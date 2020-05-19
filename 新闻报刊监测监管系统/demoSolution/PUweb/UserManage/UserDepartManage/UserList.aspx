<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="User.Web.UserDepartManage.UserList" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnRefresh" runat="server" Text="刷新" Style="display: none;" OnClick="btnRefresh_Click" />
    <asp:Button ID="btncomand" runat="server" Text="Button" Style="display: none;" OnClick="btncomand_Click" />
    <asp:HiddenField ID="HFvalue" runat="server" />
    <asp:HiddenField ID="HFcomand" runat="server" />
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="1" bgcolor="#FFFFFF">
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="31" background="../images/middle_di_01.jpg">
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td align="left" class="mo_title_l4">
                            <table width="200" border="0" cellspacing="1" cellpadding="0">
                                <tr>
                                    <td width="21">
                                        <span class="mo_title_l21">
                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                    </td>
                                    <td width="176">
                                        <span class="mo_title_l31">用户管理</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
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
        <tr>
            <td align="left">
                <asp:Button ID="btnAddDepartment" runat="server" Text="添加组织" CssClass="btn-btn01" />
                <asp:Button ID="btnUpdateDepartment" runat="server" Text="修改组织" CssClass="btn-btn01" />
                <asp:Button ID="btnDeleteDepartment" runat="server" Text="删除组织" 
                    CssClass="btn-btn01" OnClick="btnDeleteDepartment_Click" />
                <asp:Button ID="btnMoveDepartment" runat="server" Text="移动组织" CssClass="btn-btn01" />
            </td>
            <td width="50%" height="30" align="right">
                &nbsp; &nbsp;
                <asp:Button ID="btnAddUser" runat="server" Text="添加用户"   CssClass="btn-btn01" />
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
    <asp:Repeater ID="rptPaper" runat="server" EnableViewState="False" OnItemDataBound="rptPaper_ItemDataBound">
        <HeaderTemplate>
            <table width="93%" id="tabPaper" border="0" align="center" cellpadding="0" cellspacing="1"
                bgcolor="#E4E4E4">
                <tr class="trTop">
                    <td width="20%">
                        用户登录名
                    </td>
                    <td width="15%">
                        姓名
                    </td>
                    <td width="10%">
                        状态
                    </td>
                    <td width="20%">
                        角色
                    </td>
                    <td width="35%">
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="trData">
                <td align="center">
                    <asp:LinkButton ID="lbtnuserLoginName" runat="server" Text='<%#Eval("userLoginName") %>'
                        EnableViewState="False"></asp:LinkButton>
                    <asp:HiddenField ID="HFuserGUID" runat="server" Value='<%#Eval("userGUID") %>' EnableViewState="False" />
                </td>
                <td align="center">
                    <asp:Label ID="lbuserName" runat="server" Text='<%#Eval("userName") %>' EnableViewState="False"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lbactive" runat="server" Text='<%#Eval("active") %>' EnableViewState="False"></asp:Label>
                </td>
                <td align="center" id="tdPartName" runat="server">
                    <asp:Label ID="lbpartName" runat="server"  EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnUpdate" runat="server" EnableViewState="False">修改</asp:LinkButton>
                    <asp:LinkButton ID="lbtnMoveUserdepart" runat="server" EnableViewState="False">用户调动</asp:LinkButton>
                    <asp:LinkButton ID="lbtnpassword" runat="server" EnableViewState="False">密码重置</asp:LinkButton>
                    <asp:LinkButton ID="lbtnIsactive" runat="server" CommandArgument='<%# Eval("active") %>' EnableViewState="False" Text='<%#Eval("active").ToString()=="0"?"启用":"禁用" %>'></asp:LinkButton>
                    <asp:LinkButton ID="lbtnUser_Part" runat="server" EnableViewState="False">用户角色</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDelete" runat="server" EnableViewState="False">删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" class="divcss5-3">
        <tr>
            <td height="46" align="right">
                <cc1:pageControl ID="pageControl1" runat="server" fontSize="12" goPage="1" OnClick="pageControl1_Click" />
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
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    var HFvalue = document.getElementById("HFvalue");
    var HFcomand = document.getElementById("HFcomand");
    var btncomand = document.getElementById("btncomand");

    //删除用户
    //userGUID：用户GUID
    //UserLogionName：用户登录名
    function delUser(userGUID, UserLogionName) {
        var hasDel = confirm("您确定要删除\"" + UserLogionName + "\"吗？");
        if (!hasDel) return false;

        HFvalue.value = userGUID;
        HFcomand.value = "delUser";
        btncomand.click();
        return false;
    }


    //启用(禁用)用户
    //active：用户当前启用状态
    //userGUID：用户GUID
    //UserLogionName：用户登录名
    function isactive(active, userGUID, UserLogionName) {
        var HasActive = false;
        if (active == 0)
            HasActive = confirm("您确定要启用\"" + UserLogionName + "\"吗？");
        else
            HasActive = confirm("您确定要禁用\"" + UserLogionName + "\"吗？");

        if (active == 0)
            active = 1;
        else
            active = 0;

        if (!HasActive) return false;

        HFvalue.value = active + "," + userGUID;
        HFcomand.value = "active";
        btncomand.click();
        return false;
    }


    window.parent.document.getElementById("ifUserShow").style.height = document.body.scrollHeight + 50;
   

</script>
