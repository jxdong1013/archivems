namespace ArchiveStation
{
    partial class FormChangePwd
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNewPwd2 = new UILibrary.SkinTextBox();
            this.txtNewPwd = new UILibrary.SkinTextBox();
            this.txtOldPwd = new UILibrary.SkinTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtNewPwd2);
            this.panel1.Controls.Add(this.txtNewPwd);
            this.panel1.Controls.Add(this.txtOldPwd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 210);
            this.panel1.TabIndex = 11;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(95, 148);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(121, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNewPwd2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNewPwd2.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPwd2.Icon = null;
            this.txtNewPwd2.IconIsButton = false;
            this.txtNewPwd2.IsPasswordChat = '●';
            this.txtNewPwd2.IsSystemPasswordChar = true;
            this.txtNewPwd2.LeftIcon = null;
            this.txtNewPwd2.Lines = new string[0];
            this.txtNewPwd2.Location = new System.Drawing.Point(95, 109);
            this.txtNewPwd2.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPwd2.MaxLength = 32767;
            this.txtNewPwd2.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtNewPwd2.MouseBack = null;
            this.txtNewPwd2.Multiline = false;
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.NormlBack = null;
            this.txtNewPwd2.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPwd2.ReadOnly = false;
            this.txtNewPwd2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewPwd2.Size = new System.Drawing.Size(186, 28);
            this.txtNewPwd2.TabIndex = 8;
            this.txtNewPwd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPwd2.WaterColor = System.Drawing.Color.DarkGray;
            this.txtNewPwd2.WaterText = "";
            this.txtNewPwd2.WordWrap = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNewPwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNewPwd.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPwd.Icon = null;
            this.txtNewPwd.IconIsButton = false;
            this.txtNewPwd.IsPasswordChat = '●';
            this.txtNewPwd.IsSystemPasswordChar = true;
            this.txtNewPwd.LeftIcon = null;
            this.txtNewPwd.Lines = new string[0];
            this.txtNewPwd.Location = new System.Drawing.Point(96, 68);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPwd.MaxLength = 32767;
            this.txtNewPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtNewPwd.MouseBack = null;
            this.txtNewPwd.Multiline = false;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.NormlBack = null;
            this.txtNewPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPwd.ReadOnly = false;
            this.txtNewPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewPwd.Size = new System.Drawing.Size(186, 28);
            this.txtNewPwd.TabIndex = 7;
            this.txtNewPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPwd.WaterColor = System.Drawing.Color.DarkGray;
            this.txtNewPwd.WaterText = "";
            this.txtNewPwd.WordWrap = true;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtOldPwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtOldPwd.BackColor = System.Drawing.Color.Transparent;
            this.txtOldPwd.Icon = null;
            this.txtOldPwd.IconIsButton = false;
            this.txtOldPwd.IsPasswordChat = '●';
            this.txtOldPwd.IsSystemPasswordChar = true;
            this.txtOldPwd.LeftIcon = null;
            this.txtOldPwd.Lines = new string[0];
            this.txtOldPwd.Location = new System.Drawing.Point(96, 26);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtOldPwd.MaxLength = 32767;
            this.txtOldPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtOldPwd.MouseBack = null;
            this.txtOldPwd.Multiline = false;
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.NormlBack = null;
            this.txtOldPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtOldPwd.ReadOnly = false;
            this.txtOldPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOldPwd.Size = new System.Drawing.Size(186, 28);
            this.txtOldPwd.TabIndex = 6;
            this.txtOldPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOldPwd.WaterColor = System.Drawing.Color.DarkGray;
            this.txtOldPwd.WaterText = "";
            this.txtOldPwd.WordWrap = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码：";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FormChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 243);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangePwd";
            this.Text = "修改密码";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOk;
        private UILibrary.SkinTextBox txtNewPwd2;
        private UILibrary.SkinTextBox txtNewPwd;
        private UILibrary.SkinTextBox txtOldPwd;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}