﻿namespace ArchiveStation
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchangepwd = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLCopyRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pushPanel1 = new UILibrary.PushPanel.PushPanel();
            this.pushPanelItem1 = new UILibrary.PushPanel.PushPanelItem();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnLabelConfig = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnBox = new System.Windows.Forms.Button();
            this.btnFloorLabel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnBorrowLog = new System.Windows.Forms.Button();
            this.panelLoading.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).BeginInit();
            this.pushPanel1.SuspendLayout();
            this.pushPanelItem1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoading
            // 
            this.panelLoading.Location = new System.Drawing.Point(238, 213);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLUser,
            this.toolStripStatusLabel1,
            this.tsslchangepwd,
            this.tSSLCopyRight});
            this.statusStrip1.Location = new System.Drawing.Point(3, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 24);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLUser
            // 
            this.tSSLUser.Name = "tSSLUser";
            this.tSSLUser.Size = new System.Drawing.Size(0, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(562, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslchangepwd
            // 
            this.tsslchangepwd.ForeColor = System.Drawing.Color.Blue;
            this.tsslchangepwd.IsLink = true;
            this.tsslchangepwd.Name = "tsslchangepwd";
            this.tsslchangepwd.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tsslchangepwd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsslchangepwd.Size = new System.Drawing.Size(71, 19);
            this.tsslchangepwd.Text = "修改密码";
            this.tsslchangepwd.Click += new System.EventHandler(this.tsslchangepwd_Click);
            // 
            // tSSLCopyRight
            // 
            this.tSSLCopyRight.Name = "tSSLCopyRight";
            this.tSSLCopyRight.Size = new System.Drawing.Size(169, 19);
            this.tSSLCopyRight.Text = "北京乾坤科美科技有限公司 ";
            this.tSSLCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "node_normal.png");
            this.imageList1.Images.SetKeyName(1, "node_hover.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(153, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 612);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.pushPanel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(3, 30);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(150, 612);
            this.panelLeft.TabIndex = 12;
            // 
            // pushPanel1
            // 
            this.pushPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pushPanel1.Items.AddRange(new UILibrary.PushPanel.PushPanelItem[] {
            this.pushPanelItem1});
            this.pushPanel1.Location = new System.Drawing.Point(0, 0);
            this.pushPanel1.Name = "pushPanel1";
            this.pushPanel1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanel1.Size = new System.Drawing.Size(150, 612);
            this.pushPanel1.TabIndex = 6;
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.pushPanelItem1.Controls.Add(this.btnBorrowLog);
            this.pushPanelItem1.Controls.Add(this.btnReturn);
            this.pushPanelItem1.Controls.Add(this.btnBorrow);
            this.pushPanelItem1.Controls.Add(this.btnLabelConfig);
            this.pushPanelItem1.Controls.Add(this.btnUser);
            this.pushPanelItem1.Controls.Add(this.btnBox);
            this.pushPanelItem1.Controls.Add(this.btnFloorLabel);
            this.pushPanelItem1.Controls.Add(this.btnSearch);
            this.pushPanelItem1.Controls.Add(this.btnExport);
            this.pushPanelItem1.Name = "pushPanelItem1";
            this.pushPanelItem1.Padding = new System.Windows.Forms.Padding(20);
            this.pushPanelItem1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem1.Text = "菜单";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(15, 426);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(117, 46);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "归还操作";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(15, 361);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(117, 46);
            this.btnBorrow.TabIndex = 6;
            this.btnBorrow.Text = "借阅操作";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnLabelConfig
            // 
            this.btnLabelConfig.Location = new System.Drawing.Point(17, 297);
            this.btnLabelConfig.Name = "btnLabelConfig";
            this.btnLabelConfig.Size = new System.Drawing.Size(117, 46);
            this.btnLabelConfig.TabIndex = 5;
            this.btnLabelConfig.Text = "档案归盒";
            this.btnLabelConfig.UseVisualStyleBackColor = true;
            this.btnLabelConfig.Click += new System.EventHandler(this.btnLabelConfig_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(17, 553);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(117, 46);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "人员管理";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnBox
            // 
            this.btnBox.Location = new System.Drawing.Point(17, 234);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(117, 46);
            this.btnBox.TabIndex = 3;
            this.btnBox.Text = "档案盒标签注册";
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnFloorLabel
            // 
            this.btnFloorLabel.Location = new System.Drawing.Point(17, 171);
            this.btnFloorLabel.Name = "btnFloorLabel";
            this.btnFloorLabel.Size = new System.Drawing.Size(117, 46);
            this.btnFloorLabel.TabIndex = 2;
            this.btnFloorLabel.Text = "层架标签注册";
            this.btnFloorLabel.UseVisualStyleBackColor = true;
            this.btnFloorLabel.Click += new System.EventHandler(this.btnFloorLabel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 107);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 46);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "检索查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(17, 42);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 46);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "导入档案数据";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBorrowLog
            // 
            this.btnBorrowLog.Location = new System.Drawing.Point(15, 491);
            this.btnBorrowLog.Name = "btnBorrowLog";
            this.btnBorrowLog.Size = new System.Drawing.Size(117, 46);
            this.btnBorrowLog.TabIndex = 8;
            this.btnBorrowLog.Text = "借阅查询";
            this.btnBorrowLog.UseVisualStyleBackColor = true;
            this.btnBorrowLog.Click += new System.EventHandler(this.btnBorrowLog_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 669);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Radius = 8;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.Text = "档案管理系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.panelLeft, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.panelLoading.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).EndInit();
            this.pushPanel1.ResumeLayout(false);
            this.pushPanelItem1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLUser;
        private System.Windows.Forms.ToolStripStatusLabel tSSLCopyRight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelLeft;
        private UILibrary.PushPanel.PushPanel pushPanel1;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Button btnFloorLabel;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnLabelConfig;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslchangepwd;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrowLog;
    }
}

