<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Updatepassword.aspx.cs"
    Inherits="User.Web.UserDepartManage.Updatepassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>重置密码</title>
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
                                        <asp:Label ID="lbwhatDo" runat="server" Text="重置密码"></asp:Label>
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
                登&nbsp;&nbsp;录&nbsp;名:
            </td>
            <td width="219" height="20" align="left">
                <asp:Label ID="lbUserLoginName" runat="server" Text=""></asp:Label>
            </td>
            <td width="91" height="20" align="right">
                用户姓名:
            </td>
            <td width="228" height="20" align="left">
                <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="5px">
        </tr>
        <tr>
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbpassword" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td height="20" align="right">
                <asp:Label ID="lbpassword2"  runat="server" Text="确认密码:"></asp:Label>
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbpassword2" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="20px">
            <td colspan="5" align="center">
                <asp:Label ID="lbMsg" runat="server" Text="" Font-Size="12px" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnFinish" runat="server" OnClientClick="return checkInfo();" Text="保存" OnClick="btnFinish_Click" CssClass="btn-btn01" />
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
        var tbpassword = document.getElementById("tbpassword");
        var tbpassword2 = document.getElementById("tbpassword2");
        //密码
        if (tbpassword.value == "") {
            tbpassword.focus();
            lbMsg.innerHTML = "请输入密码！";
            return false;
        }

        if (tbpassword.value != tbpassword2.value) {
            tbpassword2.focus();
            lbMsg.innerHTML = "您两次输入密码不一致，请重新输入！";
            return false;
        }
        return true;
    }
</script>
