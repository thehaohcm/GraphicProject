using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Ellipse:Shape
    {
        Point startPoint, endWidthPoint, endHeightPoint;
        double widthRadius, heightRadius;
		public Ellipse(Point startPoint,Point endWidthPoint,Point endHightPoint,Color color):this(startPoint,endWidthPoint,endHightPoint)
        {
            setColor(color);
        }

		public Ellipse(Point startPoint,Point endWidthPoint, Point endHightPoint): base(TypeDraw.Ellipse)
        {
            //this.startPoint = startPoint;
            //this.endWidthPoint = endWidthPoint;
            //this.endHightPoint = endHightPoint;

            setStartPoint(startPoint);
            setEndWidthPoint(endWidthPoint);
            setEndHightPoint(endHightPoint);

            //calculate width,heigth
            //handle...
        }

        public Ellipse():this(new Point(0,0),new Point(0,0),new Point(0, 0))
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

        public void setEndWidthPoint(Point endWidthPoint)
        {
            this.endWidthPoint = endWidthPoint;
            minusRemainingClick();
            if (startPoint != null)
                widthRadius = Math.Abs(startPoint.X - endWidthPoint.X);
        }

        public Point getEndWidthPoint()
        {
            return endWidthPoint;
        }

        public void setEndHightPoint(Point endHightPoint)
        {
            this.endHeightPoint = endHightPoint;
            minusRemainingClick();
            if (startPoint != null)
                heightRadius = Math.Abs(startPoint.Y - endHeightPoint.Y);
        }

        public Point getEndHightPoint()
        {
            return endHeightPoint;
        }

        public double getWidthRadius() {
            return widthRadius;
        }

        public double getHeightRadius()
        {
            return heightRadius;
        }
    }
}
