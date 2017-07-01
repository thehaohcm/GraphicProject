using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Circle:Shape
    {
        private Point centerPoint,endPoint;
        private int radius;

        public Circle(Point centerPoint, Point endPoint, Color color) : this(centerPoint, endPoint)
        {
            setColor(color);
        }

        public Circle(Point centerPoint,Point endPoint): base(TypeDraw.Circle)
        {
            this.centerPoint = centerPoint;
            this.endPoint = endPoint;

            //calculate radius
            //handle...
        }

        public Circle():this(new Point(0, 0), new Point(0, 0))
        {
        }

        public void setCenterPoint(Point centerPoint)
        {
            this.centerPoint = centerPoint;
        }

        public Point getCenterPoint()
        {
            return centerPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            //calculate radius
            //....
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public int getRadius()
        {
            return radius;
        }
    }
}
