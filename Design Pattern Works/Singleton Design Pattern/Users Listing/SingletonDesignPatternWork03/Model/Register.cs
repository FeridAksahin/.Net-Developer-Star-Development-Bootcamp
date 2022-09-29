using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatternWork03.Model
{
    internal class Register
    {
        string username;
        string password;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                if (string.IsNullOrEmpty(username))
                {
                    throw new FormatException("Username boş geçilmemeli");
                }

            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                if (string.IsNullOrEmpty(password))
                {
                    throw new FormatException("Password boş geçilmemeli");
                }
            }
        }
    }
}
