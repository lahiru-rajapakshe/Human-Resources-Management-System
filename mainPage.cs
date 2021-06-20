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
    public partial class mainPage : Form
    {
        public mainPage()
        {
            InitializeComponent();
           
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            // openChildForm(new Login2());
            // openChildForm(new Fdis());
            // mainpagebuttonPanel.Visible = false;
           // this.Close();
           
            

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
            mpPanel.Controls.Add(childForm);
            mpPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            openChildForm(new addNewEmp());
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            openChildForm(new search2());
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            openChildForm(new manageSalary2());
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void mainpagebuttonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mpPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
