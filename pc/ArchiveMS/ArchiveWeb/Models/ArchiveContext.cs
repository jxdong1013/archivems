using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using ContractMvcWeb.Models.Beans;

namespace ContractMvcWeb.Models
{
    public class ArchiveContext
    {
        public Page<Archive> QueryByPage(Archive query, int pageidx, int pagesize = 20)
        {
            Page<Archive> page = new Page<Archive>();
            page.PageIdx = pageidx;
            page.PageSize = pagesize;            

            string where = GetWhere(query);
            string limit = string.Format( " limit {0} , {1}" , pageidx <0 ? 0 : pageidx* pagesize , pagesize );
            string orderby = "order by operatetime asc , id asc";
            string sql = string.Format( "select count(1) from v_archive where {0} " , where );
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle( sql );
            if( obj ==null ) totalrecord =0;
            int.TryParse ( obj.ToString () , out totalrecord );
            int totalPages = 0;
            totalPages = totalrecord / pagesize ;
            totalPages += totalrecord% pagesize == 0? 0: 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format ( " select * from v_archive where {0} {1} {2}", where , orderby , limit );
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return page;
            int count = ds.Tables[0].Rows.Count;
            List<Archive> list = new List<Archive>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                Archive model = DataRowToArchive(row);
                list.Add( model );
            }
            page.Data = list;      
            return page;
        }

        public static Archive DataRowToArchive(DataRow row)
        {
            Archive model = new Archive();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.idx = row["idx"].ToString();
            model.manager = row["manager"].ToString();
            model.title = row["title"].ToString();
            model.pages = row["pages"].ToString();
            model.number = row["number"].ToString();
            if (row.Table.Columns.Contains("remark"))
            {
                model.remark = row["remark"].ToString();
            }
            if (row.Table.Columns.Contains("operateman"))
            {
                model.operateman = row["operateman"].ToString();
            }
            if (row.Table.Columns.Contains("operatetime"))
            {
                model.operatetime = DateTime.Parse(row["operatetime"].ToString());
            }
            if (row.Table.Columns.Contains("position"))
            {
                model.position = row["position"].ToString();
            }
            if (row.Table.Columns.Contains("floorrfid"))
            {
                model.floorrfid = row["floorrfid"].ToString();
            }

            if (row.Table.Columns.Contains("boxname"))
            {
                model.boxname = row["boxname"].ToString();
            }
            if (row.Table.Columns.Contains("boxrfid"))
            {
                model.boxrfid = row["boxrfid"].ToString();
            }
            if (row.Table.Columns.Contains("boxnumber"))
            {
                model.boxnumber = row["boxnumber"].ToString();
            }
            if (row.Table.Columns.Contains("status"))
            {
                model.status = Convert.ToInt32( row["status"].ToString());
            }
            if (row.Table.Columns.Contains("statusname"))
            {
                model.statusname = row["statusname"].ToString();
            }
            if(row.Table.Columns.Contains("lastborrowtime"))
            {
                DateTime t;
                if( DateTime.TryParse( row["lastborrowtime"].ToString(), out t)){
                    model.lastborrowtime = t;
                }
            }
            return model;
        }

