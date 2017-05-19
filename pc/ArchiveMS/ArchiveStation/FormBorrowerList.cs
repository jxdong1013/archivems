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
    public partial class FormBorrowerList : FormBase
    {
        int pagesize = Bean.Constant.PAGESIZE;

        public BorrowerBean SelectedBorrower
        {
            get;
            set;
        }

        public FormBorrowerList()
        {
            InitializeComponent();
        }
        public FormBorrowerList(string key  )
        {
            InitializeComponent();

            txtKey.Text = key;
            Go( 0 , pagesize  , key );
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        protected void Go(int pageidx, int pagesize, string key)
        {
            if (backgroundWorker1.IsBusy) return;

            Page<BorrowerBean> p = new Page<BorrowerBean>();
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
            Page<BorrowerBean> p = e.Argument as Page<BorrowerBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            BorrowerPageResult result = wrapper.QueryBorrowerByPage(p);

            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BorrowerPageResult result = e.Result as BorrowerPageResult;
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

                if (result.Data.Data == null || result.Data.Data.Count<1)
                {
                    MessageBox.Show("无数据");
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = result.Data.Data;


                pageControl1.SetPage(result.Data);

                dataGridView1.Focus();

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            Bean.BorrowerBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.BorrowerBean;
            if (bean == null) return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectedBorrower = bean;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lblDelete"))
            {
                BorrowerBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as BorrowerBean;
                if (bean == null) return;
                DialogResult result = MessageBox.Show("您确定要删除名称为【" + bean.name + "】的信息吗？", "询问", MessageBoxButtons.OKCancel);
                if (result != System.Windows.Forms.DialogResult.OK) return;
                //DeleteBoxLabel(bean);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lblEdit"))
            {

            }
        }


        private void pageControl1_onFirst(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;

            String key = txtKey.Text.Trim();

            Page<BorrowerBean> p = new Page<BorrowerBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onGo(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            String key = txtKey.Text.Trim();
            Page<BorrowerBean> p = new Page<BorrowerBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = pagesize;
            p.Key = key;


            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onLast(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();

            Page<BorrowerBean> p = new Page<BorrowerBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = pagesize;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onNext(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();

            Page<BorrowerBean> p = new Page<BorrowerBean>();
            p.PageIdx = e.pageidx; 
            p.PageSize = pagesize;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onPre(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();

            Page<BorrowerBean> p = new Page<BorrowerBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = pagesize;
            p.Key = key;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Go(0, pagesize, txtKey.Text.Trim());
            }
        }

        private void FormBorrowerList_SizeChanged(object sender, EventArgs e)
        {
            ChangePosition();
        }

        private void ChangePosition()
        {
            int x = (panel1.Width - txtKey.Width - btnGo.Width - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);

            x = x + txtKey.Width + 8;
            btnGo.Location = new Point(x, txtKey.Location.Y);

            x = (panel2.Width - pageControl1.Width) / 2;
            pageControl1.Location = new Point(x, pageControl1.Location.Y);

        }

        private void FormBorrowerList_Shown(object sender, EventArgs e)
        {
            ChangePosition();
        }

    }
}
