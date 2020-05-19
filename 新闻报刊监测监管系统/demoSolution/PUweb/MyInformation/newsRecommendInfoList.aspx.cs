using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyInformation
{
    /// <summary>
    /// 推荐报道
    /// </summary>
    public partial class newsRecommendInfoList : System.Web.UI.Page
    {
        /// <summary>
        /// 131	报道推荐移除
        /// </summary>
        private bool delPower = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            ///130	报道推荐列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 130))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }


            //108	报道收藏
            bool SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            //110	作品报道选编
            bool zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            //111	剪报报道选编
            bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);
            //131	报道推荐移除
            delPower = Power.ifUserHavePower(webUser.UserGUID, 128);



            BtFavorites.Enabled = SCPower;
            BtClippingSend.Enabled = jbPower;
            BtMyOpus.Enabled = zpPower;
            BtdelSelect.Enabled = delPower;


            if (!IsPostBack)
            {
                search();
                inIt();
            }

        }


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
            PU.BLL.BLL_newsRecommendInfoB newsRecommendInfoCs = new PU.BLL.BLL_newsRecommendInfoB();
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;
            PubTool.DB.PageRetClass PageRetModel = newsRecommendInfoCs.getUserNewsRecommendInfoBList(pageSize, goPage);

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

        #region 删除所选的推荐报道
        protected void BtdelSelect_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            if (!delPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                dataBind();
                return;
            }

            PU.BLL.BLL_newsRecommendInfoB newsRecommendInfoCs = new PU.BLL.BLL_newsRecommendInfoB();
            string[] newscInfoIDArr = HidValue.Value.Split(',');
            int ok = 0;
            foreach (string newscInfoID in newscInfoIDArr)
            {
                newsRecommendInfoCs.Delete(int.Parse(newscInfoID));
                ok++;
            }
            scp.Alert("有[" + ok.ToString() + "]篇推荐报道删除成功！");
            dataBind();
        }
        #endregion


        #region 行绑定事件
        protected void rptRetList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PM.BLL.BLL_databaseServerB bll_databaseServerB = new PM.BLL.BLL_databaseServerB();
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidKID = e.Item.FindControl("HidKID") as HiddenField;//KID
                HiddenField HidPD = e.Item.FindControl("HidPD") as HiddenField;//PDF文件名
                HiddenField HidJP = e.Item.FindControl("HidJP") as HiddenField;//JPG文件名
                HiddenField HidpaperID = e.Item.FindControl("HidpaperID") as HiddenField;//报纸ID             
                HyperLink HLinkBT = e.Item.FindControl("HLinkBT") as HyperLink;//标题            
                Label LbRQ = e.Item.FindControl("LbRQ") as Label;//日期


                Int64 KID = Int64.Parse(HidKID.Value);
                int RQ = int.Parse(LbRQ.Text);

                LbRQ.Text = PubTool.Convert.intToDateStr(RQ);

                if (HLinkBT.Text == "" || HLinkBT.Text == "&nbsp;") HLinkBT.Text = "无标题";

                //查看文章
                HLinkBT.NavigateUrl = "../Paper/ArticlePage.aspx?KID=" + KID;

            }
        }
        #endregion

    }
}
