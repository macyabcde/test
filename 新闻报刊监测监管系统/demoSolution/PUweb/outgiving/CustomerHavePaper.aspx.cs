using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PU.BLL;
using System.Data;

namespace PU.web.outgiving
{
    public partial class CustomerHavePaper : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 客户ID
        /// </summary>
        private string customerID;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();

            //148	客户报纸范围管理
            if (!Power.ifUserHavePower(webUser.UserGUID, 148))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            customerID = Request.QueryString["customerID"];
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
        private void inItPage()
        {
            BLL_customerBasisInfoB bllCustomerBasisInfo = new BLL_customerBasisInfoB();
            lbwhatDo.Text = "已有报纸范围(" + bllCustomerBasisInfo.GetModel(customerID).customerName + ")";
            ListBind();
        }
        #endregion

        #region 绑定报纸信息列表
        /// <summary>
        /// 绑定报纸信息列表
        /// </summary>
        private void ListBind()
        {
            BLL_paperB bllpaper = new BLL_paperB();
            BLL_customerPaperInfoB bllCustomerPaperInfo = new BLL_customerPaperInfoB();

            rptCustomerPaper.DataSource = bllCustomerPaperInfo.GetCustomerPaperList(customerID);
            rptCustomerPaper.DataBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptCustomerPaper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                BLL_paperB bllpaper=new BLL_paperB();
                Label lbPaperName = e.Item.FindControl("lbPaperName") as Label;
                HiddenField HFpaperID=e.Item.FindControl("HFpaperID") as HiddenField;

                Label lbupdateOverDate = e.Item.FindControl("lbupdateOverDate") as Label;

                lbPaperName.Text = bllpaper.getPaperName(int.Parse(HFpaperID.Value));

                lbupdateOverDate.Text = DateTime.Parse(lbupdateOverDate.Text).ToString("yyyy-MM-dd");
            }
        }
        #endregion
    }
}
