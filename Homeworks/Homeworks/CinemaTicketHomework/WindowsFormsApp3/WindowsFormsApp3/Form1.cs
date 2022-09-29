using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Models;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<Film> films = new List<Film>();
        List<Customer> customer = new List<Customer>();
        ComboBox c1;
        ComboBox c2;
        Button b1;
        int count = 0; //kaç koltuk yani kaç buton tıkladıgını saymak için
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var i in customer)
            {
                if (i.Koltuk == null)
                {
                    MessageBox.Show("Koltuk girmediniz");
                }
            }
            ListSend();
            this.Hide();
            Form2 f = new Form2(customer, films);
            f.ShowDialog();
            f = null;
            this.Show();
   


        }

        private void ButtonDoldur()
        {

            int count = 1;
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 6; j++)
                {
                    if (count == 2 || count == 8 || count == 3 || count == 9 || count == 4 || count == 10)
                    {

                        Button btn = new Button();
                        btn.Text = (count++).ToString();
                        btn.Top = 70 * j + 50;
                        btn.Click += Btn_Click;
                        btn.Left = 70 * i + 40;
                        btn.Width = 60;
                        btn.Height = 60;
                        btn.BackgroundImage = Properties.Resources.chair2;
                        groupBox1.Controls.Add(btn);
                    }
                    else if (count == 50 || count == 56 || count == 51 || count == 57 || count == 52 || count == 58)
                    {
                        Button btn = new Button();
                        btn.Text = (count++).ToString();
                        btn.Top = 70 * j + 50;
                        btn.Left = 70 * i + 120;
                        btn.Click += Btn_Click;
                        btn.Width = 60;
                        btn.Height = 60;
                        btn.BackgroundImage = Properties.Resources.chair2;
                        groupBox1.Controls.Add(btn);
                    }
                    else
                    {
                        Button btn = new Button();
                        btn.Text = (count++).ToString();
                        btn.Top = 70 * j + 50;
                        btn.Left = 70 * i + 80;
                        btn.Width = 60;
                        btn.Click += Btn_Click;
                        btn.Height = 60;
                        btn.BackgroundImage = Properties.Resources.chair2;
                        groupBox1.Controls.Add(btn);
                    }

                }

            }
        }
        private void Films()
        {
            films.Add(new Film()
            {
                Name = "Film1",
                Seans01 = "4.08.2022 16:00 - 18:00",
                Seans02 = "4.08.2022 19:00 - 20:00",
                Seans03 = "5.08.2022 16:00 - 18:00",
                Price = 50.0m
            });
            films.Add(new Film()
            {
                Name = "Film2",
                Seans01 = "4.08.2022 16:00 - 18:00",
                Seans02 = "7.08.2022 12:00 - 14:00",
                Seans03 = "10.08.2022 16:00 - 18:00",
                Price = 50.0m
            });
            films.Add(new Film()
            {
                Name = "Film3",
                Seans01 = "6.08.2022 12:00 - 15:00",
                Seans02 = "9.08.2022 18:00 - 19:00",
                Seans03 = "4.08.2022 16:00 - 18:00",
                Price = 50.0m
            });

            comboBox1.Items.Add(films[0].Name);
            comboBox1.Items.Add(films[1].Name);
            comboBox1.Items.Add(films[2].Name);

        }
        //Film pickedFilm;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            ComboBox clickedComboBox = sender as ComboBox;
            //pickedFilm = comboBox1.SelectedItem as Film;

            groupBox2.Visible = true;

            foreach (var i in films)
            {
                if (clickedComboBox.Text == i.Name)
                {
                    comboBox3.Items.Add(i.Seans01);
                    comboBox3.Items.Add(i.Seans02);
                    comboBox3.Items.Add(i.Seans03);
                }
            }
            c1 = clickedComboBox;


            
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Films();
            
            ButtonDoldur();
            groupBox1.Visible = false;
            button1.Visible = false;

        }

        //Film pickedSeans;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //seans
        {
            //pickedSeans = comboBox3.SelectedItem as Film;
            ComboBox clickedComboBox = sender as ComboBox;
            c2 = clickedComboBox;
            groupBox1.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //koltuk
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {

            Button tiklanilanButton = sender as Button;
            tiklanilanButton.Enabled = false;
            count++;
            b1 = tiklanilanButton;
            button1.Visible = true;

        }
        private void ListSend()
        {
            decimal totalPrice = count * 50.0m; 
            customer.Add(new Customer() { Koltuk = b1.Text, SecilenFilm = c1.Text, secilenSeans = c2.Text,  tutar = totalPrice });
            count = 0;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


/*
 filmler combobox ya da listboxta filmler olucak.

filme göre salonun şekli gelicek,

mesela 8-9 koltugu aldık, pop up ta 9 no'lu koltuguda alıcak, isim ya da cinsiyet alıncak
ödeme yöntemi kredi ya da nakit

alınan koltuk kırmızı olucak

 */