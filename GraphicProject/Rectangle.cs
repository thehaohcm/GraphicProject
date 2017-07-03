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

        public Rectangle():this(new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            minusRemainingClick();
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            minusRemainingClick();
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public List<Line> getAllLines()
        {
            if (startPoint == null || endPoint == null)
                return null;
            Point point12 = new Point(endPoint.X,startPoint.Y);
            Point point21 = new Point(startPoint.X, endPoint.Y);
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

    }
}
