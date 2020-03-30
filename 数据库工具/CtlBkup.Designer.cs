namespace 数据库工具
{
    partial class CtlBkup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.LinkLabel();
            this.btnShow = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(15, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(193, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "DBName";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(18, 24);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(106, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "2020-02-02 02:22:22";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(215, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(48, 32);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "读取";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.AutoSize = true;
            this.btnHistory.Location = new System.Drawing.Point(141, 23);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(31, 13);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.TabStop = true;
            this.btnHistory.Text = "历史";
            this.btnHistory.VisitedLinkColor = System.Drawing.Color.Blue;
            this.btnHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnHistory_LinkClicked);
            // 
            // btnShow
            // 
            this.btnShow.AutoSize = true;
            this.btnShow.Location = new System.Drawing.Point(173, 23);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(31, 13);
            this.btnShow.TabIndex = 4;
            this.btnShow.TabStop = true;
            this.btnShow.Text = "查看";
            this.btnShow.VisitedLinkColor = System.Drawing.Color.Blue;
            this.btnShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnShow_LinkClicked);
            // 
            // CtlBkup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblName);
            this.Name = "CtlBkup";
            this.Size = new System.Drawing.Size(266, 39);
            this.Load += new System.EventHandler(this.CtlBkup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.LinkLabel btnHistory;
        private System.Windows.Forms.LinkLabel btnShow;
    }
}
