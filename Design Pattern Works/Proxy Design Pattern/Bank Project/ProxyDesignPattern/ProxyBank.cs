using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesignPattern
{

    internal class ProxyBank : IBank
    {//Proxy Class
        Bank bank;
        bool login;
        string username, password;
        public ProxyBank(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        bool Login()
        {
            if (username.Equals("ferid") && password.Equals("ferid123"))
            {
                bank = new Bank();
                login = true;
                MessageBox.Show("Hesaba giriş yapıldı.");
                return true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı şifre yanlış");
            }
            login = false;
            return false;
        }
        public bool Pay(double amount)
        {
            Login();
            if (login == false)
            {

                MessageBox.Show("Hesaba giriş yapılamadıgından ödeme gerçekleşmedi");
                return false;
            }
            bank.Pay(amount);
            return true;
        }
    }
}
