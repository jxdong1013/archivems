namespace ArchiveStation
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
            this.tSSLCopyRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pushPanel1 = new UILibrary.PushPanel.PushPanel();
            this.pushPanelItem1 = new UILibrary.PushPanel.PushPanelItem();
            this.btnLabelConfig = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnBox = new System.Windows.Forms.Button();
            this.btnFloorLabel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            this.tSSLCopyRight});
            this.statusStrip1.Location = new System.Drawing.Point(3, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLUser
            // 
            this.tSSLUser.Name = "tSSLUser";
            this.tSSLUser.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSLCopyRight
            // 
            this.tSSLCopyRight.Name = "tSSLCopyRight";
            this.tSSLCopyRight.Size = new System.Drawing.Size(802, 17);
            this.tSSLCopyRight.Spring = true;
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
            this.splitter1.Size = new System.Drawing.Size(3, 495);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.pushPanel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(3, 30);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(150, 495);
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
            this.pushPanel1.Size = new System.Drawing.Size(150, 495);
            this.pushPanel1.TabIndex = 6;
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
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
            // btnLabelConfig
            // 
            this.btnLabelConfig.Location = new System.Drawing.Point(17, 322);
            this.btnLabelConfig.Name = "btnLabelConfig";
            this.btnLabelConfig.Size = new System.Drawing.Size(117, 46);
            this.btnLabelConfig.TabIndex = 5;
            this.btnLabelConfig.Text = "档案归盒";
            this.btnLabelConfig.UseVisualStyleBackColor = true;
            this.btnLabelConfig.Click += new System.EventHandler(this.btnLabelConfig_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(17, 391);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(117, 46);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "人员管理";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnBox
            // 
            this.btnBox.Location = new System.Drawing.Point(17, 253);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(117, 46);
            this.btnBox.TabIndex = 3;
            this.btnBox.Text = "档案盒标签注册";
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnFloorLabel
            // 
            this.btnFloorLabel.Location = new System.Drawing.Point(17, 184);
            this.btnFloorLabel.Name = "btnFloorLabel";
            this.btnFloorLabel.Size = new System.Drawing.Size(117, 46);
            this.btnFloorLabel.TabIndex = 2;
            this.btnFloorLabel.Text = "层架标签注册";
            this.btnFloorLabel.UseVisualStyleBackColor = true;
            this.btnFloorLabel.Click += new System.EventHandler(this.btnFloorLabel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 46);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "检索查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(17, 46);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 46);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "导入档案数据";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 550);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.statusStrip1);
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
    }
}

