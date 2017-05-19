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
    public class BorrowerContext
    {

        public Page<Borrower> QueryByPage(string name , string idcard , string department , int pageIdex, int pageSize = 20)
        {
            Page<Borrower> page = new Page<Borrower>();
            page.PageIdx = pageIdex;
            page.PageSize = pageSize;


            string where = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                name = name.Replace("'", "");
                where += string.Format(" name like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(idcard))
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                idcard = idcard.Replace("'", "");
                where += string.Format(" idcard like '%{0}%'", idcard);
            }
            if (!string.IsNullOrEmpty(department))
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                department = department.Replace("'", "");
                where += string.Format(" department like '%{0}%'", department);
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " 1=1 ";
            }
            
            string pageString = string.Format(" limit {0},{1}", pageIdex < 0 ? 0 : pageIdex  * pageSize, pageSize);
            string orderby = string.Format(" order by createtime desc");

            string sql = string.Format("select count(1) from t_borrower where {0} ", where);
            object obj = MySqlHelper.GetSingle(sql);
            int totalRecords = 0;
            if (obj == null) totalRecords = 0;
            int.TryParse(obj.ToString(), out totalRecords);
            int totalPages = totalRecords / pageSize;
            totalPages += totalRecords % pageSize == 0 ? 0 : 1;

            page.TotalPages = totalPages;
            page.TotalRecords = totalRecords;
            if (totalRecords == 0)
            {
                page.Data = null;
                return page;
            }

            sql = string.Format("select * from t_borrower where {0} {1} {2}", where, orderby, pageString);

            DataSet result = MySqlHelper.Query(sql);
            if (result == null || result.Tables.Count < 1 || result.Tables[0].Rows.Count < 1) return null;
            List<Borrower> list = new List<Borrower>();
            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {
                Borrower model = DataRowToModel(result.Tables[0].Rows[i]);

                list.Add(model);
            }

            page.Data = list;

            return page;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Borrower DataRowToModel(DataRow row)
        {
            Borrower model = new Borrower();
            if (row != null)
            {
                if (row["borrowerid"] != null && row["borrowerid"].ToString() != "")
                {
                    model.borrowerid = int.Parse(row["borrowerid"].ToString());
                }
                if (row["idcard"] != null)
                {
                    model.idcard = row["idcard"].ToString();
                }
                if (row["no"] != null)
                {
                    model.no = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["department"] != null)
                {
                    model.department = row["department"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["post"] != null)
                {
                    model.post = row["post"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
            }
            return model;
        }


        public int Add(Borrower model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_borrower(");
            strSql.Append("idcard,no,name,department,phone,address,sex,post,remark,createtime)");
            strSql.Append(" values (");
            strSql.Append("@idcard,@no,@name,@department,@phone,@address,@sex,@post,@remark,@createtime);select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("@idcard", MySqlDbType.VarChar,20),
					new MySqlParameter("@no", MySqlDbType.VarChar,255),
					new MySqlParameter("@name", MySqlDbType.VarChar,100),
					new MySqlParameter("@department", MySqlDbType.VarChar,100),
					new MySqlParameter("@phone", MySqlDbType.VarChar,100),
					new MySqlParameter("@address", MySqlDbType.VarChar,256),
					new MySqlParameter("@sex", MySqlDbType.VarChar,10),
					new MySqlParameter("@post", MySqlDbType.VarChar,50),
					new MySqlParameter("@remark", MySqlDbType.VarChar,256),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp)};
            parameters[0].Value = model.idcard;
            parameters[1].Value = model.no;
            parameters[2].Value = model.name;
            parameters[3].Value = model.department;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.address;
            parameters[6].Value = model.sex;
            parameters[7].Value = model.post;
            parameters[8].Value = model.remark;
            parameters[9].Value = DateTime.Now;

            return Convert.ToInt32( MySqlHelper.GetSingle(strSql.ToString(), parameters));            
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int borrowerid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_borrower ");
            strSql.Append(" where borrowerid=@borrowerid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@borrowerid", MySqlDbType.Int32)
			};
            parameters[0].Value = borrowerid;

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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Borrower GetModel(int borrowerid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select borrowerid,idcard,no,name,department,phone,address,sex,post,remark,createtime from t_borrower ");
            strSql.Append(" where borrowerid=@borrowerid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@borrowerid", MySqlDbType.Int32)
			};
            parameters[0].Value = borrowerid;

            Borrower model = new Borrower();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Borrower GetModelByIdCard(string idcard)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select borrowerid,idcard,no,name,department,phone,address,sex,post,remark,createtime from t_borrower ");
            strSql.Append(" where idcard=@idcard");
            MySqlParameter[] parameters = {
					new MySqlParameter("@idcard", MySqlDbType.VarChar)
			};
            parameters[0].Value = idcard;

            Borrower model = new Borrower();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}