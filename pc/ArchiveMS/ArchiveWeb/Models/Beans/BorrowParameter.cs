using System;
using System.Collections.Generic;
using System.Text;

namespace ContractMvcWeb.Models.Beans
{
    public class BorrowParameter
    {
        public string operatename { get; set; }
        public int operateid { get; set; }
        //public string boxids { get; set; }
        public string name { get; set; }
        public string idcard { get; set; }
        public string department { get; set; }

        public string archiveids { get; set; }
    }
}
