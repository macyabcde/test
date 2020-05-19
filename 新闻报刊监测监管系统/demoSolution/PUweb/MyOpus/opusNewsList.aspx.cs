using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PU.web.MyOpus
{
    /// <summary>
    /// 我的作品
    /// </summary>
    public partial class opusNewsList : System.Web.UI.Page
    {
        /// <summary>
        /// 要执行的javascript函数
        /// </summary>
        public string exfunction="";

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //116	我的作品列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 116))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }


            //108	报道收藏
            bool SCPower = Power.ifUserHavePower(webUser.UserGUID, 108);
            //109	报道推荐
            bool tjPower = Power.ifUserHavePower(webUser.UserGUID, 109);           
            //111	剪报报道选编
            bool jbPower = Power.ifUserHavePower(webUser.UserGUID, 111);
            //119	笔名维护
            bool bmPower = Power.ifUserHavePower(webUser.UserGUID, 119);

            BtRecommend.Enabled = tjPower;
            BtClippingSend.Enabled = jbPower;
            BtFavorites.Enabled = SCPower;
            BtSetaliasInfo.Enabled = bmPower;


            if (!IsPostBack)
            {
                inIt();
                createUserOpus();
                search();
                exfunction = "checkNewOpus();";
            }

        }


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inIt()
        {
            BtNotQR.Visible = false;
            BtQR.Visible = false;
            int ConfirmState = int.Parse(DpListConfirmState.SelectedValue);
            if (ConfirmState == 0) BtNotQR.Visible = true;
            if (ConfirmState == 1) BtQR.Visible = true;
        }
        #endregion

        #region 生成当前用户的作品列表(只有用户第一次使用才会运行)
        /// <summary>
        /// 生成当前用户的作品列表(只有用户第一次使用才会运行)
        /// </summary>
        protected void createUserOpus()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_opusBasisInfoB pusBasisInfoCs = new PU.BLL.BLL_opusBasisInfoB();
            int opusBasisInfoID = pusBasisInfoCs.getOpusBasisInfoID();//作品基本信息ID
           
            PU.Model.MDL_opusBasisInfoB modelOpusBasis = pusBasisInfoCs.GetModel(opusBasisInfoID);
            if (modelOpusBasis.ifAutoCreate == 0)
            {
                PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
                DataTable dt = opusNewsInfoCs.getUserNewOpusList();

                StringBuilder KID_sb = new StringBuilder();
                int index = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (index != 0) KID_sb.Append(",");
                    KID_sb.Append(row["KID"].ToString());
                    index++;
                }
                int delsl = 0;
                opusNewsInfoCs.addOpusNewsForKIDStr(KID_sb.ToString(), 0,out delsl);

                modelOpusBasis.ifAutoCreate = 1;
                modelOpusBasis.dataUpdateTime = DateTime.Now;
                pusBasisInfoCs.Update(modelOpusBasis);
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
            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;
            
            int ConfirmState = int.Parse(DpListConfirmState.SelectedValue);
            PubTool.DB.PageRetClass PageRetModel = opusNewsInfoCs.getUserOpusNewsList(ConfirmState, pageSize, goPage);

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

        #region 已确认所选的推荐报道
        protected void BtQR_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            string opusNewsInfoIDStr = HidValue.Value;
            opusNewsInfoCs.setConfirmState(0, opusNewsInfoIDStr);

            scp.Alert("设置已确认成功！");
            dataBind();

        }
        #endregion

        #region 未确认所选的推荐报道
        protected void BtNotQR_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            string opusNewsInfoIDStr = HidValue.Value;
            opusNewsInfoCs.setConfirmState(1, opusNewsInfoIDStr);

            scp.Alert("设置未确认成功！");
            dataBind();

        }
        #endregion

        protected void DpListConfirmState_SelectedIndexChanged(object sender, EventArgs e)
        {
            inIt();
            search();
        }
    }
}
