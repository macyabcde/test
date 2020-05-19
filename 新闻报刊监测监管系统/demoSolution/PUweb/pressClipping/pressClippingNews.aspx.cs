using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PU.BLL;
using System.Data;
using PU.Model;

namespace PU.web.pressClipping
{
    /// <summary>
    /// 报道信息
    /// </summary>
    public partial class pressClippingNews : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 剪报基本信息ID
        /// </summary>
        private int pressClippingBasisInfoID;
        
        /// <summary>
        /// 137	剪报审批
        /// </summary>
        private bool spPower = false;
        /// <summary>
        /// 138	剪报查询
        /// </summary>
        private bool searchPower = false;
        /// <summary>
        /// 141	维护它人剪报报道信息
        /// </summary>
        private bool wfOtherInfoListPower = false;

        /// <summary>
        /// 操作命令
        /// </summary>
        private string whatDo = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();
           
            //137	剪报审批
            spPower = Power.ifUserHavePower(webUser.UserGUID, 137);
            //138	剪报查询
            searchPower = Power.ifUserHavePower(webUser.UserGUID, 138);
            //141	维护它人剪报报道信息
            wfOtherInfoListPower = Power.ifUserHavePower(webUser.UserGUID, 141);


            pressClippingBasisInfoID = int.Parse(Request.QueryString["pressClippingBasisInfoID"]);
            whatDo = Request.QueryString["whatDo"];

            if (!IsPostBack)
            {
                inItPage(); //页面初始化
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        private void inItPage()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);

            if (!searchPower && model.createUserGUID != webUser.UserGUID)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            btnRemove.Visible = false;
            if ((model.state == 48 && spPower) || (model.state == 47 && model.createUserGUID == webUser.UserGUID) || wfOtherInfoListPower) btnRemove.Visible = true;


            ListBind();
        }
        #endregion

        #region 绑定报道列表
        /// <summary>
        /// 绑定报道列表
        /// </summary>
        private void ListBind()
        {
            BLL_pressClippingNewsInfoB bllPressClippingNewsInfo = new BLL_pressClippingNewsInfoB();
            DataTable dt = bllPressClippingNewsInfo.GetPressClippingNewsInfoList(pressClippingBasisInfoID);
            rptPressClippingNewsInfo.DataSource = dt;
            rptPressClippingNewsInfo.DataBind();
        }
        #endregion

        #region 移除报道
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            BLL_pressClippingNewsInfoB bllPressClippingNewsInfo = new BLL_pressClippingNewsInfoB();
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);

            if (model == null) return;

            
            if (!((model.state == 48 && spPower) || (model.state == 47 && model.createUserGUID == webUser.UserGUID) || wfOtherInfoListPower))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            string pressClippingNewsInfoIDStr = HFpressClippingNewsInfoIDStr.Value;

            if (pressClippingNewsInfoIDStr == "") return;

            int pressClippingNewsInfoID=0;

            int Ok = 0;
            foreach (string temp in pressClippingNewsInfoIDStr.Split(','))
            {
                if (temp == "") continue;
                pressClippingNewsInfoID = int.Parse(temp);

                bllPressClippingNewsInfo.Delete(pressClippingNewsInfoID);

                Ok++;
            }

            scp.Alert("有" + Ok.ToString() + "篇剪报报道信息移除成功！");
            ListBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptPressClippingNewsInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
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
                Label lbRQ = e.Item.FindControl("lbRQ") as Label;//日期


                Int64 KID = Int64.Parse(HidKID.Value);
                int RQ = int.Parse(lbRQ.Text);
                string PD = HidPD.Value;
                string JP = HidJP.Value;
                int paperID = int.Parse(HidpaperID.Value);
                string BC = HidBC.Value;

                lbRQ.Text = PubTool.Convert.intToDateStr(RQ);

                if (HLinkBT.Text == "" || HLinkBT.Text == "&nbsp;") HLinkBT.Text = "无标题";
                //查看文章
                HLinkBT.NavigateUrl = "javascript:windOpen('../Search/LookArticle.aspx?KID=" + KID + "','980px','730px');";

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
    }
}
