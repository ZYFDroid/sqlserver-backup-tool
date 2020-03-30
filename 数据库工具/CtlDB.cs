using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据库工具
{
    public partial class CtlDB : UserControl
    {
        public CtlDB(String dbname)
        {
            this.dbname = dbname;
            InitializeComponent();
        }

        public event EventHandler<EventArgs> OnBackupClicked;

        public String dbname = "";

        private void CtlDB_Load(object sender, EventArgs e)
        {
            label1.Text = dbname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnBackupClicked?.Invoke(this,e);
        }
    }
}
