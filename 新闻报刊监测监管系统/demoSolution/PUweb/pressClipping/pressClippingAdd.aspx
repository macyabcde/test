<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pressClippingAdd.aspx.cs" Inherits="PU.web.pressClipping.pressClippingAdd" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>剪报基本信息</title>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="31" background="../images/middle_di_01.jpg">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td align="left" class="mo_title_l41">
                            <table width="200" border="0" cellspacing="1" cellpadding="0">
                                <tr>
                                    <td width="21">
                                        <span class="mo_title_l211">
                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                    </td>
                                    <td width="176">
                                        <asp:Label ID="lbwhatDo" Text="剪报基本信息" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#CCCCCC">
            </td>
        </tr>
    </table>
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td width="27" height="28" align="center">
                &nbsp;
            </td>
            <td width="100" height="20" align="right">
                 剪报名称:
            </td>
            <td width="219" height="20" align="left">
                <asp:TextBox ID="tbPressClippingName" runat="server"></asp:TextBox>
            </td>
            <td width="91" height="20" align="right">
                客&nbsp;&nbsp;&nbsp;&nbsp;户:
            </td>
            <td width="228" height="20" align="left">
                <asp:TextBox ID="tbcustomer" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="trPwd" runat="server">
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                销售人员:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbSalesman" Width="140px"  runat="server"></asp:TextBox>
            </td>
            <td height="20" align="right">
                输出排序:
            </td>
            <td height="20" align="left">
                <asp:DropDownList ID="ddlExportOrder" Width="145px" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trState" runat="server">
            <td height="30" align="center">
                &nbsp;
            </td>
            <td align="right">
                状&nbsp;&nbsp;&nbsp;&nbsp;态:
            </td>
            <td align="left">
                 <asp:DropDownList ID="ddlState" Width="145px" runat="server">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="lbpressClippingBasisInfoID" runat="server" Text="剪报信息ID:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbpressClippingBasisInfoID" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="30" align="center">
                &nbsp;
            </td>
            <td align="right" valign="top">
                描&nbsp;&nbsp;&nbsp;&nbsp;述:
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="tbRemark" runat="server" Style="overflow: auto;" TextMode="MultiLine"
                    Width="465px" Height="111px"></asp:TextBox>
            </td>
        </tr>
        <tr id="trSP" runat="server">
            <td height="30" align="center">
                &nbsp;
            </td>
            <td align="right" valign="top">
                审批意见:
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="tbExamineNotion" runat="server" Style="overflow: auto;" TextMode="MultiLine"
                    Width="465px" Height="111px"></asp:TextBox>
            </td>
        </tr>
        <tr id="trMsg" runat="server">
            <td colspan="5" height="30px" align="center">
                <asp:Label ID="lbMsg" runat="server" Font-Size="12px" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnSPTG" runat="server" CssClass="btn-btn01" Text="审批通过" 
                    onclick="btnSPTG_Click" />&nbsp;
                <asp:Button ID="btnJXXB" runat="server" CssClass="btn-btn01" Text="继续选编" 
                    onclick="btnJXXB_Click" />&nbsp;
                <asp:Button ID="btnFinish" OnClientClick="return checkInfo();" runat="server"   Text="保存"  CssClass="btn-btn01" onclick="btnFinish_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HDwhatDO" runat="server" />
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    
    //检查输入数据的合法性
    function checkInfo() {
        var lbMsg = document.getElementById("lbMsg");
        var tbPressClippingName = document.getElementById("tbPressClippingName");
        var tbcustomer = document.getElementById("tbcustomer");

        if (tbPressClippingName.value == "") {
            lbMsg.innerHTML = "请输入剪报名称！";
            tbPressClippingName.focus();
            return false;
        }

        if (tbcustomer.value == "") {
            lbMsg.innerHTML = "请输入客户！";
            tbcustomer.focus();
            return false;
        }
        
        lbMsg.innerHTML = "";
        return true;
    }
</script>