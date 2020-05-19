using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;
using System.Data;

namespace User.Web.select
{
    public partial class HZselectShow : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            depUserbind();

            ListBoxShow.Attributes.Add("onClick", "toSelect()");
        }
        #endregion

        #region 绑定部门人员
        /// <summary>
        /// 绑定部门人员
        /// </summary>
        private void depUserbind()
        {
            BLL_User bllUser = new BLL_User();
            int DepartID = int.Parse(Request.QueryString["DepartID"].ToString());
            DataTable dt = bllUser.GetUserList(DepartID);

            foreach (DataRow row in dt.Rows)
            {
                ListItem a = new ListItem();
                a.Text = row["UserName"].ToString();
                a.Value = row["UserGUID"].ToString();
                ListBoxShow.Items.Add(a);
            }
        }
        #endregion

    }
}
