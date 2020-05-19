<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsCollectionTypeAdd.aspx.cs" Inherits="PU.web.MyInformation.newsCollectionTypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加报纸</title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript">
        
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="31" background="../images/middle_di_01.jpg">
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
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
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
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
               类别名称：
            </td>
            <td width="219" height="20" align="left">
                <asp:TextBox ID="tbcollectionTypeName" runat="server" Width="210px"></asp:TextBox>
            </td>
            <td width="91" height="20" align="right">
                排序：
            </td>
            <td width="228" height="20" align="left">
                <asp:TextBox ID="tbxuhao" runat="server">10</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnFinish" runat="server" Text="保存" OnClick="btnFinish_Click" CssClass="btn-btn01" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
