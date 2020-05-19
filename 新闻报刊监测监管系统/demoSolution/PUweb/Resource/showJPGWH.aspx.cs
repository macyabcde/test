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
    /// 显示JPG图片，按宽高进行缩放
    /// </summary>
    public partial class showJPGWH : System.Web.UI.Page
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

            string jpgName = paperID.ToString() + "_" + BC + "_" + fileName;
            string jpgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BMJPGCach\\" + RQ.ToString());
            string jpgfilePath = Path.Combine(jpgPath, jpgName);
            string jpgUrl = "../BMJPGCach/" + RQ.ToString() + "/" + jpgName;
            
            if (File.Exists(jpgfilePath))
            {
                Server.Transfer(jpgUrl);
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
                    if (h != 0)
                    {

                        //JPGToolCs = new PubTool.JPGTool("H");
                        ChangeJPGCs = new PubTool.ChangeJPG("H", "P");
                        //byteArr = JPGToolCs.GetBytes_EasyChange(byteArr, 0, h, 0);
                        byteArr = ChangeJPGCs.GetBytesChangePic(byteArr, 0, h, 72);
                        //Response.BinaryWrite(ImageToBytes(BytesToImage(byteArr, w, h)));

                    }

                    if (!Directory.Exists(jpgPath)) Directory.CreateDirectory(jpgPath);
                    FileStream fs = null;
                    fs = File.Open(jpgfilePath, FileMode.OpenOrCreate);
                    fs.Write(byteArr, 0, byteArr.Length);
                    fs.Close();

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


        #region 对图片流文件进行操作(暂时是缩放)
        /// <summary>
        /// 对图片流文件进行操作
        /// </summary>
        /// <param name="streamByte"></param>
        /// <returns></returns>
        private System.Drawing.Image BytesToImage(byte[] streamByte, int width, int heigth)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(streamByte, true);
            stream.Write(streamByte, 0, streamByte.Length);
            Bitmap bmp = new Bitmap(stream);
            System.Drawing.Image image = bmp;//得到原图  
            //创建指定大小的图  
            System.Drawing.Image newImage = image.GetThumbnailImage(width, heigth, null, new IntPtr());
            Graphics g = Graphics.FromImage(newImage);
            //			g.DrawImage(newImage,10,10, newImage.Width, newImage.Height);   //将原图画到指定的图上(重写) 
            g.Dispose();
            stream.Close();
            return newImage;
        }
        #endregion

        #region 把图片转换成二进制流
        ///  <summary > 
        /// 将Image对象转化成二进制流 
        ///  </summary > 
        ///  <param name="image" > </param > 
        ///  <returns > </returns > 
        public byte[] ImageToBytes(System.Drawing.Image image)
        {
            //实例化流 
            MemoryStream imageStream = new MemoryStream();
            //将图片的实例保存到流中            
            image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //保存流的二进制数组 
            byte[] imageContent = new Byte[imageStream.Length];

            imageStream.Position = 0;
            //将流写如数组中 
            imageStream.Read(imageContent, 0, (int)imageStream.Length);

            return imageStream.ToArray();
        }
        #endregion
    }
}
