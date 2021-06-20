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
    public partial class addNewEmp : Form
    {
        public addNewEmp()
        {
            InitializeComponent();
            customizeDesign();
            openChildForm(new addnew2cs());
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 250)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 50;
                 panelAnimator.ShowSync(sidemenu);
               // animator1.ShowSync(pictureBox6);
                //  logoAnimator.ShowSync(logo);

            }
            else
            {
                  //animator1.Hide(pictureBox6);
                
                sidemenu.Visible = false;
                sidemenu.Width = 250;
                  panelAnimator.ShowSync(sidemenu);
              
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //openChildForm(new addnew2cs());
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
            addNewMainPanel.Controls.Add(childForm);
            addNewMainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new searchcs());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openChildForm(new myAccount());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            openChildForm(new manageSalaryEX());
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
             showSubMenu(subMenu);
           // openChildForm(new myAccount());
        }
        private void customizeDesign()
        {
            subMenu.Visible = false;
            panelsub.Visible = false;

        }
        private void hideSubMenu()
        {
            if (subMenu.Visible == true)
            {
                subMenu.Visible = false;
            }
            if (panelsub.Visible == true)
            {
                panelsub.Visible = false;
            }
        }
        private void showSubMenu(Panel submenus)
        {
            if (submenus.Visible == false)
            {
                hideSubMenu();
                submenus.Visible = true;

            }
            else
            {
                submenus.Visible = false;
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new MAcs());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openChildForm(new addnew2cs());
        }

        private void addNewMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new applyLeave());
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            showSubMenu(subMenu);
        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelsub);
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new addnewSalaryMini());
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new updateSalaryMini());
        }

        private void sidemenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton28_Click_1(object sender, EventArgs e)
        {
            openChildForm(new searchcs());
        }

        private void bunifuThinButton29_Click_1(object sender, EventArgs e)
        {
            openChildForm(new addnew2cs());
        }
    }
}
