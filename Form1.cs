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
    public partial class Please_Wait : Form
    {
        public Please_Wait()
        {
            InitializeComponent();
            label6.Parent = pictureBox1;
            label1.Visible = false;
            
        }

        private void tic(object sender, EventArgs e)
        {
            timer1.Stop();
            Hide();
            Login2 l = new Login2();
            l.ShowDialog();
            Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            label6.Hide();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
          
           
        }
    }
}
