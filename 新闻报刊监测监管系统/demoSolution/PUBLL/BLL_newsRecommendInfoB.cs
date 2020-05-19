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
    /// 报道推荐信息数据处理类
    /// </summary>
    public class BLL_newsRecommendInfoB
    {
        /// <summary>
        /// 报道推荐信息数据处理类
        /// </summary>
        public BLL_newsRecommendInfoB()
        { }

        #region 获取当前用户报道推荐列表(分页)
        /// <summary>
        /// 获取当前用户报道推荐列表(分页)
        /// </summary>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass getUserNewsRecommendInfoBList(int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            string sql = @"select  dbo.newsRecommendInfoB.*, dbo.[User].userName  from dbo.newsRecommendInfoB LEFT OUTER JOIN
                                      dbo.[User] ON dbo.newsRecommendInfoB.sourceUserGUID = dbo.[User].userGUID 
                           where objectUserGUID='" + webUser.UserGUID + "'";
            sql += " order by newscInfoID desc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(sql, null, pageSize, goPage);
            return retModel;
        }
        #endregion

        #region 获取一个报道推荐信息实体
        /// <summary>
        /// 获取一个报道推荐信息实体
        /// </summary>
        /// <param name="newscInfoID">报道推荐信息ID</param>
        /// <returns>报道推荐信息实体</returns>
        public PU.Model.MDL_newsRecommendInfoB GetModel(int newscInfoID)
        {
            PU.DAL.DAL_newsRecommendInfoB dal_newsRecommendInfoB = new DAL_newsRecommendInfoB();
            return dal_newsRecommendInfoB.GetModel(newscInfoID);
        }
        #endregion


        #region 添加报道推荐信息
        /// <summary>
        /// 添加报道推荐信息
        /// </summary>
        /// <param name="KIDStr">文章KID串。多个以“,”隔开</param>
        /// <param name="objectUserGUIDs">目标用户GUID，多个以“,”隔开</param>
        /// <param name="delsl">被删除的数量</param>
        /// <returns></returns>
        public int Add(string KIDStr, string objectUserGUIDs, out int delsl)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            string[] objectUserGUIDArr = objectUserGUIDs.Split(',');

            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();
            DataTable dt = paperCs.getDataWithKID(KIDStr, "KID,paperID,BT,ZZ,MC,RQ,BC,BM,PD,JP");

            int oksl = 0;
            delsl = KIDStr.Split(',').Length - dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                PU.Model.MDL_newsRecommendInfoB model = new MDL_newsRecommendInfoB();
                model.KID = Int64.Parse(row["KID"].ToString());
                model.paperID = int.Parse(row["paperID"].ToString());
                model.BT = row["BT"].ToString();
                model.ZZ = row["ZZ"].ToString();
                model.MC = row["MC"].ToString();
                model.RQ = int.Parse(row["RQ"].ToString());
                model.BC = row["BC"].ToString();
                model.BM = row["BM"].ToString();
                model.PD = row["PD"].ToString();
                model.JP = row["JP"].ToString();
                model.sourceUserGUID = webUser.UserGUID;
                foreach (string objectUserGUID in objectUserGUIDArr)
                {
                    model.objectUserGUID = objectUserGUID;
                    Add(model);
                }
                oksl++;
            }
            return oksl;
        }
        #endregion

        #region 添加报道推荐信息
        /// <summary>
        /// 添加报道推荐信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报道推荐信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_newsRecommendInfoB model)
        {
            Delete(model.sourceUserGUID, model.objectUserGUID, model.KID);
            PU.DAL.DAL_newsRecommendInfoB dal_newsRecommendInfoB = new DAL_newsRecommendInfoB();
            return dal_newsRecommendInfoB.Add(model);
        }
        #endregion

        #region 修改报道推荐信息
        /// <summary>
        /// 修改报道推荐信息,返回所影响的行数
        /// </summary>
        /// <param name="model">报道推荐信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_newsRecommendInfoB model)
        {
            PU.DAL.DAL_newsRecommendInfoB dal_newsRecommendInfoB = new DAL_newsRecommendInfoB();
            return dal_newsRecommendInfoB.Update(model);
        }
        #endregion

        #region 删除报道推荐信息
        /// <summary>
        /// 删除报道推荐信息,返回所影响的行数
        /// </summary>
        /// <param name="newscInfoID">报道推荐信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int newscInfoID)
        {
            PU.DAL.DAL_newsRecommendInfoB dal_newsRecommendInfoB = new DAL_newsRecommendInfoB();
            return dal_newsRecommendInfoB.Delete(newscInfoID);
        }
        #endregion

        #region 删除报道推荐信息
        /// <summary>
        /// 删除报道推荐信息
        /// </summary>
        /// <param name="sourceUserGUID">来源用户GUID</param>
        /// <param name="objectUserGUID">目标用户GUID</param>
        /// <param name="KID">文章ID</param>
        /// <returns></returns>
        public int Delete(string sourceUserGUID, string objectUserGUID, Int64 KID)
        {
            PU.DAL.DAL_newsRecommendInfoB dal_newsRecommendInfoB = new DAL_newsRecommendInfoB();
            return dal_newsRecommendInfoB.Delete(sourceUserGUID, objectUserGUID, KID);
        }
        #endregion
    }
}
