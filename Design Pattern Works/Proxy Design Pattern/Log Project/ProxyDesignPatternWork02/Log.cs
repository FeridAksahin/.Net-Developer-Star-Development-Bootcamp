using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesignPatternWork02
{
    internal class Log
    {//Real Subject Class
        public void loginLog(bool situation)
        {
            if (situation == true)
            {
                Form2 f = new Form2();
                f.Show();
                MessageBox.Show("Login log kayıtları tutuldu");
                //log codes
            }
            else if (situation == false)
            {
                MessageBox.Show("Login log kayıtları tutulamadı çünkü giriş sağlanamadı.");
            }
        }
    }
}
