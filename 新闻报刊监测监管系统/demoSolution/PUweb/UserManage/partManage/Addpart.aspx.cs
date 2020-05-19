using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using User.BLL;

namespace User.Web.partManage
{
    public partial class Addpart : System.Web.UI.Page
    {
        private string whatDo;
        private int partID;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            whatDo = Server.UrlDecode(Request.QueryString["whatDo"].ToString());
            if (whatDo == "update" || whatDo == "select") partID = int.Parse(Server.UrlDecode(Request.QueryString["partID"]));
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
            if (whatDo == "add")
            {
                inItAdd();
            }
            else if (whatDo == "update")
            {
                inItUpdate();
            }
            else if (whatDo == "select")
            {
                inItSelect();
            }
        }
        #endregion

        #region 页面数据填充
        /// <summary>
        /// 页面数据填充
        /// </summary>
        public void GetData()
        {
            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            User.Model.MDL_partB mdl_partB = new User.Model.MDL_partB();

            mdl_partB = bll_partB.GetModel(partID);
            tbpartName.Text = mdl_partB.partName;
            tbexplain.Text = mdl_partB.explain;
        }
        #endregion

        #region 为添初始化
        protected void inItAdd()
        {
            Title = "添加角色信息";
            lbwhatDo.Text = "添加角色信息";

            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            //3	添加角色
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 3))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

        }
        #endregion

        #region 为修改始化
        protected void inItUpdate()
        {
            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            //4	修改角色
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 4))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            Title = "修改角色信息";
            lbwhatDo.Text = "修改角色信息";
            GetData();
        }
        #endregion

        #region 为查看始化
        protected void inItSelect()
        {
            Title = "查看角色信息";
            lbwhatDo.Text = "查看角色信息";
            btnFinish.Visible = false;
            GetData();
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            User.Model.MDL_partB mdl_partB = new User.Model.MDL_partB();

            //执行添加操作
            if (whatDo == "add")
            {
                if (bll_partB.HaspartName(tbpartName.Text, -1))
                {
                    scp.Alert(tbpartName.Text + "已存在，不允许再添加！");
                    return;
                }
                byte[] popdom = new byte[500];
                mdl_partB.popedom = popdom;

                bll_partB.Add(GetModel(mdl_partB));
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("添加成功!");

            }
            //执行修改操作
            else if (whatDo == "update")
            {
                if (bll_partB.HaspartName(tbpartName.Text, partID))
                {
                    scp.Alert(tbpartName.Text + "已存在，不允许再添加！");
                    return;
                }
                mdl_partB = bll_partB.GetModel(partID);
                bll_partB.Update(GetModel(mdl_partB));
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("修改成功!");
            }
        }
        #endregion

        #region 修改实体数据
        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>修改完成后的实体</returns>
        public User.Model.MDL_partB GetModel(User.Model.MDL_partB model)
        {
            model.partName = tbpartName.Text;
            model.explain = tbexplain.Text;
            return model;
        }
        #endregion
    }
}
