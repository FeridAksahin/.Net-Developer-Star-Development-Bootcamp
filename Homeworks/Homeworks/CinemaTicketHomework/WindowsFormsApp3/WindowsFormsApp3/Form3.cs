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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<ZReport> report = new List<ZReport>();
        public Form3(List<ZReport> _report) : this()
        {
            report = _report;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach(ZReport report in report)
            {
                listBox1.Items.Add(new ZReport()
                {
                    Cinsiyet = report.Cinsiyet,
                    OdemeTuru = report.OdemeTuru,
                    SecilenFilm = report.SecilenFilm,
                    secilenSeans = report.secilenSeans,
                    tutar = report.tutar
                });
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }
    }
}
