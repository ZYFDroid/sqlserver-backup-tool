namespace 数据库工具
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStat = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tblSave = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshSave = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblDb = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefreshDB = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnModConn = new System.Windows.Forms.Button();
            this.bkgndWorker = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.tblMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStat
            // 
            this.txtStat.AutoSize = true;
            this.txtStat.Location = new System.Drawing.Point(20, 13);
            this.txtStat.Name = "txtStat";
            this.txtStat.Size = new System.Drawing.Size(91, 13);
            this.txtStat.TabIndex = 0;
            this.txtStat.Text = "已连接到数据库";
            // 
            // tblMain
            // 
            this.tblMain.Controls.Add(this.tabPage1);
            this.tblMain.Controls.Add(this.tabPage2);
            this.tblMain.Location = new System.Drawing.Point(15, 37);
            this.tblMain.Name = "tblMain";
            this.tblMain.SelectedIndex = 0;
            this.tblMain.Size = new System.Drawing.Size(305, 308);
            this.tblMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tblSave);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnRefreshSave);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "读档";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblSave
            // 
            this.tblSave.AutoScroll = true;
            this.tblSave.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tblSave.Location = new System.Drawing.Point(0, 29);
            this.tblSave.Name = "tblSave";
            this.tblSave.Size = new System.Drawing.Size(298, 250);
            this.tblSave.TabIndex = 5;
            this.tblSave.WrapContents = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "存档列表";
            // 
            // btnRefreshSave
            // 
            this.btnRefreshSave.Location = new System.Drawing.Point(216, 5);
            this.btnRefreshSave.Name = "btnRefreshSave";
            this.btnRefreshSave.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSave.TabIndex = 0;
            this.btnRefreshSave.Text = "刷新";
            this.btnRefreshSave.UseVisualStyleBackColor = true;
            this.btnRefreshSave.Click += new System.EventHandler(this.btnRefreshSave_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblDb);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnRefreshDB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "存档";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblDb
            // 
            this.tblDb.AutoScroll = true;
            this.tblDb.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tblDb.Location = new System.Drawing.Point(0, 29);
            this.tblDb.Name = "tblDb";
            this.tblDb.Size = new System.Drawing.Size(298, 250);
            this.tblDb.TabIndex = 4;
            this.tblDb.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "数据库列表";
            // 
            // btnRefreshDB
            // 
            this.btnRefreshDB.Location = new System.Drawing.Point(216, 5);
            this.btnRefreshDB.Name = "btnRefreshDB";
            this.btnRefreshDB.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshDB.TabIndex = 2;
            this.btnRefreshDB.Text = "刷新";
            this.btnRefreshDB.UseVisualStyleBackColor = true;
            this.btnRefreshDB.Click += new System.EventHandler(this.btnRefreshDB_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(242, 8);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(75, 23);
            this.btnRetry.TabIndex = 3;
            this.btnRetry.Text = "重连";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnModConn
            // 
            this.btnModConn.Location = new System.Drawing.Point(161, 8);
            this.btnModConn.Name = "btnModConn";
            this.btnModConn.Size = new System.Drawing.Size(75, 23);
            this.btnModConn.TabIndex = 3;
            this.btnModConn.Text = "连接参数";
            this.btnModConn.UseVisualStyleBackColor = true;
            this.btnModConn.Click += new System.EventHandler(this.btnModConn_Click);
            // 
            // bkgndWorker
            // 
            this.bkgndWorker.WorkerReportsProgress = true;
            this.bkgndWorker.WorkerSupportsCancellation = true;
            this.bkgndWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgndWorker_DoWork);
            this.bkgndWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgndWorker_ProgressChanged);
            this.bkgndWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgndWorker_RunWorkerCompleted);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(333, 357);
            this.Controls.Add(this.btnModConn);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.txtStat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "本地数据库存档读档";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtStat;
        private System.Windows.Forms.TabControl tblMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshSave;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnModConn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshDB;
        private System.Windows.Forms.FlowLayoutPanel tblSave;
        private System.Windows.Forms.FlowLayoutPanel tblDb;
        private System.ComponentModel.BackgroundWorker bkgndWorker;
        private System.IO.FileSystemWatcher fileSystemWatcher;
    }
}

