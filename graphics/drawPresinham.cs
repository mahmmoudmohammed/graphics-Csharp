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
    public partial class drawPresinham : Form
    {
        public drawPresinham()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);

            float m = (y2 - y1) / (float)(x2 - x1);

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            if (Math.Abs(m) < 1)
            {
                int P = 2 * dy - dx;
                int towXY = 2 * (dy - dx);

                int xstart, ystart, xend;
                if (x1 < x2)
                {
                    xstart = x1;
                    ystart = y1;
                    xend = x2;
                }
                else
                {
                    xstart = x2;
                    ystart = y2;
                    xend = x1;
                }

                while (xstart < xend)
                {
                    xstart++;
                    if (P < 0)
                    {
                        P = P + 2 * dy;
                        p.SetPixel(xstart, ystart, Color.Black);
                    }
                    else
                    {
                        P = P + towXY;
                        ystart++;
                        p.SetPixel(xstart, ystart, Color.Black);
                    }

                    textBox5.Text += xstart + "," + ystart + "\n";

                }
                pictureBox1.Image = p;
            }
            else
            {
                int P = 2 * dx - dy;
                int towXY = 2 * (dx - dy);

                int xstart, ystart, yend;
                if (y1 < y2)
                {
                    xstart = x1;
                    ystart = y1;
                    yend = y2;
                }
                else
                {
                    xstart = x2;
                    ystart = y2;
                    yend = y1;
                }
                string s = "";
                while (ystart < yend)
                {
                    ystart++;
                    if (P < 0)
                    {
                        P = P + 2 * dx;
                        p.SetPixel(xstart, ystart, Color.Black);
                    }
                    else
                    {
                        P = P + towXY;
                        xstart++;
                        p.SetPixel(xstart, ystart, Color.Black);
                    }

                    s += xstart + "," + ystart + "\n";

                }
                pictureBox1.Image = p;
                textBox5.Text = s;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
