using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Paper
{
    public partial class NoData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            int state = int.Parse(Request.QueryString["state"].ToString());
            string msg = "";
            switch (state)
            {
                case 1:
                    msg = "该报纸没有数据";
                    break;
                case 2:
                    msg = "该报纸没有该日期的数据";
                    break;
                case 3:
                    msg = "该报纸该日期没有该版次的数据";
                    break;
                case 4:
                    msg = "该文章不存在";
                    break;
                default:
                    msg = "未定义错误";
                    break;
            }
            LbMsg.Text = msg;

        }
    }
}
