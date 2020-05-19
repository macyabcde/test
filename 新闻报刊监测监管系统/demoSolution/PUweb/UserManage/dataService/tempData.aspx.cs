using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using User.BLL;
using System.Text;

namespace User.Web.dataService
{
    /// <summary>
    /// 临时数据交换
    /// </summary>
    public partial class tempData : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            string whatDo = Request.Form["whatDo"].ToString();

            if (whatDo == "SetExchangeData") SetExchangeData();  //添加临时交换数据

            if (whatDo == "SetExchangeData_RetrunDataKey") SetExchangeData_RetrunDataKey(); //添加临时交换数据，返回DataKey

            if (whatDo == "getExchangeData") getExchangeData(); //存获取临时交换数据

            if (whatDo == "findUser") findUser(); //查找用户
        }
        #endregion

        #region 添加临时交换数据
        /// <summary>
        /// 添加临时交换数据
        /// </summary>
        protected void SetExchangeData()
        {
            PubTool.ExchangeData exchangeData = new PubTool.ExchangeData();
            string DataKey = Request.Form["DataKey"].ToString();
            string DataValue = Request.Form["DataValue"].ToString();
            exchangeData.SetExchangeData(DataValue, DataKey);
            Response.Write("T");
            Response.End();
        }
        #endregion

        #region 添加临时交换数据，返回DataKey
        /// <summary>
        /// 添加临时交换数据，返回DataKey
        /// </summary>
        protected void SetExchangeData_RetrunDataKey()
        {
            PubTool.ExchangeData exchangeData = new PubTool.ExchangeData();
            string DataValue = Request.Form["DataValue"].ToString();
            string DataKey = exchangeData.SetExchangeData(DataValue);
            Response.Write(DataKey);
            Response.End();
        }
        #endregion

        #region 存获取临时交换数据， 返回“#null#”说明没有找到该 数据键 的数据
        /// <summary>
        /// 存获取临时交换数据， 返回“#null#”说明没有找到该 数据键 的数据
        /// </summary>
        protected void getExchangeData()
        {
            PubTool.ExchangeData exchangeData = new PubTool.ExchangeData();
            string DataKey = Request.Form["DataKey"].ToString();
            string DataValue = exchangeData.getExchangeData(DataKey);
            Response.Write(DataValue);
            Response.End();
        }
        #endregion

        #region 查找用户 
        /// <summary>
        /// 查找用户
        /// </summary>
        protected void findUser()
        {
            string keyWord = Request.Form["keyWord"].ToString();
            BLL_User bllUser = new BLL_User();
            DataTable dt = bllUser.findUser(keyWord);
            int index = 0;
            StringBuilder ret = new StringBuilder();
            string str = "";
            foreach (DataRow row in dt.Rows)
            {
                // 进行数据库查询操作，返回人员信息格式字符串。格式：
                //[{UserGUID:'',UserName:'',UserID:'',DepartName:''},...]
                if (index == 0)
                {
                    ret.Append("[");
                }
                else
                {
                    ret.Append(",");
                }
                str = "{UserGUID:'" + row["UserGUID"].ToString() + "',UserName:'" + row["UserName"].ToString() + "',UserLoginName:'" + row["UserLoginName"].ToString() + "',DepartName:'" + row["DepartName"].ToString() + "'}";
                ret.Append(str);
                index++;
            }
            if (index > 0) ret.Append("]");
            if (index == 0) ret.Append("#null#");
            Response.Write(ret.ToString());
            Response.End();
        }
        #endregion

    }
}
