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

        protected void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
    }
}
