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
        private static decimal currentNumber = 0;
        private Point startPoint, endPoint;
        public Line(Point startPoint,Point endPoint,Color color):this(startPoint,endPoint)
        {
            setColor(color);
        }

        public Line(Point startPoint,Point endPoint): base(TypeDraw.Line)
        {
            setStartPoint(startPoint);
            setEndPoint(endPoint);
            currentNumber++;
            setName("Line_" + currentNumber);
        }

        public Line():this(new Point(0, 0), new Point(0, 0))
        {
            this.resetRemaningClick();
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
            minusRemainingClick();
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
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
    }
}
