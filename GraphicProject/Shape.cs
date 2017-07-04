﻿using System;
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
        private static int numCirCle = 1, numEllipse = 1, numLine = 1, numParallelogram = 1, numRectangle = 1, numSquare = 1, numTriangle = 1, numCube=1;

        protected Shape(TypeDraw typeDraw)
        {
            this.typeDraw = typeDraw;
            resetRemaningClick();
            this.color = Color.Black; //default color
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
                case TypeDraw.Cube:
                    this.name = "Cube_" + numCube;
                    numCube++;
                    this.remainingClick = 1;
                    break;
            }
        }

        public string getName()
        {
            return name;
        }
    }
}
