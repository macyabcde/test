﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PU.Model
{
    /// <summary>
    /// 剪报报道信息实体类
    /// </summary>
    [Serializable]
    public class MDL_pressClippingNewsInfoB
    {
        #region Model
        private int _pressClippingNewsInfoID;
        private int _pressClippingBasisInfoID = 0;
        private int _paperID = 0;
        private Int64 _KID = 0;
        private string _BT = "";
        private string _ZZ = "";
        private string _MC = "";
        private int _RQ = 19000101;
        private string _BC = "";
        private string _BM = "";
        private string _PD = "";
        private string _JP = "";
        private DateTime _createTime = DateTime.Now;

        /// <summary>
        /// 剪报报道信息ID
        /// </summary>
        public int pressClippingNewsInfoID
        {
            get { return _pressClippingNewsInfoID; }
            set { _pressClippingNewsInfoID = value; }
        }

        /// <summary>
        /// 剪报基本信息ID
        /// </summary>
        public int pressClippingBasisInfoID
        {
            get { return _pressClippingBasisInfoID; }
            set { _pressClippingBasisInfoID = value; }
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
        /// 文章ID
        /// </summary>
        public Int64 KID
        {
            get { return _KID; }
            set { _KID = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string BT
        {
            get { return _BT; }
            set { _BT = value; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string ZZ
        {
            get { return _ZZ; }
            set { _ZZ = value; }
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
