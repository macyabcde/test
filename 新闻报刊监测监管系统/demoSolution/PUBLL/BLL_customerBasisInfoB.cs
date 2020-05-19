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
    /// 客户基本信息数据处理类
    /// </summary>
    public class BLL_customerBasisInfoB
    {
        /// <summary>
        /// 客户基本信息数据处理类
        /// </summary>
        public BLL_customerBasisInfoB()
        { }

        #region 获取一个客户基本信息实体
        /// <summary>
        /// 获取一个客户基本信息实体
        /// </summary>
        /// <param name="customerID">客户基本信息ID</param>
        /// <returns>客户基本信息实体</returns>
        public PU.Model.MDL_customerBasisInfoB GetModel(string customerID)
        {
            PU.DAL.DAL_customerBasisInfoB dal_customerBasisInfoB = new DAL_customerBasisInfoB();
            return dal_customerBasisInfoB.GetModel(customerID);
        }
        #endregion

        #region 添加客户基本信息
        /// <summary>
        /// 添加客户基本信息,返回所影响的行数
        /// </summary>
        /// <param name="model">客户基本信息实体类</param>
        /// <returns>返回PubTool.ReturnMsg信息，
        ///         Succeed：是否执行成功，true成功，false失败；
        ///         state：0 客户ID已存在，不允许再添加！；1 客户信息添加成功！
        ///         Msg：提示信息
        /// </returns>
        public PubTool.ReturnMsg Add(PU.Model.MDL_customerBasisInfoB model)
        {
            PU.DAL.DAL_customerBasisInfoB dal_customerBasisInfoB = new DAL_customerBasisInfoB();
            PubTool.ReturnMsg Msg = new PubTool.ReturnMsg();

            //客户ID已存在，不允许添加
            if (dal_customerBasisInfoB.GetModel(model.customerID) != null)
            {
                Msg.Succeed = false;
                Msg.state = 0;
                Msg.Msg = "客户ID已存在，不允许再添加！";
                return Msg;
            }

            dal_customerBasisInfoB.Add(model);

            Msg.Succeed = true;
            Msg.state = 1;
            Msg.Msg = "客户信息添加成功！";
            return Msg;
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
            PU.DAL.DAL_customerBasisInfoB dal_customerBasisInfoB = new DAL_customerBasisInfoB();
            return dal_customerBasisInfoB.Update(model);
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
            PU.DAL.DAL_customerBasisInfoB dal_customerBasisInfoB = new DAL_customerBasisInfoB();
            return dal_customerBasisInfoB.Delete(customerID);
        }
        #endregion

        #region 获取客户基本信息列表(分页)
        /// <summary>
        /// 获取客户基本信息列表(分页)
        /// </summary>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass GetCustomerBasisInfoList(int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            string strSql = "select * from customerBasisInfoB order by createTime asc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(strSql, null, pageSize, goPage);
            return retModel;
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
            PU.DAL.DAL_customerBasisInfoB dal_customerBasisInfoB = new DAL_customerBasisInfoB();
            return dal_customerBasisInfoB.SetCustomerActive(customerID, active);
        }
        #endregion

        
    }
}