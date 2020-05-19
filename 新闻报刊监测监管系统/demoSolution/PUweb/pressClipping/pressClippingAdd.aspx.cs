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
    /// 剪报基本信息
    /// </summary>
    public partial class pressClippingAdd : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 133	添加剪报
        /// </summary>
        private bool addPower = false;
        /// <summary>
        /// 134	修改剪报
        /// </summary>
        private bool editPower = false;
        /// <summary>
        /// 137	剪报审批
        /// </summary>
        private bool spPower = false;
        /// <summary>
        /// 138	剪报查询
        /// </summary>
        private bool searchPower = false;
        /// <summary>
        /// 139	修改它人剪报
        /// </summary>
        private bool editOtherPower = false;


        /// <summary>
        /// 操作命令
        /// </summary>
        private string whatDo;

        /// <summary>
        /// 剪报基本信息ID
        /// </summary>
        private int pressClippingBasisInfoID = -1;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            

            User.BLL.power Power = new User.BLL.power();
            //133	添加剪报
            addPower = Power.ifUserHavePower(webUser.UserGUID, 133);
            //134	修改剪报
            editPower = Power.ifUserHavePower(webUser.UserGUID, 134);
            //137	剪报审批
            spPower = Power.ifUserHavePower(webUser.UserGUID, 137);
            //138	剪报查询
            searchPower = Power.ifUserHavePower(webUser.UserGUID, 138);
            //139	修改它人剪报
            editOtherPower = Power.ifUserHavePower(webUser.UserGUID, 139);



            whatDo = Request.QueryString["whatDo"].ToString();

            if (whatDo == "update" || whatDo == "Look" || whatDo == "SP") pressClippingBasisInfoID = int.Parse(Request.QueryString["pressClippingBasisInfoID"]);

            if (!IsPostBack)
            {
                inItPage();
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inItPage()
        {
            if (whatDo == "add") inItAdd();//为添加初始化 

            if (whatDo == "update") inItUpdate();//为修改初始化

            if (whatDo == "Look") inItPriview();//为查看初始化

            if (whatDo == "SP") inItSP(); //为审批初始化
        }
        #endregion

        #region 下拉列表绑定
        /// <summary>
        /// 下拉列表绑定
        /// </summary>
        private void ddlBind()
        {
            //绑定 输出排序 选项
            PubTool.DropDownListOperate dpListCs = new PubTool.DropDownListOperate();
            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            DataTable dt = dictionaryCs.GetOnedictionaryType("exportOrder");
            dpListCs.DropDownListBind(ddlExportOrder, dt, "dictionaryName", "dictionaryInfoID", "", "");

            dt = dictionaryCs.GetOnedictionaryType("pressClippingState");
            dpListCs.DropDownListBind(ddlState, dt, "dictionaryName", "dictionaryInfoID", "", "");
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

            Title = "添加剪报基本信息";
            lbwhatDo.Text = "添加剪报基本信息";

            trSP.Visible = false;
            trState.Visible = false;
            btnSPTG.Visible = false;
            btnJXXB.Visible = false;
            lbpressClippingBasisInfoID.Visible = false;
            tbpressClippingBasisInfoID.Visible = false;

            ddlBind(); //下拉列表绑定
         
        }
        #endregion

        #region 为修改初始化
        /// <summary>
        /// 为修改初始化
        /// </summary>
        private void inItUpdate()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
            if (model.state == 48 || model.state == 49)
            {
                scp.AlertAndClose("审批中和审批通过状态的剪报不允许修改！");
                Response.End();
            }
            if (!(editPower && model.createUserGUID == webUser.UserGUID) && !editOtherPower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "修改剪报基本信息";
            lbwhatDo.Text = "修改剪报基本信息";

            btnSPTG.Visible = false;
            btnJXXB.Visible = false;

            ddlBind(); //下拉列表绑定
            ObjToPage();

            if (model.state != 47)
            {
                tbPressClippingName.Enabled = false;
                tbcustomer.Enabled = false;
                tbSalesman.Enabled = false;
                ddlExportOrder.Enabled = false;
            }
            else
            {
                trSP.Visible = false;
                trState.Visible = false;
            }
            tbExamineNotion.Enabled = false;
        }
        #endregion

        #region 为查看初始化
        /// <summary>
        /// 为查看初始化
        /// </summary>
        private void inItPriview()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
            
            //48为审批中状态	
            if (!(model.createUserGUID == webUser.UserGUID || (spPower && model.state == 48) || searchPower))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "查看剪报基本信息";
            lbwhatDo.Text = "查看剪报基本信息";

            btnFinish.Visible = false;
            btnSPTG.Visible = false;
            btnJXXB.Visible = false;

            ddlBind(); //下拉列表绑定
            ObjToPage();
        }
        #endregion

        #region 为审批初始化
        /// <summary>
        /// 为审批初始化
        /// </summary>
        private void inItSP()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
            
            //48为审批中状态	
            if (!spPower || model.state != 48)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            ddlBind(); //下拉列表绑定
            btnFinish.Visible = false;
            ObjToPage();

            tbPressClippingName.Enabled = false;
            tbcustomer.Enabled = false;
            tbSalesman.Enabled = false;
            ddlExportOrder.Enabled = false;
            ddlState.Enabled = false;
            ddlExportOrder.Enabled = false;
            tbRemark.Enabled = false;
        }
        #endregion


        #region 将表单信息存入剪报基本信息中
        /// <summary>
        /// 将表单信息存入剪报基本信息中
        /// </summary>
        private MDL_pressClippingBasisInfoB PageToObj()
        {
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            User.BLL.WebUser webUser = new User.BLL.WebUser();

            MDL_pressClippingBasisInfoB model = new MDL_pressClippingBasisInfoB();

            //添加
            if (whatDo == "add")
            {
                model.createUserGUID = webUser.UserGUID;
                model.state = 47;

                model.pressClippingName = tbPressClippingName.Text;
                model.customer = tbcustomer.Text;
                model.salesman = tbSalesman.Text;
                model.exportOrder = int.Parse(ddlExportOrder.SelectedValue);
                model.remark = tbRemark.Text;
            }

            //修改
            if (whatDo == "update")
            {
                model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
                if (model.state == 47)
                {
                    model.pressClippingName = tbPressClippingName.Text;
                    model.customer = tbcustomer.Text;
                    model.salesman = tbSalesman.Text;
                    model.exportOrder = int.Parse(ddlExportOrder.SelectedValue);                   
                }
                model.remark = tbRemark.Text;
            }

            //审批
            if (whatDo == "SP")
            {
                model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
                model.examineNotion = tbExamineNotion.Text;
                model.examineUserGUID = webUser.UserGUID;
            }

            return model;
        }
        #endregion

        #region 将剪报基本显示到表单信息中
        /// <summary>
        /// 将剪报基本显示到表单信息中
        /// </summary>
        private void ObjToPage()
        {
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            MDL_pressClippingBasisInfoB model = bllPressClippingBasisInfo.GetModel(pressClippingBasisInfoID);
            PubTool.DropDownListOperate dpListCs = new PubTool.DropDownListOperate();

            tbcustomer.Text = model.customer;
            tbExamineNotion.Text = model.examineNotion;
            tbPressClippingName.Text = model.pressClippingName;
            tbRemark.Text = model.remark;
            tbSalesman.Text = model.salesman;

            dpListCs.selectValue(ddlState, model.state.ToString());
            dpListCs.selectValue(ddlExportOrder, model.exportOrder.ToString());

            if (whatDo != "add") tbpressClippingBasisInfoID.Text = model.pressClippingBasisInfoID.ToString();
            
        }
        #endregion

        #region 检查数据合法性
        /// <summary>
        /// 检查数据合法性
        /// </summary>
        private PubTool.ReturnMsg checkInfo()
        {
            PubTool.ReturnMsg Msg = new PubTool.ReturnMsg();

            if (tbPressClippingName.Text.Trim() == "")
            {
                Msg.Succeed = false;
                tbPressClippingName.Focus();
                lbMsg.Text = "请输入剪报名称！";
                return Msg;
            }

            if (tbcustomer.Text.Trim() == "")
            {
                Msg.Succeed = false;
                tbcustomer.Focus();
                lbMsg.Text = "请输入客户！";
                return Msg;
            }

            lbMsg.Text = "";

            return Msg;
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.ReturnMsg Msg = checkInfo();

            if (!Msg.Succeed) return;

            MDL_pressClippingBasisInfoB model = PageToObj();

            if (whatDo == "add")
            {
                if (!addPower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }

                bllPressClippingBasisInfo.Add(model);
                scp.ClickParentPageButton("BtRef");
                scp.AlertAndClose("剪报信息添加成功！");
                return;
            }

            if (whatDo == "update")
            {
                //审批中和审批通过状态不允许修改
                if (model.state == 48 || model.state == 49)
                {
                    scp.Alert("审批中和审批通过状态的剪报不允许修改！");
                    return;
                }

                if (!(editPower && model.createUserGUID == webUser.UserGUID) && !editOtherPower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }

                //选编状态的修改
                if (model.state == 47)
                {
                    bllPressClippingBasisInfo.Update(model);
                    scp.ClickParentPageButton("BtRef");
                    scp.AlertAndClose("剪报信息修改成功！");
                    return;
                }


                //文件生成、排版中、制作完成、销售完成
                int state = int.Parse(ddlState.SelectedValue);

                if (state < 51)
                {
                    scp.Alert("不允许退回到此状态！");
                    return;
                }

                model.state = state;
                bllPressClippingBasisInfo.Update(model);
                scp.ClickParentPageButton("BtRef");
                scp.AlertAndClose("剪报信息修改成功！");
                return;
            }
        }
        #endregion

        #region 审批通过
        protected void btnSPTG_Click(object sender, EventArgs e)
        {
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            MDL_pressClippingBasisInfoB model = PageToObj();

            //48为审批中状态	
            if (!spPower || model.state != 48)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            model.state = 49;

            bllPressClippingBasisInfo.Update(model);

            scp.ClickParentPageButton("BtRef");
            scp.AlertAndClose("审批成功！");

        }
        #endregion

        #region 继续选编
        protected void btnJXXB_Click(object sender, EventArgs e)
        {
            BLL_pressClippingBasisInfoB bllPressClippingBasisInfo = new BLL_pressClippingBasisInfoB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            MDL_pressClippingBasisInfoB model = PageToObj();
            //48为审批中状态	
            if (!spPower || model.state != 48)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            model.state = 47;

            bllPressClippingBasisInfo.Update(model);

            scp.ClickParentPageButton("BtRef");
            scp.AlertAndClose("审批成功！");
        }
        #endregion

        
    }
}
