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
    /// 剪报基本信息数据处理类
    /// </summary>
    public class BLL_pressClippingBasisInfoB
    {
        /// <summary>
        /// 剪报基本信息数据处理类
        /// </summary>
        public BLL_pressClippingBasisInfoB()
        { }


        #region 获取当前用户剪报列表(分页)
        /// <summary>
        /// 获取当前用户剪报列表(分页)
        /// </summary>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass getUserPressClippingList(int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            string sql = @"select  dbo.pressClippingBasisInfoB.*, dbo.[User].userName  from dbo.pressClippingBasisInfoB LEFT OUTER JOIN
                                      dbo.[User] ON dbo.pressClippingBasisInfoB.createUserGUID = dbo.[User].userGUID 
                           where dbo.pressClippingBasisInfoB.createUserGUID='" + webUser.UserGUID + "'";
            sql += " order by createTime desc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(sql, null, pageSize, goPage);
            return retModel;
        }
        #endregion

        #region 获取剪报列表(分页)
        /// <summary>
        /// 获取剪报列表(分页)
        /// </summary>
        /// <param name="pressClippingName">剪报名称</param>
        /// <param name="state">状态。0表示全部</param>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass getPressClippingList(string pressClippingName, int state, int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            string sql = @"select  dbo.pressClippingBasisInfoB.*, dbo.[User].userName  from dbo.pressClippingBasisInfoB LEFT OUTER JOIN
                                      dbo.[User] ON dbo.pressClippingBasisInfoB.createUserGUID = dbo.[User].userGUID 
                           where 1=1";
            if (state != 0) sql += " and dbo.pressClippingBasisInfoB.state=" + state;
            if (pressClippingName != "") sql += " and dbo.pressClippingBasisInfoB.pressClippingName like '%" + pressClippingName + "%'";
            sql += " order by createTime desc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(sql, null, pageSize, goPage);
            return retModel;
        }
        #endregion


        #region 获取前当用户的剪报列表
        /// <summary>
        /// 获取前当用户的剪报列表
        /// </summary>
        /// <param name="state">状态。0：全部；47：选编、48：审批中、49：审批通过、50：文件生成、51：排版中、52：制作完成、53：销售完成</param>
        /// <returns></returns>
        public DataTable getPressClippingList(int state)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            string sql = @"select * from pressClippingBasisInfoB where createUserGUID='" + webUser.UserGUID + "' and state=" + state;
            sql += " order by pressClippingBasisInfoID desc";

            dataSql.sql = sql;
            DataTable dt = dataSql.ExecuteTable();

            return dt;
        }
        #endregion

        #region 获取一个剪报基本信息实体
        /// <summary>
        /// 获取一个剪报基本信息实体
        /// </summary>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns>剪报基本信息实体</returns>
        public PU.Model.MDL_pressClippingBasisInfoB GetModel(int pressClippingBasisInfoID)
        {
            PU.DAL.DAL_pressClippingBasisInfoB dal_pressClippingBasisInfoB = new DAL_pressClippingBasisInfoB();
            return dal_pressClippingBasisInfoB.GetModel(pressClippingBasisInfoID);
        }
        #endregion

        #region 提交审批
        /// <summary>
        /// 提交审批
        /// </summary>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns></returns>
        public PubTool.ReturnMsg tjsp(int pressClippingBasisInfoID)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            PU.Model.MDL_pressClippingBasisInfoB model = GetModel(pressClippingBasisInfoID);
            //47	选编
            if (model.state != 47)
            {
                msg.Succeed = false;
                msg.Msg = "剪报当前未处在[选编]状态，不可提交审批";
                return msg;
            }
            model.state = 48;
            Update(model);
            msg.Succeed = true;
            msg.Msg = "提交成功";
            return msg;
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
            PU.DAL.DAL_pressClippingBasisInfoB dal_pressClippingBasisInfoB = new DAL_pressClippingBasisInfoB();
            return dal_pressClippingBasisInfoB.Add(model);
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
            PU.DAL.DAL_pressClippingBasisInfoB dal_pressClippingBasisInfoB = new DAL_pressClippingBasisInfoB();
            return dal_pressClippingBasisInfoB.Update(model);
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
            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            dal_pressClippingNewsInfoB.DeleteWithPressClippingBasisInfoID(pressClippingBasisInfoID);

            PU.DAL.DAL_pressClippingBasisInfoB dal_pressClippingBasisInfoB = new DAL_pressClippingBasisInfoB();
            return dal_pressClippingBasisInfoB.Delete(pressClippingBasisInfoID);
        }
        #endregion
    }
}
