using System;
using System.Collections.Generic;
using System.Text;

namespace ContractMvcWeb.Models.Beans
{
    [Serializable]
    public class BorrowLogBean : Archive
    {
        public int boxid { get; set; }


        public string floornumber { get; set; }

        public DateTime createtime { get; set; }
   
        public string borrowername { get; set; }
        public string idcard { get; set; }
        public string department { get; set; }
        public string operatorname { get; set; }

        public string createtimestring
        {
            get { return  createtime.Equals( DateTime.MinValue) ?"": createtime.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
    }
}
