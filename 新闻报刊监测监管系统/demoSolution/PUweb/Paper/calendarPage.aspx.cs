using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PU.web.Paper
{
    /// <summary>
    /// 日历页面
    /// </summary>
    public partial class calendarPage : System.Web.UI.Page
    {
        /// <summary>
        /// 报纸ID
        /// </summary>
        private int paperID = 0;
        /// <summary>
        /// 年份
        /// </summary>
        private int year = 0;
        /// <summary>
        /// 月份
        /// </summary>
        private int month = 0;
        /// <summary>
        /// 当前版面日期
        /// </summary>
        private int RQ = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //105	数字报阅读
            if (!Power.ifUserHavePower(webUser.UserGUID, 105))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            paperID = int.Parse(Request.QueryString["paperID"].ToString());
            year = int.Parse(Request.QueryString["year"].ToString());
            month = int.Parse(Request.QueryString["month"].ToString());
            RQ = int.Parse(Request.QueryString["RQ"].ToString());


            calendarDateHtml(paperID, year, month, RQ);
        }

        #region 生成日历天html
        /// <summary>
        /// 生成日历天html
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="RQ">当前版面日期</param>
        protected void calendarDateHtml(int paperID, int year, int month, int RQ)
        {
            Components.DataOP DataOPCs = new PU.web.Paper.Components.DataOP();
            string dateHtml = DataOPCs.calendarDateHtml(paperID, year, month, RQ);
            
            Response.Write(dateHtml.ToString());
          
            Response.End();
        }
        #endregion
    }
}
