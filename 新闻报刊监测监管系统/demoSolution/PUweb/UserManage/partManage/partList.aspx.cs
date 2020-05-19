using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;

namespace User.Web.partManage
{
    public partial class partList : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 是否有修改角色的权限
        /// </summary>
        private bool hasUpdate = false;

        /// <summary>
        /// 是否有删除角色的权限
        /// </summary>
        private bool hasDel = false;

        /// <summary>
        /// 是否有设置角色原子权限的权限
        /// </summary>
        private bool hasSetPopedom = false;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            WebUser webUser = new WebUser();
            webUser.login();

            power powerCs = new power();

            //2	角色列表
            if(!powerCs.ifUserHavePower(webUser.UserGUID,2))
            {
                Response.Redirect("../other/NoPower.aspx");
                Response.End();
            }

            //3	添加角色
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 3)) btnAdd.Enabled = false;

            //4	修改角色
            hasUpdate = powerCs.ifUserHavePower(webUser.UserGUID, 4);

            //5	删除角色
            hasDel = powerCs.ifUserHavePower(webUser.UserGUID, 5);

            //6	设置角色原子权限
            hasSetPopedom = powerCs.ifUserHavePower(webUser.UserGUID, 6);

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
            ListBind();
        }
        #endregion

        #region 绑定角色列表
        /// <summary>
        /// 绑定角色列表
        /// </summary>
        void ListBind()
        {
            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            PubTool.DB.PageRetClass pageRetJG = bll_partB.GetPaperPageList(pageControl1.pageSize, pageControl1.goPage);
            rptPaper.DataSource = pageControl1.getPageDataForPageRet(pageRetJG);
            rptPaper.DataBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptPaper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HFpartID = e.Item.FindControl("HFpartID") as HiddenField;
                LinkButton lbtnpartName = e.Item.FindControl("lbtnpartName") as LinkButton;
                LinkButton lbtnUpdate = e.Item.FindControl("lbtnUpdate") as LinkButton;
                LinkButton lbtnDelete = e.Item.FindControl("lbtnDelete") as LinkButton;
                LinkButton lbtnpopedom = e.Item.FindControl("lbtnpopedom") as LinkButton;

                Label lbpopedomCount = e.Item.FindControl("lbpopedomCount") as Label; //权限数
                Label lbuserCount = e.Item.FindControl("lbuserCount") as Label; //使用人数


                int partID = int.Parse(HFpartID.Value);
                string partName = lbtnpartName.Text;

                User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
                User.BLL.BLL_User_PartB bll_User_PartB = new User.BLL.BLL_User_PartB();


                lbuserCount.Text = bll_User_PartB.CountConsionPeople(partID).ToString();//统计已使用人数
                lbpopedomCount.Text = bll_partB.GetPartPeodom(partID).Count.ToString();//统计权限数
                 //绑定修改角色事件
                if (hasUpdate)
                    lbtnUpdate.OnClientClick = "windOpen('Addpart.aspx?whatDo=update&partID=" + partID + "','690','380'); return false;";
                else
                    lbtnUpdate.Enabled = false;

                //绑定删除角色事件
                if (hasDel)
                    lbtnDelete.OnClientClick = "return delPart(" + partID + ",'" + partName + "');";
                else
                    lbtnDelete.Enabled = false;

                //绑定查看角色信息事件
                lbtnpartName.OnClientClick = "windOpen('Addpart.aspx?whatDo=select&partID=" + partID + "','650','370'); return false;";
              
                //权限定义
                if (hasSetPopedom)
                    lbtnpopedom.OnClientClick = "windOpen('PartBpopdom.aspx?partID=" + partID + "','818','700'); return false;";
                else
                    lbtnpopedom.Enabled = false;
            }
        }
        #endregion

        #region 多功能事件
        protected void btncomand_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            string command = HFcomand.Value;

            //删除角色
            if (command == "delPart")
            {
                WebUser webUser = new WebUser();
                webUser.login();
                power powerCs = new power();

                if (!powerCs.ifUserHavePower(webUser.UserGUID, 5))
                {
                    scp.Alert("您还未开通此权限！");
                    return;
                }

                bll_partB.Delete(int.Parse(HFvalue.Value));
            }

            HFcomand.Value = "";
            HFvalue.Value = "";
            ListBind();
        }
        #endregion

        #region 点击翻页
        protected void pageControl1_Click(object sender, EventArgs e)
        {
            ListBind();
        }
        #endregion

        #region 点击刷新
        protected void btnRefresh_Click1(object sender, EventArgs e)
        {
            ListBind();
        }
        #endregion
    }
}
