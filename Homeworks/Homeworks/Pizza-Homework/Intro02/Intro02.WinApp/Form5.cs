using Intro02.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intro02.WinApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public delegate void MyDelege(Musteri musteri);
        public MyDelege delegem;

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (ValidationKontrol())
            {
 
                Musteri m = new Musteri()
                {
                    Adress = txtAdres.Text,
                    MusteriAdi = txtAd.Text
                };
                delegem(m);

            }
            else
            {
                MessageBox.Show("Girmediğiniz bilgilerinizi giriniz.");
            }

        }

        private bool ValidationKontrol()
        {
            //todo 
            if(txtAdres.Text != "" && txtAd.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
