using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace PU.web.Command
{
    /// <summary>
    /// 页面工具类
    /// </summary>
    public class Tool
    {
        #region 生成要显示的html列表
        /// <summary>
        /// 生成要显示的html列表（每一个报纸为一个元素）
        /// </summary>
        /// <param name="dt">报纸数据</param>
        /// <returns></returns>
        public List<string> createHtmlList(DataTable dt)
        {
            List<string> list = new List<string>();

            string paperName = "";
            string paperID = "";
            string RQ = "";
            string BC = "";
            string jpg = "";
            Int64 paperNewBMID = -1;
            string link = "";
            string sc = "";
            string html = "";
            foreach (DataRow row in dt.Rows)
            {
                paperName = row["paperName"].ToString();
                paperID = row["paperID"].ToString();
                RQ = row["RQ"].ToString();
                BC = row["BC"].ToString();
                jpg = row["JP"].ToString();
                paperNewBMID = Int64.Parse(row["paperNewBMID"].ToString());
                if (paperNewBMID == -1)
                {
                    jpg = "../images/noData.jpg";
                    RQ = "";
                    link = "#";
                    sc = "#";
                }
                else
                {
                    jpg = getJPGurl(int.Parse(paperID), int.Parse(RQ), BC, jpg, 233); 
                    link = "../Paper/BMList.aspx?paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC;
                    RQ = PubTool.Convert.intToDateStr(int.Parse(RQ));
                    sc = "javascript:addPaperCollection(" + paperID + ");";
                }


                html = @"
                        <table width=""200"" border=""0"" cellspacing=""0"" cellpadding=""0"" >
                          <tr>
                              <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""" + jpg + @"""  height=""233""  border=""1"" /></a></td>
                          </tr>
                          <tr>
                               <td height=""22"" align=""center"" class=divcss5-5>" + paperName + @" " + RQ + @"</td>
                          </tr>
                          <tr>
                               <td height=""25"" align=""center"">
                                   <table width=""180"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                      <tr>
                                          <td align=""center""><a href=""" + sc + @"""><img src=""../images/button010.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                          <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""../images/button011.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                      </tr>
                                   </table></td>
                          </tr>
                        </table>";
                list.Add(html);
            }

            return list;
        }
        #endregion


        #region 生成要显示的html列表(收藏的报纸)
        /// <summary>
        /// 生成要显示的html列表(收藏的报纸)（每一个报纸为一个元素）
        /// </summary>
        /// <param name="dt">收藏的报纸数据</param>
        /// <returns></returns>
        public List<string> createHtmlListForSCPaper(DataTable dt)
        {
            List<string> list = new List<string>();

            string paperName = "";
            string paperID = "";
            string RQ = "";
            string BC = "";
            string jpg = "";
            Int64 paperNewBMID = -1;
            string link = "";
            string Remove = "";
            string html = "";
            foreach (DataRow row in dt.Rows)
            {
                paperName = row["paperName"].ToString();
                paperID = row["paperID"].ToString();
                RQ = row["RQ"].ToString();
                BC = row["BC"].ToString();
                jpg = row["JP"].ToString();
                paperNewBMID = Int64.Parse(row["paperNewBMID"].ToString());
                if (paperNewBMID == -1)
                {
                    jpg = "../images/noData.jpg";
                    RQ = "";
                    link = "#";
                    Remove = "#";
                }
                else
                {
                    jpg = getJPGurl(int.Parse(paperID), int.Parse(RQ), BC, jpg, 233);

                    link = "../Paper/BMList.aspx?paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC;
                    RQ = PubTool.Convert.intToDateStr(int.Parse(RQ));
                    Remove = "javascript:delPaperCollection(" + paperID + ");";
                }


                html = @"
                        <table width=""200"" border=""0"" cellspacing=""0"" cellpadding=""0"" id=""paper" + paperID + @""" >
                          <tr>
                              <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""" + jpg + @""" height=""233""  border=""1"" /></a></td>
                          </tr>
                          <tr>
                               <td height=""22"" align=""center"" class=divcss5-5>" + paperName + @" " + RQ + @"</td>
                          </tr>
                          <tr>
                               <td height=""25"" align=""center"">
                                   <table width=""180"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                      <tr>
                                          <td align=""center""><a href=""" + Remove + @"""><img src=""../images/button010Remove.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                          <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""../images/button011.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                      </tr>
                                   </table></td>
                          </tr>
                        </table>";
                list.Add(html);
            }

            return list;
        }
        #endregion

        

        #region 生成要显示的html列表(收藏的版面)
        /// <summary>
        /// 生成要显示的html列表(收藏的版面)（每一个版面为一个元素）
        /// </summary>
        /// <param name="dt">收藏的版面数据</param>
        /// <returns></returns>
        public List<string> createHtmlListForSCBM(DataTable dt)
        {
            List<string> list = new List<string>();

            string paperName = "";
            string paperID = "";
            string RQ = "";
            string BC = "";
            string jpg = "";
            string BM = "";
            string link = "";
            string Remove = "";
            string html = "";
            string editionCollectionInfoID = "0";
            foreach (DataRow row in dt.Rows)
            {
                editionCollectionInfoID = row["editionCollectionInfoID"].ToString();
                paperName = row["MC"].ToString();
                paperID = row["paperID"].ToString();
                RQ = row["RQ"].ToString();
                BC = row["BC"].ToString();
                jpg = row["JP"].ToString();
                BM = row["BM"].ToString();

                jpg = getJPGurl(int.Parse(paperID), int.Parse(RQ), BC, jpg, 233);

                link = "../Paper/BMList.aspx?paperID=" + paperID + "&RQ=" + RQ + "&BC=" + BC;
                RQ = PubTool.Convert.intToDateStr(int.Parse(RQ));
                Remove = "javascript:delEditionCollection(" + editionCollectionInfoID + ");";


                html = @"
                        <table width=""200"" border=""0"" cellspacing=""0"" cellpadding=""0"" id=""edition" + editionCollectionInfoID + @""" >
                          <tr>
                              <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""" + jpg + @"""  height=""233""  border=""1"" /></a></td>
                          </tr>
                          <tr>
                               <td height=""22"" align=""center"" class=divcss5-5>" + paperName + @" " + RQ + @"</td>
                          </tr>
                          <tr>
                               <td height=""22"" align=""center"" class=divcss5-5>第" + BC + @"版  " + BM + @"</td>
                          </tr>
                          <tr>
                               <td height=""25"" align=""center"">
                                   <table width=""180"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                      <tr>
                                          <td align=""center""><a href=""" + Remove + @"""><img src=""../images/button010Remove.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                          <td align=""center""><a href=""" + link + @""" target=""_blank""><img src=""../images/button011.jpg"" width=""55"" height=""23"" border=""0""/></a></td>
                                      </tr>
                                   </table></td>
                          </tr>
                        </table>";
                list.Add(html);
            }

            return list;
        }
        #endregion



        #region 获取JPGUrl
        /// <summary>
        ///  获取JPGUrl
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="RQ">出版日期</param>
        /// <param name="BC">版次</param>
        /// <param name="fileName">文件名</param>
        /// <param name="h">高度</param>
        /// <returns></returns>
        private string getJPGurl(int paperID, int RQ, string BC, string fileName, int h)
        {
            FileStream fs = null;
            string jpgUrl = "";
            string noJPGUrl = "../images/noJPG.jpg";
            if (fileName == "") return noJPGUrl;
            try
            {
                string jpgName = paperID.ToString() + "_" + BC + "_" + fileName;
                string jpgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BMJPGCach\\" + RQ.ToString());
                string jpgfilePath = Path.Combine(jpgPath, jpgName);
                jpgUrl = "../BMJPGCach/" + RQ.ToString() + "/" + jpgName;


                if (File.Exists(jpgfilePath)) return jpgUrl;

                PM.ClientLibrary.Resource ResourceCs = new PM.ClientLibrary.Resource();
                Byte[] byteArr = ResourceCs.getFile(paperID, RQ, BC, 1, fileName);


                if (byteArr == null) return noJPGUrl;
                if (byteArr.Length == 0) return noJPGUrl;

                //PubTool.JPGTool JPGToolCs = null;
                PubTool.ChangeJPG ChangeJPGCs = null;
                if (h != 0)
                {
                    //JPGToolCs = new PubTool.JPGTool("H");
                    ChangeJPGCs = new PubTool.ChangeJPG("H", "P");

                    //byteArr = JPGToolCs.GetBytes_EasyChange(byteArr, 0, h, 0);
                    byteArr = ChangeJPGCs.GetBytesChangePic(byteArr, 0, h, 72);
                }
                if (!Directory.Exists(jpgPath)) Directory.CreateDirectory(jpgPath);
                fs = File.Open(jpgfilePath, FileMode.OpenOrCreate);
                fs.Write(byteArr, 0, byteArr.Length);
                fs.Close();
            }
            catch (Exception e)
            {
                PubTool.logtext logErrCs = new PubTool.logtext("ErrJPG", true);
                logErrCs.WriteLine(DateTime.Now.ToString() + "  获取JPGUrl出错。" + e.ToString());
            }
            finally
            {
                if (fs != null) fs.Close();
            }

            return jpgUrl;
        }
        #endregion
        
    }
}
