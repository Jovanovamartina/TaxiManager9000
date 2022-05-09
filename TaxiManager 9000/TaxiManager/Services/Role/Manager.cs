using Models;
using Models.Database;
using Models.Enums;
using Services.HelprerMethods;
using Services.Interface;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Services.Role
{
    public class Manager: IManager
    {
        public void DisplayDrivers()//metod za da gi prikiaze vozacite
        {
           ServiceHelper.DisplayMessages(" LIST OF DRIVERS");
            foreach (Driver driver in Database.ListOfDrivers)
            {
                if (driver.AssignedCar != null)
                {
                    ServiceHelper.DisplayData($"ID: {driver.Id}. {driver.GetDriverFullName()} is driving in the {driver.Shift} shift with a {driver.AssignedCar.Model} car ({driver.AssignedCar.Plate}).");
                }
                else
                {
                    ServiceHelper.DisplayData($"ID: {driver.Id}. {driver.GetDriverFullName()} hasn't been assigned to a car yet.");
                }
            }
            Console.ReadLine();
        }

        public void ShowDriversLicenseStatus()//metod za prikazuvanje na vozackite dozvoli
        {
           ServiceHelper.DisplayMessages("DRIVERS LICENSE STATUS");
            Console.WriteLine(" Date: " + ServiceHelper.DateNow);
            foreach (Driver driver in Database.ListOfDrivers)
            {
                string driverInfo = $"ID: {driver.Id}. Driver {driver.GetDriverFullName()} with License {driver.License} expiering on {driver.LicenseExprDate}.";
                if (driver.LicenseExprDate <ServiceHelper.DateNow)
                {
                    ServiceHelper.DisplayRedMessage(driverInfo);
                }
                else if (ServiceHelper.DateNow.AddMonths(+3) > driver.LicenseExprDate)
                {
                    ServiceHelper.DisplayYellowMessage(driverInfo);
                }
                else
                {
                    ServiceHelper.DisplayGreenMessage(driverInfo);
                }
            }
            Console.ReadLine();
        }

        public void DriverManager()
        {
            while (true)
            {
                ServiceHelper.DisplayTitle(" DRIVER MANAGER");
                ServiceHelper.DisplayMessages("1.Assign driver\n2.Unassign driver\n3.Back to Manager Menu");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3" });
                if (userChoice == "1") AssignDriver();
                if (userChoice == "2") UnassignDriver();
                if (userChoice == "3") break;
            }
        }

        public void AssignDriver()
        {
            List<Driver> unAssignedDrivers = DataHelper.UnassignedDrivers();
            while (true)
            {
                ServiceHelper.DisplayTitle("\nAssign Driver");
                if (unAssignedDrivers.Count == 0)
                {
                    ServiceHelper.DisplayRedMessage(" NO DRIVER AVAILABLE!");
                    break;
                }
                ServiceHelper.DisplayMessages("List of unassigned drivers:");
                DataHelper.DisplayDrivers(unAssignedDrivers);
                int driverId = Validations.GetValidId(unAssignedDrivers);
                Driver selectedDriver = Database.ListOfDrivers.FirstOrDefault(x => x.Id == driverId);
                Shift shiftChoice = GetAShift();
                List<Car> availableCars = DataHelper.FreeCars(shiftChoice);
                if (availableCars.Count == 0)
                {
                    ServiceHelper.DisplayRedMessage($" NO CARS AVAILABLE FOR THE {shiftChoice} SHIFT!");
                    break;
                }
                DataHelper.DisplayFreeCars(availableCars);
                int carId = Validations.GetValidId(availableCars);
                Car selectedCar = Database.ListOfCars.FirstOrDefault(x => x.Id == carId);
                selectedCar.AsignedDriver.Add(selectedDriver);
                availableCars.Remove(selectedCar);
                unAssignedDrivers.Remove(selectedDriver);
                selectedDriver.Shift = shiftChoice;
                selectedDriver.AssignedCar = selectedCar;
                ServiceHelper.DisplayGreenMessage($"Successfully assigned driver {selectedDriver.GetDriverFullName()} to the car {selectedDriver.AssignedCar.Model} ({selectedDriver.AssignedCar.Plate}) with a {selectedDriver.Shift} shift.");
                Console.ReadLine();
                break;
            }
        }

        private Shift GetAShift()
        {
            while (true)
            {
                ServiceHelper.DisplayMessages("Choose a shift:\n1.Morning\n2.Afternoon\n3.Evening");
                string inputChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3" });
                if (inputChoice == "1") return Shift.Morning;
                if (inputChoice == "2") return Shift.Afternoon;
                if (inputChoice == "3") return Shift.Evening;
            }
        }

        public void UnassignDriver()
        {
            List<Driver> assignedDrivers = DataHelper.AssignedDrivers();
            while (true)
            {
                ServiceHelper.DisplayTitle("\n Unassign Driver");
                if (assignedDrivers.Count == 0)
                {
                   ServiceHelper.DisplayRedMessage(" NO DRIVER AVAILABLE!");
                    break;
                }
               ServiceHelper.DisplayMessages("List of assigned drivers:");
                DataHelper.DisplayDrivers(assignedDrivers);
                int driverId = Validations.GetValidId(assignedDrivers);
                Driver selectedDriver = Database.ListOfDrivers.FirstOrDefault(x => x.Id == driverId);
                selectedDriver.AssignedCar = null;
                selectedDriver.Shift = 0;
                break;
            }
        }

        public void DisplayDriversLicenseCondition()
        {
            throw new NotImplementedException();
        }
    }
}

