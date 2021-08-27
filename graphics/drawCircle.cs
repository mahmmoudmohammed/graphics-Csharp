
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
    public partial class drawCircle : Form
    {
        Bitmap op;
        public drawCircle()
        {
            InitializeComponent();
            op = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = op;
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            int X = int.Parse(textBox1.Text);
            int Y = int.Parse(textBox2.Text);
            int R = int.Parse(textBox3.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            DrawCircle(X, Y, R);
            pictureBox1.Image = op;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form c = new home();
            c.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
            int X = int.Parse(textBox1.Text);
            int Y = int.Parse(textBox2.Text);
            floodFill( X , Y , ColorTranslator.ToHtml(Color.Brown), ColorTranslator.ToHtml(Color.Orange));
            pictureBox1.Image = op;
            textBox1.Clear();
            textBox2.Clear();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            int X = int.Parse(textBox1.Text);
            int Y = int.Parse(textBox2.Text);
            boundaryFill(X, Y, ColorTranslator.ToHtml(Color.White), ColorTranslator.ToHtml(Color.Brown));
            pictureBox1.Image = op;
            textBox1.Clear();
            textBox2.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void boundaryFill(int x, int y, String boundCol, String fillCol)
        {
            int color = op.GetPixel(x, y).ToArgb();
            int colorfill = ColorTranslator.FromHtml(fillCol).ToArgb();
            int colorbound = ColorTranslator.FromHtml(boundCol).ToArgb();
            if (color != colorbound && color != colorfill)
            {
                op.SetPixel(x, y, ColorTranslator.FromHtml(fillCol));
                boundaryFill(x + 1, y, boundCol, fillCol);
                boundaryFill(x - 1, y, boundCol, fillCol);
                boundaryFill(x, y + 1, boundCol, fillCol);
                boundaryFill(x, y - 1, boundCol, fillCol);
            }
        }
        void floodFill(int x, int y, String oriCol, String fillCol)
         {
             int color = op.GetPixel(x, y).ToArgb();
            int colorOld = ColorTranslator.FromHtml(oriCol).ToArgb();
            if (color == colorOld)
            {
                op.SetPixel(x, y, ColorTranslator.FromHtml(fillCol));
                // right semi-circle
                floodFill(x, y + 1, oriCol, fillCol);
                floodFill(x, y - 1, oriCol, fillCol);
                // left semi-circle
                floodFill(x + 1, y, oriCol, fillCol);
                floodFill(x - 1, y, oriCol, fillCol);
            }
         }
        void DrawCircle(int xc, int yc,int r)
        {
            string octant1 = "", octant2 = "", octant3 = "", octant4 = "", octant5 = "", octant6 = "",
            octant7 = "", octant8 = "", Pstr = "";
            int pk = 1 - r, x = r, y = 0;
            while (x >= y)
            {
                op.SetPixel(Math.Abs(xc + x), Math.Abs(yc + y), Color.White);
                op.SetPixel(Math.Abs(xc - x), Math.Abs(yc + y), Color.White);
                op.SetPixel(Math.Abs(xc + x), Math.Abs(yc - y), Color.White);
                op.SetPixel(Math.Abs(xc - x), Math.Abs(yc - y), Color.White);
                op.SetPixel(Math.Abs(xc + y), Math.Abs(yc + x), Color.White);
                op.SetPixel(Math.Abs(xc - y), Math.Abs(yc + x), Color.White);
                op.SetPixel(Math.Abs(xc + y), Math.Abs(yc - x), Color.White);
                op.SetPixel(Math.Abs(xc - y), Math.Abs(yc - x), Color.White);

                if (pk <= 0)
                {
                    pk = pk + 2 * (y + 1) + 1;
                }
                else
                {
                    pk = pk + 2 * (y + 1) - 2 * (x - 1) + 1;
                    x--;
                }
                y++;


                Pstr += pk + "\t";
                octant1 += " Quarter one: ( " + (xc + x) + "," + (yc + y) + " )";
                octant2 += " Quarter two: ( " + (xc - x) + "," + (yc + y) + " )";
                octant3 += " Quarter three: ( " + (xc + x) + "," + (yc - y) + " )";
                octant4 += " Quarter four: ( " + (xc - x) + "," + (yc - y) + " )";
                octant5 += " Quarter one: ( " + (xc + y) + "," + (yc + x) + " )";
                octant6 += " Quarter two: ( " + (xc - y) + "," + (yc + x) + " )";
                octant7 += " Quarter three: ( " + (xc + y) + "," + (yc - x) + " )";
                octant8 += " Quarter four: ( " + (xc - y) + "," + (yc - x) + " )";
            }
           // pictureBox1.Image = op;
            textBox5.Text = octant1 + "\n" + octant5;
            textBox6.Text = octant2 + "\n" + octant6;
            textBox7.Text = octant3 + "\n" + octant7;
            textBox8.Text = octant4 + "\n" + octant8;
            textBox4.Text = Pstr;

        }

    }
}
