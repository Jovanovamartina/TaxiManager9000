using Models;
using Models.Database;
using Services.HelprerMethods;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Services.Role
{
    //nasleduva od IMaintenance
    public class Maintenance : IMaintenance
    {
        
        public void DisplayCarInformation()
        {
            throw new NotImplementedException();
        }

        public void DisplayCarsInformation()//info za avtomobilite
        {
            ServiceHelper.DisplayMessages("LIST OF CARS");
            foreach (Car car in Database.ListOfCars)
            {
               ServiceHelper.DisplayData($"{car.Id}. Model: {car.Model}. License Plate: {car.Plate} ");
                if (car.AsignedDriver.Count != 0)
                {
                    ShiftsCovered shiftsCovered = GetShifts(car);
                    ServiceHelper.DisplayGreenMessage($"{shiftsCovered.Morning}\n{shiftsCovered.Afternoon}\n{shiftsCovered.Evening}");
                }
                else
                {
                    ServiceHelper.DisplayRedMessage($"This car doesn't have assigned drivers yet.");
                }
            }
            Console.ReadLine();
        }
        //metod za prikazuvanje sttaus na registracii
        public void DisplayPlateCondition()
        {
            throw new NotImplementedException();
        }

        public void ShowLicensePlateStatus()
        {
           ServiceHelper.DisplayMessages("LICENSE PLATE STATUS");
            Console.WriteLine("Current date: " + ServiceHelper.DateNow);
            foreach (Car car in Database.ListOfCars)
            {
                string carInfo = $"ID: {car.Id}. Model: {car.Model}. License Plate: {car.Plate}. Expiery date: {car.PlateExprDate}";
                if (car.PlateExprDate < ServiceHelper.DateNow)
                {
                    ServiceHelper.DisplayRedMessage(carInfo);
                }
                else if (ServiceHelper.DateNow.AddMonths(+3) > car.PlateExprDate)
                {
                   ServiceHelper.DisplayYellowMessage(carInfo);
                }
                else
                {
                   ServiceHelper.DisplayGreenMessage(carInfo);
                }
            }
            Console.ReadLine();
        }
        //metod za prikazuvanje na smenite i podolu kalsata za smenite
        private ShiftsCovered GetShifts(Car car)
        {
            double morningShift = 0;
            double afternoonShift = 0;
            double eveningShift = 0;
            foreach (Driver driver in car.AsignedDriver)
            {
                if (driver.Shift.ToString() == "Morning") morningShift++;
                else if (driver.Shift.ToString() == "Afternoon") afternoonShift++;
                else if (driver.Shift.ToString() == "Evening") eveningShift++;
                else continue;
            }
            double sum = morningShift + afternoonShift + eveningShift;
            ShiftsCovered shiftPercentage = new ShiftsCovered();
            shiftPercentage.Morning = $"Morning shifts: {morningShift / sum * 100} %.";
            shiftPercentage.Afternoon = $"Afternoon shifts: {afternoonShift / sum * 100} %.";
            shiftPercentage.Evening = $"Evening shifts: {eveningShift / sum * 100} %.";

            return shiftPercentage;
        }
    }
    //class za Shifts i konstruktor
    public class ShiftsCovered
    {
        public string Morning { get; set; }
        public string Afternoon { get; set; }
        public string Evening { get; set; }
        public ShiftsCovered()
        {

        }
    }
}
