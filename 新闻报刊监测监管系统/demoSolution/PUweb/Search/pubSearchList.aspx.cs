using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PU.web.Search
{
    public partial class pubSearchList : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 搜索关键字
        /// </summary>
        private string keyWord = "";

        /// <summary>
        /// 文章ID
        /// </summary>
        private string paperIDStr = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            if (Request.QueryString["paperIDStr"] != null && Request.QueryString["paperIDStr"] != "")
            {
                paperIDStr = Request.QueryString["paperIDStr"];
            }

            if (!IsPostBack)
            {
                if (tbKeyWord.Text != "")
                {
                    keyWord = tbKeyWord.Text;
                    lbKewWord.Text = tbKeyWord.Text;
                }
                else
                {
                    keyWord = Server.UrlDecode(Request.QueryString["key"]);
                    tbKeyWord.Text = keyWord;
                    lbKewWord.Text = tbKeyWord.Text;
                }
                if(tbKeyWord.Text!="") dataBind();
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void dataBind()
        {
            PM.ClientLibrary.Search SearchCs = new PM.ClientLibrary.Search();
            int startDate = 19900101;
            int endDate = 30000101;
            string fields = "KID,BT,ZZ,TX,RQ";
            keyWord = getKeyWord(tbKeyWord.Text);

            int pageSize = PageControl1.pageSize;
            int goPage = PageControl1.goPage;

            PubTool.DB.PageRetClass PageRetModel = new PubTool.DB.PageRetClass();
            PageRetModel = SearchCs.FullSearch(paperIDStr, startDate, endDate, fields, 203, keyWord,"and", "", pageSize, goPage);

            DataTable dt = PageControl1.getPageDataForPageRet(PageRetModel);
            rptData.DataSource = dt;
            rptData.DataBind();
        }
        #endregion

        #region 点击查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbKeyWord.Text == "")
            {
                tbKeyWord.Focus();
                return;
            }

            lbKewWord.Text = tbKeyWord.Text;
            dataBind();
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
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }
        #endregion

        #region 点击翻页
        protected void PageControl1_Click(object sender, EventArgs e)
        {
            dataBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HyperLink hylinkBT = e.Item.FindControl("hylinkBT") as HyperLink;
                HiddenField HFKID = e.Item.FindControl("HFKID") as HiddenField;
                Label lbTX = e.Item.FindControl("lbTX") as Label;

                Label lbRQ = e.Item.FindControl("lbRQ") as Label;
                Int64 KID = Int64.Parse(HFKID.Value);
                lbRQ.Text = PubTool.Convert.intToDateStr(int.Parse(lbRQ.Text));
                hylinkBT.NavigateUrl = "../Paper/ArticlePage.aspx?KID=" + KID;



                int start = 0;
                int over=0;
                string[] keyArr = getKeyWord(keyWord).Split(',');

                if (keyArr.Length == 0) return;

                int length=lbTX.Text.Length;
                int oneKewLength = lbTX.Text.IndexOf(keyArr[0]);

                if (oneKewLength < 100) start = 0;

                if (oneKewLength > 100) start = oneKewLength - 100;

                if (length > 200)
                {
                    over = 200;
                }
                else
                {
                    over = length;
                }

                lbTX.Text = lbTX.Text.Substring(start, over-1).Trim();

                if (start != 0)
                {
                    lbTX.Text = "..." + lbTX.Text;
                }


                 lbTX.Text = lbTX.Text + "...";

                 string temp = lbTX.Text;

                 foreach (string key in keyArr)
                 {
                     temp = temp.Replace(key, "<span style='color:red'>" + key + "</span>");
                 }

                 lbTX.Text = temp;
            }
        }
        #endregion
    }
}
