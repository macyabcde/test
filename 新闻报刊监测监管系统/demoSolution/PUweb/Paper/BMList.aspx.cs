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
    /// 版面列表页面
    /// </summary>
    public partial class BMList : System.Web.UI.Page
    {
        #region 自定义字段

        /// <summary>
        /// 报纸ID
        /// </summary>
        public int paperID = 0;
        /// <summary>
        /// 出版日期
        /// </summary>
        public int RQ = -1;
        /// <summary>
        /// 版次
        /// </summary>
        private string BC = "";
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
        public DataTable Article_dt = new DataTable();
        /// <summary>
        /// JPG版面图Url
        /// </summary>
        public string jpgUrl = "";

        /// <summary>
        /// 107	版面收藏
        /// </summary>
        private bool bmSCPower = false;

        /// <summary>
        /// 运行时长
        /// </summary>
        public string timeLong = "";

        /// <summary>
        /// 日历天html(几号)
        /// </summary>
        public string dateHtml = "";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

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

            Components.DataOP dataOPCs = new Components.DataOP();
            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();


            paperID = int.Parse(Request.QueryString["paperID"].ToString());
            string RQTemp = Request.QueryString["RQ"];
            BC = Request.QueryString["BC"];
            if (RQTemp == null || RQTemp == "")
            {
                RQ = dataOPCs.getPaperLastRQ(paperID);
            }
            else
            {
                RQ = int.Parse(RQTemp);
            }
            if (RQ == -1) Response.Redirect("NoData.aspx?state=1", true);//该报纸没有数据

            BM_dt = paperCs.getBMList(paperID, RQ, RQ);

            if (BM_dt.Rows.Count == 0) Response.Redirect("NoData.aspx?state=2", true);//该报纸没有该日期的数据

            if (BC == null || BC == "")
            {
                BC = dataOPCs.getFirstBC(BM_dt);
                if (BC == "") Response.Redirect("NoData.aspx?state=3", true);//该报纸该日期没有该版次的数据
            }
            bmModel = dataOPCs.getBCmodel(BM_dt, BC);
            if (bmModel == null) Response.Redirect("NoData.aspx?state=3", true);//该报纸该日期没有该版次的数据

            Article_dt = paperCs.getArticleListForSZB(paperID, BC, RQ, RQ);

            createZBList();
            bmModel.paperID = paperID;
            bmModel.PreBC = dataOPCs.getPreBC(BM_dt, BC);
            bmModel.NetBC = dataOPCs.getNextBC(BM_dt, BC);
            bmModel.PreRQ = dataOPCs.getPreRQ(paperID, RQ);
            bmModel.NetRQ = dataOPCs.getNextRQ(paperID, RQ);

            DateListInit();
            SetPagControl();
            BindList();
            jpgUrl = "../Resource/showJPG.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.BC + "&type=1" + "&fileName=" + bmModel.JP + "&w=" + bmModel.w + "&h=" + bmModel.h;

            Components.DataOP DataOPCs = new PU.web.Paper.Components.DataOP();

            int year = int.Parse(RQ.ToString().Substring(0, 4));
            int month = int.Parse(RQ.ToString().Substring(4, 2));
            dateHtml = DataOPCs.calendarDateHtml(paperID, year, month, RQ);
            dateHtml = dateHtml.Replace("\"", "\\\"");

            time2 = DateTime.Now;
            timeLong = time2.Subtract(time1).ToString();
        }

        #region 日期下拉列表初始化
        /// <summary>
        /// 日期下拉列表初始化
        /// </summary>
        private void DateListInit()
        {
            PubTool.DropDownListOperate dpOP = new PubTool.DropDownListOperate();
            PM.BLL.BLL_paperB pm_paperCS = new PM.BLL.BLL_paperB();
            PM.Model.MDL_paperB paperModel = pm_paperCS.GetModel(paperID);

            DpListYear.Items.Clear();
            DpListMonth.Items.Clear();

            int endYear = DateTime.Now.Year + 2;
            for (int i = paperModel.firstYear; i < endYear; i++)
            {
                ListItem a = new ListItem();
                a.Value = i.ToString();
                a.Text = i.ToString();
                DpListYear.Items.Add(a);
            }
            dpOP.selectValue(DpListYear, RQ.ToString().Substring(0, 4));

            for (int i = 1; i < 13; i++)
            {                
                ListItem a = new ListItem();
                a.Value = i.ToString();
                a.Text = i.ToString();
                DpListMonth.Items.Add(a);
            }
            dpOP.selectValue(DpListMonth, RQ.ToString().Substring(4, 2).TrimStart('0'));

            DpListYear.Attributes.Add("onchange", "setCalendar(" + paperID + ",'DpListYear','DpListMonth'," + RQ + ");");
            DpListMonth.Attributes.Add("onchange", "setCalendar(" + paperID + ",'DpListYear','DpListMonth'," + RQ + ");");          

        }
        #endregion

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


            Title = PaperName;

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
            if (bmModel.PD != "")
            {
                HLinkPDFDown.NavigateUrl = "../Resource/dowmResource.aspx?paperID=" + bmModel.paperID + "&RQ=" + bmModel.RQ + "&BC=" + bmModel.BC + "&type=2" + "&fileName=" + bmModel.PD;
            }
            else
            {
                HLinkPDFDown.Enabled = false;
                HLinkPDFDown.Text = "<img height=\"16\" src=\"image/pdf02.gif\" width=\"16\" border=\"0\">";
            }

            //107	版面收藏
            if (bmSCPower)
                HLinkSC.NavigateUrl = "javascript:addEditionCollection(" + bmModel.paperID + ", '" + PaperName + "', " + bmModel.RQ + ", '" + bmModel.BC + "', '" + bmModel.BM + "', '" + bmModel.PD + "', '" + bmModel.JP + "');";
            else
                HLinkSC.Enabled = false;
        }
        #endregion

        #region 列表绑定
        private void BindList()
        {
           
            rptBMList.DataSource = BM_dt;
            rptBMList.DataBind();

            rptBMShowList.DataSource = BM_dt;
            rptBMShowList.DataBind();

            DataTable dt = Article_dt.Copy();
            DataRow[] delRowArr = dt.Select("BT=''");
            foreach (DataRow row in delRowArr)
            {
                dt.Rows.Remove(row);
            }


            rptTitleList.DataSource = dt;
            rptTitleList.DataBind();

            rptTitleShowList.DataSource = dt;
            rptTitleShowList.DataBind();
        }
        #endregion

        #region 版面列表行绑定事件
        protected void rptBMList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HidPD = e.Item.FindControl("HidPD") as HiddenField;//PDF文件名
                HiddenField HidJP = e.Item.FindControl("HidJP") as HiddenField;//JPG文件名
                HiddenField HidBM = e.Item.FindControl("HidBM") as HiddenField;//版面
                HiddenField HidBC = e.Item.FindControl("HidBC") as HiddenField;//版次

                HyperLink HLinkPDFDown = e.Item.FindControl("HLinkPDFDown") as HyperLink;//PDF下载
                HyperLink HLinkSC = e.Item.FindControl("HLinkSC") as HyperLink;//收藏
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
