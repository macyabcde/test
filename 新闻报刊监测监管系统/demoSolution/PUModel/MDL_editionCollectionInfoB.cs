using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 版面收藏信息实体类
    /// </summary>
    [Serializable]
    public class MDL_editionCollectionInfoB
    {
        #region Model
        private int _editionCollectionInfoID;
        private string _userGUID = "00000000-0000-0000-0000-000000000000";
        private int _paperID = 0;
        private string _MC = "";
        private int _RQ = 19000101;
        private string _BC = "";
        private string _BM = "";
        private string _PD = "";
        private string _JP = "";
        private string _remark = "";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 版面收藏信息ID
        /// </summary>
        public int editionCollectionInfoID
        {
            get { return _editionCollectionInfoID; }
            set { _editionCollectionInfoID = value; }
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
        /// 报纸名
        /// </summary>
        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }

        /// <summary>
        /// 日期
        /// </summary>
        public int RQ
        {
            get { return _RQ; }
            set { _RQ = value; }
        }

        /// <summary>
        /// 版次
        /// </summary>
        public string BC
        {
            get { return _BC; }
            set { _BC = value; }
        }

        /// <summary>
        /// 版面
        /// </summary>
        public string BM
        {
            get { return _BM; }
            set { _BM = value; }
        }

        /// <summary>
        /// PDF文件名
        /// </summary>
        public string PD
        {
            get { return _PD; }
            set { _PD = value; }
        }

        /// <summary>
        /// JPG文件名
        /// </summary>
        public string JP
        {
            get { return _JP; }
            set { _JP = value; }
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
