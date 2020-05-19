using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.BLL
{
    /// <summary>
    /// 报纸信息类
    /// </summary>
    public class BLL_paperB
    {
        public static Dictionary<int, string> dicPaper = new Dictionary<int, string>();

        #region 获取报名称
        /// <summary>
        /// 获取报名称
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <returns></returns>
        public string getPaperName(int paperID)
        {
            string paperName = "";
            if (dicPaper.ContainsKey(paperID))
            {
                paperName = dicPaper[paperID];
            }
            else
            {
                inItdicPaper();
                if (dicPaper.ContainsKey(paperID)) paperName = dicPaper[paperID];
            }
            if (paperName == "") paperName = "未知报纸[" + paperID + "]";
            return paperName;
        }
        #endregion

        #region 判断报纸是否存在
        /// <summary>
        /// 判断报纸是否存在(true：存在)
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <returns></returns>
        public bool ifHavePaper(int paperID)
        {
            if (dicPaper.ContainsKey(paperID))
            {
                return true;
            }
            else
            {
                inItdicPaper();
                if (dicPaper.ContainsKey(paperID))
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region 初始化报名称字典列表
        /// <summary>
        /// 初始化报名称字典列表
        /// </summary>
        public void inItdicPaper()
        {
            PM.BLL.BLL_paperB bll_paperB = new PM.BLL.BLL_paperB();
            DataTable dt = bll_paperB.getAllPaperList();
            dicPaper.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dicPaper.Add(int.Parse(row["paperID"].ToString()), row["paperName"].ToString()); 
            }
        }
        #endregion

        #region 获取所有报刊列表
        /// <summary>
        /// 获取所有报刊列表
        /// </summary>
        /// <returns></returns>
        public DataTable getPaperList()
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP  from PaperWithNewBMView  where active=1 order by xuhao asc";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 获取所有报刊列表
        /// <summary>
        /// 获取所有报刊列表
        /// </summary>
        /// <returns></returns>
        public DataTable getAllPaperList()
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName,province, paperTypeID from paperB  where active=1 order by xuhao asc";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 获取集团报刊列表
        /// <summary>
        /// 获取集团报刊列表
        /// </summary>
        /// <param name="groupName">所属报业集团</param>
        /// <returns></returns>
        public DataTable getGroupPaperList(string groupName)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP  from PaperWithNewBMViewTestTest ";
            DataTable dt = dataSql.ExecuteTable();          
            return dt;
        }
        #endregion

        #region  获取某一省份报刊列表
        /// <summary>
        ///  获取某一省份报刊列表
        /// </summary>
        /// <param name="province">省份</param>
        /// <returns></returns>
        public DataTable getProvincePaperList(int province)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP  from PaperWithNewBMView where province=" + province + " and active=1 order by xuhao asc";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 获取某一类别报刊列表
        /// <summary>
        /// 获取某一类别报刊列表
        /// </summary>
        /// <param name="paperTypeID">分类</param>
        /// <returns></returns>
        public DataTable getTypePaperList(int paperTypeID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP  from PaperWithNewBMView where paperTypeID=" + paperTypeID + " and active=1 order by xuhao asc";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 查询报刊列表
        /// <summary>
        /// 查询报刊列表
        /// </summary>
        /// <param name="key">关节词</param>
        /// <returns></returns>
        public DataTable getSearchPaperList(string key)
        {
            int paperID = 0;
            int.TryParse(key, out paperID);
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);
            dataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP  from PaperWithNewBMView where active=1";
            if (key != "") dataSql.sql += " and (paperName like '%" + key + "%' or pinyin like '%" + key + "%' or paperID=" + paperID + ")";
            dataSql.sql += " order by xuhao asc";

            DataTable dt = dataSql.ExecuteTable();

            return dt;
        }
        #endregion

        #region 获取有报纸的省份报刊对象列表
        /// <summary>
        /// 获取有报纸的省份报刊对象列表
        /// </summary>
        /// <returns></returns>
        public List<PU.Model.MDL_PaperObj> getProvincePaperObj()
        {
            PM.BLL.Comm.dictionaryClass dictionaryCs = new PM.BLL.Comm.dictionaryClass();
            List<PU.Model.MDL_PaperObj> list = new List<PU.Model.MDL_PaperObj>();
            DataTable dt_paper = getAllPaperList();
            DataTable dt_province = dictionaryCs.GetOnedictionaryType("province");
            int province = 0;
            foreach (DataRow row in dt_province.Rows)
            {
                province = int.Parse(row["dictionaryInfoID"].ToString());
                DataRow[] arr = dt_paper.Select("province=" + province);
                if (arr.Length > 0)
                {
                    PU.Model.MDL_PaperObj obj = new PU.Model.MDL_PaperObj();
                    obj.aID = province;
                    obj.name = row["dictionaryName"].ToString();
                    obj.dt = arr.CopyToDataTable();
                    list.Add(obj);
                }
            }

            return list;
        }
        #endregion

        #region 获取有报纸的类别报刊对象列表
        /// <summary>
        /// 获取有报纸的类别报刊对象列表
        /// </summary>
        /// <returns></returns>
        public List<PU.Model.MDL_PaperObj> getTypePaperObj()
        {
            PM.BLL.BLL_paperTypeB paperTypeCs = new PM.BLL.BLL_paperTypeB();
            List<PU.Model.MDL_PaperObj> list = new List<PU.Model.MDL_PaperObj>();
            DataTable dt_paper = getAllPaperList();
            DataTable dt_type = paperTypeCs.GetpaperType();
            int paperTypeID = 0;
            foreach (DataRow row in dt_type.Rows)
            {
                paperTypeID = int.Parse(row["paperTypeID"].ToString());
                DataRow[] arr = dt_paper.Select("paperTypeID=" + paperTypeID);
                if (arr.Length > 0)
                {
                    PU.Model.MDL_PaperObj obj = new PU.Model.MDL_PaperObj();
                    obj.aID = paperTypeID;
                    obj.name = row["collectionTypeName"].ToString();
                    obj.dt = arr.CopyToDataTable();
                    list.Add(obj);
                }
            }

            return list;
        }
        #endregion

        
    }
}
