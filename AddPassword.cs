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
    public partial class AddPassword : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public AddPassword()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (pass1.Text == pass2.Text)
            {
                try
                {
                    con.Open();
                   // cmd = new SqlCommand("insert into AddNewEmployee(Employee_ID,Employee_name,Age,Mobile,Gender,Department)values('" + idTxt.Text + "','" + nameTxt.Text + "','" + ageTxt.Text + "','" + mobTxt.Text + "','" + genBox.SelectedItem + "','" + depBox.SelectedItem + "')", con);
                    cmd = new SqlCommand("insert into Log(password)values('" + pass1.Text + "')", con);

                    cmd.ExecuteNonQuery();

                    string message = "             The person successfully registerd to the System !             ";
                    string title = "Registration Success !";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {

                    }
                    con.Close();
                  //  idTxt.Text = "";
                   // nameTxt.Text = "";
                  //  ageTxt.Text = "";
                 //   mobTxt.Text = "";
                   // genBox.SelectedIndex = 0;
                  //  depBox.SelectedIndex = 0;
                    // MessageBox.Show("inserted your data ! ");



                  //  displayData();





                }
                catch (Exception ex)


                {


                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
