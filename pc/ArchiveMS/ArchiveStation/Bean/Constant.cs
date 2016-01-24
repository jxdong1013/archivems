using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class Constant
    {
        public const string KEY = "JINXINAGDONG";

        public const int PAGESIZE = 30;

        public const string Role_SalesMan = "业务员";
        public const string Role_SalesManager = "业务主管";
        public const string Role_Admin = "管理员";

        public enum ResultCodeEnum
        {
            Error = 0,
            Success = 1
        }


    }
}
