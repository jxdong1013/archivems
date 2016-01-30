﻿using System;
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
        protected String _operateType = "";

        public BoxBean SelectedBoxLabel
        {
            get;
            set;
        }

        public FormBoxList()
        {
            InitializeComponent();
        }

        public FormBoxList(string operateType)
        {
            _operateType = operateType;
            InitializeComponent();

            if (_operateType.Equals("档案归盒"))
            {
                dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
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

            if (_operateType.Equals("档案归盒"))
            {
                SelectBoxLabel(bean);
            }
            else
            {
                EditBoxLabel(bean);
            }

        }

        protected void EditBoxLabel( Bean.BoxBean bean )
        {
            FormBoxLabel form = new FormBoxLabel(bean);
            form.OnRefreshData += form_OnRefreshData;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        protected void SelectBoxLabel(BoxBean bean)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectedBoxLabel = bean;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Trim().Equals("lbldelete"))
            {
                Bean.BoxBean bean = dataGridView1.Rows[e.RowIndex].DataBoundItem as Bean.BoxBean;
                if (bean == null) return;
                DialogResult result = MessageBox.Show("您确定要删除名称为【" + bean.name + "】的标签吗？", "询问", MessageBoxButtons.OKCancel);
                if (result != System.Windows.Forms.DialogResult.OK) return;
                DeleteBoxLabel(bean);
            }
        }


        protected void DeleteBoxLabel(Bean.BoxBean bean)
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
            Bean.BoxBean bean = e.Argument as Bean.BoxBean;
            if (bean == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();
            Bean.BoxResult result = wrapper.DeleteBoxLabel(bean);

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
                Bean.BoxResult result = e.Result as Bean.BoxResult;
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

    }
}
