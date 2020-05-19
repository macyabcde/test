<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="User.Web.UserLogin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table width="100%" border="0" cellspacing="1" cellpadding="0">
        <tr>
            <td align="center" background="../images/loginbg.jpg">
                <table width="469" height="301" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="75" colspan="2" align="center" background="../images/login_c0.jpg" bgcolor="#FFFFFF">
                            <p>
                                &nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td width="209" height="226" align="center" background="../images/login_c1.jpg" bgcolor="#FFFFFF">
                            <table width="174" border="0" cellspacing="1" cellpadding="0" class="divcss5-3">
                                <tr>
                                    <td width="10%" height="89" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="90%" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="69" align="left">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <%--注意事项： <br />
                ·请使用IE5.5以上浏览器 <br />
                ·请启用浏览器Cookie <br />
                ·请打开浏览器脚本支持--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="260" height="226" align="center" valign="top" background="../images/login_c2.jpg"
                            bgcolor="#FFFFFF">
                            <p>
                                &nbsp;</p>
                            <table width="220" border="0" cellspacing="1" cellpadding="0" class="divcss5-3">
                                <tr>
                                    <td width="31%" height="32" align="right">
                                        用 户 名：
                                    </td>
                                    <td width="69%" height="32" align="left">
                                        <asp:TextBox ID="tbUserID" runat="server" style="border: 0; border-bottom: 1px solid #dddddd; background: ;"
                                            size="18" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="32" align="right">
                                        密&nbsp;&nbsp;码：
                                    </td>
                                    <td height="32" align="left">
                                        <asp:TextBox ID="tbPwd" runat="server" TextMode="Password" style="border: 0; border-bottom: 1px solid #dddddd;
                                            background: ;" size="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="60" colspan="2" align="center">
                                        <table width="84%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <div align="right">
                                                        <asp:ImageButton ID="ImgBtnLogin" OnClientClick="return checkInfo();" 
                                                            ImageUrl="../images/login.jpg" runat="server" onclick="ImgBtnLogin_Click" /></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="29" colspan="2" align="center">
                                        <%--·可以写一些自己需要的，或者不要的--%>
                                        <asp:Label ID="lbMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">

    function checkInfo() {
        var tbUserID = document.getElementById("tbUserID");
        var lbMsg = document.getElementById("lbMsg");

        if (tbUserID.value == "") {
            lbMsg.innerHTML = "请输入用户名!";
            return false;
        }
        lbMsg.innerHTML = "";
        return true;
    }
    
</script>