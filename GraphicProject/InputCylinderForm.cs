using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicProject
{
    partial class InputCylinderForm : Form
    {
        DrawShape drawShape;
        public InputCylinderForm(DrawShape drawShape)
        {
            InitializeComponent();
            this.drawShape = drawShape;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputCylinderForm_Load(object sender, EventArgs e)
        {
            txtX.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int height,radius;
                height = Convert.ToInt16(textBox1.Text);
                radius = Convert.ToInt16(textBox2.Text);
                int x, y, z;
                x = Convert.ToInt16(txtX.Text);
                y = Convert.ToInt16(txtY.Text);
                z = Convert.ToInt16(txtZ.Text);
                drawShape.drawCylinder(new Point3D(x,y,z),height,radius);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, bạn vui lòng nhập lại giá trị"+ ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
    }
}
