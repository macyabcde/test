using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class AddDepartment : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 父组织ID
        /// </summary>
        private int fatherID = 0;

        /// <summary>
        /// 操作命令
        /// </summary>
        private string whatDo;

        /// <summary>
        /// 组织ID
        /// </summary>
        private int departID = -1;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            whatDo = Request.QueryString["whatDo"].ToString();

            if (whatDo == "update") departID = int.Parse(Request.QueryString["departID"]);

            if (whatDo == "add") fatherID = int.Parse(Request.QueryString["fatherID"]);

            if (!IsPostBack)
            {
                if (whatDo == "add") inItAdd(); //为添初始化

                if (whatDo == "update") inItUpdate(); //为修改始化
            }
        }
        #endregion

        #region 为添初始化
        protected void inItAdd()
        {
            Title = "添加组织";
            lbwhatDo.Text = "添加组织";

            WebUser webUser = new WebUser();
            webUser.login();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            power powerCs = new power();
            //8	添加组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 8))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }



                
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            lbFarther.Text = bll_Department.father(fatherID);
        }
        #endregion

        #region 为修改始化
        protected void inItUpdate()
        {
            Title = "修改组织";
            lbwhatDo.Text = "修改组织";

            WebUser webUser = new WebUser();
            webUser.login();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            power powerCs = new power();
            //9	修改组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 9))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            GetData();
        }
        #endregion

        #region 页面数据填充
        /// <summary>
        /// 页面数据填充
        /// </summary>
        public void GetData()
        {
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            User.Model.MDL_Department mdl_Department = new User.Model.MDL_Department();
            mdl_Department = bll_Department.GetModel(departID);
            tbdepartName.Text = mdl_Department.departName;
            tbxuhao.Text = mdl_Department.xuhao.ToString();
            tbdepartShort.Text = mdl_Department.departShort;
            tbdepartPinyin.Text = mdl_Department.departPinyin;
            lbFarther.Text = bll_Department.father(mdl_Department.fatherID);
        }
        #endregion

        #region 获取页面数据
        /// <summary>
        /// 获取页面数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>完成修改后的实体</returns>
        public User.Model.MDL_Department GetModel(User.Model.MDL_Department model)
        {
            model.departName = tbdepartName.Text;
            model.xuhao = int.Parse(tbxuhao.Text);
            model.departShort = tbdepartShort.Text;
            model.departPinyin = tbdepartPinyin.Text;
            return model;
        }
        #endregion

        #region 检测输入数据的合法性
        /// <summary>
        /// 检测输入数据的合法性
        /// </summary>
        /// <returns></returns>
        PubTool.ReturnMsg CheckInfo()
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();

            if (tbdepartName.Text.Trim() == "")
            {
                lbMsg.Text = "请输入组织名称！";
                tbdepartName.Focus();
                msg.Succeed = false;
                return msg;
            }
           
            if (tbxuhao.Text.Trim() == "")
            {
                lbMsg.Text = "请输入序号！";
                tbxuhao.Focus();
                msg.Succeed = false;
                return msg;
            }

            int xuhao=0;
            if (!int.TryParse(tbxuhao.Text, out xuhao))
            {
                lbMsg.Text = "您输入的序号格式不正确！";
                tbxuhao.Focus();
                msg.Succeed = false;
                return msg;
            }

            lbMsg.Text = "";

            return msg;
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            User.Model.MDL_Department mdl_Department = new User.Model.MDL_Department();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();


            PubTool.ReturnMsg msg = CheckInfo();
            if (!msg.Succeed) return;

            if (whatDo == "add")
            {
                if(bll_Department.HasDepartName(tbdepartName.Text,departID,-1))
                {
                    scp.Alert(tbdepartName.Text+"已存在，不允许再添加！");
                    return;
                }
                mdl_Department = GetModel(mdl_Department);
                mdl_Department.fatherID = fatherID;
                int departIDTemp = bll_Department.Add(mdl_Department);
                scp.RefreshFormWithName("iftreeShow", "departID=" + departIDTemp.ToString());
                scp.RefreshParentPage("departID=" + departIDTemp.ToString());
                scp.AlertAndClose("添加成功!");
            }
            //执行修改操作
            else if (whatDo == "update")
            {
                if (bll_Department.HasDepartName(tbdepartName.Text, fatherID, departID))
                {
                    scp.Alert(tbdepartName.Text + "已存在，不允许再修改！");
                    return;
                }
                mdl_Department = bll_Department.GetModel(departID);
                bll_Department.Update(GetModel(mdl_Department));
                scp.RefreshFormWithName("iftreeShow", "departID=" + departID.ToString());
                scp.RefreshParentPage("departID=" + departID.ToString());
                scp.AlertAndClose("修改成功!");
            }
        }
        #endregion
    }
}
