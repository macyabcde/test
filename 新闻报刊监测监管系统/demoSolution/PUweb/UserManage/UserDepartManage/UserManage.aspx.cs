using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            power powerCs = new power();

            //7	组织结构列表
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 7))
            {
                Response.Redirect("../other/NoPower.aspx");
                Response.End();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void btncomand_Click(object sender, EventArgs e)
        {

        }
    }
}
