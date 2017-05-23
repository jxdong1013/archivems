using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public partial class FormBorrow : FormBase
    {
        List<ArchiveBean> _archives = new List<ArchiveBean>();
        List<ArchiveBean> _selectedArchives = new List<ArchiveBean>();
        List<String> _boxs = new List<String>();

        public FormBorrow()
        {
            InitializeComponent();

            btnBorrow.DrawType = UILibrary.DrawStyle.Img;
            SetButtomImage(btnBorrow);

            btnreset.DrawType = UILibrary.DrawStyle.Img;
            SetButtomImage(btnreset);
        }

        private void FormBorrow_SizeChanged(object sender, EventArgs e)
        {
            changePanelTipLocation();
        }
        /// <summary>
        /// 改变提示框的显示位置
        /// </summary>
        protected void changePanelTipLocation()
        {
            int x = (this.Width - panelTip.Width -10 ) / 2;
            int y = (this.Height - panelTip.Height-10)/2;
            panelTip.Location =new Point(x, y );

            x = (this.groupBox1.Width - panelUserinfo.Width) / 2;
            y = (this.groupBox1.Height - panelUserinfo.Height) / 2;
            panelUserinfo.Location = new Point(x, y);
        }

        private void FormBorrow_Activated(object sender, EventArgs e)
        {
            Reader.GetInstance().GetUIDCallBack += FormBorrow_GetUIDCallBack;
            Reader.GetInstance().Start();
        }
        /// <summary>
        /// 标签扫描事件回调
        /// </summary>
        /// <param name="uid"></param>
        void FormBorrow_GetUIDCallBack(string uid)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<string>(RFIDCallback), new string[] { uid });
                }
                else
                {
                    RFIDCallback(uid);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        protected void RFIDCallback(string rfid)
        {

#if DEBUG
            //string[] fff = { "aaaaaaa", "bbbbbbb", "b333333", "3" };
            //rfid = fff[new Random().Next(4)];
#endif



            if (string.IsNullOrEmpty(rfid)) return;

            foreach (ArchiveBean bean in _archives)
            {
                if (bean.boxrfid.Equals(rfid)) return;
            }


            if (backgroundWorker1.IsBusy) return;

            this.panelTip.Visible = false;
            this.panelLoading.Visible = true;
            this.lblLoadingText.Text = "正在请求操作，请稍等......";
            this.panelLoading.BringToFront();
            this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            backgroundWorker1.RunWorkerAsync(rfid);
        }
        
        private void FormBorrow_Deactivate(object sender, EventArgs e)
        {
            Reader.GetInstance().GetUIDCallBack -= FormBorrow_GetUIDCallBack;
            Reader.GetInstance().Stop();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string rfid = e.Argument.ToString();               
            
            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            ArchiveListResult result = wrapper.Borrow_GetArchiveListOfBox(rfid , (int)Constant.ArchiveStatusEnum.在库 );
            e.Result = result;
        }

        protected bool isExist(ArchiveBean model)
        {
            foreach (ArchiveBean bean in _archives)
            {
                if (bean.id == model.id) return true;
            }
            return false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            { 
                panelLoading.Visible = false;
                ArchiveListResult result = e.Result as ArchiveListResult;
                if (result == null)
                {
                    lblError.Text = "请求失败,请重试！";
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
                {
                    lblError.Text=result.Message;
                    return;
                }
                List<ArchiveBean> list = result.Data;
                if (list == null || list.Count<1 )
                {
                    lblError.Text = "查无信息";
                    return;
                }

                bool isAllIn = true;
                foreach (ArchiveBean item in list)
                {
                    if (isExist(item)) { continue; }
                    isAllIn = false;
                    _archives.Add(item);
                }

                _boxs.Add(list[0].boxrfid);

                //_boxs.Add(bean);
                if (isAllIn == false)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _archives;
                }

                if (_archives == null || _archives.Count < 1)
                {
                    panelTip.Visible = true;
                }
                else
                {
                    panelTip.Visible = false;
                }
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

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryUserInfo( txtName.Text.Trim() );
            }
        }

        protected void QueryUserInfo(string key )
        {
            FormBorrowerList form = new FormBorrowerList( key );
            form.Text = "请选择借阅人，进行借阅操作";
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterParent;

            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            BorrowerBean bean = form.SelectedBorrower;
            if (bean == null) return;

            txtDepartment.Text = bean.department;
            txtIdcard.Text = bean.idcard;
            txtName.Text = bean.name;
        }

        private void txtIdcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryUserInfo( txtIdcard.Text.Trim() );
            }
        }

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryUserInfo( txtDepartment.Text.Trim() );
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            string archiveids = string.Empty;
            bool isok = CheckData(out archiveids);
            if (!isok) return;


            if (MessageBox.Show("您确定要借阅勾选的档案资料吗？", "询问", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) return;

            
            if (backgroundWorker2.IsBusy) return;

            this.panelLoading.Visible = true;
            this.lblLoadingText.Text = "正在请求操作，请稍等......";
            this.panelLoading.BringToFront();
            this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            BorrowParameter parameter = new BorrowParameter();
            parameter.archiveids = archiveids;
            parameter.department = txtDepartment.Text.Trim();
            parameter.idcard = txtIdcard.Text.Trim();
            parameter.name = txtName.Text.Trim();
            parameter.operateid = Variable.User == null ? 0 : Variable.User.userid;
            parameter.operatename = Variable.User == null ? "" : Variable.User.username;

            backgroundWorker2.RunWorkerAsync(parameter);
            
        }

        protected bool CheckData(out string archiveids )
        {
            lblError.Text = string.Empty;
            archiveids = string.Empty;
            string name = txtName.Text.Trim();
            string idcard = txtIdcard.Text.Trim();
            string department = txtDepartment.Text.Trim();
            bool isok = true;
            if (string.IsNullOrEmpty(name))
            {
                isok=false;
                lblError.Text = "请填写借阅人姓名";
            }
            if (string.IsNullOrEmpty(idcard))
            {
                isok=false;
                lblError.Text += "请填写借阅人身份证";
            }

            if (_archives == null || _archives.Count < 1)
            {
                isok = false;
                lblError.Text += "请扫描档案盒标签显示档案信息";
            }

            _selectedArchives.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["lblCheck"].EditedFormattedValue.ToString().ToLower().Equals("true"))
                {
                    _selectedArchives.Add(row.DataBoundItem as ArchiveBean);
                     if (!string.IsNullOrEmpty(archiveids))
                     {
                         archiveids += ",";
                     }
                     archiveids += row.Cells["id"].Value.ToString();
                }
            }
            if (_selectedArchives.Count < 1)
            {
                isok = false;
                lblError.Text += "请勾选需要借阅的档案";
            }
            return isok;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowParameter parameter =(BorrowParameter) e.Argument;        
            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            BorrowResult res = wrapper.Borrow(parameter);
            e.Result = res;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelLoading.Visible = false;
                BorrowResult result = e.Result as BorrowResult;
                if (result == null)
                {                   
                    lblError.Text = "请求失败,请重试！";
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
                { 
                    lblError.Text=result.Message;
                    return;
                }

                List<PrintBorrowBean> prints = new List<PrintBorrowBean>();
                prints.Add(result.Data);
                
 #if DEBUG
                PrintManager.Single.Preview_Borrow( prints );
#else
                PrintManager.Single.Print_Borrow(prints);
#endif

                _boxs.Clear();
                _archives.Clear();
                _selectedArchives.Clear();
                dataGridView1.DataSource = null;                
                txtDepartment.Text = txtIdcard.Text = txtName.Text = string.Empty;             
                panelTip.Visible = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                lblError.Text = ex.Message;
            }
            finally
            {
                panelLoading.Visible = false;
            }
        }

        private void FormBorrow_Shown(object sender, EventArgs e)
        {
            changePanelTipLocation();
        }

        private void FormBorrow_FormClosing(object sender, FormClosingEventArgs e)
        {         
            Reader.GetInstance().GetUIDCallBack -=FormBorrow_GetUIDCallBack;
            Reader.GetInstance().Stop();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            //if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lbldelete"))
            //{
            //    BoxBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as BoxBean;
            //    if (bean == null) return;
            //    DialogResult result = MessageBox.Show("您确定要删除名称为【" + bean.name + "】的标签吗？", "询问", MessageBoxButtons.OKCancel);
            //    if (result != System.Windows.Forms.DialogResult.OK) return;

            //    //_boxs.Remove(bean);
            //    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);

            //}
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            _boxs.Clear();
            _archives.Clear();
            _selectedArchives.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _archives;
            txtDepartment.Text = txtIdcard.Text = txtName.Text = string.Empty;
            changePanelTipLocation();
            panelTip.Visible = true;
            panelLoading.Visible = false;
            lblError.Text = string.Empty;
        }


    }
}
