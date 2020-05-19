using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 客户报纸信息实体类
    /// </summary>
    [Serializable]
    public class MDL_customerPaperInfoB
    {
        #region Model
        private int _customerPaperID;
        private string _customerID = "";
        private int _paperID = 1000;
        private DateTime _updateOverDate = DateTime.Parse("2011-01-01");
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 客户报纸信息ID
        /// </summary>
        public int customerPaperID
        {
            get { return _customerPaperID; }
            set { _customerPaperID = value; }
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public string customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        /// <summary>
        /// 报纸ID
        /// </summary>
        public int paperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }

        /// <summary>
        /// 已更新到日期
        /// </summary>
        public DateTime updateOverDate
        {
            get { return _updateOverDate; }
            set { _updateOverDate = value; }
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
