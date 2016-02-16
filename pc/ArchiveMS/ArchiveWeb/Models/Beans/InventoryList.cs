using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    public class InventoryList
    {
        public string title { get; set; }
        public int operateid { get; set; }
        public string operatename { get; set; }
       
        public List<InventoryRecord> records { get; set; }
    }

    public class InventoryRecord {
        public string floorrfid { get; set; }
        public string boxrfid { get; set; }
        public string status { get; set; }
    }
}