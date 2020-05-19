using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyInformation
{
    public partial class paperCollectionList : System.Web.UI.Page
    {
        /// <summary>
        /// 显示的每个报纸html列表
        /// </summary>
        public List<string> list = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();

            //122	报纸收藏列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 122))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }

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

            PU.BLL.BLL_paperCollectionInfoB paperCollectionInfoCs = new PU.BLL.BLL_paperCollectionInfoB();
            Command.Tool toolCs = new PU.web.Command.Tool();
            DataTable dt = paperCollectionInfoCs.getUserCollectionPaperList();
            list = toolCs.createHtmlListForSCPaper(dt);
            return list;
        }
        #endregion
    }
}
