using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.UserControl
{
    public partial class left : System.Web.UI.UserControl
    {
        /// <summary>
        /// 报道收藏类别
        /// </summary>
        public DataTable scType_dt = new DataTable();

        /// <summary>
        /// 当前访问的页面文件名
        /// </summary>
        public string fileName = "\"\"";

        /// <summary>
        /// 当前访问的页面文件名及参数
        /// </summary>
        public string fileNameAndQuery = "\"\"";

        protected void Page_Load(object sender, EventArgs e)
        {
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            newsCollectionTypeCs.CreateUserCollectionType();
            scType_dt = newsCollectionTypeCs.getUserCollectionTypeList();


            string url = HttpContext.Current.Request.Url.PathAndQuery;
            string[] arrayurl = url.Split('?');
            fileName = (arrayurl[0].Substring(arrayurl[0].LastIndexOf('/') + 1));
            fileName = "\"" + fileName + "\"";

            fileNameAndQuery = url.Substring(url.LastIndexOf('/') + 1);
            fileNameAndQuery = "\"" + fileNameAndQuery + "\"";

        }
    }
}