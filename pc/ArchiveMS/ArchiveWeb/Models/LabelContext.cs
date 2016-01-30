using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Web;
using ContractMvcWeb.Models.Beans;
using MySql.Data.MySqlClient;

namespace ContractMvcWeb.Models
{
    public class LabelContext
    {
        public Page<FloorLabel> QueryFloorByPage(FloorLabel query, int pageidx, int pagesize = 20)
        {
            Page<FloorLabel> page = new Page<FloorLabel>();
            page.PageIdx = pageidx;
            page.PageSize = pagesize;            

            string where = GetWhere(query);
            string limit = string.Format( " limit {0} , {1}" , pageidx <0 ? 0 : pageidx* pagesize , pagesize );
            string orderby = "";//"order by operatetime desc , id desc";
            string sql = string.Format( "select count(1) from t_floorlabel where {0} " , where );
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle( sql );
            if( obj ==null ) totalrecord =0;
            int.TryParse ( obj.ToString () , out totalrecord );
            int totalPages = 0;
            totalPages = totalrecord / pagesize ;
            totalPages += totalrecord% pagesize == 0? 0: 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format(" select * from t_floorlabel where {0} {1} {2}", where, orderby, limit);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return page;
            int count = ds.Tables[0].Rows.Count;
            List<FloorLabel> list = new List<FloorLabel>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                FloorLabel model = DataRowToFloorLabel(row);
                list.Add( model );
            }
            page.Data = list;      
            return page;
        }


        protected FloorLabel DataRowToFloorLabel(DataRow row)
        {
            FloorLabel model = new FloorLabel();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.name = row["name"].ToString();
            model.rfid = row["rfid"].ToString();
            model.number = row["number"].ToString();
      
            return model;
        }

        protected string GetWhere(FloorLabel query)
        {
            query.name = FilterSpecial(query.name);
            query.rfid = FilterSpecial(query.rfid);
       
            string where = " 1=1 ";
            if (string.IsNullOrEmpty(query.name) == false)
            {
                where += " and name like '%" + query.name + "%'";
            }
            if (string.IsNullOrEmpty(query.rfid) == false)
            {
                where += string.Format(" and rfid like '%{0}%'", query.rfid);
            }
            
            return where;
        }

        protected string FilterSpecial(string txt)
        {
            if (string.IsNullOrEmpty(txt)) return txt;
            return txt.Replace("'", "");
        }

        public bool ExistFloorLabel(String rfid)
        {
            try
            {
                String sql = String.Format(" select count(1) from t_floorlabel where rfid='{0}'", rfid);
                object obj = MySqlHelper.GetSingle(sql);
                if (obj == null) return false;
                int count = 0;
                int.TryParse(obj.ToString(), out count);
                return count > 0 ? true : false;
            }
            catch (Exception ex)
            {               
                return false;
            }
        }

