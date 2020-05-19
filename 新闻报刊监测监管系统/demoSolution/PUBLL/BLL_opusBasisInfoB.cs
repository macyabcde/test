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
    /// 品基本信息数据处理类
    /// </summary>
    public class BLL_opusBasisInfoB
    {
        /// <summary>
        /// 品基本信息数据处理类
        /// </summary>
        public BLL_opusBasisInfoB()
        { }

        #region 获取当前用户的作品基本信息ID
        /// <summary>
        /// 获取当前用户的作品基本信息ID(如果没有会自动创建)
        /// </summary>
        /// <returns></returns>
        public int getOpusBasisInfoID()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select opusBasisInfoID from opusBasisInfoB where userGUID='" + webUser.UserGUID + "'";
            DataTable dt = dataSql.ExecuteTable();
            int ret = -1;
            if (dt.Rows.Count > 0) ret = int.Parse(dt.Rows[0]["opusBasisInfoID"].ToString());

            if (ret == -1)
            {
                MDL_opusBasisInfoB model = new MDL_opusBasisInfoB();
                model.userGUID = webUser.UserGUID;
                model.ifAutoCreate = 0;
                ret = Add(model);
            }

            return ret;
        }
        #endregion


        #region 获取一个作品基本信息实体
        /// <summary>
        /// 获取一个作品基本信息实体
        /// </summary>
        /// <param name="opusBasisInfoID">作品基本信息ID</param>
        /// <returns>作品基本信息实体</returns>
        public PU.Model.MDL_opusBasisInfoB GetModel(int opusBasisInfoID)
        {
            PU.DAL.DAL_opusBasisInfoB dal_opusBasisInfoB = new DAL_opusBasisInfoB();
            return dal_opusBasisInfoB.GetModel(opusBasisInfoID);
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
            PU.DAL.DAL_opusBasisInfoB dal_opusBasisInfoB = new DAL_opusBasisInfoB();
            return dal_opusBasisInfoB.Add(model);
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
            PU.DAL.DAL_opusBasisInfoB dal_opusBasisInfoB = new DAL_opusBasisInfoB();
            return dal_opusBasisInfoB.Update(model);
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
            PU.DAL.DAL_opusBasisInfoB dal_opusBasisInfoB = new DAL_opusBasisInfoB();
            return dal_opusBasisInfoB.Delete(opusBasisInfoID);
        }
        #endregion
    }
}
