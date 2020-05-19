using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using PU.Model;
using PU.DAL;

namespace PU.BLL
{
    /// <summary>
    /// 笔名信息数据处理类
    /// </summary>
    public class BLL_aliasInfoB
    {
        /// <summary>
        ///  笔名信息数据处理类 
        /// </summary>
        public BLL_aliasInfoB()
        { }

        #region 获取当前用户笔名列表
        /// <summary>
        /// 获取当前用户笔名列表
        /// </summary>
        /// <returns></returns>
        public DataTable getUserAliasInfoList()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select * from aliasInfoB where userGUID='" + webUser.UserGUID + "'";
            DataTable dt = dataSql.ExecuteTable();
            return dt;
        }
        #endregion

        #region 获取一个笔名信息实体
        /// <summary>
        /// 获取一个笔名信息实体
        /// </summary>
        /// <param name="aliasInfoID">笔名信息ID</param>
        /// <returns>笔名信息实体</returns>
        public PU.Model.MDL_aliasInfoB GetModel(int aliasInfoID)
        {
            PU.DAL.DAL_aliasInfoB dal_aliasInfoB = new DAL_aliasInfoB();
            return dal_aliasInfoB.GetModel(aliasInfoID);
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
            if (ifHave(model.aliasInfo, model.userGUID))
            {
                return -1;
            }
            PU.DAL.DAL_aliasInfoB dal_aliasInfoB = new DAL_aliasInfoB();
            return dal_aliasInfoB.Add(model);
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
            PU.DAL.DAL_aliasInfoB dal_aliasInfoB = new DAL_aliasInfoB();
            return dal_aliasInfoB.Update(model);
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
            PU.DAL.DAL_aliasInfoB dal_aliasInfoB = new DAL_aliasInfoB();
            return dal_aliasInfoB.Delete(aliasInfoID);
        }
        #endregion

        #region 判断笔名是否已存在
        /// <summary>
        /// 判断笔名是否已存在
        /// </summary>
        /// <param name="aliasInfo">笔名</param>
        /// <param name="UserGUID">用户GUID</param>
        /// <returns>true：已存在、false：不存在</returns>
        private bool ifHave(string aliasInfo, string UserGUID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select aliasInfoID from aliasInfoB where userGUID='" + UserGUID + "' and aliasInfo='" + aliasInfo + "'";
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;
            return ret;
        }
        #endregion
    }
}
