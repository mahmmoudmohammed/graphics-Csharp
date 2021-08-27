using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new drawPresinham();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new drawDda();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new drawCircle();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new drawElips();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new cohenClipping();
            c.Show();
        }
    }
}
