using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 版面收藏信息数据访问类
    /// </summary>
    public class DAL_editionCollectionInfoB
    {
        /// <summary>
        /// 版面收藏信息数据访问类
        /// </summary>
        public DAL_editionCollectionInfoB()
        { }

        #region 获取一个版面收藏信息实体
        /// <summary>
        /// 获取一个版面收藏信息实体
        /// </summary>
        /// <param name="editionCollectionInfoID">版面收藏信息ID</param>
        /// <returns>版面收藏信息实体</returns>
        public PU.Model.MDL_editionCollectionInfoB GetModel(int editionCollectionInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from editionCollectionInfoB");
            strSql.Append(" where editionCollectionInfoID=@editionCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@editionCollectionInfoID",SqlDbType.Int,0,editionCollectionInfoID)
                                        };
            PU.Model.MDL_editionCollectionInfoB model = new PU.Model.MDL_editionCollectionInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.editionCollectionInfoID = int.Parse(dt.Rows[0]["editionCollectionInfoID"].ToString());
            model.userGUID = dt.Rows[0]["userGUID"].ToString();
            model.paperID = int.Parse(dt.Rows[0]["paperID"].ToString());
            model.MC = dt.Rows[0]["MC"].ToString();
            model.RQ = int.Parse(dt.Rows[0]["RQ"].ToString());
            model.BC = dt.Rows[0]["BC"].ToString();
            model.BM = dt.Rows[0]["BM"].ToString();
            model.PD = dt.Rows[0]["PD"].ToString();
            model.JP = dt.Rows[0]["JP"].ToString();
            model.remark = dt.Rows[0]["remark"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加版面收藏信息
        /// <summary>
        /// 添加版面收藏信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">版面收藏信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_editionCollectionInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into editionCollectionInfoB(");
            strSql.Append("userGUID,paperID,MC,RQ,BC,BM,PD,JP,remark)");
            strSql.Append(" values(");
            strSql.Append("@userGUID,@paperID,@MC,@RQ,@BC,@BM,@PD,@JP,@remark)");
            strSql.Append(" select  SCOPE_IDENTITY() as editionCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int editionCollectionInfoID = int.Parse(dt.Rows[0]["editionCollectionInfoID"].ToString());
            dataSql.Close();
            return editionCollectionInfoID;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update editionCollectionInfoB set ");
            strSql.Append("userGUID=@userGUID,");
            strSql.Append("paperID=@paperID,");
            strSql.Append("MC=@MC,");
            strSql.Append("RQ=@RQ,");
            strSql.Append("BC=@BC,");
            strSql.Append("BM=@BM,");
            strSql.Append("PD=@PD,");
            strSql.Append("JP=@JP,");
            strSql.Append("remark=@remark");
            strSql.Append(" where editionCollectionInfoID=@editionCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@editionCollectionInfoID",SqlDbType.Int,0,model.editionCollectionInfoID),
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,model.paperID),
                    dataSql.MakeInParam("@MC",SqlDbType.NVarChar,50,model.MC),
                    dataSql.MakeInParam("@RQ",SqlDbType.Int,0,model.RQ),
                    dataSql.MakeInParam("@BC",SqlDbType.NVarChar,20,model.BC),
                    dataSql.MakeInParam("@BM",SqlDbType.NVarChar,30,model.BM),
                    dataSql.MakeInParam("@PD",SqlDbType.NVarChar,50,model.PD),
                    dataSql.MakeInParam("@JP",SqlDbType.NVarChar,50,model.JP),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
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
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from editionCollectionInfoB");
            strSql.Append(" where editionCollectionInfoID=@editionCollectionInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@editionCollectionInfoID",SqlDbType.Int,0,editionCollectionInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
