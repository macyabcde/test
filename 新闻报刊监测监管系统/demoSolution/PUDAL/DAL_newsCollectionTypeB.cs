using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 报道收藏类别数据访问类
    /// </summary>
    public class DAL_newsCollectionTypeB
    {
        /// <summary>
        /// 报道收藏类别数据访问类
        /// </summary>
        public DAL_newsCollectionTypeB()
        { }

        #region 获取一个报道收藏类别实体
        /// <summary>
        /// 获取一个报道收藏类别实体
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>报道收藏类别实体</returns>
        public PU.Model.MDL_newsCollectionTypeB GetModel(int newsCollectionTypeID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from newsCollectionTypeB");
            strSql.Append(" where newsCollectionTypeID=@newsCollectionTypeID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionTypeID",SqlDbType.Int,0,newsCollectionTypeID)
                                        };
            PU.Model.MDL_newsCollectionTypeB model = new PU.Model.MDL_newsCollectionTypeB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.newsCollectionTypeID = int.Parse(dt.Rows[0]["newsCollectionTypeID"].ToString());
            model.userGUID = dt.Rows[0]["userGUID"].ToString();
            model.collectionTypeName = dt.Rows[0]["collectionTypeName"].ToString();
            model.xuhao = int.Parse(dt.Rows[0]["xuhao"].ToString());
            model.paterNewsCollectionTypeID = int.Parse(dt.Rows[0]["paterNewsCollectionTypeID"].ToString());
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加报道收藏类别
        /// <summary>
        /// 添加报道收藏类别,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报道收藏类别实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_newsCollectionTypeB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into newsCollectionTypeB(");
            strSql.Append("userGUID,collectionTypeName,xuhao,paterNewsCollectionTypeID)");
            strSql.Append(" values(");
            strSql.Append("@userGUID,@collectionTypeName,@xuhao,@paterNewsCollectionTypeID)");
            strSql.Append(" select  SCOPE_IDENTITY() as newsCollectionTypeID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@collectionTypeName",SqlDbType.NVarChar,80,model.collectionTypeName),
                    dataSql.MakeInParam("@xuhao",SqlDbType.Int,0,model.xuhao),
                    dataSql.MakeInParam("@paterNewsCollectionTypeID",SqlDbType.Int,0,model.paterNewsCollectionTypeID)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int newsCollectionTypeID = int.Parse(dt.Rows[0]["newsCollectionTypeID"].ToString());
            dataSql.Close();
            return newsCollectionTypeID;
        }
        #endregion

        #region 修改报道收藏类别
        /// <summary>
        /// 修改报道收藏类别,返回所影响的行数
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_newsCollectionTypeB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update newsCollectionTypeB set ");
            strSql.Append("userGUID=@userGUID,");
            strSql.Append("collectionTypeName=@collectionTypeName,");
            strSql.Append("xuhao=@xuhao,");
            strSql.Append("paterNewsCollectionTypeID=@paterNewsCollectionTypeID");
            strSql.Append(" where newsCollectionTypeID=@newsCollectionTypeID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionTypeID",SqlDbType.Int,0,model.newsCollectionTypeID),
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@collectionTypeName",SqlDbType.NVarChar,80,model.collectionTypeName),
                    dataSql.MakeInParam("@xuhao",SqlDbType.Int,0,model.xuhao),
                    dataSql.MakeInParam("@paterNewsCollectionTypeID",SqlDbType.Int,0,model.paterNewsCollectionTypeID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删除报道收藏类别
        /// <summary>
        /// 删除报道收藏类别,返回所影响的行数
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int newsCollectionTypeID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from newsCollectionTypeB");
            strSql.Append(" where newsCollectionTypeID=@newsCollectionTypeID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionTypeID",SqlDbType.Int,0,newsCollectionTypeID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
