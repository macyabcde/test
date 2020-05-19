using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace User.Web.UserDepartManage
{
    public partial class Tree : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 组织树javascript代码串
        /// </summary>
        public string nodeStr = "";

        /// <summary>
        /// 根节点ID
        /// </summary>
        public int rootID = 0;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            int departID;
            if (Request.QueryString["departID"] != null && Request.QueryString["departID"] != "")
                departID = int.Parse(Server.UrlDecode(Request.QueryString["departID"]));
            else departID = 0;

            treeStr(departID);
        }
        #endregion

        #region 树数据串
        /// <summary>
        /// 树数据串
        /// </summary>
        protected void treeStr(int focusID)
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            DataTable dt = bll_User.getUserDepartTreeList();
            if (dt.Rows.Count == 0) return;

            rootID = int.Parse(dt.Rows[0]["departID"].ToString());
            int departID;
            int fatherID;
            string departName;

            foreach (DataRow row in dt.Rows)
            {
                fatherID = int.Parse(row["fatherID"].ToString());
                departID = int.Parse(row["departID"].ToString());
                departName = row["departName"].ToString();

                nodeStr += "t.nodes[\"" + fatherID.ToString() + "_" + departID.ToString() + "\"]=\"";
                nodeStr += "text:" + departName + ";";
                nodeStr += "data:" + "departID=" + departID.ToString() + ";";
               // nodeStr += "url:UserList.aspx?departID=" + departID.ToString() +  ";";
                nodeStr += "method:t.expand(id);";
                nodeStr += "\";";
            }
            nodeStr = nodeStr + "t.focus(" + focusID.ToString() + ");";
            nodeStr = nodeStr + "document.write(t.toString());";

        }
        #endregion
    }
}
