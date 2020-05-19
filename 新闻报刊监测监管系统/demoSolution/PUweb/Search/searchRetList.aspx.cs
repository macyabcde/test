using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;

namespace PU.web.Search
{
    public partial class searchRetList : System.Web.UI.Page
    {
        #region 自定义属性
        /// <summary>
        /// 分组类型。year：年、paper：报纸、PT：不分组（全部显示）
        /// </summary>
        public string GroupType = "";

        /// <summary>
        /// 年份分组表
        /// </summary>
        public DataTable year_dt = new DataTable();
        /// <summary>
        /// 报纸分组表
        /// </summary>
        public DataTable paper_dt = new DataTable();

        /// <summary>
        /// 年月分组表
        /// </summary>
        private DataTable yearMonth_dt = new DataTable();

        /// <summary>
        /// 结果总行数
        /// </summary>
        public int totalRowSL = 0;

        /// <summary>
        /// 检索的关键词参数。用于传到内容页面标出关键
        /// </summary>
        private string keypar = "";

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();


            //112	经典检索
            bool jdPower = Power.ifUserHavePower(webUser.UserGUID, 112);
            //113	而且检索
            bool andPower = Power.ifUserHavePower(webUser.UserGUID, 113);
            //114	或者检索
            bool orPower = Power.ifUserHavePower(webUser.UserGUID, 114);
            //115	分项检索
            bool fxPower = Power.ifUserHavePower(webUser.UserGUID, 115);
            if (!jdPower && !andPower && !orPower && !fxPower)
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            //108	报道收藏
            bool SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            //109	报道推荐
            bool tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);
            //110	作品报道选编
            bool zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            //111	剪报报道选编
            bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);

            BtFavorites.Enabled = SCPower;
            BtRecommend.Enabled = tjPower;
            BtClippingSend.Enabled = jbPower;
            BtMyOpus.Enabled = zpPower;

            PubTool.ExchangeData ExchangeDataCs = new PubTool.ExchangeData();
            GroupType = HidGroupType.Value;

            if (!IsPostBack)
            {
                string Key = Request.QueryString["Key"].ToString();
                string DataValue = ExchangeDataCs.getExchangeData(Key);
               
                if (DataValue != "" && DataValue != "#null")
                {
                    HidTJ.Value = DataValue;//交提到本页面的检索参数
                    HttpCookie cookie = new HttpCookie("searchCookie");
                    cookie.Values.Add("cs", Server.UrlEncode(DataValue));
                    Response.AppendCookie(cookie);
                }
                else
                {
                    DataValue = Request.Cookies["searchCookie"].Values["cs"];
                    DataValue = Server.UrlDecode(DataValue);
                    HidTJ.Value = DataValue;
                }
                inIt();
                search();
            }

        }

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inIt()
        {
            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            DataTable dt = dictionaryCs.GetOnedictionaryType("searchRetOrder");
            DPListsearchRetOrder.DataValueField = "dictionaryInfoID";
            DPListsearchRetOrder.DataTextField = "dictionaryName";
            DPListsearchRetOrder.DataSource = dt;
            DPListsearchRetOrder.DataBind();

            PubTool.Parameters par = new PubTool.Parameters(HidTJ.Value);
            DPListsearchRetOrder.SelectedValue = par.getValue("searchRetOrder");
            LbKeyWord.Text = par.getValue("KeyWord");
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
            PM.ClientLibrary.Search SearchCs = new PM.ClientLibrary.Search();
            PubTool.Parameters par = new PubTool.Parameters(HidTJ.Value);
            string paperIDStr = delSamePaperID(par.getValue("paperIDStr"));
            int startDate = int.Parse(par.getValue("startDate").Replace("-", ""));
            int endDate = int.Parse(par.getValue("endDate").Replace("-", ""));
            string fields = "KID,BT,ZZ,MC,RQ,BM,JP,PD,paperID,BC";
            int searchRetOrder = int.Parse(DPListsearchRetOrder.SelectedValue);
            string KeyWord = getKeyWord(par.getValue("KeyWord"));
            string KeyWordCondition = par.getValue("KeyWordCondition");
            string notInKeyWord = getKeyWord(par.getValue("notInKeyWord"));
            string xml = par.getValue("xml");
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;

            if (xml == "")
                keypar = KeyWord;
            else
                keypar = getFXKeyWord(xml);

            LbKeyWord.Text = keypar.Replace(",", " ");

            PubTool.DB.PageRetClass PageRetModel = new PubTool.DB.PageRetClass();
            if (GroupType == "PT")
            {
                if (xml == "")
                    PageRetModel = SearchCs.FullSearchToGroup(paperIDStr, startDate, endDate, fields, searchRetOrder, KeyWord, KeyWordCondition, notInKeyWord, pageSize, goPage);
                else
                    PageRetModel = SearchCs.FXSearchToGroup(paperIDStr, startDate, endDate, fields, searchRetOrder, xml, pageSize, goPage);
            }
            if (GroupType == "year")
            {
                int Year = int.Parse(HidGroupValue.Value);
                if (xml == "")
                    PageRetModel = SearchCs.FullSearchToGroupGetYear(paperIDStr, startDate, endDate, fields, searchRetOrder, KeyWord, KeyWordCondition, notInKeyWord, Year, pageSize, goPage);
                else
                    PageRetModel = SearchCs.FXSearchToGroupGetYear(paperIDStr, startDate, endDate, fields, searchRetOrder, xml, Year, pageSize, goPage);
            }
            if (GroupType == "paper")
            {
                int paperID = int.Parse(HidGroupValue.Value);
                if (xml == "")
                    PageRetModel = SearchCs.FullSearchToGroupGetPaper(paperIDStr, startDate, endDate, fields, searchRetOrder, KeyWord, KeyWordCondition, notInKeyWord, paperID, pageSize, goPage);
                else
                    PageRetModel = SearchCs.FXSearchToGroupGetPaper(paperIDStr, startDate, endDate, fields, searchRetOrder, xml, paperID, pageSize, goPage);
            }

            year_dt = PageRetModel.otherDS.Tables[0];
            paper_dt = PageRetModel.otherDS.Tables[1];
            yearMonth_dt = PageRetModel.otherDS.Tables[2];
            DataTable dt = pageControl1.getPageDataForPageRet(PageRetModel);
            rptRetList.DataSource = dt;
            rptRetList.DataBind();

            totalRowSL = 0;
            foreach (DataRow row in year_dt.Rows)
            {
                totalRowSL += int.Parse(row["rowSL"].ToString());
            }

            LbRetTotalSL.Text = totalRowSL.ToString();

        }
        #endregion

        #region 根据年份获取月份数据信息列表
        /// <summary>
        /// 根据年份获取月份数据信息列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public DataTable getYearMonthInfoList(int year)
        {
            DataTable dt = new DataTable();
            int start = int.Parse(year.ToString() + "01");
            int end = int.Parse(year.ToString() + "12");
            DataRow[] arr = yearMonth_dt.Select("yearMonth>=" + start + " and yearMonth<=" + end);
            if (arr.Length > 0) dt = arr.CopyToDataTable();
            return dt;
        }
        #endregion

        #region 百分比计算
        /// <summary>
        /// 百分比计算
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Percen(int value)
        {
            int total = totalRowSL;
            if (total == 0) return 0;
            double p = ((double)value / (double)total) * 100;
            int ret = int.Parse(Math.Round(p).ToString());
            if (ret == 0) ret = 1;
            return ret;
        }
        #endregion

        #region 百分比计算
        /// <summary>
        /// 百分比计算
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public double PercenShow(int value)
        {
            int total = totalRowSL;
            if (total == 0) return 0;
            double p = ((double)value / (double)total) * 100;
            return p;
        }
        #endregion

        #region 获取报名称
        /// <summary>
        /// 获取报名称
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <returns></returns>
        public string getPaperName(int paperID)
        {
            PU.BLL.BLL_paperB paperCs = new PU.BLL.BLL_paperB();
            string paperName = paperCs.getPaperName(paperID);            
            return paperName;
        }
        #endregion

        #region 去除重复的报纸ID
        /// <summary>
        /// 去除重复的报纸ID
        /// </summary>
        /// <param name="paperIDStr">报纸串</param>
        /// <returns></returns>
        protected string delSamePaperID(string paperIDStr)
        {
            Dictionary<string, int> dic = PubTool.Convert.strToDic(paperIDStr);
            string ret = PubTool.Convert.DicToStr(dic);
            return ret;
        }
        #endregion

        #region 处理关键词(把空格换成“,”)
        /// <summary>
        /// 处理关键词(把空格换成“,”)
        /// </summary>
        /// <param name="KeyWord">关键词串</param>
        /// <returns></returns>
        protected string getKeyWord(string KeyWord)
        {
            KeyWord = KeyWord.Replace("　", " ");
            string[] arr = KeyWord.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0) sb.Append(",");
                sb.Append(arr[i].Trim());
            }
            return sb.ToString();
        }
        #endregion

        #region 获取分项检索XML中的关键词
        /// <summary>
        /// 获取分项检索XML中的关键词
        /// </summary>
        /// <param name="xml">检索XML</param>
        /// <returns></returns>
        protected string getFXKeyWord(string xml)
        {
            if (xml == "") return "";
            XmlDocument xmldoc = null;
            XmlElement xmlRoot;
            xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            xmlRoot = xmldoc.DocumentElement;

            XmlNode Node = xmlRoot.SelectSingleNode("fields");
            if (Node == null) return "";
            string keyStr = "";
            foreach (XmlNode node in Node.ChildNodes)
            {
                string key = node.InnerText;
                if (key != "")
                {
                    if (keyStr != "") keyStr += ",";
                    keyStr += key;
                }
            }
            return keyStr;
        }
        #endregion

        

        #region 翻页事件
        protected void pageControl1_Click(object sender, EventArgs e)
        {
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
                HiddenField HidBC = e.Item.FindControl("HidBC") as HiddenField;//版次
                HyperLink HLinkBT = e.Item.FindControl("HLinkBT") as HyperLink;//标题
                HyperLink HLinkPD = e.Item.FindControl("HLinkPD") as HyperLink;//PDF下载
                HyperLink HLinkJP = e.Item.FindControl("HLinkJP") as HyperLink; //JPG下载
                Label LbRQ = e.Item.FindControl("LbRQ") as Label;//日期


                Int64 KID = Int64.Parse(HidKID.Value);
                int RQ = int.Parse(LbRQ.Text);
                string PD = HidPD.Value;
                string JP = HidJP.Value;
                int paperID = int.Parse(HidpaperID.Value);
                string BC = HidBC.Value;

                LbRQ.Text = PubTool.Convert.intToDateStr(RQ);

                if (HLinkBT.Text == "" || HLinkBT.Text == "&nbsp;") HLinkBT.Text = "无标题";
                //查看文章
                //HLinkBT.NavigateUrl = "javascript:windOpen('LookArticle.aspx?KID=" + KID + "&keypar=" + Server.UrlEncode(keypar) + "','980px','730px');";
                HLinkBT.NavigateUrl = "javascript:windOpen('LookArticle.aspx?KID=" + KID + "&keypar=" + keypar + "','980px','730px');";

                if (PD != "")
                {
                    string pdfUrl = "../Resource/dowmResource.aspx?KID=" + KID + "&paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC + "&type=2" + "&fileName=" + PD;
                    HLinkPD.Enabled = true;
                    HLinkPD.Text = "<img src=\"../images/pdf01.gif\"  title=\"下载版面PDF\" border=\"0\"/>";
                    HLinkPD.NavigateUrl = "javascript:windOpen('" + pdfUrl + "','10px','10px');";
                }
                else
                {
                    HLinkPD.Enabled = false;
                    HLinkPD.Text = "<img src=\"../images/pdf02.gif\"  title=\"下载版面PDF\" border=\"0\"/>";
                    HLinkPD.NavigateUrl = "";
                }

                if (JP != "")
                {
                    string jpgUrl = "../Resource/dowmResource.aspx?KID=" + KID + "&paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC + "&type=1" + "&fileName=" + JP;
                    HLinkJP.Enabled = true;
                    HLinkJP.Text = "<img src=\"../images/jpg01.gif\"  title=\"下载版面JPG\" border=\"0\"/>";
                    HLinkJP.NavigateUrl = "javascript:windOpen('" + jpgUrl + "','10px','10px');";
                }
                else
                {
                    HLinkJP.Enabled = false;
                    HLinkJP.Text = "<img src=\"../images/jpg02.gif\"  title=\"下载版面JPG\" border=\"0\"/>";
                    HLinkJP.NavigateUrl = "";
                }
            }
        }
        #endregion

        #region 刷新        
        protected void BtRef_Click(object sender, EventArgs e)
        {
            dataBind();            
        }
        #endregion

        #region 刷新到第一页
        protected void BtRefGoFirst_Click(object sender, EventArgs e)
        {
            search();
        }
        #endregion

        #region 排序变化事件
        protected void DPListsearchRetOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }
        #endregion
    }
}
