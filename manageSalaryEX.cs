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
    public partial class manageSalaryEX : Form
    {
        public manageSalaryEX()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
           // openChildForm(new updateSalaryMini());
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //openChildForm(new addnewSalaryMini());
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            openChildForm(new addnewSalaryMini());
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            openChildForm(new updateSalaryMini());
        }
    }
}
