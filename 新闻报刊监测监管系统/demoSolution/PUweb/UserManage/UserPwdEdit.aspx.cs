using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;

namespace User.Web
{
    public partial class UserPwdEdit : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 用户GUID
        /// </summary>
        private string userGUID;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            WebUser webUserCs = new WebUser();
            webUserCs.login();

            userGUID = webUserCs.UserGUID;

            if (!IsPostBack)
            {
                inItPage();
            }
        }
        #endregion

        #region 点击Tab页
        protected void PanelControl1_Click(object sender, EventArgs e)
        {
            PanelControl1.GoPage();
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
            tbUserLoginName.Text = mdl_User.userLoginName;
            tbUserName.Text = mdl_User.userName;
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
            model.password = tbnewpwd.Text;
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
                lbMsg.Text = "请输入原密码！";
                msg.Succeed = false;
                return msg;
                
            }

            if (tbnewpwd.Text.Trim() == "")
            {
                tbnewpwd.Focus();
                lbMsg.Text = "请输入密码！";
                msg.Succeed = false;
                return msg;
            }

            if (tbnewpwd.Text != tbnewpwd2.Text)
            {
                tbnewpwd2.Focus();
                lbMsg.Text = "您两次输入密码不一致，请重新输入！";
                msg.Succeed = false;
                return msg;
            }
            return msg;
        }
        #endregion

        #region 点击确定
        protected void btnadd_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            User.Model.MDL_User mdl_User = new User.Model.MDL_User();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            PubTool.ReturnMsg msg = checkInfo();
            if (!msg.Succeed) return;

            mdl_User = bll_User.GetModel(userGUID);

            if (mdl_User.password != tbpassword.Text)
            {
                lbMsg.Text = "您输入的原密码不正确!";
                return;
            }

            lbMsg.Text = "";

            bll_User.Update(GetModel(mdl_User));
            scp.AlertAndClose("修改成功!");
        }
        #endregion
    }
}
