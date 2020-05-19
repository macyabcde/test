using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 客户基本信息数据访问类
    /// </summary>
    public class DAL_customerBasisInfoB
    {
        /// <summary>
        /// 客户基本信息数据访问类
        /// </summary>
        public DAL_customerBasisInfoB()
        { }

        #region 获取一个客户基本信息实体
        /// <summary>
        /// 获取一个客户基本信息实体
        /// </summary>
        /// <param name="customerID">客户基本信息ID</param>
        /// <returns>客户基本信息实体</returns>
        public PU.Model.MDL_customerBasisInfoB GetModel(string customerID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from customerBasisInfoB");
            strSql.Append(" where customerID=@customerID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID)
                                        };
            PU.Model.MDL_customerBasisInfoB model = new PU.Model.MDL_customerBasisInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.customerID = dt.Rows[0]["customerID"].ToString();
            model.password = dt.Rows[0]["password"].ToString();
            model.customerName = dt.Rows[0]["customerName"].ToString();
            model.linkman = dt.Rows[0]["linkman"].ToString();
            model.tel = dt.Rows[0]["tel"].ToString();
            model.email = dt.Rows[0]["email"].ToString();
            model.qq = dt.Rows[0]["qq"].ToString();
            model.serviceEndTime =DateTime.Parse(dt.Rows[0]["serviceEndTime"].ToString());
            model.requestLimit =int.Parse(dt.Rows[0]["requestLimit"].ToString());
            model.dataUpdateTime = DateTime.Parse(dt.Rows[0]["dataUpdateTime"].ToString());
            model.active = int.Parse(dt.Rows[0]["active"].ToString());
            model.SyncMode = int.Parse(dt.Rows[0]["SyncMode"].ToString());
            model.createUserGUID = dt.Rows[0]["createUserGUID"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加客户基本信息
        /// <summary>
        /// 添加客户基本信息,返回所影响的行数
        /// </summary>
        /// <param name="model">客户基本信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Add(PU.Model.MDL_customerBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into customerBasisInfoB(");
            strSql.Append("customerID,password,customerName,linkman,tel,email,qq,serviceEndTime,requestLimit,dataUpdateTime,active,SyncMode,createUserGUID)");
            strSql.Append(" values(");
            strSql.Append("@customerID,@password,@customerName,@linkman,@tel,@email,@qq,@serviceEndTime,@requestLimit,@dataUpdateTime,@active,@SyncMode,@createUserGUID)");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,model.customerID),
                    dataSql.MakeInParam("@password",SqlDbType.NVarChar,200,model.password),
                    dataSql.MakeInParam("@customerName",SqlDbType.NVarChar,100,model.customerName),
                    dataSql.MakeInParam("@linkman",SqlDbType.NVarChar,100,model.linkman),
                    dataSql.MakeInParam("@tel",SqlDbType.NVarChar,100,model.tel),
                    dataSql.MakeInParam("@email",SqlDbType.NVarChar,200,model.email),
                    dataSql.MakeInParam("@qq",SqlDbType.NVarChar,50,model.qq),
                    dataSql.MakeInParam("@serviceEndTime",SqlDbType.DateTime,0,model.serviceEndTime),
                    dataSql.MakeInParam("@requestLimit",SqlDbType.Int,0,model.requestLimit),
                    dataSql.MakeInParam("@dataUpdateTime",SqlDbType.DateTime,0,model.dataUpdateTime),
                    dataSql.MakeInParam("@active",SqlDbType.Int,0,model.active),
                    dataSql.MakeInParam("@SyncMode",SqlDbType.Int,0,model.SyncMode),
                    dataSql.MakeInParam("@createUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.createUserGUID))
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 修改客户基本信息
        /// <summary>
        /// 修改客户基本信息,返回所影响的行数
        /// </summary>
        /// <param name="model">客户基本信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_customerBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update customerBasisInfoB set ");
            strSql.Append("password=@password,");
            strSql.Append("customerName=@customerName,");
            strSql.Append("linkman=@linkman,");
            strSql.Append("tel=@tel,");
            strSql.Append("email=@email,");
            strSql.Append("qq=@qq,");
            strSql.Append("serviceEndTime=@serviceEndTime,");
            strSql.Append("requestLimit=@requestLimit,");
            strSql.Append("dataUpdateTime=@dataUpdateTime,");
            strSql.Append("active=@active,");
            strSql.Append("SyncMode=@SyncMode,");
            strSql.Append("createUserGUID=@createUserGUID");
            strSql.Append(" where customerID=@customerID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,model.customerID),
                    dataSql.MakeInParam("@password",SqlDbType.NVarChar,200,model.password),
                    dataSql.MakeInParam("@customerName",SqlDbType.NVarChar,100,model.customerName),
                    dataSql.MakeInParam("@linkman",SqlDbType.NVarChar,100,model.linkman),
                    dataSql.MakeInParam("@tel",SqlDbType.NVarChar,100,model.tel),
                    dataSql.MakeInParam("@email",SqlDbType.NVarChar,200,model.email),
                    dataSql.MakeInParam("@qq",SqlDbType.NVarChar,50,model.qq),
                    dataSql.MakeInParam("@serviceEndTime",SqlDbType.DateTime,0,model.serviceEndTime),
                    dataSql.MakeInParam("@requestLimit",SqlDbType.Int,0,model.requestLimit),
                    dataSql.MakeInParam("@dataUpdateTime",SqlDbType.DateTime,0,model.dataUpdateTime),
                    dataSql.MakeInParam("@active",SqlDbType.Int,0,model.active),
                    dataSql.MakeInParam("@SyncMode",SqlDbType.Int,0,model.SyncMode),
                    dataSql.MakeInParam("@createUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.createUserGUID))
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删除客户基本信息
        /// <summary>
        /// 删除客户基本信息,返回所影响的行数
        /// </summary>
        /// <param name="customerID">客户基本信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(string customerID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from customerBasisInfoB");
            strSql.Append(" where customerID=@customerID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 设置客户有效状态
        /// <summary>
        /// 设置客户有效状态
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="active">有效状态：1启用；0 禁用</param>
        /// <returns>返回所影响的行数</returns>
        public int SetCustomerActive(string customerID, int active)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update customerBasisInfoB set ");
            strSql.Append("active=@active ");
            strSql.Append(" where customerID=@customerID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@customerID",SqlDbType.NVarChar,100,customerID),
                    dataSql.MakeInParam("@active",SqlDbType.Int,0,active)
            };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
