using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicProject
{
    abstract class Shape
    {
        Color color;
        TypeDraw typeDraw;
        private int remainingClick;
        private string name;
        private static int numCirCle = 1, numEllipse = 1, numLine = 1, numParallelogram = 1, numRectangle = 1, numSquare = 1, numTriangle = 1, numCube=1,numCylinder=1,numRhombus=1;
        private Point transformPoint;
        private bool transformFlag;

        protected Shape(TypeDraw typeDraw)
        {
            this.typeDraw = typeDraw;
            resetRemaningClick();
            this.color = Color.Black; //default color
            setTransformFlag(false);
        }

        protected void setTypeDraw(TypeDraw typeDraw)
        {
            this.typeDraw = typeDraw;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }

        public TypeDraw getTypeDraw()
        {
            return typeDraw;
        }

        public int getRemainingClick()
        {
            return this.remainingClick;
        }

        protected void resetRemaningClick()
        {
            switch (this.typeDraw)
            {
                case TypeDraw.Circle:
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Ellipse:
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Line:
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Parallelogram:
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Rectangle:
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Square:
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Triangle:
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Rhombus:
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Cube:
                    this.remainingClick = 1;
                    break;
            }
        }

        protected void minusRemainingClick()
        {
            if (remainingClick > 0)  
                this.remainingClick--;
        }

        private void setTransformClick()
        {
            this.remainingClick = 1;
        }

        public bool checkDrawable()
        {
            if (this.remainingClick > 1)
                return false;
            return true;
        }

        public void setName()
        {
            switch (this.typeDraw)
            {
                case TypeDraw.Circle:
                    this.name = "Circle_" + numCirCle;
                    numCirCle++;
                    break;
                case TypeDraw.Ellipse:
                    this.name = "Ellipse_" + numEllipse;
                    numEllipse++;
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Line:
                    this.name = "Line_" + numLine;
                    numLine++;
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Parallelogram:
                    this.name = "Parallelogram_" + numParallelogram;
                    numParallelogram++;
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Rectangle:
                    this.name = "Rectangle_" + numRectangle;
                    numRectangle++;
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Square:
                    this.name = "Square_" + numSquare;
                    numSquare++;
                    this.remainingClick = 2;
                    break;
                case TypeDraw.Triangle:
                    this.name = "Triangle_" + numTriangle;
                    numTriangle++;
                    this.remainingClick = 3;
                    break;
                case TypeDraw.Rhombus:
                    this.name = "Rhombus_" + numRhombus;
                    numRhombus++;
                    this.remainingClick = 3;
                    break;
                    break;
                case TypeDraw.Cube:
                    this.name = "Cube_" + numCube;
                    numCube++;
                    this.remainingClick = 1;
                    break;
                case TypeDraw.Cylinder:
                    this.name = "Cylinder_" + numCylinder;
                    numCylinder++;
                    this.remainingClick = 1;
                    break;
            }
        }

        public string getName()
        {
            return name;
        }

        public static void resetAllCountShape()
        {
            Shape.numCirCle = 1;
            Shape.numCube = 1;
            Shape.numCylinder = 1;
            Shape.numEllipse = 1;
            Shape.numLine = 1;
            Shape.numParallelogram = 1;
            Shape.numRectangle = 1;
            Shape.numSquare = 1;
            Shape.numTriangle = 1;
        }

        public void setTransformPoint(Point transformPoint)
        {
            this.transformPoint = transformPoint;
            setTransformFlag(true);
        }

        public Point getTransformPoint()
        {
            return transformPoint;
        }

        public void setTransformFlag(bool flag)
        {
            this.transformFlag = flag;
            if(flag)
                setTransformClick();
        }

        public bool getTransformFlag()
        {
            return this.transformFlag;
        }
    }
}
