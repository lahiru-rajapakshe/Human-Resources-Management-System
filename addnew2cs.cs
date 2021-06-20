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
    public partial class addnew2cs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter adpt;
        DataTable dt;
        public addnew2cs()
        {
            InitializeComponent();
            displayData();
            genBox.SelectedIndex = 0;
            depBox.SelectedIndex = 0;
            passP.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (pass1.Text != pass2.Text)
            {
                string message = "Your password is not matching, Please check and try again !";
                string title = "Password";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                   
                }
            }


            if (idTxt.Text == "" || nameTxt.Text == "" || ageTxt.Text == "" || mobTxt.Text == "" || genBox.SelectedIndex == 0 || depBox.SelectedIndex == 0 || pass1.Text == "" || pass2.Text == "")
            {
                // msgLabel.Text = "You cannot skip this option.\nPlease enter your username and password above ! ";
                // msgLabel.Text = "";
                // label7.Text = "";
                string message = "             Please fill the every fields above !             ";
                string title = "Registration failed !";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }


            }


            









            else if (pass1.Text == pass2.Text)
            {
                
              
                try
                {
                    con.Open();
                    cmd = new SqlCommand("insert into AddNewEmployee(Employee_ID,Employee_name,Age,Mobile,Gender,Department)values('" + idTxt.Text + "','" + nameTxt.Text + "','" + ageTxt.Text + "','" + mobTxt.Text + "','" + genBox.SelectedItem + "','" + depBox.SelectedItem + "')", con);
                    cmd2 = new SqlCommand("insert into Log(UserName,Department,Password)values('" + nameTxt.Text + "','" + depBox.SelectedItem + "','" + pass1.Text + "')", con);

                    passP.Visible = false;
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    string message = "             The person successfully registerd to the System !             ";
                    string title = "Registration Success !";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {

                    }
                    con.Close();
                    idTxt.Text = "";
                    nameTxt.Text = "";
                    ageTxt.Text = "";
                    mobTxt.Text = "";
                    genBox.SelectedIndex = 0;
                    depBox.SelectedIndex = 0;
                    pass1.Text = "";
                    pass2.Text = "";
                    // MessageBox.Show("inserted your data ! ");



                    displayData();





                }
                catch (Exception ex)


                {


                }
            }
          
            
             
                
                    
                
                
            


        }
        public void displayData()
        {

            con.Open();
            adpt = new SqlDataAdapter("select * from AddNewEmployee", con);
            dt = new DataTable();
            adpt.Fill(dt);


            dataGridView1.DataSource = dt;
            con.Close();




        }

        private void genBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from AddNewEmployee where Mobile='" + mobTxt.Text + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Mobile Number that you entered is already exist. Please try another one !";
                string title = "Mobile number exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ageTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void mobTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void idTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nameTxt.Focus();
            }
        }

        private void nameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ageTxt.Focus();
            }
        }

        private void ageTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mobTxt.Focus();
            }
        }

        private void mobTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                genBox.Focus();
            }
        }

        private void genBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                depBox.Focus();
            }
        }

        private void addnew2cs_Load(object sender, EventArgs e)
        {
            //focusing o idbox box in form loging
            if (idTxt.CanSelect)
            {
                idTxt.Select();
            }
        }

        private void depBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (depBox.SelectedIndex == 1)
            {
                passP.Visible = true;
            }
            if (depBox.SelectedIndex == 2)
            {
                passP.Visible = true;
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
        //in here i roving ignore button for logging error
        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            //string message = "Do you nedd to continue without password ?             ";
            //string title = "Skip Password";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (result == DialogResult.Yes)
          //  {
           //     string message2 = "If you don't add a password you cannot log to the system by using this User name             ";
           //     string title2 = "Skip Password";
          //      MessageBoxButtons buttons2 = MessageBoxButtons.OK;
          //      DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
          //      if (result2 == DialogResult.OK)
           //     {
           //         passP.Visible = false;
            //    }
          //  }

            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if ((pass1.Text == "" || pass2.Text == "")&& (pass1.Text==pass2.Text))
            {
                string message = "             Please add a password !             ";
                string title = "Password";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }
            }

            if (pass1.Text != pass2.Text)
            {
                string message = "The password that you entered is not matched. Please input a same password for each fields !";
                string title = "Password";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }
            }

           


        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            if ((pass1.Text == pass2.Text)&& (idTxt.Text!="" && nameTxt.Text!="" && ageTxt.Text!="" && mobTxt.Text!="" && genBox.SelectedIndex==1 || genBox.SelectedIndex==2))
            {
                string message = "You password is already matching, Do you need  to change your bio data ?             ";
                string title = "Password Matching";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    passP.Visible = false;
                }
                if (result == DialogResult.No)
                {
                    //passP.Visible = false;
                }
                
            }
            if (idTxt.Text == "" || nameTxt.Text == "" || ageTxt.Text == "" || mobTxt.Text == "" || genBox.SelectedIndex == 0)
            {
                passP.Visible = false;
            }
            if (pass1.Text != pass2.Text)
            {
                passP.Visible = false;
            }
        }

        private void pass2_TextChanged(object sender, EventArgs e)
        {
            if (pass1.Text == pass2.Text)
            {
                bunifuThinButton23.Visible = false;
            }
            if (pass1.Text != pass2.Text)
            {
                bunifuThinButton23.Visible = true;
            }
        }

        private void passP_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pass1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pass1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pass2.Focus();
            }
        }

        private void ageTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from AddNewEmployee where Employee_Name='" + nameTxt.Text + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The User Name that you entered is already exist. Please try another one !";
                string title = "User Name exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from AddNewEmployee where Employee_ID='" + idTxt.Text + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Employee ID that you entered is already exist. Please try another one !";
                string title = "ID exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
           // ageTxt.Enabled = false;
           // mobTxt.Enabled = false;
          //  genBox.Enabled = false;
           // depBox.Enabled = false;
        }
    }
}

