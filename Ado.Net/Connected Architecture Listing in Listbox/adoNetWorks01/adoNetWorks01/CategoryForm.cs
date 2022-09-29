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

namespace adoNetWorks01
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Northwind;Integrated Security = true;"); //parantez açınca 3 kullanım şeklini gösteriyo 2 yi kullandık
            SqlCommand sqlCommand = new SqlCommand("Select * from Categories",conn); //ctrl+sol tık ile gittik overloadlarına baktık
                /*
                 public SqlCommand(string cmdText, SqlConnection connection) şöyle bir overloadı var demekki komuttextinide verip kullanabilriiz böyle kullanalım
                 */
            conn.Open();
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                string catName = rdr["CategoryName"].ToString();
                string Description = rdr["Description"].ToString();

                listBox1.Items.Add(string.Format("{0}-{1}", catName, Description));

            }
            conn.Close();
        }
    }
}
