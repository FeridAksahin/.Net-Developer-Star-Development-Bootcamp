using Intro.Hastane.MyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intro.Hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  Bolum b = new Bolum();
            #region MyRegion
            //int i = 0;
            //string s = "";
            //object o = null ;
            ////immutable type  //mutable type 
            //Object okl = new Object();
            ////String str = new String(null);
            ////Struct  Ref 
            #endregion


        }

        private bool sayac = true;
      //  const bool sayac02 = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sayac)
            {
                bolumlerim = new List<Bolum>();
                sayac = false;
               // sayac02 = true;
            }            

            if (ValidateEt(textBox1.Text, textBox2.Text))
            {
                bolumlerim.Add(new Bolum()
                {
                    //record daha sonra konuşucaz .

                    Aciklama = textBox2.Text,
                    BolumAdi = textBox1.Text
                });

                Bolum bl = new Bolum(599);
                bl.bolumadi = textBox1.Text;
                bl.aciklama = textBox2.Text;

                errorProvider1.Clear();
                MessageBox.Show("veri başarıyla eklendi..");
                Temizle();
            }
            else
            {
                //error
                errorProvider1.SetError(textBox1, "boş geçilemez... ");
               // MessageBox.Show("validate edilemedi.");
            }

        }

        private void Temizle()
        {
            textBox1.Text = textBox2.Text = string.Empty;
            //using (Bolum  b = new Bolum())
            //{


            //}
        }

        private bool ValidateEt(string text1, string text2)
        {
            //if (!string.IsNullOrWhiteSpace(text1))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


            return (string.IsNullOrWhiteSpace(text1) == true && string.IsNullOrWhiteSpace(text2) == true)
                ? false
                : true;


        }

        List<Bolum> bolumlerim = null;

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 ye git
            if (bolumlerim != null)
            {
                Form2 f = new Form2(bolumlerim);
                f.Show();


            }
            else
            {
                // todo slfslkdflsdf
                MessageBox.Show("Test");
            }

        }
    }
}
