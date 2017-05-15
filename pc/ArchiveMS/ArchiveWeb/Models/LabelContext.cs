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
       
            string where = "";
            if (string.IsNullOrEmpty(query.name) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += "  name like '%" + query.name + "%'";
            }
            if (string.IsNullOrEmpty(query.rfid) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += string.Format("  rfid like '%{0}%'", query.rfid);
            }

            if (string.IsNullOrEmpty(where) ) where += " 1=1 ";

            
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

        public bool ExistFloorLabelByName( string name )
        {
            string sql = string.Format(" select count(1) from t_floorlabel where name ='{0}' ", name );
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }

        public bool ExistFloorLabelByName(string name, int id)
        {
            string sql = string.Format(" select count(1) from t_floorlabel where name ='{0}' and id != {1}", name , id );
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
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

        public bool ExistBoxsOfFloorLabel(string rfid)
        {
            String sql = string.Format(" select count(1) from t_position where floorrfid ='{0}'" , rfid);
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

        public bool DeleteFloorLabel(string rfid)
        {
            string sql = string.Format(" delete from t_floorlabel where rfid = '{0}' " , rfid);
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

        public bool ExistBoxLabelByName(string name)
        {
            String sql = string.Format("select count(1) from t_boxlabel where name='{0}'",  name );
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count > 0 ? true : false;
        }


        public bool ExistBoxLabelByName(string name , int id )
        {
            String sql = string.Format("select count(1) from t_boxlabel where name='{0}' and id != {1}", name , id );
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
            query.floorrfid = FilterSpecial(query.floorrfid);

            string where = "";
            if (string.IsNullOrEmpty(query.name) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += "  name like '%" + query.name + "%'";
            }
            if (string.IsNullOrEmpty(query.rfid) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += string.Format("  rfid like '%{0}%'", query.rfid);
            }
            if (string.IsNullOrEmpty(query.floorrfid) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += string.Format("  floorrfid = '{0}'", query.floorrfid);
            }

            if (string.IsNullOrEmpty(where) ) where = " 1=1 ";


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

            if (row.Table.Columns.Contains("floorrfid"))
            {
                model.floorrfid = row["floorrfid"].ToString();
            }
            if (row.Table.Columns.Contains("floorname"))
            {
                model.floorname = row["floorname"].ToString();
            }
            if (row.Table.Columns.Contains("count"))
            {
                model.count = Convert.ToInt32( row["count"]);
            }

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
            string sql = string.Format("select count(1) from v_box where {0} ", where);
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) totalrecord = 0;
            int.TryParse(obj.ToString(), out totalrecord);
            int totalPages = 0;
            totalPages = totalrecord / pagesize;
            totalPages += totalrecord % pagesize == 0 ? 0 : 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format(" select * from v_box where {0} {1} {2}", where, orderby, limit);
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


        public List<BoxLabel> GetBoxListOfFloor(String rfid)
        {
            try
            {
                String sql = " select a.id,a.name,a.rfid , a.number  from t_boxlabel a INNER JOIN t_position b on a.id= b.boxid ";
                sql +=" INNER JOIN t_floorlabel c on b.floorid = c.id where c.rfid= '"+ rfid +"'";

                DataSet ds = MySqlHelper.Query(sql);
                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return null;
                int count = ds.Tables[0].Rows.Count;
                List<BoxLabel> list = new List<BoxLabel>();
                for (int i = 0; i < count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    BoxLabel model = DataRowToBoxLabel(row);
                    list.Add(model);
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UploadBoxListOfFloor(string rfid, string boxids , bool isAdd = false )
        {
            try
            {
                if ( string.IsNullOrEmpty(rfid) || string.IsNullOrEmpty(boxids)) return true;
                string[] boxidList = boxids.Split( new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
                if (boxidList == null || boxidList.Length<1) return true;       
       
                String boxString = "";
                for( int k=0;k<boxidList.Length;k++)
                {
                    if( string.IsNullOrEmpty( boxString)==false)
                    {
                        boxString +=",";
                    }
                    boxString +="'"+ boxidList[k]+"'";
                }

                String sql_0 = string.Format("update t_position set floorrfid = '{0}'  where floorrfid !='{1}' and boxrfid in( {2} )", rfid , rfid ,  boxString);
                MySqlHelper.ExecuteSql(sql_0);
              
                
                string sql_1 = string.Format( "select * from t_position where floorrfid='{0}'" , rfid);
                DataSet ds = MySqlHelper.Query(sql_1);
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    System.Collections.ArrayList sqlList = new System.Collections.ArrayList();     
                    for (int i = 0; i < boxidList.Length; i++)
                    {
                        string boxrfid = boxidList[i];
                        String sql = string.Format(" insert into t_position (boxrfid,floorrfid) values('{0}','{1}') ", boxrfid, rfid);
                        sqlList.Add(sql);
                    }
                    MySqlHelper.ExecuteSqlTran(sqlList);
                }
                else
                {
                    InsertBoxList(boxidList, ds.Tables[0], rfid);

                    if (isAdd == false)
                    {
                        DeleteBoxList(boxidList, ds.Tables[0], rfid);
                    }
                }
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void InsertBoxList(String[] boxidList, DataTable dt, string floorrfid)
        {
            System.Collections.ArrayList sqlList = new System.Collections.ArrayList();

            for (int i = 0; i < boxidList.Length; i++)
            {
                string brfid = boxidList[i];
                bool isexist = false;
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    DataRow row = dt.Rows[k];
                    string bbbboxrfid = row["boxrfid"].ToString();
                    if (bbbboxrfid.Equals(brfid)) { isexist = true; break; }
                }
                if (isexist) continue;

                String sql = string.Format(" insert into t_position (boxrfid,floorrfid) values('{0}','{1}') ", brfid, floorrfid);
                sqlList.Add(sql);
            }
            MySqlHelper.ExecuteSqlTran(sqlList);
        }

        protected void DeleteBoxList(String[] list, DataTable dt, string floorrfid)
        {
            System.Collections.ArrayList sqlList = new System.Collections.ArrayList();   


            for (int k = 0; k < dt.Rows.Count; k++)
            {
                DataRow row = dt.Rows[k];
                string bbbboxrfid = row["boxrfid"].ToString();
                bool isexist = false;
                for (int i = 0; i < list.Length; i++)
                {
                    string brfid = list[i];
                    if (brfid.Equals(bbbboxrfid))
                    {
                        isexist = true; break;
                    }
                }
                if (isexist == false)
                {
                    string sql = string.Format("delete from t_position where boxrfid='{0}' and floorrfid='{1}'", bbbboxrfid, floorrfid);
                    sqlList.Add(sql);
                }

                MySqlHelper.ExecuteSqlTran(sqlList);
            }
        }


        public LabelInfo GetLabelInfoByRFID( string rfid)
        {
            String sql = string.Format("select  * from t_floorlabel where rfid='{0}'", rfid);
            DataSet ds = MySqlHelper.Query(sql);
            if( ds!=null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                LabelInfo bean = new LabelInfo();
                //bean.id = int.Parse(row["id"].ToString());
                bean.name = row["name"].ToString();
                bean.rfid = rfid;
                bean.type = "floor";
                //bean.number = row["number"].ToString();
                return bean;
            }

            sql = string.Format( "select * from t_boxlabel where rfid='{0}'", rfid);
            ds = MySqlHelper.Query(sql);
            if( ds!=null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                LabelInfo bean = new LabelInfo();
                //bean.id = int.Parse(row["id"].ToString());
                bean.name = row["name"].ToString();
                bean.rfid = rfid;
                bean.type = "box";
                //bean.number = row["number"].ToString();
                return bean;
            }
            return null;
        }

        public InventoryLabelInfo GetInventoryLabelInfo(string rfid)
        {
            String sql = string.Format("select * from t_floorlabel where rfid='{0}'", rfid);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                InventoryLabelInfo bean = new InventoryLabelInfo();
                //bean.id = int.Parse(row["id"].ToString());
                bean.name = row["name"].ToString();
                bean.rfid = rfid;
                bean.type = "floor";
                //bean.number = row["number"].ToString();
                bean.boxs = GetBoxListOfFloorRFId(rfid);
               
                return bean;
            }

            sql = string.Format("select * from t_boxlabel where rfid='{0}'", rfid);
            ds = MySqlHelper.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                InventoryLabelInfo bean = new InventoryLabelInfo();
                //bean.id = int.Parse(row["id"].ToString());
                bean.name = row["name"].ToString();
                bean.rfid = rfid;
                bean.type = "box";
                //bean.number = row["number"].ToString();
                return bean;
            }
            return null;
        }


        public List<BoxLabel> GetBoxListOfFloorRFId(string floorrfid)
        {
            //string sql = string.Format( "select b.id , b.number , b.rfid , b.name from t_position a INNER JOIN t_boxlabel b on a.boxrfid = b.rfid where a.floorrfid='{0}'", floorrfid);
            string sql = string.Format("select b.id , b.number , b.rfid , b.name ,  (select count(1) from t_archive where t_archive.boxid = b.id) as count  from t_position a INNER JOIN t_boxlabel b on a.boxrfid = b.rfid where a.floorrfid='{0}'", floorrfid);


            DataSet ds = MySqlHelper.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                List<BoxLabel> list = new List<BoxLabel>();
                for (int i = 0; i < count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    BoxLabel model = DataRowToBoxLabel(row);
                    list.Add(model);
                }

                return list;
            }
            return null;

        }


        public bool UploadInventoryInfo(InventoryList data)
        {
            string sql = "insert into t_inventory( title,operateid,operatename) values( @title,@operateid,@operatename);select LAST_INSERT_ID();";
            MySqlParameter[] parameters = {
					new MySqlParameter("@title", MySqlDbType.VarChar,255),
					new MySqlParameter("@operateid", MySqlDbType.Int32),
					new MySqlParameter("@operatename", MySqlDbType.VarChar,50)
                };
            parameters[0].Value = data.title;
            parameters[1].Value = data.operateid;
            parameters[2].Value = data.operatename;

            int id = MySqlHelper.ExecuteSqlReturnId(sql, parameters);

            foreach (InventoryRecord item in data.records)
            {
                string sql2 = "insert into t_inventorydetail(mid,floorrfid,boxrfid,status) values(@mid,@floorrfid,@boxrfid,@status)";

                MySqlParameter[] parameters2 = {
					new MySqlParameter("@mid", MySqlDbType.Int32),
					new MySqlParameter("@floorrfid", MySqlDbType.VarChar,100),
					new MySqlParameter("@boxrfid", MySqlDbType.VarChar,100),
                    new MySqlParameter("@status", MySqlDbType.VarChar,50)
                };
                parameters2[0].Value = id;
                parameters2[1].Value = item.floorrfid;
                parameters2[2].Value = item.boxrfid;
                parameters2[3].Value = item.status;

                MySqlHelper.ExecuteSql(sql2, parameters2);
            }

            return true;

        }
    
    }
}