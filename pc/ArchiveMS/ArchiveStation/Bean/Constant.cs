using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class Constant
    {
        public const string KEY = "JINXINAGDONG";

        public const int PAGESIZE = 80;

        public const string Role_User = "user";
        public const string Role_Admin = "admin";

        public enum ResultCodeEnum
        {
            Error = 0,
            Success = 1
        }


    }
}
