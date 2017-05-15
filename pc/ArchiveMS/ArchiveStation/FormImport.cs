using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormImport : FormBase
    {
        public FormImport()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String filepath = e.Argument.ToString();
            List<Bean.ArchiveBean> list = ExcelUtils.ParseExcel( filepath);

            HttpUtilWrapper httpUtil = new HttpUtilWrapper();

           Bean.ImportArchiveResult result = new Bean.ImportArchiveResult();
            result.Data = new Bean.ImportResult();
            result.Data.AddCount = 0;
            result.Data.ErrorList = new List<Bean.ImportResult.ExcelErrorLine>();
            result.Data.TotalCount=0;
            result.Data.UpdateCount = 0;

            int percent = 0;
            int pagecount = 50;
            int count = list.Count / pagecount;
            int mod = list.Count % pagecount;
            count += mod>0 ? 1:0;
            int startLine = 1;
            List<Bean.ArchiveBean> temp = new List<Bean.ArchiveBean>();
            for (int i = 0; i < count; i++)
            {
                percent = i % count;
                backgroundWorker1.ReportProgress(percent);

                temp.Clear();
                for (int k = i * pagecount; (k< (i+1)*pagecount && k < list.Count); k++)
                {
                    temp.Add(list[k]);
                }
                Bean.ImportArchiveResult bResult = httpUtil.ImportArchive(temp, startLine, Bean.Variable.User.username);
                if ( bResult !=null && bResult.Code == (int)Bean.Constant.ResultCodeEnum.Error)
                {
                    result.Code = (int)Bean.Constant.ResultCodeEnum.Error;
                    result.Message = bResult.Message;
                    e.Result = result;
                    return;
                }

                if (bResult != null && bResult.Data !=null)
                {
                    result.Data.TotalCount += temp.Count;
                    result.Data.AddCount += bResult.Data.AddCount;
                    result.Data.UpdateCount += bResult.Data.UpdateCount;
                    result.Data.FailureCount += bResult.Data.FailureCount;
                    result.Data.ErrorList.AddRange(bResult.Data.ErrorList);
                }
                startLine += pagecount;

            }

            e.Result = result;

            percent = 100;
            backgroundWorker1.ReportProgress(percent);
             
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
            lblLoadingText.Text = "完成"+ e.ProgressPercentage+"%";
            //progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBar1.Visible = false;
            label1.Visible = false;
            label1.Text = "";
            //listBox1.Dock = DockStyle.Fill;
            //listBox1.Visible = true;

            try
            {

                Bean.ImportArchiveResult result = e.Result as Bean.ImportArchiveResult;
                if (result == null)
                {
                    panelLoading.Visible = false;
                    MessageBox.Show("导入出现异常，请重新导入！");
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("总共条数：" + result.Data.TotalCount);
                    listBox1.Items.Add("新增条数：" + result.Data.AddCount);
                    listBox1.Items.Add("更新条数：" + result.Data.UpdateCount);
                    listBox1.Items.Add("失败条数：" + result.Data.FailureCount);
                    for (int i = 0; i < result.Data.ErrorList.Count; i++)
                    {
                        listBox1.Items.Add("行号：" + result.Data.ErrorList[i].Line + ",原因：" + result.Data.ErrorList[i].Error);
                    }
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

        private void FormImport_Load(object sender, EventArgs e)
        {    
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "(*.*)|*.xls;*.xlsx|(*.xls)|*.xls|(*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                return;
            }

            if (backgroundWorker1.IsBusy) return;

            listBox1.Items.Clear();
            panelLoading.Visible = true;
            panelLoading.BringToFront();
            lblLoadingText.Text = "正在导入数据，请稍等......";
            panelLoading.Location = new Point((this.Width / 2 - this.panelLoading.Width / 2), this.Height / 2 - this.panelLoading.Height - 20);
        
            backgroundWorker1.RunWorkerAsync(dialog.FileName);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Export();
        }

        protected void Export()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.xls|*.xls";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            string path = dialog.FileName;
            String sPath = Application.StartupPath + "\\Templete\\templete.xls";
            System.IO.File.Copy(sPath, path);
        }

    }
}
