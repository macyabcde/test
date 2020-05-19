using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using User.BLL;
using System.Text;
using System.Data;

namespace User.Web.Command
{
    public partial class ExchangeData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PubTool.ExchangeData ExchangeDataCs = new PubTool.ExchangeData();
            ExchangeDataCs.SetAndGetForJSinIt();

            string whatDo = Request.Form["whatDo"].ToString();

            if (whatDo == "findUser") findUser(); //查找用户

        }

        #region 查找用户
        /// <summary>
        /// 查找用户
        /// </summary>
        protected void findUser()
        {
            string keyWord = Request.Form["keyWord"].ToString();
            BLL_User bllUser = new BLL_User();
            DataTable dt = bllUser.findUser(keyWord);
            int index = 0;
            StringBuilder ret = new StringBuilder();
            string str = "";
            foreach (DataRow row in dt.Rows)
            {
                // 进行数据库查询操作，返回人员信息格式字符串。格式：
                //[{UserGUID:'',UserName:'',UserID:'',DepartName:''},...]
                if (index == 0)
                {
                    ret.Append("[");
                }
                else
                {
                    ret.Append(",");
                }
                str = "{UserGUID:'" + row["UserGUID"].ToString() + "',UserName:'" + row["UserName"].ToString() + "',UserLoginName:'" + row["UserLoginName"].ToString() + "',DepartName:'" + row["DepartName"].ToString() + "'}";
                ret.Append(str);
                index++;
            }
            if (index > 0) ret.Append("]");
            if (index == 0) ret.Append("#null#");
            Response.Write(ret.ToString());
            Response.End();
        }
        #endregion
    }
}
