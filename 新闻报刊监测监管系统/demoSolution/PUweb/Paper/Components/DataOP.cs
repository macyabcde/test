using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace PU.web.Paper.Components
{
    /// <summary>
    /// 报纸数据处理
    /// </summary>
    public class DataOP
    {
        #region 得到版次实体
        /// <summary>
        /// 得到版次数据行(返回null说明找不到该版次)
        /// </summary>
        /// <param name="BMList_dt">某一天的版面列表</param>
        /// <param name="BC">要获取版次</param>
        /// <returns></returns>
        public BMmodel getBCmodel(DataTable BMList_dt, string BC)
        {
            BMmodel model = new BMmodel();
            DataRow[] arr = BMList_dt.Select("BC='" + BC + "'");
            if (arr.Length == 0)
            {
                model = null;
            }
            else
            {
                model.BC = arr[0]["BC"].ToString();
                model.BM = arr[0]["BM"].ToString();
                model.JP = arr[0]["JP"].ToString();
                model.PD = arr[0]["PD"].ToString();
                //model.paperID = int.Parse(arr[0]["paperID"].ToString());
                model.RQ = int.Parse(arr[0]["RQ"].ToString());
                string[] WHarr = arr[0]["WH"].ToString().Split('*');
                if (WHarr.Length > 0)
                {
                    if (WHarr[0] != "") model.w = int.Parse(WHarr[0]);
                }
                if (WHarr.Length > 1)
                {
                    if (WHarr[1] != "") model.h = int.Parse(WHarr[1]);
                }

            }
            return model;
        }
        #endregion

        #region 得到上一版版次
        /// <summary>
        /// 得到上一版版次(返回空说明已是第一版)
        /// </summary>
        /// <param name="BMList_dt">某一天的版面列表</param>
        /// <param name="BC">当前版次</param>
        /// <returns></returns>
        public string getPreBC(DataTable BMList_dt, string BC)
        {
            string ret = "";

            for (int i = 0; i < BMList_dt.Rows.Count; i++)
            {
                if (BMList_dt.Rows[i]["BC"].ToString() == BC)
                {
                    if (i != 0) ret = BMList_dt.Rows[i - 1]["BC"].ToString();
                    break;
                }
            }
            return ret;
        }
        #endregion

        #region 得到下一版版次
        /// <summary>
        /// 得到下一版版次(返回空说明已是最后一版)
        /// </summary>
        /// <param name="BMList_dt">某一天的版面列表</param>
        /// <param name="BC">当前版次</param>
        /// <returns></returns>
        public string getNextBC(DataTable BMList_dt, string BC)
        {
            string ret = "";
            for (int i = 0; i < BMList_dt.Rows.Count; i++)
            {
                if (BMList_dt.Rows[i]["BC"].ToString() == BC)
                {
                    if (i + 1 < BMList_dt.Rows.Count) ret = BMList_dt.Rows[i + 1]["BC"].ToString();
                    break;
                }
            }
            return ret;
        }
        #endregion

        #region 得到第一版版次
        /// <summary>
        /// 得到第一版版次
        /// </summary>
        /// <param name="BMList_dt">某一天的版面列表</param>
        /// <returns></returns>
        public string getFirstBC(DataTable BMList_dt)
        {
            string ret = "";
            if (BMList_dt.Rows.Count > 0) ret = BMList_dt.Rows[0]["BC"].ToString();
            return ret;
        }
        #endregion

        #region 得到上一期的报纸出版日期
        /// <summary>
        /// 得到上一期的报纸出版日期(返回-1说明没有上一期)
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="RQ">当前出版日期</param>
        /// <returns>返回-1说明没有上一期</returns>
        public int getPreRQ(int paperID, int RQ)
        {
            int ret = -1;
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select top 1 RQ from paperFirstBMB where paperID=" + paperID + " and RQ<" + RQ + " order by RQ desc";
            DataTable dt = dataSql.ExecuteTable();
            if (dt.Rows.Count > 0) ret = int.Parse(dt.Rows[0]["RQ"].ToString());
            return ret;
        }
        #endregion

        #region 得到下一期的报纸出版日期
        /// <summary>
        /// 得到下一期的报纸出版日期(返回-1说明没有下一期)
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="RQ">当前出版日期</param>
        /// <returns>返回-1说明没有下一期</returns>
        public int getNextRQ(int paperID, int RQ)
        {
            int ret = -1;
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select top 1 RQ from paperFirstBMB where paperID=" + paperID + " and RQ>" + RQ + " order by RQ asc";
            DataTable dt = dataSql.ExecuteTable();
            if (dt.Rows.Count > 0) ret = int.Parse(dt.Rows[0]["RQ"].ToString());
            return ret;
        }
        #endregion

        #region 得到上一篇文章KID
        /// <summary>
        /// 得到上一篇文章KID(返回-1说明已是本版的第一篇)
        /// </summary>
        /// <param name="Article_dt">某版的文章列表</param>
        /// <param name="ArticleHaveBT_dt">有标题的文章数据表</param>
        /// <param name="KID">当前文章KID</param>
        /// <returns></returns>
        public Int64 getPreArticleKID(DataTable Article_dt,DataTable ArticleHaveBT_dt, Int64 KID)
        {
            Int64 ret = -1;

            for (int i = 0; i < ArticleHaveBT_dt.Rows.Count; i++)
            {
                if (ArticleHaveBT_dt.Rows[i]["KID"].ToString() == KID.ToString())
                {
                    if (i != 0) ret = Int64.Parse(ArticleHaveBT_dt.Rows[i - 1]["KID"].ToString());
                    break;
                }
            }
            if (ret != -1) return ret;

            for (int i = 0; i < Article_dt.Rows.Count; i++)
            {
                if (Article_dt.Rows[i]["KID"].ToString() == KID.ToString())
                {
                    if (i != 0) ret = Int64.Parse(Article_dt.Rows[i - 1]["KID"].ToString());
                    break;
                }
            }
            return ret;
        }
        #endregion

        #region 得到下一篇文章KID
        /// <summary>
        /// 得到下一篇文章KID(返回-1说明已是本版的最后一篇)
        /// </summary>
        /// <param name="Article_dt">某版的文章列表</param>
        /// <param name="ArticleHaveBT_dt">有标题的文章数据表</param>
        /// <param name="KID">当前文章KID</param>
        /// <returns></returns>
        public Int64 getNextArticleKID(DataTable Article_dt,DataTable ArticleHaveBT_dt, Int64 KID)
        {
            Int64 ret = -1;

            for (int i = 0; i < ArticleHaveBT_dt.Rows.Count; i++)
            {
                if (ArticleHaveBT_dt.Rows[i]["KID"].ToString() == KID.ToString())
                {
                    if (i + 1 < ArticleHaveBT_dt.Rows.Count) ret = Int64.Parse(ArticleHaveBT_dt.Rows[i + 1]["KID"].ToString());
                    break;
                }
            }
            if (ret != -1) return ret;

            for (int i = 0; i < Article_dt.Rows.Count; i++)
            {
                if (Article_dt.Rows[i]["KID"].ToString() == KID.ToString())
                {
                    if (i + 1 < Article_dt.Rows.Count) ret = Int64.Parse(Article_dt.Rows[i + 1]["KID"].ToString());
                    break;
                }
            }
            return ret;
        }
        #endregion

        #region 得到某个月的报纸出版日期列表
        /// <summary>
        /// 得到某个月的报纸出版日期列表
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public DataTable getPaperRQListWithMonth(int paperID, int year, int month)
        {
            PubTool.DateTimeConvert DateTimeConvCs = new PubTool.DateTimeConvert();
            int start = PubTool.Convert.DateToInt(DateTimeConvCs.getMonthFirst(year, month));
            int end = PubTool.Convert.DateToInt(DateTimeConvCs.getMonthEnd(year, month));

            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select RQ from paperFirstBMB where paperID=" + paperID + " and RQ>=" + start + " and RQ<=" + end + " order by RQ asc";
            DataTable dt = dataSql.ExecuteTable();

            return dt;
        }
        #endregion

        #region 得到报纸最近的出版日期
        /// <summary>
        /// 得到报纸最近的出版日期(返回-1说明没有数据)
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <returns>返回-1说明没有数据</returns>
        public int getPaperLastRQ(int paperID)
        {
            int ret = -1;
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select RQ from paperNewBMB where paperID=" + paperID;
            DataTable dt = dataSql.ExecuteTable();
            if (dt.Rows.Count > 0) ret = int.Parse(dt.Rows[0]["RQ"].ToString());
            return ret;
        }
        #endregion


        #region 生成日历天html
        /// <summary>
        /// 生成日历天html
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="RQ">当前版面日期</param>
        public string calendarDateHtml(int paperID, int year, int month, int RQ)
        {
            PubTool.logtext logCs = new PubTool.logtext("calendarTime", true);

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;

            PubTool.DateTimeConvert DateTimeConvCs = new PubTool.DateTimeConvert();
            PM.BLL.BLL_paperFirstBMB paperFirstBMBCs = new PM.BLL.BLL_paperFirstBMB();

            DateTime startDate = DateTimeConvCs.getMonthFirst(year, month);
            DateTime endDate = DateTimeConvCs.getMonthEnd(year, month);
            DataTable dt = paperFirstBMBCs.getHaveDataRQList(paperID, PubTool.Convert.DateToInt(startDate), PubTool.Convert.DateToInt(endDate));
            Dictionary<int, int> RQdic = new Dictionary<int, int>();//有数据的日期字典对象
            foreach (DataRow row in dt.Rows)
            {
                RQdic.Add(int.Parse(row["RQ"].ToString()), 0);
            }
            int Offset = DateTimeConvCs.getWeekDateFirstSunday(startDate.DayOfWeek);//日期的偏移数
            int date = 0;//当前已输出的日期

            StringBuilder dateHtml = new StringBuilder();
            string styleName = "";
            string url = "";
            string link = "";
            int nowDate = 0;
            for (int i = 0; i < 42; i++)
            {
                styleName = "calendardateNot";
                url = "";
                link = "";
                if (i >= Offset && date < endDate.Day)
                {
                    date++;
                    nowDate = PubTool.Convert.DateToInt(startDate.AddDays(date - 1));
                    if (RQdic.ContainsKey(nowDate))
                    {
                        styleName = "calendardateHave";
                        if (nowDate == RQ) styleName = "calendardateNow";
                        url = "BMList.aspx?paperID=" + paperID + "&RQ=" + nowDate;
                        link = "<a href=\"" + url + "\" class=\"" + styleName + "\">" + date.ToString() + "</a>";
                    }
                    else
                    {
                        styleName = "calendardateNot";
                        if (nowDate == RQ) styleName = "calendardateNow";
                        link = "<span class=\"" + styleName + "\">" + date.ToString() + "</span>";
                    }
                }
                else
                {
                    link = "<span class=\" calendardateNot\">&nbsp;</span>";
                }

                if (i != 0) dateHtml.Append("!");
                dateHtml.Append(link);
            }
           

            time2 = DateTime.Now;
            //logCs.WriteLine("生成日历数据用时：" + time2.Subtract(time1).ToString());
           return dateHtml.ToString();
        }
        #endregion
    }
}
