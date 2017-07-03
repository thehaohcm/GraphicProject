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
        private double radius;

        public Circle(Point centerPoint, Point endPoint, Color color) : this(centerPoint, endPoint)
        {
            setColor(color);
        }

        public Circle(Point centerPoint,Point endPoint): base(TypeDraw.Circle)
        {
            setCenterPoint(centerPoint);
            setEndPoint(endPoint);

            //calculate radius
            //handle...

        }

        public Circle():this(new Point(0, 0), new Point(0, 0))
        {
            resetRemaningClick();
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public void setCenterPoint(Point centerPoint)
        {
            this.centerPoint = centerPoint;
            minusRemainingClick();
            calculateRadius();
        }

        public Point getCenterPoint()
        {
            return centerPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            minusRemainingClick();
            //calculate radius
            //....
            calculateRadius();
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public double getRadius()
        {
            return radius;
        }

        private void calculateRadius()
        {
            if (centerPoint != new Point(0,0) && endPoint != new Point(0,0))
            {
                double c1 = Math.Abs(centerPoint.X - endPoint.X);
                double c2 = Math.Abs(centerPoint.Y - endPoint.Y);
                this.radius = Math.Sqrt(c1 * c1 + c2 * c2);
            }
        }
    }
}
