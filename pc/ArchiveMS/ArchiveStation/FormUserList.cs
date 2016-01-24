using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormUserList : FormBase
    {
        public FormUserList()
        {
            InitializeComponent();
        }

        private void lblAdd_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormUser form = new FormUser(null);
            //form.Parent = this;
            form.StartPosition = FormStartPosition.CenterParent;
            form.OnRefresh += form_OnRefresh;
            form.ShowDialog();
        }

        void form_OnRefresh(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            RefreshData(0, Bean.Constant.PAGESIZE, key);
        }

        protected void RefreshData(int pageidx, int pagesize, string key)
        { 
            if (backgroundWorker1.IsBusy) return;

            Bean.Page<Bean.UserBean> p = new Bean.Page<Bean.UserBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;


       
          

            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            backgroundWorker1.RunWorkerAsync(p);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           Bean.Page<Bean.UserBean> p = e.Argument as Bean.Page<Bean.UserBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            Bean.UserPageResult result = wrapper.GetUser(p);

            e.Result = result;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Bean.UserPageResult result = e.Result as Bean.UserPageResult;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("请求失败,请重试！");
                    return;
                }
                if (result.Code == (int)Bean.Constant.ResultCodeEnum.Error)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show(result.Message);
                    return;
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = result.Data.Data;

                pageControl1.SetPage(result.Data);

            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            finally
            {
                panelLoading.Visible = false;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            RefreshData(0, Bean.Constant.PAGESIZE, key);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            Bean.UserBean model = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.UserBean;
            if (model == null) return;
            EditUser(model);
        }

        protected void EditUser(Bean.UserBean bean)
        {
            FormUser form = new FormUser(bean);
            form.StartPosition = FormStartPosition.CenterParent;
            form.OnRefresh += form_OnRefresh;
            form.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0|| e.RowIndex< 0 ) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lbldelete"))
            {
                int userid;
                int.TryParse( dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString(), out userid);
                string username = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                DeleteUser(userid, username);

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lbledit"))
            {
                Bean.UserBean model = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.UserBean;
                if (model == null) return;
                EditUser(model);
            }
        }

        private void DeleteUser( int userid , String username )
        {
            DialogResult result=   MessageBox.Show("您确定要删除【"+username +"】用户吗？", "询问", MessageBoxButtons.OKCancel);
            if (result != System.Windows.Forms.DialogResult.OK) return;
            if (backgroundWorker2.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.BringToFront();
            lblLoadingText.Text = "正在请求操作，请稍等......";
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            backgroundWorker2.RunWorkerAsync( userid );

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int userid;
            int.TryParse(e.Argument.ToString(), out userid);

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            Bean.UserResult result = wrapper.DeleteUser(userid);

            e.Result = result;

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Bean.UserPageResult result = e.Result as Bean.UserPageResult;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("请求失败,请重试！");
                    return;
                }
                if (result.Code == (int)Bean.Constant.ResultCodeEnum.Error)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show(result.Message);
                    return;
                }

                String key = txtKey.Text.Trim();
                RefreshData(0, Bean.Constant.PAGESIZE, key);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                panelLoading.Visible = false;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("enable"))
            {
                object obj = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (obj == null) return;
                int temp = 0;
                int.TryParse(obj.ToString(), out temp);
                if (temp == 0) e.Value = "禁用";
                else
                {
                    e.Value = "正常";
                }
            }
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                String key = txtKey.Text.Trim();
                RefreshData(0, Bean.Constant.PAGESIZE, key);
            }
        }
    }
}
