using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.PaperLook
{
    public partial class typePaper : System.Web.UI.Page
    {
        /// <summary>
        /// 显示的每个报纸html列表
        /// </summary>
        public List<string> list = new List<string>();
        /// <summary>
        /// 报刊分类数据表
        /// </summary>
        public DataTable dt_type;

        public int paperTypeID = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //104	报刊分类
            if (!Power.ifUserHavePower(webUser.UserGUID, 104))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

            PM.BLL.BLL_paperTypeB paperTypeCs = new PM.BLL.BLL_paperTypeB();
            string paperTypeIDStr = Request.QueryString["paperTypeID"];
            if (paperTypeIDStr == null) paperTypeIDStr = "0";
            paperTypeID = int.Parse(paperTypeIDStr);
            dt_type = paperTypeCs.GetpaperType();
            if (paperTypeID == 0) paperTypeID = int.Parse(dt_type.Rows[0]["paperTypeID"].ToString());
            
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
            DataTable dt = paperCs.getTypePaperList(paperTypeID);
            list = toolCs.createHtmlList(dt);
            return list;
        }
        #endregion

        
    }
}
