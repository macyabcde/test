using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;
using User.BLL;

namespace User.Web.UserDepartManage
{
    public partial class MoveDepartment : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 树字符串
        /// </summary>
        public string nodeStr = "";

        /// <summary>
        /// 组织ID
        /// </summary>
        private int departID = 0;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
           
            WebUser webUser = new WebUser();
            webUser.login();
            power powerCs = new power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            //11	移动组织节点
            if (!powerCs.ifUserHavePower(webUser.UserGUID, 11))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                return;
            }

            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
            departID = int.Parse(Request.QueryString["departID"].ToString());
            HFdepartID.Value = departID.ToString();
            HFfatherID.Value = bll_Department.GetModel(departID).fatherID.ToString();
            Bind(departID);
        }
        #endregion

        #region 绑定组织树。去掉要移动部门的下属部门
        /// <summary>
        /// 绑定组织树。去掉要移动部门的下属部门
        /// </summary>
        /// <param name="moveDepart">要移动的组织ID</param>
        void Bind(int moveDepart)
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            int[] delDepartIDArr = new int[1];
            delDepartIDArr[0] = moveDepart;
            //获取用户组织树列表数据
            DataTable dt = bll_User.getUserDepartTreeList(delDepartIDArr, false);

            foreach (DataRow row in dt.Rows)
            {
                nodeStr = nodeStr + "t.nodes[\"" + row["fatherID"].ToString() + "_" + row["departID"].ToString() + "\"]=\"";
                nodeStr = nodeStr + "text:" + row["departName"].ToString() + ";";
                nodeStr = nodeStr + "hint:0;";
                nodeStr = nodeStr + "style.color:'blue';";
                nodeStr = nodeStr + "method:SetTreeNodeURL('" + row["departID"].ToString() + "');";
                nodeStr = nodeStr + "data:" + "departID=" + row["departID"].ToString();
                nodeStr = nodeStr + "\";";
            }
            nodeStr = nodeStr + "document.write(t.toString());";
        }
        #endregion

        #region 点击保存
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            PubTool.ReturnMsg retMsg = new PubTool.ReturnMsg();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.BLL_Department bll_Department = new User.BLL.BLL_Department();
           

            if (HFmoveToDeaprtID.Value == "")
            {
                scp.Alert("请先选择要移动的组织！");
                return;
            }

            int MoveToDepartID = int.Parse(HFmoveToDeaprtID.Value);//要移动到的组织           


            retMsg = bll_Department.MoveDepartment(MoveToDepartID, departID);
            if (retMsg.Succeed)
            {
                scp.RefreshFormWithName("iftreeShow", "departID=" + departID.ToString());
                scp.RefreshParentPage("departID=" + departID.ToString());
                scp.AlertAndClose(retMsg.Msg);
            }
            else
            {
                scp.Alert(retMsg.Msg);
            }
        }
        #endregion
    }
}
