using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Command
{
    /// <summary>
    /// 为JS存储或获取临时数据页面
    /// </summary>
    public partial class ExchangeData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PubTool.ExchangeData ExchangeDataCs = new PubTool.ExchangeData();
            ExchangeDataCs.SetAndGetForJSinIt();

        }
    }
}
