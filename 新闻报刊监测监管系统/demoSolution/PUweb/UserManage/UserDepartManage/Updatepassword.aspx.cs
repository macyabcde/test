using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class Updatepassword : System.Web.UI.Page
    {
        private string userGUID;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {


            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            //17	用户密码重置
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 17))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }


            userGUID = Server.UrlDecode(Request.QueryString["userGUID"]);
            if (!IsPostBack)
            {
                inItPage();
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inItPage()
        {
            GetData();
        }
        #endregion

        #region 页面数据填充
        /// <summary>
        /// 页面数据填充
        /// </summary>
        public void GetData()
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            User.Model.MDL_User mdl_User = new User.Model.MDL_User();

            mdl_User = bll_User.GetModel(userGUID);
            lbUserLoginName.Text = mdl_User.userLoginName;
            lbUserName.Text = mdl_User.userName;
        }
        #endregion

        #region 获取页面数据
        /// <summary>
        /// 获取页面数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>完成修改后的实体</returns>
        public User.Model.MDL_User GetModel(User.Model.MDL_User model)
        {
            model.password = tbpassword.Text;
            return model;
        }
        #endregion

        #region 表单数据验证
        /// <summary>
        /// 表单数据验证
        /// </summary>
        /// <returns></returns>
        private PubTool.ReturnMsg checkInfo()
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (tbpassword.Text.Trim() == "")
            {
                tbpassword.Focus();
                lbMsg.Text = "请输入密码！";
                msg.Succeed = false;
                return msg;
            }

            if (tbpassword.Text != tbpassword2.Text)
            {
                tbpassword2.Focus();
                lbMsg.Text = "您两次输入密码不一致，请重新输入！";
                msg.Succeed = false;
                return msg;
            }
            return msg;
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            User.Model.MDL_User mdl_User = new User.Model.MDL_User();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            PubTool.ReturnMsg msg = checkInfo();
            if (!msg.Succeed) return;

            lbMsg.Text = "";

            mdl_User = bll_User.GetModel(userGUID);
            bll_User.Update(GetModel(mdl_User));
            scp.ClickParentPageButton("btnRefresh");
            scp.AlertAndClose("修改成功!");
        }
        #endregion
    }
}
