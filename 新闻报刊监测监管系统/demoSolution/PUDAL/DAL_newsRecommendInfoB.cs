using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 报道推荐信息数据访问类
    /// </summary>
    public class DAL_newsRecommendInfoB
    {
        /// <summary>
        /// 报道推荐信息数据访问类
        /// </summary>
        public DAL_newsRecommendInfoB()
        { }

        #region 获取一个报道推荐信息实体
        /// <summary>
        /// 获取一个报道推荐信息实体
        /// </summary>
        /// <param name="newscInfoID">报道推荐信息ID</param>
        /// <returns>报道推荐信息实体</returns>
        public PU.Model.MDL_newsRecommendInfoB GetModel(int newscInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from newsRecommendInfoB");
            strSql.Append(" where newscInfoID=@newscInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newscInfoID",SqlDbType.Int,0,newscInfoID)
                                        };
            PU.Model.MDL_newsRecommendInfoB model = new PU.Model.MDL_newsRecommendInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.newscInfoID = int.Parse(dt.Rows[0]["newscInfoID"].ToString());
            model.sourceUserGUID = dt.Rows[0]["sourceUserGUID"].ToString();
            model.objectUserGUID = dt.Rows[0]["objectUserGUID"].ToString();
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

        #region 添加报道推荐信息
        /// <summary>
        /// 添加报道推荐信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报道推荐信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_newsRecommendInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into newsRecommendInfoB(");
            strSql.Append("sourceUserGUID,objectUserGUID,paperID,KID,BT,ZZ,MC,RQ,BC,BM,PD,JP)");
            strSql.Append(" values(");
            strSql.Append("@sourceUserGUID,@objectUserGUID,@paperID,@KID,@BT,@ZZ,@MC,@RQ,@BC,@BM,@PD,@JP)");
            strSql.Append(" select  SCOPE_IDENTITY() as newscInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@sourceUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.sourceUserGUID)),
                    dataSql.MakeInParam("@objectUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.objectUserGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@KID",SqlDbType.BigInt,0,model.KID),
                    dataSql.MakeInParam("@BT",SqlDbType.NVarChar,200,model.BT),
                    dataSql.MakeInParam("@ZZ",SqlDbType.NVarChar,100,model.ZZ),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int newscInfoID = int.Parse(dt.Rows[0]["newscInfoID"].ToString());
            dataSql.Close();
            return newscInfoID;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update newsRecommendInfoB set ");
            strSql.Append("sourceUserGUID=@sourceUserGUID,");
            strSql.Append("objectUserGUID=@objectUserGUID,");
            strSql.Append("paperID=@paperID,");
            strSql.Append("KID=@KID,");
            strSql.Append("BT=@BT,");
            strSql.Append("ZZ=@ZZ,");
            strSql.Append("MC=@MC,");
            strSql.Append("RQ=@RQ,");
            strSql.Append("BC=@BC,");
            strSql.Append("BM=@BM,");
            strSql.Append("PD=@PD,");
            strSql.Append("JP=@JP");
            strSql.Append(" where newsRecommendInfoB=@newsRecommendInfoB");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newscInfoID",SqlDbType.Int,0,model.newscInfoID),
                    dataSql.MakeInParam("@sourceUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.sourceUserGUID)),
                    dataSql.MakeInParam("@objectUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.objectUserGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@KID",SqlDbType.BigInt,0,model.KID),
                    dataSql.MakeInParam("@BT",SqlDbType.NVarChar,200,model.BT),
                    dataSql.MakeInParam("@ZZ",SqlDbType.NVarChar,100,model.ZZ),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from newsRecommendInfoB");
            strSql.Append(" where newscInfoID=@newscInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@newscInfoID",SqlDbType.Int,0,newscInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
        public int Delete(string sourceUserGUID,string objectUserGUID,Int64 KID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "delete from newsRecommendInfoB where sourceUserGUID='" + sourceUserGUID + "' and objectUserGUID='" + objectUserGUID + "' and KID=" + KID;
         
            int RetValue = dataSql.ExecuteNonQuery();
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
