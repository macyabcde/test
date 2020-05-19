<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="User.Web.UserDepartManage.AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                <asp:Label ID="lbdepartName" runat="server" Text="组织路径:"></asp:Label>
            </td>
            <td height="20" align="left" colspan="3">
                <asp:Label ID="lbDepartStr" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="27" height="28" align="center">
                &nbsp;
            </td>
            <td width="100" height="20" align="right">
                登&nbsp;录&nbsp;名:
            </td>
            <td width="219" height="20" align="left">
                <asp:TextBox ID="tbuserLoginName" runat="server"></asp:TextBox>
            </td>
            <td width="91" height="20" align="right">
                <asp:Label ID="lbuserName" runat="server" Text="用户姓名:"></asp:Label>
            </td>
            <td width="228" height="20" align="left">
                <asp:TextBox ID="tbuserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="trPwd" runat="server">
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                密&nbsp;&nbsp;&nbsp;&nbsp;码:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbpassword" Width="140px" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td height="20" align="right">
                <asp:Label ID="lbpassword2" runat="server" Text="确认密码:"></asp:Label>
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbpassword2" Width="140px" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="right">
                <asp:Label ID="lbemail" runat="server" Text="邮箱地址:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
            </td>
            <td align="right">
                <asp:Label ID="lbtel" runat="server" Text="办公电话:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="tbtel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="28" align="center">
                &nbsp;
            </td>
            <td height="20" align="right">
                <asp:Label ID="lbmobile" runat="server" Text="手机号码:"></asp:Label>
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbmobile" runat="server"></asp:TextBox>
            </td>
            <td height="20" align="right">
                序&nbsp;&nbsp;&nbsp;&nbsp;号:
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbxuhao" runat="server">10</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="30" align="center">
                &nbsp;
            </td>
            <td align="right" valign="top">
                备&nbsp;&nbsp;&nbsp;&nbsp;注:
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="tbexplain" runat="server" Style="overflow: auto;" TextMode="MultiLine"
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
                <asp:Button ID="btnFinish" OnClientClick="return checkInfo();" runat="server" Text="保存" OnClick="btnFinish_Click" CssClass="btn-btn01" />
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

    //检测输入数据的合法性
    function checkInfo() {
        var lbMsg = document.getElementById("lbMsg");
        var tbuserLoginName = document.getElementById("tbuserLoginName");
        var tbuserName = document.getElementById("tbuserName");
        var tbpassword = document.getElementById("tbpassword");
        var tbpassword2 = document.getElementById("tbpassword2");
        var tbxuhao = document.getElementById("tbxuhao");
        var HDwhatDO = document.getElementById("HDwhatDO");

        //用户登录名
        if (tbuserLoginName.value == "") {
            tbuserLoginName.focus();
            lbMsg.innerHTML = "请输入登录名！";
            return false;
        }

        //用户姓名
        if (tbuserName.value == "") {
            tbuserName.focus();
            lbMsg.innerHTML = "请输入用户姓名！";
            return false;
        }

        if (HDwhatDO.value == "add") {
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
        }

        //序号
        if (tbxuhao.value == "") {
            tbxuhao.focus();
            lbMsg.innerHTML = "请输入序号！";
            return false;
        }

        return true;
    }

</script>