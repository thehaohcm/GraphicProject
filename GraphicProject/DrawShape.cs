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

        private List<Shape> shapeSet,shapeSet3D;
        private Shape shape,choosedShape;
        private Form1 frm;
        private Color color;
        private bool choosedFlag = false;
        //private bool translationFlag = false;
        
        public DrawShape(Form1 frm)
        {
            shapeSet = new List<Shape>();
            shapeSet3D = new List<Shape>();
            this.frm = frm;
            color = Color.Black;
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
                case TypeDraw.Cube:
                    shape = new Cube();
                    break;
                case TypeDraw.Cylinder:
                    shape = new Cylinder();
                    break;
            }
            shape.setColor(color);
            choosedFlag = false;
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
            putpixel(round(centerX + x), round(centerY + y), color);
            putpixel(round(centerX + x), round(centerY - y), color);
            putpixel(round(centerX - x), round(centerY + y), color);
            putpixel(round(centerX - x), round(centerY - y), color);
            putpixel(round(centerX + y), round(centerY + x), color);
            putpixel(round(centerX + y), round(centerY - x), color);
            putpixel(round(centerX - y), round(centerY + x), color);
            putpixel(round(centerX - y), round(centerY - x), color);
        }

        private void put4pixel(int x, int y, int centerX, int centerY, Color color)
        {
            putpixel(round(centerX + x), round(centerY + y), color);
            putpixel(round(centerX - x), round(centerY + y), color);
            putpixel(round(centerX + x), round(centerY - y), color);
            putpixel(round(centerX - x), round(centerY - y), color);
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
            return new Point(round(X), round(Y));
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
            //if (x == centerX || y != centerY)
            //{
            //    R = Math.Abs(y - centerY);
            //}
            //else if (y == centerY)
            //{
            //    R = Math.Abs(x - centerX);
            //}
            R = round(circle.getRadius());
            int max = round((float)(Math.Sqrt(2) / 2 * R));
            p = 5 / 4 - R;
            x = 0; y = R;
            put8pixel(x, y, centerX, centerY, color);

            while (x <= max)
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
            //int x1, y1, x2, y2, centerX, centerY;
            int x, y, fx, fy, a2, b2, p, a, b;
            a = (int)ellipse.getWidthRadius();
            b = (int)ellipse.getHeightRadius();
            x = 0;
            y = b;
            a2 = a * a;
            b2 = b * b;
            fx = 0;
            fy = 2 * a2 * y;
            put4pixel(x, y, ellipse.getStartPoint().X, ellipse.getStartPoint().Y, ellipse.getColor());
            p = round(b2 - (a2 * b) + (0.25 * a2));//p=b2 - a2*b +a2/4
            while (fx < fy)
            {
                x++;
                fx += 2 * b2;
                //delay(50);
                if (p < 0)
                {
                    p += b2 * (2 * x + 3);//p=p + b2*(2x +3)
                }
                else
                {
                    y--;
                    p += b2 * (2 * x + 3) + a2 * (2 - 2 * y);//p=p +b2(2x +3) +a2(2-2y)
                    fy -= 2 * a2;
                }
                put4pixel(x, y, ellipse.getStartPoint().X, ellipse.getStartPoint().Y, ellipse.getColor());
            }
            p = round(b2 * (x + 0.5) * (x + 0.5) + a2 * (y - 1) * (y - 1) - a2 * b2);
            //
            while (y > 0)
            {
                y--;
                fy -= 2 * a2;
                // delay(50);
                if (p >= 0)
                {
                    p += a2 * (3 - 2 * y); //p=p +a2(3-2y)
                }
                else
                {
                    x++;
                    fx += 2 * b2;
                    p += b2 * (2 * x + 2) + a2 * (3 - 2 * y);//p=p+ b2(2x +2) + a2(3-2y)
                }
                put4pixel(ellipse.getStartPoint().X, ellipse.getStartPoint().Y, x, y, ellipse.getColor());
            }
        }
        public void DDA_Line(Line line) // Ve duong thang co dinh dang mau
        {
            //Line line = (Line)s;
            int Dx, Dy, count, temp_1, temp_2, dem = 1, absX, absY;
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
            float x, y, x_inc, y_inc;
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
            while (step != -1)
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

        public void drawLinebyMidPoint(Line line,bool dottedLineFlag=false)
        {
            int x1 = round(line.getStartPoint().X);
            int y1 = round(line.getStartPoint().Y);
            int x2 = round(line.getEndPoint().X);
            int y2 = round(line.getEndPoint().Y);
            int Dx =round(x2 - x1);
            int Dy =round(y2 - y1);
            int x = round(x1);
            int y = round(y1);
            putpixel(x1, y1, line.getColor());
            float P = 2*Dy - Dx;
            float Q = 2 * Dx - Dy;
            int count = 0;
            while (x < x2 || y < y2)
            {
                if (y < y2)
                {

                    y++;
                    if (Q < 0)
                    {
                        Q = Q + 2 * Dx;
                    }
                    else
                    {
                        Q = Q + 2 * (Dx - Dy);
                        x++;
                    }
                }
                else
                {
                    x++;
                    if (P < 0)
                    {
                        P = P + 2 * Dy;
                    }
                    else
                    {
                        P = P + 2 * (Dy - Dx);
                        y++;
                    }
                }
                if (dottedLineFlag==false||(dottedLineFlag == true && count % 10== 0))
                {
                    putpixel(round(x), round(y), line.getColor());
                    
                }
                count++;
            }
        }

        public void setColorForShape(Color color)
        {
            this.color = color;
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
            g.DrawLine(new Pen(Color.Aqua), 0, 200, 400, 200);
            g.DrawLine(new Pen(Color.Aqua), 200, 0, 200, 400);

        }

        public void paint(Object sender, PaintEventArgs e)
        {
            if (!choosedFlag)
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
                                {
                                    DDA_Line2(_line);
                                }
                            break;
                        case TypeDraw.Parallelogram:
                            Parallelogram parallelogram = (Parallelogram)s;
                            listLines = parallelogram.getAllLines();
                            if (listLines != null)
                                foreach (Line _line in listLines)
                                {
                                    DDA_Line2(_line);
                                }
                            break;
                        case TypeDraw.Circle:
                            Circle circle = (Circle)s;
                            MidPoint_Circle(circle);
                            break;
                        case TypeDraw.Ellipse:
                            Ellipse ellipse = (Ellipse)s;
                            MidPoint_Ellipse(ellipse);
                            break;
                        case TypeDraw.Cube:
                            Cube cube = (Cube)s;
                            g.DrawLine(new Pen(Color.Black), 200, 200, 400, 200);
                            g.DrawLine(new Pen(Color.Black), 200, 200, 200, 400);
                            //g.DrawLine(new Pen(Color.Red), 200, 0, 200, 200);
                            //g.DrawLine(new Pen(Color.Red), 200, 200, 400, 200);
                            g.DrawLine(new Pen(Color.Aqua), 200, 200, 400, 400);
                            foreach (Line _line in cube.getListLine())
                            {
                                //g.DrawLine(pen, _line.getStartPoint(), _line.getEndPoint());
                                drawLinebyMidPoint(_line,_line.getDottedLineFlag());
                            }
                            break;
                        case TypeDraw.Cylinder:
                            Cylinder cylinder = (Cylinder)s;
                            g.DrawLine(new Pen(Color.Black), 200, 200, 400, 200);
                            g.DrawLine(new Pen(Color.Black), 200, 200, 200, 400);
                            //g.DrawLine(new Pen(Color.Red), 200, 0, 200, 200);
                            //g.DrawLine(new Pen(Color.Red), 200, 200, 400, 200);
                            g.DrawLine(new Pen(Color.Aqua), 200, 200, 400, 400);
                            foreach(Shape _s in cylinder.getListLine())
                            {
                                if (_s.getTypeDraw() == TypeDraw.Line)
                                    drawLinebyMidPoint((Line)_s);
                                else if (_s.getTypeDraw() == TypeDraw.Ellipse)
                                    MidPoint_Ellipse((Ellipse)_s);
                            }
                            break;
                    }
                    g.Dispose();
                }
            }
            else
            {
                if (choosedShape != null)
                {
                    if (shape != null && shape.getTransformFlag())
                    {
                        Transform.transformTranslation(shape);
                    }
                    Pen pen = new Pen(choosedShape.getColor(), 3);
                    Graphics g = frm.panel1.CreateGraphics();
                    switch (choosedShape.getTypeDraw())
                    {
                        case TypeDraw.Line:
                            Line line = (Line)choosedShape;
                            //g.DrawLine(pen, line.getStartPoint().X, line.getStartPoint().Y, line.getEndPoint().X, line.getEndPoint().Y);
                            //DDA_Line2(line);
                            drawLinebyMidPoint(line);
                            break;
                        case TypeDraw.Rectangle:
                            Rectangle retangle = (Rectangle)choosedShape;
                            List<Line> listLines = retangle.getAllLines();
                            if (listLines != null)
                                foreach (Line _line in listLines)
                                {
                                    DDA_Line2(_line);
                                }
                            break;
                        case TypeDraw.Triangle:
                            Triangle triangle = (Triangle)choosedShape;
                            listLines = triangle.getAllLines();
                            if (listLines != null)
                                foreach (Line _line in listLines)
                                {
                                    DDA_Line2(_line);
                                }
                            break;
                        case TypeDraw.Parallelogram:
                            Parallelogram parallelogram = (Parallelogram)choosedShape;
                            listLines = parallelogram.getAllLines();
                            if (listLines != null)
                                foreach (Line _line in listLines)
                                {
                                    DDA_Line2(_line);
                                }
                            break;
                        case TypeDraw.Circle:
                            Circle circle = (Circle)choosedShape;
                            MidPoint_Circle(circle);
                            break;
                        case TypeDraw.Ellipse:
                            Ellipse ellipse = (Ellipse)choosedShape;
                            MidPoint_Ellipse(ellipse);
                            break;
                    }
                    g.Dispose();
                }
            }
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
            shape.setName();
            if (shape.getTypeDraw() == TypeDraw.Cube)
                shapeSet3D.Add(shape);
            shapeSet.Add(shape);
            updateListView();
        }

        public void clearAllScreen()
        {
            shapeSet.Clear();
            Shape.resetAllCountShape();
            frm.panel1.Refresh();
        }

        public void updateListView()
        {
            frm.listBox1.Items.Clear();
            foreach (Shape shape in shapeSet)
            {
                frm.listBox1.Items.Add(shape.getName());
            }
            if (frm.listBox1.Items.Count > 0)
                frm.button8.Enabled = true;
            else
                frm.button8.Enabled = false;
        }

        public void chooseShape(int index)
        {
            choosedFlag = true;
            choosedShape = shapeSet.ElementAt(index);
            getInfoShape();
        }

        public void removeShape(int index)
        {
            shapeSet.RemoveAt(index);
            choosedFlag = false;
            choosedShape = null;
            updateListView();
        }

        public void translationTransform(int index)
        {
            shape = shapeSet.ElementAt(index);
            shape.setTransformFlag(true);
            //this.translationFlag = true;
            //Transform.transformTranslation(shape, new Point(1, 1));
        }

        public void showAllShape2D()
        {
            choosedFlag = false;
        }

        private void getInfoShape()
        {
            
            frm.richTextBox1.AppendText("Tên hình ảnh: " + choosedShape.getName()+"\n");
            frm.richTextBox1.AppendText("Màu sắc: " + choosedShape.getColor().ToString() + "\n");
            switch (choosedShape.getTypeDraw())
            {
                case TypeDraw.Line:
                    Line line = (Line)choosedShape;
                    frm.richTextBox1.AppendText("Điểm đầu: " + line.getStartPoint().ToString()+"\n");
                    frm.richTextBox1.AppendText("Điểm cuối: " + line.getEndPoint().ToString()+"\n");
                    frm.richTextBox1.AppendText("Chiều dài: ");
                    break;
                case TypeDraw.Circle:
                    Circle circle = (Circle)choosedShape;
                    frm.richTextBox1.AppendText("Tâm: " + circle.getCenterPoint().ToString() + "\n");
                    frm.richTextBox1.AppendText("Bán kính: ");
                    break;
                case TypeDraw.Ellipse:
                    Ellipse ellipse = (Ellipse)choosedShape;
                    frm.richTextBox1.AppendText("Tâm: " + ellipse.getStartPoint().ToString() + "\n");
                    frm.richTextBox1.AppendText("Bán kính dài: ");
                    frm.richTextBox1.AppendText("Bán kính rộng: ");
                    break;
                case TypeDraw.Parallelogram:
                    Parallelogram parallelogram = (Parallelogram)choosedShape;
                    frm.richTextBox1.AppendText("Điểm thứ I: " + parallelogram.getPoint1().ToString()+"\n");
                    frm.richTextBox1.AppendText("Điểm thứ II: " + parallelogram.getPoint2().ToString()+"\n");
                    frm.richTextBox1.AppendText("Điểm thứ III: " + parallelogram.getPoint3().ToString()+"\n");
                    frm.richTextBox1.AppendText("Điểm thứ IV: " + parallelogram.getPoint4().ToString() + "\n");
                    frm.richTextBox1.AppendText("Chiều dài:" + "\n");
                    frm.richTextBox1.AppendText("Chiều rộng:" + "\n");
                    break;
                case TypeDraw.Rectangle:
                    Rectangle rectangle = (Rectangle)choosedShape;
                    frm.richTextBox1.AppendText("Điểm thứ I: "+rectangle.getStartPoint().ToString()+"\n");
                    frm.richTextBox1.AppendText("Điểm thứ II: " + rectangle.getPoint12().ToString() + "\n");
                    frm.richTextBox1.AppendText("Điểm thứ III: " + rectangle.getEndPoint().ToString() + "\n");
                    frm.richTextBox1.AppendText("Điểm thứ VI: " + rectangle.getPoint21().ToString() + "\n");
                    frm.richTextBox1.AppendText("Chiều dài:" + "\n");
                    frm.richTextBox1.AppendText("Chiều rộng:" + "\n");
                    break;
                case TypeDraw.Triangle:
                    Triangle triangle = (Triangle)choosedShape;
                    frm.richTextBox1.AppendText("Điểm thứ I" + triangle.getPoint1().ToString() + "\n");
                    frm.richTextBox1.AppendText("Điểm thứ II" + triangle.getPoint2().ToString() + "\n");
                    frm.richTextBox1.AppendText("Điểm thứ III" + triangle.getPoint3().ToString() + "\n");
                    frm.richTextBox1.AppendText("Độ dài cạnh I: " + "\n");
                    frm.richTextBox1.AppendText("Độ dài cạnh II: " + "\n");
                    frm.richTextBox1.AppendText("Độ dài cạnh III: " + "\n");
                    break;
            }
        }
    }
}
