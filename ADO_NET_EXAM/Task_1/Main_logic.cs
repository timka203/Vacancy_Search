using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Timers;

namespace Task_1
{
    public class Main_logic
    {
        public static void start()
        {
            using (Model_info_type2 db = new Model_info_type2())
            {
                List<Information> infos = new List<Information>();
                try
                {
                infos = GetInformation.GetRates<Information>("http://www.nationalbank.kz/rss/rates.xml");
                    infos.Sort();
                }
                catch (Exception)
                {
                    MailSender.Send_mail("XML файл не соделрит нужну информацию или содержет её в неподдерживаемом виде ");
                    
                }

                List<Information> test = new List<Information>();
                try
                {
                   test = db.information.ToList();
                }
                catch (Exception ex)
                {
                    MailSender.Send_mail(ex.ToString());

                }  
         

                Console.WriteLine("Проверка данных");
                if (!Equals(infos, test)||Convert.ToDateTime(test[0].pubDate)<DateTime.Now)
                {
                    Console.WriteLine("Обновление данных");
                    db.Database.ExecuteSqlCommand("delete from Information");
                    db.information.AddRange(infos);
                    db.Database.CreateIfNotExists();
                    db.SaveChanges();
                }
                Console.WriteLine("Данные совпадают");



                //db.info.Add(infos[0]);
                //db.SaveChanges();


            }
        }
       
            public static bool Equals(List<Information> infos, List<Information> test)
            {
            if (infos.Count!=test.Count())
            {
                return false;
            }
            List<bool> bl = new List<bool>(); 
            for (int i = 0; i < infos.Count; i++)
            {
             bl.Add(infos[i].title== test[i].title);
                bl.Add(infos[i].quant == test[i].quant);
                bl.Add(infos[i].pubDate == test[i].pubDate);
                bl.Add(infos[i].description ==test[i].description);
            }
            return bl.All(a=>a==true);
        }

        
        }
    }


