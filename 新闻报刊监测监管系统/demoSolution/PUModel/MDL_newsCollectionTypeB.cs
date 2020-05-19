using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 报道收藏类别实体类
    /// </summary>
    [Serializable]
    public class MDL_newsCollectionTypeB
    {
        #region Model
        private int _newsCollectionTypeID;
        private string _userGUID = "00000000-0000-0000-0000-000000000000";
        private string _collectionTypeName = "";
        private int _xuhao = 0;
        private int _paterNewsCollectionTypeID = 0;
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 报道收藏类别ID
        /// </summary>
        public int newsCollectionTypeID
        {
            get { return _newsCollectionTypeID; }
            set { _newsCollectionTypeID = value; }
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
        /// 类别名称
        /// </summary>
        public string collectionTypeName
        {
            get { return _collectionTypeName; }
            set { _collectionTypeName = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int xuhao
        {
            get { return _xuhao; }
            set { _xuhao = value; }
        }

        /// <summary>
        /// 父报道收藏类别ID
        /// </summary>
        public int paterNewsCollectionTypeID
        {
            get { return _paterNewsCollectionTypeID; }
            set { _paterNewsCollectionTypeID = value; }
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