        public bool ExistFloorLabel(string rfid, int id)
        {
            string sql = string.Format(" select count(1) from t_floorlabel where rfid='{0}' and id != {1}", rfid, id);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count  = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool ExistBoxsOfFloorLabel(int id)
        {
            String sql = string.Format(" select count(1) from t_boxlabel where floorid =" + id);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool ExistArchivesOfBoxLabel(int id)
        {
            String sql = string.Format(" select count(1) from t_archive where  boxid =" + id);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool AddFloorLabel(FloorLabel model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_floorlabel(");
                strSql.Append(" name,rfid, number)");
                strSql.Append(" values (");
                strSql.Append("@name,@rfid,@number)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@rfid", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,100)
                };
                parameters[0].Value = model.name;
                parameters[1].Value = model.rfid;
                parameters[2].Value = model.number;


                int result = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditFloorLabel(FloorLabel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_floorlabel set ");
            strSql.Append(" name=@name,");
            strSql.Append(" rfid=@rfid,");
            strSql.Append(" number=@number");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@rfid", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,100),
                    new MySqlParameter("@id",MySqlDbType.Int32)
            };
            parameters[0].Value = model.name;
            parameters[1].Value = model.rfid;
            parameters[2].Value = model.number;
            parameters[3].Value = model.id;

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

        public bool DeleteFloorLabel(int id)
        {
            string sql = string.Format(" delete from t_floorlabel where id = "+ id );
            int count = MySqlHelper.ExecuteSql(sql);
            return count > 0 ? true : false;
        }

        public bool ExistBoxLabel(string rfid)
        {
            String sql = string.Format( "select count(1) from t_boxlabel where rfid='{0}'", rfid);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool ExistBoxLabel(string rfid, int id)
        {
            String sql = string.Format("select count(1) from t_boxlabel where rfid='{0}' and id != {1}", rfid , id );
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool AddBoxLabel(BoxLabel model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_boxlabel(");
                strSql.Append(" name,rfid, number)");
                strSql.Append(" values (");
                strSql.Append("@name,@rfid,@number)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@rfid", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,100)
                };
                parameters[0].Value = model.name;
                parameters[1].Value = model.rfid;
                parameters[2].Value = model.number;


                int result = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditBoxLabel(BoxLabel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_boxlabel set ");
            strSql.Append(" name=@name,");
            strSql.Append(" rfid=@rfid,");
            strSql.Append(" number=@number");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@rfid", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,100),
                    new MySqlParameter("@id",MySqlDbType.Int32)
            };
            parameters[0].Value = model.name;
            parameters[1].Value = model.rfid;
            parameters[2].Value = model.number;
            parameters[3].Value = model.id;

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

        public bool DeleteBoxLabel(int id)
        {
            string sql = string.Format(" delete from t_boxlabel where id = " + id);
            int count = MySqlHelper.ExecuteSql(sql);
            return count > 0 ? true : false;
        }

        protected string GetWhere(BoxLabel query)
        {
            query.name = FilterSpecial(query.name);
            query.rfid = FilterSpecial(query.rfid);

            string where = " 1=1 ";
            if (string.IsNullOrEmpty(query.name) == false)
            {
                where += " and name like '%" + query.name + "%'";
            }
            if (string.IsNullOrEmpty(query.rfid) == false)
            {
                where += string.Format(" and rfid like '%{0}%'", query.rfid);
            }

            return where;
        }
    
        protected BoxLabel DataRowToBoxLabel(DataRow row)
        {
            BoxLabel model = new BoxLabel();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            model.name = row["name"].ToString();
            model.rfid = row["rfid"].ToString();
            model.number = row["number"].ToString();

            return model;
        }

        public Page<BoxLabel> QueryBoxByPage(BoxLabel query, int pageidx, int pagesize = 20)
        {
            Page<BoxLabel> page = new Page<BoxLabel>();
            page.PageIdx = pageidx;
            page.PageSize = pagesize;

            string where = GetWhere(query);
            string limit = string.Format(" limit {0} , {1}", pageidx < 0 ? 0 : pageidx * pagesize, pagesize);
            string orderby = "";//"order by operatetime desc , id desc";
            string sql = string.Format("select count(1) from t_boxlabel where {0} ", where);
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) totalrecord = 0;
            int.TryParse(obj.ToString(), out totalrecord);
            int totalPages = 0;
            totalPages = totalrecord / pagesize;
            totalPages += totalrecord % pagesize == 0 ? 0 : 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format(" select * from t_boxlabel where {0} {1} {2}", where, orderby, limit);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return page;
            int count = ds.Tables[0].Rows.Count;
            List<BoxLabel> list = new List<BoxLabel>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                BoxLabel model = DataRowToBoxLabel(row);
                list.Add(model);
            }
            page.Data = list;
            return page;
        }


        public bool ArchiveToBox(List<int> archiveids, int boxid)
        {
            try
            {
                String ids = "";
                System.Collections.ArrayList sqlList = new System.Collections.ArrayList();
                foreach (int id in archiveids)
                {
                    string sql = string.Format(" update t_archive set boxid={0} where id ={1}", boxid, id);
                    sqlList.Add(sql);
                }
                MySqlHelper.ExecuteSqlTran(sqlList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}