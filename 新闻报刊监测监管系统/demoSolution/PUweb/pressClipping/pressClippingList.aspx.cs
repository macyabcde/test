using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PU.Model;
using PU.BLL;

namespace PU.web.pressClipping
{
    /// <summary>
    /// 剪报制作
    /// </summary>
    public partial class pressClippingList : System.Web.UI.Page
    {
        /// <summary>
        /// 133	添加剪报
        /// </summary>
        private bool addPower = false;
        /// <summary>
        /// 134	修改剪报
        /// </summary>
        private bool editPower = false;
        /// <summary>
        /// 135	删除剪报
        /// </summary>
        private bool delPower = false;
        /// <summary>
        /// 136	剪报提交审批
        /// </summary>
        private bool tjspPower = false;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //132	剪报制作列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 132))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }
            //133	添加剪报
            addPower = Power.ifUserHavePower(webUser.UserGUID, 133);
            //134	修改剪报
            editPower = Power.ifUserHavePower(webUser.UserGUID, 134);
            //135	删除剪报
            delPower = Power.ifUserHavePower(webUser.UserGUID, 135);
            //136	剪报提交审批
            tjspPower = Power.ifUserHavePower(webUser.UserGUID, 136);

            if (!IsPostBack)
            {
                inIt();
                search();                
            }

        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inIt()
        {
            BtAdd.Enabled = addPower;

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
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();
            int pageSize = pageControl1.pageSize;
            int goPage = pageControl1.goPage;
            PubTool.DB.PageRetClass PageRetModel = pressClippingBasisInfoCs.getUserPressClippingList(pageSize, goPage);

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
            string commName = HidCommand.Value;
            //删除剪报
            if (commName == "del") del();
            //提交审批
            if (commName == "tjsp") tjsp();

        }
        #endregion

        #region 删除剪报
        /// <summary>
        /// 删除剪报
        /// </summary>
        protected void del()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();           
            int pressClippingBasisInfoID = int.Parse(HidValue.Value);
            MDL_pressClippingBasisInfoB model = pressClippingBasisInfoCs.GetModel(pressClippingBasisInfoID);
            if (delPower && model.state == 47 && model.createUserGUID == webUser.UserGUID)
            {
                pressClippingBasisInfoCs.Delete(pressClippingBasisInfoID);
                scp.Alert("删除成功！");
            }
            else {
                scp.Alert("对不起，您还未开通此权限！或本剪报未处在选编状态！");
            }
            dataBind();
        }
        #endregion

        #region 提交审批
        /// <summary>
        /// 提交审批
        /// </summary>
        protected void tjsp()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();
            int pressClippingBasisInfoID = int.Parse(HidValue.Value);
            MDL_pressClippingBasisInfoB model = pressClippingBasisInfoCs.GetModel(pressClippingBasisInfoID);
            if (tjspPower && model.createUserGUID == webUser.UserGUID)
            {
                PubTool.ReturnMsg msg = pressClippingBasisInfoCs.tjsp(pressClippingBasisInfoID);
                scp.Alert(msg.Msg + "！");
            }
            else
            {
                scp.Alert("对不起，您还未开通此权限");
            }
            dataBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptRetList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PM.BLL.BLL_databaseServerB bll_databaseServerB = new PM.BLL.BLL_databaseServerB();
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();

                HiddenField HidpressClippingBasisInfoID = e.Item.FindControl("HidpressClippingBasisInfoID") as HiddenField;//剪报基本信息ID
                HyperLink HLinkpressClippingName = e.Item.FindControl("HLinkpressClippingName") as HyperLink;//名称 
                Label Lbstate = e.Item.FindControl("Lbstate") as Label;//状态
                Label LbcreateTime = e.Item.FindControl("LbcreateTime") as Label;//创建时间
                HyperLink HLinkUpdate = e.Item.FindControl("HLinkUpdate") as HyperLink;//修改   
                HyperLink HLinkNewsList = e.Item.FindControl("HLinkNewsList") as HyperLink;//报道信息
                HyperLink HLinkDel = e.Item.FindControl("HLinkDel") as HyperLink;//删除
                HyperLink HLinkTJSP = e.Item.FindControl("HLinkTJSP") as HyperLink;//提交审批

                int pressClippingBasisInfoID = int.Parse(HidpressClippingBasisInfoID.Value);
                int state = int.Parse(Lbstate.Text);

                string pressClippingName = HLinkpressClippingName.Text;
                Lbstate.Text = dictionaryCs.Find(state);
                LbcreateTime.Text = DateTime.Parse(LbcreateTime.Text).ToString("yyyy-MM-dd HH:mm:ss");

                //提交审批  47	选编
                if (state == 47 && tjspPower)
                {
                    HLinkTJSP.Enabled = true;
                    HLinkTJSP.NavigateUrl = "javascript:tjsp(" + pressClippingBasisInfoID + ",'" + pressClippingName + "');";
                }
                else { HLinkTJSP.Enabled = false; }

                //删除
                if (state == 47 && delPower)
                {
                    HLinkDel.Enabled = true;
                    HLinkDel.NavigateUrl = "javascript:del(" + pressClippingBasisInfoID + ",'" + pressClippingName + "');";
                }
                else { HLinkDel.Enabled = false; }

                //修改
                if (state != 48 && state != 49 && editPower)
                {
                    HLinkUpdate.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=update','760','450');";
                    HLinkUpdate.Enabled = true;
                }
                else { HLinkUpdate.Enabled = false; }

                //查看
                HLinkpressClippingName.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=Look','760','450');";


                //报道信息
                HLinkNewsList.NavigateUrl = "javascript:windOpen('pressClippingNews.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "','980px','700px');";


            }
        }
        #endregion
    }
}

