using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.Search
{
    public partial class PaperSelect : System.Web.UI.UserControl
    {
        #region 自定义对象
        /// <summary>
        /// 省份报纸对象列表
        /// </summary>
        public List<PU.Model.MDL_PaperObj> list_prv = new List<PU.Model.MDL_PaperObj>();
        /// <summary>
        /// 类别报纸对象列表
        /// </summary>
        public List<PU.Model.MDL_PaperObj> list_type = new List<PU.Model.MDL_PaperObj>();
        /// <summary>
        /// 集团报纸列表
        /// </summary>
        public DataTable dt_group = new DataTable();

        /// <summary>
        /// 报刊收藏列表
        /// </summary>
        public DataTable dt_SC = new DataTable();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            PU.BLL.BLL_paperB paperCs = new PU.BLL.BLL_paperB();
            list_prv = paperCs.getProvincePaperObj();
            list_type = paperCs.getTypePaperObj();
            dt_group = paperCs.getGroupPaperList(PU.Command.ConfigProvider.groupName);

            PU.BLL.BLL_paperCollectionInfoB paperCollectionInfoCs = new PU.BLL.BLL_paperCollectionInfoB();

            dt_SC = paperCollectionInfoCs.getUserCollectionPaperList();
        }

        #region 生成报纸复选框html代码
        /// <summary>
        /// 生成报纸复选框html代码
        /// </summary>
        /// <param name="row">报纸数据行</param>
        /// <param name="name">复选框起始名称</param>
        /// <returns></returns>
        public string getCKboxHtml(DataRow row, string name)
        {
            string paperID = row["paperID"].ToString();
            string paperName = row["paperName"].ToString();
            string tempName = paperName;
            if (paperName.Length > 6) tempName = paperName.Substring(0, 5)+"...";
            string objID = name + paperID;
            string str = "<input id=\"" + objID + "\" type=\"checkbox\" name=\"" + objID + "\" CKpaperID=\"" + paperID + "\" bj=\"CKpaperSelect\" value=\"" + paperID + "\" onclick=\"checkChange(this);\" /><label for=\"" + objID + "\">" + tempName + "</label>";
            str = "<div title=\"" + paperName + "\" style=\"height:24px; width:100px;float: left;text-align:left;\">" + str + "</div>";
            return str;
        }
        #endregion
    }
}