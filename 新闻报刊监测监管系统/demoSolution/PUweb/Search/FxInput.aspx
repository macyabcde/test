<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FxInput.aspx.cs" Inherits="PU.web.Search.FxInput" %>

<%@ Register src="../UserControl/head.ascx" tagname="head" tagprefix="uc1" %>
<%@ Register src="../UserControl/left.ascx" tagname="left" tagprefix="uc2" %>
<%@ Register src="../UserControl/footer.ascx" tagname="footer" tagprefix="uc3" %>

<%@ Register src="PaperSelect.ascx" tagname="PaperSelect" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>分项检索</title>
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
             var startDate = $("#txtstartDate").val();
             var endDate = $("#txtendDate").val();
             if (startDate == "") startDate = "1900-01-01";
             if (endDate == "") endDate = "2200-12-31";
             var YT =getKeyWord($("#txtYT").val());
             var BT = getKeyWord($("#txtBT").val());
             var FB = getKeyWord($("#txtFB").val());
             var ZZ = getKeyWord($("#txtZZ").val());
             var LM = getKeyWord($("#txtLM").val());
             var TX = getKeyWord($("#txtTX").val());
             var GGZ = getKeyWord($("#txtGGZ").val());
             var GGCP = getKeyWord($("#txtGGCP").val());
             
             paperIDStr = getSelectPaperIDStr();
             if (paperIDStr == "") {
                 alert("请选择要检索的报纸！");
                 return;
             }

             var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
             xml += "<root>";
             xml += "<fields>";
             if (YT != "") xml += "<YT KeyWordCondition=\"" + KeyWordCondition + "\">" + YT + "</YT>";
             if (BT != "") xml += "<BT KeyWordCondition=\"" + KeyWordCondition + "\">" + BT + "</BT>";
             if (FB != "") xml += "<FB KeyWordCondition=\"" + KeyWordCondition + "\">" + FB + "</FB>";
             if (ZZ != "") xml += "<ZZ KeyWordCondition=\"" + KeyWordCondition + "\">" + ZZ + "</ZZ>";
             if (LM != "") xml += "<LM KeyWordCondition=\"" + KeyWordCondition + "\">" + LM + "</LM>";
             if (TX != "") xml += "<TX KeyWordCondition=\"" + KeyWordCondition + "\">" + TX + "</TX>";
             if (GGZ != "") xml += "<GGZ KeyWordCondition=\"" + KeyWordCondition + "\">" + GGZ + "</GGZ>";
             if (GGCP != "") xml += "<GGCP KeyWordCondition=\"" + KeyWordCondition + "\">" + GGCP + "</GGCP>";
             
             xml += "</fields>";
             xml += "</root>";


             var DataValue = "";
             DataValue += "<paperIDStr>" + paperIDStr + "</paperIDStr>";                     
             DataValue += "<searchRetOrder>" + searchRetOrder + "</searchRetOrder>";
             DataValue += "<startDate>" + startDate + "</startDate>";
             DataValue += "<endDate>" + endDate + "</endDate>";
             DataValue += "<xml>" + xml + "</xml>";
                        
             var Key = SetExchangeData(DataValue);

             document.location = "searchRetList.aspx?Key=" + Key;
         }

      
        //处理关键词(把空格换成“,”)
         function getKeyWord(KeyWord) {
             if (KeyWord == "") return "";
             KeyWord = KeyWord.replace("　", " ");
             var arr = KeyWord.split(" ");
             var ret = "";
             var temp = "";
             for (var i = 0; i < arr.length; i++) {
                 temp = arr[i];
                 if (temp != "") {
                     if (ret != "") ret += ",";
                     ret += temp;
                 }
             }
             return ret;
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
                  <td width="176"><span class="mo_title_l31">分项检索</span></td>
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
                                            引题：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtYT" runat="server" Width="219px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            标题：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBT" runat="server" Width="219px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            副题：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFB" runat="server" Width="219px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            作者：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtZZ" runat="server" Width="219px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            栏目：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLM" runat="server" Width="219px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            正文：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTX" runat="server" Width="219px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            广告主：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGGZ" runat="server" Width="219px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30">
                                            广告产品：</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGGCP" runat="server" Width="219px"></asp:TextBox></td>
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

