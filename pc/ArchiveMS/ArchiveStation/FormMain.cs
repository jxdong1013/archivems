﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormMain : FormBase
    {
        MdiClient _mdiClient = null;
        FormList formList = null;
        FormFloorList formFloorList = null;
        FormUserList formUserList = null;
        FormBoxList formBoxList = null;
        FormImport formImport = null;
        FormLabelConfig formLabelConfig = null;
        FormBorrow formBorrow = null;
        FormReturn formReturn = null;
        FormBorrowBackList formBorrowBackList = null;

        public FormMain()
        {
            InitializeComponent();

            this.Location = new Point(-1000, -1000);  
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Login();
        }

        protected void Login()
        {
            this.Hide();
            FormLogin form = new FormLogin();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Bean.Variable.User != null)
                {
                    this.tSSLUser.Text = Bean.Variable.User.realname + "(" + Bean.Variable.User.username + ")";
                }
                this.Location = new Point(0, 0);
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.BringToFront();

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    MdiClient client = this.Controls[i] as MdiClient;
                    if (client == null) continue;
                    _mdiClient = client;
                    _mdiClient.BackColor = Color.White;
                    break;
                }

                setRole();

                //GetUserRoles();

                //LoadTreeMenu();

                //ShowMenuByRoles();

                //tSSLUser.Text = FishEntity.Variable.User == null ? string.Empty : FishEntity.Variable.User.realname + "(" + FishEntity.Variable.User.roletype + ")";

                DrawMdiClientBackground();

                //ShowPushMessageForm();

                //StartBackThread();

            }
            else
            {
                this.Close();
            }
        }

        protected void setRole()
        {
            string role = Bean.Variable.User==null? "": Bean.Variable.User.roletype;
            role = role.Trim();
            if (Bean.Constant.Role_Admin.Equals(role))
            {
                btnBorrow.Visible = true;
                btnReturn.Visible = true;
                btnUser.Visible = true;
            }
            else
            {
                btnBorrow.Visible = false;
                btnReturn.Visible = false;                    
                btnUser.Visible = false;
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            DrawMdiClientBackground();
        }

        private void DrawMdiClientBackground()
        {
            if (this.IsMdiContainer == false) return;
            if (_mdiClient == null) return;
            if (_mdiClient.ClientSize.Width <= 0 || _mdiClient.ClientSize.Height <= 0) return;
            string path = Application.StartupPath + "\\Images\\bg.jpg";
            if (System.IO.File.Exists(path) == false) return;

            Image mdiBg_Image = Image.FromFile(path);
            System.Drawing.Bitmap myImg = new Bitmap(_mdiClient.ClientSize.Width, _mdiClient.ClientSize.Height);
            System.Drawing.Graphics myGraphics = System.Drawing.Graphics.FromImage(myImg);
            myGraphics.Clear(Color.White);

            int myX = 0;
            int myY = 0;
            myX = (myImg.Width - mdiBg_Image.Width) / 2;
            myY = (myImg.Height - mdiBg_Image.Height) / 2;

            myGraphics.DrawImage(mdiBg_Image, myX, myY, mdiBg_Image.Width, mdiBg_Image.Height);
            _mdiClient.BackgroundImage = myImg;
            myGraphics.Dispose();
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (formImport == null)
            {
                formImport = new FormImport();
                formImport.WindowState = FormWindowState.Maximized;
                formImport.FormClosing += formImport_FormClosing;
                formImport.MdiParent = this;
            }
            formImport.Show();
            formImport.BringToFront();             
        }

        void formImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            formImport = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (formList == null)
            {
                formList = new FormList();
                formList.FormClosed += formList_FormClosed;
                formList.MdiParent = this;
            }

            formList.Show();
            formList.BringToFront();
        }

        void formList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formList = null;
        }

        private void btnFloorLabel_Click(object sender, EventArgs e)
        {
            if (formFloorList == null)
            {
                formFloorList = new FormFloorList();
                formFloorList.FormClosed += formFloorList_FormClosed;
                formFloorList.MdiParent = this;
            }

            formFloorList.WindowState = FormWindowState.Maximized;
            formFloorList.Show();
            formFloorList.BringToFront();
        }

        void formFloorList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formFloorList = null;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (formUserList == null)
            {
                formUserList = new FormUserList();
                formUserList.FormClosed += formUserList_FormClosed;
                formUserList.MdiParent = this;
            }
            formUserList.Show();
            formUserList.BringToFront();
        }

        void formUserList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formUserList=null;
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            if (formBoxList == null)
            {
                formBoxList = new FormBoxList();
                formBoxList.FormClosed += formBoxList_FormClosed;
                formBoxList.MdiParent = this;
            }
            formBoxList.Show();
            formBoxList.BringToFront();
        }

        void formBoxList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBoxList = null;
        }

        private void btnLabelConfig_Click(object sender, EventArgs e)
        {
            if (formLabelConfig == null)
            {
                formLabelConfig = new FormLabelConfig();
                formLabelConfig.FormClosed += formLabelConfig_FormClosed;
                formLabelConfig.MdiParent = this;
            }
            formLabelConfig.WindowState = FormWindowState.Maximized;
            formLabelConfig.Show();
            formLabelConfig.BringToFront();
        }

        void formLabelConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            formLabelConfig = null;
        }

        private void tsslchangepwd_Click(object sender, EventArgs e)
        {
            FormChangePwd form = new FormChangePwd();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (formBorrow == null)
            {
                formBorrow = new FormBorrow();
                formBorrow.FormClosed += formBorrow_FormClosed;
                formBorrow.MdiParent = this;
            }
            formBorrow.WindowState = FormWindowState.Maximized;
            formBorrow.Show();
            formBorrow.BringToFront();
        }

        void formBorrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBorrow = null;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if ( formReturn == null)
            {
                formReturn = new FormReturn();
                formReturn.FormClosed += formReturn_FormClosed;
                formReturn.MdiParent = this;
            }
            formReturn.WindowState = FormWindowState.Maximized;
            formReturn.Show();
            formReturn.BringToFront();
        }

        void formReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formReturn=null;
        }

        private void btnBorrowLog_Click(object sender, EventArgs e)
        {
            if (formBorrowBackList == null)
            {
                formBorrowBackList = new FormBorrowBackList();
                formBorrowBackList.FormClosed += formBorrowBackList_FormClosed;
                formBorrowBackList.MdiParent = this;
            }
            formBorrowBackList.WindowState = FormWindowState.Maximized;
            formBorrowBackList.Show();
            formBorrowBackList.BringToFront();
        }

        void formBorrowBackList_FormClosed(object sender, FormClosedEventArgs e)
        {
            formBorrowBackList = null;
        }

    }
}
