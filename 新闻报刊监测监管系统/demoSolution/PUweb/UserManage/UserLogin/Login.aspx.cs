using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;
using User.Command;
using User.Model;
namespace User.Web.UserLogin
{
    public partial class Login : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 原来转过来的url
        /// </summary>
        private string url = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.QueryString["url"];
            if (url == null)
                url = "";
            else
                url = Server.UrlDecode(url);
        }
        #endregion

        #region 点击登录
        protected void ImgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BLL_User bllUser = new BLL_User();
                PubTool.ReturnMsg Msg = new PubTool.ReturnMsg();
                MDL_User model = bllUser.GetModelForUserLoginName(tbUserID.Text);

                if (model == null)
                {
                    lbMsg.Text = "该用户不存在！";
                    return;
                }

                if (model.password != tbPwd.Text)
                {
                    lbMsg.Text = "用户密码不正确！";
                    return;
                }


                Session.Add("UserLoginName", model.userLoginName);
                Session.Add("UserName", model.userName);
                Session.Add("UserGUID", model.userGUID);
                Session.Add("DefaultDepart", model.departID);
                

                lbMsg.Text = "";
                string goUrl = url;

                if (url == "") goUrl = ConfigProvider.indxPageUrl;

                Response.Redirect(goUrl);
                //Response.Write("goUrl=" + goUrl);
                Response.End();

            }
            catch (Exception exc)
            {
                lbMsg.Text = exc.Message;
            }
        }
        #endregion
    }
}
