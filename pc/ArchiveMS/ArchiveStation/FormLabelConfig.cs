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
            bool showNoPosition = ckbNoPosition.Checked;
            Go(0, pagesize, key , showNoPosition );
        }

        protected void Go(int pageidx, int pagesize, string key , bool showNoPosition )
        {
            if (backgroundWorker1.IsBusy) return;

            ckbAll.Checked = false;
            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;
            p.showNoPosition = showNoPosition;


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
            p.showNoPosition = ckbNoPosition.Checked;

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
            p.showNoPosition = ckbNoPosition.Checked;

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
            p.showNoPosition = ckbNoPosition.Checked;

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
            p.showNoPosition = ckbNoPosition.Checked;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void pageControl1_onPre(object sender, PageEventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = Bean.Constant.PAGESIZE;
            p.Key = key;
            p.showNoPosition = ckbNoPosition.Checked;

            backgroundWorker1.RunWorkerAsync(p);

        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String key = txtKey.Text.Trim();
                bool showNoPosition = ckbNoPosition.Checked;
                Go(0, pagesize, key , showNoPosition );
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            List<int> records = GetCheckedRecord();
            if (records == null || records.Count < 1)
            {
                MessageBox.Show("请勾选需要归盒的档案记录", "提示信息");
                return;
            }


            FormBoxList form = new FormBoxList("档案归盒");
            form.Text = "请选择档案盒标签，进行归盒操作";
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;

            BoxBean boxLabel = form.SelectedBoxLabel;
            if (boxLabel == null) return;

            if (backgroundWorker2.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);
            lblLoadingText.Text = "正在请求档案归盒操作，请稍等......";

            BoxLabelConfig para = new BoxLabelConfig();
            para.ArchiveIds = records;
            para.BoxId = boxLabel.id;

            backgroundWorker2.RunWorkerAsync( para );

        }

        protected List<int> GetCheckedRecord()
        {
            dataGridView1.EndEdit();
            List<int> records = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object obj = row.Cells["ckbselect"].Value;
                if (obj == null) continue;
                bool isckb;
                bool.TryParse(obj.ToString(), out isckb);
                if (isckb== false )continue;
                obj  = row.Cells["id"].Value;
                if( obj ==null) continue;
                int id;
                int.TryParse( obj.ToString(),out id);
                records.Add(id);
                
            }
            return records;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BoxLabelConfig para = e.Argument as BoxLabelConfig;
            if (para == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            ArchiveResult result = wrapper.ArchiveToBox(para.ArchiveIds, para.BoxId);
            e.Result = result;

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ArchiveResult result = e.Result as ArchiveResult;
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

                String key = txtKey.Text.Trim();
                bool showNoposition = ckbNoPosition.Checked;
                Go(0, pagesize, key, showNoposition );

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

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckRecords(ckbAll.Checked);
        }

        protected void CheckRecords( bool state)
        {
            if (dataGridView1.Rows.Count < 1) return;
            foreach( DataGridViewRow row in dataGridView1.Rows )
            {
                row.Cells["ckbselect"].Value = state;
            }
        }


        class BoxLabelConfig
        {
            public List<int> ArchiveIds { get; set; }
            public int BoxId { get; set; }
        }

        private void FormLabelConfig_Shown(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        private void FormLabelConfig_SizeChanged(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        protected void changeBarLocation()
        {
            int x = (panel1.Width - txtKey.Width - btnGo.Width - btnConfig.Width - 8 - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);


            x = x + txtKey.Width + 8;
            btnGo.Location = new Point(x, txtKey.Location.Y);

            x = x + btnGo.Width + 8;
            btnConfig.Location = new Point(x, txtKey.Location.Y);

            x = x + btnConfig.Width + 8;
            btnDelete.Location = new Point(x, txtKey.Location.Y);

            x = txtKey.Location.X + 8;
            ckbNoPosition.Location = new Point(x, ckbNoPosition.Location.Y);

            x = (panel2.Width - pageControl1.Width) / 2;
            pageControl1.Location = new Point(x, pageControl1.Location.Y);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> records = GetCheckedRecord();
            if (records == null || records.Count < 1)
            {
                MessageBox.Show("请勾选需要删除的档案记录", "提示信息");
                return;
            }

            if (MessageBox.Show("您确定要删除勾选的档案记录吗？", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            if (backgroundWorker3.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);
            lblLoadingText.Text = "正在请求删除档案操作，请稍等...";

            BoxLabelConfig para = new BoxLabelConfig();
            para.ArchiveIds = records;
            
            backgroundWorker3.RunWorkerAsync(para);

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            BoxLabelConfig para = e.Argument as BoxLabelConfig;
            if (para == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            ArchiveResult result = wrapper.DeleteArchives(para.ArchiveIds);
            e.Result = result;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ArchiveResult result = e.Result as ArchiveResult;
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

                String key = txtKey.Text.Trim();
                bool showNoposition = ckbNoPosition.Checked;
                Go(0, pagesize, key, showNoposition);

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
    }
}
