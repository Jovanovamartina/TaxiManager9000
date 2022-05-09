using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.Database;
using Models.Enums;

namespace Services.HelprerMethods
{
    public static class DataHelper
    {
        // funkcija za prikazuvanje na userite so id username i role
        public static void DisplayListOfUsers()
        {
            foreach (User user in Database.ListOfUsers)
            {
                ServiceHelper.DisplayData($"ID: {user.Id}. Username: {user.Username}. Role: {user.Role}");
            }
        }

        //  funkcija za prikazuvanje na vozacite so id,ime i prezime,licenca,datum na istekuanje na licencata
        public static void DisplayDrivers(List<Driver> ListOfDrivers)
        {
            foreach (Driver driver in ListOfDrivers)
            {
                ServiceHelper.DisplayData($"ID: {driver.Id}. Driver {driver.GetDriverFullName()} with License {driver.License} expiering on {driver.LicenseExprDate}.");
            }
        }
        //dodeleni vozaci
        public static List<Driver> AssignedDrivers()
        {
            return Database.ListOfDrivers.Where(driver => driver.AssignedCar != null && driver.LicenseExprDate > DateTime.Today).ToList();
        }
        //nedodeleni vozaci
        public static List<Driver> UnassignedDrivers()
        {
            return Database.ListOfDrivers.Where(driver => driver.AssignedCar == null && driver.LicenseExprDate > DateTime.Today).ToList();
        }

        // funkcija za prikazuvanje na slobodni avtomobili od listata i se pravi iteracija niz nea i se prikazuva id,model,registracija..
        public static void DisplayFreeCars(List<Car> carList)
        {
            foreach (Car car in carList)
            {
                ServiceHelper.DisplayData($"ID: {car.Id}. Model: {car.Model}. License Plate: {car.Plate}. Expiery date: {car.PlateExprDate}");
            }
        }

        public static List<Car> FreeCars(Shift shift)
        {
            return Database.ListOfCars.Where(car => (car.AsignedDriver.Count == 0 && car.PlateExprDate > DateTime.Today) || (car.AsignedDriver.Count != 0 && car.AsignedDriver.All(x => x.Shift != shift) && car.PlateExprDate > DateTime.Today)).ToList();
        }

    }
}

   