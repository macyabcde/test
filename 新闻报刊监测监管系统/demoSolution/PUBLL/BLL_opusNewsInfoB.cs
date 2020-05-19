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
    /// 作品报道信息数据处理类
    /// </summary>
    public class BLL_opusNewsInfoB
    {
        /// <summary>
        /// 作品报道信息数据处理类
        /// </summary>
        public BLL_opusNewsInfoB()
        { }

        #region 获取当前用户作品列表(分页)
        /// <summary>
        /// 获取当前用户作品列表(分页)
        /// </summary>
        /// <param name="ConfirmState">确认状态</param>
        /// <param name="pageSize">每页面行数</param>
        /// <param name="goPage">要跳转到的页码</param>
        /// <returns>分页信息返回数据结构</returns>
        public PubTool.DB.PageRetClass getUserOpusNewsList(int ConfirmState, int pageSize, int goPage)
        {
            PubTool.DB.PageClass PageCs = new PubTool.DB.PageClass(PU.Command.ConfigProvider.PUDBconn);
            BLL_opusBasisInfoB opusBasisInfoBCs = new BLL_opusBasisInfoB();

            int opusBasisInfoID = opusBasisInfoBCs.getOpusBasisInfoID();
            string sql = "select * from opusNewsInfoB where opusBasisInfoID=" + opusBasisInfoID + " and ConfirmState=" + ConfirmState;
            sql += " order by RQ desc, opusNewsInfoID desc";
            PubTool.DB.PageRetClass retModel = PageCs.getPageDataForBase(sql, null, pageSize, goPage);
            return retModel;
        }
        #endregion

        #region 设置当前用户作品的确认状态
        /// <summary>
        /// 设置当前用户作品的确认状态
        /// </summary>
        /// <param name="ConfirmState">确认状态。0：已确认、1：未确认</param>
        /// <param name="opusNewsInfoIDStr">作品报道信息ID。多个间以“,”隔开</param>
        public void setConfirmState(int ConfirmState, string opusNewsInfoIDStr)
        {
            if (opusNewsInfoIDStr == "") return;
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            BLL_opusBasisInfoB opusBasisInfoBCs = new BLL_opusBasisInfoB();

            int opusBasisInfoID = opusBasisInfoBCs.getOpusBasisInfoID();
            string sql = "update opusNewsInfoB set ConfirmState=" + ConfirmState + " where opusBasisInfoID=" + opusBasisInfoID + " and opusNewsInfoID in(" + opusNewsInfoIDStr + ")";
            dataSql.sql = sql;
            dataSql.ExecuteNonQuery();
        }
        #endregion


        #region 获取当前用户新的作品的KID列表
        /// <summary>
        /// 获取当前用户新的作品的KID列表
        /// </summary>
        public DataTable getUserNewOpusList()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            BLL_opusBasisInfoB pusBasisInfoCs = new BLL_opusBasisInfoB();
            BLL_aliasInfoB aliasInfoCs = new BLL_aliasInfoB();
            DataTable dt = new DataTable();
            int opusBasisInfoID = pusBasisInfoCs.getOpusBasisInfoID();//作品基本信息ID


            PU.Model.MDL_opusBasisInfoB opusBasisInfoModel = pusBasisInfoCs.GetModel(opusBasisInfoID);
            //if (opusBasisInfoModel.dataUpdateTime > DateTime.Now.AddMinutes(-1)) return dt;

            //opusBasisInfoModel.dataUpdateTime = DateTime.Now;
            //pusBasisInfoCs.Update(opusBasisInfoModel);//更新数据更新时间

            string keyWord = webUser.UserName;
            DataTable dt_alias = aliasInfoCs.getUserAliasInfoList();
            foreach (DataRow row in dt_alias.Rows)
            {
                if (keyWord != "") keyWord += ",";
                keyWord += row["aliasInfo"].ToString();
            }
            if (keyWord == "") return dt;

            PM.ClientLibrary.Search SearchCs = new PM.ClientLibrary.Search();
            PubTool.DB.PageRetClass PageRetModel = SearchCs.FullSearch("", 18000101, 22001231, "KID", 201, keyWord, "or", "", 10000000, 1);
            if (PageRetModel.retTable.Rows.Count == 0) return dt;
            dt = PageRetModel.retTable;
            Dictionary<Int64, byte> dic = getUserNewsCollectionList();
            if (dic.Count == 0) return dt;

            List<DataRow> delList = new List<DataRow>();
            Int64 KID = 0;
            foreach (DataRow row in dt.Rows)
            {
                KID = Int64.Parse(row["KID"].ToString());
                if (dic.ContainsKey(KID)) delList.Add(row);
            }
            foreach (DataRow row in delList)
            {
                dt.Rows.Remove(row);
            }

            return dt;
        }
        #endregion

        #region 获取当前用户已有的作品KID字典
        /// <summary>
        /// 获取当前用户已有的作品KID字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<Int64, byte> getUserNewsCollectionList()
        {
            Dictionary<Int64, byte> dic = new Dictionary<long, byte>();
            BLL_opusBasisInfoB opusBasisInfoBCs = new BLL_opusBasisInfoB();
            int opusBasisInfoID = opusBasisInfoBCs.getOpusBasisInfoID();
            PubTool.DB.databaseSql dataSql = new PubTool.DB.databaseSql(PU.Command.ConfigProvider.PUDBconn, true);
            dataSql.sql = "select KID from opusNewsInfoB where opusBasisInfoID=" + opusBasisInfoID;
            DataTable dt = dataSql.ExecuteTable();
            Int64 KID = 0;
            foreach (DataRow row in dt.Rows)
            {
                KID = Int64.Parse(row["KID"].ToString());
                if (!dic.ContainsKey(KID)) dic.Add(KID, 0);
            }
            return dic;
        }
        #endregion


        #region 将KID串文章加入当前用户的作品报道信息表中
        /// <summary>
        /// 将KID串文章加入当前用户的作品报道信息表中
        /// </summary>
        /// <param name="KIDStr">文章KID串。多个以“,”隔开</param>
        /// <param name="ConfirmState">确认状态。0：已确认、1：未确认</param>
        /// <param name="delsl">被删除的数量</param>
        /// <returns>返回成功数量，不成功的说明文章已在我的作品中</returns>
        public int addOpusNewsForKIDStr(string KIDStr, int ConfirmState, out int delsl)
        {
            delsl = 0;
            if (KIDStr == "") return 0;
            BLL_opusBasisInfoB pusBasisInfoCs = new BLL_opusBasisInfoB();
            int opusBasisInfoID = pusBasisInfoCs.getOpusBasisInfoID();//作品基本信息ID

            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();
            DataTable dt = PaperCs.getDataWithKID(KIDStr, "KID,paperID,BT,ZZ,MC,RQ,BC,BM,PD,JP");
            Dictionary<Int64, byte> dic = getUserNewsCollectionList();
            Int64 KID = 0;
            int oksl = 0;
            delsl = KIDStr.Split(',').Length - dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                KID = Int64.Parse(row["KID"].ToString());
                if (dic.ContainsKey(KID)) continue;
                PU.Model.MDL_opusNewsInfoB model = new MDL_opusNewsInfoB();
                model.opusBasisInfoID = opusBasisInfoID;
                model.ConfirmState = ConfirmState;
                model.paperID = int.Parse(row["paperID"].ToString());
                model.KID = KID;
                model.BT = row["BT"].ToString();
                model.ZZ = row["ZZ"].ToString();
                model.MC = row["MC"].ToString();
                model.RQ = int.Parse(row["RQ"].ToString());
                model.BC = row["BC"].ToString();
                model.BM = row["BM"].ToString();
                model.PD = row["PD"].ToString();
                model.JP = row["JP"].ToString();
                Add(model);
                oksl++;
            }
            return oksl;
        }
        #endregion

        #region 获取一个作品报道信息实体
        /// <summary>
        /// 获取一个作品报道信息实体
        /// </summary>
        /// <param name="opusNewsInfoID">作品报道信息ID</param>
        /// <returns>作品报道信息实体</returns>
        public PU.Model.MDL_opusNewsInfoB GetModel(int opusNewsInfoID)
        {
            PU.DAL.DAL_opusNewsInfoB dal_opusNewsInfoB = new DAL_opusNewsInfoB();
            return dal_opusNewsInfoB.GetModel(opusNewsInfoID);
        }
        #endregion

        #region 添加作品报道信息
        /// <summary>
        /// 添加作品报道信息,返回当前添加信息的ID
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>当前添加信息的ID</returns>
        public int Add(PU.Model.MDL_opusNewsInfoB model)
        {
            PU.DAL.DAL_opusNewsInfoB dal_opusNewsInfoB = new DAL_opusNewsInfoB();
            return dal_opusNewsInfoB.Add(model);
        }
        #endregion

        #region 修改作品报道信息
        /// <summary>
        /// 修改作品报道信息,返回所影响的行数
        /// </summary>
        /// <param name="model">作品报道信息实体类</param>
        /// <returns>所影响的行数</returns>
        public int Update(PU.Model.MDL_opusNewsInfoB model)
        {
            PU.DAL.DAL_opusNewsInfoB dal_opusNewsInfoB = new DAL_opusNewsInfoB();
            return dal_opusNewsInfoB.Update(model);
        }
        #endregion

        #region 删除作品报道信息
        /// <summary>
        /// 删除作品报道信息,返回所影响的行数
        /// </summary>
        /// <param name="opusNewsInfoID">作品报道信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int opusNewsInfoID)
        {
            PU.DAL.DAL_opusNewsInfoB dal_opusNewsInfoB = new DAL_opusNewsInfoB();
            return dal_opusNewsInfoB.Delete(opusNewsInfoID);
        }
        #endregion
    }
}
