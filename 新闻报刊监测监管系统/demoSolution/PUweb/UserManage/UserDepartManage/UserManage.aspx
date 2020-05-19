<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="User.Web.UserDepartManage.UserManage" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnRefresh" runat="server" Text="刷新" Style="display: none;" OnClick="btnRefresh_Click" />
    <asp:Button ID="btncomand" runat="server" Text="Button" Style="display: none;" OnClick="btncomand_Click" />
    <asp:HiddenField ID="HFvalue" runat="server" />
    <asp:HiddenField ID="HFcomand" runat="server" />
    <uc1:head ID="head2" runat="server" />
    <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="212" align="center" valign="top" background="../images/leftdi.jpg">
                <uc2:left ID="left1" runat="server" />
            </td>
            <td width="1" align="center" valign="top" bgcolor="#FFFFFF">
            </td>
            <td width="5" bgcolor="#5F87BC">
                <img src="../images/middledot.jpg" width="4" height="1" />
            </td>
            <td width="180" valign="top">
                <iframe id="iftreeShow" name="iftreeShow" scrolling="auto" src="Tree.aspx" frameborder="0"
                    align="right"></iframe>
            </td>
            <td width="5" valign="top" bgcolor="#5F87BC">
                <img src="../images/middledot.jpg" width="4" height="1" />
            </td>
            <td width="100%" valign="top">
                <iframe width="100%" id="ifUserShow" name="ifUserShow" src="UserList.aspx" frameborder="0">
                </iframe>
            </td>
        </tr>
    </table>
    <uc3:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
