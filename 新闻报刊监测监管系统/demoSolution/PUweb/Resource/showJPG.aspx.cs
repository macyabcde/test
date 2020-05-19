using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace PU.web.Resource
{
    /// <summary>
    /// 显示JPG图片
    /// </summary>
    public partial class showJPG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

            //PubTool.logtext logInfoCs = new PubTool.logtext("imgTime", true);

            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            int paperID = int.Parse(Request.QueryString["paperID"].ToString());
            int RQ = int.Parse(Request.QueryString["RQ"].ToString());
            string BC = Request.QueryString["BC"].ToString();
            int type = int.Parse(Request.QueryString["type"].ToString());//资源类型。1：版面JPG、3：文章插图
            string fileName = Request.QueryString["fileName"].ToString();
            int w = int.Parse(Request.QueryString["w"].ToString());//要显示的宽，0说明忽略
            int h = int.Parse(Request.QueryString["h"].ToString());//要显示的高，0说明忽略
            if (fileName == "")
            {
                Server.Transfer("../images/noJPG.jpg");
                return;
            }
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
                    //PubTool.JPGTool JPGToolCs = null;
                    PubTool.ChangeJPG ChangeJPGCs = null;

                    if (w != 0)
                    {
                        //JPGToolCs = new PubTool.JPGTool("W");
                        ChangeJPGCs = new PubTool.ChangeJPG("W", "P");
                        //byteArr = JPGToolCs.GetBytes_EasyChange(byteArr, w, 0, 0);
                        byteArr = ChangeJPGCs.GetBytesChangePic(byteArr, w, 0, 72);
                        //Response.BinaryWrite(ImageToBytes(BytesToImage(byteArr, w, h)));

                    }                   
                    Response.BinaryWrite(byteArr);
                    Response.Flush();
                }
            }
            else
            {
                //Response.Write("找不到该文件");
                Server.Transfer("../images/noJPG.jpg");
            }

            time2 = DateTime.Now;

            //logInfoCs.WriteLine(DateTime.Now + " fileName=" + fileName + " timelong=" + time2.Subtract(time1).ToString());
        }


    }
}
