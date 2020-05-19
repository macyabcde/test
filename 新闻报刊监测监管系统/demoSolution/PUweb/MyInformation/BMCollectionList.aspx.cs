using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.MyInformation
{
    public partial class BMCollectionList : System.Web.UI.Page
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

            //123	版面收藏列表
            if (!Power.ifUserHavePower(webUser.UserGUID, 123))
            {
                Response.Redirect("../other/NoPower.aspx", true);
            }


            list = getHtmlList();
        }

        #region 生成要显示的html列表
        /// <summary>
        /// 生成要显示的html列表（每一个版面为一个元素）
        /// </summary>
        /// <param name="dt">报纸数据</param>
        /// <returns></returns>
        protected List<string> getHtmlList()
        {
            List<string> list = new List<string>();

            PU.BLL.BLL_editionCollectionInfoB ditionCollectionInfoCs = new PU.BLL.BLL_editionCollectionInfoB();
            Command.Tool toolCs = new PU.web.Command.Tool();
            DataTable dt = ditionCollectionInfoCs.getUserCollectionEditionList();
            list = toolCs.createHtmlListForSCBM(dt);
            return list;
        }
        #endregion
    }
}
