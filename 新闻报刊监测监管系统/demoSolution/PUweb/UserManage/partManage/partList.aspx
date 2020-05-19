<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partList.aspx.cs" Inherits="User.Web.partManage.partList" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>

    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnRefresh" runat="server" Text="刷新"  Style="display: none;"  onclick="btnRefresh_Click1"/>
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
                                                    <span class="mo_title_l31">角色管理</span>
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
                        <td width="100%" height="30" align="right">
                            <asp:Button ID="btnAdd" runat="server" Text="添加" OnClientClick="windOpen('Addpart.aspx?whatDo=add','690','380'); return false;"
                                CssClass="btn-btn01" />
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
                                <td>
                                    角色名称
                                </td>
                                <td>
                                    权限数
                                </td>
                                <td>
                                    使用人数
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="trData">
                            <td align="center">
                                <asp:LinkButton ID="lbtnpartName" runat="server" Text='<%#Eval("partName") %>' EnableViewState="False"></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbpopedomCount" runat="server"  EnableViewState="False"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbuserCount" runat="server"  EnableViewState="False"></asp:Label>
                            </td>
                            <td>
                                <asp:HiddenField ID="HFpartID" Value='<%# Eval("partID") %>' runat="server" />
                                <asp:LinkButton ID="lbtnUpdate" runat="server" EnableViewState="False">修改</asp:LinkButton>
                                <asp:LinkButton ID="lbtnpopedom" runat="server" EnableViewState="False">权限定义</asp:LinkButton>
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
                <!-- mainEnd -->
            </td>
        </tr>
    </table>
    <uc3:footer ID="footer1" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    var HFvalue = document.getElementById("HFvalue");
    var HFcomand = document.getElementById("HFcomand");
    var btncomand = document.getElementById("btncomand");

    //删除角色
    //partID：角色ID
    //partName：角色名称
    function delPart(partID,partName) {
        var hasDel = confirm("您确定要删除“" + partName + "”吗？");
        if (!hasDel) return false;

        HFvalue.value = partID;
        HFcomand.value = "delPart";
        btncomand.click();
        return false;
    }
</script>

