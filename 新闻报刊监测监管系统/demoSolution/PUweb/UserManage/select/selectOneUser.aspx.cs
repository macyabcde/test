using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using User.BLL;

namespace User.Web.select
{
    public partial class selectOneUser : System.Web.UI.Page
    {

        #region 自定义属性

        /// <summary>
        /// 组织树javascript代码串
        /// </summary>
        public string nodeStr = "";

        /// <summary>
        /// 交点ID，默认选种的节点ID
        /// </summary>
        public int focusID = -1;

        /// <summary>
        /// 已选择的用户GUID
        /// </summary>
        public string UserGUID = "";

        /// <summary>
        /// 已选择的用户姓名
        /// </summary>
        public string UserName = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            if (Request.QueryString["UserGUID"] != "" || Request.QueryString["UserGUID"] != null) UserGUID = Request.QueryString["UserGUID"];

            if (Request.QueryString["UserName"] != "" || Request.QueryString["UserName"] != null) UserName = Request.QueryString["UserName"];
            

            if (!IsPostBack)
            {
                LoadTreeStr(); //加载树数据串 
            }
        }
        #endregion

        #region 树数据串
        /// <summary>
        /// 树数据串
        /// </summary>
        protected void LoadTreeStr()
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            DataTable dt = bll_User.getUserDepartTreeList();

            if (dt.Rows.Count == 0) return;

            WebUser webUserCs = new WebUser();
            focusID = webUserCs.DefaultDepart; //设置用户的默认部门的焦点

            int DepartID;
            int Fatherid;
            string DepartName;

            foreach (DataRow row in dt.Rows)
            {
                Fatherid = int.Parse(row["Fatherid"].ToString());
                DepartID = int.Parse(row["DepartID"].ToString());
                DepartName = row["DepartName"].ToString();

                nodeStr += "t.nodes[\"" + Fatherid.ToString() + "_" + DepartID.ToString() + "\"]=\"";
                nodeStr += "text:" + DepartName + ";";
                nodeStr += "data:" + "DepartID=" + DepartID.ToString() + ";";
                nodeStr += "url:selectOneUserShow.aspx;";
                nodeStr += "method:t.expand(id);";
                nodeStr += "\";";
            }

            nodeStr = nodeStr + "t.focus(" + focusID.ToString() + ");";
            nodeStr = nodeStr + "document.write(t.toString());";
        }
        #endregion
    }
}
