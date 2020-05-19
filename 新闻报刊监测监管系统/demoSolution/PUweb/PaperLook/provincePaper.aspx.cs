using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.PaperLook
{
    public partial class provincePaper : System.Web.UI.Page
    {
        /// <summary>
        /// 显示的每个报纸html列表
        /// </summary>
        public List<string> list = new List<string>();
        /// <summary>
        /// 省份数据表
        /// </summary>
        public DataTable dt_province;

        public int province = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //103	报刊地域
            if (!Power.ifUserHavePower(webUser.UserGUID, 103))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            string provinceStr = Request.QueryString["province"];
            if (provinceStr == null) provinceStr = "0";
            province = int.Parse(provinceStr);
            dt_province = dictionaryCs.GetOnedictionaryType("province");
            if (province == 0) province = int.Parse(dt_province.Rows[0]["dictionaryInfoID"].ToString());

            list = getHtmlList();
        }

        #region 生成要显示的html列表
        /// <summary>
        /// 生成要显示的html列表（每一个报纸为一个元素）
        /// </summary>
        /// <param name="dt">报纸数据</param>
        /// <returns></returns>
        protected List<string> getHtmlList()
        {
            List<string> list = new List<string>();

            PU.BLL.BLL_paperB paperCs = new PU.BLL.BLL_paperB();
            Command.Tool toolCs = new PU.web.Command.Tool();
            DataTable dt = paperCs.getProvincePaperList(province);
            list = toolCs.createHtmlList(dt);
            return list;
        }
        #endregion


    }
}
