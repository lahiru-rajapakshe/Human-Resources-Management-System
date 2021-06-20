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
    public partial class myAccount : Form
    {
        public myAccount()
        {
            InitializeComponent();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            openChildForm(new MAcs());
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
            myaccPanel.Controls.Add(childForm);
            myaccPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            openChildForm(new applyLeave());
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
           // this.Close();
        }
    }
}
