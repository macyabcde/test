using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.Command;

namespace User.Web.UserLogin
{
    public partial class loginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(ConfigProvider.indxPageUrl);
            Response.End();
        }
    }
}
