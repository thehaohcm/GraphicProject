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
        public Line(Point startPoint,Point endPoint,Color color):this(startPoint,endPoint)
        {
            setColor(color);
        }

        public Line(Point startPoint,Point endPoint): base(TypeDraw.Line)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public Line():this(new Point(0, 0), new Point(0, 0))
        {
        }

        public void setStartPoint(Point startPoint)
        {
            this.startPoint = startPoint;
        }

        public void setEndPoint(Point endPoint)
        {
            this.endPoint = endPoint;
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
