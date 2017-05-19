using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class BorrowLogPageResult : BaseBean
    {
        public Page<BorrowLogBean> Data { get; set; }
    }

    public class BorrowListResult : BaseBean
    {
        public List<BorrowLogBean> Data { get; set; }
    }

    public class BorrowLogBean : ArchiveBean
    {
        public string floornumber { get; set; }

        public DateTime createtime { get; set; }

        public string borrowername { get; set; }
        public string idcard { get; set; }
        public string department { get; set; }
        public string operatorname { get; set; }
    }
}
