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
    public partial class drawDda : Form
    {
        public drawDda()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap op = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);
            float dx = x2 - x1;
            float dy = y2 - y1;
            float steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xinc = dx / (float)steps;
            float yinc = dy / (float)steps;
            float X = x1, Y = y1;
            op.SetPixel(x1, x2, Color.Red);

            for (int i = 0; i < steps; i++)
            {
                X += xinc;
                Y += yinc;
                op.SetPixel((int)Math.Round(X), (int)Math.Round(Y), Color.Red);
                textBox5.Text += " (" + Math.Round(X) + "-" + Math.Round(Y) + ") ";

            }
            /* 

           for (int i = 1; i < (int)pictureBox1.Width; i++)
           {
               op.SetPixel(1, i, Color.Red);
           }
           for (int i = 1; i < 22; i++)
           {
               op.SetPixel(i, 1, Color.Red);
           }
             *   */
            pictureBox1.Image = op;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new home();
            c.Show();
        }
    }
}
