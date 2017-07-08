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
    partial class ScalingTransformForm : Form
    {
        DrawShape drawShape;
        public ScalingTransformForm(DrawShape drawShape)
        {
            InitializeComponent();
            this.drawShape = drawShape;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Trim() == ""||comboBox2.Text.Trim()=="")
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Bạn vui lòng nhập vào số tỉ lệ hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int scalingX = Convert.ToInt16(comboBox1.Text);
                int scalingY = Convert.ToInt16(comboBox2.Text);
                drawShape.transformScaling(scalingX,scalingY);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra, bạn vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
