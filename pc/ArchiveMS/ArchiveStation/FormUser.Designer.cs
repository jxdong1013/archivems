namespace ArchiveStation
{
    partial class FormUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError2 = new System.Windows.Forms.Label();
            this.lblError1 = new System.Windows.Forms.Label();
            this.rdbWoman = new System.Windows.Forms.RadioButton();
            this.rdbMan = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbDisable = new System.Windows.Forms.CheckBox();
            this.btnCancel = new UILibrary.SkinButtom();
            this.btnOk = new UILibrary.SkinButtom();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new UILibrary.SkinTextBox();
            this.txtRealName = new UILibrary.SkinTextBox();
            this.txtName = new UILibrary.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoading
            // 
            this.panelLoading.Location = new System.Drawing.Point(27, 369);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblError2);
            this.panel1.Controls.Add(this.lblError1);
            this.panel1.Controls.Add(this.rdbWoman);
            this.panel1.Controls.Add(this.rdbMan);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ckbDisable);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.txtRealName);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 329);
            this.panel1.TabIndex = 27;
            // 
            // lblError2
            // 
            this.lblError2.AutoSize = true;
            this.lblError2.ForeColor = System.Drawing.Color.Red;
            this.lblError2.Location = new System.Drawing.Point(82, 111);
            this.lblError2.Name = "lblError2";
            this.lblError2.Size = new System.Drawing.Size(0, 12);
            this.lblError2.TabIndex = 41;
            // 
            // lblError1
            // 
            this.lblError1.AutoSize = true;
            this.lblError1.ForeColor = System.Drawing.Color.Red;
            this.lblError1.Location = new System.Drawing.Point(85, 59);
            this.lblError1.Name = "lblError1";
            this.lblError1.Size = new System.Drawing.Size(0, 12);
            this.lblError1.TabIndex = 40;
            // 
            // rdbWoman
            // 
            this.rdbWoman.AutoSize = true;
            this.rdbWoman.Location = new System.Drawing.Point(132, 131);
            this.rdbWoman.Name = "rdbWoman";
            this.rdbWoman.Size = new System.Drawing.Size(35, 16);
            this.rdbWoman.TabIndex = 39;
            this.rdbWoman.Text = "女";
            this.rdbWoman.UseVisualStyleBackColor = true;
            // 
            // rdbMan
            // 
            this.rdbMan.AutoSize = true;
            this.rdbMan.Checked = true;
            this.rdbMan.Location = new System.Drawing.Point(79, 131);
            this.rdbMan.Name = "rdbMan";
            this.rdbMan.Size = new System.Drawing.Size(35, 16);
            this.rdbMan.TabIndex = 38;
            this.rdbMan.TabStop = true;
            this.rdbMan.Text = "男";
            this.rdbMan.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(13, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "初始密码：123456";
            // 
            // ckbDisable
            // 
            this.ckbDisable.AutoSize = true;
            this.ckbDisable.Location = new System.Drawing.Point(235, 216);
            this.ckbDisable.Name = "ckbDisable";
            this.ckbDisable.Size = new System.Drawing.Size(48, 16);
            this.ckbDisable.TabIndex = 36;
            this.ckbDisable.Text = "禁用";
            this.ckbDisable.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(175, 251);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(77, 251);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "联系电话：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "真实姓名：";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.Icon = null;
            this.txtPhone.IconIsButton = false;
            this.txtPhone.IsPasswordChat = '\0';
            this.txtPhone.IsSystemPasswordChar = false;
            this.txtPhone.LeftIcon = null;
            this.txtPhone.Lines = new string[0];
            this.txtPhone.Location = new System.Drawing.Point(79, 169);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(0);
            this.txtPhone.MaxLength = 32767;
            this.txtPhone.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPhone.MouseBack = null;
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.NormlBack = null;
            this.txtPhone.Padding = new System.Windows.Forms.Padding(5);
            this.txtPhone.ReadOnly = false;
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhone.Size = new System.Drawing.Size(204, 28);
            this.txtPhone.TabIndex = 30;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPhone.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPhone.WaterText = "请输入联系电话";
            this.txtPhone.WordWrap = true;
            // 
            // txtRealName
            // 
            this.txtRealName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRealName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRealName.BackColor = System.Drawing.Color.Transparent;
            this.txtRealName.Icon = null;
            this.txtRealName.IconIsButton = false;
            this.txtRealName.IsPasswordChat = '\0';
            this.txtRealName.IsSystemPasswordChar = false;
            this.txtRealName.LeftIcon = null;
            this.txtRealName.Lines = new string[0];
            this.txtRealName.Location = new System.Drawing.Point(79, 79);
            this.txtRealName.Margin = new System.Windows.Forms.Padding(0);
            this.txtRealName.MaxLength = 32767;
            this.txtRealName.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtRealName.MouseBack = null;
            this.txtRealName.Multiline = false;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.NormlBack = null;
            this.txtRealName.Padding = new System.Windows.Forms.Padding(5);
            this.txtRealName.ReadOnly = false;
            this.txtRealName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRealName.Size = new System.Drawing.Size(204, 28);
            this.txtRealName.TabIndex = 29;
            this.txtRealName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRealName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtRealName.WaterText = "请输入真实名称";
            this.txtRealName.WordWrap = true;
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Icon = null;
            this.txtName.IconIsButton = false;
            this.txtName.IsPasswordChat = '\0';
            this.txtName.IsSystemPasswordChar = false;
            this.txtName.LeftIcon = null;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(80, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.MaxLength = 32767;
            this.txtName.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtName.MouseBack = null;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.NormlBack = null;
            this.txtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtName.ReadOnly = false;
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.Size = new System.Drawing.Size(204, 28);
            this.txtName.TabIndex = 28;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtName.WaterText = "请输入用户名";
            this.txtName.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "用户名：";
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 362);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUser";
            this.Radius = 10;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.Text = "";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblError2;
        private System.Windows.Forms.Label lblError1;
        private System.Windows.Forms.RadioButton rdbWoman;
        private System.Windows.Forms.RadioButton rdbMan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbDisable;
        private UILibrary.SkinButtom btnCancel;
        private UILibrary.SkinButtom btnOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private UILibrary.SkinTextBox txtPhone;
        private UILibrary.SkinTextBox txtRealName;
        private UILibrary.SkinTextBox txtName;
        private System.Windows.Forms.Label label2;

    }
}