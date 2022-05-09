using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Database
{
    public class Database//BAZA NA SITE  PODATOCI !!!!!!!
    {
        public static List<Car> ListOfCars { get; set; } = new List<Car>();
        public static List<Driver> ListOfDrivers { get; set; } = new List<Driver>();
        public static List<User> ListOfUsers { get; set; } = new List<User>()
        {
            // so ovie se logirame
            new User("Admin","admin",roles.Administrator),
            new User("Manager","manager",roles.Manager),
            new User("Service","service",roles.Maintenance),
           
        };

        //konstruktor
        public Database()
        {
            // CARS OBJEKTI
            Car audi = new Car("Audi", "VE1234AA", new DateTime(2022, 4, 14));
            Car mercedes = new Car("Mercedes", "Ve4321AA", new DateTime(2022, 1, 16));
            Car fiat = new Car("Fiat", "VE5678BF", new DateTime(2023, 9, 5));
            Car ford = new Car("Ford", "VE5219MM", new DateTime(2022, 2, 20));
            Car volkswagen = new Car("Volkswagen", "VE1010FF", new DateTime(2023, 8, 14));

            //DRIVERS OBJEKTI
            Driver David = new Driver("David", "Nastov", "1122", new DateTime(2023, 1, 13));
            Driver Damjan = new Driver("Damjan", "Jovanov", "2233", new DateTime(2023, 5, 11));
            Driver Hristijan = new Driver("Hristijan", "Dimovski", "3344", new DateTime(2023, 2, 15));
            Driver Dimitar = new Driver("Dimitar", "Trajanov", "4455", new DateTime(2022, 4, 15));
            Driver Dragan = new Driver("Dragan", "Stojkovski", "5566", new DateTime(2022, 3, 15));
            Driver Marko = new Driver("Marko", "Dimitrov", "6677", new DateTime(2026, 5, 11));
            Driver Zoran = new Driver("Zoran", "Zdravkov", "7788", new DateTime(2024, 2, 12));
            Driver aleksandar = new Driver("Aleksandar", "Stojanovski", "8899", new DateTime(2022, 3, 3));
            Driver Martin = new Driver("Martin", "Mircev", "9999", new DateTime(2024, 6, 12));
            Driver Matej = new Driver("Matej", "Kocevski", "1919", new DateTime(2025, 10, 10));

            // dodavanje avtomobi na listata
            ListOfCars.Add(audi);
            ListOfCars.Add(mercedes);
            ListOfCars.Add(fiat);
            ListOfCars.Add(ford);
            ListOfCars.Add(volkswagen);

            //dodavanje vozaci na listata
            ListOfDrivers.Add(David);
            ListOfDrivers.Add(Damjan);
            ListOfDrivers.Add(Hristijan);
            ListOfDrivers.Add(Dimitar);
            ListOfDrivers.Add(Dragan);
            ListOfDrivers.Add(Marko);
            ListOfDrivers.Add(Zoran);
            ListOfDrivers.Add(aleksandar);
            ListOfDrivers.Add(Martin);
            ListOfDrivers.Add(Matej);

        }
    }
}
