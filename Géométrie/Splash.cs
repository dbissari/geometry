using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Géométrie
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == 3000)
            {
                button1.Visible = true;
                timer1.Enabled = false;
            }
            if (timer1.Interval == 9000)
            {
                pictureBox1.Visible = false;
                label1.Visible = true;
                timer1.Interval = 3000;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Splash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!timer1.Enabled)
               Close();
        }
    }
}
