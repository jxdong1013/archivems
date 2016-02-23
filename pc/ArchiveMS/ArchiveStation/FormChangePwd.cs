using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormChangePwd : FormBase
    {
        public FormChangePwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string oldpwd = txtOldPwd.Text.Trim();
            string newpwd = txtNewPwd.Text.Trim();
            string newpwd2 = txtNewPwd2.Text.Trim();
            if (string.IsNullOrEmpty(oldpwd))
            {
                lblInfo.Text = "请输入原密码";
                txtOldPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty( newpwd))
            {
                lblInfo.Text = "请输入新密码";
                txtNewPwd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(newpwd2))
            {
                lblInfo.Text = "请输入确认密码";
                txtNewPwd2.Focus();
                return;
            }

            if ( newpwd.Equals(newpwd2 )==false)
            {
                lblInfo.Text = "两次密码输入不一致";
                txtNewPwd.Focus();
                return;
            }

            if (backgroundWorker1.IsBusy) return;
           
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            PwdPara para = new PwdPara();
            para.oldpwd = oldpwd;
            para.newpwd = newpwd;
            para.username = Bean.Variable.User.username;

            backgroundWorker1.RunWorkerAsync(para);
        }

        class PwdPara
        {
            public string oldpwd { get; set; }
            public string newpwd { get; set; }
            public string username { get; set; }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PwdPara para = e.Argument as PwdPara;
            if (para == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            Bean.BaseBean result = wrapper.ChangePwd(para.username, para.oldpwd, para.newpwd);

            e.Result = result;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("操作失败，请重试");
                    return;
                }
                Bean.BaseBean result = e.Result as Bean.BaseBean;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("操作失败，请重试");
                    return;
                }
                if (result.Code == (int)Bean.Constant.ResultCodeEnum.Error)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show(result.Message);
                    return;
                }


                MessageBox.Show("修改密码成功");
                this.Close();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                panelLoading.Visible = false;
            }
            finally
            {
                panelLoading.Visible = false;
            }

        }
    }
}
