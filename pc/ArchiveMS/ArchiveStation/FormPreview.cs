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
    /// <summary>
    /// 打印预览窗体
    /// </summary>
    public partial class FormPreview : Form
    {
        /// <summary>
        /// 预览控件
        /// </summary>
        FastReport.Preview.PreviewControl _previewControl = null;
        FastReport.Report _report = null;
        /// <summary>
        /// 预览数据
        /// </summary>
        List<PrintBorrowBean> _list = null;
        string _reportPath = "";

        public FormPreview(List<PrintBorrowBean> list, string reportPath)
        {
            InitializeComponent();

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            _list = list;
            _reportPath = reportPath;
            _previewControl = new FastReport.Preview.PreviewControl();
            _previewControl.Dock = DockStyle.Fill;
            _previewControl.ToolbarVisible = false;
            this.panel2.Controls.Add(_previewControl);

            watch.Stop();
            //TCUtility.LogHelper.WriteLog("pringview:"+ watch.ElapsedMilliseconds/1000.00);

            LoadPagesButton();
        }
        /// <summary>
        /// 
        /// </summary>
        protected void LoadPagesButton()
        {
            panel1.Controls.Clear();
            if (_list == null || _list.Count < 1 ) return;           
            for (int pageid = 0 ; pageid < _list.Count ;pageid ++ )
            {
                PrintBorrowBean entity = _list[pageid];
                Button btnPage = new Button();
                btnPage.Text = "第"+( pageid + 1 ).ToString()+"页";
                btnPage.Tag = entity;
                btnPage.Dock = DockStyle.Left;
                panel1.Controls.Add(btnPage);
                btnPage.Click += new EventHandler(btnPage_Click);
            }
        }

        void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                PrintBorrowBean entity = (sender as Button).Tag as PrintBorrowBean;
                PreivewData(entity);

                foreach (Control ctl in panel1.Controls)
                {
                    Button btn = (ctl as Button);
                    if (btn != null) btn.ForeColor = Color.Black;
                }
                (sender as Button).ForeColor = Color.Red;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        protected void PreivewData(PrintBorrowBean entity)
        {
            if (_report != null)
            {
                _report.Clear();
                _report.Dispose();
                _report = null;
            }

            if (System.IO.File.Exists( _reportPath ) == false) return;
            _report = new FastReport.Report();
            _report.Load( _reportPath );

            BorrowerBean borrower = entity.Borrower;
            System.Reflection.PropertyInfo[] properties = borrower.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                string name = info.Name;
                object value = info.GetValue(borrower, null);
                if (_report.Parameters.FindByName(name) != null)
                {
                    _report.SetParameterValue(name, value);
                }
            }
            System.Data.DataTable dt = PrintManager.ToDataTable<ArchiveBean>( entity.ArchiveList );
            dt.TableName = "detail";
            _report.RegisterData(dt, "detail");

            _report.Preview = _previewControl;
            _report.Prepare();
            _report.ShowPrepared();
        }

        public FastReport.Report Report
        {
            get
            {
                return _report;
            }
            set
            {
                _report = value;
                _report.Preview = _previewControl;
            }
        }

        private void FormPreview_Load(object sender, EventArgs e)
        {
        }

        private void FormPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_report != null)
                {
                    _report.Clear();
                    _report.Dispose();
                    _report = null;
                }

                if (_previewControl != null)
                {
                    _previewControl.Clear();
                    _previewControl.Dispose();
                    _previewControl = null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        private void FormPreview_Shown(object sender, EventArgs e)
        {
            //_report.Prepare();
            //_report.ShowPrepared();
            try
            {
                panel1.Visible = false;
                Cursor = Cursors.WaitCursor;
                if (_list == null || _list.Count < 1) return;
                if (_list.Count == 1)
                {
                    panel1.Visible = false;
                }
                else
                {
                    panel1.Visible = true;
                }
                if (panel1.Controls.Count > 0 && panel1.Controls[0] is Button)
                {
                    btnPage_Click((panel1.Controls[0] as Button), EventArgs.Empty);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            } 
        }
    }
}
