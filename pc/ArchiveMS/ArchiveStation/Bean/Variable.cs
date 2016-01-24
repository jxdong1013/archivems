using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace ArchiveStation.Bean
{
    public class Variable
    {

        /// <summary>
        /// 数据字典
        /// </summary>
        //public static List<DictEntity> DictList = null;

        public static CookieContainer globelCookieContainer=new CookieContainer();

        public static UserBean User = null;

        //public static List<FishEntity.PersonRole> Roles = null;

        public static String RootUrl()
        {
            //if (string.IsNullOrEmpty(_connectionString))
            //{
            string url = IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "URL", "host");
            //    string port = IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "port");
            //    string dbname = IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "dbname");
             //   string user = IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "user");
             //   string password = IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "password");
             //   string passwordEx = DesEncryptUtil.DecryptDES(password, Constant.KEY);
                //_connectionString = string.Format("Data Source={0};Port={1};Database={2};User Id={3};Password={4};charset=utf8;pooling=true;Connection Timeout=5", host, port, dbname, user, passwordEx);
           // }

            return url;

        }
    }
}
