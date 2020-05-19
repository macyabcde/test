using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PU.BLL;

namespace PU.web.outgiving
{
    /// <summary>
    /// 客户管理
    /// </summary>
    public partial class CustomerBasisInfoList : System.Web.UI.Page
    {      
        /// <summary>
        /// 144	添加客户
        /// </summary>
        private bool addPower = false;
        /// <summary>
        /// 145	修改客户
        /// </summary>
        private bool editPower = false;
        /// <summary>
        /// 146	删除客户
        /// </summary>
        private bool delPower = false;
        /// <summary>
        /// 147	客户状态管理
        /// </summary>
        private bool activePower = false;
        /// <summary>
        /// 148	客户报纸范围管理
        /// </summary>
        private bool fwPower = false;


        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //143	客户列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 143))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            //144	添加客户
            addPower = Power.ifUserHavePower(webUser.UserGUID, 144);
            //145	修改客户
            editPower = Power.ifUserHavePower(webUser.UserGUID, 145);
            //146	删除客户
            delPower = Power.ifUserHavePower(webUser.UserGUID, 146);
            //147	客户状态管理
            activePower = Power.ifUserHavePower(webUser.UserGUID, 147);
            //148	客户报纸范围管理
            fwPower = Power.ifUserHavePower(webUser.UserGUID, 148);

            BtnAdd.Enabled = addPower;
            BtnDel.Enabled = delPower;

            if (!IsPostBack)
            {
                inItPage(); //页面初始化
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

        #region 绑定客户信息
        /// <summary>
        /// 绑定客户信息
        /// </summary>
        private void ListBind()
        {
            BLL_customerBasisInfoB bllcustomerBasisInfo = new BLL_customerBasisInfoB();
            PubTool.DB.PageRetClass pageRetJG = bllcustomerBasisInfo.GetCustomerBasisInfoList(pageControl1.pageSize, pageControl1.goPage);
            rptCustomerList.DataSource = pageControl1.getPageDataForPageRet(pageRetJG);
            rptCustomerList.DataBind();
        }
        #endregion

        #region 刷新客户信息
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ListBind();
        }
        #endregion

        #region 客户信息行绑定事件
        protected void rptCustomerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidCustomerID = e.Item.FindControl("HidCustomerID") as HiddenField; //客户ID

                Label lbServiceEndTime = e.Item.FindControl("lbServiceEndTime") as Label; //服务截止日期
                Label lbCustomerName = e.Item.FindControl("lbCustomerName") as Label; //客户名称

                LinkButton lbtnUpdate = e.Item.FindControl("lbtnUpdate") as LinkButton; //修改客户信息
                LinkButton lbtnActive = e.Item.FindControl("lbtnActive") as LinkButton; //禁用(启用)客户信息
                LinkButton lbtnPaperFW = e.Item.FindControl("lbtnPaperFW") as LinkButton; //报纸范围

                string customerID = HidCustomerID.Value;
                int active = int.Parse(lbtnActive.CommandArgument);

                if (active == 0)
                    lbtnActive.Text = "启用";
                else
                    lbtnActive.Text = "禁用";

                lbServiceEndTime.Text = DateTime.Parse(lbServiceEndTime.Text).ToString("yyyy-MM-dd");

                if (editPower)
                    lbtnUpdate.OnClientClick = "windOpen('CustomerBasisInfoAdd.aspx?whatDo=update&customerID=" + customerID + "','730','355'); return false;";
                else
                    lbtnUpdate.Enabled = false;

                if (activePower)
                    lbtnActive.OnClientClick = "return isactive(" + active + ",'" + customerID + "','" + lbCustomerName.Text + "');";
                else
                    lbtnActive.Enabled = false;

                if (fwPower)
                    lbtnPaperFW.OnClientClick = "windOpen('CustomerPaperFW.aspx?customerID=" + customerID + "','900','700'); return false;";
                else
                    lbtnPaperFW.Enabled = false;
            }
        }
        #endregion

        #region 多用事件
        protected void btncomand_Click(object sender, EventArgs e)
        {
            string command = HFcomand.Value;
            BLL_customerBasisInfoB bllCustomerBasisInfo = new BLL_customerBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            

            //启用(禁用用户)
            if (command == "active")
            {
                if (!activePower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    ListBind();
                    return;
                }
                bllCustomerBasisInfo.SetCustomerActive(HFvalue.Value, int.Parse(HFactive.Value));
            }

            HFcomand.Value = "";
            HFvalue.Value = "";
            HFactive.Value = "";
            ListBind();
        }
        #endregion

        #region 删除客户信息
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!delPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                ListBind();
                return;
            }

            string customerIDStr = HFvalue.Value;
            if (customerIDStr == "") return;
            BLL_customerBasisInfoB bllCustomerBasisInfo = new BLL_customerBasisInfoB();
            foreach (string customerID in customerIDStr.Split(','))
            {
                bllCustomerBasisInfo.Delete(customerID);
            }
            ListBind();
        }
        #endregion
    }
}