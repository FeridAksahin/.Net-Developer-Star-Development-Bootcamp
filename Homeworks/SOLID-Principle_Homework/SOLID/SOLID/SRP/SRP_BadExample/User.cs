using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Single Responsibility Principle
namespace SOLID.SRP.SRP_BadExample
{
    internal class AddUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    internal class User
    {
        public void AddUser(AddUserModel model)
        {
            //Codes for add user
        }
        public void SendMailToUser()
        {
            //kullanıcı eklenirse mail yolla kodları
        }

    }
   
}
