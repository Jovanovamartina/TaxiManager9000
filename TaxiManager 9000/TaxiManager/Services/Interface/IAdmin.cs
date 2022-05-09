using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Models;


namespace Services.Interface
{
    public interface IAdmin
    {
        void CreateNewUser();//metod za kreiranje nov korisnik
        void RemoveUser(User user);//metod za brisenje na korisnik
    }
}
