using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_1;

namespace Vacancy
{
    public static class Work_with_class
    {
        public static void setVacancies(string url, string name)
        {
            Category category = GetCategory(url);
            category.Category_Name = name;
            
            using (Vacancy_ModelContainer db = new Vacancy_ModelContainer())
            {
               
                if(!db.CategorySet.Any(a=>a.Category_Name==category.Category_Name))
                {
                    db.CategorySet.Add(category);
                   
                    db.SaveChanges();
                }
                category.Id = db.CategorySet.Where(w => w.Category_Name == category.Category_Name).Select(s => s.Id).Single();
               
                if (!Equal(category.Vacancy.ToList(), db.CategorySet.Where(w=>w.Category_Name==category.Category_Name).Single().Vacancy.ToList()))
                {
                    db.Database.ExecuteSqlCommand("delete from VacancySet where CategoryId ="+ db.CategorySet.Where(g => g.Category_Name == category.Category_Name).Select(s => s.Id).Single().ToString());
                    db.VacancySet.AddRange(category.Vacancy.ToList());
                    db.SaveChanges();
                }
               
            }

        }
        public static List<Category> GetCategories()
        {
            using (Vacancy_ModelContainer db = new Vacancy_ModelContainer())
            {
                return db.CategorySet.ToList();
            }
        }
        public static bool Equal(List<Vacancy> vacancies, List<Vacancy> test)
        {
           
                if (vacancies.Count != test.Count())
                {
                    return false;
                }
                List<bool> bl = new List<bool>();
                for (int i = 0; i < vacancies.Count; i++)
                {
                    bl.Add(vacancies[i].title == test[i].title);
                    bl.Add(vacancies[i].link == test[i].link);
                    bl.Add(vacancies[i].pubDate == test[i].pubDate);
                    bl.Add(vacancies[i].description == test[i].description);
                bl.Add(vacancies[i].guid == test[i].guid);
                bl.Add(vacancies[i].author == test[i].author);
      
            }
                return bl.All(a => a == true);
            }
        public static Category GetCategory(string xml)
        {
            Category category = new Category();
            List<Vacancy> rates = new List<Vacancy>();


            XDocument xDoc = new XDocument();
            try
            {
                xDoc = XDocument.Load(xml);
            }
            catch (Exception)
            {
                

            }
            try
            {
    
                foreach (var item in xDoc.Descendants("item"))
                {
                    Object istanance = Activator.CreateInstance(typeof(Vacancy));
                    foreach (var items in item.Elements())
                    {



                        foreach (PropertyInfo prop in istanance.GetType().GetProperties())
                        {

                            if (items.Name == prop.Name)
                            {
                                istanance.GetType().GetProperty(prop.Name).SetValue(istanance, items.Value);
                            }


                        }

                    }
                    
                    rates.Add(istanance as Vacancy);
                }
            }
            catch (Exception)
            {
              

            }
      
            category.Vacancy = rates;
            Console.WriteLine(rates.Count());
            return category;

        }

    }

}

