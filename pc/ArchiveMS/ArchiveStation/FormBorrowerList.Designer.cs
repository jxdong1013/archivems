namespace ArchiveStation
{
    partial class FormBorrowerList
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
            this.txtKey = new UILibrary.SkinTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pageControl1 = new ArchiveStation.PageControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.borrowerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 66);
            this.panel1.TabIndex = 12;
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
            this.txtKey.WaterText = "请输入名称，省份证，部门 进行查询";
            this.txtKey.WordWrap = true;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.pageControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(1, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 61);
            this.panel2.TabIndex = 15;
            // 
            // pageControl1
            // 
            this.pageControl1.Location = new System.Drawing.Point(95, 8);
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
            this.borrowerid,
            this.idcard,
            this.name,
            this.department,
            this.lblEdit,
            this.lblDelete,
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(1, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(987, 421);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // borrowerid
            // 
            this.borrowerid.DataPropertyName = "borrowerid";
            this.borrowerid.HeaderText = "borrowerid";
            this.borrowerid.Name = "borrowerid";
            this.borrowerid.ReadOnly = true;
            this.borrowerid.Visible = false;
            // 
            // idcard
            // 
            this.idcard.DataPropertyName = "idcard";
            this.idcard.HeaderText = "身份证";
            this.idcard.Name = "idcard";
            this.idcard.ReadOnly = true;
            this.idcard.Width = 180;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 220;
            // 
            // department
            // 
            this.department.DataPropertyName = "department";
            this.department.HeaderText = "部门";
            this.department.MinimumWidth = 100;
            this.department.Name = "department";
            this.department.ReadOnly = true;
            this.department.Width = 250;
            // 
            // lblEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lblEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.lblEdit.HeaderText = "操作";
            this.lblEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.ReadOnly = true;
            this.lblEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lblEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblEdit.Text = "编辑";
            this.lblEdit.ToolTipText = "编辑";
            this.lblEdit.UseColumnTextForLinkValue = true;
            this.lblEdit.Visible = false;
            this.lblEdit.Width = 80;
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
            this.lblDelete.Visible = false;
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
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormBorrowerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderWidth = 1;
            this.ClientSize = new System.Drawing.Size(989, 518);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormBorrowerList";
            this.Radius = 6;
            this.Text = "借阅人信息列表";
            this.Shown += new System.EventHandler(this.FormBorrowerList_Shown);
            this.SizeChanged += new System.EventHandler(this.FormBorrowerList_SizeChanged);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UILibrary.SkinTextBox txtKey;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel2;
        private PageControl pageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewLinkColumn lblEdit;
        private System.Windows.Forms.DataGridViewLinkColumn lblDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}