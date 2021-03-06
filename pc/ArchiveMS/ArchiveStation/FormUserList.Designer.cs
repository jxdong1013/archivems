﻿namespace ArchiveStation
{
    partial class FormUserList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.txtKey = new UILibrary.SkinTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pageControl1 = new ArchiveStation.PageControl();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roletype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbledit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblResetPwd = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAdd);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 53);
            this.panel1.TabIndex = 11;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(553, 19);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(65, 12);
            this.lblAdd.TabIndex = 6;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "添加新用户";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            this.lblAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblAdd_MouseClick);
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
            this.txtKey.Location = new System.Drawing.Point(55, 11);
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
            this.txtKey.WaterText = "请输入用户名，姓名，联系电话等查询条件";
            this.txtKey.WordWrap = true;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(463, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 28);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "检索";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userid,
            this.username,
            this.realname,
            this.sex,
            this.phone,
            this.enable,
            this.roletype,
            this.lbledit,
            this.lblResetPwd,
            this.lblDelete,
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(784, 377);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pageControl1
            // 
            this.pageControl1.Location = new System.Drawing.Point(117, 3);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.Size = new System.Drawing.Size(641, 46);
            this.pageControl1.TabIndex = 14;
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
            this.panel2.Location = new System.Drawing.Point(3, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 55);
            this.panel2.TabIndex = 15;
            // 
            // userid
            // 
            this.userid.DataPropertyName = "userid";
            this.userid.HeaderText = "userid";
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            this.userid.Visible = false;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "用户名";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // realname
            // 
            this.realname.DataPropertyName = "realname";
            this.realname.HeaderText = "真实姓名";
            this.realname.Name = "realname";
            this.realname.ReadOnly = true;
            this.realname.Width = 150;
            // 
            // sex
            // 
            this.sex.DataPropertyName = "sex";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sex.DefaultCellStyle = dataGridViewCellStyle14;
            this.sex.HeaderText = "性别";
            this.sex.MinimumWidth = 70;
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 80;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "联系电话";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 180;
            // 
            // enable
            // 
            this.enable.DataPropertyName = "enable";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.enable.DefaultCellStyle = dataGridViewCellStyle15;
            this.enable.HeaderText = "状态";
            this.enable.Name = "enable";
            this.enable.ReadOnly = true;
            this.enable.Width = 80;
            // 
            // roletype
            // 
            this.roletype.DataPropertyName = "roletype";
            this.roletype.HeaderText = "用户类型";
            this.roletype.Name = "roletype";
            this.roletype.ReadOnly = true;
            this.roletype.Width = 80;
            // 
            // lbledit
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lbledit.DefaultCellStyle = dataGridViewCellStyle16;
            this.lbledit.HeaderText = "编辑";
            this.lbledit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbledit.Name = "lbledit";
            this.lbledit.ReadOnly = true;
            this.lbledit.Text = "编辑";
            this.lbledit.ToolTipText = "编辑";
            this.lbledit.UseColumnTextForLinkValue = true;
            this.lbledit.Width = 70;
            // 
            // lblResetPwd
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lblResetPwd.DefaultCellStyle = dataGridViewCellStyle17;
            this.lblResetPwd.HeaderText = "操作";
            this.lblResetPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblResetPwd.Name = "lblResetPwd";
            this.lblResetPwd.ReadOnly = true;
            this.lblResetPwd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lblResetPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lblResetPwd.Text = "重置密码";
            this.lblResetPwd.ToolTipText = "重置密码";
            this.lblResetPwd.UseColumnTextForLinkValue = true;
            this.lblResetPwd.Width = 80;
            // 
            // lblDelete
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lblDelete.DefaultCellStyle = dataGridViewCellStyle18;
            this.lblDelete.HeaderText = "删除";
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
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // FormUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormUserList";
            this.Text = "人员管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormUserList_Shown);
            this.SizeChanged += new System.EventHandler(this.FormUserList_SizeChanged);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UILibrary.SkinTextBox txtKey;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PageControl pageControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn realname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn roletype;
        private System.Windows.Forms.DataGridViewLinkColumn lbledit;
        private System.Windows.Forms.DataGridViewLinkColumn lblResetPwd;
        private System.Windows.Forms.DataGridViewLinkColumn lblDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}