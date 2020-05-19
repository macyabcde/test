using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 客户报纸信息数据访问类
    /// </summary>
    public class DAL_customerPaperInfoB
    {
        /// <summary>
        /// 客户报纸信息数据访问类
        /// </summary>
        public DAL_customerPaperInfoB()
        { }

        #region 获取一个客户报纸信息实体
        /// <summary>
        /// 获取一个客户报纸信息实体
        /// </summary>
        /// <param name="customerPaperID">客户报纸信息ID</param>
        /// <returns>客户报纸信息实体</returns>
        public PU.Model.MDL_customerPaperInfoB GetModel(int customerPaperID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from customerPaperInfoB");
            strSql.Append(" where customerPaperID=@customerPaperID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerPaperID",SqlDbType.Int,0,customerPaperID)
                                        };
            PU.Model.MDL_customerPaperInfoB model = new PU.Model.MDL_customerPaperInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;

            model.customerPaperID = int.Parse(dt.Rows[0]["customerPaperID"].ToString());
            model.customerID = dt.Rows[0]["customerID"].ToString();
            model.paperID = int.Parse(dt.Rows[0]["paperID"].ToString());
            model.updateOverDate = DateTime.Parse(dt.Rows[0]["updateOverDate"].ToString());
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 获取一个客户报纸信息实体
        /// <summary>
        /// 获取一个客户报纸信息实体
        /// </summary>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="customerID">客户信息ID</param>
        /// <returns>客户报纸信息实体</returns>
        public PU.Model.MDL_customerPaperInfoB GetModelForPaperID(int paperID, string customerID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from customerPaperInfoB");
            strSql.Append(" where paperID=@paperID and customerID=@customerID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,paperID),
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID)
                                        };
            PU.Model.MDL_customerPaperInfoB model = new PU.Model.MDL_customerPaperInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;

            model.customerPaperID = int.Parse(dt.Rows[0]["customerPaperID"].ToString());
            model.customerID = dt.Rows[0]["customerID"].ToString();
            model.paperID = int.Parse(dt.Rows[0]["paperID"].ToString());
            model.updateOverDate = DateTime.Parse(dt.Rows[0]["updateOverDate"].ToString());
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加客户报纸信息
        /// <summary>
        /// 添加客户报纸信息,返回所影响的行数
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="updateOverDate">已更新到日期</param>
        /// <returns>所影响的行数</returns>
        public int Add(string customerID, int paperID,string updateOverDate)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into customerPaperInfoB(");
            strSql.Append("customerID,paperID,updateOverDate)");
            strSql.Append(" values(");
            strSql.Append("@customerID,@paperID,@updateOverDate)");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,paperID),
                    dataSql.MakeInParam("@updateOverDate",SqlDbType.DateTime,0,DateTime.Parse(updateOverDate))
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 修改已更新到日期
        /// <summary>
        /// 修改已更新到日期
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="updateOverDate">已更新到日期</param>
        /// <returns>所影响的行数</returns>
        public int EditupdateOverDate(string customerID, int paperID, DateTime updateOverDate)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            string sql = "update customerPaperInfoB set updateOverDate=@updateOverDate where customerID=@customerID and paperID=@paperID";
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,paperID),
                    dataSql.MakeInParam("@updateOverDate",SqlDbType.DateTime,0,updateOverDate)
                                       };
            dataSql.sql = sql;
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            return RetValue;
        }
        #endregion

        #region 获取已更新到日期
        /// <summary>
        /// 获取已更新到日期(返回3000-01-01 说明该客户没有该报纸)
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <returns></returns>
        public DateTime getupdateOverDate(string customerID, int paperID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            string sql = "select updateOverDate from customerPaperInfoB where customerID=" + customerID + " and paperID=" + paperID;

            dataSql.sql = sql;
            DataTable dt = dataSql.ExecuteTable();
            DateTime ret = DateTime.Parse("3000-01-01");
            if (dt.Rows.Count >= 0) ret = DateTime.Parse(dt.Rows[0]["updateOverDate"].ToString());
            return ret;
        }
        #endregion

        #region 删除客户报纸信息
        /// <summary>
        /// 删除客户报纸信息,返回所影响的行数
        /// </summary>
        /// <param name="customerPaperID">客户报纸信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int customerPaperID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from customerPaperInfoB");
            strSql.Append(" where customerPaperID=@customerPaperID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerPaperID",SqlDbType.Int,0,customerPaperID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删除客户报纸信息
        /// <summary>
        /// 删除客户报纸信息,返回所影响的行数
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="paperID">报纸ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(string customerID, int paperID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from customerPaperInfoB");
            strSql.Append(" where customerID=@customerID and paperID=@paperID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,paperID),
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID)
            };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 获取客户报纸信息列表
        /// <summary>
        /// 获取客户报纸信息列表
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns>客户报纸信息列表</returns>
        public DataTable GetCustomerPaperList(string customerID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            string strSql = @"select * from customerPaperInfoB where customerID=@customerID";
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID)
            };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            return dt;
        }
        #endregion

        #region 检测用户是否已有某份报纸信息
        /// <summary>
        /// 检测用户是否已有某份报纸信息。
        /// 返回0表示客户没有此客户信息；如果有返回客户报纸信息ID
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="paperID">报纸ID</param>
        /// <returns>返回0表示客户没有此客户信息；如果有返回客户报纸信息ID</returns>
        public int IfHavePaper(string customerID, int paperID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            string strSql = "select customerPaperID from customerPaperInfoB where customerID=@customerID and paperID=@paperID";
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID),
                    dataSql.MakeInParam("@paperID",SqlDbType.Int,0,paperID)
            };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);

            int retValue = 0;

            if (dt.Rows.Count != 0) retValue = int.Parse(dt.Rows[0]["customerPaperID"].ToString());

            return retValue;
        }
        #endregion
    }
}
