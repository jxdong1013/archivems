using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractMvcWeb.Models.Beans
{
    public class Borrow
    {
        private long _borrowid;
        private int _archiveid;
        //private int _boxid;
		private int _status;
		private int _borrowerid;
		private DateTime _createtime= DateTime.Now;
		private int _operatorid;
        private string _operatorname;
        private string _remark;

		/// <summary>
		/// auto_increment
		/// </summary>
		public long borrowid
		{
			set{ _borrowid=value;}
			get{return _borrowid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int archiveid
		{
            set { _archiveid = value; }
            get { return _archiveid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int borrowerid
		{
			set{ _borrowerid=value;}
			get{return _borrowerid;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}


        public string createtimestring
        {
            get { return _createtime.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
		/// <summary>
		/// 
		/// </summary>
		public int operatorid
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string operatorname
		{
            set { _operatorname = value; }
            get { return _operatorname; }
		}
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}