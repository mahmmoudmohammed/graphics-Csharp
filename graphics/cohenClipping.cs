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
    public partial class cohenClipping : Form
    {

        public DataTable DDAtable = new DataTable();
        public Point[] pp = new Point[2];

        private const byte interior = 0; 
        private const byte left = 1;   
        private const byte right = 2;  
        private const byte bootom = 4; 
        private const byte top = 8;    
        Bitmap p;   

        public cohenClipping()
        {
            InitializeComponent();
            p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }


        public byte compute_code(double x, double y, int t, int b, int l, int r)
        {
            byte code = interior;
            if (x < l)
                code |= left;
            else if (x > r)
                code |= right;
            if (y < b)
                code |= bootom;
            else if (y > t)
                code |= top;
            return code;
        }


        public Point[] cohen(Point p0, Point p1, int T, int B, int L, int R)
        {
            Point[] p = new Point[2];
            double x0 = p0.X;
            double y0 = p0.Y;
            double x1 = p1.X;
            double y1 = p1.Y;

            byte outcode0 = compute_code(x0, y0, T, B, L, R);
            byte outcode1 = compute_code(x1, y1, T, B, L, R);
            bool accept = false;

            while (true)
            {
                if ((outcode0 | outcode1) == 0)
                { accept = true; break; }

                else if ((outcode0 & outcode1) != 0)
                { break; }
                else
                {
                    double x, y;
                    byte outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;
                    if ((outcodeOut & top) != 0)
                    {
                        x = x0 + (x1 - x0) * (T - y0) / (y1 - y0);
                        y = T;
                    }
                    else if ((outcodeOut & Bottom) != 0)
                    {
                        x = x0 + (x1 - x0) * (B - y0) / (y1 - y0);
                        y = B;
                    }
                    else if ((outcodeOut & right) != 0)
                    {
                        y = y0 + (y1 - y0) * (R - x0) / (x1 - x0);
                        x = R;
                    }
                    else if ((outcodeOut & left) != 0)
                    {
                        y = y0 + (y1 - y0) * (L - x0) / (x1 - x0);
                        x = L;
                    }
                    else
                    {
                        x = double.NaN;
                        y = double.NaN;
                    }
                    if (outcodeOut == outcode0)
                    {
                        x0 = x; y0 = y;
                        outcode0 = compute_code(x0, y0, T, B, L, R);
                    }
                    else
                    {
                        x1 = x; y1 = y;
                        outcode1 = compute_code(x1, y1, T, B, L, R);
                    }
                }
            }
            if (accept)
            {
                p[0].X = (int)x0;
                p[0].Y = (int)y0;
                p[1].X = (int)x1;
                p[1].Y = (int)y1;
                return p;
            }
            else
                return null;
        }

        public void DDA(int x1, int y1, int x2, int y2)
        {
            //  Bitmap op = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            float dx = x2 - x1;
            float dy = y2 - y1;
            float steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float xinc = dx / (float)steps;
            float yinc = dy / (float)steps;
            float X = x1, Y = y1;
            p.SetPixel(x1, x2, Color.Red);

            for (int i = 0; i < steps; i++)
            {
                X += xinc;
                Y += yinc;
                p.SetPixel((int)Math.Round(X), (int)Math.Round(Y), Color.LightGoldenrodYellow);
            }
            pictureBox1.Image = p;

        }


        void rotate(double angle, int T, int L, int B, int R)
        {
            try
            {
                int x1 = T;
                int y1 = L;
                int x2 = B;
                int y2 = R;
                double a = angle;
                int x3 = Convert.ToInt32(x2 * Math.Cos(a) - y2 * Math.Sin(a));
                int y3 = Convert.ToInt32(x2 * Math.Sin(a) + y2 * Math.Cos(a));
                //int dx = Math.Abs(x3 - x1), dy = Math.Abs(y3 - y1);
                DDA(x1, y1, x3, y3);
                //pictureBox1.Image = p;
            }
            catch (Exception exe)
            { MessageBox.Show(exe.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new home();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //start point
                pp[0].X = int.Parse(textBox1.Text);
                pp[0].Y = int.Parse(textBox2.Text);
                //end point
                pp[1].X = int.Parse(textBox3.Text);
                pp[1].Y = int.Parse(textBox4.Text);
                //Border
                int T = int.Parse(textBox8.Text);
                int B = int.Parse(textBox6.Text);
                int L = int.Parse(textBox7.Text);
                int R = int.Parse(textBox5.Text);
                //Angle
                double a = double.Parse(Angle.Text) * Math.PI / 180;
                //draw border
                DDA(L, B, L, T);
                DDA(L, T, R, T);
                DDA(R, B, R, T);
                DDA(R, B, L, B);
                //draw line
                DDA(pp[0].X, pp[0].Y, pp[1].X, pp[1].Y);
                if (radioButton1.Checked)
                {
                    rotate(a, pp[0].X, pp[0].Y, pp[1].X, pp[1].Y);
                }
                pictureBox1.Image = p;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //border
            int T = int.Parse(textBox8.Text);
            int B = int.Parse(textBox6.Text);
            int L = int.Parse(textBox5.Text);
            int R = int.Parse(textBox7.Text);
            //clipping
            pp = cohen(pp[0], pp[1], T, B, L, R);
            DDA(pp[0].X, pp[0].Y, pp[1].X, pp[1].Y);
            //draw border
            DDA(L, B, L, T);
            DDA(L, T, R, T);
            DDA(R, B, R, T);
            DDA(R, B, L, B);
            pictureBox1.Image = p;

        }
    }
}
