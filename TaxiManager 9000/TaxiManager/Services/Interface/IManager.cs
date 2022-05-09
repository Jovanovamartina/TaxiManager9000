using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
   public interface IManager
    {
        void DisplayDrivers();
        void DisplayDriversLicenseCondition();
        void DriverManager();
        void AssignDriver();
        void UnassignDriver();
    }
}
