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
    public partial class selectDep : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 组织树javascript代码串
        /// </summary>
        public string nodeStr = "";

        /// <summary>
        /// 选择的部门ID
        /// </summary>
        public string selDepartID = "";

        /// <summary>
        /// 选择的部门名称
        /// </summary>
        public string selDepartName = "";

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            treeStr();//树数据串
        }
        #endregion

        #region 树数据串
        /// <summary>
        /// 树数据串
        /// </summary>
        protected void treeStr()
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();

            DataTable dt = bll_User.getUserDepartTreeList();
            if (dt.Rows.Count == 0) return;

            int focusID = 0;

            //设置上一次选择的部门为焦点
            if (Request.QueryString["DepartID"] != null && Request.QueryString["DepartID"]!="")
            {
                focusID = int.Parse(Request.QueryString["DepartID"]);
            }

            //设置用户的默认部门为焦点
            if (focusID == 0)
            {
                WebUser webUserCs = new WebUser();
                focusID = webUserCs.DefaultDepart;
            }

            DataRow[] rowArr = dt.Select("DepartID=" + focusID);
            if (rowArr.Length > 0)
            {
                selDepartID = rowArr[0]["DepartID"].ToString();
                selDepartName = rowArr[0]["DepartName"].ToString();
            }

            int DepartID;
            int FatherID;
            string DepartName;

            foreach (DataRow row in dt.Rows)
            {
                FatherID = int.Parse(row["fatherID"].ToString());
                DepartID = int.Parse(row["departID"].ToString());
                DepartName = row["departName"].ToString();

                nodeStr += "t.nodes[\"" + FatherID.ToString() + "_" + DepartID.ToString() + "\"]=\"";
                nodeStr += "text:" + DepartName + ";";
                nodeStr += "data:" + "departID=" + DepartID.ToString() + ";";
                nodeStr += "method:select(" + DepartID.ToString() + ",'" + DepartName + "');";
                nodeStr += "\";";
            }

            nodeStr = nodeStr + "t.focus(" + focusID + ");";
            nodeStr = nodeStr + "document.write(t.toString());";
        }
        #endregion
    }
}
