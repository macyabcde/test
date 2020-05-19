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
    /// 报纸收藏信息数据处理类
    /// </summary>
    public class BLL_paperCollectionInfoB
    {
        /// <summary>
        /// 报纸收藏信息数据处理类
        /// </summary>
        public BLL_paperCollectionInfoB()
        { }

        #region 获取当前用户收藏的所有报刊列表
        /// <summary>
        /// 获取当前用户收藏的所有报刊列表
        /// </summary>
        /// <returns></returns>
        public DataTable getUserCollectionPaperList()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            DataTable dt = new DataTable();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select paperID from paperCollectionInfoB where userGUID='" + webUser.UserGUID + "' order by createTime asc";
            DataTable sc_dt = dataSql.ExecuteTable();
            StringBuilder scPaperID_sb = new StringBuilder();
            for (int i = 0; i < sc_dt.Rows.Count; i++)
            {
                if (i != 0) scPaperID_sb.Append(",");
                scPaperID_sb.Append(sc_dt.Rows[i]["paperID"].ToString());
            }
            string scPaperIDs = scPaperID_sb.ToString();
            if (scPaperIDs == "") return dt;

            PubTool.DB.databaseSql PMdataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PMDBconn, true);

            PMdataSql.sql = "select paperID, paperName, paperNewBMID, RQ, BC, BM, JP from PaperWithNewBMView where paperID in(" + scPaperIDs + ")";
            DataTable paper_dt = PMdataSql.ExecuteTable();
            if (paper_dt.Rows.Count == 0) return dt;
            Dictionary<int, DataRow> dic = new Dictionary<int, DataRow>();
            foreach (DataRow row in paper_dt.Rows)
            {
                dic.Add(int.Parse(row["paperID"].ToString()), row);
            }

            List<DataRow> list = new List<DataRow>();
            int paperID = 0;
            foreach (DataRow row in sc_dt.Rows)
            {
                paperID = int.Parse(row["paperID"].ToString());
                if (dic.ContainsKey(paperID)) list.Add(dic[paperID]);
            }
            dt = list.CopyToDataTable();

            return dt;
        }
        #endregion

        #region 获取一个报纸收藏信息实体
        /// <summary>
        /// 获取一个报纸收藏信息实体
        /// </summary>
        /// <param name="paperCollectionInfoID">报纸收藏信息ID</param>
        /// <returns>报纸收藏信息实体</returns>
        public PU.Model.MDL_paperCollectionInfoB GetModel(int paperCollectionInfoID)
        {
            PU.DAL.DAL_paperCollectionInfoB dal_paperCollectionInfoB = new DAL_paperCollectionInfoB();
            return dal_paperCollectionInfoB.GetModel(paperCollectionInfoID);
        }
        #endregion

        #region 添加报纸收藏信息
        /// <summary>
        /// 添加报纸收藏信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报纸收藏信息实体类</param>
        /// <returns></returns>
        public PubTool.ReturnMsg Add(PU.Model.MDL_paperCollectionInfoB model)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (ifHave(model.paperID, model.userGUID))
            {
                msg.Succeed = false;
                msg.Msg = "该报纸您已收藏";
                return msg;
            }
            PU.DAL.DAL_paperCollectionInfoB dal_paperCollectionInfoB = new DAL_paperCollectionInfoB();
            dal_paperCollectionInfoB.Add(model);
            msg.Succeed = true;
            msg.Msg = "报纸收藏成功";
            return msg;
        }
        #endregion

        #region 修改报纸收藏信息
        /// <summary>
        /// 修改报纸收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="model">报纸收藏信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_paperCollectionInfoB model)
        {
            PU.DAL.DAL_paperCollectionInfoB dal_paperCollectionInfoB = new DAL_paperCollectionInfoB();
            return dal_paperCollectionInfoB.Update(model);
        }
        #endregion

        #region 删除报纸收藏信息
        /// <summary>
        /// 删除报纸收藏信息,返回所影响的行数
        /// </summary>
        /// <param name="paperCollectionInfoID">报纸收藏信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int paperCollectionInfoID)
        {
            PU.DAL.DAL_paperCollectionInfoB dal_paperCollectionInfoB = new DAL_paperCollectionInfoB();
            return dal_paperCollectionInfoB.Delete(paperCollectionInfoID);
        }
        #endregion

        #region 删除报纸收藏信息
        /// <summary>
        /// 删除报纸收藏信息
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="userGUID">用户GUID</param>
        /// <returns></returns>
        public int Delete(int paperID, string userGUID)
        {
            PU.DAL.DAL_paperCollectionInfoB dal_paperCollectionInfoB = new DAL_paperCollectionInfoB();
            return dal_paperCollectionInfoB.Delete(paperID, userGUID);
        }
        #endregion


        #region 判断用户报纸是否已收藏
        /// <summary>
        /// 判断用户报纸是否已收藏
        /// </summary>
        /// <param name="paperID">报纸ID</param>
        /// <param name="UserGUID">用户GUID</param>
        /// <returns>true：已收藏、false：未收藏</returns>
        private bool ifHave(int paperID, string UserGUID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select paperID from paperCollectionInfoB where userGUID='" + UserGUID + "' and paperID=" + paperID;
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;
            return ret;
        }
        #endregion
    }
}
