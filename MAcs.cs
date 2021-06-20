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
    public partial class MAcs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public MAcs()
        {
            InitializeComponent();
            disabled();
          //  label5.Parent = pictureBox1;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            enabled();

        }
        private void disabled()
        {
            nameTxt.Enabled = false;
            ageTxt.Enabled = false;
            mobTxt.Enabled = false;
            genBox.Enabled = false;
            depBox.Enabled = false;
        }
        private void enabled()
        {
            nameTxt.Enabled = true;
            ageTxt.Enabled = true;
            mobTxt.Enabled = true;
            genBox.Enabled = true;
            depBox.Enabled = true;
            genBox.SelectedIndex = 0;
            depBox.SelectedIndex = 0;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {


            if (idTxt.Text == "" || nameTxt.Text == "" || ageTxt.Text == "" || mobTxt.Text == "" || genBox.SelectedIndex == 0 || depBox.SelectedIndex == 0)
            {
                // msgLabel.Text = "You cannot skip this option.\nPlease enter your username and password above ! ";
                // msgLabel.Text = "";
                // label7.Text = "";
                string message = "             Please fill every fields above !             ";
                string title = "Update failed !";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }


            }

            else

                try
                {
                    string message2 = "Are you sure ?   Do you need to continue with updating ?             ";
                    string title2 = "Confirm Updating";
                    MessageBoxButtons buttons2 = MessageBoxButtons.YesNoCancel;
                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result2 == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("update AddNewEmployee set Employee_ID='" + idTxt.Text + "',Employee_name='" + nameTxt.Text + "',Age='" + ageTxt.Text + "',Mobile='" + mobTxt.Text + "',Gender='" + genBox.SelectedItem + "',Department='" + depBox.Text + "' where employee_ID='" + idTxt.Text + "'", con);
                        cmd.ExecuteNonQuery();

                        string message = "             Your Data Updated Successfully !             ";
                        string title = "Updaate Success !";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {

                        }
                        idTxt.Text = "";
                        nameTxt.Text = "";
                        ageTxt.Text = "";
                        mobTxt.Text = "";
                        genBox.SelectedIndex = 0;
                        depBox.SelectedIndex = 0;
                        // MessageBox.Show("inserted your data ! ");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        con.Close();

                        // displayData();

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

                        }
                    }
                }
                catch (Exception ex)


                {
                    //  msgLabel.Text = "";
                    //  label7.Text = "Invalid Entrance !\nPlease check your username or password !";

                }
            disabled();
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            if (idTxt.Text=="")
            {
                string message2 = "Please Input Your ID here, then Try again !";
               string title2 = "Search";
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
                    string q = "select * from AddNewEmployee where Employee_ID=" + int.Parse(idTxt.Text);
                    cmd = new SqlCommand(q, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                      //  idTxt.Text = (dr["Employee_name"].ToString());
                        nameTxt.Text = (dr["Employee_name"].ToString());
                        ageTxt.Text = (dr["Age"].ToString());
                        mobTxt.Text = (dr["Mobile"].ToString());
                        genBox.Text = (dr["Gender"].ToString());
                        depBox.Text = (dr["Department"].ToString());
                    }


                    con.Close();


                }
                catch (Exception ex)
                {

                }
        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ageTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            //blocking char input
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
                mobTxt.Focus();
            }
        }

        private void genBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                depBox.Focus();
            }
        }

        private void MAcs_Load(object sender, EventArgs e)
        {
            //focusing o username box in form loging
            if (idTxt.CanSelect)
            {
                idTxt.Select();
            }
        }
    }
}
