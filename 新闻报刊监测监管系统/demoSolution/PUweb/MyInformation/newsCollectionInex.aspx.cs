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
    /// 报道收藏信息
    /// </summary>
    public partial class newsCollectionInex : System.Web.UI.Page
    {
        /// <summary>
        /// 报道收藏类别ID
        /// </summary>
        public int newsCollectionTypeID = 0;
        /// <summary>
        /// 126	删除报道收藏类别
        /// </summary>
        private bool delTypePower = false;
        //128	报道收藏移除
        private bool delSCPower = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //127	报道收藏列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 127))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }


            //109	报道推荐
            bool tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);
            //110	作品报道选编
            bool zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            //111	剪报报道选编
            bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);
            //128	报道收藏移除
            delSCPower = Power.ifUserHavePower(webUser.UserGUID, 128);

            //124	添加报道收藏类别
            bool addTypePower = Power.ifUserHavePower(webUser.UserGUID, 124);
            //125	修改报道收藏类别
            bool editTypePower = Power.ifUserHavePower(webUser.UserGUID, 125);
            //126	删除报道收藏类别
            delTypePower = Power.ifUserHavePower(webUser.UserGUID, 126);

            BtRecommend.Enabled = tjPower;
            BtClippingSend.Enabled = jbPower;
            BtMyOpus.Enabled = zpPower;
            BtdelSelect.Enabled = delSCPower;

            BtAddType.Enabled = addTypePower;
            BtEditType.Enabled = editTypePower;
            BtDelType.Enabled = delTypePower;

            string newsCollectionTypeIDstr = Request.QueryString["newsCollectionTypeID"];
            if (newsCollectionTypeIDstr == null || newsCollectionTypeIDstr == "") newsCollectionTypeIDstr = "-1";
            newsCollectionTypeID = int.Parse(newsCollectionTypeIDstr);

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
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            if (newsCollectionTypeID != -1)
            {
                PU.Model.MDL_newsCollectionTypeB model = newsCollectionTypeCs.GetModel(newsCollectionTypeID);
                if (model.userGUID != webUser.UserGUID)
                {
                    Response.Redirect("../other/NoPower.aspx", true);
                }

                LbTypeName.Text = "--" + model.collectionTypeName;
                BtEditType.Enabled = true;
                BtDelType.Enabled = true;
                BtEditType.OnClientClick = "windOpen('newsCollectionTypeAdd.aspx?whatDo=update&newsCollectionTypeID=" + newsCollectionTypeID + "','750px','200px'); return false;";
                BtDelType.OnClientClick = "return delType('" + model.collectionTypeName + "');";
            }
            else
            {
                LbTypeName.Text = "";
                BtEditType.Enabled = false;
                BtDelType.Enabled = false;
            }

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
            PU.BLL.BLL_newsCollectionInfoB newsCollectionInfoCs = new PU.BLL.BLL_newsCollectionInfoB();
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;
            PubTool.DB.PageRetClass PageRetModel = newsCollectionInfoCs.getUserNewsCollectionList(newsCollectionTypeID, pageSize, goPage);

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
            inIt();
            dataBind();
        }
        #endregion

        #region 多功能按钮事件
        protected void BtCommand_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 删除类别事件
        protected void BtDelType_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!delTypePower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                dataBind();
                return;
            }

            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            msg = newsCollectionTypeCs.Delete(newsCollectionTypeID);

            if (msg.Succeed)
            {
                scp.Alert("删除类别成功！");
                scp.RefreshPage("");
            }
            else
            {
                scp.Alert(msg.Msg);
                dataBind();
            }
        }
        #endregion


        #region 删除所选的收藏
        protected void BtdelSelect_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!delSCPower)
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }
            PU.BLL.BLL_newsCollectionInfoB newsCollectionInfoCs = new PU.BLL.BLL_newsCollectionInfoB();
            string[] newsCollectionInfoIDArr = HidValue.Value.Split(',');
            int ok = 0;
            foreach (string newsCollectionInfoID in newsCollectionInfoIDArr)
            {
                newsCollectionInfoCs.Delete(int.Parse(newsCollectionInfoID));
                ok++;
            }
            scp.Alert("有[" + ok.ToString() + "]篇报道收藏删除成功！");
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
