using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adoNetWorks02
{
    public partial class Categories : Form
    {
        SqlConnection conn = new SqlConnection("Server=.;Database=Northwind;Integrated Security = true;");
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            getCategoriesList();
        }
        private void getCategoriesList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Categories", conn); 
            DataTable dataTable = new DataTable(); 
            adapter.Fill(dataTable); 
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["CategoryID"].Visible = false; 
            //dataGridView1.Columns["Picture"].Visible = false;
   
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;
            string catDesc = DescriptionTextBox.Text;
 
            if (categoryName == "" || catDesc == "")
            {
                MessageBox.Show("Doldurulmayan alan var");
                Application.Restart();
            }
            SqlCommand command = new SqlCommand();
            command.CommandText = string.Format("INSERT Categories (CategoryName, Description) Values('{0}','{1}')", categoryName
                , catDesc); 
            command.Connection = conn;

            conn.Open();
            int etkilenenSatırSayısı = command.ExecuteNonQuery(); //hem exex eder hemde etkilenen satır sayısını return eder ExecuteNonQuery
            if (etkilenenSatırSayısı > 0)
            {
                MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                getCategoriesList();
            }
            else
            {
                MessageBox.Show("Kayıt ekleme başarısız olmuştur.");
            }
            conn.Close();
        }
    }
}
