using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 报纸收藏信息数据访问类
    /// </summary>
    public class DAL_paperCollectionInfoB
    {
        /// <summary>
        /// 报纸收藏信息数据访问类
        /// </summary>
        public DAL_paperCollectionInfoB()
        { }

        #region 获取一个报纸收藏信息实体
        /// <summary>
        /// 获取一个报纸收藏信息实体
        /// </summary>
        /// <param name="paperCollectionInfoID">报纸收藏信息ID</param>
        /// <returns>报纸收藏信息实体</returns>
        public PU.Model.MDL_paperCollectionInfoB GetModel(int paperCollectionInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from paperCollectionInfoB");
            strSql.Append(" where paperCollectionInfoID=@paperCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@paperCollectionInfoID",SqlDbType.Int,0,paperCollectionInfoID)
                                        };
            PU.Model.MDL_paperCollectionInfoB model = new PU.Model.MDL_paperCollectionInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.paperCollectionInfoID = int.Parse(dt.Rows[0]["paperCollectionInfoID"].ToString());
            model.userGUID =dt.Rows[0]["userGUID"].ToString();
            model.paperID = int.Parse(dt.Rows[0]["paperID"].ToString());
            model.remark = dt.Rows[0]["remark"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加报纸收藏信息
        /// <summary>
        /// 添加报纸收藏信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报纸收藏信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_paperCollectionInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into paperCollectionInfoB(");
            strSql.Append("userGUID,paperID,remark)");
            strSql.Append(" values(");
            strSql.Append("@userGUID,@paperID,@remark)");
            strSql.Append(" select  SCOPE_IDENTITY() as paperCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int paperCollectionInfoID = int.Parse(dt.Rows[0]["paperCollectionInfoID"].ToString());
            dataSql.Close();
            return paperCollectionInfoID;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update paperCollectionInfoB set ");
            strSql.Append("userGUID=@userGUID,");
            strSql.Append("paperID=@paperID,");
            strSql.Append("remark=@remark");
            strSql.Append(" where paperCollectionInfoID=@paperCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@paperCollectionInfoID",SqlDbType.Int,0,model.paperCollectionInfoID),
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from paperCollectionInfoB");
            strSql.Append(" where paperCollectionInfoID=@paperCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@paperCollectionInfoID",SqlDbType.Int,0,paperCollectionInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "delete from paperCollectionInfoB where paperID=" + paperID + " and userGUID='" + userGUID + "'";            
            int RetValue = dataSql.ExecuteNonQuery();
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
