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
        private bool dottedEllipseFlag,changeFlag;

        public Ellipse(Point startPoint,Point endWidthPoint,Point endHightPoint,Color color):this(startPoint,endWidthPoint,endHightPoint)
        {
            setColor(color);
        }

		public Ellipse(Point startPoint,Point endWidthPoint, Point endHightPoint, bool dottedEllipseFlag=false) : base(TypeDraw.Ellipse)
        {
            setStartPoint(startPoint);
            setEndWidthPoint(endWidthPoint);
            setEndHightPoint(endHightPoint);

            setDottedEllipseFlag(dottedEllipseFlag);
            //calculate width,heigth
            //handle...
        }

        public Ellipse() : this(new Point(0, 0), new Point(0, 0), new Point(0, 0))
        {
            dottedEllipseFlag = true;
            resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            //calculateWidthHeight();
            minusRemainingClick();
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public void setEndWidthPoint(Point endWidthPoint)
        {
            this.endWidthPoint = endWidthPoint;
            //calculateWidthHeight();
            minusRemainingClick();
        }

        public Point getEndWidthPoint()
        {
            return endWidthPoint;
        }

        public void setEndHightPoint(Point endHightPoint)
        {
            this.endHeightPoint = endHightPoint;
            calculateWidthHeight();
            minusRemainingClick();
            if (startPoint != null)
                //heightRadius = Math.Abs(startPoint.Y - endHeightPoint.Y);
                heightRadius = Math.Sqrt(((endHeightPoint.X - startPoint.X) * (endHeightPoint.X - startPoint.X)) + ((endHeightPoint.Y - startPoint.Y) * (endHeightPoint.Y - startPoint.Y)));

            if (startPoint != null && endWidthPoint != null)
            {

            }
        }

        public Point getEndHightPoint()
        {
            return endHeightPoint;
        }

        public double getWidthRadius()
        {
            return widthRadius;
        }

        public double getHeightRadius()
        {
            return heightRadius;
        }

        public void setDottedEllipseFlag(bool dottedEllipseFlag)
        {
            this.dottedEllipseFlag = dottedEllipseFlag;
        }

        public bool getDottedEllipseFlag()
        {
            return this.dottedEllipseFlag;
        }

        public void calculateWidthHeight()
        {
            if ((startPoint != null && endWidthPoint != null && endHeightPoint != null) || (startPoint != new Point(0, 0) && endHeightPoint != new Point(0, 0) && endWidthPoint != new Point(0, 0))){
                double widthRadius, heightRadius;
                widthRadius = Math.Sqrt(((endWidthPoint.X - startPoint.X) * (endWidthPoint.X - startPoint.X)) + ((endWidthPoint.Y - startPoint.Y) * (endWidthPoint.Y - startPoint.Y)));
                heightRadius = Math.Sqrt(((endHeightPoint.X - startPoint.X) * (endHeightPoint.X - startPoint.X)) + ((endHeightPoint.Y - startPoint.Y) * (endHeightPoint.Y - startPoint.Y)));
                if (widthRadius < heightRadius)
                {
                    this.widthRadius = widthRadius;
                    this.heightRadius = heightRadius;
                    this.changeFlag = false;
                }
                else
                {
                    this.widthRadius = widthRadius;
                    this.heightRadius = heightRadius;
                    //this.widthRadius = widthRadius;
                    //this.heightRadius = heightRadius;

                    this.changeFlag = true;
                    //Point tempPoint = new Point(endHeightPoint.X, endHeightPoint.Y);
                    //endHeightPoint = endWidthPoint;
                    //endWidthPoint = tempPoint;
                }
            }
        }

        public bool getChangeFlag()
        {
            return changeFlag;
        }
    }
}
