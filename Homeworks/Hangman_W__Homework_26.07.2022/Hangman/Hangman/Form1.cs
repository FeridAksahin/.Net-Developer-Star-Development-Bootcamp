using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hede h = new Hede();
            //h.Hesapla();

            for (int i = 65; i < 65 + 26; i++)
            {
                Button btn = new Button();

                btn.Text = Convert.ToString(Convert.ToChar(i));
                btn.Click += Btn_Click;
                btn.Width = 40;
                btn.Height = 40;
                //btn.Top = 50;
                //btn.Left = 20;
                flHarfler.Controls.Add(btn);
            }

            Random rdn = new Random();
            string secilenKelime = kelimelerim[rdn.Next(0, kelimelerim.Count() - 1)];
            foreach (char item in secilenKelime.ToUpper())
            {
                Label lbl = new Label();
                //lbl.Text = item.ToString();
                lbl.Text = "_";
                lbl.Tag = item;
                lbl.Width = 40;
                lbl.Height = 40;
                flKelime.Controls.Add(lbl);

            }


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklanilanButton = sender as Button;
            int count = 0;
            string a = "";
            //  MessageBox.Show(tiklanilanButton.Text);
            foreach (Label item in flKelime.Controls)
            {
                a += Convert.ToString(item.Tag);//Seçilen kelimeyi a değişkeni ile aldım.

                if (Convert.ToString(item.Tag) == tiklanilanButton.Text)
                {
                    //aranan kelimenin harfi bulundu.
                    item.Text = tiklanilanButton.Text;
                    count++; //eğer buton ile kelime eşleşirse sayacımı arttırdım.

                }

            }
            if (count == 0) //sayaç 0 sa yani tıklanılan buton hiç bir harfi bulamadıysa
            {
                if (button1.Visible == true)//button1 isimli butonumun visible özelliği true yani görünür ise false yap
                {
                    button1.Visible = false;
                    label2.Text = "5"; //ayrıca label2.text i yani hp kısmını 5 e düşür
                }
                else if (button2.Visible == true)//button2.visible true ise onu false yani görünürlüğünü kaldır çünkü button2.visible true ise üstteki if i çıkmıstır
                                                 //ve bu else if e düşmüştür eğer bu else if'e geldiyse. demekki üstteki button1.Visible false'idir. Demekki 2. hakkındada bilemedi o yüzden 
                                                 //burayı false yapıyorum button2.visible ve label2.texti 4 e düşürüyorum.
                {
                    button2.Visible = false;
                    label2.Text = "4";
                }
                else if (button3.Visible == true)//aynı mantık 
                {
                    button3.Visible = false;
                    label2.Text = "3";
                }
                else if (button4.Visible == true)
                {
                    button4.Visible = false;
                    label2.Text = "2";
                }
                else if (button5.Visible == true)
                {
                    button5.Visible = false;
                    label2.Text = "1";
                }
                else if (button6.Visible == true)
                {
                    button6.Visible = false;
                    label2.Text = "0";
                }

            }
            if (button6.Visible == false)//eğer button6.visible false ise son hakkıda bitmiştir.
            {//kazanamamıştır yeniden başlamak isterse diye messagebox çıkartıyorum.
                if (MessageBox.Show("Kelime = " + a + ". Tekrar denemek ister misin?", "Bilemedin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart(); //yes basarsa
                }
                else
                {
                    Application.Exit(); //no basarsa
                }
            }

        }

        string[] kelimelerim = new string[] { "Ankara", "İzmir", "Bursa", "Televizyon" };

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flKelime_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
