using Models;
using Models.Database;
using Services.HelprerMethods;
using Services.Interface;
using Services.Role;
using System;
using System.Collections.Generic;
using System.Text;
using Models.Enums;
using Services.Login;
using Services.Validation;

namespace Services.Menu
{
    //nasleduva od interface IMenu
    public class Menus : IMenu
    {
        //metod za start na aplikacijata
        public void StartApp()
        {
            StartMenu();
        }
        //metod za start na menito
        public void StartMenu()
        {
            Database taxiDatabase = new Database();  //initializing the database
            while (true)
            {
                ServiceHelper.DisplayTitle("\n                              Welcome to application Taxi Manager 9000");
                ServiceHelper.DisplayMessages("\n\n\nPlease PRESS 1 to login or PRESS 2 to exit application");
                ServiceHelper.DisplayMessages("\n1.Login\n2.Exit");
                string inputChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2" });// 1 ili 2
                if (inputChoice == "1") LoginMenu();//ako pritisne 1 se otvora menu
                else if (inputChoice == "2") EndApp();//ako pritisne 2 se isklucuva aplikacijata
            }
        }
        //metod za logiranje kako admin manager ili service
        public void LoginMenu()
        {
            User loggedInUser = LoginApp.EnterUserName();
            ServiceHelper.DisplayGreenMessage($"\n\n             Welcome {loggedInUser.Role} ");

            switch (loggedInUser.Role)
            {
                case roles.Administrator:
                    AdminMenu(loggedInUser);
                    break;
                case roles.Manager:
                    ManagerMenu(loggedInUser);
                    break;
                case roles.Maintenance:
                    MaintenanceMenu(loggedInUser);
                    break;
            }
        }
        //admin
        public void AdminMenu(User user)
        {
            Admin adminService = new Admin();
            while (true)
            {
                ServiceHelper.DisplayTitle("\nADMIN MENU");
                ServiceHelper.DisplayMessages("1.Create New User\n2.Delete User\n3.Change Password\n4.Logout\n5.Exit application");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3", "4", "5" });
                if (userChoice == "1") adminService.CreateNewUser();
                if (userChoice == "2") adminService.DeleteUser(user);
                if (userChoice == "3") user.ChangePassword();
                if (userChoice == "4") break;
                if (userChoice == "5") EndApp();
            }
        }
        //service
        public void MaintenanceMenu(User user)
        {
            Maintenance maintenance = new Maintenance();
            while (true)
            {
                ServiceHelper.DisplayTitle("\n  SERVICE MENU");
              ServiceHelper.DisplayMessages("1.List all Vehicles\n2.License Plate Status\n3.Change Password\n4.Logout\n5.Exit app");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3", "4", "5" });
                if (userChoice == "1") maintenance.DisplayCarsInformation();
                if (userChoice == "2") maintenance.DisplayPlateCondition();
                if (userChoice == "3") user.ChangePassword();
                if (userChoice == "4") break;
                if (userChoice == "5") EndApp();
            }
        }
        //manager
        public void ManagerMenu(User user)
        {
            Manager manager = new Manager();
            while (true)
            {
                ServiceHelper.DisplayTitle("\n MANAGER MENU");
                ServiceHelper.DisplayMessages("1.List all Drivers\n2.Drivers License Status\n3.Driver Manager Menu\n4.Change Password\n5.Logout\n6.Exit app");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3", "4", "5", "6" });
                if (userChoice == "1") manager.DisplayDrivers();
                if (userChoice == "2") manager.ShowDriversLicenseStatus();
                if (userChoice == "3") manager.DriverManager();
                if (userChoice == "4") user.ChangePassword();
                if (userChoice == "5") break;
                if (userChoice == "6") EndApp();
            }
        }

        public void EndApp()//EXIT
        {
            Console.Clear();
            ServiceHelper.DisplayMessages("THANK YOU FOR USING OUR APP ");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public void StartApplication()
        {
            throw new NotImplementedException();
        }
    }
}

