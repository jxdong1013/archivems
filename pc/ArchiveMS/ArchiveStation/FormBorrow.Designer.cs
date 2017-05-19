namespace ArchiveStation
{
    partial class FormBorrow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelUserinfo = new System.Windows.Forms.Panel();
            this.btnreset = new UILibrary.SkinButtom();
            this.lblError = new System.Windows.Forms.Label();
            this.txtDepartment = new UILibrary.TCTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrow = new UILibrary.SkinButtom();
            this.txtName = new UILibrary.TCTextBox();
            this.txtIdcard = new UILibrary.TCTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTip = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelLoading.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelUserinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelUserinfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1228, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "借阅人信息";
            // 
            // panelUserinfo
            // 
            this.panelUserinfo.Controls.Add(this.btnreset);
            this.panelUserinfo.Controls.Add(this.lblError);
            this.panelUserinfo.Controls.Add(this.txtDepartment);
            this.panelUserinfo.Controls.Add(this.label1);
            this.panelUserinfo.Controls.Add(this.btnBorrow);
            this.panelUserinfo.Controls.Add(this.txtName);
            this.panelUserinfo.Controls.Add(this.txtIdcard);
            this.panelUserinfo.Controls.Add(this.label3);
            this.panelUserinfo.Controls.Add(this.label2);
            this.panelUserinfo.Location = new System.Drawing.Point(6, 18);
            this.panelUserinfo.Name = "panelUserinfo";
            this.panelUserinfo.Size = new System.Drawing.Size(1196, 80);
            this.panelUserinfo.TabIndex = 16;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.Transparent;
            this.btnreset.ControlState = UILibrary.ControlState.Normal;
            this.btnreset.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnreset.DownBack = null;
            this.btnreset.Location = new System.Drawing.Point(771, 18);
            this.btnreset.MouseBack = null;
            this.btnreset.Name = "btnreset";
            this.btnreset.NormlBack = null;
            this.btnreset.Size = new System.Drawing.Size(81, 39);
            this.btnreset.TabIndex = 18;
            this.btnreset.Text = "重置";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(883, 31);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 12);
            this.lblError.TabIndex = 17;
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.Transparent;
            this.txtDepartment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartment.Location = new System.Drawing.Point(424, 29);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.txtDepartment.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDepartment.MouseHoverImage = null;
            this.txtDepartment.MouseNormalImage = null;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Padding = new System.Windows.Forms.Padding(5);
            this.txtDepartment.PasswordChar = '\0';
            this.txtDepartment.ReadOnly = false;
            this.txtDepartment.Size = new System.Drawing.Size(195, 28);
            this.txtDepartment.TabIndex = 16;
            this.txtDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDepartment.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDepartment.WaterText = "";
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "借阅人姓名：";
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrow.ControlState = UILibrary.ControlState.Normal;
            this.btnBorrow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBorrow.DownBack = null;
            this.btnBorrow.Location = new System.Drawing.Point(649, 18);
            this.btnBorrow.MouseBack = null;
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.NormlBack = null;
            this.btnBorrow.Size = new System.Drawing.Size(81, 39);
            this.btnBorrow.TabIndex = 15;
            this.btnBorrow.Text = "借阅";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Location = new System.Drawing.Point(14, 29);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtName.MouseHoverImage = null;
            this.txtName.MouseNormalImage = null;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtName.PasswordChar = '\0';
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(178, 28);
            this.txtName.TabIndex = 5;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtName.WaterText = "";
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtIdcard
            // 
            this.txtIdcard.BackColor = System.Drawing.Color.Transparent;
            this.txtIdcard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdcard.Location = new System.Drawing.Point(208, 29);
            this.txtIdcard.Margin = new System.Windows.Forms.Padding(0);
            this.txtIdcard.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtIdcard.MouseHoverImage = null;
            this.txtIdcard.MouseNormalImage = null;
            this.txtIdcard.Name = "txtIdcard";
            this.txtIdcard.Padding = new System.Windows.Forms.Padding(5);
            this.txtIdcard.PasswordChar = '\0';
            this.txtIdcard.ReadOnly = false;
            this.txtIdcard.Size = new System.Drawing.Size(195, 28);
            this.txtIdcard.TabIndex = 6;
            this.txtIdcard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdcard.WaterColor = System.Drawing.Color.DarkGray;
            this.txtIdcard.WaterText = "";
            this.txtIdcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdcard_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(422, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "所属部门：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(206, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "借阅人身份证：";
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
            this.lblCheck,
            this.id,
            this.title,
            this.number,
            this.idx,
            this.manager,
            this.boxnumber,
            this.statusname,
            this.status,
            this.rfid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1228, 393);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblCheck
            // 
            this.lblCheck.HeaderText = "操作";
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lblCheck.Width = 70;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "文件题目";
            this.title.Name = "title";
            this.title.Width = 200;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "档案编号";
            this.number.Name = "number";
            this.number.Width = 150;
            // 
            // idx
            // 
            this.idx.DataPropertyName = "idx";
            this.idx.HeaderText = "序号";
            this.idx.Name = "idx";
            // 
            // manager
            // 
            this.manager.DataPropertyName = "manager";
            this.manager.HeaderText = "负责人";
            this.manager.Name = "manager";
            this.manager.Width = 120;
            // 
            // boxnumber
            // 
            this.boxnumber.DataPropertyName = "boxnumber";
            this.boxnumber.HeaderText = "盒编号";
            this.boxnumber.MinimumWidth = 100;
            this.boxnumber.Name = "boxnumber";
            this.boxnumber.Width = 150;
            // 
            // statusname
            // 
            this.statusname.DataPropertyName = "statusname";
            this.statusname.HeaderText = "状态";
            this.statusname.MinimumWidth = 80;
            this.statusname.Name = "statusname";
            this.statusname.Width = 80;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.Visible = false;
            // 
            // rfid
            // 
            this.rfid.DataPropertyName = "rfid";
            this.rfid.HeaderText = "rfid";
            this.rfid.Name = "rfid";
            this.rfid.Visible = false;
            // 
            // panelTip
            // 
            this.panelTip.Controls.Add(this.label4);
            this.panelTip.Location = new System.Drawing.Point(174, 176);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(367, 80);
            this.panelTip.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(26, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "请将档案盒放在感应器";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // FormBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 547);
            this.Controls.Add(this.panelTip);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormBorrow";
            this.Text = "借阅操作";
            this.Activated += new System.EventHandler(this.FormBorrow_Activated);
            this.Deactivate += new System.EventHandler(this.FormBorrow_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBorrow_FormClosing);
            this.Shown += new System.EventHandler(this.FormBorrow_Shown);
            this.SizeChanged += new System.EventHandler(this.FormBorrow_SizeChanged);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.panelTip, 0);
            this.panelLoading.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelUserinfo.ResumeLayout(false);
            this.panelUserinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTip.ResumeLayout(false);
            this.panelTip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UILibrary.TCTextBox txtIdcard;
        private UILibrary.TCTextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UILibrary.SkinButtom btnBorrow;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelUserinfo;
        private UILibrary.TCTextBox txtDepartment;
        private System.Windows.Forms.Label lblError;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lblCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
        private UILibrary.SkinButtom btnreset;
    }
}