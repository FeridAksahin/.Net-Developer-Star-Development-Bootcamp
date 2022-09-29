using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesignPatternWork02
{
    public class LogProxy : ILog
    {//Proxy Class
        Log log;
        bool login;
        string username, password;

        public LogProxy(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public void Login()
        {
            log = new Log();
            if (username.Equals("ferid") && password.Equals("ferid123"))
            {
                login = true;
                MessageBox.Show("Hesaba giriş yapıldı.");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı şifre yanlış");
                login = false;
            }
      
     
        }
        public void loginLog()
        {
            Login();
            if (login == false)
            {
                MessageBox.Show("Hesaba giriş yapılamadı");
                log.loginLog(false);
            }
            else
            {
                log.loginLog(true);
            }
           
        }
    }
}
