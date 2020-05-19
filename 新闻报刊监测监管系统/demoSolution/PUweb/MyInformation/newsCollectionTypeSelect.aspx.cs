using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyInformation
{
    /// <summary>
    /// 报道收藏类别选择
    /// </summary>
    public partial class newsCollectionTypeSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            lbwhatDo.Text = "收藏类别选择";
            Bind();
        }

        #region 绑定收藏类别选择
        /// <summary>
        /// 绑定收藏类别选择
        /// </summary>
        void Bind()
        {
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            newsCollectionTypeCs.CreateUserCollectionType();
           DataTable  dt = newsCollectionTypeCs.getUserCollectionTypeList();
           foreach (DataRow row in dt.Rows)
           {
               rbl_type.Items.Add(new ListItem(row["collectionTypeName"].ToString(), row["newsCollectionTypeID"].ToString()));
           }
        }
        #endregion
    }
}
