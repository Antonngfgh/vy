using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многоугольники
{
   
    abstract class Vertex
    {
        
        protected static int r;
        protected static Brush clr;
        protected int x, y;
        public Vertex()
        {
            x = 0;
            y = 0;
        }
        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        static Vertex()
        {
            r = 50;
            clr = new SolidBrush(Color.Black);
        }
        abstract public int X
        {
            get;
            set;
            
        }
        abstract public int Y
        {
            get;
            set;  
        }
        static int R
        {
            get
            {
                return r;
            }
        }
        static Brush CLR
        {
            get
            {
                return clr;
            }
        }
        abstract public void Draw(Graphics g);
        abstract public bool Check(int xm, int ym);
        
    }
    class Circle : Vertex
    {
        public Circle() : base() { }
        public Circle(int x, int y) : base(x, y) { }
            
        public override int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }


        public override void Draw(Graphics g)
        {
           
            g.FillEllipse(clr, x-r/2, y-r/2, r, r);
        }
        public override bool Check(int xm, int ym)
        {
            double xx = Math.Pow(X - xm, 2);
            double yy = Math.Pow(Y - ym, 2);
            if (xx + yy <= Math.Pow(r / 2, 2)) return true;
            else return false;
        }
    }
    class Square : Vertex
    {
        public Square() : base() { }
        public Square(int x, int y) : base(x, y) { }

        public override int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public override void Draw(Graphics g)
        {
           
            g.FillRectangle(clr, x-r/2, y-r/2, r, r);
        }
        public override bool Check(int xm, int ym)
        {
            
            if (xm >= x-r/2 && xm <= x+r/2 && ym >=y-r/2 && ym <= y+r/2) return true;
            else return false;
        }
    }
    class Triangle : Vertex
    {
        public Triangle() : base() { }
        public Triangle(int x, int y) : base(x, y) { }

        public override int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public override void Draw(Graphics g)
        {
            Point[] point = new Point[3];
            point[0] = new Point(x,y-r/2);
            point[1] = new Point(x-r/2, y+r/2);
            point[2] = new Point(x + r / 2, y + r/2);
            g.FillPolygon(clr, point);
        }
        public override bool Check(int xm, int ym)
        {
            double x1 = x;
            double x2 = x + r * Math.Sqrt(3) / 2;
            double x3 = x - r * Math.Sqrt(3) / 2;
            double y1 = y - r;
            double y2 = y + r / 2;
            double y3 = y + r / 2;
            double a = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            double b = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double c = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            double l = Math.Sqrt(Math.Pow((x3 - xm), 2) + Math.Pow((y3 - ym), 2));
            double m = Math.Sqrt(Math.Pow((x1 - xm), 2) + Math.Pow((y1 - ym), 2));
            double n = Math.Sqrt(Math.Pow((x2 - xm), 2) + Math.Pow((y2 - ym), 2));
            double S_all = Geron(a, b, c);
            double S1 = Geron(a, m, l);
            double S2 = Geron(c, l, n);
            double S3 = Geron(b, m, n);
            if (Math.Abs(S_all - (S1 + S2 + S3)) < 1e-6)
            {
                return true;
            }
            return false;
        }
        private double Geron(double a, double b, double c)
        {
            double P = (a + b + c) / 2;
            return Math.Sqrt(P * (P - a) * (P - b) * (P - c));
        }
    }
}

