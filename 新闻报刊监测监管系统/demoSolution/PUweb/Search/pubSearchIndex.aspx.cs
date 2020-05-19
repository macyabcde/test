using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Search
{
    public partial class pubSearchIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            lbFooter.Text = PU.Command.ConfigProvider.footerMsgForPaper;
        }

        #region 点击搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("pubSearchList.aspx?key=" + Server.UrlEncode(tbKeyWard.Text));
        }
        #endregion
    }
}
