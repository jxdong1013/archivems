using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class ArchiveResult : BaseBean
    {

    }


    public class ImportArchiveResult : BaseBean
    {
        public ImportResult Data { get; set; }
    }

    public class ArchivePageResult : BaseBean
    {
        public Page<ArchiveBean> Data { get; set; }
    }

    public class ArchiveBean
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

        public String position { get; set; }
    }
}
