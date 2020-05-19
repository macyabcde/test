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
    public partial class selectOneUserShow : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            depUserbind();
            intItSelectData();
            ListBoxShow.Attributes.Add("ondblclick", "OKreturn()");
        }
        #endregion

        #region 页面初始化已选数据
        /// <summary>
        /// 页面初始化已选数据
        /// </summary>
        protected void intItSelectData()
        {
            string UserGUID=Request.QueryString["UserGUID"];
            string UserName = Request.QueryString["UserName"];

            if (UserGUID == "" || UserGUID == null) return;

            if (ListBoxShow.Items.FindByValue(UserGUID) != null)
            {
                ListBoxShow.SelectedValue = UserGUID;
                return;
            }

            ListItem a = new ListItem();
            a.Value = UserGUID;
            a.Text = UserName;
            a.Selected = true;
            ListBoxShow.Items.Insert(0, a);
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
