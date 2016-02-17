using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public partial class FormLogin : FormBase
    {
        public FormLogin()
        {
            InitializeComponent();

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            tcCheckBox1.BackColor = Color.Transparent;
            lblTipInfo.BackColor = Color.Transparent;
            lblTipPwd.BackColor = Color.Transparent;
            lblTipUser.BackColor = Color.Transparent;

            btnOk.DrawType = UILibrary.DrawStyle.Img;
            btnCancel.DrawType = UILibrary.DrawStyle.Img;


            SetButtomImage(btnOk);

            SetButtomImageGray(btnCancel);
                 

            lblTipPwd.Visible = false;
            lblTipUser.Visible = false;
            lblTipInfo.Visible = false;
            lblTipUser.Text = lblTipPwd.Text = lblTipInfo.Text = string.Empty;

            UserBean u = UserManager.LoadUsers();
            if (u != null)
            {
                txtUserName.Text = u.username;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblTipInfo.Visible = lblTipPwd.Visible = lblTipUser.Visible = false;
            bool isOk = true;
            if( string.IsNullOrEmpty( txtUserName.Text ))
            {
                lblTipUser.Text = "请输入用户名";
                lblTipUser.Visible = true;
               isOk = false;
               txtUserName.Focus();
            }
            if( string.IsNullOrEmpty( txtPassword.Text ))
            {
                lblTipPwd.Text = "请输入密码";
                lblTipPwd.Visible = true;
                isOk = false;
                txtPassword.Focus();
            }

            if( isOk == false )
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            string username = txtUserName.Text.Trim ();
            string password = txtPassword.Text;
            string pwdMD5 = DesEncryptUtil.EncryptMD5( password );


            if (backgroundWorker1.IsBusy) return;
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);
            UserBean user = new UserBean();
            user.username = username;
            user.password = password;
            backgroundWorker1.RunWorkerAsync(user);
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            return;

             

            UserResult entity = new HttpUtilWrapper().Login<UserResult>(username, password);


            if (entity == null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                lblTipInfo.Text = "登录失败，用户名或密码错误";
                lblTipInfo.Visible = true;
                return;
            }
            else if (entity.Code == (int)Constant.ResultCodeEnum.Error)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                lblTipInfo.Text = entity.Message; // "登录失败，用户名或密码错误";
                lblTipInfo.Visible = true;
                return;
            }

            Variable.User = entity.Data;

            SaveUser(Variable.User);
        }

        protected void SaveUser(  UserBean user )
        {
            if (tcCheckBox1.Checked)
            {
                UserManager.SaveUser(user);
            }
            else
            {
                UserManager.Delete(user);
            }
        }

        private void FormLogin_SysBottomClick(object sender)
        {
            VisPanel();
        }

        protected bool Check()
        {
            string ip = txtIP.Text.Trim();
            //string port = txtPort.Text.Trim();
           // string dbusername = txtDBUserName.Text.Trim();
            //string dbpassword = txtDBPassword.Text.Trim();

            lblTipDBIP.Visible = lblTipDBUserName.Visible = lblTipDBPassword.Visible = lblTipDBPort.Visible = false;

            string msg = string.Empty;

            bool pass = true;
            //bool isok = ValidateUtil.ValidateIP(ip, ref msg);
            //if (isok == false)
            //{
            //    lblTipDBIP.Visible = true;
            //    lblTipDBIP.Text = msg;
            //    pass = false;
            //}

           // isok = ValidateUtil.ValidatePort(port, ref msg);
           // if (isok == false)
            //{
            //    lblTipDBPort.Visible = true;
           //     lblTipDBPort.Text = msg;
           //     pass = false;
           // }

            //if (string.IsNullOrEmpty(dbusername))
            //{
            //    lblTipDBUserName.Visible = true;
            //    lblTipDBUserName.Text = "请输入数据库用户名";
            //    pass = false;
            //}
            //if (string.IsNullOrEmpty(dbpassword))
            //{
            //    lblTipDBPassword.Visible = true;
            //    lblTipDBPassword.Text = "请输入数据库密码";
            //    pass = false;
            //}

            return pass;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;

            if (Check() == false)
            {
                return;
            }

            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini";
            string ip = txtIP.Text.Trim();
            //string port = txtPort.Text.Trim();
            //string dbusername = txtDBUserName.Text.Trim();
           // string dbpassword = txtDBPassword.Text.Trim();
            //string dbpasswordEx = DesEncryptUtil.EncryptDES(dbpassword, Constant.KEY);

            IniUtil.WriteIniValue(path, "URL", "host",ip);
            //IniUtil.WriteIniValue(path, "URL", "port", port);
            //IniUtil.WriteIniValue(path, "DB", "dbname","fish" );
           // IniUtil.WriteIniValue(path, "DB", "user", dbusername);
            //IniUtil.WriteIniValue(path, "DB", "password", dbpasswordEx );

            VisPanel();
        }

        protected void VisPanel()
        {
            bool vis = panel1.Visible;
            panel1.Visible = panel2.Visible;
            panel2.Visible = vis;
        }

        private void btnSetCancel_Click(object sender, EventArgs e)
        {
            VisPanel();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {                
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini";
            string url = IniUtil.ReadIniValue(path, "URL", "host");
            //string port = IniUtil.ReadIniValue(path, "URL", "port");
            //string user = IniUtil.ReadIniValue(path, "DB", "user");
            //string password = IniUtil.ReadIniValue(path, "DB", "password");

            //string passwordEx = DesEncryptUtil.DecryptDES(password, Constant.KEY);

            txtIP.Text = url;
            //txtPort.Text = string.IsNullOrEmpty ( port)? "80": port ;
            //txtDBUserName.Text = user;
            //txtDBPassword.Text = passwordEx;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UserResult result;
            UserBean bean = e.Argument as UserBean;
            if (bean == null)
            {
                result = new UserResult();
                result.Code = (int)Constant.ResultCodeEnum.Error;
                result.Message = "参数错误";
                e.Result = result;
                return;
            }

            UserResult entity = new HttpUtilWrapper().Login<UserResult>(bean.username , bean.password);

            if (entity == null)
            {
                result = new UserResult();
                result.Code = (int)Constant.ResultCodeEnum.Error;
                result.Message = "登录失败，用户名或密码错误";
                //this.DialogResult = System.Windows.Forms.DialogResult.None;
                //lblTipInfo.Text = "登录失败，用户名或密码错误";
                //lblTipInfo.Visible = true;
                e.Result = result;
                return;
            }
            else if (entity.Code == (int)Constant.ResultCodeEnum.Error)
            {
                //this.DialogResult = System.Windows.Forms.DialogResult.None;
                //lblTipInfo.Text = entity.Message; // "登录失败，用户名或密码错误";
                //blTipInfo.Visible = true;
                result = new UserResult();
                result.Code = (int)Constant.ResultCodeEnum.Error;
                result.Message = entity.Message;
                e.Result = result;
                return;
            }

            Variable.User = entity.Data;

            //SaveUser(Variable.User);

            result = entity;
            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                UserResult result = e.Result as UserResult;
                if (result == null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    lblTipInfo.Text = "登录失败,请重试！";
                    lblTipInfo.Visible = true;
                    //MessageBox.Show("登录失败,请重试！");
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    lblTipInfo.Text = result.Message;
                    lblTipInfo.Visible = true;
                    return;
                }


                SaveUser(result.Data);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                lblTipInfo.Text = "登录失败,请重试！";
                lblTipInfo.Visible = true;
            }
            finally
            {
                panelLoading.Visible = false;
            }
        }


    }
}
