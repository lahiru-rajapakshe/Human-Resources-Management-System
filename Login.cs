using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_Mini_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           // signupPanel.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
         //   signupPanel.Visible = true;
            LoginPanel2.Visible = false;
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            LoginPanel2.Visible = true;
          //  signupPanel.Visible = false;
        }

        private void signupPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
