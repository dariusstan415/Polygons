using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygons
{
    public partial class Form1 : Form
    {
        int n;
        PoligonR poligon;
        Pen p;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            p = new Pen(Color.Black, 3);
            n = 3;
            label1.Size = new Size(50, 50);
            label1.Text = " Polygons";
            label1.AutoSize = true;
            label1.Font = new Font("Algerian", 45, FontStyle.Italic);
            
            label2.Font = new Font("Monotype", 10, FontStyle.Regular);
            label2.Text = "Ïntroduceți numărul de laturi:";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string z = textBox1.Text;
            string v = "1234567890";
            if (v.Contains(z[0]) && v.Contains(z[z.Length - 1]) && z[0] != '0' && z.Length <= 2 && z.Length > 0)
            {
                int n = Convert.ToInt32(z);
                if (n > 2)
                {
                    textBox1.BackColor = Color.LightGreen;

                    PointF centru = new PointF(this.Width / 2, this.Height / 2);
                    PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
                    poligon = new PoligonR(n, centru, p1);
                    MessageBox.Show("Acum puteți crea poligonul");
                }
                else
                    MessageBox.Show("Un poligon are cel putin trei laturi");
            }
            else
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("asigurati-va ca ati inrodus un numar natural de cel mult doua cifre");
                textBox1.BackColor = Color.White;
                textBox1.Text = "";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                poligon.Create2(g, p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
                poligon.Create1(g, p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
                poligon.Create4(g, p);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                poligon.Create5(g, p);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                poligon.Create3(g, p);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OnBackColorChanged(e);
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           

            PointF centru = new PointF(this.Width / 2, this.Height / 2);
            PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
            Hexagon hexagon = new Hexagon(centru, p1);

            p = new Pen(Color.Red, 3);
            hexagon.Create2(g, p);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

            PointF centru = new PointF(this.Width / 2, this.Height / 2);
            PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
            Patrat patrat = new Patrat(centru,p1);

            p = new Pen(Color.Red, 3);
            patrat.Create2(g, p);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            

            PointF centru = new PointF(this.Width / 2, this.Height / 2);
            PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
            Pentagon pentagon = new Pentagon(centru, p1);

            p = new Pen(Color.Red, 3);
            pentagon.Create2(g, p);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            

            PointF centru = new PointF(this.Width / 2, this.Height / 2);
            PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
            Heptagon heptagon = new Heptagon(centru, p1);

            p = new Pen(Color.Red, 3);
            heptagon.Create2(g, p);
        }

        private void button10_Click(object sender, EventArgs e)
        {
           

            PointF centru = new PointF(this.Width / 2, this.Height / 2);
            PointF p1 = new PointF(this.Width / 2, this.Height / 2 - 300);
            Octogon octogon = new Octogon(centru, p1);

            p = new Pen(Color.Red, 3);
            octogon.Create1(g, p);
        }
    }
}
