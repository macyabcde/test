using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PU.web.Paper
{
    /// <summary>
    /// 版面概览
    /// </summary>
    public partial class titleIndex : System.Web.UI.Page
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
        /// 版面数据表
        /// </summary>
        public DataTable BM_dt = new DataTable();
        /// <summary>
        /// 文章数据表
        /// </summary>
        public DataTable Article_dt = new DataTable();
        /// <summary>
        /// 有标题的文章数据表
        /// </summary>
        private DataTable ArticleHaveBT_dt = new DataTable();
        /// <summary>
        /// 上一期
        /// </summary>
        private int PreRQ = 0;
        /// <summary>
        /// 下一期
        /// </summary>
        private int NetRQ = 0;

        /// <summary>
        /// 日历天html(几号)
        /// </summary>
        public string dateHtml = "";

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


            Components.DataOP dataOPCs = new Components.DataOP();
            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();


            paperID = int.Parse(Request.QueryString["paperID"].ToString());
            string RQTemp = Request.QueryString["RQ"];
            
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

           
            Article_dt = paperCs.getArticleListForSZB(paperID, "", RQ, RQ);
            ArticleHaveBT_dt = Article_dt.Copy();
            DataRow[] delRowArr = ArticleHaveBT_dt.Select("BT=''");
            foreach (DataRow row in delRowArr)
            {
                ArticleHaveBT_dt.Rows.Remove(row);
            }
           
            
            PreRQ = dataOPCs.getPreRQ(paperID, RQ);
            NetRQ = dataOPCs.getNextRQ(paperID, RQ);

            DateListInit();
            SetPagControl();
            BindList();

            Components.DataOP DataOPCs = new PU.web.Paper.Components.DataOP();

            int year = int.Parse(RQ.ToString().Substring(0, 4));
            int month = int.Parse(RQ.ToString().Substring(4, 2));
            dateHtml = DataOPCs.calendarDateHtml(paperID, year, month, RQ);
            dateHtml = dateHtml.Replace("\"", "\\\"");

        }

        #region 根据版次获取文章列表
        /// <summary>
        /// 根据版次获取文章列表
        /// </summary>
        /// <param name="BC">版次</param>
        /// <returns></returns>
        public DataTable getArticleList(string BC)
        {
            DataTable dt = new DataTable();

            DataRow[] RowArr = ArticleHaveBT_dt.Select("BC='" + BC + "'");
            if (RowArr.Length > 0) dt = RowArr.CopyToDataTable();
            return dt;
        }
        #endregion

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

       

        #region 页面控件赋值
        /// <summary>
        /// 页面控件赋值
        /// </summary>
        private void SetPagControl()
        {
            PU.BLL.BLL_paperB puPaperCs = new PU.BLL.BLL_paperB();
            PubTool.DateTimeConvert DateTimeConvCs = new PubTool.DateTimeConvert();
            DateTime nowRQ = PubTool.Convert.intToDate(RQ);
            string RQInfoStr = nowRQ.ToString("yyyy年MM月dd日") + " 星期" + DateTimeConvCs.getChinaWeekName(nowRQ.DayOfWeek) + " 出版";
            LbRQ.Text = RQInfoStr;

           
            string PaperName = puPaperCs.getPaperName(paperID);
            Title = PaperName;

            if (PreRQ != -1)
                HLinkPreRQ.NavigateUrl = "titleIndex.aspx?paperID=" + paperID + "&RQ=" + PreRQ;
            else
                HLinkPreRQ.NavigateUrl = "javascript:alert(\"当前已是第一期！\")";

            if (NetRQ != -1)
                HLinkNetRQ.NavigateUrl = "titleIndex.aspx?paperID=" + paperID + "&RQ=" + NetRQ;
            else
                HLinkNetRQ.NavigateUrl = "javascript:alert(\"当前已是最后一期！\")";
            
        }
        #endregion

        #region 列表绑定
        private void BindList()
        {
            rptBMShowList.DataSource = BM_dt;
            rptBMShowList.DataBind();
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
                HLinkBT.NavigateUrl = "BMList.aspx?paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC;

                if (PD != "")
                {
                    string pdfUrl = "../Resource/dowmResource.aspx?paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC + "&type=2" + "&fileName=" + PD;
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


            }
        }
        #endregion

       
    }
}
