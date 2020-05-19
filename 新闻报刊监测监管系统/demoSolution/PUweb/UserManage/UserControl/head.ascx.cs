using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;
using User.Command;

namespace User.Web
{
    public partial class head : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            lbUserInfo.Text = GetTimeExplain(DateTime.Now) + webUser.UserName;

            hylinkLoginOut.NavigateUrl = ConfigProvider.LoginOutPageUrl;


        }

        #region 获取时间的时段描述
        /// <summary>
        /// 获取时间的时段描述，如：早上、晚上等
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private string GetTimeExplain(DateTime time)
        {
            int hour = time.Hour; //获取当前时间的小时

            string Msg = "";

            if (hour < 6) { Msg = "凌晨好！"; }
            else if (hour < 9) { Msg = "早上好！"; }
            else if (hour < 12) { Msg = "上午好！"; }
            else if (hour < 14) { Msg = "中午好！"; }
            else if (hour < 17) { Msg = "下午好！"; }
            else if (hour < 19) { Msg = "傍晚好！"; }
            else if (hour < 22) { Msg = "晚上好！"; }
            else { Msg = "夜里好！"; }

            return Msg;
        }
        #endregion
    }
}