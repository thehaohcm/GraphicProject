using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

public delegate void drawCoordinates();
namespace GraphicProject
{
    public partial class Form1 : Form
    {
        //bool drawable = false;
        //TypeDraw typeDraw;
        //Line[] line;
        //int currentLine = 0;

        List<Shape> shapeSet;
        Shape shape;
        bool endClick = false;
        
        public Form1()
        {
            InitializeComponent();
            shapeSet = new List<Shape>();
        }

        public void drawCoordinates()
        {
            Graphics g = this.panel1.CreateGraphics();
            // SolidBrush brush = new SolidBrush(Color.DarkSlateBlue);
            for (int i = 0; i <= 80; i++)
            {
                g.DrawLine(new Pen(Color.Black), 5 * i, 0, 5 * i, 400);
                g.DrawLine(new Pen(Color.Black), 0, 5 * i, 400, 5 * i);
            }
            g.DrawLine(new Pen(Color.Red), 0, 200, 400, 200);
            g.DrawLine(new Pen(Color.Red), 200, 0, 200, 400);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panel1.CreateGraphics();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using (Graphics g = panel1.CreateGraphics())
            //{
            //    g.DrawLine(new Pen(Color.Black, 3), new Point(234, 118), new Point(293, 228));
            //}
            shape = new Line();
            endClick = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            drawCoordinates();
        }

        private void paint(Object sender,PaintEventArgs e)
        {
            foreach(Shape s in shapeSet)
            {
                Pen pen = new Pen(s.getColor(), 3);
                Graphics g = this.panel1.CreateGraphics();
                if (s.getTypeDraw()==TypeDraw.Line)
                {
                    Line line = (Line)s;
                    g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                }
                g.Dispose();
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!endClick)
            {
                switch (shape.getTypeDraw())
                {
                    case TypeDraw.Line:
                        Line line = (Line)shape;
                        line.setStartPoint(new Point(Convert.ToInt16(e.X), Convert.ToInt16(e.Y)));
                        endClick = true;
                        break;
                    case TypeDraw.Circle:

                        break;
                }
            }
            else
            {
                switch (shape.getTypeDraw())
                {
                    case TypeDraw.Line:
                        Line line = (Line)shape;
                        line.setEndPoint(new Point(Convert.ToInt16(e.X), Convert.ToInt16(e.Y)));
                        break;
                }
                shapeSet.Add(shape);
                panel1.Paint += new PaintEventHandler(paint);
                panel1.Refresh();
                endClick = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
