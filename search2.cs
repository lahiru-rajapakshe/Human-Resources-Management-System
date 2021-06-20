using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace C_Sharp_Mini_Project
{
    public partial class search2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public search2()
        {
            InitializeComponent();
            depSrch.SelectedIndex = 0;
            gridText();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            logout2 l = new logout2();
            l.Show();
            displayData();
        }
        public void displayData()
        {



            if (depSrch.SelectedIndex == 1)
            {

                con.Open();
                adpt = new SqlDataAdapter("select * from AddNewEmployee where Department like 'HR%'", con);
                dt = new DataTable();
                adpt.Fill(dt);

                label3.Text = "";
                dataGridView1.DataSource = dt;

                con.Close();

            }
            if (depSrch.SelectedIndex == 2)
            {

                con.Open();
                adpt = new SqlDataAdapter("select * from AddNewEmployee where Department like 'Acc%'", con);
                dt = new DataTable();
                adpt.Fill(dt);

                label3.Text = "";
                dataGridView1.DataSource = dt;
                con.Close();

            }
            if (depSrch.SelectedIndex == 0)
            {
                string message = "Please Select Department name that you need to search !";
                string title = "Search";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }
            }

        }
        public void gridText()
        {
            if (depSrch.SelectedIndex == 0)
            {
                label3.Text = "Please select the Department name above, that you need to search !";
            }
           
        }
    }
}
