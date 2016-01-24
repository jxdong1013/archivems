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
    }
}