<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="andInput.aspx.cs" Inherits="PU.web.Search.andInput" %>

<%@ Register src="../UserControl/head.ascx" tagname="head" tagprefix="uc1" %>
<%@ Register src="../UserControl/left.ascx" tagname="left" tagprefix="uc2" %>
<%@ Register src="../UserControl/footer.ascx" tagname="footer" tagprefix="uc3" %>

<%@ Register src="PaperSelect.ascx" tagname="PaperSelect" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>而且检索</title>
     <link href="../css/style.css" type="text/css" rel="stylesheet"/>
 <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <script src="../js/jquery.js" type="text/javascript"></script>
     <script src="../js/PubJSLibrary.js" type="text/javascript"></script>


     <script language="javascript" type="text/javascript">
         //提交检索
         function search() {
             var paperIDStr = "";
             var KeyWordCondition = "and";
             var searchRetOrder = $("#DPListsearchRetOrder").val();

             var KeyWord = $("#txtKeyWord").val();
             var notInKeyWord = $("#txtnotInKeyWord").val();
             var startDate = $("#txtstartDate").val();
             var endDate = $("#txtendDate").val();
             if (startDate == "") startDate = "1900-01-01";
             if (endDate == "") endDate = "2200-12-31";

             if (KeyWord == "") {
                 if (searchRetOrder == 203 || searchRetOrder == 204) {
                     alert("您没有输入关键词，排序方式只能选择按出版日期排序！");
                     return;
                 }
                 if (notInKeyWord != "") {
                     alert("在您没有输入关键词情况下，不包含的关键词也应该为空！");
                     return;
                 }
             }
             
             paperIDStr = getSelectPaperIDStr();
             if (paperIDStr == "") {
                 alert("请选择要检索的报纸！");
                 return;
             }
             var DataValue = "";
             DataValue += "<paperIDStr>" + paperIDStr + "</paperIDStr>";
             DataValue += "<KeyWord>" + KeyWord + "</KeyWord>";
             DataValue += "<KeyWordCondition>" + KeyWordCondition + "</KeyWordCondition>";
             DataValue += "<notInKeyWord>" + notInKeyWord + "</notInKeyWord>";
             
             DataValue += "<searchRetOrder>" + searchRetOrder + "</searchRetOrder>";
             DataValue += "<startDate>" + startDate + "</startDate>";
             DataValue += "<endDate>" + endDate + "</endDate>";

             var Key = SetExchangeData(DataValue);

             document.location = "searchRetList.aspx?Key=" + Key;
         }

     </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:head ID="head2" runat="server" />
    
    <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="212" align="center" valign="top" background="images/leftdi.jpg">
        <uc2:left ID="left2" runat="server" />
      </td>
	<td width="1" align="center" valign="top" bgcolor="#FFFFFF"></td>
    <td width="5" bgcolor="#5F87BC"></td>
    <td valign="top">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="1" bgcolor="#FFFFFF"></td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="31" background="../images/middle_di_01.jpg"><table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
          <tr>
            <td align="left" class="mo_title_l4"><table width="200" border="0" cellspacing="1" cellpadding="0">
                <tr>
                  <td width="21"><span class="mo_title_l21"><img src="../images/tubiao100.gif" width="15" height="15" /></span></td>
                  <td width="176"><span class="mo_title_l31">而且检索</span></td>
                </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
    </table>	<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="1" bgcolor="#CCCCCC"></td>
      </tr>
    </table>
    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="25"></td>
      </tr>
    </table>
   
    
   
    
    
    
    
    
<table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td>
            <table align="center" width="330" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right" height="30">
                                            关键词：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtKeyWord" runat="server" Width="219px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            不包含：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtnotInKeyWord" runat="server" Width="219px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            时间段：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtstartDate" onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'});"
                                                runat="server" Width="93px">2011-03-15</asp:TextBox>
                                            到
                                            <asp:TextBox ID="txtendDate" onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'});"
                                                runat="server" Width="93px">2011-06-28</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            排序方式：
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DPListsearchRetOrder" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: center; width: 100%; margin-top: 10px;">
                                    <asp:Button ID="BtSearch" runat="server" Text="检 索" CssClass="btn-btn01" OnClientClick="search();return false;" /></div>
                
                </td>
          </tr>
        </table>        
        
    
       
    
        <uc4:PaperSelect ID="PaperSelect1" runat="server" />
        
    
       
    
    </td>
  </tr>
</table>

        <uc3:footer ID="footer2" runat="server" />
        
    </div>
    </form>
</body>
</html>

