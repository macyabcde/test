using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using PU.Model;
using PU.DAL;
using System.Data.SqlClient;

namespace PU.BLL
{
    /// <summary>
    /// 剪报报道信息数据处理类
    /// </summary>
    public class BLL_pressClippingNewsInfoB
    {
        /// <summary>
        /// 剪报报道信息数据处理类
        /// </summary>
        public BLL_pressClippingNewsInfoB()
        { }

        #region 获取一个剪报报道信息实体
        /// <summary>
        /// 获取一个剪报报道信息实体
        /// </summary>
        /// <param name="pressClippingNewsInfoID">剪报报道信息ID</param>
        /// <returns>剪报报道信息实体</returns>
        public PU.Model.MDL_pressClippingNewsInfoB GetModel(int pressClippingNewsInfoID)
        {
            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            return dal_pressClippingNewsInfoB.GetModel(pressClippingNewsInfoID);
        }
        #endregion

        #region 获取剪报报道列表
        /// <summary>
        /// 获取剪报报道列表
        /// </summary>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns>剪报报道列表</returns>
        public DataTable GetPressClippingNewsInfoList(int pressClippingBasisInfoID)
        {
            BLL_pressClippingBasisInfoB ressClippingBasisInfoCs = new BLL_pressClippingBasisInfoB();
            int exportOrder = ressClippingBasisInfoCs.GetModel(pressClippingBasisInfoID).exportOrder;
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            string strSql = "select * from pressClippingNewsInfoB where pressClippingBasisInfoID=@pressClippingBasisInfoID";
            switch (exportOrder)
            {
                case 59:
                    strSql += " order by RQ asc,MC asc";
                    break;
                case 60:
                    strSql += " order by RQ desc,MC asc";
                    break;
                case 61:
                    strSql += " order by MC asc,RQ asc";
                    break;
                default:
                    break;
            }
            SqlParameter[] paras = { dataSql.MakeInParam("@pressClippingBasisInfoID", SqlDbType.Int, 0, pressClippingBasisInfoID) };
            dataSql.sql = strSql;
            return dataSql.ExecuteTable(paras);
        }
        #endregion


        #region 添加剪报报道信息
        /// <summary>
        /// 添加剪报报道信息
        /// </summary>
        /// <param name="KID">文章KID</param>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns></returns>
        public PubTool.ReturnMsg Add(Int64 KID, int pressClippingBasisInfoID)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            User.BLL.WebUser webUser = new User.BLL.WebUser();

            if (ifHave(KID, pressClippingBasisInfoID))
            {
                msg.Succeed = false;
                msg.Msg = "您选择的剪报已拥有该报道信息";
                return msg;
            }

            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();
            PM.Model.MDL_ArticleInfoB ArticleInfoModel = paperCs.getArticleInfoBModel(KID);
            PU.Model.MDL_pressClippingNewsInfoB model = new MDL_pressClippingNewsInfoB();
            model.KID = KID;
            model.pressClippingBasisInfoID = pressClippingBasisInfoID;
            model.paperID = ArticleInfoModel.paperID;
            model.BT = ArticleInfoModel.BT;
            model.ZZ = ArticleInfoModel.ZZ;
            model.MC = ArticleInfoModel.MC;
            model.RQ = ArticleInfoModel.RQ;
            model.BC = ArticleInfoModel.BC;
            model.BM = ArticleInfoModel.BM;
            model.PD = ArticleInfoModel.PD;
            model.JP = ArticleInfoModel.JP;


            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            msg.aID = dal_pressClippingNewsInfoB.Add(model);
            msg.Succeed = true;
            msg.Msg = "剪报推送成功";
            return msg;
        }
        #endregion

        #region 添加剪报报道信息
        /// <summary>
        /// 添加剪报报道信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">剪报报道信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_pressClippingNewsInfoB model)
        {
            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            return dal_pressClippingNewsInfoB.Add(model);
        }
        #endregion

        #region 修改剪报报道信息
        /// <summary>
        /// 修改剪报报道信息,返回所影响的行数
        /// </summary>
        /// <param name="model">剪报报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_pressClippingNewsInfoB model)
        {
            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            return dal_pressClippingNewsInfoB.Update(model);
        }
        #endregion

        #region 删除剪报报道信息
        /// <summary>
        /// 删除剪报报道信息,返回所影响的行数
        /// </summary>
        /// <param name="pressClippingNewsInfoID">剪报报道信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int pressClippingNewsInfoID)
        {
            PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
            return dal_pressClippingNewsInfoB.Delete(pressClippingNewsInfoID);
        }
        #endregion

        #region 添加剪报报道信息
        /// <summary>
        /// 添加剪报报道信息
        /// </summary>
        /// <param name="KIDStr">文章KID串。多个以“,”隔开</param>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <param name="delsl">被删除的数量</param>
        /// <returns></returns>
        public int addClippingNewes(string KIDStr, int pressClippingBasisInfoID, out int delsl)
        {
            BLL_pressClippingNewsInfoB bll_pressClippingNewsInfoB = new BLL_pressClippingNewsInfoB();
           
            PM.ClientLibrary.Paper paperCs = new PM.ClientLibrary.Paper();
            DataTable dt = paperCs.getDataWithKID(KIDStr, "KID,paperID,BT,ZZ,MC,RQ,BC,BM,PD,JP");

            int oksl = 0;
            delsl = KIDStr.Split(',').Length - dt.Rows.Count;

            Int64 KID = 0;
            foreach (DataRow row in dt.Rows)
            {
                KID = Int64.Parse(row["KID"].ToString());
                if (bll_pressClippingNewsInfoB.ifHave(KID, pressClippingBasisInfoID)) continue;
                PU.Model.MDL_pressClippingNewsInfoB model = new MDL_pressClippingNewsInfoB();
                model.KID = KID;
                model.pressClippingBasisInfoID = pressClippingBasisInfoID;
                model.paperID = int.Parse(row["paperID"].ToString());
                model.BT = row["BT"].ToString();
                model.ZZ = row["ZZ"].ToString();
                model.MC = row["MC"].ToString();
                model.RQ = int.Parse(row["RQ"].ToString());
                model.BC = row["BC"].ToString();
                model.BM = row["BM"].ToString();
                model.PD = row["PD"].ToString();
                model.JP = row["JP"].ToString();

                PU.DAL.DAL_pressClippingNewsInfoB dal_pressClippingNewsInfoB = new DAL_pressClippingNewsInfoB();
                dal_pressClippingNewsInfoB.Add(model);
                oksl++;
            }
            return oksl;
        }
        #endregion

        #region 判断文章是否已在剪报中
        /// <summary>
        /// 判断文章是否已在剪报中
        /// </summary>
        /// <param name="KID">文章KID</param>
        /// <param name="pressClippingBasisInfoID">剪报基本信息ID</param>
        /// <returns>true：已存在、false：未存在</returns>	
        private bool ifHave(Int64 KID, int pressClippingBasisInfoID)
        {
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select pressClippingNewsInfoID from pressClippingNewsInfoB where pressClippingBasisInfoID=" + pressClippingBasisInfoID + " and KID=" + KID;
            DataTable dt = dataSql.ExecuteTable();
            bool ret = false;
            if (dt.Rows.Count > 0) ret = true;
            return ret;
        }
        #endregion
    }
}
