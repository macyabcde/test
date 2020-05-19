<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="User.Web.other.index" %>


<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统管理</title>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
  
    <uc1:head ID="head2" runat="server" />
    <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="212" align="center" valign="top" background="../images/leftdi.jpg">
                <uc2:left ID="left1" runat="server" />
            </td>
            <td width="1" align="center" valign="top" bgcolor="#FFFFFF">
            </td>
            <td width="5" bgcolor="#5F87BC">
            </td>
            <td valign="top">
                <!-- mainStart -->
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="1" bgcolor="#FFFFFF">
                        </td>
                    </tr>
                </table>
               
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="1" bgcolor="#CCCCCC">
                        </td>
                    </tr>
                </table>
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr height="400px;">
                        <td>
                          
                        </td>
                    </tr>
                </table>
                
               
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <!-- mainEnd -->
            </td>
        </tr>
    </table>
    <uc3:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
