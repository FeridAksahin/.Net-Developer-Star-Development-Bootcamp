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
    public partial class Form4 : Form
    {
        private List<Hasta> hastalarim;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(List<Hasta> hastalarim):this()
        {
            this.hastalarim = hastalarim;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            int sira = 1;
            foreach(Hasta hasta in hastalarim)
            {
                ListViewItem li = new ListViewItem();
                li.Text = (sira++).ToString();
                li.SubItems.Add(hasta.Ad + " " + hasta.Soyad);
                li.SubItems.Add(hasta.TC);
                li.SubItems.Add(hasta.Doktor.DoktorAdSoyad);
                li.SubItems.Add(hasta.Doktor.Bolum.BolumAdi);
                li.SubItems.Add(hasta.KayitTarihi.ToShortDateString());
                //li.Tag = hasta;
                listView1.Items.Add(li);
                
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
