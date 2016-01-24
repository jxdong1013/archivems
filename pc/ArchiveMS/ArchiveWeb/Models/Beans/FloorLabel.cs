﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    [Serializable]
    public class FloorLabel
    {
        public int id { get; set; }
        public string rfid { get; set; }
        public string name { get; set; }
        public string number { get; set; }
    }
}