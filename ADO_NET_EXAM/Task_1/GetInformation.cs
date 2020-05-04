using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_1
{
  public  class GetInformation
    {
        public static List<T> GetRates<T>(string xml)
        {
            List<T> rates = new List<T>();


            XDocument xDoc = new XDocument();
            try
            {
                xDoc = XDocument.Load(xml);
            }
            catch (Exception)
            {
                MailSender.Send_mail("Невозможно получить XML файл");
               
            }
            try
            {
                foreach (var item in xDoc.Descendants("item"))
                {
                    Object istanance = Activator.CreateInstance(typeof(T));
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
                    rates.Add((T)Convert.ChangeType(istanance, typeof(T)));
                }
            }
            catch (Exception)
            {
                MailSender.Send_mail("Невозможно создать объект на основе XML,возможно,поменялась конструкция XML файла");
             
            }
           
         
            Console.WriteLine(rates.Count());
            return rates;

        }
       
    }
}

