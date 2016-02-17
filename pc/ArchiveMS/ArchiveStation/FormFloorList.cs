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
    public partial class FormFloorList : FormBase
    {
        public int pagesize = Constant.PAGESIZE;

        public FormFloorList()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Page<FloorBean> p = e.Argument as Page<FloorBean>;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            FloorPageResult result = wrapper.QueryFloorByPage(p);

            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                FloorPageResult result = e.Result as FloorPageResult;
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

            Page<FloorBean> p = new Page<FloorBean>();
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
            Page<FloorBean> p = new Page<FloorBean>();
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

            Page<FloorBean> p = new Page<FloorBean>();
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
            Page<FloorBean> p = new Page<FloorBean>();
            p.PageIdx =e.pageidx;
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
          
            Page<FloorBean> p = new Page<FloorBean>();
            p.PageIdx = e.pageidx;
            p.PageSize = pagesize;
            p.Key = key;
         
            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        protected void Go(int pageidx, int pagesize, string key)
        {
            if (backgroundWorker1.IsBusy) return;

            Page<FloorBean> p = new Page<FloorBean>();
            p.PageIdx = pageidx;
            p.PageSize = pagesize;
            p.Key = key;


            lblLoadingText.Text = "正在查询数据，请稍等......";
            panelLoading.Visible = true;
            panelLoading.BringToFront();
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);


            backgroundWorker1.RunWorkerAsync(p);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormFloorLabel form = new FormFloorLabel( null );
            form.StartPosition = FormStartPosition.CenterParent;
            form.OnRefreshData += form_OnRefreshData;
            form.ShowDialog();
        }

        void form_OnRefreshData(object sender, EventArgs e)
        {
            String key = txtKey.Text.Trim();
            Go(0, pagesize, key);
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String key = txtKey.Text.Trim();
                Go(0, pagesize, key);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            Bean.FloorBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.FloorBean;
            if (bean == null) return;

            FormFloorLabel form = new FormFloorLabel(bean);
            form.OnRefreshData += form_OnRefreshData;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              if (e.ColumnIndex < 0|| e.RowIndex< 0 ) return;
              if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lbldelete"))
              {
                  Bean.FloorBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.FloorBean;
                  if( bean==null) return;
                  DialogResult result = MessageBox.Show("您确定要删除名称为【" + bean.name + "】的标签吗？", "询问", MessageBoxButtons.OKCancel);
                  if (result != System.Windows.Forms.DialogResult.OK) return;
                  DeleteFloorLabel(bean);
              }
              else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lblseeboxs"))
              {
                  Bean.FloorBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.FloorBean;
                  if( bean==null) return;
                  FormBoxList form = new FormBoxList();
                  form.WindowState = FormWindowState.Normal;
                  form.StartPosition = FormStartPosition.CenterScreen;
                  form.setFloorRfid(bean.rfid);
                  form.ShowDialog();
              }
        }

        protected void DeleteFloorLabel( Bean.FloorBean bean )
        {
            if (backgroundWorker2.IsBusy) return;

            panelLoading.Visible = true;
            panelLoading.BringToFront();
            lblLoadingText.Text = "正在请求删除操作，请稍等......";
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            backgroundWorker2.RunWorkerAsync(bean);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Bean.FloorBean bean = e.Argument as Bean.FloorBean;
            if( bean ==null ) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            Bean.FloorResult result =  wrapper.DeleteFloorLabel(bean);

            e.Result = result;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("操作失败，请重试");
                    return;
                }
                Bean.FloorResult result = e.Result as Bean.FloorResult;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("操作失败，请重试");
                    return;
                }
                if (result.Code == (int)Bean.Constant.ResultCodeEnum.Error)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show(result.Message);
                    return;
                }

                String key = txtKey.Text.Trim();
                Go(0, Bean.Constant.PAGESIZE, key);

            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                panelLoading.Visible = false;
            }
        }

        private void FormFloorList_SizeChanged(object sender, EventArgs e)
        {
            changeBarLocation();
        }

        protected void changeBarLocation()
        {
            int x = (panel1.Width - txtKey.Width - btnGo.Width - btnAdd.Width- 8 - 8) / 2;
            txtKey.Location = new Point(x, txtKey.Location.Y);

            x = x + txtKey.Width + 8;
            btnGo.Location = new Point(x, txtKey.Location.Y);

            x = x + btnGo.Width + 8;
            btnAdd.Location = new Point(x, txtKey.Location.Y);

            x= (panel2.Width - pageControl1.Width )/2;
            pageControl1.Location = new Point(x, pageControl1.Location.Y);

        }

        private void FormFloorList_Shown(object sender, EventArgs e)
        {
            changeBarLocation();
        }
    }
}
