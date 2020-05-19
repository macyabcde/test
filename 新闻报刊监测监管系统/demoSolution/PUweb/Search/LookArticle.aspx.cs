using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Search
{
    /// <summary>
    /// 文章信息显示页面
    /// </summary>
    public partial class LookArticle : System.Web.UI.Page
    {
        #region 自定义字段
        /// <summary>
        /// 文章实体
        /// </summary>
        public PM.Model.MDL_ArticleInfoB ArticleJG = new PM.Model.MDL_ArticleInfoB();
        /// <summary>
        /// 版面JPG图url
        /// </summary>
        public string jpgUrl = "";
        /// <summary>
        /// 版面其它信息
        /// </summary>
        public string bmOtherInfo = "";
        /// <summary>
        /// 文章KID
        /// </summary>
        private Int64 KID = 0;

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
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            //162	文章内容查看
            bool lookPower = Power.ifUserHavePower(webUser.UserGUID, 162);
            if (!lookPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            //108	报道收藏
            bool SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            //109	报道推荐
            bool tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);
            //110	作品报道选编
            bool zpPower = Power.ifUserHavePower(webUser.UserGUID, 110);
            //111	剪报报道选编
            bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);
            //160	报道修改
            bool editPower = Power.ifUserHavePower(webUser.UserGUID, 160);

            BtFavorites.Enabled = SCPower;
            BtRecommend.Enabled = tjPower;
            BtClippingSend.Enabled = jbPower;
            BtMyOpus.Enabled = zpPower;
            BtEdit.Enabled = editPower;

            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();

            KID = Int64.Parse(Request.QueryString["KID"].ToString());
            ArticleJG = PaperCs.getArticleInfoBModel(KID);
            if (ArticleJG == null)
            {
                scp.AlertAndClose("该报道已被删除或已被更新！");
                Response.End();
            }

            keypar = Request.QueryString["keypar"];
            if (keypar == null) keypar = "";
            keypar = Server.UrlDecode(keypar);
            //Response.Write("keypar=" + keypar);

            inItPage();
        }



        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inItPage()
        {
            BtFavorites.OnClientClick = "addNewsCollection('" + ArticleJG.KID + "');return false";
            BtRecommend.OnClientClick = "addNewsRecommend('" + ArticleJG.KID + "');return false";
            BtClippingSend.OnClientClick = "addClippingNewes('" + ArticleJG.KID + "');return false";
            BtMyOpus.OnClientClick = "addOpusNewsInfo('" + ArticleJG.KID + "');return false";
            BtEPaper.OnClientClick = "window.open('../Paper/ArticlePage.aspx?KID=" + ArticleJG.KID + "');return false";

            BtEdit.OnClientClick = "window.location = 'ArticleEdit.aspx?KID=" + ArticleJG.KID + "';return false";
            if (ArticleJG.PD != "")
            {
                string pdfurl = "../Resource/dowmResource.aspx?paperID=" + ArticleJG.paperID + "&RQ=" + ArticleJG.RQ + "&BC=" + ArticleJG.BC + "&type=2" + "&fileName=" + ArticleJG.PD;
                BtFDFDown.OnClientClick = "windOpen('" + pdfurl + "',200,200);return false;";
            }
            else
            {
                BtFDFDown.Enabled = false;
            }


            WriteDataToPage();
        }
        #endregion

        #region 将文章信息写到页面
        /// <summary>
        /// 将文章信息写到页面
        /// </summary>
        protected void WriteDataToPage()
        {
            if (ArticleJG.BT == "") ArticleJG.BT = "无标题";

            Title = ArticleJG.BT;

            jpgUrl = "../Resource/getResource.aspx?KID=" + KID + "&paperID=" + ArticleJG.paperID + "&RQ=" + ArticleJG.RQ + "&BC=" + ArticleJG.BC + "&type=1" + "&fileName=" + ArticleJG.JP;


            bmOtherInfo = MarkKey(ArticleJG.MC + "&nbsp;&nbsp;" + PubTool.Convert.intToDateStr(ArticleJG.RQ) + "&nbsp;&nbsp;" + "第" + ArticleJG.BC + "版");

            if (ArticleJG.BM != "")
            {
                bmOtherInfo += "&nbsp;&nbsp;" + MarkKey(ArticleJG.BM);
            }
            if (ArticleJG.LM != "")
            {
                bmOtherInfo += "&nbsp;&nbsp;" + MarkKey(ArticleJG.LM);
            }
            if (ArticleJG.FL != "")
            {
                bmOtherInfo += "&nbsp;&nbsp;" + MarkKey(ArticleJG.FL);
            }
            if (ArticleJG.BJ != "")
            {
                bmOtherInfo += "&nbsp;&nbsp;" + MarkKey(ArticleJG.BJ);
            }

            BtFavorites.OnClientClick = "addNewsCollection('" + ArticleJG.KID + "');return false";
            BtRecommend.OnClientClick = "addNewsRecommend('" + ArticleJG.KID + "');return false";
            BtClippingSend.OnClientClick = "addClippingNewes('" + ArticleJG.KID + "');return false";
            BtMyOpus.OnClientClick = "addOpusNewsInfo('" + ArticleJG.KID + "');return false";
            BtEPaper.OnClientClick = "window.open('../Paper/ArticlePage.aspx?KID=" + ArticleJG.KID + "');return false";

            BtEdit.OnClientClick = "window.location = 'ArticleEdit.aspx?KID=" + ArticleJG.KID + "';return false";
            if (ArticleJG.PD != "")
            {
                string pdfurl = "../Resource/dowmResource.aspx?paperID=" + ArticleJG.paperID + "&RQ=" + ArticleJG.RQ + "&BC=" + ArticleJG.BC + "&type=2" + "&fileName=" + ArticleJG.PD;
                BtFDFDown.OnClientClick = "windOpen('" + pdfurl + "',200,200);return false;";
            }
            else
            {
                BtFDFDown.Enabled = false;
            }
        }
        #endregion

        #region 标注关键词
        /// <summary>
        /// 标注关键词
        /// </summary>
        /// <param name="txt">待标注的文本</param>
        public string MarkKey(string txt)
        {
            string ret = txt;
            string[] keyArr = keypar.Split(',');
            foreach (string key in keyArr)
            {
                if (key == "") continue;
                ret = ret.Replace(key, "<span style='color:red'>" + key + "</span>");
            }
            return ret;
        }
        #endregion


    }
}
