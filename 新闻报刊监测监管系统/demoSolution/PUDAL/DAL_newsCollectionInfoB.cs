using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 报道收藏信息数据访问类
    /// </summary>
    public class DAL_newsCollectionInfoB
    {
        /// <summary>
        /// 报道收藏信息数据访问类
        /// </summary>
        public DAL_newsCollectionInfoB()
        { }

        #region 获取一个报道收藏信息实体
        /// <summary>
        /// 获取一个报道收藏信息实体
        /// </summary>
        /// <param name="newsCollectionInfoID">报道收藏信息ID</param>
        /// <returns>报道收藏信息实体</returns>
        public PU.Model.MDL_newsCollectionInfoB GetModel(int newsCollectionInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from newsCollectionInfoB");
            strSql.Append(" where newsCollectionInfoID=@newsCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionInfoID",SqlDbType.Int,0,newsCollectionInfoID)
                                        };
            PU.Model.MDL_newsCollectionInfoB model = new PU.Model.MDL_newsCollectionInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.newsCollectionInfoID = int.Parse(dt.Rows[0]["newsCollectionInfoID"].ToString());
            model.newsCollectionTypeID = int.Parse(dt.Rows[0]["newsCollectionTypeID"].ToString());
            model.paperID = int.Parse(dt.Rows[0]["paperID"].ToString());
            model.KID = Int64.Parse(dt.Rows[0]["KID"].ToString());
            model.BT = dt.Rows[0]["BT"].ToString();
            model.ZZ = dt.Rows[0]["ZZ"].ToString();
            model.MC = dt.Rows[0]["MC"].ToString();
            model.RQ = int.Parse(dt.Rows[0]["RQ"].ToString());
            model.BC = dt.Rows[0]["BC"].ToString();
            model.BM = dt.Rows[0]["BM"].ToString();
            model.PD = dt.Rows[0]["PD"].ToString();
            model.JP = dt.Rows[0]["JP"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加报道收藏信息
        /// <summary>
        /// 添加报道收藏信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报道收藏信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_newsCollectionInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into newsCollectionInfoB(");
            strSql.Append("newsCollectionTypeID,paperID,KID,BT,ZZ,MC,RQ,BC,BM,PD,JP,userGUID)");
            strSql.Append(" values(");
            strSql.Append("@newsCollectionTypeID,@paperID,@KID,@BT,@ZZ,@MC,@RQ,@BC,@BM,@PD,@JP,@userGUID)");
            strSql.Append(" select  SCOPE_IDENTITY() as newsCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionTypeID",SqlDbType.Int,0,model.newsCollectionTypeID),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@KID",SqlDbType.BigInt,0,model.KID),
                    dataSql.MakeInParam("@BT",SqlDbType.NVarChar,200,model.BT),
                    dataSql.MakeInParam("@ZZ",SqlDbType.NVarChar,100,model.ZZ),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP),
                    dataSql.MakeInParam("@userGUID",SqlDbType.NVarChar,200,model.userGUID)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int newsCollectionInfoID = int.Parse(dt.Rows[0]["newsCollectionInfoID"].ToString());
            dataSql.Close();
            return newsCollectionInfoID;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update newsCollectionInfoB set ");
            strSql.Append("newsCollectionTypeID=@newsCollectionTypeID,");
            strSql.Append("paperID=@paperID,");
            strSql.Append("KID=@KID,");
            strSql.Append("BT=@BT,");
            strSql.Append("ZZ=@ZZ,");
            strSql.Append("MC=@MC,");
            strSql.Append("RQ=@RQ,");
            strSql.Append("BC=@BC,");
            strSql.Append("BM=@BM,");
            strSql.Append("PD=@PD,");
            strSql.Append("JP=@JP,");
            strSql.Append("userGUID=@userGUID");
            strSql.Append(" where newsCollectionInfoID=@newsCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionInfoID",SqlDbType.Int,0,model.newsCollectionInfoID),
                    dataSql.MakeInParam("@newsCollectionTypeID",SqlDbType.Int,0,model.newsCollectionTypeID),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@KID",SqlDbType.BigInt,0,model.KID),
                    dataSql.MakeInParam("@BT",SqlDbType.NVarChar,200,model.BT),
                    dataSql.MakeInParam("@ZZ",SqlDbType.NVarChar,100,model.ZZ),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP),
                    dataSql.MakeInParam("@userGUID",SqlDbType.NVarChar,200,model.userGUID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from newsCollectionInfoB");
            strSql.Append(" where newsCollectionInfoID=@newsCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newsCollectionInfoID",SqlDbType.Int,0,newsCollectionInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
