<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBasisInfoAdd.aspx.cs" Inherits="PU.web.outgiving.CustomerBasisInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                                        <asp:Label ID="lbwhatDo" runat="server"></asp:Label>
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
    <table width="700" border="0"  style=" line-height:30px" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                客户ID:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbCustomerID" runat="server"></asp:TextBox>
            </td>
            <td height="20" align="right">
                客户名称:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbCustomerName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
                客户密码:
            </td>
            <td align="left">
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </td>
            <td align="right">
                客户联系人:
            </td>
            <td align="left">
                <asp:TextBox ID="tbLinkman" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
                联系人电话:
            </td>
            <td align="left">
                <asp:TextBox ID="tbTel" runat="server"></asp:TextBox>
            </td>
            <td align="right">
                联系人Email:
            </td>
            <td align="left">
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
               联系人QQ:
            </td>
            <td align="left">
                <asp:TextBox ID="tbQQ" runat="server"></asp:TextBox>
            </td>
            <td align="right">
               频度限制:
            </td>
            <td align="left">
                <asp:TextBox ID="tbRequestLimit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
                服务截止日期:
            </td>
            <td align="left">
                <asp:TextBox ID="tbServiceEndTime" onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'});"  runat="server"></asp:TextBox>
            </td>
            <td align="right">
                同步模式:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlSyncMode" runat="server">
                    <asp:ListItem Value="1" Text="宽松"></asp:ListItem>
                    <asp:ListItem Value="0" Text="严格"></asp:ListItem>                    
                </asp:DropDownList>
                <asp:TextBox ID="tbDataUpdateTime" style=" display:none;" onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'});" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30px">
            <td colspan="5" align="center">
                <asp:Label ID="lbMsg" runat="server" Text="" ForeColor="Red" Font-Size="12px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnFinish" runat="server" Text="保存" 
                    OnClientClick="return checkInfo();"  CssClass="btn-btn01" 
                    onclick="btnFinish_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    
    //检测输入数据的合法性
    function checkInfo() {
    
        var lbMsg = document.getElementById("lbMsg");
        var tbCustomerID = document.getElementById("tbCustomerID");     
        var tbCustomerName = document.getElementById("tbCustomerName");
        var tbPassword = document.getElementById("tbPassword");
        var tbRequestLimit = document.getElementById("tbRequestLimit");
        var tbServiceEndTime = document.getElementById("tbServiceEndTime");
        var tbDataUpdateTime = document.getElementById("tbDataUpdateTime");


        if (tbCustomerID.value == "") {
            lbMsg.innerHTML = "请输入客户ID！";
            tbCustomerID.focus();
            return false;
        }

        if (tbCustomerName.value == "") {
            lbMsg.innerHTML = "请输入客户名称！";
            tbCustomerName.focus();
            return false;
        }

        if (tbPassword.value == "") {
            lbMsg.innerHTML = "请输入客户密码！";
            tbPassword.focus();
            return false;
        }

        if (tbRequestLimit.value == "") {
            lbMsg.innerHTML = "请输入频率限制！";
            tbRequestLimit.focus();
            return false;
        }

        if (tbServiceEndTime.value == "") {
            lbMsg.innerHTML = "请输入服务截止日期！";
            tbServiceEndTime.focus();
            return false;
        }

        if (tbDataUpdateTime.value == "") {
            lbMsg.innerHTML = "请输入数据更新时间！";
            tbDataUpdateTime.focus();
            return false;
        }

        return true;
    }
</script>
