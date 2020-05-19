using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PU.BLL;
using PU.Model;

namespace PU.web.outgiving
{
    /// <summary>
    /// 添加、修改客户信息
    /// </summary>
    public partial class CustomerBasisInfoAdd : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 操作命令
        /// </summary>
        private string whatDo;

        /// <summary>
        /// 客户ID
        /// </summary>
        private string customerID;

        /// <summary>
        /// 144	添加客户
        /// </summary>
        private bool addPower = false;
        /// <summary>
        /// 145	修改客户
        /// </summary>
        private bool editPower = false;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();

            //144	添加客户
            addPower = Power.ifUserHavePower(webUser.UserGUID, 144);
            //145	修改客户
            editPower = Power.ifUserHavePower(webUser.UserGUID, 145);
            if (!addPower && !editPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }


            whatDo = Request.QueryString["whatDo"];

            if (whatDo == "update") customerID = Request.QueryString["customerID"];

            if (!IsPostBack)
            {
                if (whatDo == "add") inItAdd(); //为添加初始化

                if (whatDo == "update") inItUpdate(); //为修改初始化
            }
        }
        #endregion

        #region 为添加初始化
        /// <summary>
        /// 为添加初始化
        /// </summary>
        private void inItAdd()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!addPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "添加客户基本信息";
            lbwhatDo.Text = "添加客户基本信息";

            tbServiceEndTime.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            tbDataUpdateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 为修改初始化
        /// <summary>
        /// 为修改初始化
        /// </summary>
        private void inItUpdate()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!editPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "修改客户基本信息";
            lbwhatDo.Text = "修改客户基本信息";
            tbCustomerID.Enabled = false;
            //将客户基本信息显示到页面中
            ObjToPage();
        }
        #endregion

        #region 将客户基本信息显示到页面中
        /// <summary>
        /// 将客户基本信息显示到页面中
        /// </summary>
        private void ObjToPage()
        {
            BLL_customerBasisInfoB bllcustomerBasisInfo = new BLL_customerBasisInfoB();
            MDL_customerBasisInfoB customerBasisInfoModel = bllcustomerBasisInfo.GetModel(customerID);

            tbCustomerID.Text = customerBasisInfoModel.customerID;
            tbCustomerName.Text = customerBasisInfoModel.customerName;
            tbDataUpdateTime.Text = customerBasisInfoModel.dataUpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
            tbEmail.Text = customerBasisInfoModel.email;
            tbLinkman.Text = customerBasisInfoModel.linkman;
            tbPassword.Text = customerBasisInfoModel.password;
            tbQQ.Text = customerBasisInfoModel.qq;
            tbRequestLimit.Text = customerBasisInfoModel.requestLimit.ToString();
            tbServiceEndTime.Text = customerBasisInfoModel.serviceEndTime.ToString("yyyy-MM-dd");
            tbTel.Text = customerBasisInfoModel.tel;

            ddlSyncMode.SelectedValue = customerBasisInfoModel.SyncMode.ToString();
        }
        #endregion

        #region 将页面客户基本信息加载在实体中
        /// <summary>
        /// 将页面客户基本信息加载在实体中
        /// </summary>
        private MDL_customerBasisInfoB PageToObj()
        {
            BLL_customerBasisInfoB bllcustomerBasisInfo = new BLL_customerBasisInfoB();
            User.BLL.WebUser webUser=new User.BLL.WebUser();
            MDL_customerBasisInfoB customerBasisInfoModel;

            if (whatDo == "add")
            {
                customerBasisInfoModel = new MDL_customerBasisInfoB();
                customerBasisInfoModel.customerID = tbCustomerID.Text;
                customerBasisInfoModel.createUserGUID = webUser.UserGUID;
                customerBasisInfoModel.active = 1;
            }
            else
            {
                customerBasisInfoModel = bllcustomerBasisInfo.GetModel(customerID);
            }

            customerBasisInfoModel.customerName = tbCustomerName.Text;
            customerBasisInfoModel.dataUpdateTime = DateTime.Parse(tbDataUpdateTime.Text);
            customerBasisInfoModel.email = tbEmail.Text;
            customerBasisInfoModel.linkman = tbLinkman.Text;
            customerBasisInfoModel.password = tbPassword.Text;
            customerBasisInfoModel.qq = tbQQ.Text;
            customerBasisInfoModel.requestLimit = int.Parse(tbRequestLimit.Text);
            customerBasisInfoModel.serviceEndTime = DateTime.Parse(tbServiceEndTime.Text);
            customerBasisInfoModel.tel = tbTel.Text;
            customerBasisInfoModel.SyncMode = int.Parse(ddlSyncMode.SelectedValue);

            return customerBasisInfoModel;
        }
        #endregion

        #region 检测输入数据的合法性
        /// <summary>
        /// 检测输入数据的合法性
        /// </summary>
        private PubTool.ReturnMsg checkInfo()
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();

            if (tbCustomerID.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbCustomerID.Focus();
                lbMsg.Text = "请输入客户ID！";
                return msg;
            }

            if (tbCustomerName.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbCustomerName.Focus();
                lbMsg.Text = "请输入客户名称！";
                return msg;
            }

            if (tbPassword.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbPassword.Focus();
                lbMsg.Text = "请输入客户密码！";
                return msg;
            }

            if (tbRequestLimit.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbRequestLimit.Focus();
                lbMsg.Text = "请输入频率限制！";
                return msg;
            }

            int RequestLimit = 0;
            if (!int.TryParse(tbRequestLimit.Text, out RequestLimit))
            {
                msg.Succeed = false;
                tbRequestLimit.Focus();
                lbMsg.Text = "您输入的频率限制格式不正确，请重新输入！";
                return msg;
            }


            if (tbServiceEndTime.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbServiceEndTime.Focus();
                lbMsg.Text = "请输入服务截止日期！";
                return msg;
            }

            DateTime ServiceEndTime;
            if (!DateTime.TryParse(tbServiceEndTime.Text, out ServiceEndTime))
            {
                msg.Succeed = false;
                tbServiceEndTime.Focus();
                lbMsg.Text = "您输入的服务截止日期格式不正确，请重新输入！";
                return msg;
            }

            if (tbDataUpdateTime.Text.Trim() == "")
            {
                msg.Succeed = false;
                tbDataUpdateTime.Focus();
                lbMsg.Text = "请输入数据更新时间！";
                return msg;
            }
            DateTime DataUpdateTime;
            if (!DateTime.TryParse(tbDataUpdateTime.Text, out DataUpdateTime))
            {
                msg.Succeed = false;
                tbDataUpdateTime.Focus();
                lbMsg.Text = "您输入的数据更新时间格式不正确，请重新输入！";
                return msg;
            }

            lbMsg.Text = "";
            return msg;
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //数据验证
            PubTool.ReturnMsg msg = checkInfo();
            if (!msg.Succeed) return;

            lbMsg.Text = "";

            BLL_customerBasisInfoB bllcustomerBasisInfo = new BLL_customerBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            MDL_customerBasisInfoB customerBasisInfoModel = PageToObj();
        
            if (whatDo == "add")
            {
                if (!addPower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }

                msg=bllcustomerBasisInfo.Add(customerBasisInfoModel);
                if (!msg.Succeed)
                {
                    scp.AlertAndClose(msg.Msg);
                    return;
                }

                scp.ClickParentPageButton("btnRefresh");
                scp.Alert(msg.Msg);
            }

            if (whatDo == "update")
            {
                if (!editPower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }

                bllcustomerBasisInfo.Update(customerBasisInfoModel);
                scp.ClickParentPageButton("btnRefresh");
                scp.AlertAndClose("客户信息修改成功！");
            }
        }
        #endregion
    }
}
