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
    public partial class applyLeave : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public applyLeave()
        {
            InitializeComponent();
            levelBox.SelectedIndex = 0;
            noTxt.Enabled = false;
            nameTxt.Enabled = false;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            //  this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {


            if (idTxt.Text == "" || nameTxt.Text == "" || nameTxt.Text == "" || levelBox.SelectedIndex == 0 || noTxt.Text == "")
            {
                // msgLabel.Text = "You cannot skip this option.\nPlease enter your username and password above ! ";
                // msgLabel.Text = "";
                // label7.Text = "";
                string message = "             Please fill every fields above !             ";
                string title = "Apply a leave, failed !";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {

                }

            }

            else
                try
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Apply_Leave(Employee_ID,Name,Leave_Type,No_Of_Days)values('" + idTxt.Text + "','" + nameTxt.Text + "','" + levelBox.SelectedItem + "','" + noTxt.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    string message = "             Your Leaving Data Inserted Successfully !             ";
                    string title = "Leaving success !";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {

                    }
                    idTxt.Text = "";
                    nameTxt.Text = "";
                    levelBox.SelectedIndex = 0;
                    noTxt.Text = "";
                    //  ageTxt.Text = "";
                    //  mobTxt.Text = "";
                    //  genBox.SelectedIndex = 0;
                    //   depBox.SelectedIndex = 0;
                    // MessageBox.Show("inserted your data ! ");

                    con.Close();

                    displayData();

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
                catch (Exception ex)


                {
                    //  msgLabel.Text = "";
                    //  label7.Text = "Invalid Entrance !\nPlease check your username or password !";

                }

        }
        public void displayData()
        {

            con.Open();
            adpt = new SqlDataAdapter("select * from Apply_Leave ", con);
            dt = new DataTable();
            adpt.Fill(dt);


            dataGridView1.DataSource = dt;
            con.Close();




        }

        private void levelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (levelBox.SelectedIndex == 1)
            {
                noTxt.Text = "30";
            }
            if (levelBox.SelectedIndex == 2)
            {
                noTxt.Text = "25";
            }
            if (levelBox.SelectedIndex == 3)
            {
                noTxt.Text = "5";
            }
            if (levelBox.SelectedIndex == 4)
            {
                noTxt.Text = "7";
            }
            if (levelBox.SelectedIndex == 5)
            {
                noTxt.Text = "4";
            }
            if (levelBox.SelectedIndex == 6)
            {
                noTxt.Text = "30";
            }
            if (levelBox.SelectedIndex == 7)
            {
                noTxt.Text = "3";
            }
            if (levelBox.SelectedIndex == 8)
            {
                noTxt.Text = "1";
            }
            if (levelBox.SelectedIndex == 9)
            {
                noTxt.Text = "10";
            }

            if (levelBox.SelectedIndex == 10)
            {
                noTxt.Text = "4";
            }
        }

        private void nameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void idTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                levelBox.Focus();
            }
        }

        private void applyLeave_Load(object sender, EventArgs e)
        {
            //focusing on idtxt box in form loging
            if (idTxt.CanSelect)
            {
                idTxt.Select();
            }
        }

        private void idTxt_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton2_Click_1(object sender, EventArgs e)
        {
            try
            {





                con.Open();
                string q = "select * from AddNewEmployee where Employee_ID=" + int.Parse(idTxt.Text);
                cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                     nameTxt.Text = (dr["Employee_name"].ToString());
                    //  mediTxt.Text = (dr["medical_allowance"].ToString());
                    // traTxt.Text = (dr["travelling_allowance"].ToString());
                    // otherTxt.Text = (dr["Other"].ToString());
                    // grossTxt.Text = (dr["gross_salary"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
        }
    }
}
