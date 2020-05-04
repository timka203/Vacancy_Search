using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Task_1
{
    class MailSender
    {
       public static void Send_mail(string message)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("timka22033@gmail.com"),
                    Subject = "Error in Project",
                    Body = message
                };

                mail.To.Add(new MailAddress(ConfigurationManager.AppSettings["LoginTo"]));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
            
                return;
            }

            Console.WriteLine("Email sccessfully sent");
        
        }
    }
}