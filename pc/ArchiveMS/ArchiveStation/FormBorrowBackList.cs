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
    public partial class FormBorrowBackList : FormBase
    {
        int pagesize = Bean.Constant.PAGESIZE;

        public FormBorrowBackList()
        {
            InitializeComponent();

            btnQuery.DrawType = UILibrary.DrawStyle.Img;
            SetButtomImage(btnQuery);

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        protected void Go(int pageidx, int pagesize, string key)
        {
            if (backgroundWorker1.IsBusy) return;

            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
           
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;


            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            backgroundWorker1.RunWorkerAsync(p);

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PageObject<BorrowLogBean> p = e.Argument as PageObject<BorrowLogBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            BorrowLogPageResult result = wrapper.QueryBorrowLogByPage(p   );

            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BorrowLogPageResult result = e.Result as BorrowLogPageResult;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("请求失败,请重试！");
                    return;
                }
                if (result.Code == (int)Constant.ResultCodeEnum.Error)
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

        private void FormBorrowBackList_SizeChanged(object sender, EventArgs e)
        {
            changeBarLocation();
        }
        /// <summary>
        /// 改变提示框的显示位置
        /// </summary>     
        protected void changeBarLocation()
        {
            int x = (panel1.Width - txtKey.Width - btnQuery.Width - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);

            x = x + txtKey.Width + 8;
            btnQuery.Location = new Point(x, txtKey.Location.Y);

            x = (panel2.Width - pageControl1.Width) / 2;
            pageControl1.Location = new Point(x, pageControl1.Location.Y);

        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String key = txtKey.Text.Trim();
                Go(0, pagesize, key);
            }
        }

        private void FormBorrowBackList_Shown(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        private void pageControl1_onFirst(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;

            String key = txtKey.Text.Trim();

            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;

            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onGo(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();
            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = e.pageidx; //pageidx;
            p.PageSize = pagesize;
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;


            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onLast(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();

            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = e.pageidx;// pageidx;
            p.PageSize = pagesize;
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onNext(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();

            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = e.pageidx; // pageidx;
            p.PageSize = pagesize;
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onPre(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();

            PageObject<BorrowLogBean> p = new PageObject<BorrowLogBean>();
            p.PageIdx = e.pageidx;//pageidx;
            p.PageSize = pagesize;
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = key;
            bean.idcard = key;
            bean.department = key;
            bean.boxnumber = key;
            bean.title = key;
            bean.status = -1;
            p.Key = bean;

            backgroundWorker1.RunWorkerAsync(p);
        }


    }
}
