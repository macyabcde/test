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
    public partial class AddUser : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 用户GUID
        /// </summary>
        private string userGUID;

        /// <summary>
        /// 操作命令
        /// </summary>
        private string whatDo;

        /// <summary>
        /// 组织节点ID
        /// </summary>
        private int departID = 0;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            whatDo = Request.QueryString["whatDo"].ToString();
            HDwhatDO.Value = whatDo;
            if (whatDo == "update" || whatDo == "priview") userGUID = Request.QueryString["userGUID"];

            departID = int.Parse(Request.QueryString["departID"]);


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
            if (whatDo == "add") inItAdd();//为添初始化 

            if (whatDo == "update") inItUpdate();//为修改始化

            if (whatDo == "priview") inItPriview();//为查看始化

            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            lbDepartStr.Text = bll_Department.father(departID);
        }
        #endregion

        #region 为添初始化
        private void inItAdd()
        {
            Title = "添加用户";
            lbwhatDo.Text = "添加用户";
            WebUser webUser = new WebUser();
            webUser.login();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            power powerCs = new power();
            //13	添加用户
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 13))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

        }
        #endregion

        #region 为修改始化
        private void inItUpdate()
        {
            Title = "修改用户";
            lbwhatDo.Text = "修改用户";

            WebUser webUser = new WebUser();
            webUser.login();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            power powerCs = new power();
            //14	修改用户
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 14))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            trPwd.Visible = false;
            GetData();
        }
        #endregion

        #region 为查看始化
        private void inItPriview()
        {
            Title = "查看用户";
            lbwhatDo.Text = "查看用户";
            btnFinish.Visible = false;
            trMsg.Visible = false;
            trPwd.Visible = false;
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
            tbuserLoginName.Text = mdl_User.userLoginName;
            tbuserName.Text = mdl_User.userName;
            tbpassword.Text = mdl_User.password;
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
            
            if (HDwhatDO.Value == "add") model.password = tbpassword.Text;

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

            if (whatDo == "add")
            {
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

            if (whatDo == "add")
            {
                if (bll_User.HasuserLoginName(tbuserLoginName.Text, ""))
                {
                    scp.Alert(tbuserLoginName.Text + "已存在，不允许再添加！");
                    return;
                }
                mdl_User.departID = departID;
                mdl_User.userGUID = Guid.NewGuid().ToString();
                bll_User.Add(GetModel(mdl_User));
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("添加成功!");
            }
            //执行修改操作
            else if (whatDo == "update")
            {
                mdl_User = bll_User.GetModel(userGUID);
                if (bll_User.HasuserLoginName(tbuserLoginName.Text, userGUID))
                {

                    return;    
                }

                bll_User.Update(GetModel(mdl_User));
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("修改成功!");
            }
        }
        #endregion
    }
}
