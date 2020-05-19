using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using User.BLL;

namespace User.Web.select
{
    public partial class HZselectIndex : System.Web.UI.Page
    {
        #region 自定义属性

        /// <summary>
        /// 组织树javascript代码串
        /// </summary>
        public string nodeStr = "";

        /// <summary>
        /// 临时交换数据键。如果为空说明没用传过来。如果不为空则取出临时数据用以初始化页面（已选的数据），将用户选好的数据再次以本键存储以供其它程序获取
        /// </summary>
        public string tempDataKey = "";

        /// <summary>
        /// 交点ID，默认选种的节点ID
        /// </summary>
        public int focusID = -1;

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUser webUser = new WebUser();
            webUser.login();

            tempDataKey = Request.QueryString["DataKey"];
            if (tempDataKey == null) tempDataKey = "";

            if (!IsPostBack)
            {
                LoadTreeStr(); //加载树数据串
                intItSelectData(tempDataKey);//页面初始化已选数据
                ListBoxSelect.Attributes.Add("onClick", "toNotSelect()");
            }
        }   
        #endregion

        #region 页面初始化已选数据
        /// <summary>
        /// 页面初始化已选数据
        /// </summary>
        /// <param name="DataKey">临时交换数据键</param>
        protected void intItSelectData(string DataKey)
        {
            PubTool.ExchangeData exchangeData = new PubTool.ExchangeData();
           
            if (tempDataKey == "") return;
            string tempdata = exchangeData.getExchangeData(tempDataKey);
            
            if (tempdata == "#null#" || tempdata == "") return;

            string[] tempdataArr = tempdata.Split(';');
            if (tempdataArr.Length < 2)
            {
                Response.Write("临时交换数据格式有错误！(" + tempdata + ")");
                Response.End();
            }
            string[] idArr = tempdataArr[0].Split(',');
            string[] nameArr = tempdataArr[1].Split(',');

            if (idArr.Length != nameArr.Length)
            {
                Response.Write("标识ID的个数与名称个数不相同，临时交换数据格式有错误！(" + tempdata + ")");
                Response.End();
            }

            ListBoxSelect.Items.Clear();
            for (int i = 0; i < idArr.Length; i++)
            {
                ListItem a = new ListItem();
                a.Value = idArr[i];
                a.Text = nameArr[i];
                ListBoxSelect.Items.Add(a);
            }
        }
        #endregion

        #region 树数据串
        /// <summary>
        /// 树数据串
        /// </summary>
        protected void LoadTreeStr()
        {
            User.BLL.BLL_User bll_User = new User.BLL.BLL_User();
            DataTable dt = bll_User.getUserDepartTreeList();

            if (dt.Rows.Count == 0) return;

            WebUser webUserCs = new WebUser();
            focusID = webUserCs.DefaultDepart; //设置用户的默认部门的焦点

            int DepartID;
            int Fatherid;
            string DepartName;

            foreach (DataRow row in dt.Rows)
            {
                Fatherid = int.Parse(row["Fatherid"].ToString());
                DepartID = int.Parse(row["DepartID"].ToString());
                DepartName = row["DepartName"].ToString();

                nodeStr += "t.nodes[\"" + Fatherid.ToString() + "_" + DepartID.ToString() + "\"]=\"";
                nodeStr += "text:" + DepartName + ";";
                nodeStr += "data:" + "DepartID=" + DepartID.ToString() + ";";
                nodeStr += "url:HZselectShow.aspx;";
                nodeStr += "method:t.expand(id);";
                nodeStr += "\";";
            }

            nodeStr = nodeStr + "t.focus(" + focusID.ToString() + ");";
            nodeStr = nodeStr + "document.write(t.toString());";
        }
        #endregion
    }
}
