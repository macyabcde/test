<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoEdit.aspx.cs" Inherits="User.Web.UserInfoEdit" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人信息修改</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/tabStyle.css" rel="stylesheet" type="text/css" />
    <base  target="_self"></base>
</head>
<body bgcolor="#fcfefd">
    <form id="form2" runat="server">
    <div style=" width:700px;  margin:0 auto;" >
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td >
               <cc1:PanelControl ID="PanelControl1" 
                    pageItem="个人信息修改,UserInfoEdit.aspx;密码修改,UserPwdEdit.aspx"  runat="server" 
                    onclick="PanelControl1_Click" />      
            </td>
        </tr>
    </table>
    <table width="700" border="0" style=" border:solid 1px #cccccc; background-color:White;" align="center" cellpadding="0" cellspacing="1">
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
                <asp:TextBox ID="tbuserLoginName" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td width="91" height="20" align="right">
                <asp:Label ID="lbuserName" runat="server" Text="用户姓名:"></asp:Label>
            </td>
            <td width="228" height="20" align="left">
                <asp:TextBox ID="tbuserName" runat="server" Enabled="False"></asp:TextBox>
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
               
            </td>
            <td height="20" align="left">
                <asp:TextBox ID="tbxuhao" runat="server" Visible="False">10</asp:TextBox>
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
                <asp:Button ID="btnFinish" OnClientClick="return checkInfo();" runat="server" 
                    Text="保存"  CssClass="btn-btn01" onclick="btnFinish_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
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
        return true;
    }

    try {
        document.getElementById("lbuserName").focus();
    }
    catch (e) {

    }
    
</script>
