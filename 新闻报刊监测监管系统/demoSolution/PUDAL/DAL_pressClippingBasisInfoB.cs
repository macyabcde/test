using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PU.DAL
{
    /// <summary>
    /// 剪报基本信息数据访问类
    /// </summary>
    public class DAL_pressClippingBasisInfoB
    {
        /// <summary>
        /// 剪报基本信息数据访问类
        /// </summary>
        public DAL_pressClippingBasisInfoB()
        { }

        #region 获取一个剪报基本信息实体
        /// <summary>
        /// 获取一个剪报基本信息实体
        /// </summary>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns>剪报基本信息实体</returns>
        public PU.Model.MDL_pressClippingBasisInfoB GetModel(int pressClippingBasisInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from pressClippingBasisInfoB");
            strSql.Append(" where pressClippingBasisInfoID=@pressClippingBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@pressClippingBasisInfoID",SqlDbType.Int,0,pressClippingBasisInfoID)
                                        };
            PU.Model.MDL_pressClippingBasisInfoB model = new PU.Model.MDL_pressClippingBasisInfoB();
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            dataSql.Close();
            if (dt.Rows.Count == 0) return null;
            model.pressClippingBasisInfoID = int.Parse(dt.Rows[0]["pressClippingBasisInfoID"].ToString());
            model.createUserGUID = dt.Rows[0]["createUserGUID"].ToString();
            model.pressClippingName = dt.Rows[0]["pressClippingName"].ToString();
            model.customer = dt.Rows[0]["customer"].ToString();
            model.salesman = dt.Rows[0]["salesman"].ToString();
            model.exportOrder = int.Parse(dt.Rows[0]["exportOrder"].ToString());
            model.examineNotion = dt.Rows[0]["examineNotion"].ToString();
            model.examineUserGUID = dt.Rows[0]["examineUserGUID"].ToString();
            model.state = int.Parse(dt.Rows[0]["state"].ToString());
            model.remark = dt.Rows[0]["remark"].ToString();
            model.createTime = DateTime.Parse(dt.Rows[0]["createTime"].ToString());
            return model;
        }
        #endregion

        #region 添加剪报基本信息
        /// <summary>
        /// 添加剪报基本信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">剪报基本信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_pressClippingBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pressClippingBasisInfoB(");
            strSql.Append("createUserGUID,pressClippingName,customer,salesman,exportOrder,examineNotion,examineUserGUID,[state],remark)");
            strSql.Append(" values(");
            strSql.Append("@createUserGUID,@pressClippingName,@customer,@salesman,@exportOrder,@examineNotion,@examineUserGUID,@state,@remark)");
            strSql.Append(" select  SCOPE_IDENTITY() as pressClippingBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@createUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.createUserGUID)),
                    dataSql.MakeInParam("@pressClippingName",SqlDbType.NVarChar,100,model.pressClippingName),
                    dataSql.MakeInParam("@customer",SqlDbType.NVarChar,100,model.customer),
                    dataSql.MakeInParam("@salesman",SqlDbType.NVarChar,100,model.salesman),
                    dataSql.MakeInParam("@exportOrder",SqlDbType.Int,0,model.exportOrder),
                    dataSql.MakeInParam("@examineNotion",SqlDbType.NText,0,model.examineNotion),
                    dataSql.MakeInParam("@examineUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.examineUserGUID)),
                    dataSql.MakeInParam("@state",SqlDbType.Int,0,model.state),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            DataTable dt = dataSql.ExecuteTable(parameters);
            int pressClippingBasisInfoID = int.Parse(dt.Rows[0]["pressClippingBasisInfoID"].ToString());
            dataSql.Close();
            return pressClippingBasisInfoID;
        }
        #endregion

        #region 修改剪报基本信息
        /// <summary>
        /// 修改剪报基本信息,返回所影响的行数
        /// </summary>
        /// <param name="model">剪报基本信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_pressClippingBasisInfoB model)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pressClippingBasisInfoB set ");
            strSql.Append("createUserGUID=@createUserGUID,");
            strSql.Append("pressClippingName=@pressClippingName,");
            strSql.Append("customer=@customer,");
            strSql.Append("salesman=@salesman,");
            strSql.Append("exportOrder=@exportOrder,");
            strSql.Append("examineNotion=@examineNotion,");
            strSql.Append("examineUserGUID=@examineUserGUID,");
            strSql.Append("[state]=@state,");
            strSql.Append("remark=@remark");
            strSql.Append(" where pressClippingBasisInfoID=@pressClippingBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@pressClippingBasisInfoID",SqlDbType.Int,0,model.pressClippingBasisInfoID),
                    dataSql.MakeInParam("@createUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.createUserGUID)),
                    dataSql.MakeInParam("@pressClippingName",SqlDbType.NVarChar,100,model.pressClippingName),
                    dataSql.MakeInParam("@customer",SqlDbType.NVarChar,100,model.customer),
                    dataSql.MakeInParam("@salesman",SqlDbType.NVarChar,100,model.salesman),
                    dataSql.MakeInParam("@exportOrder",SqlDbType.Int,0,model.exportOrder),
                    dataSql.MakeInParam("@examineNotion",SqlDbType.NText,0,model.examineNotion),
                    dataSql.MakeInParam("@examineUserGUID",SqlDbType.UniqueIdentifier,0,new Guid(model.examineUserGUID)),
                    dataSql.MakeInParam("@state",SqlDbType.Int,0,model.state),
                    dataSql.MakeInParam("@remark",SqlDbType.NText,0,model.remark)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion

        #region 删除修改剪报基本
        /// <summary>
        /// 删除修改剪报基本,返回所影响的行数
        /// </summary>
        /// <param name="pressClippingBasisInfoID">修改剪报基本ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int pressClippingBasisInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pressClippingBasisInfoB");
            strSql.Append(" where pressClippingBasisInfoID=@pressClippingBasisInfoID");
            SqlParameter[] parameters ={
                    dataSql.MakeInParam("@pressClippingBasisInfoID",SqlDbType.Int,0,pressClippingBasisInfoID)
                                        };
            dataSql.sql = strSql.ToString();
            int RetValue = dataSql.ExecuteNonQuery(parameters);
            dataSql.Close();
            return RetValue;
        }
        #endregion
    }
}
