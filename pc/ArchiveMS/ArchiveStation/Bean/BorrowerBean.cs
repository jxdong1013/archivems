using System;
using System.Collections.Generic;
using System.Web;

namespace ArchiveStation.Bean
{
    

    public class BorrowerPageResult : BaseBean
    {
        public Page<BorrowerBean> Data { get; set; }
    }


    [Serializable]
    public class BorrowerBean
    {
        /// <summary>
        /// t_borrower:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>	
        public BorrowerBean() { }
        #region Model
        private int _borrowerid;
        private string _idcard;
        private string _no;
        private string _name;
        private string _department;
        private string _phone;
        private string _address;
        private string _sex = "男";
        private string _post;
        private string _remark;
        private DateTime _createtime;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int borrowerid
        {
            set { _borrowerid = value; }
            get { return _borrowerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string idcard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

        public DateTime borrowdate { get; set; }

        public string borrowdatestring
        {
            get;
            set;
        }

    }
}
