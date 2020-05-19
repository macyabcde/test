using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.Search
{
    /// <summary>
    /// 而且检索
    /// </summary>
    public partial class orInput : System.Web.UI.Page
    {  
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //114	或者检索
            if (!Power.ifUserHavePower(webUser.UserGUID, 114))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            txtstartDate.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
            txtendDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            DataTable dt = dictionaryCs.GetOnedictionaryType("searchRetOrder");
            DPListsearchRetOrder.DataValueField = "dictionaryInfoID";
            DPListsearchRetOrder.DataTextField = "dictionaryName";
            DPListsearchRetOrder.DataSource = dt;
            DPListsearchRetOrder.DataBind();
        }



        
    }
}
