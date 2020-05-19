using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Resource
{
    public partial class dowmResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            int paperID = int.Parse(Request.QueryString["paperID"].ToString());
            int RQ = int.Parse(Request.QueryString["RQ"].ToString());
            string BC = Request.QueryString["BC"].ToString();
            int type = int.Parse(Request.QueryString["type"].ToString());//资源类型。1：版面JPG、2：版面PDF、3：文章插图
            string fileName = Request.QueryString["fileName"].ToString();

            PM.ClientLibrary.Resource ResourceCs = new PM.ClientLibrary.Resource();
            Byte[] byteArr = ResourceCs.getFile(paperID, RQ, BC, type, fileName);

            if (byteArr != null)
            {
                if (byteArr.Length == 0)
                {
                    Response.Write("该文件为空");
                }
                else
                {
                    Response.ContentType = "application/x-msdownload";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName.Trim()));
                    Response.BinaryWrite(byteArr);
                    Response.Flush();
                }
            }
            else
            {
                Response.Write("找不到该文件");
            }
        }
    }
}
