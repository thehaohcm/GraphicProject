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

        private void putcolor(int x, int y, Color m)
        {
            if (x < 0 || x > 400 || y < 0 || y > 400) return;
            //arrcolor[round(y) / 5, round(x) / 5] = m;
        }

        private void putpixel(int x, int y, Color m)
        {
            if (x < 0 || x > 400 || y < 0 || y > 400) return;

            Graphics grfx = frm.panel1.CreateGraphics();
            Pen p = new Pen(m);
            SolidBrush b = new SolidBrush(m);
            grfx.DrawEllipse(p, x, y, 2, 2);
            grfx.FillEllipse(b, x, y, 2, 2);
            grfx.DrawEllipse(p, x - 2, y - 2, 2, 2);
            grfx.FillEllipse(b, x - 2, y - 2, 2, 2);
            grfx.DrawEllipse(p, x, y - 2, 2, 2);
            grfx.FillEllipse(b, x, y - 2, 2, 2);
            grfx.DrawEllipse(p, x - 2, y, 2, 2);
            grfx.FillEllipse(b, x - 2, y, 2, 2);

            putcolor(x, y, m);
        }

        public int round(double tds)
        {
            int tdm;
            double sodu = tds % 5;
            if (sodu != 0)
            {
                if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > 400) tdm = 400;
            return tdm;
        }

        public Point roundPoint(double X, double Y)
        {
            return new Point(round(X),round(Y));
        }

        public void DDA_Line(Line line) // Ve duong thang co dinh dang mau
        {
            //Line line = (Line)s;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = line.getEndPoint().X - line.getStartPoint().Y;
            Dy = line.getEndPoint().Y - line.getStartPoint().Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = line.getStartPoint().X;
                y = line.getStartPoint().Y;
                do
                {
                    temp_1 = round(x);
                    temp_2 = round(y);
                    putpixel(temp_1, temp_2, shape.getColor());
                    // temp_3 = temp_1;
                    // temp_4 = temp_2;
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
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

        public void drawCoordinates()
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
                    //g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                    DDA_Line(line);
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
                            //g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                            
                            DDA_Line(line);
                        }
                        break;
                }
            }
        }

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
