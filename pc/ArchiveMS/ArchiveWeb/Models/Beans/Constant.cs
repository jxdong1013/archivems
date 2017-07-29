using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    public class Constant
    {
        //public enum BoxStatusEnum
        //{
        //    在库 = 0,
        //    借出 = 1,
        //}

        public enum ArchiveStatusEnum
        {
            在库 = 0,
            借出 = 1,
        }

        public enum InventoryBoxStatusEnum
        {
            在库=0,
            有借已还=1,
            有借未还=2,
        }
    }
 
}