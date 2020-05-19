using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using User.BLL;

namespace User.Web.partManage
{
    public partial class PartBpopdom : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 角色ID
        /// </summary>
        private int partID = -1;

        /// <summary>
        /// 角色已有的原子权限代码集合
        /// </summary>
        private List<int> partPopdomList = new List<int>();

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            //6	设置角色原子权限
            if(!powerCs.ifUserHavePower(webUser.UserGUID,6))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            partID = int.Parse(Request.QueryString["partID"]);
            partPopdomList = bll_partB.GetPartPeodom(partID);

            if (!IsPostBack)
            {
                Bindmodule();
            }
        }
        #endregion


        #region 绑定业务系统模块列表
        /// <summary>
        /// 绑定业务系统模块列表
        /// </summary>
        private void Bindmodule()
        {
            User.BLL.BLL_moduleB bll_moduleB = new User.BLL.BLL_moduleB();
            rptmodule.DataSource = bll_moduleB.GetList("");
            rptmodule.DataBind();
        }
        #endregion

        #region 系统模块行绑定事件
        protected void rptmodule_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HDmoduleID = e.Item.FindControl("HDmoduleID") as HiddenField;
                int moduleID = int.Parse(HDmoduleID.Value); //模块ID

                Repeater rptPopedom = (Repeater)e.Item.FindControl("rptPopedom");
                Bindpopedom(moduleID, rptPopedom);
            }
        }
        #endregion


        #region 绑定模块原子权限列表
        /// <summary>
        /// 绑定模块原子权限列表
        /// </summary>
        /// <param name="moduleID">模块ID</param>
        /// <param name="rptpopdom">原子权限repeater</param>
        private void Bindpopedom(int moduleID, Repeater rptpopdom)
        {
            User.BLL.BLL_popedomB bll_popedomB = new User.BLL.BLL_popedomB();
            rptpopdom.DataSource = bll_popedomB.GetPopedom(moduleID);
            rptpopdom.ItemDataBound += new RepeaterItemEventHandler(rptpopdom_ItemDataBound);
            rptpopdom.DataBind();
        }
        #endregion

        #region 系统模块原子权限行绑定事件
        void rptpopdom_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlInputCheckBox cbPopedomCode = e.Item.FindControl("cbPopedomCode") as HtmlInputCheckBox;//原子权限代码

                int popedomCode = int.Parse(cbPopedomCode.Value);

                if (partPopdomList.Contains(popedomCode)) cbPopedomCode.Checked = true;
            }
        }
        #endregion


        #region 定义角色原子权限
        protected void btnFinish_Click(object sender, EventArgs e)
        {

            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();


            //6	设置角色原子权限
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 6))
            {
                Response.Redirect("../other/NoPowerForOpenPage.aspx");
                Response.End();
            }


             PubTool.ScriptClass scp = new PubTool.ScriptClass();
              User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();

            string[] strPoedomArr = HFpopedomCodeStr.Value.Split(',');
            List<int> partNewPopedom = new List<int>();
            foreach (string str in strPoedomArr)
            {
                if (str == "") continue;

                partNewPopedom.Add(int.Parse(str));
            }

            if (bll_partB.PoedomDefine(partNewPopedom, partID))
            {
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("权限定义成功!");
            }
            else
                scp.AlertAndClose("权限定义失败!");
        }
        #endregion
    }
}
