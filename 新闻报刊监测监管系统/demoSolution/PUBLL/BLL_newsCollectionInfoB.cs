using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using PU.Model;
using PU.DAL;

namespace PU.BLL
{
    /// <summary>
    /// 报道收藏信息数据处理类
    /// </summary>
    public class BLL_newsCollectionInfoB
    {
        /// <summary>
        /// 报道收藏信息数据处理类
        /// </summary>
        public BLL_newsCollectionInfoB()
        { }

        #region 获取当前用户报道收藏列表(分页)
        /// <summary>
        /// 获取当前用户报道收藏列表(分页)
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID。如果为-1则列出所有收藏的文章</param>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass getUserNewsCollectionList(int newsCollectionTypeID, int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            string sql = "select *  from newsCollectionInfoB where userGUID='" + webUser.UserGUID + "'";
            if (newsCollectionTypeID != -1) sql += " and newsCollectionTypeID=" + newsCollectionTypeID;
            sql += " order by newsCollectionInfoID asc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(sql, null, pageSize, goPage);
            return retModel;
        }
        #endregion

        #region 获取一个报道收藏信息实体
        /// <summary>
        /// 获取一个报道收藏信息实体
        /// </summary>
        /// <param name="newsCollectionInfoID">报道收藏信息ID</param>
        /// <returns>报道收藏信息实体</returns>
        public PU.Model.MDL_newsCollectionInfoB GetModel(int newsCollectionInfoID)
        {
            PU.DAL.DAL_newsCollectionInfoB dal_newsCollectionInfoB = new DAL_newsCollectionInfoB();
            return dal_newsCollectionInfoB.GetModel(newsCollectionInfoID);
        }
        #endregion

        #region 添加报道收藏信息
        /// <summary>
        /// 添加报道收藏信息
        /// </summary>
        /// <param name="KIDStr">文章KID串。多个以“,”隔开</param>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <param name="delsl">被删除的数量</param>
        /// <returns></returns>
        public int Add(string KIDStr, int newsCollectionTypeID, out int delsl)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();

            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();
            DataTable dt = paperCs.getDataWithKID(KIDStr, "KID,paperID,BT,ZZ,MC,RQ,BC,BM,PD,JP");

            int oksl = 0;
            delsl = KIDStr.Split(',').Length - dt.Rows.Count;

            Int64 KID = 0;
            foreach (DataRow row in dt.Rows)
            {
                KID = Int64.Parse(row["KID"].ToString());
                if (ifHave(KID, webUser.UserGUID)) continue;
                PU.Model.MDL_newsCollectionInfoB model = new MDL_newsCollectionInfoB();
                model.KID = KID;
                model.newsCollectionTypeID = newsCollectionTypeID;
                model.paperID = int.Parse(row["paperID"].ToString());
                model.BT = row["BT"].ToString();
                model.ZZ = row["ZZ"].ToString();
                model.MC = row["MC"].ToString();
                model.RQ = int.Parse(row["RQ"].ToString());
                model.BC = row["BC"].ToString();
                model.BM = row["BM"].ToString();
                model.PD = row["PD"].ToString();
                model.JP = row["JP"].ToString();
                model.userGUID = webUser.UserGUID;

                PU.DAL.DAL_newsCollectionInfoB dal_newsCollectionInfoB = new DAL_newsCollectionInfoB();
                dal_newsCollectionInfoB.Add(model);
                oksl++;
            }
            return oksl;
        }
        #endregion

        


        #region 修改报道收藏信息
        /// <summary>
        /// 修改报道收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="model">报道收藏信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_newsCollectionInfoB model)
        {
            PU.DAL.DAL_newsCollectionInfoB dal_newsCollectionInfoB = new DAL_newsCollectionInfoB();
            return dal_newsCollectionInfoB.Update(model);
        }
        #endregion

        #region 删除报道收藏信息
        /// <summary>
        /// 删除报道收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="newsCollectionInfoID">报道收藏信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int newsCollectionInfoID)
        {
            PU.DAL.DAL_newsCollectionInfoB dal_newsCollectionInfoB = new DAL_newsCollectionInfoB();
            return dal_newsCollectionInfoB.Delete(newsCollectionInfoID);
        }
        #endregion

        #region 判断用户文章是否已收藏
        /// <summary>
        /// 判断用户文章是否已收藏
        /// </summary>
        /// <param name="KID">文章KID</param>
        /// <param name="UserGUID">用户GUID</param>
        /// <returns>true：已收藏、false：未收藏</returns>
        private bool ifHave(Int64 KID, string UserGUID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select paperID from newsCollectionInfoB where userGUID='" + UserGUID + "' and KID=" + KID;
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;
            return ret;
        }
        #endregion
    }
}
