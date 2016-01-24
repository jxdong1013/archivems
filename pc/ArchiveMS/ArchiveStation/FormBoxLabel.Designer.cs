namespace ArchiveStation
{
    partial class FormBoxLabel
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
            this.txtName = new UILibrary.SkinTextBox();
            this.txtRFID = new UILibrary.SkinTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new UILibrary.SkinTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblOne = new System.Windows.Forms.Label();
            this.lblTwo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "RFID：";
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
            this.txtName.Location = new System.Drawing.Point(92, 17);
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
            this.txtName.TabIndex = 4;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.WaterColor = System.Drawing.Color.DarkGray;
            this.txtName.WaterText = "请输入档案名称，负责人，编号";
            this.txtName.WordWrap = true;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtRFID
            // 
            this.txtRFID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRFID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRFID.BackColor = System.Drawing.Color.Transparent;
            this.txtRFID.Icon = null;
            this.txtRFID.IconIsButton = false;
            this.txtRFID.IsPasswordChat = '\0';
            this.txtRFID.IsSystemPasswordChar = false;
            this.txtRFID.LeftIcon = null;
            this.txtRFID.Lines = new string[0];
            this.txtRFID.Location = new System.Drawing.Point(92, 73);
            this.txtRFID.Margin = new System.Windows.Forms.Padding(0);
            this.txtRFID.MaxLength = 32767;
            this.txtRFID.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtRFID.MouseBack = null;
            this.txtRFID.Multiline = false;
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.NormlBack = null;
            this.txtRFID.Padding = new System.Windows.Forms.Padding(5);
            this.txtRFID.ReadOnly = false;
            this.txtRFID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRFID.Size = new System.Drawing.Size(204, 28);
            this.txtRFID.TabIndex = 5;
            this.txtRFID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRFID.WaterColor = System.Drawing.Color.DarkGray;
            this.txtRFID.WaterText = "请输入档案名称，负责人，编号";
            this.txtRFID.WordWrap = true;
            this.txtRFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "编号：";
            // 
            // txtNumber
            // 
            this.txtNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtNumber.Icon = null;
            this.txtNumber.IconIsButton = false;
            this.txtNumber.IsPasswordChat = '\0';
            this.txtNumber.IsSystemPasswordChar = false;
            this.txtNumber.LeftIcon = null;
            this.txtNumber.Lines = new string[0];
            this.txtNumber.Location = new System.Drawing.Point(92, 130);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumber.MaxLength = 32767;
            this.txtNumber.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtNumber.MouseBack = null;
            this.txtNumber.Multiline = false;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.NormlBack = null;
            this.txtNumber.Padding = new System.Windows.Forms.Padding(5);
            this.txtNumber.ReadOnly = false;
            this.txtNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNumber.Size = new System.Drawing.Size(204, 28);
            this.txtNumber.TabIndex = 7;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNumber.WaterColor = System.Drawing.Color.DarkGray;
            this.txtNumber.WaterText = "请输入档案名称，负责人，编号";
            this.txtNumber.WordWrap = true;
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(121, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "注册";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblOne
            // 
            this.lblOne.AutoSize = true;
            this.lblOne.ForeColor = System.Drawing.Color.Red;
            this.lblOne.Location = new System.Drawing.Point(95, 52);
            this.lblOne.Name = "lblOne";
            this.lblOne.Size = new System.Drawing.Size(0, 12);
            this.lblOne.TabIndex = 11;
            // 
            // lblTwo
            // 
            this.lblTwo.AutoSize = true;
            this.lblTwo.ForeColor = System.Drawing.Color.Red;
            this.lblTwo.Location = new System.Drawing.Point(96, 109);
            this.lblTwo.Name = "lblTwo";
            this.lblTwo.Size = new System.Drawing.Size(0, 12);
            this.lblTwo.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRFID);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.lblTwo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblOne);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 259);
            this.panel1.TabIndex = 13;
            // 
            // FormBoxLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 292);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBoxLabel";
            this.Radius = 10;
            this.RoundStyle = SkinForm.RoundStyle.All;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "档案盒标签注册";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
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
        private UILibrary.SkinTextBox txtName;
        private UILibrary.SkinTextBox txtRFID;
        private System.Windows.Forms.Label label3;
        private UILibrary.SkinTextBox txtNumber;
        private System.Windows.Forms.Button btnOk;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblOne;
        private System.Windows.Forms.Label lblTwo;
        private System.Windows.Forms.Panel panel1;
    }
}