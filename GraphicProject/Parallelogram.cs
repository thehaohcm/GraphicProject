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
            setName();
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
            minusRemainingClick();
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point)
        {
            this.point2 = point;
            minusRemainingClick();
        }

        public Point getPoint2()
        {
            return point2;
        }

        public void setPoint3(Point point)
        {
            this.point3 = point;
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

        private void calculatePoint4()
        {
            if (point1 == null || point2 == null || point3 == null)
                return;
            //calculatePoint4();
            //if (point1.X > point2.X)
            //{
            //    if (point3.X < point2.X)
            //        this.point4 = new Point(point1.X - (point2.X - point3.X), point3.Y);
            //    else
            //        this.point4 = new Point(point1.X + (point3.X - point2.X), point3.Y);
            //}
            //else
            if (point1.X < point2.X)
            {
                if (point1.X < point2.X)
                    this.point4 = new Point(point3.X + (point1.X - point2.X), point3.Y);
                else
                    this.point4 = new Point(point3.X - (point2.X - point1.X), point3.Y);
            }
            //if (point1.Y > point2.Y)
            //{
            //    if (point3.X < point2.X)
            //        this.point4 = new Point(point1.X - (point2.X - point3.X), point3.Y);
            //    else
            //        this.point4 = new Point(point1.X + (point3.X - point2.X), point3.Y);
            //}
            //else
            else if (point1.Y < point2.Y)
            {
                if (point1.X < point2.X)
                    this.point4 = new Point(point3.X - (point2.X - point1.X), point1.Y);
                else
                    this.point4 = new Point(point3.X + (point1.X - point2.X), point1.Y);
            }
            minusRemainingClick();
        }

        public List<Line> getAllLines()
        {
            if (point1 == null || point2 == null || point3 == null || point4 == null)
                return null;
            calculatePoint4();
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
    }
}
