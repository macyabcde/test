using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.pressClipping
{
    /// <summary>
    /// 剪报审批
    /// </summary>
    public partial class pressClippingSPList : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //137	剪报审批
            if (!Power.ifUserHavePower(webUser.UserGUID, 137))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            if (!IsPostBack)
            {
                search();
                inIt();
            }

        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inIt()
        {


        }
        #endregion

        #region 检索(转到第一页)
        /// <summary>
        /// 检索(转到第一页)
        /// </summary>
        protected void search()
        {
            pageControl1.goPage = 1;
            dataBind();
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void dataBind()
        {
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;
            PubTool.DB.PageRetClass PageRetModel = pressClippingBasisInfoCs.getPressClippingList("", 48, pageSize, goPage);

            DataTable dt = pageControl1.getPageDataForPageRet(PageRetModel);
            rptRetList.DataSource = dt;
            rptRetList.DataBind();
        }
        #endregion

        #region 翻页事件
        protected void pageControl1_Click(object sender, EventArgs e)
        {
            dataBind();
        }
        #endregion

        #region 刷新
        protected void BtRef_Click(object sender, EventArgs e)
        {
            dataBind();
        }
        #endregion

        #region 多功能按钮事件
        protected void BtCommand_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 行绑定事件
        protected void rptRetList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PM.BLL.BLL_databaseServerB bll_databaseServerB = new PM.BLL.BLL_databaseServerB();
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();

                HiddenField HidpressClippingBasisInfoID = e.Item.FindControl("HidpressClippingBasisInfoID") as HiddenField;//剪报基本信息ID
                HyperLink HLinkpressClippingName = e.Item.FindControl("HLinkpressClippingName") as HyperLink;//名称 
                Label Lbstate = e.Item.FindControl("Lbstate") as Label;//状态
                Label LbcreateTime = e.Item.FindControl("LbcreateTime") as Label;//创建时间               
                HyperLink HLinkNewsList = e.Item.FindControl("HLinkNewsList") as HyperLink;//报道信息                
                HyperLink HLinkSP = e.Item.FindControl("HLinkSP") as HyperLink;//审批

                int pressClippingBasisInfoID = int.Parse(HidpressClippingBasisInfoID.Value);
                int state = int.Parse(Lbstate.Text);

                Lbstate.Text = dictionaryCs.Find(state);
                LbcreateTime.Text = DateTime.Parse(LbcreateTime.Text).ToString("yyyy-MM-dd HH:mm:ss");

                //查看(审批)
                HLinkpressClippingName.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=Look','760','450');";
                //审批
                HLinkSP.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=SP','760','450');";
                //报道信息
                HLinkNewsList.NavigateUrl = "javascript:windOpen('pressClippingNews.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=Look','980px','700px');";
            }
        }
        #endregion
    }
}
