using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Parallelogram : Shape
    {
        Point point1, point2, point3;

        Point point4;

        double width, height;
        public Parallelogram(Point point1, Point point2, Point point3, Color color) : this(point1, point2, point3)
        {
            setColor(color);
        }

        public Parallelogram(Point point1, Point point2, Point point3) : base(TypeDraw.Parallelogram)
        {
            //this.point1 = point1;
            //this.point2 = point2;
            //this.point3 = point3;

            setPoint1(point1);
            setPoint2(point2);
            setPoint3(point3);
            //handle => point 4
            //...
        }

        public Parallelogram() : this(new Point(0, 0), new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setPoint1(Point point)
        {
            this.point1 = point;
            calculatePoint4andlenths();
            minusRemainingClick();
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point)
        {
            this.point2 = point;
            calculatePoint4andlenths();
            minusRemainingClick();
        }

        public Point getPoint2()
        {
            return point2;
        }

        public void setPoint3(Point point)
        {
            this.point3 = point;
            calculatePoint4andlenths();
            minusRemainingClick();
        }

        public Point getPoint3()
        {
            return point3;
        }

        //public void setPoint4(Point point)
        //{
        //    this.point4 = point;
        //    minusRemainingClick();
        //}

        public Point getPoint4()
        {
            return point4;
        }

        private void calculatePoint4andlenths()
        {
            if ((point1 == null && point2 == null && point3 == null)&&(point1!=new Point(0,0)&&point2!=new Point(0,0)&&point3!=new Point(0,0)))
            {
                Point ptd = new Point(0, 0);
                ptd.X = point1.X + point3.X;
                ptd.Y = point1.Y + point3.Y;
                this.point4.X = ptd.X - point2.X;
                this.point4.Y = ptd.Y - point2.Y;

                double width, height;
                width = Math.Sqrt(((point2.X - point1.X) * (point2.X - point1.X)) - ((point2.Y - point1.Y) * (point2.Y - point1.Y)));
                height = Math.Sqrt(((point3.X - point1.X) * (point3.X - point1.X)) - ((point3.Y - point1.Y) * (point3.Y - point1.Y)));
                if (width < height)
                {
                    this.width = width;
                    this.height = height;
                }
                else
                {
                    this.height = width;
                    this.width = height;
                }
            }
        }

        public List<Line> getAllLines()
        {
            if (point1 == null || point2 == null || point3 == null || point4 == null)
                return null;
            Line l1 = new Line(point1, point2);
            l1.setColor(this.getColor());
            Line l2 = new Line(point2, point3);
            l2.setColor(this.getColor());
            Line l3 = new Line(point3, point4);
            l3.setColor(this.getColor());
            Line l4 = new Line(point4, point1);
            l4.setColor(this.getColor());
            List<Line> listLine = new List<Line>();
            listLine.Add(l1);
            listLine.Add(l2);
            listLine.Add(l3);
            listLine.Add(l4);
            return listLine;
        }

        public double getWidth()
        {
            return this.width;
        }

        public double getHeight()
        {
            return this.height;
        }
    }
}
