namespace ArchiveStation
{
    partial class PageControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPage = new UILibrary.SkinButtom();
            this.txtPage = new UILibrary.SkinTextBox();
            this.btnLast = new UILibrary.SkinButtom();
            this.btnFirst = new UILibrary.SkinButtom();
            this.btnNext = new UILibrary.SkinButtom();
            this.btnPre = new UILibrary.SkinButtom();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(490, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 12);
            this.lblTotal.TabIndex = 13;
            // 
            // btnPage
            // 
            this.btnPage.BackColor = System.Drawing.Color.Transparent;
            this.btnPage.ControlState = UILibrary.ControlState.Normal;
            this.btnPage.DownBack = null;
            this.btnPage.Location = new System.Drawing.Point(263, 4);
            this.btnPage.MouseBack = null;
            this.btnPage.Name = "btnPage";
            this.btnPage.NormlBack = null;
            this.btnPage.Size = new System.Drawing.Size(46, 30);
            this.btnPage.TabIndex = 12;
            this.btnPage.Text = "GO";
            this.btnPage.UseVisualStyleBackColor = true;
            this.btnPage.Click += new System.EventHandler(this.btnPage_Click);
            // 
            // txtPage
            // 
            this.txtPage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPage.BackColor = System.Drawing.Color.Transparent;
            this.txtPage.Icon = null;
            this.txtPage.IconIsButton = false;
            this.txtPage.IsPasswordChat = '\0';
            this.txtPage.IsSystemPasswordChar = false;
            this.txtPage.LeftIcon = null;
            this.txtPage.Lines = new string[0];
            this.txtPage.Location = new System.Drawing.Point(198, 4);
            this.txtPage.Margin = new System.Windows.Forms.Padding(0);
            this.txtPage.MaxLength = 32767;
            this.txtPage.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtPage.MouseBack = null;
            this.txtPage.Multiline = false;
            this.txtPage.Name = "txtPage";
            this.txtPage.NormlBack = null;
            this.txtPage.Padding = new System.Windows.Forms.Padding(5);
            this.txtPage.ReadOnly = false;
            this.txtPage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPage.Size = new System.Drawing.Size(49, 30);
            this.txtPage.TabIndex = 11;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPage.WaterText = "页号";
            this.txtPage.WordWrap = true;
            this.txtPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPage_KeyDown);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.ControlState = UILibrary.ControlState.Normal;
            this.btnLast.DownBack = null;
            this.btnLast.Location = new System.Drawing.Point(409, 4);
            this.btnLast.MouseBack = null;
            this.btnLast.Name = "btnLast";
            this.btnLast.NormlBack = null;
            this.btnLast.Size = new System.Drawing.Size(75, 30);
            this.btnLast.TabIndex = 10;
            this.btnLast.Text = "末页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.ControlState = UILibrary.ControlState.Normal;
            this.btnFirst.DownBack = null;
            this.btnFirst.Location = new System.Drawing.Point(28, 4);
            this.btnFirst.MouseBack = null;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.NormlBack = null;
            this.btnFirst.Size = new System.Drawing.Size(75, 30);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.Text = "首页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.ControlState = UILibrary.ControlState.Normal;
            this.btnNext.DownBack = null;
            this.btnNext.Location = new System.Drawing.Point(328, 4);
            this.btnNext.MouseBack = null;
            this.btnNext.Name = "btnNext";
            this.btnNext.NormlBack = null;
            this.btnNext.Size = new System.Drawing.Size(75, 30);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.BackColor = System.Drawing.Color.Transparent;
            this.btnPre.ControlState = UILibrary.ControlState.Normal;
            this.btnPre.DownBack = null;
            this.btnPre.Location = new System.Drawing.Point(109, 4);
            this.btnPre.MouseBack = null;
            this.btnPre.Name = "btnPre";
            this.btnPre.NormlBack = null;
            this.btnPre.Size = new System.Drawing.Size(75, 30);
            this.btnPre.TabIndex = 7;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // PageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPage);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(544, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private UILibrary.SkinButtom btnPage;
        private UILibrary.SkinTextBox txtPage;
        private UILibrary.SkinButtom btnLast;
        private UILibrary.SkinButtom btnFirst;
        private UILibrary.SkinButtom btnNext;
        private UILibrary.SkinButtom btnPre;
    }
}
