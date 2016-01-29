namespace ArchiveStation
{
    partial class FormLabelConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbNoPosition = new System.Windows.Forms.CheckBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.txtKey = new UILibrary.SkinTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.pageControl1 = new ArchiveStation.PageControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ckbSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckbNoPosition);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 65);
            this.panel1.TabIndex = 11;
            // 
            // ckbNoPosition
            // 
            this.ckbNoPosition.AutoSize = true;
            this.ckbNoPosition.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ckbNoPosition.Location = new System.Drawing.Point(93, 44);
            this.ckbNoPosition.Name = "ckbNoPosition";
            this.ckbNoPosition.Size = new System.Drawing.Size(120, 16);
            this.ckbNoPosition.TabIndex = 5;
            this.ckbNoPosition.Text = "只显示未归盒数据";
            this.ckbNoPosition.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(568, 14);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 30);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "档案归盒";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // txtKey
            // 
            this.txtKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtKey.BackColor = System.Drawing.Color.Transparent;
            this.txtKey.Icon = null;
            this.txtKey.IconIsButton = false;
            this.txtKey.IsPasswordChat = '\0';
            this.txtKey.IsSystemPasswordChar = false;
            this.txtKey.LeftIcon = null;
            this.txtKey.Lines = new string[0];
            this.txtKey.Location = new System.Drawing.Point(55, 14);
            this.txtKey.Margin = new System.Windows.Forms.Padding(0);
            this.txtKey.MaxLength = 32767;
            this.txtKey.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtKey.MouseBack = null;
            this.txtKey.Multiline = false;
            this.txtKey.Name = "txtKey";
            this.txtKey.NormlBack = null;
            this.txtKey.Padding = new System.Windows.Forms.Padding(5);
            this.txtKey.ReadOnly = false;
            this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKey.Size = new System.Drawing.Size(404, 28);
            this.txtKey.TabIndex = 3;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKey.WaterColor = System.Drawing.Color.DarkGray;
            this.txtKey.WaterText = "请输入档案名称，负责人，编号";
            this.txtKey.WordWrap = true;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(476, 13);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 30);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "检索";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(50, 103);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(48, 16);
            this.ckbAll.TabIndex = 6;
            this.ckbAll.Text = "全选";
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbAll_CheckedChanged);
            // 
            // pageControl1
            // 
            this.pageControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageControl1.Location = new System.Drawing.Point(3, 469);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.Size = new System.Drawing.Size(764, 46);
            this.pageControl1.TabIndex = 13;
            this.pageControl1.onFirst += new System.EventHandler(this.pageControl1_onFirst);
            this.pageControl1.onPre += new System.EventHandler<ArchiveStation.PageEventArgs>(this.pageControl1_onPre);
            this.pageControl1.onNext += new System.EventHandler<ArchiveStation.PageEventArgs>(this.pageControl1_onNext);
            this.pageControl1.onLast += new System.EventHandler<ArchiveStation.PageEventArgs>(this.pageControl1_onLast);
            this.pageControl1.onGo += new System.EventHandler<ArchiveStation.PageEventArgs>(this.pageControl1_onGo);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckbSelect,
            this.idx,
            this.id,
            this.manager,
            this.title,
            this.pages,
            this.number,
            this.remark,
            this.position});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(764, 374);
            this.dataGridView1.TabIndex = 14;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // ckbSelect
            // 
            this.ckbSelect.Frozen = true;
            this.ckbSelect.HeaderText = "";
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ckbSelect.ToolTipText = "选择";
            this.ckbSelect.Width = 60;
            // 
            // idx
            // 
            this.idx.DataPropertyName = "idx";
            this.idx.HeaderText = "序号";
            this.idx.Name = "idx";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // manager
            // 
            this.manager.DataPropertyName = "manager";
            this.manager.HeaderText = "责任人";
            this.manager.Name = "manager";
            this.manager.Width = 150;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "文件题目";
            this.title.MinimumWidth = 100;
            this.title.Name = "title";
            this.title.Width = 250;
            // 
            // pages
            // 
            this.pages.DataPropertyName = "pages";
            this.pages.HeaderText = "页数";
            this.pages.Name = "pages";
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "编号";
            this.number.Name = "number";
            this.number.Width = 180;
            // 
            // remark
            // 
            this.remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.MinimumWidth = 80;
            this.remark.Name = "remark";
            // 
            // position
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.position.DefaultCellStyle = dataGridViewCellStyle3;
            this.position.HeaderText = "位置信息";
            this.position.Name = "position";
            this.position.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.position.ToolTipText = "位置信息";
            // 
            // FormLabelConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 518);
            this.Controls.Add(this.ckbAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pageControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FormLabelConfig";
            this.Radius = 10;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.Text = "档案归盒";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pageControl1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.ckbAll, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfig;
        private UILibrary.SkinTextBox txtKey;
        private System.Windows.Forms.Button btnGo;
        private PageControl pageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox ckbNoPosition;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ckbSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn pages;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
    }
}