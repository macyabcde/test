using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 作品基本信息数据访问类
    /// </summary>
    public class DAL_opusBasisInfoB
    {
        /// <summary>
        /// 作品基本信息数据访问类
        /// </summary>
        public DAL_opusBasisInfoB()
        { }

        #region 获取一个作品基本信息实体
        /// <summary>
        /// 获取一个作品基本信息实体
        /// </summary>
        /// <param name="opusBasisInfoID">作品基本信息ID</param>
        /// <returns>作品基本信息实体</returns>
        public PU.Model.MDL_opusBasisInfoB GetModel(int opusBasisInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from opusBasisInfoB");
            strSql.Append(" where opusBasisInfoID=@opusBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,opusBasisInfoID)
                                        };
            PU.Model.MDL_opusBasisInfoB model = new PU.Model.MDL_opusBasisInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.opusBasisInfoID = int.Parse(dt.Rows[0]["opusBasisInfoID"].ToString());
            model.userGUID = dt.Rows[0]["userGUID"].ToString();
            model.dataUpdateTime = DateTime.Parse(dt.Rows[0]["dataUpdateTime"].ToString());
            model.ifAutoCreate = int.Parse(dt.Rows[0]["ifAutoCreate"].ToString());
            model.remark = dt.Rows[0]["remark"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加作品基本信息
        /// <summary>
        /// 添加作品基本信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">作品基本信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_opusBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into opusBasisInfoB(");
            strSql.Append("userGUID,dataUpdateTime,ifAutoCreate,remark)");
            strSql.Append(" values(");
            strSql.Append("@userGUID,@dataUpdateTime,@ifAutoCreate,@remark)");
            strSql.Append(" select  SCOPE_IDENTITY() as opusBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@dataUpdateTime",SqlDbType.DateTime,0,model.dataUpdateTime),
                    dataSql.MakeInParam("@ifAutoCreate",SqlDbType.Int,0,model.ifAutoCreate),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int opusBasisInfoID = int.Parse(dt.Rows[0]["opusBasisInfoID"].ToString());
            dataSql.Close();
            return opusBasisInfoID;
        }
        #endregion

        #region 修改作品基本信息
        /// <summary>
        /// 修改作品基本信息,返回所影响的行数
        /// </summary>
        /// <param name="model">作品基本信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_opusBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update opusBasisInfoB set ");
            strSql.Append("userGUID=@userGUID,");
            strSql.Append("dataUpdateTime=@dataUpdateTime,");
            strSql.Append("ifAutoCreate=@ifAutoCreate,");
            strSql.Append("remark=@remark");
            strSql.Append(" where opusBasisInfoID=@opusBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,model.opusBasisInfoID),
                    dataSql.MakeInParam("@userGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.userGUID)),
                    dataSql.MakeInParam("@dataUpdateTime",SqlDbType.DateTime,0,model.dataUpdateTime),
                    dataSql.MakeInParam("@ifAutoCreate",SqlDbType.Int,0,model.ifAutoCreate),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删作品基本信息
        /// <summary>
        /// 删除作品基本信息,返回所影响的行数
        /// </summary>
        /// <param name="opusBasisInfoID">作品基本信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int opusBasisInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from opusBasisInfoB");
            strSql.Append(" where opusBasisInfoID=@opusBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@opusBasisInfoID",SqlDbType.Int,0,opusBasisInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
