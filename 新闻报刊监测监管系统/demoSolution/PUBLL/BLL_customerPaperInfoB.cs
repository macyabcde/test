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
    /// 客户报纸信息数据处理类
    /// </summary>
    public class BLL_customerPaperInfoB
    {
        /// <summary>
        /// 客户报纸信息数据处理类
        /// </summary>
        public BLL_customerPaperInfoB()
        { }

        #region 获取一个客户报纸信息实体
        /// <summary>
        /// 获取一个客户报纸信息实体
        /// </summary>
        /// <param name="customerPaperID">客户报纸信息ID</param>
        /// <returns>客户报纸信息实体</returns>
        public PU.Model.MDL_customerPaperInfoB GetModel(int customerPaperID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.GetModel(customerPaperID);
        }
        #endregion

        #region 获取一个客户报纸信息实体
        /// <summary>
        /// 获取一个客户报纸信息实体
        /// </summary>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="customerID">客户信息ID</param>
        /// <returns>客户报纸信息实体</returns>
        public PU.Model.MDL_customerPaperInfoB GetModelForPaperID(int paperID, string customerID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.GetModelForPaperID(paperID, customerID);
        }
        #endregion

        #region 删除客户报纸信息
        /// <summary>
        /// 删除客户报纸信息,返回所影响的行数
        /// </summary>
        /// <param name="customerPaperID">客户报纸信息ID</param>
        /// <returns>所影响的行数</returns>
        public int Delete(int customerPaperID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.Delete(customerPaperID);
        }
        #endregion

        #region 添加客户报纸信息
        /// <summary>
        /// 添加客户报纸信息
        /// </summary>
        /// <param name="customerPaperIDArr"报纸信息ID集合</param>
        /// <param name="customerID">客户ID</param>
        /// <returns>返回PubTool.ReturnMsg,
        ///          Succeed：是否执行成功，true 成功，false 失败；
        ///          state：0 设置客户报纸信息成功；
        ///          Msg：执行情况详细信息
        /// </returns>
        public PubTool.ReturnMsg Add(string[] customerPaperIDArr, string customerID,string[] updateOverDateArr)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            PubTool.ReturnMsg Msg = new PubTool.ReturnMsg();
            List<int> customerPaperIDlist = GetCustomerPaperIDArr(customerID);
            int paperID = 0;
            string updateOverDate = "";
            for (int i = 0; i < customerPaperIDArr.Length; i++)
            {
                if (customerPaperIDArr[i] == "") continue;

                paperID = int.Parse(customerPaperIDArr[i]);
                updateOverDate = updateOverDateArr[i];

                //如果客户已有了要添加的报纸信息ID，则不添加
                if (customerPaperIDlist.Contains(paperID))
                {
                    customerPaperIDlist.Remove(paperID);
                    dal_customerPaperInfoB.EditupdateOverDate(customerID, paperID, DateTime.Parse(updateOverDate));
                }
                else
                {
                    dal_customerPaperInfoB.Add(customerID, paperID, updateOverDate);
                }
            }

            //删除取消客户的报纸信息
            foreach (int delPaperID in customerPaperIDlist)
            {
                dal_customerPaperInfoB.Delete(customerID, delPaperID);
            }

            Msg.Succeed = true;
            Msg.state = 0;
            Msg.Msg = "设置客户报纸信息成功！";
            return Msg;
        }
        #endregion

        #region 添加客户报纸信息
        /// <summary>
        /// 添加客户报纸信息,返回所影响的行数
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="updateOverDate">已更新到日期</param>
        /// <returns>返回-1，表示客户已有此报纸；大于0 添加成功！
        /// </returns>
        public int Add(string customerID, int paperID, string updateOverDate)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();

            if (dal_customerPaperInfoB.IfHavePaper(customerID, paperID)>0) return -1;

            return dal_customerPaperInfoB.Add(customerID, paperID, updateOverDate);
        }
        #endregion

        #region 获取客户报纸信息列表
        /// <summary>
        /// 获取客户报纸信息列表
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns>客户报纸信息列表</returns>
        public DataTable GetCustomerPaperList(string customerID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.GetCustomerPaperList(customerID);
        }
        #endregion

        #region 修改已更新到日期
        /// <summary>
        /// 修改已更新到日期
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <param name="updateOverDate">已更新到日期</param>
        /// <returns>所影响的行数</returns>
        public int EditupdateOverDate(string customerID, int paperID, DateTime updateOverDate)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.EditupdateOverDate(customerID, paperID, updateOverDate);
        }
        #endregion

        #region 获取已更新到日期
        /// <summary>
        /// 获取已更新到日期(返回3000-01-01 说明该客户没有该报纸)
        /// </summary>
        /// <param name="customerID">客户信息ID</param>
        /// <param name="paperID">报纸信息ID</param>
        /// <returns></returns>
        public DateTime getupdateOverDate(string customerID, int paperID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            return dal_customerPaperInfoB.getupdateOverDate(customerID, paperID);
        }
        #endregion

        

        #region 获取客户报纸信息ID集合
        /// <summary>
        /// 获取客户报纸信息ID集合
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns>客户报纸信息ID集合</returns>
        public List<int> GetCustomerPaperIDArr(string customerID)
        {
            PU.DAL.DAL_customerPaperInfoB dal_customerPaperInfoB = new DAL_customerPaperInfoB();
            DataTable dt=dal_customerPaperInfoB.GetCustomerPaperList(customerID);
            List<int> customerPaperIDList = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                customerPaperIDList.Add(int.Parse(row["paperID"].ToString()));
            }

            return customerPaperIDList;
        }
        #endregion

    }
}
