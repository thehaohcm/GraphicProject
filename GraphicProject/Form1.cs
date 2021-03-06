﻿using System;
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
            button13.Enabled = false;
            button12.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button17.Enabled = false;
        }

        public int round(double tds)
        {
            int tdm;
            double sodu = tds % 5;
            if (sodu != 0)
            {
                if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > 400) tdm = 400;
            return tdm;
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
                            //line.setStartPoint(new Point(Convert.ToInt16(round(e.X)), Convert.ToInt16(round(e.Y))));
                            line.setStartPoint(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Rectangle:
                            Rectangle rectangle = (Rectangle)drawShape.getShape();
                            rectangle.setStartPoint(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Triangle:
                            Triangle triangle = (Triangle)drawShape.getShape();
                            if (triangle.getRemainingClick() == 3)
                                triangle.setPoint1(new Point(round(e.X), round(e.Y)));
                            else if (triangle.getRemainingClick() == 2)
                                triangle.setPoint2(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Parallelogram:
                            Parallelogram parallelogram = (Parallelogram)drawShape.getShape();
                            if (parallelogram.getRemainingClick() == 3)
                                parallelogram.setPoint1(new Point(round(e.X), round(e.Y)));
                            else if (parallelogram.getRemainingClick() == 2)
                                parallelogram.setPoint2(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Circle:
                            Circle circle = (Circle)drawShape.getShape();
                            circle.setCenterPoint(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Ellipse:
                            Ellipse ellipse = (Ellipse)drawShape.getShape();
                            if (ellipse.getRemainingClick() == 3)
                                ellipse.setStartPoint(new Point(round(e.X), round(e.Y)));
                            else if (ellipse.getRemainingClick() == 2)
                                ellipse.setEndWidthPoint(new Point(round(e.X), round(e.Y)));
                            break;
                        case TypeDraw.Square:
                            Square square = (Square)drawShape.getShape();
                            square.setPoint1(new Point(round(e.X), round(e.Y)));
                            break;
                        
                    }
                }
                else
                {
                    if (drawShape.getShape().getTransformFlag())
                    {
                        drawShape.getShape().setTransformPoint(new Point(round(e.X), round(e.Y)));
                    }
                    else {
                        switch (drawShape.getShape().getTypeDraw())
                        {
                            case TypeDraw.Line:
                                Line line = (Line)drawShape.getShape();
                                //line.setEndPoint(new Point(Convert.ToInt16(round(e.X)), Convert.ToInt16(round(e.Y))));
                                line.setEndPoint(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Rectangle:
                                Rectangle rectangle = (Rectangle)drawShape.getShape();
                                rectangle.setEndPoint(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Triangle:
                                Triangle triangle = (Triangle)drawShape.getShape();
                                triangle.setPoint3(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Parallelogram:
                                Parallelogram paralleogram = (Parallelogram)drawShape.getShape();
                                paralleogram.setPoint3(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Circle:
                                Circle circle = (Circle)drawShape.getShape();
                                circle.setEndPoint(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Ellipse:
                                Ellipse ellipse = (Ellipse)drawShape.getShape();
                                ellipse.setEndHightPoint(new Point(round(e.X), round(e.Y)));
                                break;
                            case TypeDraw.Cube:
                                //Cube cube = (Cube)drawShape.getShape();
                                //cube.setStartPoint(new Point(round(e.X), round(e.Y)));
                                //new InputCubeForm(drawShape).ShowDialog();
                                return;
                                break;
                            case TypeDraw.Cylinder:
                                //Cylinder cylinder = (Cylinder)drawShape.getShape();
                                //cylinder.setPoint(new Point(round(e.X), round(e.Y)));
                                return;
                                break;
                            case TypeDraw.Square:
                                Square square = (Square)drawShape.getShape();
                                square.setPoint2(new Point(round(e.X), round(e.Y)));
                                break;

                        }
                        drawShape.addShapeToShapeSet();
                        drawShape.resetShape();
                        button9.Enabled = false;
                        button12.Enabled = false;
                        button14.Enabled = false;
                        button15.Enabled = false;
                        button17.Enabled = false;
                        button13.Enabled = false;
                        if (drawShape.getShapeSet().Count == 0)
                            button8.Enabled = false;
                    }
                    panel1.Refresh();
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
                    drawShape.setNullChoosedShape();
                    richTextBox1.Clear();
                    button9.Enabled = false;
                    button12.Enabled = false;
                    button14.Enabled = false;
                    button15.Enabled = false;
                    button17.Enabled = false;
                    button13.Enabled = false;
                    button8.Enabled = false;
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
                richTextBox1.Clear();
                this.indexChoosedShape = index;
                drawShape.chooseShape(index);
                button9.Enabled = true;
                button8.Enabled = true;
                button13.Enabled = true;
                button12.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button17.Enabled = true;

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
                    button8.Enabled = false;
                    button13.Enabled = false;
                    button12.Enabled = false;
                    button14.Enabled = false;
                    button15.Enabled = false;
                    button17.Enabled = false;
                    panel1.Refresh();
                    richTextBox1.Clear();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Cube);
            new InputCubeForm(drawShape).ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Cylinder);
            new InputCylinderForm(drawShape).ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (indexChoosedShape != -1)
            {
                drawShape.translationTransform(indexChoosedShape);
                //panel1.Refresh();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            drawShape.showAllShape();
            drawShape.setNullChoosedShape();
            richTextBox1.Clear();
            panel1.Refresh();
        }

        public void setCube(int height,int width,int depth)
        {

        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            button11.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button16.Enabled = true;

            dToolStripMenuItem.Checked = true;
            dToolStripMenuItem1.Checked = false;
            drawShape.setCheck2d(true);
            //panel1.Invalidate();
            panel1.Refresh();
            drawShape.updateListView();
        }

        private void dToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button10.Enabled = true;
            button11.Enabled = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button16.Enabled = false;

            dToolStripMenuItem1.Checked = true;
            dToolStripMenuItem.Checked = false;
            drawShape.setCheck2d(false);
            //panel1.Invalidate();
            panel1.Refresh();
            drawShape.updateListView();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (new ScalingTransformForm(drawShape).ShowDialog()==DialogResult.OK)
                panel1.Refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(new ReflectionTransformForm(drawShape).ShowDialog() == DialogResult.OK)
            {
                panel1.Refresh();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            drawShape.initShape(TypeDraw.Square);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(new RotationTransformForm(drawShape).ShowDialog() == DialogResult.OK)
            {
                panel1.Refresh();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                drawShape.fillColor(color);
            }
        }
    }
}
