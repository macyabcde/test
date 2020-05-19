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
    /// 剪报查询
    /// </summary>
    public partial class pressClippingSearchList : System.Web.UI.Page
    {
        /// <summary>
        ///  139	修改它人剪报
        /// </summary>
        private bool editPower = false;
        /// <summary>
        /// 140	删除它人剪报
        /// </summary>
        private bool delPower = false;
        /// <summary>
        /// 142	强制退回
        /// </summary>
        private bool QzReturnPower = false;


        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //139	修改它人剪报
            editPower = Power.ifUserHavePower(webUser.UserGUID, 139);
            //140	删除它人剪报
            delPower = Power.ifUserHavePower(webUser.UserGUID, 140);
            //142	强制退回
            QzReturnPower = Power.ifUserHavePower(webUser.UserGUID, 142);

            //138	剪报查询
            if (!Power.ifUserHavePower(webUser.UserGUID, 138))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

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
            PubTool.DropDownListOperate dpListCs = new PubTool.DropDownListOperate();
            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            DataTable dt = dictionaryCs.GetOnedictionaryType("pressClippingState");
            dpListCs.DropDownListBind(DPListstate, dt, "dictionaryName", "dictionaryInfoID", "状态", "0");
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

        #region 点击查询
        protected void BtSearch_Click(object sender, EventArgs e)
        {
            search();
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

            PubTool.DB.PageRetClass PageRetModel = pressClippingBasisInfoCs.getPressClippingList(txtpressClippingName.Text, int.Parse(DPListstate.SelectedValue), pageSize, goPage);

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
            //强制退回
            if (commName == "QzReturn") QzReturn();
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
            if (delPower)
            {
                pressClippingBasisInfoCs.Delete(pressClippingBasisInfoID);
                scp.Alert("删除成功！");
            }
            else
            {
                scp.Alert("对不起，您还未开通此权限！或本剪报未处在选编状态！");
            }
            dataBind();
        }
        #endregion

        #region 强制退回
        /// <summary>
        /// 强制退回
        /// </summary>
        protected void QzReturn()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();
            int pressClippingBasisInfoID = int.Parse(HidValue.Value);
            MDL_pressClippingBasisInfoB model = pressClippingBasisInfoCs.GetModel(pressClippingBasisInfoID);
            if (QzReturnPower)
            {
                model.state = 47;
                pressClippingBasisInfoCs.Update(model);
                scp.Alert("将[" + model.pressClippingName + "]强制退回到选编状态成功！");
            }
            else
            {
                scp.Alert("对不起，您还未开通此权限！");
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
                HyperLink HLinkNewsList = e.Item.FindControl("HLinkNewsList") as HyperLink;//报道信息 
                HyperLink HLinkUpdate = e.Item.FindControl("HLinkUpdate") as HyperLink;//修改
                HyperLink HLinkQZReturn = e.Item.FindControl("HLinkQZReturn") as HyperLink;//强制退回
                HyperLink HLinkDel = e.Item.FindControl("HLinkDel") as HyperLink;//删除
             

                int pressClippingBasisInfoID = int.Parse(HidpressClippingBasisInfoID.Value);
                int state = int.Parse(Lbstate.Text);
                string pressClippingName = HLinkpressClippingName.Text;

                Lbstate.Text = dictionaryCs.Find(state);
                LbcreateTime.Text = DateTime.Parse(LbcreateTime.Text).ToString("yyyy-MM-dd HH:mm:ss");

                //修改
                if (editPower)
                {
                    HLinkUpdate.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=update','760','450');";
                    HLinkUpdate.Enabled = true;
                }
                else { HLinkUpdate.Enabled = false; }

                //强制退回
                if (QzReturnPower)
                {
                    HLinkQZReturn.Enabled = true;
                    HLinkQZReturn.NavigateUrl = "javascript:QzReturn(" + pressClippingBasisInfoID + ",'" + pressClippingName + "');";
                }
                else { HLinkQZReturn.Enabled = false; }

                //删除
                if (delPower)
                {
                    HLinkDel.Enabled = true;
                    HLinkDel.NavigateUrl = "javascript:del(" + pressClippingBasisInfoID + ",'" + pressClippingName + "');";
                }
                else { HLinkDel.Enabled = false; }

                

                //查看
                HLinkpressClippingName.NavigateUrl = "javascript:windOpen('pressClippingAdd.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "&whatDo=Look','760','450');";
              
                //报道信息
                HLinkNewsList.NavigateUrl = "javascript:windOpen('pressClippingNews.aspx?pressClippingBasisInfoID=" + pressClippingBasisInfoID + "','980px','700px');";
            }
        }
        #endregion

       
    }
}
