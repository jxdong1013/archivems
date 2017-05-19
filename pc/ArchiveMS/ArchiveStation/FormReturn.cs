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
    public partial class FormReturn : FormBase
    {
        List<BorrowLogBean> _archives = new List<BorrowLogBean>();
        List<BorrowLogBean> _selectedArchives = new List<BorrowLogBean>();
        BorrowerBean _borrower = null;

        public FormReturn()
        {
            InitializeComponent();

            btnReturn.DrawType = UILibrary.DrawStyle.Img;
            SetButtomImage(btnReturn);

            btnReset.DrawType = UILibrary.DrawStyle.Img;
            SetButtomImage(btnReset);

            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void FormReturn_SizeChanged(object sender, EventArgs e)
        {
            changePanelTipLocation();
        }

        protected void changePanelTipLocation()
        {
            int x = (panel1.Width - txtKey.Width - btnGo.Width - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);

            x = x + txtKey.Width + 8;
            btnGo.Location = new Point(x, txtKey.Location.Y);

            int y = (panelBottom.Height - btnReturn.Height)/2;
       
            x = (panelBottom.Width - btnReset.Width) - 20;
            btnReset.Location = new Point(x, y);

            x = x - btnReturn.Width -20;
            btnReturn.Location = new Point(x, y);
        }

        //private void btnStartScan_Click(object sender, EventArgs e)
        //{
        //    //startScan();
        //}


        private void FormReturn_Activated(object sender, EventArgs e)
        {
        }

        private void FormReturn_Deactivate(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowerBean borrower = e.Argument as BorrowerBean;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            BorrowListResult result = wrapper.Borrow_GetArchiveListByBorrower(borrower.borrowerid);
            e.Result = result;
        }

        //protected bool isExist(ArchiveBean model)
        //{
        //    foreach (ArchiveBean bean in _archives)
        //    {
        //        if (bean.id == model.id) return true;
        //    }
        //    return false;
        //}

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelLoading.Visible = false;
                BorrowListResult result = e.Result as BorrowListResult;
                if (result == null)
                {
                    lblError.Text = "请求失败,请重试！";
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
                {
                    lblError.Text = result.Message;
                    return;
                }

                List<BorrowLogBean> list = result.Data;
                if (list == null || list.Count<1 )
                {
                    lblError.Text = "经查询，该用户无借阅档案";
                    return;
                }

                _archives.Clear();

                _archives = list;

                //foreach (ArchiveBean item in list)
                //{
                //    if (isExist(item)) { continue; }
                //    _archives.Add(item);
                //}

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _archives;
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

        //protected void startScan()
        //{
        //    Reader.GetInstance().GetUIDCallBack += FormReturn_GetUIDCallBack;
        //    Reader.GetInstance().Start();
        //}

        //void FormReturn_GetUIDCallBack(string uid)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            this.Invoke(new Action<string>(RFIDCallback), new string[] { uid });
        //        }
        //        else
        //        {
        //            RFIDCallback(uid);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //protected void RFIDCallback(string rfid)
        //{

        //    //string[] fff = { "7", "11", "5", "3" };
        //    //rfid = fff[new Random().Next(4)];



        //    if (string.IsNullOrEmpty(rfid)) return;
            

        //    if (_boxs != null)
        //    {
        //        foreach (BoxBean item in _boxs)
        //        {
        //            if (item.rfid.Equals(rfid))
        //            {
        //                //lblError.Text = "档案已经扫描";
        //                return;
        //            }
        //        }
        //    }


        //    if (backgroundWorker1.IsBusy) return;

        //    this.panelTip.Visible = false;
        //    this.panelLoading.Visible = true;
        //    this.lblLoadingText.Text = "正在请求操作，请稍等......";
        //    this.panelLoading.BringToFront();
        //    this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

        //    backgroundWorker1.RunWorkerAsync(rfid);
        //}
        


        //protected void stopScan()
        //{
        //    Reader.GetInstance().GetUIDCallBack -= FormReturn_GetUIDCallBack;
        //    Reader.GetInstance().Stop();
        //}

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //stopScan();

            string archiveids = string.Empty;
            bool isok = CheckData(out archiveids);
            if (!isok) return;


            if (backgroundWorker2.IsBusy) return;


            if (MessageBox.Show("您确定要归还勾选的档案资料吗？", "询问", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) return;


            this.panelLoading.Visible = true;
            this.lblLoadingText.Text = "正在请求操作，请稍等......";
            this.panelLoading.BringToFront();
            this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            BorrowParameter parameter = new BorrowParameter();
            parameter.archiveids = archiveids;


            backgroundWorker2.RunWorkerAsync(parameter);            
        }

        private bool CheckData(out string archiveids)
        {
            lblError.Text = string.Empty;
            archiveids = string.Empty;
            bool isok = true;
            if (_archives == null || _archives.Count < 1)
            {
                isok = false;
                lblError.Text += "请选择档案，进行归还操作";
                //changePanelTipLocation();
            }

            //foreach (ArchiveBean bean in _archives)
            //{
            //    if (!string.IsNullOrEmpty(archiveids))
            //    {
            //        archiveids += ",";
            //    }
            //    archiveids += bean.id.ToString();
            //}

            _selectedArchives.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["lblCheck"].EditedFormattedValue.ToString().ToLower().Equals("true"))
                {
                    _selectedArchives.Add(row.DataBoundItem as BorrowLogBean);
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
                lblError.Text += "请勾选需要归还的档案";
            }

            return isok;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowParameter parameter = (BorrowParameter)e.Argument;
            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            BaseBean res = wrapper.Return(parameter);
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
                    //panelLoading.Visible = false;
                    lblError.Text = "请求失败,请重试！";
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
                {
                    //panelLoading.Visible = false;
                    lblError.Text = result.Message;
                    return;
                }

                _archives.Clear();
                _selectedArchives.Clear();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _archives;
                //changePanelTipLocation();
                panelLoading.Visible = false;
                MessageBox.Show("归还操作完成");
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();          

            FormBorrowerList form = new FormBorrowerList(key);
            form.Text = "请选择借阅人，进行归还档案操作";
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterParent;

            if (form.ShowDialog() != DialogResult.OK) return;

            _borrower = form.SelectedBorrower;
            if (_borrower == null) return;

            if (backgroundWorker1.IsBusy) return;

            _archives.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _archives;

            this.panelLoading.Visible = true;
            this.lblLoadingText.Text = "正在请求操作，请稍等......";
            this.panelLoading.BringToFront();
            this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);
            

            backgroundWorker1.RunWorkerAsync(_borrower);            
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo.PerformClick();
            }
        }

        private void FormReturn_Shown(object sender, EventArgs e)
        {
            changePanelTipLocation();
            txtKey.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = false;
            lblError.Text = string.Empty;
            _archives.Clear();
            _selectedArchives.Clear();
            _borrower = null;
            txtKey.Text = string.Empty;
            dataGridView1.DataSource = null;
        }

    }
}
