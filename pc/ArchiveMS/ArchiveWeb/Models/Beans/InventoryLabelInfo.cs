using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    public class InventoryLabelInfo :LabelInfo
    {
        public List<BoxLabel> boxs { get; set; } 
    }
}