        public List<Archive> Query(Archive query)
        {
            string where = GetWhere(query);
            string orderby = "order by operatetime desc";
            string sql = string.Format(" select * from t_archive where {0} {1}", where, orderby);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return null;
            int count = ds.Tables[0].Rows.Count;
            List<Archive> list = new List<Archive>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                Archive model = DataRowToArchive(row);
                list.Add(model);
            }
            return list;
        }

        protected string GetWhere(Archive query)
        {
            query.manager = FilterSpecial(query.manager);
            query.title = FilterSpecial(query.title);
            query.number = FilterSpecial(query.number);
            query.floorrfid = FilterSpecial(query.floorrfid);
            query.boxrfid = FilterSpecial(query.boxrfid);

            string where = "";
            if (string.IsNullOrEmpty(query.manager) == false)
            {
                if (string.IsNullOrEmpty(where) == false ) where += " or ";
                where += "  manager like '%" + query.manager + "%'";
            }
            if (string.IsNullOrEmpty(query.title) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                where += string.Format("  title like '%{0}%'", query.title);
            }
            if (string.IsNullOrEmpty(query.number) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                where += string.Format(" number like '%{0}%' ", query.number);
            }

            if (string.IsNullOrEmpty(query.floorrfid) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                where += string.Format(" floorrfid = '{0}' ", query.floorrfid);
            }

            if (string.IsNullOrEmpty(query.boxrfid) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                where += string.Format(" boxrfid = '{0}' ", query.boxrfid);
            }

            if (query.shownoposition)
            {
                if (string.IsNullOrEmpty(where) == false)
                {
                    where = " boxid = 0 and ( " + where + " )";
                }
                else
                {
                    where = " boxid=0 ";
                }
            }


            if (string.IsNullOrEmpty(where))
            {
                where = " 1=1 ";
            }

            return where;  
        }

        protected string FilterSpecial(string txt)
        {
            if( string.IsNullOrEmpty (txt )) return txt;
            return txt.Replace("'","");
        }

        public bool AddArchive(Archive model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_archive(");
                strSql.Append("idx, manager,title,pages,number,remark,operateman)");
                strSql.Append(" values (");
                strSql.Append("@idx,@manager,@title,@pages,@number,@remark,@operateman)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@idx", MySqlDbType.VarChar,45),
					new MySqlParameter("@manager", MySqlDbType.VarChar,255),
					new MySqlParameter("@title", MySqlDbType.VarChar,255),
					new MySqlParameter("@pages", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,100),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@operateman", MySqlDbType.VarChar,255)
                };
                parameters[0].Value = model.idx;
                parameters[1].Value = model.manager;
                parameters[2].Value = model.title;
                parameters[3].Value = model.pages;
                parameters[4].Value = model.number;
                parameters[5].Value = model.remark;
                parameters[6].Value = model.operateman;
         

                int result = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public bool EditArchiveByManagerTitleNumber(Contract model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_archive set ");
                strSql.Append("idx=@idx,");
                strSql.Append("manager=@manager,");
                strSql.Append("title=@title,");
                strSql.Append("number=@number,");
                strSql.Append("pages=@pages,");
                strSql.Append("remark=@remark");
                strSql.Append(" where manager=@projectnum2 and ");
                strSql.Append(" seq=@seq2");
                MySqlParameter[] parameters = {
					//new MySqlParameter("@contractid", MySqlDbType.Int32,11),
					new MySqlParameter("@seq", MySqlDbType.VarChar,45),
					new MySqlParameter("@contractnum", MySqlDbType.VarChar,45),
					new MySqlParameter("@contractname", MySqlDbType.VarChar,128),
					new MySqlParameter("@contractstate", MySqlDbType.VarChar,45),
					new MySqlParameter("@unshelve", MySqlDbType.VarChar,45),    
				    new MySqlParameter("@projectnum", MySqlDbType.VarChar,45),
					new MySqlParameter("@projectname", MySqlDbType.VarChar,100),
					new MySqlParameter("@projectmanager", MySqlDbType.VarChar,45),
					new MySqlParameter("@tel", MySqlDbType.VarChar,100),
					new MySqlParameter("@depart", MySqlDbType.VarChar,45),
					new MySqlParameter("@linker", MySqlDbType.VarChar,45),
					new MySqlParameter("@paymethod", MySqlDbType.VarChar,45),
					new MySqlParameter("@money", MySqlDbType.VarChar,45),
					new MySqlParameter("@contractplace", MySqlDbType.VarChar,45),
					new MySqlParameter("@contractrfid", MySqlDbType.VarChar,45),
					new MySqlParameter("@bcompany", MySqlDbType.VarChar,45),
					new MySqlParameter("@signingdate", MySqlDbType.VarChar,45),
					new MySqlParameter("@packageName", MySqlDbType.VarChar,100),
					new MySqlParameter("@packageBudget", MySqlDbType.VarChar,45),
					new MySqlParameter("@tendarNum", MySqlDbType.VarChar,45),
					new MySqlParameter("@tendarCompany", MySqlDbType.VarChar,100),
					new MySqlParameter("@tendarStartTime", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone", MySqlDbType.VarChar,45),
					new MySqlParameter("@deliveryTime", MySqlDbType.VarChar,45),
					new MySqlParameter("@inspection", MySqlDbType.VarChar,128),
					new MySqlParameter("@progress", MySqlDbType.VarChar,45),
					new MySqlParameter("@isPayAll", MySqlDbType.VarChar,20),
					new MySqlParameter("@isArmoured", MySqlDbType.VarChar,20),
					new MySqlParameter("@isRefund", MySqlDbType.VarChar,20),
					new MySqlParameter("@remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@operatorId", MySqlDbType.VarChar,45),
					new MySqlParameter("@operatorName", MySqlDbType.VarChar,45),
					//new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@type",MySqlDbType.Int32),
                    new MySqlParameter("@projectnum2", MySqlDbType.VarChar,45),
					new MySqlParameter("@seq2", MySqlDbType.VarChar,100)
                                          };
                //parameters[0].Value = model.contractid;
                parameters[0].Value = model.seq;
                parameters[1].Value = model.contractnum;
                parameters[2].Value = model.contractname;
                parameters[3].Value = model.contractstate;
                parameters[4].Value = model.unshelve;
                parameters[5].Value = model.projectnum;
                parameters[6].Value = model.projectname;
                parameters[7].Value = model.projectmanager;
                parameters[8].Value = model.tel;
                parameters[9].Value = model.depart;
                parameters[10].Value = model.linker;
                parameters[11].Value = model.paymethod;
                parameters[12].Value = model.money;
                parameters[13].Value = model.contractplace;
                parameters[14].Value = model.contractrfid;
                parameters[15].Value = model.bcompany;
                parameters[16].Value = model.signingdate;
                parameters[17].Value = model.packageName;
                parameters[18].Value = model.packageBudget;
                parameters[19].Value = model.tendarNum;
                parameters[20].Value = model.tendarCompany;
                parameters[21].Value = model.tendarStartTime;
                parameters[22].Value = model.phone;
                parameters[23].Value = model.deliveryTime;
                parameters[24].Value = model.inspection;
                parameters[25].Value = model.progress;
                parameters[26].Value = model.isPayAll;
                parameters[27].Value = model.isArmoured;
                parameters[28].Value = model.isRefund;
                parameters[29].Value = model.remark;
                parameters[30].Value = model.operatorId;
                parameters[31].Value = model.operatorName;
                //parameters[33].Value = model.createtime;
                parameters[32].Value = model.modifytime;
                parameters[33].Value = model.type;
                parameters[34].Value = model.projectnum;
                parameters[35].Value = model.seq;


                int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
                      

        public bool EditArchive(Archive model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_archive set ");
            strSql.Append("idx=@idx,");
            strSql.Append("manager=@manager,");
            strSql.Append("title=@title,");
            strSql.Append("pages=@pages,");
            strSql.Append("number=@number,");
            strSql.Append("remark=@remark,");
            strSql.Append("operateman=@operateman,");
            strSql.Append("operatetime=@operatetime");
             strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@idx", MySqlDbType.VarChar,50),
					new MySqlParameter("@manager", MySqlDbType.VarChar,255),
					new MySqlParameter("@title", MySqlDbType.VarChar,255),
					new MySqlParameter("@pages", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,255),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),		
					new MySqlParameter("@operateman", MySqlDbType.VarChar,255),	
                    new MySqlParameter("@operatetime", MySqlDbType.Timestamp),	
                    new MySqlParameter("@id",MySqlDbType.Int32)
            };
            parameters[0].Value = model.idx;
            parameters[1].Value = model.manager;
            parameters[2].Value = model.title;
            parameters[3].Value = model.pages;
            parameters[4].Value = model.number;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.operateman;
            parameters[7].Value = model.operatetime;
            parameters[8].Value = model.id;         
           
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public Archive GetModel(int id)
        {
            string sql = "select * from t_archive where id="+ id ;
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return null;
            DataRow row = ds.Tables[0].Rows[0];
            Archive model = DataRowToArchive(row);
            return model;
        }

        public Archive GetModelEx(int id)
        {
            string sql = "select * from v_archive where id=" + id;
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return null;
            DataRow row = ds.Tables[0].Rows[0];
            Archive model = DataRowToArchive(row);
            return model;
        }


        public Beans.BatchImportResult BatchAddArchives(List<Archive> list , int startLine , string operatorName )
        {
            Beans.BatchImportResult result = null;

            if (list == null || list.Count < 1) return result;


            if (CheckData(list, startLine, out result) == false) return result;

            result = new BatchImportResult();
            result.TotalCount = list.Count;               

            int addcount  =0;  
            int updatecount = 0;
            int fail = 0;
            List<Beans.BatchImportResult.ExcelErrorLine> errLines = new List<BatchImportResult.ExcelErrorLine>();
            int idx = startLine;//1; //因为excel 从第二行开始数据行
            foreach (Archive c in list)
            {           
                idx ++;
                bool isExist = ExistArchive( c.idx , c.manager, c.title, c.number);
                if (isExist)
                {
                    //bool isSuccess = EditContractByProjectNumAndSeq(c); // EditContractByProjectNumAndProjectName(c);
                    //updatecount += isSuccess ? 1 : 0;
                    //fail += isSuccess ? 0 : 1;   
                    fail++;
                    errLines.Add( new BatchImportResult.ExcelErrorLine( idx.ToString() , "数据重复"));
                }
                else
                {
                    c.operateman = operatorName;
                    bool isSuccess = AddArchive(c);
                    addcount += isSuccess ? 1 : 0;
                    fail += isSuccess ? 0 : 1;
                    if (isSuccess == false ) errLines.Add( new BatchImportResult.ExcelErrorLine( idx .ToString () , "新增失败"));
                }
            }

            result.AddCount = addcount;
            result.UpdateCount = updatecount;
            result.FailureCount = fail;
            result.ErrorList = errLines;

            return result;
        }

        
        public bool ExistArchive( string idx , string  manger , string title , String number)
        {
            string sql = string.Format(" select count(1) from t_archive where idx='{0}'and manager='{1}' and title ='{2}' and number='{3}'", idx , manger ,  title , number);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }
              

  
        public bool ExistContract(int  id)
        {
            string sql = string.Format(" select count(1) from t_archive where id={0}", id );
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        //public bool ExistContractNotSelf(string rfid, int contractid)
        //{
        //    string sql = string.Format(" select count(1) from t_contract where contractid != {0} and contractrfid='{1}'", contractid , rfid);
        //    object obj = MySqlHelper.GetSingle(sql);
        //    if (obj == null) return false;
        //    int count = 0;
        //    int.TryParse(obj.ToString(), out count);
        //    return count > 0 ? true : false;
        //}

        public bool DeleteArchives(List<int> ids)
        {
            string idsstr = string.Empty;
            if (ids == null || ids.Count < 1) return false;
            foreach(int id in ids )
            {
                if (string.IsNullOrEmpty(idsstr) == false)
                {
                    idsstr += ",";
                }
                idsstr += id;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_archive where id in ( " + idsstr + " )");      
            int count = MySqlHelper.ExecuteSql(strSql.ToString());
            return count > 0 ?true: false;
        }

        public bool DeleteAllContracts()
        {
            MySqlHelper.ExecuteSql("delete from t_archive");
            return true;
        }

        protected bool CheckData(List<Archive> list , int startLineIndex , out BatchImportResult result )
        {
            result = new BatchImportResult();
            if (list == null) return true;

            result.ErrorList = new List<BatchImportResult.ExcelErrorLine>();
            bool isok = true;
            for (int i = 0; i < list.Count; i++)
            {
                string msg = "";

                if (string.IsNullOrEmpty(list[i].manager))
                {
                    isok = false;
                    msg += "负责人不能空";
                }

                if (string.IsNullOrEmpty(list[i].title))
                {
                    isok = false;
                    msg += "文件题名不能空";
                }

                if (string.IsNullOrEmpty(list[i].number))
                {
                    isok = false;
                    if (msg != "")
                    {
                        msg += ",";
                    }
                    msg += "编号不能空";
                }
                

                if ( msg !="")
                {
                    result.ErrorList.Add(new BatchImportResult.ExcelErrorLine(( startLineIndex + i +1 ).ToString(), msg ));
                }
            }
            return isok;

        }

    }
}