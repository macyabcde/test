using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 客户基本信息实体类
    /// </summary>
    [Serializable]
    public class MDL_customerBasisInfoB
    {
        #region Model
        private string _customerID;
        private string _password = "";
        private string _customerName = "";
        private string _linkman = "";
        private string _tel = "";
        private string _email = "";
        private string _qq = "";
        private DateTime _serviceEndTime = DateTime.Now;
        private int _requestLimit = 0;
        private DateTime _dataUpdateTime = DateTime.Now;
        private int _active = 1;
        private int _SyncMode = 1;
        private string _createUserGUID = "00000000-0000-0000-0000-000000000000";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 客户ID
        /// </summary>
        public string customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        /// <summary>
        /// 客户密码
        /// </summary>
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string customerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// <summary>
        /// 客户联系人
        /// </summary>
        public string linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        /// <summary>
        /// 联系人Email
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// 联系人QQ
        /// </summary>
        public string qq
        {
            get { return _qq; }
            set { _qq = value; }
        }

        /// <summary>
        /// 服务截止日期
        /// </summary>
        public DateTime serviceEndTime
        {
            get { return _serviceEndTime; }
            set { _serviceEndTime = value; }
        }

        /// <summary>
        /// 频度限制
        /// </summary>
        public int requestLimit
        {
            get { return _requestLimit; }
            set { _requestLimit = value; }
        }

        /// <summary>
        /// 数据更新时间
        /// </summary>
        public DateTime dataUpdateTime
        {
            get { return _dataUpdateTime; }
            set { _dataUpdateTime = value; }
        }

        /// <summary>
        /// 是否有效 1：代表有效 0：代表无效
        /// </summary>
        public int active
        {
            get { return _active; }
            set { _active = value; }
        }

        /// <summary>
        /// 同步模式 1：宽松(如果资源文件同步出错将继续同步)、0：严格(有任何错误将重新同步)
        /// </summary>
        public int SyncMode
        {
            get { return _SyncMode; }
            set { _SyncMode = value; }
        }

        /// <summary>
        /// 创建人 "00000000-0000-0000-0000-000000000000"
        /// </summary>
        public string createUserGUID
        {
            get { return _createUserGUID; }
            set { _createUserGUID = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        #endregion
    }
}
