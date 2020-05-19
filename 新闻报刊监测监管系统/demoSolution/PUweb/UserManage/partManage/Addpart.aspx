<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addpart.aspx.cs" Inherits="User.Web.partManage.Addpart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加角色</title>
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
                                        <asp:Label ID="lbwhatDo" runat="server" Text="Label"></asp:Label>
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
    <table width="650" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="650" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td width="27" height="28" align="center">
                &nbsp;
            </td>
            <td width="100" height="20" align="right">
                <asp:Label ID="lbpartName" runat="server" Text="角色名称:"></asp:Label>
            </td>
            <td width="219" height="20" align="left">
                <asp:TextBox ID="tbpartName" runat="server"></asp:TextBox>
            </td>
            <td width="91" height="20" align="center">
                &nbsp;
            </td>
            <td width="228" height="20" align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="30" align="center">
                &nbsp;
            </td>
            <td align="right">
                说&nbsp;&nbsp;&nbsp;&nbsp;明:
            </td>
            <td colspan="3" align="left">
                <asp:TextBox ID="tbexplain" style=" overflow:auto;" runat="server" Width="70%" TextMode="MultiLine" Height="132px"></asp:TextBox>
            </td>
        </tr>
        <tr height="20px">
            <td align="center" colspan="5">
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
<script  language="javascript" type="text/javascript">
    
    //检测输入数据的合法性
    function checkInfo() {
        var lbMsg = document.getElementById("lbMsg");
        var tbpartName = document.getElementById("tbpartName");
        if (tbpartName.value == "") {
            lbMsg.innerHTML = "请输入角色名称！";
            tbpartName.focus();
            return false;
        }
        return true;
    }
</script>