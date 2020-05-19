using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;

namespace User.Web
{
    public partial class UserInfoEdit : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 用户GUID
        /// </summary>
        private string userGUID;

        /// <summary>
        /// 组织节点ID
        /// </summary>
        private int departID = 0;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUserCs = new WebUser();
            webUserCs.login();

            userGUID = webUserCs.UserGUID;
            departID = webUserCs.DefaultDepart;

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
            Title = "修改个人信息";
            GetData();
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            lbDepartStr.Text = bll_Department.father(departID);
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
            tbuserLoginName.Text = mdl_User.userLoginName;
            tbuserName.Text = mdl_User.userName;
            tbxuhao.Text = mdl_User.xuhao.ToString();
            tbtel.Text = mdl_User.tel;
            tbemail.Text = mdl_User.email;
            tbmobile.Text = mdl_User.mobile;
            tbexplain.Text = mdl_User.explain;
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
            model.userLoginName = tbuserLoginName.Text;
            model.userName = tbuserName.Text;

            model.xuhao = int.Parse(tbxuhao.Text);
            model.tel = tbtel.Text;
            model.email = tbemail.Text;
            model.mobile = tbmobile.Text;
            model.explain = tbexplain.Text;
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

            if (tbuserLoginName.Text.Trim() == "")
            {
                tbuserLoginName.Focus();
                lbMsg.Text = "请输入登录名！";
                msg.Succeed = false;
                return msg;
            }

            if (tbuserName.Text.Trim() == "")
            {
                tbuserName.Focus();
                lbMsg.Text = "请输入用户性名！";
                msg.Succeed = false;
                return msg;
            }

            if (tbxuhao.Text == "")
            {
                tbxuhao.Focus();
                lbMsg.Text = "请输入序号！";
                msg.Succeed = false;
                return msg;
            }

            int xuhao = 0;
            if (!int.TryParse(tbxuhao.Text, out xuhao))
            {
                tbxuhao.Focus();
                lbMsg.Text = "您输入的序号格式不正确，请重新输入！";
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

            PubTool.ReturnMsg msg = checkInfo();

            if (!msg.Succeed) return;

            lbMsg.Text = "";

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            mdl_User = bll_User.GetModel(userGUID);
            if (bll_User.HasuserLoginName(tbuserLoginName.Text, userGUID))
            {

                return;
            }

            bll_User.Update(GetModel(mdl_User));
            scp.AlertAndClose("修改成功!");
        }
        #endregion

        #region 点击Tab页
        protected void PanelControl1_Click(object sender, EventArgs e)
        {
            PanelControl1.GoPage();
        }
        #endregion
    }
}
