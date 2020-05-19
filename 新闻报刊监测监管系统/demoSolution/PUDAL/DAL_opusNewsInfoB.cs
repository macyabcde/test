using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 作品报道信息数据访问层
    /// </summary>
    public class DAL_opusNewsInfoB
    {
        /// <summary>
        /// 作品报道信息数据访问层
        /// </summary>
        public DAL_opusNewsInfoB()
        { }

        #region 获取一个作品报道信息实体
        /// <summary>
        /// 获取一个作品报道信息实体
        /// </summary>
        /// <param name="opusNewsInfoID">作品报道信息ID</param>
        /// <returns>作品报道信息实体</returns>
        public PU.Model.MDL_opusNewsInfoB GetModel(int opusNewsInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from opusNewsInfoB");
            strSql.Append(" where opusNewsInfoID=@opusNewsInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,opusNewsInfoID)
                                        };
            PU.Model.MDL_opusNewsInfoB model = new PU.Model.MDL_opusNewsInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.opusNewsInfoID = int.Parse(dt.Rows[0]["opusNewsInfoID"].ToString());
            model.opusBasisInfoID = int.Parse(dt.Rows[0]["opusBasisInfoID"].ToString());
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

        #region 添加作品报道信息
        /// <summary>
        /// 添加作品报道信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_opusNewsInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into opusNewsInfoB(");
            strSql.Append("opusBasisInfoID,paperID,KID,BT,ZZ,MC,RQ,BC,BM,PD,JP,ConfirmState)");
            strSql.Append(" values(");
            strSql.Append("@opusBasisInfoID,@paperID,@KID,@BT,@ZZ,@MC,@RQ,@BC,@BM,@PD,@JP,@ConfirmState)");
            strSql.Append(" select  SCOPE_IDENTITY() as opusNewsInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,model.opusBasisInfoID),
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
                    dataSql.MakeInParam("@ConfirmState",SqlDbType.Int,0,model.ConfirmState)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int opusNewsInfoID = int.Parse(dt.Rows[0]["opusNewsInfoID"].ToString());
            dataSql.Close();
            return opusNewsInfoID;
        }
        #endregion

        #region 修改作品报道信息
        /// <summary>
        /// 修改作品报道信息,返回所影响的行数
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_opusNewsInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update opusNewsInfoB set ");
            strSql.Append("opusBasisInfoID=@opusBasisInfoID,");
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
            strSql.Append("ConfirmState=@ConfirmState");
            strSql.Append(" where opusNewsInfoID=@opusNewsInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,model.opusNewsInfoID),
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,model.opusBasisInfoID),
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
                    dataSql.MakeInParam("@ConfirmState",SqlDbType.Int,0,model.ConfirmState)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删除作品报道信息
        /// <summary>
        /// 删除作品报道信息,返回所影响的行数
        /// </summary>
        /// <param name="opusNewsInfoID">作品报道信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int opusNewsInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from opusNewsInfoB");
            strSql.Append(" where opusNewsInfoID=@opusNewsInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusNewsInfoID",SqlDbType.Int,0,opusNewsInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
