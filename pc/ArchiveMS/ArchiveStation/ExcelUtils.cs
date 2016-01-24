using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using NPOI.SS.UserModel;

namespace ArchiveStation
{
    public class ExcelUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Bean.ArchiveBean> ParseExcel(string filePath)
        {
            FileStream fs = null;   
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                NPOI.SS.UserModel.IWorkbook workbook = null;
                workbook = NPOI.SS.UserModel.WorkbookFactory.Create(fs);

                NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
                if (sheet == null) return null;                  
                NPOI.SS.UserModel.IRow firstRow = sheet.GetRow(0);                    
                int rowCount = sheet.LastRowNum;
                int cellCount = firstRow.LastCellNum;

                List<Bean.ArchiveBean> list = new List<Bean.ArchiveBean>();

                for (int i = sheet.FirstRowNum + 1; i <= rowCount; i++)
                {
                    try
                    {
                        Bean.ArchiveBean model = new Bean.ArchiveBean();

                        NPOI.SS.UserModel.IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                       
                        model.idx = row.GetCell(0) == null ? string.Empty : row.GetCell(0).ToString();
                        model.manager = row.GetCell(1) == null ? string.Empty : row.GetCell(1).ToString();
                        model.title = row.GetCell(2) == null ? string.Empty : row.GetCell(2).ToString();
                        model.pages = row.GetCell(3) == null ? string.Empty : row.GetCell(3).ToString();
                        model.number = row.GetCell(4) == null ? string.Empty : row.GetCell(4).ToString();
                        model.remark = row.GetCell(5) == null ? string.Empty : row.GetCell(5).ToString();
                                          

                        if (CheckEmptyLine( model )) continue; 

                        list.Add(model);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteException(ex);
                        throw ex;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
        }

        protected static int ParseInt( object temp)
        {
            if (temp == null) return 0;
            int i = 0;
            int.TryParse(temp.ToString(), out i);
            return i;
        }

        protected static void CreateCell(IRow row, int cellIdx, string txt, CellType type = CellType.String, ICellStyle style = null)
        {
            ICell cell = row.CreateCell(cellIdx, type);
            if (style != null) cell.CellStyle = style;
            cell.SetCellValue(txt);     
        }

        public static MemoryStream RenderToExcel(List<Bean.ArchiveBean> list)
        {   
            MemoryStream ms = new MemoryStream();

            NPOI.SS.UserModel.IWorkbook workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("sheet1");

            #region head row
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            //row.RowStyle = style;
            row.Height = 26 * 20;

            CreateCell(row, 0, "序号", CellType.String, style);
            CreateCell(row, 1, "责任人", CellType.String, style);
            CreateCell(row, 2, "文件题目", CellType.String, style);
            CreateCell(row, 3, "页数", CellType.String, style);
            CreateCell(row, 4, "编号", CellType.String, style);
            CreateCell(row, 5, "备注", CellType.String, style);         
            #endregion

            if (list != null && list.Count > 0)
            {
                int rowidx = 0;
                foreach (Bean.ArchiveBean model in list)
                {
                    #region row
                    rowidx++;
                    row = sheet.CreateRow(rowidx);
                    CreateCell(row, 0, model.idx);
                    CreateCell(row, 1, model.manager);
                    CreateCell(row, 2, model.title);
                    CreateCell(row, 3, model.pages);
                    CreateCell(row, 4, model.number);
                    CreateCell(row, 5, model.remark);
                    
               
                    #endregion
                }
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        public static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();

                data = null;
            }
        }

        //public static void RenderToBrowser(List<Models.Beans.Contract> list, HttpContextBase context, string fileName)
        //{
        //    MemoryStream ms = RenderToExcel(list);
        //    if (context.Request.Browser.Browser == "IE")
        //        fileName = HttpUtility.UrlEncode(fileName);
        //    context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        //    context.Response.BinaryWrite(ms.ToArray());
        //    if (ms != null)
        //    {
        //        ms.Close();
        //        ms = null;
        //    }
        //}


        protected static bool CheckEmptyLine( Bean.ArchiveBean model )
        {
            return string.IsNullOrEmpty(model.idx) &&
                string.IsNullOrEmpty(model.manager) &&
                string.IsNullOrEmpty(model.title) &&
                string.IsNullOrEmpty(model.pages) &&
                string.IsNullOrEmpty(model.remark) &&
                string.IsNullOrEmpty(model.number);                                
        
        }
    }
}