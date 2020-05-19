using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 剪报基本信息实体类
    /// </summary>
    [Serializable]
    public class MDL_pressClippingBasisInfoB
    {
        #region Model
        private int _pressClippingBasisInfoID;
        private string _createUserGUID = "00000000-0000-0000-0000-000000000000";
        private string _pressClippingName = "";
        private string _customer = "";
        private string _salesman = "";
        private int _exportOrder = 0;
        private string _examineNotion = "";
        private string _examineUserGUID = "00000000-0000-0000-0000-000000000000";
        private int _state = 0;
        private string _remark = "";
        private DateTime _createTime = DateTime.Now;
        /// <summary>
        /// 剪报基本信息ID
        /// </summary>
        public int pressClippingBasisInfoID
        {
            get { return _pressClippingBasisInfoID; }
            set { _pressClippingBasisInfoID = value; }
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
        /// 剪报名称
        /// </summary>
        public string pressClippingName
        {
            get { return _pressClippingName; }
            set { _pressClippingName = value; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        /// <summary>
        /// 销售人员
        /// </summary>
        public string salesman
        {
            get { return _salesman; }
            set { _salesman = value; }
        }

        /// <summary>
        /// 输出排序
        /// </summary>
        public int exportOrder
        {
            get { return _exportOrder; }
            set { _exportOrder = value; }
        }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string examineNotion
        {
            get { return _examineNotion; }
            set { _examineNotion = value; }
        }

        /// <summary>
        /// 审批人
        /// </summary>
        public string examineUserGUID
        {
            get { return _examineUserGUID; }
            set { _examineUserGUID = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
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
