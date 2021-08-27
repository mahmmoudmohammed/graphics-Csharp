//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace graphics
//{
//    public partial class drawElips : Form
//    {
//        public drawElips()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
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
    public partial class drawElips : Form
    {
        public drawElips()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int xc, yc, Rx, Ry;

            xc = int.Parse(textBox1.Text);
            yc = int.Parse(textBox2.Text);
            Rx = int.Parse(textBox3.Text);
            Ry = int.Parse(textBox4.Text);

            Bitmap g = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;

            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            float p;
            int x = 0, y = Ry, dx = twoRy2 * x, dy = twoRx2 * y;
            string Pstr = "", octant1 = "", octant2 = "", octant3 = "", octant4 = "";
            //region one
            p = (int)Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));    //  (b^2) - ( a^2 * b ) + ( a^2 * (1/4) )
            while (dx < dy)
            {
                x++;
                dx = twoRy2 * x;

                if (p < 0)
                    p += Ry2 + dx;

                else
                {
                    y--;
                    dy = twoRx2 * y;
                    p += Ry2 + dx - dy;
                }

                g.SetPixel(xc + x, yc + y, Color.Yellow);
                g.SetPixel(xc - x, yc + y, Color.White);
                g.SetPixel(xc - x, yc - y, Color.Yellow);
                g.SetPixel(xc + x, yc - y, Color.White);

                Pstr += "Region one " + p + "\t";
                octant1 += " Quarter one: ( " + (xc + x) + "," + (yc + y) + " )";
                octant2 += " Quarter two: ( " + (xc - x) + "," + (yc + y) + " )";
                octant3 += " Quarter three: ( " + (xc - x) + "," + (yc - y) + " )";
                octant4 += " Quarter four: ( " + (xc + x) + "," + (yc - y) + " )";


            }
            Pstr += "-------------------------";

            //region two
            p = (int)Math.Round((y - 1) * Rx2 * (y - 1) + Ry2 * (x + .5) * (x + .5) - Rx2 * Ry2);
            while (y > 0)
            {
                y--;
                dy = twoRx2 * y;
                if (p > 0)
                {
                    p += Rx2 - dy;
                }
                else
                {
                    x++;
                    dx = twoRy2 * x;
                    p += Rx2 - dy + dx;
                }

                g.SetPixel(xc + x, yc + y, Color.Yellow);
                g.SetPixel(xc - x, yc + y, Color.White);
                g.SetPixel(xc - x, yc - y, Color.Yellow);
                g.SetPixel(xc + x, yc - y, Color.White);

                Pstr += "Region two " + p + "\t";
                octant1 += " Quarter one: ( " + (xc + x) + "," + (yc + y) + " )";
                octant2 += " Quarter two: ( " + (xc - x) + "," + (yc + y) + " )";
                octant3 += " Quarter three: ( " + (xc - x) + "," + (yc - y) + " )";
                octant4 += " Quarter four: ( " + (xc + x) + "," + (yc - y) + " )";


            }
            pictureBox1.Image = g;

            textBox5.Text = Pstr;
            textBox6.Text = octant1 + "\n";
            textBox7.Text = octant2 + "\n";
            textBox8.Text = octant3 + "\n";
            textBox9.Text = octant4 + "\n";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form c = new home();
            c.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Form c = new home();
            c.Show();
        }
    }
}

