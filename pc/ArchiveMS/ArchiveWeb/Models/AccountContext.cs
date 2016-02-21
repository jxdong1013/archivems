﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using ContractMvcWeb.Models.Beans;

namespace ContractMvcWeb.Models
{
    public class AccountContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User  Login(string username, string password)
        {
            string sql = "select * from t_user where username=@username and password=@password";

            MySqlParameter[] parameters ={
                           new MySqlParameter("@username", MySqlDbType.VarChar,45),
					new MySqlParameter("@password", MySqlDbType.VarChar,45)
                                         };
            parameters[0].Value = username;
            parameters[1].Value = password;

            DataSet result = MySqlHelper.Query(sql , parameters );
            if (result == null || result.Tables.Count < 1 || result.Tables[0].Rows.Count < 1) return null;
            User model = new User();
            if (result.Tables[0].Rows[0]["userid"].ToString() != "")
            {
                model.userid = int.Parse(result.Tables[0].Rows[0]["userid"].ToString());
            }
            model.username = result.Tables[0].Rows[0]["username"].ToString();
            model.password = result.Tables[0].Rows[0]["password"].ToString();
            model.createtime=DateTime.Parse( result.Tables[0].Rows[0]["createtime"].ToString());
            model.modifytime=DateTime.Parse( result.Tables[0].Rows[0]["modifytime"].ToString());
            if (result.Tables[0].Rows[0]["enable"].ToString() != "")
            {
                model.enable = int.Parse(result.Tables[0].Rows[0]["enable"].ToString());
            }
            //model.link = result.Tables[0].Rows[0]["link"].ToString();
            model.sex = result.Tables[0].Rows[0]["sex"].ToString();
            model.address = result.Tables[0].Rows[0]["address"].ToString();
            model.roletype = result.Tables[0].Rows[0]["roletype"].ToString();
            if (result.Tables[0].Columns.Contains("realname"))
            {
                model.realname = result.Tables[0].Rows[0]["realname"].ToString();
            }
            
            return model;
        }

        //public int Register(RegisterModel model)
        //{
        //    string sql = string.Format("insert into person( no , name , password)");
        //    //MySqlHelper.ExecuteSql();
        //    return - 1;
        //}

        protected User DataRowToUser(DataRow row)
        {
            User model = new User();
            if ( row["userid"].ToString() != "")
            {
                model.userid = int.Parse( row["userid"].ToString());
            }
            model.username = row["username"].ToString();
            model.realname = row["realname"].ToString();
            model.password = row["password"].ToString();
            model.createtime = DateTime.Parse(  row["createtime"].ToString());
            model.modifytime = DateTime.Parse( row["modifytime"].ToString());
            //model.link = row["link"].ToString();
            model.phone = row["phone"].ToString();
            model.sex = row["sex"].ToString();
            if (row["enable"].ToString() != "")
            {
                model.enable = int.Parse(row["enable"].ToString());
            }
            model.address = row["address"].ToString();

            model.roletype = row["roletype"].ToString();

            model.createman = row["createman"].ToString();
            model.modifyman = row["modifyman"].ToString();

            return model;
        }

        public Page<User> QueryByPage(string userName, EnableEnum state, int pageIdex , int pageSize = 20 )
        {
            Page<User> page = new Page<User>();
            page.PageIdx = pageIdex;
            page.PageSize = pageSize;


            string where = " 1=1 ";
            if(! string.IsNullOrEmpty ( userName ))
            {
                userName = userName.Replace("'", "");
                where += string.Format( " and username like '%{0}%'" , userName );
            }
            if( state != EnableEnum.ALL )
            {
                where += string.Format ( " and enable ={0}" , (int)state );
            }
            string pageString = string.Format ( " limit {0},{1}" , pageIdex < 1 ? 0 :  (pageIdex-1) * pageSize , pageSize ) ;
            string orderby = string.Format(" order by modifytime desc");

            string sql = string.Format( "select count(1) from t_user where {0} " , where );
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

             sql = string.Format("select * from t_user where {0} {1} {2}", where , orderby , pageString );

            DataSet result = MySqlHelper.Query(sql);
            if (result == null || result.Tables.Count < 1 || result.Tables[0].Rows.Count < 1) return null;
            List<User> list = new List<User>();
            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {
                User model= DataRowToUser( result.Tables[0].Rows[i]);
               
                list.Add(model);
            }

            page.Data = list;

            return page;
        }


