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
    public partial class Form3 : Form
    {
        private List<Doktor> doktors;
        private List<Bolum> bolumler;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<Doktor> doktors):this()
        {
            this.doktors = doktors;
        }

        public Form3(List<Doktor> doktors, List<Bolum> bolumler) : this(doktors)
        {
            this.bolumler = bolumler;
            foreach (var item in bolumler)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (var item in this.doktors)
            {
                lstDoktorlar.Items.Add(item);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bolum secilenBolum= comboBox1.SelectedItem as Bolum;
            lstDoktorlar.Items.Clear();
            foreach (var item in doktors)
            {
                if (item.Bolum.BolumAdi == secilenBolum.BolumAdi)
                {
                    lstDoktorlar.Items.Add(item);
                }
            }
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            //todo arama geliştir. 
            //  var degerler = doktors.Where(x => x.DoktorAdSoyad == "efe").ToList();
            string input = textBox3.Text;
            List<Doktor> ar = new List<Doktor>();//searchte bulunanları atayacağım liste.
            int count = 0;
            foreach (var item in this.doktors)//doktors listesinde dönme
            {
                item.DoktorAdSoyad = item.DoktorAdSoyad.ToLower();//listedeki .DoktorAdSoyad değişken karsılıklarını küçük harf
                if (item.DoktorAdSoyad.Contains(input.ToLower()))//eğer textBox'tan girilen değer listedeki DoktorAdSoyad olan değişken karsılığına eşitse
                {
                    ar.Add(item);//listeye ekle
                    count++;//sayacı arttır demekki arama yapılanın karsılığı mevcut
                }
            }
            lstDoktorlar.Items.Clear();//doktorları temizleki aranan doktor ya da doktorlar sadece gözüksün
            if (count > 0) //eğer aramanın karsılıgı var ise
            {
                foreach (var item2 in ar) //arama sonucu karsılıgı olan doktorları ekledigim listelerde dönüş
                {
              
                    lstDoktorlar.Items.Add(new Doktor()
                    {
                        DoktorAdSoyad = item2.DoktorAdSoyad //listedeki elemanları yazdırma
                    });

                }
               
            }
         
        }

        List<Hasta> hastalarim = new List<Hasta>();

        private void button2_Click(object sender, EventArgs e)
        {
            if (true)
            {
                hastalarim.Add(new Hasta()
                {
                    Ad = textBox1.Text,
                    Soyad = textBox2.Text,
                    TC = maskedTextBox1.Text,
                    Doktor = lstDoktorlar.SelectedItem as Doktor,
                    HastaSikayet = textBox4.Text,
                    DoktorTeshis = textBox5.Text,
                    KayitTarihi = DateTime.Now
                });
                Temizle();
                MessageBox.Show("Hasta kaydı yapıldı.");
            }
            else
            {
                MessageBox.Show("Test");
            }
        }
        private void Temizle()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4(hastalarim);
            frm.Show();

        }
    }
}
