using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    [Serializable]
    public class Archive
    {
        public int id { get; set; }
        public string idx { get; set; }
        public String manager { get; set; }
        public String title { get; set; }
        public String number { get; set; }
        public string pages { get; set; }
        public string remark { get; set; }
        public string operateman { get; set; }
        public DateTime operatetime { get; set; }

        public int status { get; set; }

        public string statusname { get; set; }
        public int borrowid { get; set; }

        public string floorrfid { get; set; }
        public string boxname { get; set; }
        public string boxrfid { get; set; }
        public string boxnumber { get; set; }


        public string position { get; set; }
        /// <summary>
        /// 是否显示未归盒的档案
        /// </summary>
        public bool shownoposition { get; set; }
        /// <summary>
        /// 最新借或还时间
        /// </summary>
        public DateTime lastborrowtime { get; set; }
    }
}