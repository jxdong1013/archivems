namespace ArchiveStation
{
    partial class FormBorrowBackList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKey = new UILibrary.TCTextBox();
            this.btnQuery = new UILibrary.SkinButtom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pageControl1 = new ArchiveStation.PageControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.boxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 100);
            this.panel1.TabIndex = 11;
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.Transparent;
            this.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKey.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(127, 36);
            this.txtKey.Margin = new System.Windows.Forms.Padding(0);
            this.txtKey.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtKey.MouseHoverImage = null;
            this.txtKey.MouseNormalImage = null;
            this.txtKey.Name = "txtKey";
            this.txtKey.Padding = new System.Windows.Forms.Padding(5);
            this.txtKey.PasswordChar = '\0';
            this.txtKey.ReadOnly = false;
            this.txtKey.Size = new System.Drawing.Size(478, 32);
            this.txtKey.TabIndex = 16;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKey.WaterColor = System.Drawing.Color.DarkGray;
            this.txtKey.WaterText = "请输入查询条件";
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ControlState = UILibrary.ControlState.Normal;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQuery.DownBack = null;
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(649, 35);
            this.btnQuery.MouseBack = null;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.NormlBack = null;
            this.btnQuery.Size = new System.Drawing.Size(81, 34);
            this.btnQuery.TabIndex = 15;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pageControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 55);
            this.panel2.TabIndex = 12;
            // 
            // pageControl1
            // 
            this.pageControl1.Location = new System.Drawing.Point(127, 3);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.Size = new System.Drawing.Size(559, 39);
            this.pageControl1.TabIndex = 7;
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
            this.boxid,
            this.title,
            this.number,
            this.manager,
            this.boxnumber,
            this.borrowname,
            this.idcard,
            this.department,
            this.createtime,
            this.statusname,
            this.position,
            this.boxname,
            this.rfid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1003, 330);
            this.dataGridView1.TabIndex = 13;
            // 
            // boxid
            // 
            this.boxid.DataPropertyName = "boxid";
            this.boxid.HeaderText = "boxid";
            this.boxid.Name = "boxid";
            this.boxid.Visible = false;
            this.boxid.Width = 80;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "文件题目";
            this.title.Name = "title";
            this.title.Width = 180;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "文件编号";
            this.number.Name = "number";
            this.number.Width = 120;
            // 
            // manager
            // 
            this.manager.DataPropertyName = "manager";
            this.manager.HeaderText = "负责人";
            this.manager.Name = "manager";
            // 
            // boxnumber
            // 
            this.boxnumber.DataPropertyName = "boxnumber";
            this.boxnumber.HeaderText = "盒编号";
            this.boxnumber.Name = "boxnumber";
            this.boxnumber.Width = 150;
            // 
            // borrowname
            // 
            this.borrowname.DataPropertyName = "borrowname";
            this.borrowname.HeaderText = "借阅人";
            this.borrowname.MinimumWidth = 80;
            this.borrowname.Name = "borrowname";
            // 
            // idcard
            // 
            this.idcard.DataPropertyName = "idcard";
            this.idcard.HeaderText = "身份证";
            this.idcard.Name = "idcard";
            this.idcard.Width = 130;
            // 
            // department
            // 
            this.department.DataPropertyName = "department";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.department.DefaultCellStyle = dataGridViewCellStyle3;
            this.department.HeaderText = "部门";
            this.department.Name = "department";
            // 
            // createtime
            // 
            this.createtime.DataPropertyName = "createtime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.createtime.DefaultCellStyle = dataGridViewCellStyle4;
            this.createtime.HeaderText = "时间";
            this.createtime.Name = "createtime";
            this.createtime.Width = 120;
            // 
            // statusname
            // 
            this.statusname.DataPropertyName = "statusname";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.statusname.DefaultCellStyle = dataGridViewCellStyle5;
            this.statusname.HeaderText = "状态";
            this.statusname.Name = "statusname";
            this.statusname.Width = 80;
            // 
            // position
            // 
            this.position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "位置";
            this.position.Name = "position";
            // 
            // boxname
            // 
            this.boxname.DataPropertyName = "boxname";
            this.boxname.HeaderText = "盒名称";
            this.boxname.Name = "boxname";
            this.boxname.Visible = false;
            this.boxname.Width = 130;
            // 
            // rfid
            // 
            this.rfid.DataPropertyName = "rfid";
            this.rfid.HeaderText = "rfid";
            this.rfid.Name = "rfid";
            this.rfid.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormBorrowBackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormBorrowBackList";
            this.Text = "借阅查询";
            this.Shown += new System.EventHandler(this.FormBorrowBackList_Shown);
            this.SizeChanged += new System.EventHandler(this.FormBorrowBackList_SizeChanged);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PageControl pageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UILibrary.SkinButtom btnQuery;
        private UILibrary.TCTextBox txtKey;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxid;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowname;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn createtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxname;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
    }
}