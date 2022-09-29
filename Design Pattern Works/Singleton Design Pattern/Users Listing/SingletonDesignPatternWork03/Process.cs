using SingletonDesignPatternWork03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPatternWork03
{
    internal class Process  
    {
        public Process()
        {

        }
        List<Register> list = new List<Register>();
        public Process(List<Register> list)
        {
            this.list = list;
        }
        public void Question()
        {
            int count = 0;
            string[] a = { "Register", "Kayıt olanları listele" };
            foreach(string ar in a)
            {
                count++;
                Console.WriteLine(count+" - "+ar);
            }
            string input = Console.ReadLine();
            if (input == "1")
            {
                RegisterPage rp = RegisterPage.GetInstance();
                rp.RegisterProc();
            }
            else if(input == "2")
            {
                listing();
            }
            else
            {
                Console.WriteLine("1 veya 2 tuşlanmalı");
                Question();
            }

        }
        public void listing()
        {
            int count = 0;
            foreach (Register register in list)
            {
                count++;
                Console.WriteLine(count+". Kullanıcı Adı : "+ register.UserName);
                Console.WriteLine(count + ". Kullanıcı Şifresi : " + register.Password);
            }
            Question();
        }
    }
}
