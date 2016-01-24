namespace ArchiveStation
{
    partial class FormEditArchive
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNo = new UILibrary.SkinTextBox();
            this.txtManager = new UILibrary.SkinTextBox();
            this.txtTitle = new UILibrary.SkinTextBox();
            this.txtPages = new UILibrary.SkinTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtnumber = new UILibrary.SkinTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoading
            // 
            this.panelLoading.Location = new System.Drawing.Point(57, 413);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "序号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "负责人：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "文件题目：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "页数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "编号：";
            // 
            // txtNo
            // 
            this.txtNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNo.BackColor = System.Drawing.Color.Transparent;
            this.txtNo.Icon = null;
            this.txtNo.IconIsButton = false;
            this.txtNo.IsPasswordChat = '\0';
            this.txtNo.IsSystemPasswordChar = false;
            this.txtNo.LeftIcon = null;
            this.txtNo.Lines = new string[0];
            this.txtNo.Location = new System.Drawing.Point(90, 11);
            this.txtNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtNo.MaxLength = 32767;
            this.txtNo.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtNo.MouseBack = null;
            this.txtNo.Multiline = false;
            this.txtNo.Name = "txtNo";
            this.txtNo.NormlBack = null;
            this.txtNo.Padding = new System.Windows.Forms.Padding(5);
            this.txtNo.ReadOnly = false;
            this.txtNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNo.Size = new System.Drawing.Size(204, 28);
            this.txtNo.TabIndex = 16;
            this.txtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNo.WaterColor = System.Drawing.Color.DarkGray;
            this.txtNo.WaterText = "请输入序号";
            this.txtNo.WordWrap = true;
            // 
            // txtManager
            // 
            this.txtManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtManager.BackColor = System.Drawing.Color.Transparent;
            this.txtManager.Icon = null;
            this.txtManager.IconIsButton = false;
            this.txtManager.IsPasswordChat = '\0';
            this.txtManager.IsSystemPasswordChar = false;
            this.txtManager.LeftIcon = null;
            this.txtManager.Lines = new string[0];
            this.txtManager.Location = new System.Drawing.Point(90, 63);
            this.txtManager.Margin = new System.Windows.Forms.Padding(0);
            this.txtManager.MaxLength = 32767;
            this.txtManager.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtManager.MouseBack = null;
            this.txtManager.Multiline = false;
            this.txtManager.Name = "txtManager";
            this.txtManager.NormlBack = null;
            this.txtManager.Padding = new System.Windows.Forms.Padding(5);
            this.txtManager.ReadOnly = false;
            this.txtManager.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtManager.Size = new System.Drawing.Size(204, 28);
            this.txtManager.TabIndex = 17;
            this.txtManager.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtManager.WaterColor = System.Drawing.Color.DarkGray;
            this.txtManager.WaterText = "请输入负责人";
            this.txtManager.WordWrap = true;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.Icon = null;
            this.txtTitle.IconIsButton = false;
            this.txtTitle.IsPasswordChat = '\0';
            this.txtTitle.IsSystemPasswordChar = false;
            this.txtTitle.LeftIcon = null;
            this.txtTitle.Lines = new string[0];
            this.txtTitle.Location = new System.Drawing.Point(90, 118);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(0);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtTitle.MouseBack = null;
            this.txtTitle.Multiline = false;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.NormlBack = null;
            this.txtTitle.Padding = new System.Windows.Forms.Padding(5);
            this.txtTitle.ReadOnly = false;
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTitle.Size = new System.Drawing.Size(204, 28);
            this.txtTitle.TabIndex = 18;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTitle.WaterColor = System.Drawing.Color.DarkGray;
            this.txtTitle.WaterText = "请输入文件题目";
            this.txtTitle.WordWrap = true;
            // 
            // txtPages
            // 
            this.txtPages.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPages.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPages.BackColor = System.Drawing.Color.Transparent;
            this.txtPages.Icon = null;
            this.txtPages.IconIsButton = false;
            this.txtPages.IsPasswordChat = '\0';
            this.txtPages.IsSystemPasswordChar = false;
            this.txtPages.LeftIcon = null;
            this.txtPages.Lines = new string[0];
            this.txtPages.Location = new System.Drawing.Point(90, 172);
            this.txtPages.Margin = new System.Windows.Forms.Padding(0);
            this.txtPages.MaxLength = 32767;
            this.txtPages.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPages.MouseBack = null;
            this.txtPages.Multiline = false;
            this.txtPages.Name = "txtPages";
            this.txtPages.NormlBack = null;
            this.txtPages.Padding = new System.Windows.Forms.Padding(5);
            this.txtPages.ReadOnly = false;
            this.txtPages.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPages.Size = new System.Drawing.Size(204, 28);
            this.txtPages.TabIndex = 19;
            this.txtPages.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPages.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPages.WaterText = "请输入页数";
            this.txtPages.WordWrap = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(105, 277);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // txtnumber
            // 
            this.txtnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtnumber.BackColor = System.Drawing.Color.Transparent;
            this.txtnumber.Icon = null;
            this.txtnumber.IconIsButton = false;
            this.txtnumber.IsPasswordChat = '\0';
            this.txtnumber.IsSystemPasswordChar = false;
            this.txtnumber.LeftIcon = null;
            this.txtnumber.Lines = new string[0];
            this.txtnumber.Location = new System.Drawing.Point(90, 227);
            this.txtnumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtnumber.MaxLength = 32767;
            this.txtnumber.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtnumber.MouseBack = null;
            this.txtnumber.Multiline = false;
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.NormlBack = null;
            this.txtnumber.Padding = new System.Windows.Forms.Padding(5);
            this.txtnumber.ReadOnly = false;
            this.txtnumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtnumber.Size = new System.Drawing.Size(204, 28);
            this.txtnumber.TabIndex = 21;
            this.txtnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtnumber.WaterColor = System.Drawing.Color.DarkGray;
            this.txtnumber.WaterText = "请输入编号";
            this.txtnumber.WordWrap = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtManager);
            this.panel1.Controls.Add(this.txtnumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPages);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 317);
            this.panel1.TabIndex = 22;
            // 
            // FormEditArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 350);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditArchive";
            this.Radius = 10;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.Text = "编辑资料";
            this.Controls.SetChildIndex(this.panelLoading, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panelLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private UILibrary.SkinTextBox txtNo;
        private UILibrary.SkinTextBox txtManager;
        private UILibrary.SkinTextBox txtTitle;
        private UILibrary.SkinTextBox txtPages;
        private System.Windows.Forms.Button btnOk;
        private UILibrary.SkinTextBox txtnumber;
        private System.Windows.Forms.Panel panel1;
    }
}