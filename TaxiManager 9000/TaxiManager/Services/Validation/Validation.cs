using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Services.HelprerMethods;
using Models.Database;

namespace Services.Validation
{
    public static class Validations
    {
        //metod za validacija na user choise ,login or exit !!!!
        public static string ValidationOfUserChoice(string[] validChoice)
        {
            while (true)
            {
                string inputChoice = Console.ReadLine();
                if (validChoice.Contains(inputChoice))
                {
                    return inputChoice;
                }
                else
                {
                    ServiceHelper.DisplayRedMessage("PLEASE SELECT VALID OPTION ");
                    continue;
                }
            }
        }
        //metod za validacija na username
        public static User ValidateUsername(string userName)
        {
            return Database.ListOfUsers.FirstOrDefault(x => x.Username == userName);
        }
        //metod za validacija na id
        
        public static User ValidateId(int id)
        {
            return Database.ListOfUsers.FirstOrDefault(x => x.Id == id);
        }

        public static bool ValidateId<T>(int id, List<T> modelsList) where T : IId
        {
            return modelsList.Any(x => x.Id == id);
        }
        
        public static int GetValidId<T>(List<T> modelsList) where T : IId
        {
            while (true)
            {
                try
                {
                    string idInput = Console.ReadLine();
                    bool isValid = int.TryParse(idInput, out int id);
                    if (string.IsNullOrWhiteSpace(idInput))
                    {
                        ServiceHelper.DisplayError("ENTER VALUE!");
                    }
                    else if (!isValid)
                    {
                        ServiceHelper.
                            DisplayError("ENTER VALID ID!");
                    }
                    else if (!ValidateId(id, modelsList))
                    {
                        ServiceHelper.DisplayError("ENTER ID FROM THE LIST!");
                    }
                    return id;
                }
                catch (Exception ex)
                {
                    ServiceHelper.DisplayRedMessage(ex.Message);
                }
        
            }

        }
        
    }
        
}

    
