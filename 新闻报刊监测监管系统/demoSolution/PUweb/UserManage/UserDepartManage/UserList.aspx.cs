using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.Model;
using System.Data;
using System.Web.UI.HtmlControls;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class UserList : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 组织ID
        /// </summary>
        private int departID = 0;

        /// <summary>
        /// 父组织ID
        /// </summary>
        private int fatherID = 0;

        /// <summary>
        /// 是否有修改组织架构的权限
        /// </summary>
        private bool hasUpdateDepart = false;

        /// <summary>
        /// 是否有修改用户的权限
        /// </summary>
        private bool hasUpdatUser = false;

        /// <summary>
        /// 是否有删除用户的权限
        /// </summary>
        private bool hasDelUser = false;

        /// <summary>
        /// 是否有删除部门的权限
        /// </summary>
        private bool hasDelDepart = false;

        /// <summary>
        /// 是否有用户状态管理的权限
        /// </summary>
        private bool hasStateManage = false;

        /// <summary>
        /// 是否有用户密码重置的权限
        /// </summary>
        private bool hasSetPwd = false;
        
        /// <summary>
        /// 是否有用户调动的权限
        /// </summary>
        private bool hasMoveUser = false;

        /// <summary>
        /// 是否有角色维护的权限
        /// </summary>
        private bool hasPartManage = false;

        /// <summary>
        /// 是否有用户角色查看的权限
        /// </summary>
        private bool hasLookPart=false;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();

            //12	用户列表
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 12))
            {
                Response.Redirect("../other/NoPower.aspx");
                Response.End();
            }

            //8	添加组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 8)) btnAddDepartment.Enabled = false;

            //9	修改组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 9)) btnUpdateDepartment.Enabled = false;

            //10 删除组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 10)) btnDeleteDepartment.Enabled = false;

            //11 移动组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 11)) btnMoveDepartment.Enabled = false;

            //13	添加用户
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 13)) btnAddUser.Enabled = false;

            //14	修改用户
            hasUpdatUser = powerCs.ifUserHavePower(webUser.UserGUID, 14);

            //15	删除用户
            hasDelUser = powerCs.ifUserHavePower(webUser.UserGUID, 15);

            //16	用户状态管理
            hasStateManage = powerCs.ifUserHavePower(webUser.UserGUID, 16);

            //17	用户密码重置
            hasSetPwd = powerCs.ifUserHavePower(webUser.UserGUID, 17);

            //18	用户调动
            hasMoveUser = powerCs.ifUserHavePower(webUser.UserGUID, 18);

            //19	用户角色维护
            hasPartManage = powerCs.ifUserHavePower(webUser.UserGUID, 19);

            //20    用户角色查看
            hasLookPart = powerCs.ifUserHavePower(webUser.UserGUID, 19);


            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            MDL_Department departModel = bll_Department.GetTopModel();

            if (Request.QueryString["departID"] != null && Request.QueryString["departID"] != "")
            {
                departID = int.Parse(Request.QueryString["departID"]);
                fatherID = bll_Department.GetModel(departID).fatherID;
            }
            else
            {
                //获取根组织信息
                if (departModel != null)
                {
                    departID = departModel.departID;
                }
            }

            //添加组织
            btnAddDepartment.OnClientClick = "windOpen('AddDepartment.aspx?whatDo=add&fatherID=" + departID + "','730','285'); return false;";
            //修改组织
            btnUpdateDepartment.OnClientClick = "windOpen('AddDepartment.aspx?whatDo=update&departID=" + departID + "','730','285'); return false;";
            //移动组织
            btnMoveDepartment.OnClientClick = "windOpen('MoveDepartment.aspx?departID=" + departID + "','430','600'); return false;";

            if (fatherID == 0)
            {
                if (departModel == null)
                {
                    btnUpdateDepartment.Enabled = false;
                }

                btnDeleteDepartment.Enabled = false;
                btnMoveDepartment.Enabled = false;
            }
            else
            {
                btnDeleteDepartment.OnClientClick = "return confirm(\"您确定要删除\\\"" + bll_Department.GetModel(departID).departName + "\\\"吗？\");";
            }

            //添加用户
            if (departID == -1)
                btnAddUser.Enabled = false;
            else
                btnAddUser.OnClientClick = "windOpen('AddUser.aspx?whatDo=add&departID=" + departID + "','730','430'); return false;";

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
            ListBind();
        }
        #endregion

        #region 绑定用户列表
        /// <summary>
        /// 绑定用户列表
        /// </summary>
        void ListBind()
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            PubTool.DB.PageRetClass pageRetJG = bll_User.GetUserPageList(departID.ToString(), pageControl1.pageSize, pageControl1.goPage);
            rptPaper.DataSource = pageControl1.getPageDataForPageRet(pageRetJG);
            rptPaper.DataBind();
        }
        #endregion

        #region 行绑定事件
        protected void rptPaper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField HFuserGUID = e.Item.FindControl("HFuserGUID") as HiddenField;

                LinkButton lbtnuserLoginName = e.Item.FindControl("lbtnuserLoginName") as LinkButton; //查看
                LinkButton lbtnUpdate = e.Item.FindControl("lbtnUpdate") as LinkButton; //修改
                LinkButton lbtnDelete = e.Item.FindControl("lbtnDelete") as LinkButton; //删除
                LinkButton lbtnpassword = e.Item.FindControl("lbtnpassword") as LinkButton; //密码重置
                LinkButton lbtnIsactive = e.Item.FindControl("lbtnIsactive") as LinkButton; //启用禁用
                LinkButton lbtnMoveUserdepart = e.Item.FindControl("lbtnMoveUserdepart") as LinkButton; //用户调动
                LinkButton lbtnUser_Part = e.Item.FindControl("lbtnUser_Part") as LinkButton; //用户角色
                
                Label lbpartName = e.Item.FindControl("lbpartName") as Label; //用户角色
                HtmlTableCell cell = e.Item.FindControl("tdPartName") as HtmlTableCell;
                Label lbactive = e.Item.FindControl("lbactive") as Label; //状态

                string userGUID = HFuserGUID.Value;
                string userLoginName = lbtnuserLoginName.Text;
                int active = int.Parse(lbactive.Text);

                string partArrStr = "";

                #region 绑定用户角色

                //获取用户角色
                User.BLL.BLL_User_PartB bll_User_PartB = new User.BLL.BLL_User_PartB();
                DataTable dtPart = bll_User_PartB.GetUserPartList(userGUID);
                foreach (DataRow row in dtPart.Rows)
                {
                    if (partArrStr == "")
                    {
                        lbpartName.Text = row["partName"].ToString();
                        partArrStr = row["partName"].ToString();
                        continue;
                    }

                    partArrStr += "," + row["partName"].ToString();
                }
                if (partArrStr != "") cell.Attributes.Add("title", partArrStr);

                #endregion

                if (lbactive.Text == "0")
                    lbactive.Text = "禁用";
                else
                    lbactive.Text = "启用";

                //绑定修改事件
                if (hasUpdatUser)
                    lbtnUpdate.OnClientClick = "windOpen('AddUser.aspx?whatDo=update&userGUID=" + userGUID + "&departID=" + departID + "','740','430'); return false;";
                else
                    lbtnUpdate.Enabled = false;

                //绑定删除用户事件
                if (hasDelUser)
                    lbtnDelete.OnClientClick = " return delUser('" + userGUID + "','" + userLoginName + "');";
                else
                    lbtnDelete.Enabled = false;

                //绑定查看用户信息事件
                lbtnuserLoginName.OnClientClick = "windOpen('AddUser.aspx?whatDo=priview&userGUID=" + userGUID + "&departID=" + departID + "','700','430'); return false;";

                //绑定启用禁用事件
                if (hasStateManage)
                    lbtnIsactive.OnClientClick = "return isactive('" + active + "','" + userGUID + "','" + userLoginName + "'); ";
                else
                    lbtnIsactive.Enabled = false;

                //绑定密码重置事件
                if (hasSetPwd)
                    lbtnpassword.OnClientClick = "windOpen('Updatepassword.aspx?userGUID=" + userGUID + "','730','260'); return false;";
                else
                    lbtnpassword.Enabled = false;

                //绑定用户调动事件
                if (hasMoveUser)
                    lbtnMoveUserdepart.OnClientClick = "windOpen('MoveUserdepart.aspx?userGUID=" + userGUID + "','430','620'); return false;";
                else
                    lbtnMoveUserdepart.Enabled = false;

                //绑定用户角色事件
                if (hasPartManage)
                    lbtnUser_Part.OnClientClick = "windOpen('AddUser_PartB.aspx?userGUID=" + userGUID + "','720','640'); return false;";
                else
                    lbtnUser_Part.Enabled = false;
            }
        }
        #endregion

        #region 点击翻页
        protected void pageControl1_Click(object sender, EventArgs e)
        {
            ListBind();
        }
        #endregion

        #region 多功能事件
        protected void btncomand_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            User.BLL.BLL_User_PartB bll_User_PartB = new User.BLL.BLL_User_PartB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            
            string command=HFcomand.Value;

            //删除用户信息
            if (command== "delUser")
            {
                //15	删除用户
                if (!powerCs.ifUserHavePower(webUser.UserGUID, 15))
                {
                    scp.Alert("您还未开通此权限！");
                    return;
                }

                bll_User.Delete(HFvalue.Value);
                bll_User_PartB.DeleteUserPart(HFvalue.Value);
            }

            //启用(禁用用户)
            if (command == "active")
            {
                //16	用户状态管理
                if (!powerCs.ifUserHavePower(webUser.UserGUID, 16))
                {
                    scp.Alert("您还未开通此权限！");
                    return;
                }

                int active = int.Parse(HFvalue.Value.Split(',')[0]);
                string UserGUID = HFvalue.Value.Split(',')[1];
                bll_User.Updateactive(active, UserGUID);
            }

            HFcomand.Value = "";
            HFvalue.Value = "";
            ListBind();
        }
        #endregion

        #region 点击刷新
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ListBind();
        }
        #endregion

        #region 删除组织
        protected void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            
            //10	删除组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 10))
            {
                scp.Alert("您还未开通此权限！");
                return;
            }


           
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();

            if (fatherID == 0)
            {
                scp.Alert("根组织不得删除!");
                ListBind();
                return;
            }

            if (bll_Department.HasDepart(departID))
            {
                scp.Alert("该组织存在下级组织,不得删除!");
                ListBind();
                return;
            }
            if (bll_Department.HasUser(departID))
            {
                scp.Alert("该组织存在用户,不得删除!");
                ListBind();
                return;
            }

            bll_Department.Delete(departID);
            scp.RefreshThisFormWithName("iftreeShow", "departID=" + fatherID.ToString());
            scp.RefreshPage("departID=" + fatherID.ToString());

        }
        #endregion
    }
}