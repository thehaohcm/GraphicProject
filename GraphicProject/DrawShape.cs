using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicProject
{
    class DrawShape
    {

        private List<Shape> shapeSet;
        private Shape shape;
        private Form1 frm;

        public DrawShape(Form1 frm)
        {
            shapeSet = new List<Shape>();
            this.frm = frm;
        }

        public void initShape(TypeDraw type)
        {
            switch (type)
            {
                case TypeDraw.Line:
                    shape = new Line();
                    break;
                case TypeDraw.Circle:
                    shape = new Circle();
                    break;
                case TypeDraw.Ellipse:
                    shape = new Ellipse();
                    break;
                case TypeDraw.Parallelogram:
                    shape = new Parallelogram();
                    break;
                case TypeDraw.Rectangle:
                    shape = new Rectangle();
                    break;
                case TypeDraw.Square:
                    shape = new Square();
                    break;
                case TypeDraw.Triangle:
                    shape = new Triangle();
                    break;
            }
            shape.setColor(frm.colorDialog1.Color);
        }

        public void resetShape()
        {
            initShape(shape.getTypeDraw());
        }

        public static int round(float num)
        {
            //handle
            return 1;
        }

        public static void drawDDA()
        {

        }

        public static void draw(Shape shape)
        {
            switch (shape.getTypeDraw())
            {
                case TypeDraw.Line:

                    break;
                case TypeDraw.Circle:

                    break;
                case TypeDraw.Ellipse:

                    break;
                case TypeDraw.Rectangle:

                    break;
                case TypeDraw.Square:

                    break;
                case TypeDraw.Triangle:

                    break;
                case TypeDraw.Parallelogram:

                    break;
            }
        }

        public static void drawLine(Form1 frm)
        {

        }

        public static void drawCoordinates(Form1 frm)
        {
            Graphics g = frm.panel1.CreateGraphics();
            // SolidBrush brush = new SolidBrush(Color.DarkSlateBlue);
            for (int i = 0; i <= 80; i++)
            {
                g.DrawLine(new Pen(Color.Black), 5 * i, 0, 5 * i, 400);
                g.DrawLine(new Pen(Color.Black), 0, 5 * i, 400, 5 * i);
            }
            g.DrawLine(new Pen(Color.Red), 0, 200, 400, 200);
            g.DrawLine(new Pen(Color.Red), 200, 0, 200, 400);

        }

        public void paint(Object sender, PaintEventArgs e)
        {
            foreach (Shape s in shapeSet)
            {
                Pen pen = new Pen(s.getColor(), 3);
                Graphics g = frm.panel1.CreateGraphics();
                if (s.getTypeDraw() == TypeDraw.Line)
                {
                    Line line = (Line)s;
                    g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                }
                g.Dispose();
            }

            if (shape.checkDrawable()) //if (endClick)
            {
                switch (shape.getTypeDraw())
                {
                    case TypeDraw.Line:
                        Line line = (Line)shape;
                        if (line.getEndPoint() != null)
                        {
                            Pen pen = new Pen(shape.getColor(), 3);
                            Graphics g = frm.panel1.CreateGraphics();
                            g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                        }
                        break;
                }

            }
        }

        //public void paintPanel(Shape shape)//,List<Shape> shapeSet)
        //{
        //    //DrawShape.shapeSet = shapeSet;
        //    frm.panel1.Paint += new PaintEventHandler(paint);
        //    frm.panel1.Refresh();
        //}

        public void addShape(Shape shape)
        {
            this.shapeSet.Add(shape);
        }
        public List<Shape> getShapeSet()
        {
            return shapeSet;
        }

        public Shape getShape()
        {
            return shape;
        }

        public void addShapeToShapeSet()
        {
            shapeSet.Add(shape);
        }
    }
}
