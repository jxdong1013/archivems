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
    public partial class FormList : FormBase
    {
        int pagesize = Bean.Constant.PAGESIZE;

        public FormList()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize , key);
        }

        public void SetBoxRfid(string rfid)
        {
            txtKey.Text = rfid;
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        protected void Go( int pageidx , int pagesize , string key)
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

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

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

                btnFirst.Tag = 0;
                btnPre.Tag = result.Data.PageIdx - 1;
                btnNext.Tag = result.Data.PageIdx + 1;
                btnLast.Tag = result.Data.TotalPages - 1;
                txtPage.Text =  (result.Data.PageIdx+1) >= result.Data.TotalPages ?  result.Data.TotalPages.ToString(): (result.Data.PageIdx + 1).ToString();

                lblTotal.Text = "共"+result.Data.TotalPages + "页/" + result.Data.TotalRecords + "条";


                if (result.Data.PageIdx == 0)
                {
                    btnFirst.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                }

                if (result.Data.PageIdx > 0)
                {
                    btnPre.Enabled = true;
                }
                else 
                {
                    btnPre.Enabled = false;
                }


                if (result.Data.TotalPages > 0 && result.Data.PageIdx + 1 < result.Data.TotalPages)
                {
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = false;
                }

                if (result.Data.PageIdx == result.Data.TotalPages - 1)
                {
                    btnLast.Enabled = false;
                }
                else
                {
                    btnLast.Enabled = true;
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
        

        private void btnFirst_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;           

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;
            if (btnPre.Tag == null)
            {
                pageidx = 0;
            }
            else
            {
                int.TryParse(btnPre.Tag.ToString(), out pageidx);
            }

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            go();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;
            if (btnNext.Tag == null)
            {
                pageidx = 0;
            }
            else
            {
                int.TryParse(btnNext.Tag.ToString(), out pageidx);
            }

            String key =txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;
            if (btnLast.Tag == null)
            {
                pageidx = 0;
            }
            else
            {
                int.TryParse(btnLast.Tag.ToString(), out pageidx);
            }

            String key = txtKey.Text.Trim();

            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                go();
            }
        }

        protected void go()
        {
            panelLoading.Visible = true;
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            int pageidx = 0;
            if (txtPage.Text == null)
            {
                txtPage.Text = "1";
                pageidx = 1;
            }
            else
            {
                int.TryParse(txtPage.Text.ToString(), out pageidx);
            }
            pageidx--;
            if (pageidx < 0) pageidx = 0;
            

            String key = txtKey.Text.Trim();
            Page<ArchiveBean> p = new Page<ArchiveBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;


            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            object obj = dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
            if (obj == null) return;
            int id = 0;
            int.TryParse(obj.ToString(), out id);
            if (id == 0) return;

            FormEditArchive form = new FormEditArchive(id);
            form.ShowDialog();

        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String key = txtKey.Text.Trim();
                Go(0, pagesize, key);
            }
        }

        private void FormList_SizeChanged(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        protected void changeBarLocation()
        {
            int x = (panel1.Width - txtKey.Width - btnGo.Width - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);

            x = x + txtKey.Width + 8;
            btnGo.Location = new Point(x, txtKey.Location.Y);          

        }

        private void FormList_Load(object sender, EventArgs e)
        {
            
        }

        private void FormList_Shown(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        //private void btnConfig_Click(object sender, EventArgs e)
        //{
        //    btnConfigOk.Visible = btnConfigCancel.Visible = true;
        //    btnConfig.Visible = false;
        //    dataGridView1.Columns["ckbselect"].Visible = true;    
        //}

        //private void btnConfigCancel_Click(object sender, EventArgs e)
        //{
        //    btnConfigOk.Visible = btnConfigCancel.Visible = false;
        //    btnConfig.Visible = true;
        //    dataGridView1.Columns["ckbselect"].Visible = false;
                
        //}

        //private void btnConfigOk_Click(object sender, EventArgs e)
        //{
        //    FormBoxList form = new FormBoxList();
        //    form.WindowState = FormWindowState.Normal;
        //    form.StartPosition = FormStartPosition.CenterParent;
        //    form.ShowDialog();
        //}
    }
}
