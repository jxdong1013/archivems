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
    public partial class FormLabelConfig : FormBase
    {
        int pagesize = Bean.Constant.PAGESIZE;

        public FormLabelConfig()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        protected void Go(int pageidx, int pagesize, string key)
        {
            if (backgroundWorker1.IsBusy) return;

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;


            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            backgroundWorker1.RunWorkerAsync(p);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Page<Bean.ArchiveBean> p = e.Argument as Page<Bean.ArchiveBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            ArchivePageResult result = wrapper.QueryArchiveByPage(p);

            e.Result = result;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ArchivePageResult result = e.Result as ArchivePageResult;
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

        private void pageControl1_onFirst(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);

        }

        private void pageControl1_onGo(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();
            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onLast(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onNext(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();
            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onPre(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);

        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String key = txtKey.Text.Trim();
                Go(0, pagesize, key);
            }
        }

    }
}
