using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PU.web.pressClipping
{
    /// <summary>
    /// 剪报选择
    /// </summary>
    public partial class pressClippingSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbwhatDo.Text = "剪报选择";
            Bind();
        }

        #region 绑定剪报选择
        /// <summary>
        /// 绑定剪报选择
        /// </summary>
        void Bind()
        {
            PU.BLL.BLL_pressClippingBasisInfoB pressClippingBasisInfoCs = new PU.BLL.BLL_pressClippingBasisInfoB();

            DataTable dt = pressClippingBasisInfoCs.getPressClippingList(47);
            foreach (DataRow row in dt.Rows)
            {
                rbl_type.Items.Add(new ListItem(row["pressClippingName"].ToString(), row["pressClippingBasisInfoID"].ToString()));
            }
        }
        #endregion
    }
}
