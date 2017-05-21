using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    [Serializable]
    public class BoxLabel
    {
        public int id { get; set; }
        public string rfid { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        /// <summary>
        /// 档案盒状态
        /// </summary>
        public int status { get; set; }
        public string statusname { get;set;}
        public string floorrfid { get;set;}
        public string floorname { get; set; }
        /// <summary>
        /// 档案数量
        /// </summary>
        public int count { get; set; }
    
 
    }


    [Serializable]
    public class InventoryBoxLabel : BoxLabel
    {
        public DateTime borrowDate { get; set; }
        public int inventoryStatus { get; set; }

        public string borrowDateString
        {
            get { return borrowDate.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
    }

}