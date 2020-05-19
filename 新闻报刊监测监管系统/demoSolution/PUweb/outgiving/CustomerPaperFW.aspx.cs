using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PU.BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace PU.web.outgiving
{
    /// <summary>
    /// 客户报纸范围
    /// </summary>
    public partial class CustomerPaperFW : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 客户ID
        /// </summary>
        private string customerID;

        /// <summary>
        /// 客户已有报纸信息ID集合
        /// </summary>
        private List<int> customerPaperList = new List<int>();

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();

            //148	客户报纸范围管理
            if (!Power.ifUserHavePower(webUser.UserGUID, 148))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            customerID = Request.QueryString["customerID"];
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
            BLL_customerBasisInfoB bllCustomerBasisInfo = new BLL_customerBasisInfoB();
            lbwhatDo.Text = "报纸范围(" + bllCustomerBasisInfo.GetModel(customerID).customerName + ")";
            btnLook.OnClientClick = "windOpen('CustomerHavePaper.aspx?whatDo=update&customerID=" + customerID + "','900','600'); return false;";
            ListBind(); 
        }
        #endregion

        #region 绑定报纸信息列表
        /// <summary>
        /// 绑定报纸信息列表
        /// </summary>
        private void ListBind()
        {
            BLL_paperB bllpaper = new BLL_paperB();
            DataTable dt = bllpaper.getAllPaperList();

            BLL_customerPaperInfoB bllCustomerPaperInfo = new BLL_customerPaperInfoB();
            customerPaperList = bllCustomerPaperInfo.GetCustomerPaperIDArr(customerID);

            rptCustomerPaper.DataSource = dt;
            rptCustomerPaper.DataBind();
        }
        #endregion

        #region 报纸信息行绑定事件
        protected void rptCustomerPaper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                BLL_customerPaperInfoB bllCustomerPaperInfo = new BLL_customerPaperInfoB();
                HtmlInputCheckBox cbPaperID = e.Item.FindControl("cbPaperID") as HtmlInputCheckBox; //报纸信息ID

                TextBox tbupdateOverDate = e.Item.FindControl("tbupdateOverDate") as TextBox;

                int paperID = int.Parse(cbPaperID.Value);

                tbupdateOverDate.Attributes.Add("paperID", paperID.ToString());

                if (customerPaperList.Contains(paperID))
                {
                    tbupdateOverDate.Text = bllCustomerPaperInfo.GetModelForPaperID(paperID,customerID).updateOverDate.ToString("yyyy-MM-dd");
                    cbPaperID.Checked = true;
                }
            }
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            BLL_customerPaperInfoB bllCustomerPaperInfo = new BLL_customerPaperInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PubTool.ReturnMsg Msg = bllCustomerPaperInfo.Add(HFcustomerPaperStr.Value.Split(','), customerID, HFupdateOverDateStr.Value.Split(','));
            scp.Alert(Msg.Msg);
            ListBind();
        }
        #endregion

        #region 批量添加客户报纸
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            BLL_customerPaperInfoB bllCustomerPaperInfo = new BLL_customerPaperInfoB();
            BLL_paperB bllpaper = new BLL_paperB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            string paperIDstr = tbPaperID.Text;
            if (paperIDstr.Trim() == "")
            {
                tbPaperID.Focus();
                scp.Alert("请录入您要添加的报纸信息ID字符串!");
                return; 
            }

            if (tbupdateOverDate.Text == "")
            {
                tbupdateOverDate.Focus();
                scp.Alert("请录入已到新到日期！");
                return; 
            }

            string[] strPaperIDarr = paperIDstr.Split(',');
            int paperID = 0;
            int Ok = 0;
            foreach(string strPaperID in strPaperIDarr)
            {
                if (!int.TryParse(strPaperID, out paperID)) continue; //判断报纸信息ID格式是否正确

                if (!bllpaper.ifHavePaper(paperID)) continue; //判断报纸是否存在
                
                bllCustomerPaperInfo.Add(customerID, paperID,tbupdateOverDate.Text);
                Ok++;
            }
            ListBind();
            scp.Alert(Ok.ToString() + "份报纸添加成功！");
        }
        #endregion
    }
}
