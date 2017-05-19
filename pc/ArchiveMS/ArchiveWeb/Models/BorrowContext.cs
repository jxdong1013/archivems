using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractMvcWeb.Models.Beans;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace ContractMvcWeb.Models
{
    public class BorrowContext
    {
        public void  Borrow(List<string> archiveIdList , int borrowerid , string operatename , int operateid )
        {
            foreach (string aid in archiveIdList)
            {
                Borrow b = new Beans.Borrow();
                b.borrowerid = borrowerid;
                b.archiveid = Convert.ToInt32( aid );
                b.createtime = DateTime.Now;
                b.operatorid = operateid;
                b.operatorname = operatename;
                b.status = (int)Constant.ArchiveStatusEnum.借出;
                
                int borrowid = AddBorrowLog(b);
                b.borrowid = borrowid;

                int count = UpdateArchiveBorrowStatus(b.archiveid , borrowerid, (int)Constant.ArchiveStatusEnum.借出 , borrowid );
            }
        }


        public void Return(List<string> archiveList,  string operatename, int operateid)
        {
            for (int i = 0; i < archiveList.Count; i++)
            {
                Borrow b = new Beans.Borrow();
                b.borrowerid = 0;//returner[i];
                b.archiveid = Convert.ToInt32(archiveList[i]);
                b.createtime = DateTime.Now;
                b.operatorid = operateid;
                b.operatorname = operatename;
                b.status = (int)Constant.ArchiveStatusEnum.在库;

                int borrowid = AddBorrowLog(b);
                b.borrowid = borrowid;

                int count = UpdateArchiveReturnStatus(b.archiveid , (int)Constant.ArchiveStatusEnum.在库 );
            }
        }
        


        public int AddBorrowLog( Borrow model )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_borrow(");
            strSql.Append("archiveid,borrowerid,status,createtime,operatorid,operatorname)");
            strSql.Append(" values (");
            strSql.Append("@archiveid,@borrowerid,@status,@createtime,@operatorid,@operatorname);select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("@archiveid", MySqlDbType.Int32,20),
					new MySqlParameter("@borrowerid", MySqlDbType.Int32,11),
					new MySqlParameter("@status", MySqlDbType.Int32,11),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@operatorid", MySqlDbType.Int32,11),
					new MySqlParameter("@operatorname", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.archiveid;
            parameters[1].Value = model.borrowerid;
            parameters[2].Value = model.status;
            parameters[3].Value = model.createtime;
            parameters[4].Value = model.operatorid;
            parameters[5].Value = model.operatorname;

            return Convert.ToInt32( MySqlHelper.GetSingle(strSql.ToString(), parameters));
         
        }

        public int UpdateArchiveBorrowStatus(int archiveid , int borrowerid, int status , int borrowid )
        {
            string sql = string.Format("update t_archive set status=@status, borrowid=@borrowid where id=@archiveid");
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@status", MySqlDbType.Int16),                   
                                             new MySqlParameter("@borrowid",MySqlDbType.Int32),
                                             new MySqlParameter("@archiveid", MySqlDbType.Int32),
                                        };
            parameters[0].Value = status;    
            parameters[1].Value = borrowid;
            parameters[2].Value = archiveid;

            int count = MySqlHelper.ExecuteSql(sql, parameters);
            return count;
        }

        public int UpdateArchiveReturnStatus(int archiveid, int status)
        {
            string sql = string.Format("update t_archive set status=@status , borrowid=@borrowid where id=@archiveid");
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@status", MySqlDbType.Int16),  
                                             new MySqlParameter("@borrowid", 0),
                                             new MySqlParameter("@archiveid", MySqlDbType.Int32),
                                        };
            parameters[0].Value = status;
            parameters[1].Value = archiveid;

            int count = MySqlHelper.ExecuteSql(sql, parameters);
            return count;
        }


        public Page<BorrowLogBean> Log(BorrowLogBean query, int pageidx, int pagesize = 20)
        {
            Page<BorrowLogBean> page = new Page<BorrowLogBean>();
            page.PageIdx = pageidx;
            page.PageSize = pagesize;

            string where = GetWhere(query);
            string limit = string.Format(" limit {0} , {1}", pageidx < 0 ? 0 : pageidx * pagesize, pagesize);
            string orderby = "";//"order by operatetime desc , id desc";
            string sql = string.Format("select count(1) from v_borrow where {0} ", where);
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) totalrecord = 0;
            int.TryParse(obj.ToString(), out totalrecord);
            int totalPages = 0;
            totalPages = totalrecord / pagesize;
            totalPages += totalrecord % pagesize == 0 ? 0 : 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format(" select * from v_borrow where {0} {1} {2}", where, orderby, limit);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return page;
            int count = ds.Tables[0].Rows.Count;
            List<BorrowLogBean> list = new List<BorrowLogBean>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                BorrowLogBean model = DataRowToBorrowLog(row);
                list.Add(model);
            }
            page.Data = list;
            return page;
        }

        private string GetWhere(BorrowLogBean parameter)
        {
            string wherestr = " 1=1 ";
            if (parameter != null)
            {
                if (!string.IsNullOrEmpty(parameter.boxnumber))
                {
                    wherestr += string.Format(" and boxnumber like '%{0}%' ", parameter.boxnumber);
                }
                if (!string.IsNullOrEmpty(parameter.floornumber))
                {
                    wherestr += string.Format(" and floornumber like '%{0}%'", parameter.floornumber);
                }
                if (!string.IsNullOrEmpty(parameter.borrowername))
                {
                    wherestr += string.Format(" and borrowername like '%{0}%'", parameter.borrowername);
                }
                if (!string.IsNullOrEmpty(parameter.idcard))
                {
                    wherestr += string.Format(" and idcard like '%{0}%'", parameter.idcard);
                }
                if (!string.IsNullOrEmpty(parameter.department))
                {
                    wherestr += string.Format(" and department like '%{0}%'", parameter.department);
                }
                if (!string.IsNullOrEmpty(parameter.title))
                {
                    wherestr += string.Format(" and title like '%{0}%'", parameter.title);
                }
                if (!string.IsNullOrEmpty(parameter.number))
                {
                    wherestr += string.Format(" and number like '%{0}%'", parameter.number);
                }
                if (!string.IsNullOrEmpty(parameter.manager))
                {
                    wherestr += string.Format(" and manager like '%{0}%'", parameter.manager);
                }
                if (parameter.status >= 0)
                {
                    wherestr += string.Format(" and status = {0}", parameter.status);
                }

            }
            return wherestr;
        }

        private BorrowLogBean DataRowToBorrowLog(DataRow row)
        {
            BorrowLogBean bean = new BorrowLogBean();
            bean.borrowername = row["borrowername"].ToString();
            DateTime temp;
            if( DateTime.TryParse( row["createtime"].ToString() , out temp)){
                bean.createtime = temp;
            }
            int boxid =0;
            if (int.TryParse(row["boxid"].ToString() , out boxid))
            {
                bean.boxid = boxid;
            }
            //bean.boxname = row["boxname"].ToString();
            bean.boxnumber = row["boxnumber"].ToString();
            bean.department = row["department"].ToString();
            bean.idcard = row["idcard"].ToString();
            bean.operatorname = row["operatorname"].ToString();
            bean.position = row["position"].ToString();
            bean.status = Convert.ToInt32(row["status"]);
            if (row.Table.Columns.Contains("statusname"))
            {
                bean.statusname = row["statusname"].ToString();
            }
            bean.floornumber = row["floornumber"].ToString();
            bean.id = Convert.ToInt32(row["id"]);
            bean.idx = row["idx"].ToString();
            bean.manager = row["manager"].ToString();
            bean.number = row["number"].ToString();
            bean.pages = row["pages"].ToString();
            bean.position = row["position"].ToString();
            bean.title = row["title"].ToString();
            

            return bean;
        }



        public List<BorrowLogBean> GetArchiveListByBorrower(int borrowerid, int status)
        {
            //string sql = "select a.* from t_archive a inner join t_borrow b on a.borrowid=b.borrowid where b.borrowerid=@borrowerid and a.status=@status";
            string sql = "select * from v_borrow where borrowerid=@borrowerid and status=@status";


            MySqlParameter[] parameters ={
                                             new MySqlParameter("@borrowerid", MySqlDbType.Int32),
                                             new MySqlParameter("@status",status)
                                        };
            parameters[0].Value = borrowerid;

            DataSet ds = MySqlHelper.Query(sql, parameters);
            List<BorrowLogBean> list = new List<BorrowLogBean>();
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    BorrowLogBean model = this.DataRowToBorrowLog(ds.Tables[0].Rows[i]);
                    list.Add(model);
                }
            }

            return list;
        }

    }
}