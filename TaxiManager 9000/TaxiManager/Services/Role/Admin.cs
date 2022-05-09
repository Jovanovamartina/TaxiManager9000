
using System;
using System.Collections.Generic;
using System.Text;
using Services.Validation;
using Models.Database;
using Models;
using Services.HelprerMethods;
using Services.Login;
using Models.Enums;
using Services.Interface;

namespace Services.Role
{
    //naslediva od interface IAdmin
    public class Admin : IAdmin
    {
        // metod za kreiranje nov user
        public void CreateNewUser()
        {
            ServiceHelper.DisplayTitle("Create new user please");
            bool ifIsTrue = true;
            while (ifIsTrue)
            {
                string username = LoginApp.CreateNewUsername();
                string password = LoginApp.CreateNewPassword();

                ServiceHelper.DisplayMessages("select a role: \n1.Administrator\n2.Manager\n3.Maintenance");

                string selectedRole = Validations.ValidationOfUserChoice(new string[] { "1", "2", "3" });
                roles role = selectedRole == "1" ? roles.Administrator : selectedRole == "2" ? roles.Manager : roles.Maintenance;
                User newUser = new User(username, password, role);

                Database.ListOfUsers.Add(newUser);
                ServiceHelper.DisplayGreenMessage($"Successfully created new user {newUser.Username} with a role {newUser.Role} and an Id {newUser.Id}.");
                ServiceHelper.DisplayMessages("\n1.Add another user\n2.Back to admin menu");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2" });
                ifIsTrue = userChoice == "1" ? true : false;
            }
        }
        //metod za brisenje user
        public void DeleteUser(User user)
        {
            ServiceHelper.DisplayTitle("Delete user");
            bool ifIsTrue = true;
            while (ifIsTrue)
            {
                DataHelper.DisplayListOfUsers();
                ServiceHelper.DisplayMessages("Enter the id of the user you wish to delete:\n*0 to cancel");
                string inputChoice = Console.ReadLine();
                if (inputChoice == "0") break;
                bool isValidInput = int.TryParse(inputChoice, out int idValue);
                if (!isValidInput)
                {
                    ServiceHelper.DisplayRedMessage("Enter valid choise!");
                    continue;
                }
                User deleteUser = Validations.ValidateId(idValue);
                if (deleteUser == null)
                {
                    ServiceHelper.DisplayRedMessage("No user with that id!");
                    continue;
                }
           
                ServiceHelper.DisplayGreenMessage($"Successfully deleted {deleteUser.Role} user {deleteUser.Username} with id {deleteUser.Id}");
                Database.ListOfUsers.Remove(deleteUser);
                ServiceHelper.DisplayMessages("\n1.Remove another user\n2.Back to admin menu");
                string userChoice = Validations.ValidationOfUserChoice(new string[] { "1", "2" });
                ifIsTrue = userChoice == "1" ? true : false;
            }
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
