﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据库工具
{
    public partial class FrmDate : Form
    {
        public FrmDate()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = listBox1.SelectedValue != null;
        }
    }
}
