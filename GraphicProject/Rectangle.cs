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
            List<Line> listLine = new List<Line>();
            listLine.Add(new Line(startPoint,point12));
            listLine.Add(new Line( point12,endPoint));
            listLine.Add(new Line( endPoint,point21));
            listLine.Add(new Line(point21,startPoint));
            return listLine;
        }

    }
}
