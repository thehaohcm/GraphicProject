using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Rectangle:Shape
    {
        Point startPoint, endPoint;
        Point point12, point21;
        double width, height;

        //Insert 2 Point to Rectangle and get-set method
        //handle...

        public Rectangle(Point startPoint,Point endPoint,Color color):this(startPoint,endPoint)
        {
            setColor(color);
        }

        public Rectangle(Point startPoint,Point endPoint):base(TypeDraw.Rectangle)
        {
            resetRemaningClick();
            //this.startPoint = startPoint;
            //this.endPoint = endPoint;
            setStartPoint(startPoint);
            setEndPoint(endPoint);
        }

        private void calculatePoints()
        {
            this.point12 = new Point(endPoint.X, startPoint.Y);
            this.point21 = new Point(startPoint.X, endPoint.Y);
        }

        public Rectangle() : this(new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            calculatePoints();
            calcuateWidthHeight();
            minusRemainingClick();
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            calculatePoints();
            calcuateWidthHeight();
            minusRemainingClick();
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public Point getPoint12()
        {
            return point12;
        }

        public Point getPoint21()
        {
            return point21;
        }

        public List<Line> getAllLines()
        {
            if (startPoint == null || endPoint == null)
                return null;
            Line l1 = new Line(startPoint, point12);
            l1.setColor(this.getColor());
            Line l2 = new Line(point12, endPoint);
            l2.setColor(this.getColor());
            Line l3 = new Line(endPoint, point21);
            l3.setColor(this.getColor());
            Line l4 = new Line(point21, startPoint);
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

        public double getHeigth()
        {
            return this.height;
        }

        private void calcuateWidthHeight()
        {
            if ((startPoint != null && endPoint != null)&&(startPoint!=new Point(0,0))&&endPoint!=new Point(0,0))
            {
                double width = Math.Sqrt(((endPoint.X - point12.X) * (endPoint.X - point12.X)) + ((endPoint.Y - point12.Y) * (endPoint.Y - point12.Y)));
                double height = Math.Sqrt(((startPoint.X - point21.X) * (startPoint.X - point21.X)) + ((startPoint.Y - point21.Y) * (startPoint.Y - point21.Y)));
                if (width < height)
                {
                    this.width = width;
                    this.height = height;
                }
                else
                {
                    this.width = height;
                    this.height = width;
                }
            }
        }
    }
}
