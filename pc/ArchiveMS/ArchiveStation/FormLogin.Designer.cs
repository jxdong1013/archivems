namespace ArchiveStation
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new UILibrary.SkinButtom();
            this.btnCancel = new UILibrary.SkinButtom();
            this.txtPassword = new UILibrary.SkinTextBox();
            this.txtUserName = new UILibrary.SkinTextBox();
            this.tcCheckBox1 = new UILibrary.TCCheckBox();
            this.lblTipUser = new System.Windows.Forms.Label();
            this.lblTipPwd = new System.Windows.Forms.Label();
            this.lblTipInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTipDBPassword = new System.Windows.Forms.Label();
            this.lblTipDBUserName = new System.Windows.Forms.Label();
            this.lblTipDBPort = new System.Windows.Forms.Label();
            this.lblTipDBIP = new System.Windows.Forms.Label();
            this.btnSet = new UILibrary.SkinButtom();
            this.btnSetCancel = new UILibrary.SkinButtom();
            this.txtIP = new UILibrary.SkinTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(103, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "密  码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(103, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名：";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(111, 172);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(81, 34);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(251, 172);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(81, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Icon = null;
            this.txtPassword.IconIsButton = false;
            this.txtPassword.IsPasswordChat = '*';
            this.txtPassword.IsSystemPasswordChar = false;
            this.txtPassword.LeftIcon = null;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(171, 74);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPassword.MouseBack = null;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NormlBack = null;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.Size = new System.Drawing.Size(185, 28);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPassword.WaterText = "请输入密码";
            this.txtPassword.WordWrap = true;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.Icon = null;
            this.txtUserName.IconIsButton = false;
            this.txtUserName.IsPasswordChat = '\0';
            this.txtUserName.IsSystemPasswordChar = false;
            this.txtUserName.LeftIcon = null;
            this.txtUserName.Lines = new string[0];
            this.txtUserName.Location = new System.Drawing.Point(171, 20);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserName.MaxLength = 32767;
            this.txtUserName.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtUserName.MouseBack = null;
            this.txtUserName.Multiline = false;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.NormlBack = null;
            this.txtUserName.Padding = new System.Windows.Forms.Padding(5);
            this.txtUserName.ReadOnly = false;
            this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserName.Size = new System.Drawing.Size(185, 28);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtUserName.WaterText = "请输入用户名";
            this.txtUserName.WordWrap = true;
            // 
            // tcCheckBox1
            // 
            this.tcCheckBox1.AutoSize = true;
            this.tcCheckBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tcCheckBox1.BorderColor = System.Drawing.Color.DarkGray;
            this.tcCheckBox1.Checked = true;
            this.tcCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tcCheckBox1.ControlState = UILibrary.ControlState.Normal;
            this.tcCheckBox1.Font = new System.Drawing.Font("SimSun", 10F);
            this.tcCheckBox1.Location = new System.Drawing.Point(104, 133);
            this.tcCheckBox1.Name = "tcCheckBox1";
            this.tcCheckBox1.Size = new System.Drawing.Size(96, 18);
            this.tcCheckBox1.TabIndex = 3;
            this.tcCheckBox1.Text = "记住用户名";
            this.tcCheckBox1.UseVisualStyleBackColor = true;
            // 
            // lblTipUser
            // 
            this.lblTipUser.AutoSize = true;
            this.lblTipUser.ForeColor = System.Drawing.Color.Red;
            this.lblTipUser.Location = new System.Drawing.Point(175, 55);
            this.lblTipUser.Name = "lblTipUser";
            this.lblTipUser.Size = new System.Drawing.Size(0, 12);
            this.lblTipUser.TabIndex = 11;
            // 
            // lblTipPwd
            // 
            this.lblTipPwd.AutoSize = true;
            this.lblTipPwd.ForeColor = System.Drawing.Color.Red;
            this.lblTipPwd.Location = new System.Drawing.Point(174, 107);
            this.lblTipPwd.Name = "lblTipPwd";
            this.lblTipPwd.Size = new System.Drawing.Size(0, 12);
            this.lblTipPwd.TabIndex = 12;
            // 
            // lblTipInfo
            // 
            this.lblTipInfo.AutoSize = true;
            this.lblTipInfo.ForeColor = System.Drawing.Color.Red;
            this.lblTipInfo.Location = new System.Drawing.Point(200, 137);
            this.lblTipInfo.Name = "lblTipInfo";
            this.lblTipInfo.Size = new System.Drawing.Size(0, 12);
            this.lblTipInfo.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblTipInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTipPwd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTipUser);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.tcCheckBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 244);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTipDBPassword);
            this.panel2.Controls.Add(this.lblTipDBUserName);
            this.panel2.Controls.Add(this.lblTipDBPort);
            this.panel2.Controls.Add(this.lblTipDBIP);
            this.panel2.Controls.Add(this.btnSet);
            this.panel2.Controls.Add(this.btnSetCancel);
            this.panel2.Controls.Add(this.txtIP);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 247);
            this.panel2.TabIndex = 15;
            this.panel2.Visible = false;
            // 
            // lblTipDBPassword
            // 
            this.lblTipDBPassword.AutoSize = true;
            this.lblTipDBPassword.ForeColor = System.Drawing.Color.Red;
            this.lblTipDBPassword.Location = new System.Drawing.Point(302, 116);
            this.lblTipDBPassword.Name = "lblTipDBPassword";
            this.lblTipDBPassword.Size = new System.Drawing.Size(0, 12);
            this.lblTipDBPassword.TabIndex = 18;
            // 
            // lblTipDBUserName
            // 
            this.lblTipDBUserName.AutoSize = true;
            this.lblTipDBUserName.ForeColor = System.Drawing.Color.Red;
            this.lblTipDBUserName.Location = new System.Drawing.Point(123, 118);
            this.lblTipDBUserName.Name = "lblTipDBUserName";
            this.lblTipDBUserName.Size = new System.Drawing.Size(0, 12);
            this.lblTipDBUserName.TabIndex = 17;
            // 
            // lblTipDBPort
            // 
            this.lblTipDBPort.AutoSize = true;
            this.lblTipDBPort.ForeColor = System.Drawing.Color.Red;
            this.lblTipDBPort.Location = new System.Drawing.Point(302, 70);
            this.lblTipDBPort.Name = "lblTipDBPort";
            this.lblTipDBPort.Size = new System.Drawing.Size(0, 12);
            this.lblTipDBPort.TabIndex = 16;
            // 
            // lblTipDBIP
            // 
            this.lblTipDBIP.AutoSize = true;
            this.lblTipDBIP.ForeColor = System.Drawing.Color.Red;
            this.lblTipDBIP.Location = new System.Drawing.Point(124, 71);
            this.lblTipDBIP.Name = "lblTipDBIP";
            this.lblTipDBIP.Size = new System.Drawing.Size(0, 12);
            this.lblTipDBIP.TabIndex = 15;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ControlState = UILibrary.ControlState.Normal;
            this.btnSet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSet.DownBack = null;
            this.btnSet.Location = new System.Drawing.Point(111, 146);
            this.btnSet.MouseBack = null;
            this.btnSet.Name = "btnSet";
            this.btnSet.NormlBack = null;
            this.btnSet.Size = new System.Drawing.Size(81, 34);
            this.btnSet.TabIndex = 14;
            this.btnSet.Text = "确定";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnSetCancel
            // 
            this.btnSetCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSetCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnSetCancel.DownBack = null;
            this.btnSetCancel.Location = new System.Drawing.Point(251, 146);
            this.btnSetCancel.MouseBack = null;
            this.btnSetCancel.Name = "btnSetCancel";
            this.btnSetCancel.NormlBack = null;
            this.btnSetCancel.Size = new System.Drawing.Size(81, 34);
            this.btnSetCancel.TabIndex = 9;
            this.btnSetCancel.Text = "取消";
            this.btnSetCancel.UseVisualStyleBackColor = false;
            this.btnSetCancel.Click += new System.EventHandler(this.btnSetCancel_Click);
            // 
            // txtIP
            // 
            this.txtIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIP.BackColor = System.Drawing.Color.Transparent;
            this.txtIP.Icon = null;
            this.txtIP.IconIsButton = false;
            this.txtIP.IsPasswordChat = '\0';
            this.txtIP.IsSystemPasswordChar = false;
            this.txtIP.LeftIcon = null;
            this.txtIP.Lines = new string[0];
            this.txtIP.Location = new System.Drawing.Point(35, 52);
            this.txtIP.Margin = new System.Windows.Forms.Padding(0);
            this.txtIP.MaxLength = 32767;
            this.txtIP.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtIP.MouseBack = null;
            this.txtIP.Multiline = false;
            this.txtIP.Name = "txtIP";
            this.txtIP.NormlBack = null;
            this.txtIP.Padding = new System.Windows.Forms.Padding(5);
            this.txtIP.ReadOnly = false;
            this.txtIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIP.Size = new System.Drawing.Size(404, 28);
            this.txtIP.TabIndex = 2;
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIP.WaterColor = System.Drawing.Color.DarkGray;
            this.txtIP.WaterText = "";
            this.txtIP.WordWrap = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "服务器地址配置";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(480, 280);
            this.ControlBoxOffset = new System.Drawing.Point(2, 1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 280);
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "FormLogin";
            this.Radius = 8;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SysBottomVisibale = true;
            this.Text = "用户登录";
            this.SysBottomClick += new SkinForm.SkinPictureForm.SysBottomEventHandler(this.FormLogin_SysBottomClick);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UILibrary.SkinButtom btnOk;
        private UILibrary.SkinButtom btnCancel;
        private UILibrary.SkinTextBox txtPassword;
        private UILibrary.SkinTextBox txtUserName;
        private UILibrary.TCCheckBox tcCheckBox1;
        private System.Windows.Forms.Label lblTipUser;
        private System.Windows.Forms.Label lblTipPwd;
        private System.Windows.Forms.Label lblTipInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UILibrary.SkinButtom btnSet;
        private UILibrary.SkinButtom btnSetCancel;
        private UILibrary.SkinTextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTipDBIP;
        private System.Windows.Forms.Label lblTipDBPort;
        private System.Windows.Forms.Label lblTipDBPassword;
        private System.Windows.Forms.Label lblTipDBUserName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}