        protected string FilterSpecial(string txt)
        {
            if (string.IsNullOrEmpty(txt)) return txt;
            return txt.Replace("'", "");
        }


        protected string GetWhere(User query)
        {
            query.username = FilterSpecial(query.username);
            query.realname= FilterSpecial(query.realname);
            query.phone = FilterSpecial(query.phone);

            string where = "";
            if (string.IsNullOrEmpty(query.username) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";
                where += " username like '%" + query.username + "%'";
            }
            if (string.IsNullOrEmpty(query.realname) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += string.Format(" realname like '%{0}%'", query.realname);
            }
            if (string.IsNullOrEmpty(query.phone) == false)
            {
                if (string.IsNullOrEmpty(where) == false) where += " or ";

                where += string.Format(" phone like '%{0}%'", query.phone);
            }

            if (string.IsNullOrEmpty(where) ) where =" 1=1 ";


            return where;
        }

        public Page<User> QueryByPage( User query, int pageidx, int pagesize = 20)
        {
            Page<User> page = new Page<User>();
            page.PageIdx = pageidx;
            page.PageSize = pagesize;

            string where = GetWhere(query);
            string limit = string.Format(" limit {0} , {1}", pageidx < 0 ? 0 : pageidx * pagesize, pagesize);
            string orderby = "";//"order by operatetime desc , id desc";
            string sql = string.Format("select count(1) from t_user where {0} ", where);
            int totalrecord = 0;
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) totalrecord = 0;
            int.TryParse(obj.ToString(), out totalrecord);
            int totalPages = 0;
            totalPages = totalrecord / pagesize;
            totalPages += totalrecord % pagesize == 0 ? 0 : 1;
            page.TotalPages = totalPages;
            page.TotalRecords = totalrecord;
            sql = string.Format(" select * from t_user where {0} {1} {2}", where, orderby, limit);
            DataSet ds = MySqlHelper.Query(sql);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1) return page;
            int count = ds.Tables[0].Rows.Count;
            List<User> list = new List<User>();
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                User model = DataRowToUser(row);
                list.Add(model);
            }
            page.Data = list;
            return page;
        }
        

        public bool ExistUserName(string username)
        {
            string sql =  string.Format (" select count(1) from t_user where username ='{0}'" , username.Trim()) ;
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count == 0 ? false : true;
        }

        public bool ExistUserName(string username, int userid)
        {
            String sql = string.Format("select count(1) from t_user where username='{0}' and userid != {1}", username, userid);
            object obj = MySqlHelper.GetSingle(sql);
            if (obj == null) return false;
            int count = 0;
            int.TryParse(obj.ToString(), out count);
            return count == 0 ? false : true;
        }
        
        public int AddUser(User model)
        {
            string sql = string.Format(" insert into t_user( username , password , enable , phone ,sex,address, roletype, createman,modifyman,realname) values(@username,@password,@enable,@phone,@sex,@address,@roletype,@createman,@modifyman,@realname)");
            MySql.Data.MySqlClient.MySqlParameter[] paras = new MySql.Data.MySqlClient.MySqlParameter[10];
            paras[0] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[0].ParameterName = "@username";
            paras[0].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[0].Value = model.username;
            paras[1] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[1].ParameterName ="@password";
            paras[1].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[1].Value = model.password ;
            paras[2] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[2].ParameterName ="@enable";
            paras[2].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.Int16 ;
            paras[2].Value= model.enable ;
            paras[3] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[3].ParameterName = "@phone";
            paras[3].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[3].Value = model.phone;
            paras[4] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[4].ParameterName = "@sex";
            paras[4].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[4].Value = model.sex;
            paras[5] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[5].ParameterName = "@address";
            paras[5].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[5].Value = model.address;
            paras[6] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[6].ParameterName = "@roletype";
            paras[6].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[6].Value = model.roletype; 
            paras[7] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[7].ParameterName = "@createman";
            paras[7].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[7].Value = model.createman;
            paras[8] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[8].ParameterName = "@modifyman";
            paras[8].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[8].Value = model.modifyman;
            paras[9] = new MySql.Data.MySqlClient.MySqlParameter();
            paras[9].ParameterName = "@realname";
            paras[9].MySqlDbType = MySql.Data.MySqlClient.MySqlDbType.VarChar;
            paras[9].Value = model.realname;

            int result = MySqlHelper.ExecuteSql(sql, paras);
            return result;
        }

        public bool EditUser(User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_user set ");
            strSql.Append("username=@username,");
            strSql.Append("realname=@realname,");
            strSql.Append("phone=@phone,");
            strSql.Append("enable=@enable,");
            //strSql.Append("createtime=@createtime,");
            //strSql.Append("modifytime=@modifytime,");
            strSql.Append("sex=@sex,");
            strSql.Append("address=@address,");
            strSql.Append("roletype=@roletype,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("modifytime=@modifytime");
            strSql.Append(" where userid=@userid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userid", MySqlDbType.Int32,11),
					new MySqlParameter("@username", MySqlDbType.VarChar,45),
					new MySqlParameter("@realname", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone", MySqlDbType.VarChar,45),
					new MySqlParameter("@enable", MySqlDbType.Int32,11),
					//new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					//new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@sex", MySqlDbType.VarChar,10),
					new MySqlParameter("@address", MySqlDbType.VarChar,256),
                    new MySqlParameter("@roletype",MySqlDbType.VarChar,256),                   
                    new MySqlParameter("@modifyman",MySqlDbType.VarChar,256),
                    new MySqlParameter("@modifytime",MySqlDbType.Timestamp)
            };
            parameters[0].Value = model.userid;
            parameters[1].Value = model.username;
            parameters[2].Value = model.realname;
            parameters[3].Value = model.phone;
            parameters[4].Value = model.enable;
            //parameters[4].Value = model.createtime;
            //parameters[5].Value = model.modifytime;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.address;
            parameters[7].Value = model.roletype;
            parameters[8].Value = model.modifyman;
            parameters[9].Value = model.modifytime;

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
        public Models.Beans.User GetModel(int userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select userid,username,realname,password,phone,enable,createtime,modifytime,sex,address, roletype,createtime ,createman,modifytime,modifyman from t_user ");
            strSql.Append(" where userid=@userid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userid", MySqlDbType.Int32)
                                          };
            parameters[0].Value = userid;

            Models.Beans.User model = new Models.Beans.User();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.userid = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                if (ds.Tables[0].Rows[0]["enable"].ToString() != "")
                {
                    model.enable = int.Parse(ds.Tables[0].Rows[0]["enable"].ToString());
                }
                model.createtime= DateTime.Parse( ds.Tables[0].Rows[0]["createtime"].ToString());
                model.modifytime= DateTime.Parse( ds.Tables[0].Rows[0]["modifytime"].ToString());
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.roletype = ds.Tables[0].Rows[0]["roletype"].ToString();
                model.createman = ds.Tables[0].Rows[0]["createman"].ToString();
                model.modifyman = ds.Tables[0].Rows[0]["modifyman"].ToString();
                model.realname = ds.Tables[0].Rows[0]["realname"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool ChangePassword( Beans.LocalPasswordModel model , string  username , out string msg  )
        {
            msg = "";
            string sql = "select count(1) from t_user where username=@username and password=@password";
            MySqlParameter[] parameters = {
                                              new MySqlParameter("@password" ,MySqlDbType.VarChar ),
					new MySqlParameter("@username", MySqlDbType.VarChar )
                                          };
            parameters[0].Value = model.OldPassword;
            parameters[1].Value = username;

            object obj = MySqlHelper.GetSingle(sql, parameters);
            if (obj == null || int.Parse ( obj.ToString() ) <1 )
            {
                msg = "用户名或密码错误。";
                return false;
            }

            sql = "update t_user set password=@password where username =@username";
            MySqlParameter[] parameters2 =  {
                                              new MySqlParameter("@password" ,MySqlDbType.VarChar ),
					new MySqlParameter("@username", MySqlDbType.VarChar )
                                          };
            parameters2[0].Value = model.NewPassword;
            parameters2[1].Value = username ;

            int result = MySqlHelper.ExecuteSql(sql , parameters2 );
            return result > 0 ? true : false;
        }

        public bool DeleteUser(int userid)
        {
            String sql = string.Format( "delete from t_user where userid={0}" , userid);
            int result =  MySqlHelper.ExecuteSql(sql);
            return result > 0 ? true : false;
        }
    }


    public class LoginModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
