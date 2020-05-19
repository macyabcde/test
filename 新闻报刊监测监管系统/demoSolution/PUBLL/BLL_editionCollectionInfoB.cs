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
    /// 版面收藏信息数据处理类
    /// </summary>
    public class BLL_editionCollectionInfoB
    {
        /// <summary>
        /// 版面收藏信息数据处理类
        /// </summary>
        public BLL_editionCollectionInfoB()
        { }


        #region 获取当前用户收藏的所有版面列表
        /// <summary>
        /// 获取当前用户收藏的所有版面列表
        /// </summary>
        /// <returns></returns>
        public DataTable getUserCollectionEditionList()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select editionCollectionInfoID, paperID, MC, RQ, BC, BM, JP,PD from editionCollectionInfoB  where userGUID='" + webUser.UserGUID + "' order by createTime asc";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 获取一个版面收藏信息实体
        /// <summary>
        /// 获取一个版面收藏信息实体
        /// </summary>
        /// <param name="editionCollectionInfoID">版面收藏信息ID</param>
        /// <returns>版面收藏信息实体</returns>
        public PU.Model.MDL_editionCollectionInfoB GetModel(int editionCollectionInfoID)
        {
            PU.DAL.DAL_editionCollectionInfoB dal_editionCollectionInfoB = new DAL_editionCollectionInfoB();
            return dal_editionCollectionInfoB.GetModel(editionCollectionInfoID);
        }
        #endregion

        #region 添加版面收藏信息
        /// <summary>
        /// 添加版面收藏信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">版面收藏信息实体类</param>
        /// <returns></returns>
        public PubTool.ReturnMsg Add(PU.Model.MDL_editionCollectionInfoB model)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (ifHave(model.paperID, model.RQ, model.BC, model.userGUID))
            {
                msg.Succeed = false;
                msg.Msg = "该版面您已收藏";
                return msg;
            }
            PU.DAL.DAL_editionCollectionInfoB dal_editionCollectionInfoB = new DAL_editionCollectionInfoB();
            msg.aID = dal_editionCollectionInfoB.Add(model);
            msg.Succeed = true;
            msg.Msg = "版面收藏成功";
            return msg;
        }
        #endregion

        #region 修改版面收藏信息
        /// <summary>
        /// 修改版面收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_editionCollectionInfoB model)
        {
            PU.DAL.DAL_editionCollectionInfoB dal_editionCollectionInfoB = new DAL_editionCollectionInfoB();
            return dal_editionCollectionInfoB.Update(model);
        }
        #endregion

        #region 删除版面收藏信息
        /// <summary>
        /// 删除版面收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="editionCollectionInfoID">版面收藏信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int editionCollectionInfoID)
        {
            PU.DAL.DAL_editionCollectionInfoB dal_editionCollectionInfoB = new DAL_editionCollectionInfoB();
            return dal_editionCollectionInfoB.Delete(editionCollectionInfoID);
        }
        #endregion

        #region 判断用户版面是否已收藏
        /// <summary>
        /// 判断用户版面是否已收藏
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="RQ">日期</param>
        /// <param name="BC">版次</param>
        /// <param name="UserGUID">用户GUID</param>
        /// <returns>true：已收藏、false：未收藏</returns>
        private bool ifHave(int paperID,int RQ,string BC, string UserGUID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select paperID from editionCollectionInfoB where userGUID='" + UserGUID + "' and paperID=" + paperID + " and RQ=" + RQ + " and BC='" + BC + "'";
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;
            return ret;
        }
        #endregion
    }
}
