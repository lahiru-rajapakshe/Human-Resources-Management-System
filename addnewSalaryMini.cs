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
    public partial class addnewSalaryMini : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public addnewSalaryMini()
        {
            InitializeComponent();
            //comboBox1.SelectedIndex = 0;
            idBox.SelectedIndex = 0;
            cmbdis();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int basic;
            int medi;
            int tra;
            int other;
            int gross;
            //  basic = Convert.ToInt32(ToString(basicTxt.Text));
            basic = Convert.ToInt32(basicTxt.Text);
            medi = Convert.ToInt32(mediTxt.Text);
            tra = Convert.ToInt32(traTxt.Text);
            other = Convert.ToInt32(OtherTxt.Text);
          // gross = Convert.ToInt32(grossTxt.Text);

            gross = basic + medi + tra + other;

            // grossTxt.Text = gross;
            grossTxt.Text = Convert.ToString(gross);




        }
        

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            basicTxt.Text = "";
            mediTxt.Text = "";
            traTxt.Text = "";
            OtherTxt.Text = "";
            grossTxt.Text = "";
            idBox.SelectedIndex = 0;
        }
        //------------adding data to combobox----------//
        public void cmbdis()
        {
            con.Open();
            string q = "select employee_id from AddNewEmployee";
            SqlCommand cmd = new SqlCommand(q,con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idBox.Items.Add(dr["employee_id"].ToString());
                idBox.DisplayMember=(dr["employee_id"].ToString());
            }
            con.Close();
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (basicTxt.Text == "" || mediTxt.Text == "" || traTxt.Text == "" || OtherTxt.Text == "")
            {
                // msgLabel.Text = "You cannot skip this option.\nPlease enter your username and password above ! ";
                // msgLabel.Text = "";
                // label7.Text = "";
                string message = "             Please fill every fields above !             ";
                string title = "Invalid Entrance";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }

            else
                try
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Add_New_Salary(Employee_ID,Basic_Salary,Medical_Allowance,Travelling_Allowance,Other,Gross_Salary)values('" + idBox.SelectedItem + "','" + basicTxt.Text + "','" + mediTxt.Text + "','" + traTxt.Text + "','" + OtherTxt.Text + "','" + grossTxt.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    string message = "             Added Your Salary Successfully !             ";
                    string title = "Salary Added !";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {
                        
                    }
                    // idTxt.Text = "";
                    //  nameTxt.Text = "";
                    //   ageTxt.Text = "";
                    //   mobTxt.Text = "";
                    //  genBox.SelectedIndex = 0;
                    //  depBox.SelectedIndex = 0;
                    // MessageBox.Show("inserted your data ! ");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    //  displayData();

                    if (dt.Rows.Count > 0)
                    {
                        //  Hide();
                        // MainPagecs form = new MainPagecs();
                        //  form.ShowDialog();
                        //   Close();
                        //   msgLabel2.Text = "";
                        //    openChildForm(new mainPage());
                        // headerNameShow.Text = "Main Page";
                    }
                    else
                    {
                        //   msgLabel.Text = "";
                        //  label7.Text = "Invalid Entrance !\nPlease check your username or password !";
                        // MessageBox.Show("erre 2");
                    }
                }
                catch (Exception ex)


                {
                    //  msgLabel.Text = "";
                    //  label7.Text = "Invalid Entrance !\nPlease check your username or password !";

                    
                }
        }

        private void basicTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mediTxt.Focus();
            }
        }

        private void mediTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                traTxt.Focus();
            }
        }

        private void traTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OtherTxt.Focus();
            }
        }

        private void basicTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void mediTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void traTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void OtherTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void grossTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void basicTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from Add_New_Salary where Employee_ID='" + idBox.SelectedItem + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Employee ID that you entered is already added salary information. Please try another ID number !";
                string title = "Salary informations exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }

        private void mediTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from Add_New_Salary where Employee_ID='" + idBox.SelectedItem + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Employee ID that you entered is already added salary information. Please try another ID number !";
                string title = "Salary informations exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }

        private void traTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from Add_New_Salary where Employee_ID='" + idBox.SelectedItem + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Employee ID that you entered is already added salary information. Please try another ID number !";
                string title = "Salary informations exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }

        private void OtherTxt_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select count(*) from Add_New_Salary where Employee_ID='" + idBox.SelectedItem + "'", con);
            object obj = cmdcheck.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                string message = "The Employee ID that you entered is already added salary information. Please try another ID number !";
                string title = "Salary informations exsist";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }
            con.Close();
        }
    }
}
