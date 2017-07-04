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

namespace GraphicProject
{
    public partial class Form1 : Form
    {
        DrawShape drawShape;
        private int indexChoosedShape = -1;
        public Form1()
        {
            InitializeComponent();
            label2.BackColor = colorDialog1.Color;
            drawShape = new DrawShape(this);
            button9.Enabled = false;
            panel1.Paint += new PaintEventHandler(drawShape.paint);
            button8.Enabled = false;
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
                            line.setStartPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Rectangle:
                            Rectangle rectangle = (Rectangle)drawShape.getShape();
                            rectangle.setStartPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Triangle:
                            Triangle triangle = (Triangle)drawShape.getShape();
                            if (triangle.getRemainingClick() == 3)
                                triangle.setPoint1(new Point(e.X, e.Y));
                            else if (triangle.getRemainingClick() == 2)
                                triangle.setPoint2(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Parallelogram:
                            Parallelogram parallelogram = (Parallelogram)drawShape.getShape();
                            if (parallelogram.getRemainingClick() == 3)
                                parallelogram.setPoint1(new Point(e.X, e.Y));
                            else if (parallelogram.getRemainingClick() == 2)
                                parallelogram.setPoint2(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Circle:
                            Circle circle = (Circle)drawShape.getShape();
                            circle.setCenterPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Ellipse:
                            Ellipse ellipse = (Ellipse)drawShape.getShape();
                            if (ellipse.getRemainingClick() == 3)
                                ellipse.setStartPoint(new Point(e.X, e.Y));
                            else if (ellipse.getRemainingClick() == 2)
                                ellipse.setEndHightPoint(new Point(e.X, e.Y));
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
                            line.setEndPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Rectangle:
                            Rectangle rectangle = (Rectangle)drawShape.getShape();
                            rectangle.setEndPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Triangle:
                            Triangle triangle = (Triangle)drawShape.getShape();
                            triangle.setPoint3(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Parallelogram:
                            Parallelogram paralleogram = (Parallelogram)drawShape.getShape();
                            paralleogram.setPoint3(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Circle:
                            Circle circle = (Circle)drawShape.getShape();
                            circle.setEndPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Ellipse:
                            Ellipse ellipse = (Ellipse)drawShape.getShape();
                            ellipse.setEndWidthPoint(new Point(e.X, e.Y));
                            break;
                        case TypeDraw.Cube:
                            Cube cube = (Cube)drawShape.getShape();
                            cube.setPoint(new Point(e.X, e.Y));
                            break;
                    }
                    drawShape.addShapeToShapeSet();
                    
                    panel1.Refresh();
                    drawShape.resetShape();
                }
            }
            else if (e.Button == MouseButtons.Right) //cancel and clear the current shape in screen
            {
                drawShape.resetShape();
                //panel1.Paint += new PaintEventHandler(drawShape.paint);
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
                drawShape.setColorForShape(colorDialog1.Color);
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult r = MessageBox.Show("Bạn có thật sựa muốn xóa hết tất cả?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    drawShape.clearAllScreen();
                    drawShape.updateListView();
                    panel1.Refresh();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                this.indexChoosedShape = index;
                drawShape.chooseShape(index);
                button9.Enabled = true;
                //drawShape.resetShape();
                panel1.Refresh();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (indexChoosedShape != -1) {
                DialogResult r=MessageBox.Show("Bạn có thật sự muốn xóa hình này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    drawShape.removeShape(indexChoosedShape);
                    this.indexChoosedShape = -1;
                    button9.Enabled = false;
                    panel1.Refresh();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Cube);
            
        }
    }
}
