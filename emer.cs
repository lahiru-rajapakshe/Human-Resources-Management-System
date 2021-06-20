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
    public partial class emer : Form
    {
        public emer(string depart)
        {
            InitializeComponent();
            label1.Text = depart;
        }

        private void emer_Load(object sender, EventArgs e)
        {
            if (((Form)this).Controls["label1"].Text !="HR")
            {
                button2.Visible = false;
               
                mainpagebuttonPanel.Visible = false;
            }
            if (((Form)this).Controls["label1"].Text != "Accounting")
            {
                button2.Visible = false;

                UserMain.Visible = false;
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            openChildForm(new addNewEmp());
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
            //this.Close();

            string message = "             Are you sure ?   Do you want to Logout ?             ";
            string title = "Logout Confirmation !";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
                
            {
               
                this.Close();
            }
            else if (result == DialogResult.No)
            {

            }
            else
            {

            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
             string message = "Are you sure ?   Do you want to Switch to Accounting Department?             ";
            string title = "Swiching to User's Section ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Switching s = new Switching();
                s.Show();
                UserMain.Visible = true;
                
            }
            else if(result == DialogResult.No) {
                 
            }
            else
            {
                
            }
            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
          //  string message = "\n\n             Are you sure ?   Do you want to Logout ?             \n\n";
          //  string title = "Logout confirmation";
         //   MessageBoxButtons buttons = MessageBoxButtons.YesNo;
          //  DialogResult result = MessageBox.Show(message, title, buttons);
         //   if (result == DialogResult.Yes)
         //   {
          //      this.Close();
          //  }
          //  else
          //  {

           // }
            string message = "             Are you sure ?   Do you want to Logout ?             ";
            string title = "Logout Confirmation !";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                logout l = new logout();
                l.Show();
                this.Close();
            }
            else if(result == DialogResult.No) {
                 
            }
            else
            {
                
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            openChildForm(new MAcs());
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            openChildForm(new applyLeave());
        }
    }
}
