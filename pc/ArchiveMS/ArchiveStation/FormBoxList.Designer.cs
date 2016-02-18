namespace ArchiveStation
{
    partial class FormBoxList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtKey = new UILibrary.SkinTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.pageControl1 = new ArchiveStation.PageControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSeeArchive = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 66);
            this.panel1.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(643, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 28);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "新增盒标签";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.txtKey.Location = new System.Drawing.Point(142, 21);
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
            this.txtKey.TabIndex = 5;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKey.WaterColor = System.Drawing.Color.DarkGray;
            this.txtKey.WaterText = "请输入名称，标签";
            this.txtKey.WordWrap = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(550, 21);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 28);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "检索";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pageControl1
            // 
            this.pageControl1.Location = new System.Drawing.Point(95, 3);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.Size = new System.Drawing.Size(598, 37);
            this.pageControl1.TabIndex = 12;
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.rfid,
            this.number,
            this.lblSeeArchive,
            this.lblDelete,
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(902, 358);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 180;
            // 
            // rfid
            // 
            this.rfid.DataPropertyName = "rfid";
            this.rfid.HeaderText = "标签";
            this.rfid.Name = "rfid";
            this.rfid.ReadOnly = true;
            this.rfid.Width = 220;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "编号";
            this.number.MinimumWidth = 100;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 250;
            // 
            // lblSeeArchive
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lblSeeArchive.DefaultCellStyle = dataGridViewCellStyle3;
            this.lblSeeArchive.HeaderText = "操作";
            this.lblSeeArchive.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblSeeArchive.Name = "lblSeeArchive";
            this.lblSeeArchive.ReadOnly = true;
            this.lblSeeArchive.Text = "查看档案";
            this.lblSeeArchive.ToolTipText = "查看档案";
            this.lblSeeArchive.UseColumnTextForLinkValue = true;
            this.lblSeeArchive.Width = 70;
            // 
            // lblDelete
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lblDelete.DefaultCellStyle = dataGridViewCellStyle4;
            this.lblDelete.HeaderText = "操作";
            this.lblDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.ReadOnly = true;
            this.lblDelete.Text = "删除";
            this.lblDelete.ToolTipText = "删除";
            this.lblDelete.UseColumnTextForLinkValue = true;
            this.lblDelete.Width = 70;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.pageControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 454);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 61);
            this.panel2.TabIndex = 14;
            // 
            // FormBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBoxList";
            this.Text = "档案盒标签";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormBoxList_Shown);
            this.SizeChanged += new System.EventHandler(this.FormBoxList_SizeChanged);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private UILibrary.SkinTextBox txtKey;
        private System.Windows.Forms.Button btnGo;
        private PageControl pageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewLinkColumn lblSeeArchive;
        private System.Windows.Forms.DataGridViewLinkColumn lblDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel2;
    }
}