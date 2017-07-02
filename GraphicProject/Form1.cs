using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

public delegate void drawCoordinates();
namespace GraphicProject
{
    public partial class Form1 : Form
    {
        DrawShape drawShape;
        
        public Form1()
        {
            InitializeComponent();
            label2.BackColor = colorDialog1.Color;
            drawShape = new DrawShape(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Line);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            drawShape.drawCoordinates();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawShape.getShape() == null)
                {
                    MessageBox.Show("Bạn vui lòng chọn hình trước khi vẽ");
                    return;
                }
                if(!drawShape.getShape().checkDrawable())//if (!endClick)
                {
                    switch (drawShape.getShape().getTypeDraw())
                    {
                        case TypeDraw.Line:
                            Line line = (Line)drawShape.getShape();
                            //line.setStartPoint(new Point(Convert.ToInt16(e.X), Convert.ToInt16(e.Y)));
                            line.setStartPoint(drawShape.roundPoint(e.X, e.Y));
                            break;
                        case TypeDraw.Circle:

                            break;
                    }
                }
                else
                {
                    switch (drawShape.getShape().getTypeDraw())
                    {
                        case TypeDraw.Line:
                            Line line = (Line)drawShape.getShape();
                            //line.setEndPoint(new Point(Convert.ToInt16(e.X), Convert.ToInt16(e.Y)));
                            line.setEndPoint(drawShape.roundPoint(e.X, e.Y));
                            break;
                    }
                    drawShape.addShapeToShapeSet();
                    panel1.Paint += new PaintEventHandler(drawShape.paint);
                    panel1.Refresh();
                    drawShape.resetShape();
                }
            }
            else if (e.Button == MouseButtons.Right) //cancel and clear the current shape in screen
            {
                drawShape.resetShape();
                panel1.Paint += new PaintEventHandler(drawShape.paint);
                panel1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Circle);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.BackColor = colorDialog1.Color;
                if (drawShape.getShape() != null)
                    drawShape.getShape().setColor(colorDialog1.Color);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //if(drawShape.getShape()!=null&&drawShape.getShape().checkDrawable())//if (endClick)
            //{
            //    switch (drawShape.getShape().getTypeDraw())
            //    {
            //        case TypeDraw.Line:
            //            Line line = (Line)drawShape.getShape();
            //            line.setEndPoint(drawShape.roundPoint(e.X,e.Y));
            //            break;
            //    }
            //    panel1.Paint += new PaintEventHandler(drawShape.paint);
            //    panel1.Refresh();
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Ellipse);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Rectangle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Parallelogram);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Triangle);
        }
    }
}
