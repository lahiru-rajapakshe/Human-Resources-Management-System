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
    public partial class extraLogincs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q8M2O2V\SQLEXPRESS;Initial Catalog=ProjectCSharp;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public extraLogincs()
        {
            InitializeComponent();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from Login where username='" + unameTxt.Text.Trim() + "'and password='" + pwordTxt.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //  Hide();
                // MainPagecs form = new MainPagecs();
                //  form.ShowDialog();
                //   Close();
                //   msgLabel2.Text = "";
                openChildForm(new mainPage());
               // headerNameShow.Text = "Main Page";
            }
            else
            {
                msgLabel.Text = "Invalid Entrance !\nPlease check your username or password !";

            }
            if (unameTxt.Text == "")
            {
                msgLabel.Text = "Invalid Entrance !\nPlease check your username or password !";
            }
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            signinPanel.Visible = true;
            loginPanel.Visible = false;
          //  headerNameShow.Text = "Sign-In";
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into login (username,password)values('" + signUname.Text + "','" + signPword.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("You are all set ! ");
            loginPanel.Visible = true;
            signinPanel.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            con.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            signinPanel.Visible = false;
          //  headerNameShow.Text = "Login";
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
            extraLogPanel.Controls.Add(childForm);
            extraLogPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
