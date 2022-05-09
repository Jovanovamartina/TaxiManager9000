using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IMenu
    {
        void StartApplication();
        void StartMenu();
        void LoginMenu();
        void AdminMenu(User user);
        void ManagerMenu(User user);
        void MaintenanceMenu(User user);
        void EndApp();
    }
}
