using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Models
{
    public class Car : IId//Car nasleduva od interface IId
    {
        public int Id { get; set; }
        public static int IdCounter;// integer brojac
        private string v1;
        private string v2;
        private DateTime dateTime;

        public string Model { get; set; }
        public string Plate { get; set; }//registerska tablica
        public DateTime PlateExprDate { get; set; }//data na istekuvanje na tablicaya
        public List<Driver> AsignedDriver { get; set; } = new List<Driver>();//lista na dodeleni vozaci.
        public object AsignedDrivers { get; set; }
        public object DisplayAssignedDrivers { get; set; }

        //Car konstruktor
        public Car()   
        {
            Id = IdCounter++;
        }

       
        public Car(string model,string plate,DateTime plateExprDate, List<Driver> drivers)
        {
            Id = IdCounter++;
            Model = model;
            Plate = plate;
            PlateExprDate = plateExprDate;
            AsignedDriver = drivers;
        }

        public Car(string v1, string v2, DateTime dateTime)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.dateTime = dateTime;
        }
    }
}
