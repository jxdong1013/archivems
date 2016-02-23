using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormUser : FormBase
    {
        Bean.UserBean _user;
        public event EventHandler OnRefresh;

        public FormUser( Bean.UserBean bean)
        {
            InitializeComponent();
            _user = bean;

            if (_user != null)
            {
                txtName.Text = _user.username;
                txtPhone.Text = _user.phone;
                txtRealName.Text = _user.realname;
                rdbMan.Checked = _user.sex.Equals("男");
                ckbDisable.Checked = _user.enable == 1 ? false : true;
                rdbNormal.Checked = _user.roletype.Equals(Bean.Constant.Role_User) ? true : false;
                rdbDB.Checked = _user.realname.Equals(Bean.Constant.Role_Admin) ? true : false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblError1.Visible = false;
            lblError2.Visible = false;                
            String username = txtName.Text.Trim();
            string realname = txtRealName.Text.Trim();
            String phone = txtPhone.Text.Trim();
            String sex = rdbMan.Checked ? "男" : "女";
            int enable = ckbDisable.Checked ? 0 : 1;
            if (string.IsNullOrEmpty(username))
            {
                lblError1.Text = "请输入用户名！";
                lblError1.Visible = true;
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            
            if( _user ==null)
            {
              _user = new Bean.UserBean();
              _user.createman = Bean.Variable.User.username;
              _user.password = "123456";
            }

            _user.username = username;
            _user.realname = realname;
            _user.sex = sex;
            _user.enable = enable;
            _user.phone = phone;
            _user.modifyman = Bean.Variable.User.username;
            _user.modifytime = DateTime.Now;
            _user.roletype = rdbNormal.Checked ? Bean.Constant.Role_User : Bean.Constant.Role_Admin;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            Bean.UserResult result;
            if (_user.userid == 0)
            {
               result =   wrapper.AddUser(_user);              
            }
            else
            {
                result = wrapper.EditUser(_user);
            }
            if (result != null && result.Code == (int)Bean.Constant.ResultCodeEnum.Success)
            {
                MessageBox.Show(result.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                if (OnRefresh != null)
                {
                    OnRefresh(this, EventArgs.Empty);
                }
            }
            else
            {
                String msg=  result==null ?"操作失败":result.Message;
                MessageBox.Show(msg);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

    }
}
