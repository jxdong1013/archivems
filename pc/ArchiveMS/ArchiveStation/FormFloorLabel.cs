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
    public partial class FormFloorLabel : FormBase
    {
        public event EventHandler OnRefreshData;
        private Bean.FloorBean _bean;

        public FormFloorLabel( Bean.FloorBean bean)
        {
            InitializeComponent();

            this._bean = bean;
            if (this._bean != null)
            {
                txtName.Text = _bean.name;
                txtNumber.Text = _bean.number;
                txtRFID.Text = _bean.rfid;
            }

        }

        protected void Go()
        {
            lblOne.Text = lblTwo.Text = "";
            bool isPass = true;
            if (String.IsNullOrEmpty(txtName.Text))
            {
                isPass = false;
                txtName.Focus();
                lblOne.Text = "请输入名称";
                lblOne.Visible = true;
            }
            if (String.IsNullOrEmpty(txtRFID.Text))
            {
                isPass = false;
                txtRFID.Focus();
                lblTwo.Visible = true;
                lblTwo.Text = "请扫描标签";
            }
            if (!isPass)
            {
                return;
            }

            if (_bean == null)
            {
                _bean = new Bean.FloorBean();
            }

            _bean.name = txtName.Text.Trim();
            _bean.rfid = txtRFID.Text.Trim();
            _bean.number = txtNumber.Text.Trim();

            if (backgroundWorker1.IsBusy) return;

            this.lblOne.Text = "";
            this.lblTwo.Text = "";
            this.panelLoading.Visible = true;
            this.panelLoading.BringToFront();
            this.lblLoadingText.Text = "正在请求操作，请稍等......";
            this.panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);

            backgroundWorker1.RunWorkerAsync(_bean);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                FloorResult result = e.Result as FloorResult;
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
                    txtRFID.Focus();
                    return;
                }

                if (OnRefreshData != null)
                {
                    OnRefreshData(this, EventArgs.Empty);
                }
                panelLoading.Visible = false;
                    
                MessageBox.Show( result.Message );

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bean.FloorBean p = e.Argument as Bean.FloorBean;
            if (p == null) return;

            HttpUtilWrapper wrapper = new HttpUtilWrapper();

            Bean.FloorResult result = wrapper.EditFloorLabel(p);

            e.Result = result;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Go();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
