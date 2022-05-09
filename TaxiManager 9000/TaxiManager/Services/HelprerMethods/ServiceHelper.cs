using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace Services.HelprerMethods
{
    public class ServiceHelper//helper klasa kade sto gi cuvame site metodi za boja na porakite sto se ispisuvaat.
    {
        public static DateTime DateNow = DateTime.Today;
        public static void DisplayMessages(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void DisplayData(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void DisplayTitle(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void DisplayRedMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void DisplayGreenMessage(string msg)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void DisplayYellowMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

      

        public static void  DisplayError(string msg)
        {
            throw new Exception(msg);
        }
    }
}
