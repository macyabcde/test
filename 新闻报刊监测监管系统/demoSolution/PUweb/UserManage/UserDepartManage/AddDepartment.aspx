<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs"
    Inherits="User.Web.UserDepartManage.AddDepartment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
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
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td width="27" height="28" align="center">
                &nbsp;
            </td>
            <td width="100" height="20" align="center">
                <asp:Label ID="lbfather" runat="server" Text="上级组织路径:"></asp:Label>
            </td>
            <td width="219" height="20" align="left" colspan="3">
                <asp:Label ID="lbFarther" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="center">
                <asp:Label ID="lbdepartName" runat="server" Text="组织名称:"></asp:Label>
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbdepartName" runat="server"></asp:TextBox>
            </td>
            <td height="20" align="center">
                <asp:Label ID="lbxuhao" runat="server" Text="序号:"></asp:Label>
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbxuhao" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="center">
                简&nbsp;&nbsp;&nbsp;&nbsp;称:
            </td>
            <td align="left">
                <asp:TextBox ID="tbdepartShort" runat="server"></asp:TextBox>
            </td>
            <td align="center">
                <asp:Label ID="lbdepartPinyin" runat="server" Text="简拼:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbdepartPinyin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25px">
            <td colspan="5" align="center">
                <asp:Label ID="lbMsg" runat="server" Text="" ForeColor="Red" Font-Size="12px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnFinish" runat="server" Text="保存" OnClientClick="return checkInfo();" OnClick="btnFinish_Click" CssClass="btn-btn01" />
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
        var tbdepartName = document.getElementById("tbdepartName");
        var tbxuhao = document.getElementById("tbxuhao");

        if (tbdepartName.value == "") {
            lbMsg.innerHTML = "请输入组织名称！";
            tbdepartName.focus();
            return false;
        }

        if (tbxuhao.value == "") {
            lbMsg.innerHTML = "请输入序号！";
            tbxuhao.focus();
            return false;
        }

        return true;
    }

</script>