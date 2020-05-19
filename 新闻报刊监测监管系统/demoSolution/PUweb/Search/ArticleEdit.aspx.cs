using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PU.web.Search
{
    /// <summary>
    /// 报道修改
    /// </summary>
    public partial class ArticleEdit : System.Web.UI.Page
    {
        /// <summary>
        /// 文章KID
        /// </summary>
        private Int64 KID = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            webUser.login();

            User.BLL.power Power = new User.BLL.power();
            PubTool.ScriptClass scp = new PubTool.ScriptClass();

            //160	报道修改
            if (!Power.ifUserHavePower(webUser.UserGUID, 160))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            //161	报道删除
            bool delPower = Power.ifUserHavePower(webUser.UserGUID, 161);
            BtDel.Enabled = delPower;

            KID = Int64.Parse(Request.QueryString["KID"].ToString());

            if (!IsPostBack)
            {
                WriteDataToPage();
                BtDel.OnClientClick = "return confirm('您真的要删除本报道吗？');";
            }
        }

        #region 将文章信息写到页面
        /// <summary>
        /// 将文章信息写到页面
        /// </summary>
        protected void WriteDataToPage()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();

            PM.Model.MDL_ArticleInfoB ArticleJG = PaperCs.getArticleInfoBModel(KID);
            if (ArticleJG == null)
            {
                scp.AlertAndClose("该报道已被删除！");
                Response.End();
            }

            txtMC.Text = ArticleJG.MC;
            if (ArticleJG.PU == 1)
                CKBoxPU.Checked = true;
            else
                CKBoxPU.Checked = false;
            txtYT.Text = ArticleJG.YT;
            txtBT.Text = ArticleJG.BT;
            txtFB.Text = ArticleJG.FB;
            txtZZ.Text = ArticleJG.ZZ;
            txtBM.Text = ArticleJG.BM;
            txtBC.Text = ArticleJG.BC;
            txtBN.Text = ArticleJG.BN.ToString();
            txtBJ.Text = ArticleJG.BJ;
            txtLM.Text = ArticleJG.LM;
            txtFL.Text = ArticleJG.FL;
            txtDQ.Text = ArticleJG.DQ;
            txtTC.Text = ArticleJG.TC;
            txtRW.Text = ArticleJG.RW;
            txtLY.Text = ArticleJG.LY;
            txtGGCP.Text = ArticleJG.GGCP;
            txtGGLX.Text = ArticleJG.GGLX;
            txtGGFL.Text = ArticleJG.GGFL;
            txtGGSC.Text = ArticleJG.GGSC;
            txtGGZ.Text = ArticleJG.GGZ;
            txtGGMJ.Text = ArticleJG.GGMJ.ToString();
            txtZB.Text = ArticleJG.ZB;
            txtTX.Text = ArticleJG.TX;

        }
        #endregion

        #region 读取页面数据到结构
        /// <summary>
        /// 读取页面数据到结构
        /// </summary>
        protected PM.Model.MDL_ArticleInfoB readDataToModel()
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();

            PM.Model.MDL_ArticleInfoB ArticleJG = PaperCs.getArticleInfoBModel(KID);
            if (ArticleJG == null)
            {
                scp.AlertAndClose("该报道已被删除！");
                Response.End();
            }

            if (CKBoxPU.Checked)
                ArticleJG.PU = 1;
            else
                ArticleJG.PU = 0;

            ArticleJG.YT = txtYT.Text;
            ArticleJG.BT = txtBT.Text;
            ArticleJG.FB = txtFB.Text;
            ArticleJG.ZZ = txtZZ.Text;
            ArticleJG.BM = txtBM.Text;
            ArticleJG.BC = txtBC.Text;
            ArticleJG.BN = int.Parse(txtBN.Text);
            ArticleJG.BJ = txtBJ.Text;
            ArticleJG.LM = txtLM.Text;
            ArticleJG.FL = txtFL.Text;
            ArticleJG.DQ = txtDQ.Text;
            ArticleJG.TC = txtTC.Text;
            ArticleJG.RW = txtRW.Text;
            ArticleJG.LY = txtLY.Text;
            ArticleJG.GGCP = txtGGCP.Text;
            ArticleJG.GGLX = txtGGLX.Text;
            ArticleJG.GGFL = txtGGFL.Text;
            ArticleJG.GGSC = txtGGSC.Text;
            ArticleJG.GGZ = txtGGZ.Text;
            ArticleJG.GGMJ = double.Parse(txtGGMJ.Text);
            ArticleJG.ZB = txtZB.Text;
            ArticleJG.TX = txtTX.Text;

            return ArticleJG;
        }
        #endregion

        #region 删除
        protected void BtDel_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            User.BLL.WebUser webUser = new User.BLL.WebUser();
            User.BLL.power Power = new User.BLL.power();
            //161	报道删除
            if (!Power.ifUserHavePower(webUser.UserGUID, 161))
            {
                scp.AlertAndClose("对不起，您还未开通此权限！");
                Response.End();
            }

            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();
            PubTool.ReturnMsg retMsg = PaperCs.delArticleInfoB(KID);
            if (retMsg.Succeed)
            {
                scp.ClickParentPageButton("BtRef");
                scp.AlertAndClose("报道删除成功！");
            }
            else
            {
                scp.Alert("报道删除失败！" + retMsg.Msg);
            }
        }
        #endregion


        #region 保存
        protected void BtOK_Click(object sender, EventArgs e)
        {
            PubTool.ScriptClass scp = new PubTool.ScriptClass();
            PM.ClientLibrary.Paper PaperCs = new PM.ClientLibrary.Paper();

            PM.Model.MDL_ArticleInfoB model = readDataToModel();
            PubTool.ReturnMsg retMsg = PaperCs.UpdateArticleInfoB(model);

            if (retMsg.Succeed)
            {
                scp.ClickParentPageButton("BtRef");
                scp.AlertAndClose("报道修改成功！");
            }
            else
            {
                scp.Alert("报道修改失败！" + retMsg.Msg);
            }
        }
        #endregion


    }
}
