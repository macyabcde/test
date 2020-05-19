using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 笔名信息实体类
    /// </summary>
    [Serializable]
    public class MDL_aliasInfoB
    {
        #region Model
        private int _aliasInfoID;
        private string _userGUID = "00000000-0000-0000-0000-000000000000";
        private string _aliasInfo = "";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 笔名信息ID
        /// </summary>
        public int aliasInfoID
        {
            get { return _aliasInfoID; }
            set { _aliasInfoID = value; }
        }

        /// <summary>
        /// 用户GUID  "00000000-0000-0000-0000-000000000000"
        /// </summary>
        public string userGUID
        {
            get { return _userGUID; }
            set { _userGUID = value; }
        }

        /// <summary>
        /// 笔名信息
        /// </summary>
        public string aliasInfo
        {
            get { return _aliasInfo; }
            set { _aliasInfo = value; }
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
