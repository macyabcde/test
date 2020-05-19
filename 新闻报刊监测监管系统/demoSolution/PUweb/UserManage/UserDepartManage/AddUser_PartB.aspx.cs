using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class AddUser_PartB : System.Web.UI.Page
    {
        private string userGUID;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            power powerCs = new power();
            //19	用户角色维护
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 19))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            userGUID = Request.QueryString["userGUID"];
            if (!IsPostBack)
            {
                inItPage();
                lbwhatDo.Text = "用户角色(" + bll_User.GetModel(userGUID).userName + ")";
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inItPage()
        {
            cbListBind();
        }
        #endregion

        #region 绑定角色列表
        /// <summary>
        /// 绑定角色列表
        /// </summary>
        void cbListBind()
        {
            User.BLL.BLL_partB bll_partB = new User.BLL.BLL_partB();
            User.BLL.BLL_User_PartB bll_User_PartB = new User.BLL.BLL_User_PartB();
            //角色列表
            DataTable dt = bll_partB.GetList();
            //用户已有角色ID集合
            List<int> UserPartIDList = bll_User_PartB.GetUserPartIDList(userGUID);
            int partID = 0;
            string partName = "";
            ListItem list;

            foreach (DataRow row in dt.Rows)
            {
                partID = int.Parse(row["partID"].ToString());
                partName = row["partName"].ToString();
                list = new ListItem(partName, partID.ToString());
                list.Attributes.Add("style", "width:250px");

                if (UserPartIDList.Contains(partID)) list.Selected = true;

                cbUserPartList.Items.Add(list);
            }
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            User.BLL.BLL_User_PartB bll_User_PartB = new User.BLL.BLL_User_PartB();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            string partIDs = "";

            foreach (ListItem cbList in cbUserPartList.Items)
            {
                if (cbList.Selected)
                {
                    if (partIDs == "")
                        partIDs = cbList.Value;
                    else
                        partIDs += "," + cbList.Value;
                }
            }

            string[] UserArr = partIDs.Split(',');
            bll_User_PartB.DeleteUserPart(userGUID);

            foreach (string partID in UserArr)
            {
                if (partID == "") continue;

                bll_User_PartB.Add(userGUID, int.Parse(partID));
            }
            scp.ClickParentPageButton("btnRefresh");
            scp.AlertAndClose("添加成功!");
        }
        #endregion
    }
}
