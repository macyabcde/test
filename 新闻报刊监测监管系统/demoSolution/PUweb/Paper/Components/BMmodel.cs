using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PU.web.Paper.Components
{
    /// <summary>
    /// 版面信息实体对象
    /// </summary>
    public class BMmodel
    {
        #region Model

        private int _paperID = 0;
        private int _RQ = 19000101;
        private string _BC = "";
        private string _BM = "";
        private string _PD = "";
        private string _JP = "";
        private int _w = 0;
        private int _h = 0;
        private string _PreBC = "";
        private string _NetBC = "";
        private int _PreRQ = -1;
        private int _NetRQ = -1;

        /// <summary>
        /// 报纸ID
        /// </summary>
        public int paperID
        {
            get { return _paperID; }
            set { _paperID = value; }
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
        /// 版面文件宽
        /// </summary>
        public int w
        {
            get { return _w; }
            set { _w = value; }
        }
        /// <summary>
        /// 版面文件高
        /// </summary>
        public int h
        {
            get { return _h; }
            set { _h = value; }
        }

        /// <summary>
        /// 得到上一版版次(返回空说明已是第一版)
        /// </summary>
        public string PreBC
        {
            get { return _PreBC; }
            set { _PreBC = value; }
        }

        /// <summary>
        /// 得到下一版版次(返回空说明已是最后一版)
        /// </summary>
        public string NetBC
        {
            get { return _NetBC; }
            set { _NetBC = value; }
        }

        /// <summary>
        /// 得到上一期的报纸出版日期(返回-1说明没有上一期)
        /// </summary>
        public int PreRQ
        {
            get { return _PreRQ; }
            set { _PreRQ = value; }
        }

        /// <summary>
        /// 得到下一期的报纸出版日期(返回-1说明没有下一期)
        /// </summary>
        public int NetRQ
        {
            get { return _NetRQ; }
            set { _NetRQ = value; }
        }


        #endregion
    }
}
