using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyOpus
{
    public partial class opusNewsQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();

            //116	我的作品列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 116))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            if (!IsPostBack)
            {
                dataBind();
            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void dataBind()
        {
            string key = Request.QueryString["key"].ToString();
            PubTool.ExchangeData ExchangeDataCs = new PubTool.ExchangeData();
            string KIDStr = ExchangeDataCs.getExchangeData(key);
            DataTable dt = new DataTable();
            if (KIDStr == "")
            {
                Response.Write("第二次加载。");
                return;
            }
            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();
            dt = PaperCs.getDataWithKID(KIDStr, "KID,paperID,BT,ZZ,MC,RQ,BC,BM,PD,JP");

            rptRetList.DataSource = dt;
            rptRetList.DataBind();
           
        }
        #endregion

        


        #region 确认所选
        protected void BtQR0_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            int delsl = 0;
            opusNewsInfoCs.addOpusNewsForKIDStr(HidValue.Value, 0,out delsl);
            opusNewsInfoCs.addOpusNewsForKIDStr(HidValueNot.Value, 1, out delsl);
            
            scp.ClickParentPageButton("BtRef");
            scp.AlertAndClose("确认成功！");
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
                HLinkBT.NavigateUrl = "javascript:windOpen('../Search/LookArticle.aspx?KID=" + KID + "','980px','730px');";

            }
        }
        #endregion
    }
}
