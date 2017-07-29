using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using ArchiveStation.Bean;
using Newtonsoft.Json;

namespace ArchiveStation
{
    /// <summary>
    /// 打印管理类
    /// </summary>
    public class PrintManager
    {
        /// <summary>
        /// 打印模板文件夹路径
        /// </summary>
        protected string _reportFolder = Application.StartupPath + "\\Templete" ;



        protected string Report_借阅单
        {
            get
            {
                string path = _reportFolder + "\\借阅单.frx";
                return path;
            }
        }


        private static PrintManager _single = null;
        private PrintManager()
        {
            //设置FastReport 打印时不显示进度框
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;
            FastReport.Utils.Config.ReportSettings.ShowPerformance = false;
        }

        public static PrintManager Single
        {
            get
            {
                if (_single == null)
                {
                    _single = new PrintManager();
                }
                return _single;
            }
        }
        /// <summary>
        /// 模板设计器
        /// </summary>
        //public void Desinger(string hospitalId, string hospitalName)
        //{
        //    FormDesigner form = new FormDesigner(hospitalId, hospitalName);
        //    form.Show();
        //}


        public int Print_Borrow(List<PrintBorrowBean> list )
        {
            try
            {
                if (list == null || list.Count < 1) return -2;
                if (System.IO.File.Exists(Report_借阅单) == false) return -1;

                foreach (PrintBorrowBean entity in list)
                {
                    FastReport.Report report = new FastReport.Report();
                    report.Load(Report_借阅单);
                    SetParameters<BorrowerBean , ArchiveBean>(entity.Borrower , entity.ArchiveList , report);
                    PrintReport(report);
                }
                return list.Count;
            }
            catch (System.Drawing.Printing.InvalidPrinterException pex)
            {
                return -4;
            }
            catch (Exception ex)
            {
                return -3;
            }
        }
    
        /// <summary>
        /// 预览 挂号单
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public int Preview_Borrow(List<PrintBorrowBean> list)
        {
            try
            {
                if (list == null || list.Count < 1) return -2;
                if (System.IO.File.Exists(Report_借阅单) == false) return -1;

                FormPreview form = new FormPreview(list, Report_借阅单);
                form.ShowDialog();
                return 0;

            }
            catch (System.Drawing.Printing.InvalidPrinterException pex)
            {
                LogHelper.WriteException(pex);
                return -4;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return -3;
            }
        }

        /// <summary>
        /// 打印预览时，屏蔽打印功能，返回 0张页数
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        protected int PreviewReport(FastReport.Report report)
        {
            try
            {
                //PreviewForm.Report = report;
                //PreviewForm.ShowDialog();
                return 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return -3;
            }
        }

        protected int PrintReport(FastReport.Report report)
        {
            //report.PrintPrepared();
            //report.Prepare();
            //int pagecount = report.PreparedPages.Count;

            //LogHelper.WriteLog("FastReport ShowProgress:" + FastReport.Utils.Config.ReportSettings.ShowProgress);
            //FastReport.Utils.Config.ReportSettings.ShowProgress = false;
            //LogHelper.WriteLog("FastReport ShowProgress:" + FastReport.Utils.Config.ReportSettings.ShowProgress);
            //LogHelper.WriteLog("FastReport WebModel:" + FastReport.Utils.Config.WebMode);
            //FastReport.Utils.Config.WebMode = true;
            //LogHelper.WriteLog("FastReport WebModel:" + FastReport.Utils.Config.WebMode);
            //LogHelper.WriteLog("FastReport ShowPerformance:" + FastReport.Utils.Config.ReportSettings.ShowPerformance);
            //LogHelper.WriteLog("FastReport UseFileCache:" + report.UseFileCache);
                        
            report.PrintSettings.ShowDialog = false;                       
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            report.Print();

            watch.Stop();
            LogHelper.WriteLog("pring() time:" + watch.ElapsedMilliseconds / 1000.00);

            report.Clear();
            report.Dispose();
            report = null;
            //return pagecount;
            return 1;
        }

        protected T GetEntity<T>(string jsonString)
        {
            T entity = default(T);
            try
            {
                entity = JsonConvert.DeserializeObject<T>(jsonString);
                return entity;
            }
            catch
            {
                //return -2;
                return default(T);
            }
        }

        protected List<T> GetEntityList<T>(string jsonString)
        {
            try
            {
                List<T> list = JsonConvert.DeserializeObject<List<T>>(jsonString);
                return list;
            }
            catch( Exception ex )
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        protected void SetParameters<T, H>(T patient, IList<H> chargeItem, FastReport.Report report)
        {
            System.Reflection.PropertyInfo[] properties = patient.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                string name = info.Name;
                object value = info.GetValue(patient, null);
                if (report.Parameters.FindByName(name) != null)
                {
                    report.SetParameterValue(name, value);
                }
            }
            System.Data.DataTable dt = ToDataTable<H>(chargeItem);
            dt.TableName = "detail";
            report.RegisterData(dt, "detail");
        }

        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

    }
}