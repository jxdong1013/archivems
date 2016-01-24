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
    public partial class FormBoxList : FormBase
    {
        public FormBoxList()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Page<BoxBean> p = e.Argument as Page<BoxBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            BoxPageResult result = wrapper.QueryBoxByPage(p);

            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BoxPageResult result = e.Result as BoxPageResult;
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

            Page<BoxBean> p = new Page<BoxBean>();
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
            Page<BoxBean> p = new Page<BoxBean>();
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

            Page<BoxBean> p = new Page<BoxBean>();
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
            Page<BoxBean> p = new Page<BoxBean>();
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

            Page<BoxBean> p = new Page<BoxBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE; 
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, Bean.Constant.PAGESIZE, key);
        }
        protected void Go(int pageidx, int pagesize, string key)
        {
            if (backgroundWorker1.IsBusy) return;

            Page<BoxBean> p = new Page<BoxBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;


            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormBoxLabel form = new FormBoxLabel( null );
            form.StartPosition = FormStartPosition.CenterParent;
            form.OnRefreshData += form_OnRefreshData;
            form.ShowDialog();
        }

        void form_OnRefreshData(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, Bean.Constant.PAGESIZE, key);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            Bean.BoxBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.BoxBean;
            if (bean == null) return;

            FormBoxLabel form = new FormBoxLabel(bean);
            form.OnRefreshData += form_OnRefreshData;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
    }
}
