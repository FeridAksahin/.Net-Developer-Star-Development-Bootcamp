using SingletonDesignPatternWork03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatternWork03
{
    internal class RegisterPage
    {
        List<Register> list = new List<Register>();

        private RegisterPage()
        {

        }
        private static RegisterPage instance;

        public static RegisterPage GetInstance()
        {
            if (instance == null)
            {
                instance = new RegisterPage();
            }
            return instance;
        }

        public void RegisterProc()
        {
            try
            {
                Console.WriteLine("Name : ");
                string s = Console.ReadLine();
                Console.WriteLine("Password : ");
                string pass = Console.ReadLine();
                Register r = new Register();
                r.UserName = s;
                r.Password = pass;
                list.Add(r);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Process p = new Process(list);
            p.Question();
        }
    }
}
