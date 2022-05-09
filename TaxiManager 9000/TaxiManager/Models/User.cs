using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Models.Enums;

namespace Models
{
    public class User : IId//nasleduva od IId interface
    {
        public int Id { get; set; }
        public static int IdCounter = 1;
       
     

        public string Username { get; set; }//username na userot
        public string Password { get; set; }//password na userot
        public roles Role { get; set; }

        //konstruktor
      

        public User(string username, string password, roles role)
        {
            Id = IdCounter++;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
