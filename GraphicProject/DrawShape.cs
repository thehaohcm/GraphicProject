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

        private void put8pixel(int x, int y, int centerX, int centerY, Color color)
        {
            putpixel(centerX + x, centerY + y, color);
            putpixel(centerX + x, centerY - y,color);
            putpixel(centerX - x, centerY + y, color);
            putpixel(centerX - x, centerY - y, color);
            putpixel(centerX + y, centerY + x, color);
            putpixel(centerX + y, centerY - x, color);
            putpixel(centerX - y, centerY + x, color);
            putpixel(centerX - y, centerY - x, color);
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
        public void MidPoint_Circle(Circle circle)
        {
            int x, y, centerX, centerY, p, R;
            R = 0;
            //get color of the circle
            Color color = circle.getColor();
            //get the point at radius
            x = circle.getEndPoint().X;
            y = circle.getEndPoint().Y;
            centerX = circle.getCenterPoint().X;
            centerY = circle.getCenterPoint().Y;
            if(x == centerX || y!=centerY)
            {
                R = Math.Abs(y - centerY);
            }else if(y==centerY)
            {
                R = Math.Abs(x - centerX);
            }
            int max = round((float)(Math.Sqrt(2) / 2 * R));
            p =1 - R;
            put8pixel(x, y, centerX, centerY, color);
            while (x < max)
            {
                if (p < 0)
                    p = p + 2 * x + 3;
                else
                {
                    p = p + 2 * (x - y) + 5;
                    y = y - 1;
                }
                x = x + 1;
                put8pixel(x, y, centerX, centerY, color);
            }



        }

        public void MidPoint_Ellipse(Ellipse ellipse)
        {
            int x1, y1, x2, y2, centerX, centerY;




        }
        public void DDA_Line(Line line) // Ve duong thang co dinh dang mau
        {
            //Line line = (Line)s;
            int Dx, Dy, count, temp_1, temp_2, dem = 1,absX,absY;
            //int temp_3, temp_4;
            Dx = line.getEndPoint().X - line.getStartPoint().Y;
            Dy = line.getEndPoint().Y - line.getStartPoint().Y;
            absX = Math.Abs(Dx);
            absY = Math.Abs(Dy);
            if (absY > absX) count = absY;
            else count = absX;
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
                    putpixel(temp_1, temp_2, line.getColor());
                    // temp_3 = temp_1;
                    // temp_4 = temp_2;
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }

        private void DDA_Line1(Line line)
        {
            int dY, step, absX, absY;
            float x,y, x_inc, y_inc;
            int dX = line.getEndPoint().X - line.getStartPoint().Y;
            dY = line.getEndPoint().Y - line.getStartPoint().Y;
            absX = Math.Abs(dX);
            absY = Math.Abs(dY);
            if (absX > absY)
                step = absX;
            else
                step = absY;
            x_inc = dX / step;
            y_inc = dY / step;
            x = line.getStartPoint().X;
            y = line.getStartPoint().Y;
            putpixel(round(line.getStartPoint().X), round(line.getStartPoint().Y), line.getColor());
            step--;
            int k = 1;
            while (step!=-1)
            {
                x += x_inc;
                y += y_inc;
                putpixel(round(x), round(y), line.getColor());
                k++;
                step--;
            }

        }

        public void DDA_Line2(Line line)
        {
            int xInitial = line.getStartPoint().X, yInitial = line.getStartPoint().Y, xFinal = line.getEndPoint().X, yFinal = line.getEndPoint().Y;

            int dx = xFinal - xInitial, dy = yFinal - yInitial, steps, k, xf, yf;

            float xIncrement, yIncrement, x = xInitial, y = yInitial;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);

            else steps = Math.Abs(dy);
            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;
            //PixelFunc func = new PixelFunc(SetPixel);
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                xf = (int)x;
                y += yIncrement;
                yf = (int)y;
                //try
                //{
                    //pictureBox1.Invoke(func, xf, yf, Color.Blue);
                    putpixel(round(x), round(y), line.getColor());
                //}
                //catch (InvalidOperationException)
                //{
                //    return;
                //}
            }
        }

        public void drawLinebyMidPoint(Line line)
        {
            int x1 = round(line.getStartPoint().X);
            int y1 = round(line.getStartPoint().Y);
            int x2 = round(line.getEndPoint().X);
            int y2 = round(line.getEndPoint().Y);
            int Dx = 5;//round(x2 - x1);
            int Dy = 5;//round(y2 - y1);
            int x = x1;
            int y = y1;
            putpixel(x1, y1, line.getColor());
            float D = Dy - (Dx >> 1); // ~ float D = Dy - Dx/2;
            while (x <= x2)
            {
                x++;
                if (D < 0)
                {
                    D = D + Dy;
                }
                else
                {
                    D = D + (Dy - Dx);
                    y++;
                }
                putpixel(x, y, line.getColor());
            }
        }

        public void draw(Shape shape)
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
                switch (s.getTypeDraw())
                {
                    case TypeDraw.Line:
                        Line line = (Line)s;
                        //g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                        //DDA_Line2(line);
                        drawLinebyMidPoint(line);
                        break;
                    case TypeDraw.Rectangle:
                        Rectangle retangle = (Rectangle)s;
                        List<Line> listLines = retangle.getAllLines();
                        if (listLines != null)
                            foreach (Line _line in listLines)
                            {
                                DDA_Line2(_line);
                            }
                        break;
                    case TypeDraw.Triangle:
                        Triangle triangle = (Triangle)s;
                        listLines = triangle.getAllLines();
                        if (listLines != null)
                            foreach (Line _line in listLines)
                                DDA_Line2(_line);
                        break;
                    case TypeDraw.Parallelogram:
                        Parallelogram parallelogram = (Parallelogram)s;
                        listLines = parallelogram.getAllLines();
                        if (listLines != null)
                            foreach (Line _line in listLines)
                                DDA_Line2(_line);
                        break;
                    case TypeDraw.Circle:
                        Circle circle = (Circle)s;
                        MidPoint_Circle(circle);
                        break;
                }
                g.Dispose();
            }

            //if (shape.checkDrawable()) //if (endClick)
            //{
            //    switch (shape.getTypeDraw())
            //    {
            //        case TypeDraw.Line:
            //            Line line = (Line)shape;
            //            if (line.getEndPoint() != null)
            //            {
            //                Pen pen = new Pen(shape.getColor(), 3);
            //                Graphics g = frm.panel1.CreateGraphics();
            //                //g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                            
            //                DDA_Line2(line);
            //            }
            //            break;
            //    }
            //}
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
