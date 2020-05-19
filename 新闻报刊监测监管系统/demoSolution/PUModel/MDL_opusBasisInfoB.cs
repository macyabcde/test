using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 作品基本信息实体类
    /// </summary>
    [Serializable]
    public class MDL_opusBasisInfoB
    {
        #region Model
        private int _opusBasisInfoID;
        private string _userGUID = "00000000-0000-0000-0000-000000000000";
        private DateTime _dataUpdateTime = DateTime.Now;
        private int _ifAutoCreate;
        private string _remark = "";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 作品基本信息ID
        /// </summary>
        public int opusBasisInfoID
        {
            get { return _opusBasisInfoID; }
            set { _opusBasisInfoID = value; }
        }

        /// <summary>
        /// 用户GUID  00000000-0000-0000-0000-000000000000
        /// </summary>
        public string userGUID
        {
            get { return _userGUID; }
            set { _userGUID = value; }
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
        /// 是否已创建过  0:未自动创建过　1:已自动创建过
        /// </summary>
        public int ifAutoCreate
        {
            get { return _ifAutoCreate; }
            set { _ifAutoCreate = value; }
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
