using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace PU.web.Command
{
    /// <summary>
    /// 处理post提交的数据
    /// </summary>
    public partial class dataPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            
            string whatDo = Request.Form["whatDo"].ToString();
            switch (whatDo)
            {
                //添加报纸收藏
                case "addPaperCollection":
                    addPaperCollection();
                    break;
                //删除报纸收藏
                case "delPaperCollection":
                    delPaperCollection();
                    break;
                //添加版面收藏信息
                case "addEditionCollection":
                    addEditionCollection();
                    break;
                //删版面收藏信息
                case "delEditionCollection":
                    delEditionCollection();
                    break;


                //添加报道收藏(多篇)
                case "addNewsCollection":
                    addNewsCollection();
                    break;               
                //添加报道推荐信息(多篇多人)
                case "addNewsRecommend":
                    addNewsRecommend();
                    break;               
                // 添加剪报报道信息(多篇)
                case "addClippingNewes":
                    addClippingNewes();
                    break;
                // 添加我的作品(多篇)
                case "addOpusNewsInfo":
                    addOpusNewsInfo();
                    break;
                
                // 获取当前用户新的作品的KID列表
                case "getUserNewOpusList":
                    getUserNewOpusList();
                    break;
                default:
                    break;
               
            }
        }

        #region 添加报纸收藏
        /// <summary>
        /// 添加报纸收藏
        /// </summary>
        protected void addPaperCollection()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //106	报纸收藏
            if (!Power.ifUserHavePower(webUser.UserGUID, 106))
            {
                Response.Write("对不起，您还未开通此权限！");
                Response.End();
            }
                       
            PU.BLL.BLL_paperCollectionInfoB paperCollectionInfoCs = new PU.BLL.BLL_paperCollectionInfoB();

            int paperID = int.Parse(Request.Form["paperID"].ToString());

            PU.Model.MDL_paperCollectionInfoB model = new PU.Model.MDL_paperCollectionInfoB();
            model.userGUID = webUser.UserGUID;
            model.paperID = paperID;

            PubTool.ReturnMsg msg = paperCollectionInfoCs.Add(model);
            Response.Write(msg.Msg + "！");
            Response.End();
        }
        #endregion

        #region 删除报纸收藏
        /// <summary>
        /// 删除报纸收藏
        /// </summary>
        protected void delPaperCollection()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_paperCollectionInfoB paperCollectionInfoCs = new PU.BLL.BLL_paperCollectionInfoB();

            int paperID = int.Parse(Request.Form["paperID"].ToString());
            paperCollectionInfoCs.Delete(paperID, webUser.UserGUID);
            Response.Write("报纸收藏删除成功！");
            Response.End();
        }
        #endregion

        #region 添加版面收藏信息
        /// <summary>
        /// 添加版面收藏信息
        /// </summary>
        protected void addEditionCollection()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //107	版面收藏
            if (!Power.ifUserHavePower(webUser.UserGUID, 107))
            {
                Response.Write("对不起，您还未开通此权限！");
                Response.End();
            }

            PU.BLL.BLL_editionCollectionInfoB editionCollectionInfoCs = new PU.BLL.BLL_editionCollectionInfoB();

            int paperID = int.Parse(Request.Form["paperID"].ToString());
            string MC = Request.Form["MC"].ToString();
            int RQ = int.Parse(Request.Form["RQ"].ToString());
            string BC = Request.Form["BC"].ToString();
            string BM = Request.Form["BM"].ToString();
            string PD = Request.Form["PD"].ToString();
            string JP = Request.Form["JP"].ToString();


            PU.Model.MDL_editionCollectionInfoB model = new PU.Model.MDL_editionCollectionInfoB();
            model.userGUID = webUser.UserGUID;
            model.paperID = paperID;
            model.MC = MC;
            model.RQ = RQ;
            model.BC = BC;
            model.BM = BM;
            model.PD = PD;
            model.JP = JP;

            PubTool.ReturnMsg msg = editionCollectionInfoCs.Add(model);
            Response.Write(msg.Msg + "！");
            Response.End();
        }
        #endregion

        #region 删版面收藏信息
        /// <summary>
        /// 删版面收藏信息
        /// </summary>
        protected void delEditionCollection()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_editionCollectionInfoB editionCollectionInfoCs = new PU.BLL.BLL_editionCollectionInfoB();

            int editionCollectionInfoID = int.Parse(Request.Form["editionCollectionInfoID"].ToString());
            editionCollectionInfoCs.Delete(editionCollectionInfoID);
            Response.Write("版面收藏删除成功！");
            Response.End();
        }
        #endregion       


        #region 添加报道收藏(多篇)
        /// <summary>
        /// 添加报道收藏(多篇)
        /// </summary>
        protected void addNewsCollection()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //108	报道收藏
            if (!Power.ifUserHavePower(webUser.UserGUID, 108))
            {
                Response.Write("-1,-1");
                Response.End();
            }
           
            PU.BLL.BLL_newsCollectionInfoB newsCollectionInfoCs = new PU.BLL.BLL_newsCollectionInfoB();

            string KIDStr = Request.Form["KIDStr"].ToString();
            int newsCollectionTypeID = int.Parse(Request.Form["newsCollectionTypeID"].ToString());

            int delsl = 0;
            int oksl = newsCollectionInfoCs.Add(KIDStr, newsCollectionTypeID, out delsl);
            Response.Write(oksl.ToString() + "," + delsl.ToString());
            Response.End();
        }
        #endregion

        #region 添加报道推荐信息(多篇多人)
        /// <summary>
        /// 添加报道推荐信息(多篇多人)
        /// </summary>
        protected void addNewsRecommend()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //109	报道推荐
            if (!Power.ifUserHavePower(webUser.UserGUID, 109))
            {
                Response.Write("-1,-1");
                Response.End();
            }

            PU.BLL.BLL_newsRecommendInfoB newsRecommendInfoCs = new PU.BLL.BLL_newsRecommendInfoB();

            string KIDStr = Request.Form["KIDStr"].ToString();           
            string objectUserGUIDs = Request.Form["objectUserGUIDs"].ToString();
            int delsl = 0;
            int oksl = newsRecommendInfoCs.Add(KIDStr, objectUserGUIDs, out delsl);

            Response.Write(oksl.ToString() + "," + delsl.ToString());
            Response.End();
        }
        #endregion       

        #region 添加剪报报道信息(多篇)
        /// <summary>
        /// 添加剪报报道信息(多篇)
        /// </summary>
        protected void addClippingNewes()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //111	剪报报道选编
            if (!Power.ifUserHavePower(webUser.UserGUID, 111))
            {
                Response.Write("-1,-1");
                Response.End();
            }
            PU.BLL.BLL_pressClippingNewsInfoB pressClippingNewsInfoCs = new PU.BLL.BLL_pressClippingNewsInfoB();

            string KIDStr = Request.Form["KIDStr"].ToString();
            int pressClippingBasisInfoID = int.Parse(Request.Form["pressClippingBasisInfoID"].ToString());  

            int delsl = 0;
            int oksl = pressClippingNewsInfoCs.addClippingNewes(KIDStr, pressClippingBasisInfoID, out delsl);
            Response.Write(oksl.ToString() + "," + delsl.ToString());
            Response.End();
        }
        #endregion

        #region 添加我的作品(多篇)
        /// <summary>
        /// 添加我的作品(多篇)
        /// </summary>
        public void addOpusNewsInfo()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //110	作品报道选编
            if (!Power.ifUserHavePower(webUser.UserGUID, 110))
            {
                Response.Write("-1,-1");
                Response.End();
            }

            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            string KIDStr = Request.Form["KIDStr"].ToString(); ;
            if (KIDStr == "")
            {
                Response.Write("0,0");
                Response.End();
            }
            int delsl = 0;
            int oksl = opusNewsInfoCs.addOpusNewsForKIDStr(KIDStr, 0, out delsl);

            Response.Write(oksl.ToString() + "," + delsl.ToString());
            Response.End();
        }
        #endregion


        #region 获取当前用户新的作品的KID列表
        /// <summary>
        /// 获取当前用户新的作品的KID列表
        /// </summary>
        public void getUserNewOpusList()
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_opusBasisInfoB pusBasisInfoCs = new PU.BLL.BLL_opusBasisInfoB();
            int opusBasisInfoID = pusBasisInfoCs.getOpusBasisInfoID();//作品基本信息ID


            PU.BLL.BLL_opusNewsInfoB opusNewsInfoCs = new PU.BLL.BLL_opusNewsInfoB();
            DataTable dt = opusNewsInfoCs.getUserNewOpusList();

            PU.Model.MDL_opusBasisInfoB opusBasisInfoModel = pusBasisInfoCs.GetModel(opusBasisInfoID);
            opusBasisInfoModel.dataUpdateTime = DateTime.Now;
            pusBasisInfoCs.Update(opusBasisInfoModel);//更新数据更新时间

            if (dt.Rows.Count == 0)
            {
                Response.Write("no");
                Response.End();
            }

            StringBuilder KID_sb = new StringBuilder();
            int index = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (index != 0) KID_sb.Append(",");
                KID_sb.Append(row["KID"].ToString());
                index++;
                if (index >= 1000) break;
            }
            PubTool.ExchangeData ExchangeDataCs = new PubTool.ExchangeData();
            string key = ExchangeDataCs.SetExchangeData(KID_sb.ToString());
            Response.Write(key);
            Response.End();

        }
        #endregion
    }
}
