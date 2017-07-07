using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Square:Shape
    {
        private Point point1, point2, point3, point4;
        private double edge;

        public Square(Point point1,Point point2, Color color):this(point1, point2)
        {
            setColor(color);
        }

        public Square(Point point1, Point point2):base(TypeDraw.Square)
        {
            resetRemaningClick();
            //this.startPoint = startPoint;
            //this.endPoint = endPoint;
            setPoint1(point1);
            setPoint2(point2);
        }

        private void calculatePointsandEdge()
        {
            this.edge = Math.Sqrt(((point2.X - point1.X) * (point2.X - point1.X)) + ((point2.Y - point1.Y) * (point2.Y - point1.Y)));

            this.point3 = new Point(point2.X, (int)(point2.Y + edge));
            this.point4 = new Point(point1.X, (int)(point1.Y + edge));
        }

        public Square() : this(new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setPoint1(Point point1)
        {
            this.point1 = point1;
            calculatePointsandEdge();
            minusRemainingClick();
        }

        public Point getPoint1()
        {
            return point1;
        }

        public void setPoint2(Point point2)
        {
            this.point2 = point2;
            calculatePointsandEdge();
            minusRemainingClick();
        }

        public Point getPoint2()
        {
            return point2;
        }

        public Point getPoint3()
        {
            return point3;
        }

        public Point getPoint4()
        {
            return point4;
        }

        public List<Line> getAllLines()
        {
            if (point1 == null || point2 == null)
                return null;
            Line l1 = new Line(point1,point2);
            l1.setColor(this.getColor());
            Line l2 = new Line(point2,point3);
            l2.setColor(this.getColor());
            Line l3 = new Line(point3,point4);
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

        public double getEdge()
        {
            return this.edge;
        }
    }
}
