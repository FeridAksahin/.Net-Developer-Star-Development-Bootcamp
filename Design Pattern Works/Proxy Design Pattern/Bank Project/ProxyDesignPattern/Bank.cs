using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesignPattern
{
    internal class Bank : IBank
    {//Real Subject Class
        public bool Pay(double amount)
        {
            if(amount < 50)
            {
                MessageBox.Show("50 den küçük olamaz");
            }else if(amount > 100)
            {
                MessageBox.Show("100 den büyük olamaz");
            }
            else
            {
                MessageBox.Show("Ödeme gerçekleşti tutar : "+ amount);
            }
            return false;
        }
    }
}
