﻿using System;
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
    partial class RotationTransformForm : Form
    {
        DrawShape drawShape;
        public RotationTransformForm(DrawShape drawShape)
        {
            InitializeComponent();
            this.drawShape = drawShape;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text.Trim()=="")
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Bạn vui lòng nhập vào góc quay hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float rotation = float.Parse(comboBox1.Text);
                drawShape.transformRotation(rotation);
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
