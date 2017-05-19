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
        public string manager { get; set; }
        public string title { get; set; }
        public string number { get; set; }
        public string pages { get; set; }
        public string remark { get; set; }
        public string operateman { get; set; }
        public DateTime operatetime { get; set; }

        public string position { get; set; }

        public int status { get; set; }

        public string statusname { get; set; }
        public string boxnumber { get; set; }
        public string boxrfid { get; set; }
    }


    public class ArchiveListResult : BaseBean
    {
        public List<ArchiveBean> Data { get; set; }
    }
}
