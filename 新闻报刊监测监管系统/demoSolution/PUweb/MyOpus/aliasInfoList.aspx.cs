using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyOpus
{
    /// <summary>
    /// 笔名设置
    /// </summary>
    public partial class aliasInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();

            //119	笔名维护
            if (!Power.ifUserHavePower(webUser.UserGUID, 119))
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
            PU.BLL.BLL_aliasInfoB aliasInfoCs = new PU.BLL.BLL_aliasInfoB();

            DataTable dt = aliasInfoCs.getUserAliasInfoList();
            rptRetList.DataSource = dt;
            rptRetList.DataBind();
        }
        #endregion


        #region 添加笔名
        protected void BtAdd_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (txtaliasInfo.Text == "")
            {
                scp.Alert("请输入笔名！");
                return;
            }
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.Model.MDL_aliasInfoB model = new PU.Model.MDL_aliasInfoB();
            model.userGUID = webUser.UserGUID;
            model.aliasInfo = txtaliasInfo.Text;

            PU.BLL.BLL_aliasInfoB aliasInfoCs = new PU.BLL.BLL_aliasInfoB();
            aliasInfoCs.Add(model);
            txtaliasInfo.Text = "";
            dataBind();
        }
        #endregion

        #region 多功能按钮事件
        protected void BtCommand_Click(object sender, EventArgs e)
        {
            string CommandName = HidCommand.Value;
            if (CommandName == "del")
            {
                PU.BLL.BLL_aliasInfoB aliasInfoCs = new PU.BLL.BLL_aliasInfoB();
                aliasInfoCs.Delete(int.Parse(HidValue.Value));
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
                HiddenField HidaliasInfoID = e.Item.FindControl("HidaliasInfoID") as HiddenField;//笔名信息ID                
                HyperLink HLinkDel = e.Item.FindControl("HLinkDel") as HyperLink;//删除          
                Label LbcreateTime = e.Item.FindControl("LbcreateTime") as Label;//创建时间
                Label LbaliasInfo = e.Item.FindControl("LbaliasInfo") as Label;//笔名

                string aliasInfo = LbaliasInfo.Text;
                int aliasInfoID = int.Parse(HidaliasInfoID.Value);

                LbcreateTime.Text = DateTime.Parse(LbcreateTime.Text).ToString("yyyy-MM-dd HH:mm:ss");

                //删除
                HLinkDel.NavigateUrl = "javascript:del(" + aliasInfoID + ",'" + aliasInfo + "');";
            }
        }
        #endregion
    }
}
