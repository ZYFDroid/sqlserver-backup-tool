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
    public partial class CtlBkup : UserControl
    {

        public CtlBkup(String dbname,DateTime dbtime)
        {
            this.dbname = dbname;
            this.dbtime = dbtime;
            InitializeComponent();
        }

        private void CtlBkup_Load(object sender, EventArgs e)
        {
            lblName.Text = dbname;
            lblTime.Text = dbtime.toTimeStr();
        }

        public event EventHandler<EventArgs> OnRestoreClicked;
        public event EventHandler<EventArgs> OnHistoryClicked;
        public event EventHandler<EventArgs> OnShowClicked;

        public String dbname = "";
        public DateTime dbtime;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OnRestoreClicked?.Invoke(this, e);
        }

        private void btnHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnHistoryClicked?.Invoke(this, e);
        }

        private void btnShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnShowClicked?.Invoke(this, e);
        }
    }
}
