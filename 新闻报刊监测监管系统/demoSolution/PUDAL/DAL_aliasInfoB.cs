using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 笔名信息数据访问类
    /// </summary>
    public class DAL_aliasInfoB
    {
        /// <summary>
        /// 笔名信息数据访问类
        /// </summary>
        public DAL_aliasInfoB()
        { }

        #region 获取一个笔名信息实体
        /// <summary>
        /// 获取一个笔名信息实体
        /// </summary>
        /// <param name="aliasInfoID">笔名信息ID</param>
        /// <returns>笔名信息实体</returns>
        public PU.Model.MDL_aliasInfoB GetModel(int aliasInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aliasInfoID,userGUID,aliasInfo,createTime");
            strSql.Append(" from aliasInfoB");
            strSql.Append(" where aliasInfoID=@aliasInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@aliasInfoID",SqlDbType.Int,0,aliasInfoID)
                                        };
            PU.Model.MDL_aliasInfoB model = new PU.Model.MDL_aliasInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.aliasInfoID = int.Parse(dt.Rows[0]["aliasInfoID"].ToString());
            model.userGUID = dt.Rows[0]["userGUID"].ToString();
            model.aliasInfo = dt.Rows[0]["aliasInfo"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加笔名信息
        /// <summary>
        /// 添加笔名信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">笔名信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_aliasInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into aliasInfoB(");
            strSql.Append("userGUID,aliasInfo)");
            strSql.Append(" values(");
            strSql.Append("@userGUID,@aliasInfo)");
            strSql.Append(" select  SCOPE_IDENTITY() as aliasInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@aliasInfo",SqlDbType.NVarChar,100,model.aliasInfo)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int aliasInfoID = int.Parse(dt.Rows[0]["aliasInfoID"].ToString());
            dataSql.Close();
            return aliasInfoID;
        }
        #endregion

        #region 修改笔名信息
        /// <summary>
        /// 修改笔名信息,返回所影响的行数
        /// </summary>
        /// <param name="model">笔名信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_aliasInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update aliasInfoB set ");
            strSql.Append("userGUID=@userGUID,");
            strSql.Append("aliasInfo=@aliasInfo");
            strSql.Append(" where aliasInfoID=@aliasInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@aliasInfoID",SqlDbType.Int,0,model.aliasInfoID),
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@aliasInfo",SqlDbType.NVarChar,100,model.aliasInfo)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删作笔名信息
        /// <summary>
        /// 删除笔名信息,返回所影响的行数
        /// </summary>
        /// <param name="aliasInfoID">笔名信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int aliasInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from aliasInfoB");
            strSql.Append(" where aliasInfoID=@aliasInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@aliasInfoID",SqlDbType.Int,0,aliasInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
