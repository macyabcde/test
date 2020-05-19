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
    /// 报道收藏类别数据处理类
    /// </summary>
    public class BLL_newsCollectionTypeB
    {
        /// <summary>
        /// 报道收藏类别数据处理类
        /// </summary>
        public BLL_newsCollectionTypeB()
        { }

        #region 获取当前用户报道收藏类别列表(只获取第二层)
        /// <summary>
        /// 获取当前用户报道收藏类别列表(只获取第二层)
        /// </summary>
        /// <returns></returns>
        public DataTable getUserCollectionTypeList()
        { 
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            int paterNewsCollectionTypeID = getUserCollectionTypeRootID();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select *  from newsCollectionTypeB where paterNewsCollectionTypeID=" + paterNewsCollectionTypeID + " and userGUID='" + webUser.UserGUID + "' order by xuhao asc, newsCollectionTypeID asc";
            DataTable dt = dataSql.ExecuteTable();
          
            return dt;
        }
        #endregion

        #region 获取当前用户报道收藏类别根节点ID
        /// <summary>
        ///  获取当前用户报道收藏类别根节点ID
        /// </summary>
        /// <returns></returns>
        public int getUserCollectionTypeRootID()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select newsCollectionTypeID from newsCollectionTypeB  where userGUID='" + webUser.UserGUID + "' and paterNewsCollectionTypeID=0";
            DataTable dt = dataSql.ExecuteTable();
            int ret = -1;
            if (dt.Rows.Count > 0) ret = int.Parse(dt.Rows[0]["newsCollectionTypeID"].ToString());
           
            return ret;
        }
        #endregion

        #region 为当前用户自动创建报道收藏类别
        /// <summary>
        ///  为当前用户自动创建报道收藏类别
        /// </summary>
        /// <returns></returns>
        public void CreateUserCollectionType()
        {
            if (getUserCollectionTypeRootID() != -1) return;
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.Model.MDL_newsCollectionTypeB model;

            //添加根
            model = new MDL_newsCollectionTypeB();
            model.collectionTypeName = "报道收藏";
            model.userGUID = webUser.UserGUID;
            model.xuhao = 0;
            model.paterNewsCollectionTypeID = 0;
            int rootID = Add(model).aID;

            string[] nameArr = PU.Command.ConfigProvider.DefaultNewsCollectionType.Split(',');
            foreach (string name in nameArr)
            {
                model = new MDL_newsCollectionTypeB();
                model.collectionTypeName = name;
                model.userGUID = webUser.UserGUID;
                model.xuhao = 0;
                model.paterNewsCollectionTypeID = rootID;
                Add(model);
            }
        }
        #endregion



        #region 获取一个报道收藏类别实体
        /// <summary>
        /// 获取一个报道收藏类别实体
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>报道收藏类别实体</returns>
        public PU.Model.MDL_newsCollectionTypeB GetModel(int newsCollectionTypeID)
        {
            PU.DAL.DAL_newsCollectionTypeB dal_newsCollectionTypeB = new DAL_newsCollectionTypeB();
            return dal_newsCollectionTypeB.GetModel(newsCollectionTypeID);
        }
        #endregion

        #region 添加报道收藏类别
        /// <summary>
        /// 添加报道收藏类别,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">报道收藏类别实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public PubTool.ReturnMsg Add(PU.Model.MDL_newsCollectionTypeB model)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (ifHaveTypeName(0, model.paterNewsCollectionTypeID, model.collectionTypeName))
            {
                msg.Succeed = false;
                msg.Msg = "同级类别下名称为[" + model.collectionTypeName + "]已存在";
                return msg;
            }
            PU.DAL.DAL_newsCollectionTypeB dal_newsCollectionTypeB = new DAL_newsCollectionTypeB();
            int newsCollectionTypeID = dal_newsCollectionTypeB.Add(model);
            msg.Succeed = true;
            msg.aID = newsCollectionTypeID;
            return msg;
        }
        #endregion

        #region 修改报道收藏类别
        /// <summary>
        /// 修改报道收藏类别,返回所影响的行数
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public PubTool.ReturnMsg Update(PU.Model.MDL_newsCollectionTypeB model)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (ifHaveTypeName(model.newsCollectionTypeID, model.paterNewsCollectionTypeID, model.collectionTypeName))
            {
                msg.Succeed = false;
                msg.Msg = "同级类别下名称为[" + model.collectionTypeName + "]已存在";
                return msg;
            }
            PU.DAL.DAL_newsCollectionTypeB dal_newsCollectionTypeB = new DAL_newsCollectionTypeB();
            int sl = dal_newsCollectionTypeB.Update(model);
            msg.Succeed = true;
            msg.aID = sl;
            return msg;
        }
        #endregion

        #region 删除报道收藏类别
        /// <summary>
        /// 删除报道收藏类别,返回所影响的行数
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>所影响的行数</returns>
        public PubTool.ReturnMsg Delete(int newsCollectionTypeID)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            if (ifHaveSub(newsCollectionTypeID))
            {
                msg.Succeed = false;
                msg.Msg = "本类别下有子类别，不允许删除";
                return msg;
            }
            if (ifHaveArticle(newsCollectionTypeID))
            {
                msg.Succeed = false;
                msg.Msg = "本类别下有收收藏的文章，不允许删除";
                return msg;
            }

            PU.DAL.DAL_newsCollectionTypeB dal_newsCollectionTypeB = new DAL_newsCollectionTypeB();
            int sl = dal_newsCollectionTypeB.Delete(newsCollectionTypeID);
            msg.Succeed = true;
            msg.aID = sl;
            return msg;
        }
        #endregion

        #region 判断同级类别名称是否存在
        /// <summary>
        /// 判断同级类别名称是否存在
        /// </summary>
        /// <param name="newsCollectionTypeID">排除的报道收藏类别ID</param>
        /// <param name="paterNewsCollectionTypeID">父报道收藏类别ID</param>
        /// <param name="collectionTypeName">类别名称</param>
        /// <returns>true：有、false：没有</returns>
        public bool ifHaveTypeName(int newsCollectionTypeID, int paterNewsCollectionTypeID, string collectionTypeName)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select newsCollectionTypeID from newsCollectionTypeB  where newsCollectionTypeID<>" + newsCollectionTypeID + "and paterNewsCollectionTypeID=" + paterNewsCollectionTypeID + " and collectionTypeName='" + collectionTypeName + "'";
            dataSql.sql += " and userGUID='" + webUser.UserGUID + "'";
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;

            return ret;
        }
        #endregion

        #region 判断类别下是否有子类别
        /// <summary>
        /// 判断类别下是否有子类别
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>true：有、false：没有</returns>
        public bool ifHaveSub(int newsCollectionTypeID)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select newsCollectionTypeID from newsCollectionTypeB  where paterNewsCollectionTypeID=" + newsCollectionTypeID;
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;

            return ret;
        }
        #endregion

        #region 判断类别下是有文章
        /// <summary>
        /// 判断类别下是有文章
        /// </summary>
        /// <param name="newsCollectionTypeID">报道收藏类别ID</param>
        /// <returns>true：有、false：没有</returns>
        public bool ifHaveArticle(int newsCollectionTypeID)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select top 1 newsCollectionInfoID from newsCollectionInfoB  where newsCollectionTypeID=" + newsCollectionTypeID + " order by newsCollectionTypeID asc";
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;

            return ret;
        }
        #endregion
    }
}
