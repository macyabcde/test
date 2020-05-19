using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.Paper
{
    /// <summary>
    /// 文章页面
    /// </summary>
    public partial class ArticlePage : System.Web.UI.Page
    {
        #region 自定义字段

        /// <summary>
        /// 文章KID
        /// </summary>
        private Int64 KID = 0;

        /// <summary>
        /// 版面实体对象
        /// </summary>
        private Components.BMmodel bmModel = null;
        /// <summary>
        /// 文章坐标列表
        /// </summary>
        public List<string> zblist = new List<string>();
        /// <summary>
        /// 版面数据表
        /// </summary>
        private DataTable BM_dt = new DataTable();
        /// <summary>
        /// 文章数据表
        /// </summary>
        private DataTable Article_dt = new DataTable();
        /// <summary>
        /// 有标题的文章数据表
        /// </summary>
        private DataTable ArticleHaveBT_dt = new DataTable();
        /// <summary>
        /// JPG版面图Url
        /// </summary>
        public string jpgUrl = "";

        /// <summary>
        /// 上一篇文章KID(返回-1说明已是本版的第一篇)
        /// </summary>
        private Int64 PreArticleKID = 0;
        /// <summary>
        /// 下一篇文章KID(返回-1说明已是本版的最后一篇)
        /// </summary>
        private Int64 NextArticleKID = 0;
        /// <summary>
        /// 文章实体对象
        /// </summary>
        public PM.Model.MDL_ArticleInfoB ArticleModel = null;


        #region 权限
        /// <summary>
        /// 107	版面收藏
        /// </summary>
        private bool bmSCPower = false;
        /// <summary>
        /// 108	报道收藏
        /// </summary>
        private bool SCPower = false;
        /// <summary>
        /// 109	报道推荐
        /// </summary>
        private bool tjPower = false;
        /// <summary>
        /// 110	作品报道选编
        /// </summary>
        private bool zpPower = false;
        /// <summary>
        /// 111	剪报报道选编
        /// </summary>
        private bool jbPower = false;

        #endregion

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //105	数字报阅读
            if (!Power.ifUserHavePower(webUser.UserGUID, 105))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            //107	版面收藏
            bmSCPower = Power.ifUserHavePower(webUser.UserGUID, 107);
            //108	报道收藏
            SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            //109	报道推荐
            tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);
            //110	作品报道选编
            zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            //111	剪报报道选编
            jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);


            Components.DataOP dataOPCs = new Components.DataOP();
            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();

            KID = Int64.Parse(Request.QueryString["KID"].ToString());
            ArticleModel = paperCs.getArticleInfoBModel(KID);


            if (ArticleModel == null) Response.Redirect("NoData.aspx?state=4", true);//该文章不存在
            BM_dt = paperCs.getBMList(ArticleModel.paperID, ArticleModel.RQ, ArticleModel.RQ);

            if (BM_dt.Rows.Count == 0) Response.Redirect("NoData.aspx?state=2", true);//该报纸没有该日期的数据


            bmModel = dataOPCs.getBCmodel(BM_dt, ArticleModel.BC);
            if (bmModel == null) Response.Redirect("NoData.aspx?state=3", true);//该报纸该日期没有该版次的数据

            Article_dt = paperCs.getArticleListForSZB(ArticleModel.paperID, ArticleModel.BC, ArticleModel.RQ, ArticleModel.RQ);
            ArticleHaveBT_dt = Article_dt.Copy();
            DataRow[] delRowArr = ArticleHaveBT_dt.Select("BT=''");
            foreach (DataRow row in delRowArr)
            {
                ArticleHaveBT_dt.Rows.Remove(row);
            }

            createZBList();
            bmModel.paperID = ArticleModel.paperID;
            bmModel.PreBC = dataOPCs.getPreBC(BM_dt, ArticleModel.BC);
            bmModel.NetBC = dataOPCs.getNextBC(BM_dt, ArticleModel.BC);
            bmModel.PreRQ = dataOPCs.getPreRQ(ArticleModel.paperID, ArticleModel.RQ);
            bmModel.NetRQ = dataOPCs.getNextRQ(ArticleModel.paperID, ArticleModel.RQ);
            PreArticleKID = dataOPCs.getPreArticleKID(Article_dt, ArticleHaveBT_dt, KID);
            NextArticleKID = dataOPCs.getNextArticleKID(Article_dt, ArticleHaveBT_dt, KID);


            SetPagControl();
            WriteArticleToPage();
            BindList();
            jpgUrl = "../Resource/showJPG.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.BC + "&type=1" + "&fileName=" + bmModel.JP + "&w=" + bmModel.w + "&h=" + bmModel.h;
        }


        #region 生成文章坐标列表
        /// <summary>
        /// 生成文章坐标列表
        /// </summary>
        private void createZBList()
        {
            PM.BLL.Comm.tool toolCs = new PM.BLL.Comm.tool();
            int w = 349;
            if (w < bmModel.w)
            {
                bmModel.h = bmModel.h * w / bmModel.w;
                bmModel.w = w;
            }
            else
            {
                //bmModel.h = bmModel.h * w / bmModel.w;
                //bmModel.w = w;
            }
            foreach (DataRow row in Article_dt.Rows)
            {
                string zb = toolCs.getJPGPercentTozb(row["ZB"].ToString(), bmModel.w, bmModel.h);
                zblist.Add(zb + ";" + row["KID"].ToString());
            }
        }
        #endregion

        #region 页面控件赋值
        /// <summary>
        /// 页面控件赋值
        /// </summary>
        private void SetPagControl()
        {
            PU.BLL.BLL_paperB puPaperCs = new PU.BLL.BLL_paperB();
            PubTool.DateTimeConvert DateTimeConvCs = new PubTool.DateTimeConvert();
            string PaperName = puPaperCs.getPaperName(bmModel.paperID);
            Title = PaperName;

            DateTime nowRQ = PubTool.Convert.intToDate(bmModel.RQ);
            string RQInfoStr = nowRQ.ToString("yyyy年MM月dd日") + " 星期" + DateTimeConvCs.getChinaWeekName(nowRQ.DayOfWeek) + " 出版";
            LbRQ.Text = RQInfoStr;

            LbBC.Text = bmModel.BC;
            LbBM.Text = "：" + bmModel.BM;



            if (bmModel.PreRQ != -1)
                HLinkPreRQ.NavigateUrl = "BMList.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.PreRQ;
            else
                HLinkPreRQ.NavigateUrl = "javascript:alert(\"当前已是第一期！\")";

            if (bmModel.NetRQ != -1)
                HLinkNetRQ.NavigateUrl = "BMList.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.NetRQ;
            else
                HLinkNetRQ.NavigateUrl = "javascript:alert(\"当前已是最后一期！\")";

            if (bmModel.PreBC != "")
                HLinkPreBC.NavigateUrl = "BMList.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.PreBC;
            else
                HLinkPreBC.NavigateUrl = "javascript:alert(\"当前已是该期的第一版！\")";
            if (bmModel.NetBC != "")
                HLinkNetBC.NavigateUrl = "BMList.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.NetBC;
            else
                HLinkNetBC.NavigateUrl = "javascript:alert(\"当前已是该期的最后一版！\")";

            if (PreArticleKID != -1)
                HLinkPreArticle.NavigateUrl = "ArticlePage.aspx?KID=" + PreArticleKID;

            else
                HLinkPreArticle.NavigateUrl = "javascript:alert(\"当前已是本版的第一篇文章！\")";

            HLinkPreArticle2.NavigateUrl = HLinkPreArticle.NavigateUrl;

            if (NextArticleKID != -1)
                HLinkNextArticle.NavigateUrl = "ArticlePage.aspx?KID=" + NextArticleKID;

            else
                HLinkNextArticle.NavigateUrl = "javascript:alert(\"当前已是本版的最后一篇文章！\")";

            HLinkNextArticle2.NavigateUrl = HLinkNextArticle.NavigateUrl;

            if (bmModel.PD != "")
            {
                HLinkPDFDown.NavigateUrl = "../Resource/dowmResource.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.BC + "&type=2" + "&fileName=" + bmModel.PD;
            }
            else
            {
                HLinkPDFDown.Enabled = false;
                HLinkPDFDown.Text = "<img height=\"16\" src=\"image/pdf02.gif\" width=\"16\" border=\"0\">";
            }

            ////107	版面收藏
            //bool bmSCPower = Power.ifUserHavePower(webUser.UserGUID, 107);
            ////108	报道收藏
            //bool SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            ////109	报道推荐
            //bool tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);
            ////110	作品报道选编
            //bool zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            ////111	剪报报道选编
            //bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);

            //107	版面收藏
            if (bmSCPower)
                HLinkSC.NavigateUrl = "javascript:addEditionCollection(" + bmModel.paperID + ", '" + PaperName + "', " + bmModel.RQ + ", '" + bmModel.BC + "', '" + bmModel.BM + "', '" + bmModel.PD + "', '" + bmModel.JP + "');";
            else
                HLinkSC.Enabled = false;

            //108	报道收藏
            if (SCPower)
                HLinkArticleSC.NavigateUrl = "javascript:addNewsCollection('" + KID + "');";
            else
                HLinkArticleSC.Enabled = false;

            //109	报道推荐
            if (tjPower)
                HLinkTJ.NavigateUrl = "javascript:addNewsRecommend('" + KID + "');";
            else
                HLinkTJ.Enabled = false;

            //111	剪报报道选编
            if (jbPower)
                HLinkTJB.NavigateUrl = "javascript:addClippingNewes('" + KID + "');";
            else
                HLinkTJB.Enabled = false;

            //110	作品报道选编
            if (zpPower)
                HLinkMyOpus.NavigateUrl = "javascript:addOpusNewsInfo('" + KID + "');";
            else
                HLinkMyOpus.Enabled = false;

            HLinkArticleSC2.NavigateUrl = HLinkArticleSC.NavigateUrl;
            HLinkArticleSC2.Enabled = HLinkArticleSC.Enabled;

            HLinkTJ2.NavigateUrl = HLinkTJ.NavigateUrl;
            HLinkTJ2.Enabled = HLinkTJ.Enabled;

            HLinkTJB2.NavigateUrl = HLinkTJB.NavigateUrl;
            HLinkTJB2.Enabled = HLinkTJB.Enabled;

            HLinkMyOpus2.NavigateUrl = HLinkMyOpus.NavigateUrl;
            HLinkMyOpus2.Enabled = HLinkMyOpus.Enabled;
        }
        #endregion

        #region 文章数据写到页面
        /// <summary>
        /// 文章数据写到页面
        /// </summary>
        private void WriteArticleToPage()
        {
            LbYT.Text = ArticleModel.YT;
            LbBT.Text = ArticleModel.BT;
            LbFB.Text = ArticleModel.FB;
            LbZZ.Text = ArticleModel.ZZ;
            string tx = ArticleModel.TX;
            tx = tx.Replace("\r\n", "<br>");
            tx = tx.Replace(" ", "&nbsp;");
            LbTX.Text = tx;
        }
        #endregion


        #region 列表绑定
        private void BindList()
        {
            rptBMShowList.DataSource = BM_dt;
            rptBMShowList.DataBind();

            rptTitleList.DataSource = ArticleHaveBT_dt;
            rptTitleList.DataBind();

            rptTitleShowList.DataSource = ArticleHaveBT_dt;
            rptTitleShowList.DataBind();
        }
        #endregion



        #region 版面列表显示行绑定事件
        protected void rptBMShowList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidPD = e.Item.FindControl("HidPD") as HiddenField;//PDF文件名
                HiddenField HidJP = e.Item.FindControl("HidJP") as HiddenField;//JPG文件名
                HiddenField HidBM = e.Item.FindControl("HidBM") as HiddenField;//版面
                HiddenField HidBC = e.Item.FindControl("HidBC") as HiddenField;//版次

                HyperLink HLinkPDFDown = e.Item.FindControl("HLinkPDFDown") as HyperLink;//PDF下载
                HyperLink HLinkBT = e.Item.FindControl("HLinkBT") as HyperLink; //标题


                string PD = HidPD.Value;
                string JP = HidJP.Value;
                string BM = HidBM.Value;
                string BC = HidBC.Value;

                //查看版面
                HLinkBT.Text = "第" + BC + "版：" + BM;
                HLinkBT.NavigateUrl = "BMList.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + BC;

                if (PD != "")
                {
                    string pdfUrl = "../Resource/dowmResource.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + BC + "&type=2" + "&fileName=" + PD;
                    HLinkPDFDown.Enabled = true;
                    HLinkPDFDown.Text = "<img src=\"image/pdf01.gif\"  title=\"下载版面PDF\" border=\"0\"/>";
                    HLinkPDFDown.NavigateUrl = pdfUrl;
                }
                else
                {
                    HLinkPDFDown.Enabled = false;
                    HLinkPDFDown.Text = "<img height=\"16\" src=\"image/pdf02.gif\" width=\"16\" border=\"0\" title=\"下载版面PDF\">";
                    HLinkPDFDown.NavigateUrl = "";
                }

                if (BC == bmModel.BC)
                {
                    HLinkBT.ForeColor = System.Drawing.Color.FromName("#900000");
                    HLinkBT.Font.Bold = true;
                }

            }
        }
        #endregion

        #region 标题列表行绑定事件
        protected void rptTitleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidKID = e.Item.FindControl("HidKID") as HiddenField;//KID
                HyperLink HLinkBT = e.Item.FindControl("HLinkBT") as HyperLink; //标题

                string KID = HidKID.Value;
                //查看
                if (HLinkBT.Text == "" || HLinkBT.Text == "&nbsp;") HLinkBT.Text = "无标题";
                HLinkBT.NavigateUrl = "ArticlePage.aspx?KID=" + KID;

            }
        }
        #endregion

        #region 标题列表显示行绑定事件
        protected void rptTitleShowList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidKID = e.Item.FindControl("HidKID") as HiddenField;//KID
                HyperLink HLinkBT = e.Item.FindControl("HLinkBT") as HyperLink; //标题

                string KID = HidKID.Value;
                //查看
                if (HLinkBT.Text == "" || HLinkBT.Text == "&nbsp;") HLinkBT.Text = "无标题";
                HLinkBT.NavigateUrl = "ArticlePage.aspx?KID=" + KID;

            }

        }
        #endregion
    }
}
