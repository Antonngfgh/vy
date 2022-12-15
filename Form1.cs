using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        bool f;
        bool f1;
        bool f2;
        bool f3;
        int dx, dy;

        Vertex vertex;


        public Form1()
        {

            f = false;
            f1 = false;
            f2 = false;
            f3 = false;

            dx = dy = 0;
            InitializeComponent();
            circleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            f = true;
            Refresh();


        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
            squareToolStripMenuItem.Checked = false;
            f = true;
            Refresh();

        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = true;
            f = true;
            Refresh();

        }

        

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                vertex = null;
            }
            else
            {
                
                if (circleToolStripMenuItem.Checked == true)
                {

                    if (vertex != null && vertex.Check(e.X, e.Y) == true)
                    {
                        dx = e.X - vertex.X;
                        dy = e.Y - vertex.Y;
                        f1 = true;

                    }
                    else vertex = new Circle(e.X, e.Y);
                }


                if (triangleToolStripMenuItem.Checked == true)
                {


                    if (vertex != null && vertex.Check(e.X, e.Y) == true)
                    {
                        dx = e.X - vertex.X;
                        dy = e.Y - vertex.Y;
                        f2 = true;
                    }
                    else vertex = new Triangle(e.X, e.Y);
                }
                if (squareToolStripMenuItem.Checked == true)
                {


                    if (vertex != null && vertex.Check(e.X, e.Y) == true)
                    {
                        dx = e.X - vertex.X;
                        dy = e.Y - vertex.Y;
                        f3 = true;
                    }
                    else vertex = new Square(e.X, e.Y);
                }
                Refresh();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (f1 && vertex != null)
            {

                vertex.X = e.X - dx;
                vertex.Y = e.Y - dy;

            }
            if (f3 && vertex != null)
            {
                vertex.X = e.X - dx;
                vertex.Y = e.Y - dy;

            }
            if (f2 && vertex != null)
            {
                vertex.X = e.X - dx;
                vertex.Y = e.Y - dy;

            }
            this.Refresh();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (f1)
            {
                f1 = false;
                Refresh();
            }
            if (f2)
            {
                f2 = false;
                Refresh();
            }
            if (f3)
            {
                f3 = false;
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            if (vertex != null && f == true)
                vertex.Draw(e.Graphics);
            if (vertex != null && f == true)
                vertex.Draw(e.Graphics);
            if (vertex != null && f == true)
                vertex.Draw(e.Graphics);


        }
    }
}