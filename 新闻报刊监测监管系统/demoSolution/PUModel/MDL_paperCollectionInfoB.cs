using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 报纸收藏信息实体类
    /// </summary>
    [Serializable]
    public class MDL_paperCollectionInfoB
    {
        #region Model
        private int _paperCollectionInfoID;
        private string _userGUID = "00000000-0000-0000-0000-000000000000";
        private int _paperID = 0;
        private string _remark = "";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 报纸收藏信息ID
        /// </summary>
        public int paperCollectionInfoID
        {
            get { return _paperCollectionInfoID; }
            set { _paperCollectionInfoID = value; }
        }

        /// <summary>
        /// 用户GUID "00000000-0000-0000-0000-000000000000"
        /// </summary>
        public string userGUID
        {
            get { return _userGUID; }
            set { _userGUID = value; }
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
        /// 备注
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
