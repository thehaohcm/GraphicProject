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
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public Rectangle():this(new Point(0, 0), new Point(0, 0))
        {
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

    }
}
