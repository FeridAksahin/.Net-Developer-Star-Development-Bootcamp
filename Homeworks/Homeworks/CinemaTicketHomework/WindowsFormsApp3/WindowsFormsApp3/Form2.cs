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
    public partial class Form2 : Form
    {
        ComboBox pickedGender;
        RadioButton cashOrCard;

        public Form2()
        {
            InitializeComponent();
        }
        List<Customer> customer = new List<Customer>();
        List<ZReport> report = new List<ZReport>();
        List<Film> films = new List<Film>();

        public Form2(List<Customer> _customer, List<Film> films) : this()
        {
            customer = _customer;
            this.films = films;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = customer[customer.Count - 1].SecilenFilm;
            seans.Text = customer[customer.Count - 1].secilenSeans;
            tutar.Text = (customer[customer.Count - 1].tutar).ToString();
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Male");
            // creditCard.Text = "        -        -        -        ";
            radioButton1.Checked = true;
        }

        private void seans_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox pickedComboBox = sender as ComboBox;
            pickedGender = pickedComboBox;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton2.Checked)
            {
                cashOrCard = radioButton;
                creditCard.Visible = true;
            }
            else
            {
                cashOrCard = radioButton;
                creditCard.Visible = false;
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {//validations

          

            if (comboBox1.SelectedItem != null)
            {
                if (radioButton2.Checked)
                {
                    try
                    {
                        Convert.ToInt64(creditCard.Text);
                        if (creditCard.Text.Length == 16)
                        {
                            this.Close();
                            addList();

                        }
                        else
                        {
                            MessageBox.Show("Kredi kartı numarası 16 haneli olmalıdır.");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Kredi kart numarasında harf ya da boş olmamalı.");
                    }

                }
                else
                {
                    this.Close();
                    addList();
                }
            }


            else
            {
                MessageBox.Show("Cinsiyeti seçmelisiniz.");
            }
            if (textBox1.Text == "adminadmin123")
            {
                Form3 f = new Form3(report);
                f.Show();
                /*
                this.Hide();
             
                f.ShowDialog();
                f = null;
                this.Show();
     */
                /*
                listBox1.Visible = true;
                listBox1.Items.Add(new ZReport()
                {
                    Cinsiyet = report[report.Count - 1].Cinsiyet,
                    OdemeTuru = report[report.Count - 1].OdemeTuru,
                    SecilenFilm = report[report.Count - 1].SecilenFilm,
                    secilenSeans = report[report.Count - 1].secilenSeans,
                    tutar = report[report.Count - 1].tutar
                });*/

            }
        
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void creditCard_TextChanged(object sender, EventArgs e)
        {

        }
        private void addList()
        {
            
            report.Add(new ZReport()
            {
                Cinsiyet = pickedGender.Text,
                OdemeTuru = cashOrCard.Text,
                SecilenFilm = customer[customer.Count - 1].SecilenFilm,
                secilenSeans = customer[customer.Count - 1].secilenSeans,
                tutar = (customer[customer.Count - 1].tutar),
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxVisibleButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
