using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Models.Enums;


namespace Models
{
    public class Driver : IId//nasleduva id IId interface
    {
        public int Id { get; set; }
        public static int IdCounter = 1;
        
        //private DateTime dateTime;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Car AssignedCar { get; set; }//dodel avtoobil
        public Shift Shift { get; set; }
        public string License { get; set; }//licenca 
        public DateTime LicenseExprDate { get; set; }//istekuvanje na licencata

        // Driver konstruktor 
        
        public Driver(string firstName,string lastName,string license,DateTime exprDate)
        {
            Id = IdCounter++;
            FirstName = firstName;
            LastName = lastName;
            License = license;
            LicenseExprDate = exprDate;
        }
        

        public Driver(string firstName, string lastName, string license, DateTime exprDate, Car assignedCar, Shift shift)
        {
            Id = IdCounter++;
            FirstName = firstName;
            LastName = lastName;
            AssignedCar = assignedCar;
            Shift = shift;
            License = license;
            LicenseExprDate = exprDate;
        }

       

        public string GetDriverFullName()//metod za dobivanje na celoto ime i prezime na vozacot
        {
            return $"{FirstName} {LastName}";
        }
    }
}
