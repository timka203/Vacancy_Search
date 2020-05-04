using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task_1
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
           // MailSender.Send_mail("test");
            SetTimer();
            Console.ReadLine();

        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Main_logic.start();
        }
    }
}
