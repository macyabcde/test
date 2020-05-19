<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPwdEdit.aspx.cs" Inherits="User.Web.UserPwdEdit" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>密码修改</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/tabStyle.css" rel="stylesheet" type="text/css" />
      <base  target="_self"></base>
</head>
<body bgcolor="#fcfefd">
    <form id="form2" runat="server">
    <div style="width: 700px; margin: 0 auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <cc1:PanelControl pageItem="个人信息修改,UserInfoEdit.aspx;密码修改,UserPwdEdit.aspx" runat="server"
                        ID="PanelControl1" runat="server" onclick="PanelControl1_Click" />
                </td>
            </tr>
        </table>
        <table border="0"  width="700" style="border: solid 1px #cccccc; line-height:34px; background-color: White;"  align="center"    
            cellspacing="0" cellpadding="0">
            <tr>
                <td height="20" width="250px" align="right">
                    用户ID：
                </td>
                <td align="left">
                    <asp:TextBox ID="tbUserLoginName" Width="200px" runat="server"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="80" height="20" align="right">
                    用户名：
                </td>
                <td align="left">
                    <asp:TextBox ID="tbUserName" runat="server" Width="200px" CssClass="ipt-t" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="20" align="right">
                    原密码：
                </td>
                <td height="20" align="left">
                    <asp:TextBox ID="tbpassword" runat="server" Width="200px" CssClass="ipt-t" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    新密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="tbnewpwd" runat="server" Width="200px" CssClass="ipt-t" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    确认密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="tbnewpwd2" runat="server" Width="200px" CssClass="ipt-t" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lbMsg" runat="server" style=" color:Red; font-size:12px;" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="50" align="center">
                    <asp:Button ID="btnadd" runat="server" OnClientClick="return checkInfo();"
                        CssClass="btn-btn01" Text="确定" onclick="btnadd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btncancel" OnClientClick="window.returnValue='no'; window.close();"
                        runat="server" CssClass="btn-btn01" Text="关闭" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HDwhatDO" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    //检测输入数据的合法性
    function checkInfo() {
        var lbMsg = document.getElementById("lbMsg");
        var tbpassword = document.getElementById("tbpassword");
        var tbnewpwd = document.getElementById("tbnewpwd");
        var tbnewpwd2 = document.getElementById("tbnewpwd2");

        if (tbpassword.value == "") {
            tbpassword.focus();
            lbMsg.innerHTML = "请输入原密码！";
            return false;
        }

        if (tbnewpwd.value == "") {
            tbnewpwd.focus();
            lbMsg.innerHTML = "请输入新密码！";
            return false;
        }

        if (tbnewpwd2.value != tbnewpwd.value) {
            tbnewpwd2.focus();
            lbMsg.innerHTML = "两次输入密码不一致！";
            return false;
        }

        return true;
    }

</script>

