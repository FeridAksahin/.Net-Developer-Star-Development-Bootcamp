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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(lblAnaToplam.Text) > 0 && _formdanGelenMusteriBilgisi != null && lstSepetim.Items.Count != 0)
            {
                MessageBox.Show($"Sevgili {_formdanGelenMusteriBilgisi.MusteriAdi}, Toplam {lstSepetim.Items.Count} çeşit pizza siparişin bulunmakta. Bize {lblAnaToplam.Text} TL dökül bakalım :)");
            }
            else
            {
                MessageBox.Show("Geçersiz veriler.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.delegem = new Form5.MyDelege(VeriyiAl);
            f.Show();
        }

        void VeriyiAl(Musteri formdanGelenMusteriBilgisi)
        {
            _formdanGelenMusteriBilgisi = formdanGelenMusteriBilgisi;
        }

        Musteri _formdanGelenMusteriBilgisi;

        //----
        private void Form4_Load(object sender, EventArgs e)
        {
            PizzaDoldur();
            MalzemeleriDoldur();
            txtAraToplam.Enabled = false;
        }

        private void MalzemeleriDoldur()
        {
            lstMalzemeler.Items.Add("Mısır");
            lstMalzemeler.Items.Add("Zeytin");
            lstMalzemeler.Items.Add("Siyah Zeytin");
        }

        private void PizzaDoldur()
        {
            cmbPizzalar.Items.Add(new Pizza()
            {
                Adi = "Süper Pizza",
                Fiyat = 50m
            });
            cmbPizzalar.Items.Add(new Pizza()
            {
                Adi = "Ege Pizza",
                Fiyat = 150m
            });
        }
        Pizza secilenPizza;
        private void cmbPizzalar_SelectedIndexChanged(object sender, EventArgs e)
        {

            secilenPizza = cmbPizzalar.SelectedItem as Pizza;
            txtAraToplam.Text = secilenPizza.Fiyat.ToString();
            rdpBuyuk.Checked = false;//
            rdpKucuk.Checked = false;//
            rdpOrta.Checked = false;//

        }


        private void btnAt_Click(object sender, EventArgs e)
        {
            if (lstMalzemeler.SelectedItems.Count == 0) //malzeme listesinden birşey seçilmediyse '>' basıldıysa
            {
                MessageBox.Show("Malzeme seçmelisin.");
            }
            else if (cmbPizzalar.SelectedItem == null) //pizza comboboxından birşey seçilmeden '>' basıldıysa
            {
                MessageBox.Show("Pizza Seçmelisin");
            }
            else if (rdpBuyuk.Checked == false && rdpOrta.Checked == false && rdpKucuk.Checked == false) //radio button seçilmediyse
            {
                MessageBox.Show("Pizza boyutu seçmelisin Seçmelisin");
            }
            else
            {
                lstSecilenMalzemeler.Items.Add(lstMalzemeler.SelectedItem);
                txtAraToplam.Text = (decimal.Parse(txtAraToplam.Text) + 1).ToString();
            }

        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            //todo
            if (lstSecilenMalzemeler.SelectedItems.Count == 1)
            {
                lstSecilenMalzemeler.Items.Remove(lstSecilenMalzemeler.SelectedItem);//
                txtAraToplam.Text = (decimal.Parse(txtAraToplam.Text) - 1).ToString();//
            }


        }



        private void rdpKucuk_CheckedChanged_1(object sender, EventArgs e)
        {
            //todo yanlış senaryoda ne olur.
            if (cmbPizzalar.SelectedItem != null)//
            {
                if (rdpOrta.Checked)
                {
                    lstSecilenMalzemeler.Items.Clear();
                    numericUpDown1.Value = 1;
                    txtAraToplam.Text = (secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.2m)).ToString();
                    
                }
                else if (rdpBuyuk.Checked)
                {
                    lstSecilenMalzemeler.Items.Clear();
                    numericUpDown1.Value = 1;
                    txtAraToplam.Text = (secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.5m)).ToString();
                    
                }
                else
                {
                    lstSecilenMalzemeler.Items.Clear();
                    numericUpDown1.Value = 1;
                    txtAraToplam.Text = (secilenPizza.Fiyat).ToString();//
                    
                }
            }
            else
            {
                MessageBox.Show("Önce pizza seçmelisin.");//
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
            if (cmbPizzalar.SelectedItem != null)//
            {
                decimal secilenAdetMiktari = numericUpDown1.Value;
                decimal total = 0;
                if (lstSecilenMalzemeler.Items.Count == 0 && rdpKucuk.Checked)
                {
                    total = secilenPizza.Fiyat + lstSecilenMalzemeler.Items.Count;
                }
                else if (lstSecilenMalzemeler.Items.Count == 0 && rdpKucuk.Checked)
                {
                    total = secilenPizza.Fiyat;
                }
                else if (lstSecilenMalzemeler.Items.Count == 0 && rdpBuyuk.Checked)
                {
                    total = secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.5m);
                }
                else if (lstSecilenMalzemeler.Items.Count == 0 && rdpOrta.Checked)
                {
                    total = secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.2m);
                }
                else if (lstSecilenMalzemeler.Items.Count != 0 && rdpOrta.Checked)
                {
                    total = secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.2m) + lstSecilenMalzemeler.Items.Count;
                }
                else if (lstSecilenMalzemeler.Items.Count != 0 && rdpBuyuk.Checked)
                {
                    total = secilenPizza.Fiyat + (secilenPizza.Fiyat * 0.5m) + lstSecilenMalzemeler.Items.Count;
                }
                else if (lstSecilenMalzemeler.Items.Count != 0 && rdpKucuk.Checked)
                {
                    total = secilenPizza.Fiyat + lstSecilenMalzemeler.Items.Count;
                }



                txtAraToplam.Text = (decimal.Parse(txtAraToplam.Text) + total).ToString();
            }
            else
            {
                MessageBox.Show("Pizza seçiniz");
                numericUpDown1.Value = 1;
            }

            //150 2 300 3 900 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(cmbPizzalar.SelectedItem == null || rdpBuyuk.Checked == false && rdpKucuk.Checked == false && rdpOrta.Checked == false)
            {
                MessageBox.Show("Veriler eksik.");
            }
            else
            {
                lstSepetim.Items.Add(new Sepetim()
                {
                    Adet = numericUpDown1.Value,
                    Pizza = secilenPizza,
                    AraTutar = decimal.Parse(txtAraToplam.Text)
                });

                lblAnaToplam.Text = AnaToplamTutariBul();
                lstSecilenMalzemeler.Items.Clear();//
                numericUpDown1.Value = 1;
          
                rdpBuyuk.Checked = false;
                rdpKucuk.Checked = false;
                rdpOrta.Checked = false;
            }
           
        }

        private string AnaToplamTutariBul()
        {
            // todo
            //label6.Text = txtAraToplam.Text.ToString()+Convert.ToDecimal(label6.Text);
            lblAnaToplam.Text = (Convert.ToDecimal(lblAnaToplam.Text) + Convert.ToDecimal(txtAraToplam.Text)).ToString();
            txtAraToplam.Text = "0";
            return lblAnaToplam.Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstSepetim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAraToplam_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstSecilenMalzemeler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
