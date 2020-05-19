using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace PU.Command
{
    /// <summary>
    /// 基础数据配置类
    /// </summary>
    public class ConfigProvider
    {
        #region 报刊库应用数据库链接串
        /// <summary>
        /// 报刊库应用数据库链接串
        /// </summary>
        public static string PUDBconn
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["PUDBconn"].ToString();
                return connStr;
            }
        }
        #endregion

        #region 报刊库管理数据库链接串
        /// <summary>
        /// 报刊库管理数据库链接串
        /// </summary>
        public static string PMDBconn
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["PMDBconn"].ToString();
                return connStr;
            }
        }
        #endregion

        #region 检索引擎WebServiceUrl
        /// <summary>
        /// 检索引擎WebServiceUrl
        /// </summary>
        public static string PMwebServiceUrl
        {
            get
            {
                string _PMwebServiceUrl = System.Configuration.ConfigurationSettings.AppSettings["PMwebServiceUrl"];

                return _PMwebServiceUrl;
            }
        }
        #endregion

        #region 所属报业集团
        /// <summary>
        /// 所属报业集团
        /// </summary>
        public static string groupName
        {
            get
            {
                string _groupName = System.Configuration.ConfigurationSettings.AppSettings["groupName"];

                return _groupName;
            }
        }
        #endregion

        #region 默认新建的报道收藏类别
        /// <summary>
        /// 默认新建的报道收藏类别
        /// </summary>
        public static string DefaultNewsCollectionType
        {
            get
            {
                string _DefaultNewsCollectionType = System.Configuration.ConfigurationSettings.AppSettings["DefaultNewsCollectionType"];
                if (_DefaultNewsCollectionType == null) _DefaultNewsCollectionType = "";
                if (_DefaultNewsCollectionType == "") _DefaultNewsCollectionType = "时政,财经,体育,娱乐";
                return _DefaultNewsCollectionType;
            }
        }
        #endregion

        #region footer显示内容
        /// <summary>
        /// footer显示内容
        /// </summary>
        public static string footerMsg
        {
            get
            {
                string _footerMsg = System.Configuration.ConfigurationSettings.AppSettings["footerMsg"];

                return _footerMsg;
            }
        }
        #endregion

        #region 动态数字报footer显示内容
        /// <summary>
        /// 动态数字报footer显示内容
        /// </summary>
        public static string footerMsgForPaper
        {
            get
            {
                string _footerMsg = System.Configuration.ConfigurationSettings.AppSettings["footerMsgForPaper"];
               
                return _footerMsg;
            }
        }
        #endregion
    }
}
