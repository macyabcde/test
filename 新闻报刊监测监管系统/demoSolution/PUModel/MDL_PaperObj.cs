using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PU.Model
{
    /// <summary>
    /// 报刊对象
    /// </summary>
    [Serializable]
    public class MDL_PaperObj
    {
        #region Model
        private int _aID;
        private string _name = "";
        private DataTable _dt =new DataTable();

        /// <summary>
        /// 数据ID
        /// </summary>
        public int aID
        {
            get { return _aID; }
            set { _aID = value; }
        }

        /// <summary>
        /// 数据名称
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 包含的DataTable
        /// </summary>
        public DataTable dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
        #endregion

    }
}
