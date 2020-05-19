using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.MyInformation
{
    public partial class newsCollectionTypeAdd : System.Web.UI.Page
    {
        /// <summary>
        /// 做什么
        /// </summary>
        private string whatDo = "";
        /// <summary>
        /// 报道收藏类别ID
        /// </summary>
        private int newsCollectionTypeID = 0;

        /// <summary>
        /// 124	添加报道收藏类别
        /// </summary>
        private bool addTypePower = false;
        /// <summary>
        /// 125	修改报道收藏类别
        /// </summary>
        private bool editTypePower = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.power Power = new User.BLL.power();
            
            //124	添加报道收藏类别
            addTypePower = Power.ifUserHavePower(webUser.UserGUID, 124);
            //125	修改报道收藏类别
            editTypePower = Power.ifUserHavePower(webUser.UserGUID, 125);

            if (!addTypePower && !editTypePower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }
            

            whatDo = Request.QueryString["whatDo"].ToString();
            if (whatDo == "update" || whatDo == "select") newsCollectionTypeID = int.Parse(Request.QueryString["newsCollectionTypeID"].ToString());
            if (!IsPostBack)
            {
                inItPage();
            }
        }

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        protected void inItPage()
        {

            if (whatDo == "add")
            {
                inItAdd();
            }
            else if (whatDo == "update")
            {
                inItUpdate();
            }
            else if (whatDo == "select")
            {
                inItSelect();
            }

        }
        #endregion

        #region 为添初始化
        /// <summary>
        /// 为添初始化
        /// </summary>
        protected void inItAdd()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!addTypePower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "添加类别";
            lbwhatDo.Text = "添加类别";
        }
        #endregion

        #region 为修改始化
        /// <summary>
        /// 为修改始化
        /// </summary>
        protected void inItUpdate()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            if (!editTypePower)
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            Title = "修改类别";
            lbwhatDo.Text = "修改类别";
            WriteDataToPage();
        }
        #endregion

        #region 为查看始化
        /// <summary>
        /// 为查看始化
        /// </summary>
        protected void inItSelect()
        {
            Title = "查看类别";
            lbwhatDo.Text = "查看类别";
            btnFinish.Visible = false;
            WriteDataToPage();
        }
        #endregion

        #region 将数据写到页面
        /// <summary>
        /// 将数据写到页面
        /// </summary>
        public void WriteDataToPage()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();

            PU.Model.MDL_newsCollectionTypeB model = newsCollectionTypeCs.GetModel(newsCollectionTypeID);
            if (model.userGUID != webUser.UserGUID)
            {
                scp.AlertAndClose("非法访问");
                Response.End();
            }
            tbcollectionTypeName.Text = model.collectionTypeName;
            tbxuhao.Text = model.xuhao.ToString();
        }
        #endregion

        #region 获取页面数据
        /// <summary>
        /// 获取页面数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>完成修改后的实体</returns>
        public PU.Model.MDL_newsCollectionTypeB GetModel(PU.Model.MDL_newsCollectionTypeB model)
        {
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            model.newsCollectionTypeID = newsCollectionTypeID;
            model.userGUID = webUser.UserGUID;
            model.collectionTypeName = tbcollectionTypeName.Text;
            model.xuhao = int.Parse(tbxuhao.Text);
            model.paterNewsCollectionTypeID = newsCollectionTypeCs.getUserCollectionTypeRootID();
            return model;
        }
        #endregion

        #region 保存按钮点击事件
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            PubTool.ReturnMsg msg = new PubTool.ReturnMsg();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PU.BLL.BLL_newsCollectionTypeB newsCollectionTypeCs = new PU.BLL.BLL_newsCollectionTypeB();
            PU.Model.MDL_newsCollectionTypeB model = new PU.Model.MDL_newsCollectionTypeB();

            if (whatDo == "add")
            {               
                if (!addTypePower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }
                model = GetModel(model);
                msg = newsCollectionTypeCs.Add(model);
                if (msg.Succeed)
                {
                    //scp.ClickParentPageButton("BtRef");
                    scp.RefreshParentPage("newsCollectionTypeID=" + msg.aID);
                    scp.AlertAndClose("类别添加成功!");
                }
                else
                {
                    scp.Alert(msg.Msg);
                }

            }
            //执行修改操作
            else if (whatDo == "update")
            {
                if (!editTypePower)
                {
                    scp.AlertAndClose("对不起，您还未开通此权限！");
                    Response.End();
                }

                model = GetModel(model);
                msg = newsCollectionTypeCs.Update(model);
                if (msg.Succeed)
                {
                    scp.ClickParentPageButton("BtRef");
                    scp.AlertAndClose("类别修改成功!");
                }
                else
                {
                    scp.Alert(msg.Msg);
                }

            }
        }
        #endregion
    }
}
