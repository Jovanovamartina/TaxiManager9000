using Services.Menu;
using System;


namespace TaxiManager9000
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menus startApp = new Menus();
            startApp.StartApp();

            Console.ReadLine();
        }
    }

   
}
