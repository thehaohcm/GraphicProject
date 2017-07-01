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

        protected Shape()
        {

        }

        protected Shape(TypeDraw typeDraw)
        {
            this.typeDraw = typeDraw;
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
    }
}
