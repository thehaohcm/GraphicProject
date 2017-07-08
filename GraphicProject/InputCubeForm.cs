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
    partial class InputCubeForm : Form
    {
        DrawShape drawShape;
        public InputCubeForm(DrawShape drawShape)
        {
            InitializeComponent();
            this.drawShape = drawShape;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputCubeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int width, height, depth;
                width = Convert.ToInt16(textBox1.Text);
                height = Convert.ToInt16(textBox2.Text);
                depth = Convert.ToInt16(textBox3.Text);
                drawShape.drawCube(width,height,depth);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, bạn vui lòng nhập lại giá trị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
    }
}
