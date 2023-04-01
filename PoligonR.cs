using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Polygons
{
    class PoligonR
    {
        protected int _n; //numarul de laturi
        protected float _r; //raza cercului circumscris in poligon
        protected PointF[] _points; //varfurile poligonului 
        protected PointF _c; //centrul poligonului

        public PointF C
        {
            get { return _c; }
        }
        public float R
        {
            get { return _r; }
        }
        public int N
        {
            get { return _n; }
        }
        public PointF[] Points
        {
            get { return _points; }
        }


        //constructor vid
        public PoligonR()
        {
            _n = 0;
            _r = 0;
            _c = new PointF(0, 0);
        }
        /*constructor cu patru parametrii
         * n - numarul de laturi
         * c - centrul cercului circumscris poligonului
         * p1 - un varf al poligonului
         */

        public PoligonR(int n, PointF c, PointF p1)
        {
            _n = n;
            _r = (float)Math.Sqrt((p1.X - c.X) * (p1.X - c.X) + (p1.Y - c.Y) * (p1.Y - c.Y));
            _points = new PointF[_n];
            _points[0] = p1;
            _c = c;
            int i = 1;
            while (i <= n / 2)
            {
                double alpha = i * (2 * Math.PI / n);
                double Z1 = _r * _r - c.X * c.X - c.Y * c.Y;
                double Z2 = 2 * _r * _r * (1 - Math.Cos(alpha)) - p1.X * p1.X - p1.Y * p1.Y;
                PointF p2a, p2b;
                if (c.Y != p1.Y)
                {
                    double T = (Z2 - Z1) / (2.0 * (c.Y - p1.Y));
                    double coef = (1.0 * (c.X - p1.X)) / (1.0 * (c.Y - p1.Y));
                    double A = 1 + coef * coef;
                    double B = 2 * (c.Y * coef - c.X - T * coef);
                    double C = T * T - 2 * T * c.Y - Z1;
                    double delta = B * B - 4 * A * C;
                    double ex1 = (-1 * B + Math.Sqrt(delta)) / (2.0 * A);
                    double ex2 = (-1 * B - Math.Sqrt(delta)) / (2.0 * A);
                    double ey1 = T - coef * ex1;
                    double ey2 = T - coef * ex2;
                    p2a = new PointF((float)(ex1), (float)(ey1));
                    p2b = new PointF((float)(ex2), (float)(ey2));
                }
                else
                {
                    double T = (Z2 - Z1) / (2.0 * (c.X - p1.X));
                    double coef = (1.0 * (c.Y - p1.Y)) / (1.0 * (c.X - p1.X));
                    double A = 1 + coef * coef;
                    double B = 2 * (c.X * coef - c.Y - T * coef);
                    double C = T * T - 2 * c.X * T - Z1;
                    double delta = B * B - 4 * A * C;
                    double ey1 = (-1 * B + Math.Sqrt(delta)) / (2.0 * A);
                    double ey2 = (-1 * B - Math.Sqrt(delta)) / (2.0 * A);
                    double ex1 = T - coef * ey1;
                    double ex2 = T - coef * ey2;
                    p2a = new PointF((float)(ex1), (float)(ey1));
                    p2b = new PointF((float)(ex2), (float)(ey2));
                }
                _points[i] = p2a;
                _points[n - i] = p2b;
                i++;
            }
        }


        protected float y(PointF p1, PointF p2, float x)//returnează y-ul corespunzator pentru x, pentru a se situa pe dreapta P1P2
        {

            float m = (float)((p2.Y - p1.Y) * 1.0 / (p2.X - p1.X) * 1.0);
            return (float)((x - p1.X) * m) + p1.Y;
        }

        public void Create1(Graphics g, Pen p)//desenează poligonul
        {
            for (int i = 0; i < _n - 1; i++)
                g.DrawLine(p, _points[i], _points[i + 1]);
            g.DrawLine(p, _points[0], _points[_n - 1]);
        }
        public void Create2(Graphics g, Pen p)//unește treptat, în mișcare, vârfurile
        {
            PointF p1;
            for (int i = 0; i < _n - 1; i++)
            {
                p1 = _points[i];
                if (p1.X == _points[i + 1].X)
                {
                    while ((p1.Y - _points[i + 1].Y >= 0.5 || p1.Y - _points[i + 1].Y <= -0.5))
                    {
                        if (p1.Y < _points[i + 1].Y)
                            p1.Y++;
                        else
                            p1.Y--;
                        g.DrawLine(p, _points[i], p1);
                    }
                }
                while ((p1.X - _points[i + 1].X >= 0.5 || p1.X - _points[i + 1].X <= -0.5))
                {
                    if (p1.X < _points[i + 1].X)
                        p1.X++;
                    else
                        p1.X--;
                    g.DrawLine(p, _points[i].X, _points[i].Y, p1.X, y(_points[i], _points[i + 1], p1.X));

                    System.Threading.Thread.Sleep(10);
                }

            }
            p1 = _points[_n - 1];
            while ((p1.X - _points[0].X >= 0.5 || p1.X - _points[0].X <= -0.5))
            {
                if (p1.X < _points[0].X)
                    p1.X++;
                else
                    p1.X--;
                g.DrawLine(p, _points[_n - 1].X, _points[_n - 1].Y, p1.X, y(_points[0], _points[_n - 1], p1.X));
                System.Threading.Thread.Sleep(10);
            }

        }
        public void Create3(Graphics g, Pen p)//cerc circumscris
        {
            int i = 1;
            while (i <= 360)
            {
                g.DrawArc(p, _points[0].X - _r, _points[0].Y, 2 * _r, 2 * _r, 270, i);
                i++;
                System.Threading.Thread.Sleep(20);
            }
        }
        public void Create4(Graphics g, Pen p)// distante varf-centru
        {
            p.Width = 1;
            for (int i = 0; i < _n; i++)
                g.DrawLine(p, _points[i], _c);
            p.Width = 3;
        }
        public void Create5(Graphics g, Pen p) // diagonale
        {
            p.Width = 1;
            for (int i = 0; i < _n - 1; i++)
                for (int j = i + 1; j <= _n - 1; j++)
                    g.DrawLine(p, _points[i], _points[j]);
            g.DrawLine(p, _points[0], _points[_n - 1]);
            p.Width = 3;
        }

    }
}
