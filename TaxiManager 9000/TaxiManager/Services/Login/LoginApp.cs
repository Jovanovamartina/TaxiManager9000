using System;
using System.Linq;
using Models;
using Services.HelprerMethods;
using Services.Validation;

namespace Services.Login

{
    public static class LoginApp
    {
        //metod za kreiranje nov user
        public static string CreateNewUsername()
        {
            while (true)
            {
                ServiceHelper.DisplayMessages("Enter username:");
                string username = Console.ReadLine();
                if (Validations.ValidateUsername(username) != null)
                {
                    ServiceHelper.DisplayRedMessage("THAT USERNAME ALREADY EXISTS!");
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(username))
                {
                    ServiceHelper.DisplayRedMessage("ENTER VALUE!");
                    continue;
                }
                else if (username.Length < 5)
                {
                    ServiceHelper.DisplayRedMessage("MUST CONTAIN AT LEAST 5 CHARACTERS!");
                    continue;
                }
                return username;
            }
        }
        //metod za promena na lozinka
        public static void ChangePassword(this User user)
        {
            ServiceHelper.DisplayTitle("Change password");
            while (true)
            {
                ServiceHelper.DisplayMessages("Enter old password:");
                string oldPassword = Console.ReadLine();
                if (oldPassword != user.Password)
                {
                    ServiceHelper.DisplayRedMessage("INVALID PASSWORD!");
                    continue;
                }
                string newPassword = CreateNewPassword();
                if (oldPassword == newPassword)
                {
                    ServiceHelper.DisplayRedMessage("TRY CHANGING THE OLD ONE!");
                    continue;
                }
                user.Password = newPassword;
                ServiceHelper.DisplayGreenMessage("Successfully changed password.");
                Console.ReadLine();
                break;
            }
        }
        //metod za kreiranje nov password
        public static string CreateNewPassword()
        {
            string inputPassword = string.Empty;
            while (true)
            {
                ServiceHelper.DisplayMessages("Enter new password:");
                inputPassword = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputPassword))
                {
                   ServiceHelper.DisplayRedMessage("ENTER VALUE!");
                    continue;
                }
                else if (inputPassword.Length < 5)
                {
                   ServiceHelper.DisplayRedMessage("TOO SHORT! MUST CONTAIN AT LEAST 5 CHARACTERS!");
                    continue;
                }
                else if (!inputPassword.Any(char.IsDigit))
                {
                  ServiceHelper.DisplayRedMessage("THE PASSWORD MUST CONTAIN A NUMBER!");
                    continue;
                }
                else
                {
                    return inputPassword;
                }
            }
        }
        //metod za logiranje za  username 
        public static User EnterUserName()
        {
            while (true)
            {
                try
                {
                    ServiceHelper.DisplayMessages("Enter username: ");
                    string inputUsername = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputUsername))
                    {
                      ServiceHelper.DisplayError("ENTER A VALUE!");
                    }
                    User user = Validations.ValidateUsername(inputUsername);
                    if (user == null)
                    {
                        ServiceHelper.DisplayError("NO USER WITH THAT USERNAME FOUND!");
                    }
                    else
                    {
                        EnterPassword(user);
                        return user;
                    }
                }
                catch (Exception ex)
                {
                    ServiceHelper.DisplayRedMessage(ex.Message);
                }
            }
        }

        //metod za logiranje za password
        public static void EnterPassword(User user)
        {
            while (true)
            {
                try
                {
                    ServiceHelper.DisplayMessages("Enter password: ");
                    string inputPassword = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(inputPassword))
                    {
                        ServiceHelper.DisplayError("ENTER A VALUE!");
                    }
                    else if (user.Password != inputPassword)
                    {
                       ServiceHelper.DisplayError("INVALID PASSWORD!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    ServiceHelper.DisplayRedMessage(ex.Message);
                }
            }
        }

    }
}


     

        
