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
    public partial class updateSalary2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public updateSalary2()
        {
            InitializeComponent();
            disabled();
            cmbdis();
            idBox.SelectedIndex = 0;
            errorMsg();
           // numberZero();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (idBox.Enabled == false)
            {
                string message2 = "          Please Enable every fields first !          ";
                string title2 = "Fields locked";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.OK)
                {

                }
            }




            if ((basicTxt.Text == "0" || mediTxt.Text == "0" || traTxt.Text == "0" || otherTxt.Text == "0" || idBox.SelectedIndex == 0) && idBox.Enabled == true)
            {
                // msgLabel.Text = "You cannot skip this option.\nPlease enter your username and password above ! ";
                // msgLabel.Text = "";
                // label7.Text = "";
                string message2 = "          Please fill every fields above !          ";
                string title2 = "Update failed ";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.OK)
                {

                }



            }


            else
                try
                {
                    if (basicTxt.Text != "0")
                    {


                        string message2 = "Are you sure ?   Do you need to continue with updating ?             ";
                        string title2 = "Confirm Updating";
                        MessageBoxButtons buttons2 = MessageBoxButtons.YesNoCancel;
                        DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result2 == DialogResult.Yes)
                        {

                            con.Open();
                            cmd = new SqlCommand("update Add_New_Salary set Basic_Salary='" + basicTxt.Text + "',Medical_Allowance='" + mediTxt.Text + "',Travelling_Allowance='" + traTxt.Text + "',Other='" + otherTxt.Text + "',Gross_Salary='" + grossTxt.Text + "' where employee_ID='" + idBox.SelectedItem + "'", con);
                            cmd.ExecuteNonQuery();

                            string message = "             Updated Your Salary Data Successfully !             ";
                            string title = "Update success !";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {

                            }
                            //   idTxt.Text = "";
                            // nameTxt.Text = "";
                            // ageTxt.Text = "";
                            //mobTxt.Text = "";
                            //genBox.SelectedIndex = 0;
                            // depBox.SelectedIndex = 0;
                            // MessageBox.Show("inserted your data ! ");
                            idBox.SelectedIndex = 0;
                            basicTxt.Text = "0";
                            mediTxt.Text = "0";
                            traTxt.Text = "0";
                            otherTxt.Text = "0";
                            grossTxt.Text = "0";
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

                        else
                        {

                        }


                    }
                }

                catch (Exception ex)


                {
                    //  msgLabel.Text = "";
                    //  label7.Text = "Invalid Entrance !\nPlease check your username or password !";
                    // MessageBox.Show("erre 25");
                }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            basicTxt.Text = "0";
            mediTxt.Text = "0";
            traTxt.Text = "0";
            otherTxt.Text = "0";
            grossTxt.Text = "0";
            idBox.SelectedIndex = 0;
        }
        private void disabled()
        {
            basicTxt.Enabled = false;
            mediTxt.Enabled = false;
            traTxt.Enabled = false;
            otherTxt.Enabled = false;
            grossTxt.Enabled = false;
            idBox.Enabled = false;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            enabled();
            label7.Text = "";
            linkLabel1.Text = "";
            label9.Text = "";
            linkLabel2.Text = "";
        }
        private void enabled()
        {
            basicTxt.Enabled = true;
            mediTxt.Enabled = true;
            traTxt.Enabled = true;
            otherTxt.Enabled = true;
            grossTxt.Enabled = true;
            idBox.Enabled = true;
        }
        public void cmbdis()
        {
            con.Open();
            string q = "select employee_id from AddNewEmployee";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idBox.Items.Add(dr["employee_id"].ToString());
                idBox.DisplayMember = (dr["employee_id"].ToString());
            }
            con.Close();

        }
        public void setApplyData()
        {
           
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {

            if (idBox.SelectedIndex == 0)
            {
                string message2 = "Please select the Employee Id and then search salary  details that already added  !";
                string title2 = "Please Select !";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.OK)
                {

                }

            }
            else
                try
                {





                    con.Open();
                    string q = "select * from Add_New_Salary where Employee_ID=" + int.Parse(idBox.Text);
                    cmd = new SqlCommand(q, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        basicTxt.Text = (dr["basic_salary"].ToString());
                        mediTxt.Text = (dr["medical_allowance"].ToString());
                        traTxt.Text = (dr["travelling_allowance"].ToString());
                        otherTxt.Text = (dr["Other"].ToString());
                        grossTxt.Text = (dr["gross_salary"].ToString());
                    }

                    if (basicTxt.Text == "0"|| mediTxt.Text=="0"||traTxt.Text=="0"||otherTxt.Text=="0")
                    {
                        string message2 = "This person has no any salary information. Please add the salary information first, and then you can Update them";
                        string title2 = "Not found";
                        MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                        DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (result2 == DialogResult.OK)
                        {

                        }
                        disabled();
                        // bunifuThinButton22.Enabled = false;
                        linkLabel2.Text = "Click Here";
                        label9.Text = "Go to the Aplly Salery section";
                    }


                    con.Close();


                }catch(Exception ex)
                {
                    
                }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new addNewSalarycs());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
           updateMainpanel.Controls.Add(childForm);
          updateMainpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void errorMsg()
        {
            label7.Text = "Before you update the salary data,first you must add them\n";
            linkLabel2.Text = "";
            label9.Text="";
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

        private void otherTxt_KeyPress(object sender, KeyPressEventArgs e)
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
                otherTxt.Focus();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new addNewSalarycs());
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
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
            other = Convert.ToInt32(otherTxt.Text);
            // gross = Convert.ToInt32(grossTxt.Text);

            gross = basic + medi + tra + other;

            // grossTxt.Text = gross;
            grossTxt.Text = Convert.ToString(gross);

            if (basicTxt.Text == "0" || mediTxt.Text == "0" || traTxt.Text == "0" || otherTxt.Text == "0")
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
        }
        public void numberZero()
        {
            basicTxt.Text = "";
            mediTxt.Text = "";
            traTxt.Text = "";
            otherTxt.Text = "";
            grossTxt.Text = "";
        }
    }
}
