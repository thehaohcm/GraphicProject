using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    class Line:Shape
    {
        private Point startPoint, endPoint;
        private bool dottedLineFlag;
        private double length;
        
        public Line(Point startPoint,Point endPoint,Color color):this(startPoint,endPoint)
        {
            setColor(color);
        }

        public Line(Point startPoint,Point endPoint, bool dottedLineFlag=false):this(startPoint,endPoint)
        {
            setDottedLineFlag(dottedLineFlag);
        }

        public Line(Point startPoint,Point endPoint): base(TypeDraw.Line)
        {
            setStartPoint(startPoint);
            setEndPoint(endPoint);
        }


        public Line() : this(new Point(0, 0), new Point(0, 0))
        {
            this.resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            calculateLength();
            minusRemainingClick();
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
            calculateLength();
            minusRemainingClick();
        }

        public Point getStartPoint()
        {
            return startPoint;
        }

        public Point getEndPoint()
        {
            return endPoint;
        }

        public void setDottedLineFlag(bool dottedLineFlag)
        {
            this.dottedLineFlag = dottedLineFlag;
        }

        public bool getDottedLineFlag()
        {
            return this.dottedLineFlag;
        }

        private void calculateLength()
        {
            if ((startPoint != null && endPoint != null) || (startPoint != new Point(0, 0)) && endPoint != new Point(0, 0)) {
                this.length = Math.Sqrt(((endPoint.X - startPoint.X) * (endPoint.X - startPoint.X)) + ((endPoint.Y - startPoint.Y) * (endPoint.Y - startPoint.Y)));
            }
        }

        public double getLength()
        {
            return this.length;
        }
    }
}
