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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<Bolum> _bolumler;
        public Form2(List<Bolum> bolumler) : this()
        {
            _bolumler = bolumler;
            foreach (var item in _bolumler)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                lstDoktorlar.Items.Add(new Doktor()
                {
                    Adres = textBox2.Text,
                    DoktorAdSoyad = textBox1.Text,
                    Tel = maskedTextBox1.Text,
                    Bolum = comboBox1.SelectedItem as Bolum
                });
                Temizle();
            }
        }

        private void Temizle()
        {
            //todo 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(DoktorlariListele(), _bolumler);
            f.Show();
        }

        private List<Doktor> DoktorlariListele()
        {

            List<Doktor> hazirDoktorlar = new List<Doktor>();
            //  var hede = (List<Doktor>) lstDoktorlar.Items;
            foreach (Doktor item in lstDoktorlar.Items)
            {
                hazirDoktorlar.Add(item);
            }
           
            return hazirDoktorlar;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
