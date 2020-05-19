<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pressClippingSearchList.aspx.cs"
    Inherits="PU.web.pressClipping.pressClippingSearchList" %>

<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>剪报查询</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript"></script>
     <script language="javascript" type="text/javascript">
         

         /* 删除
         pressClippingBasisInfoID：剪报基本信息ID
         pressClippingName：剪报名称	
         */
         function del(pressClippingBasisInfoID, pressClippingName) {
             if (!confirm("您确认要将[" + pressClippingName + "]删除吗？")) return
             $("#HidValue").val(pressClippingBasisInfoID);
             $("#HidCommand").val("del");
             document.getElementById("BtCommand").click();
         }
         /* 强制退回
         pressClippingBasisInfoID：剪报基本信息ID
         pressClippingName：剪报名称	
         */
         function QzReturn(pressClippingBasisInfoID, pressClippingName) {
             if (!confirm("您确认要将[" + pressClippingName + "]强制退回到选编状态吗？")) return
             $("#HidValue").val(pressClippingBasisInfoID);
             $("#HidCommand").val("QzReturn");
             document.getElementById("BtCommand").click();
         }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtRef" runat="server" Text="刷新" CssClass="hide" OnClick="BtRef_Click" />
        <asp:HiddenField ID="HidValue" runat="server" />
        <asp:HiddenField ID="HidCommand" runat="server" />
        <asp:Button ID="BtCommand" runat="server" Text="多功能按钮" CssClass="hide" OnClick="BtCommand_Click" />
        <uc1:head ID="head2" runat="server" />
        <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="212" align="center" valign="top" background="images/leftdi.jpg">
                    <uc2:left ID="left2" runat="server" />
                </td>
                <td width="1" align="center" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="5" bgcolor="#5F87BC">
                </td>
                <td valign="top" align="center">
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
                                            <table width="500" border="0" cellspacing="1" cellpadding="0">
                                                <tr>
                                                    <td width="21">
                                                        <span class="mo_title_l21">
                                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                                    </td>
                                                    <td width="176">
                                                        <span class="mo_title_l31">剪报查询</span>
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
                            <td height="5">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                        <tr>
                            <td align="left">
                                &nbsp; 名称：<asp:TextBox ID="txtpressClippingName" runat="server" Width="181px"></asp:TextBox>
                                &nbsp;<asp:DropDownList ID="DPListstate" runat="server">
                                </asp:DropDownList>
                            &nbsp;<asp:Button ID="BtSearch" runat="server" Text="查询" CssClass="btn-btn01" 
                                    onclick="BtSearch_Click"  />
                            </td>
                            <td align="right" height="40">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="93%" id="tabRetList" border="0" align="center" cellpadding="0" cellspacing="1"
                        bgcolor="#E4E4E4">
                        <tr class="trTop">
                            <td>
                                名称
                            </td>
                            <td>
                                客户
                            </td>
                            <td>
                                销售人员
                            </td>
                            <td>
                                创建人
                            </td>
                            <td>
                                状态
                            </td>
                            <td>
                                创建时间
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" OnItemDataBound="rptRetList_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="trData">
                                    <td align="center">
                                        <asp:HyperLink ID="HLinkpressClippingName" runat="server" Text='<%#Eval("pressClippingName") %>'
                                            EnableViewState="False"></asp:HyperLink>
                                        <asp:HiddenField ID="HidpressClippingBasisInfoID" runat="server" Value='<%#Eval("pressClippingBasisInfoID") %>'
                                            EnableViewState="False" />
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <asp:Label ID="Lbcustomer" runat="server" Text='<%#Eval("customer") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="salesman" runat="server" Text='<%#Eval("salesman") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbuserName" runat="server" Text='<%#Eval("userName") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Lbstate" runat="server" Text='<%#Eval("state") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbcreateTime" runat="server" Text='<%#Eval("createTime") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:HyperLink ID="HLinkNewsList" runat="server" Text="报道信息" EnableViewState="False"></asp:HyperLink>
                                        <asp:HyperLink ID="HLinkUpdate" runat="server" Text="修改" EnableViewState="False"></asp:HyperLink>
                                        <asp:HyperLink ID="HLinkQZReturn" runat="server" Text="强制退回" title="强制退回到选编状态" EnableViewState="False"></asp:HyperLink>                                        
                                        <asp:HyperLink ID="HLinkDel" runat="server" Text="删除" EnableViewState="False"></asp:HyperLink>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <table width="93%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" height="40" style="font-size: 12px;">
                            </td>
                            <td align="right" height="40">
                                <cc1:pageControl ID="pageControl1" runat="server" pageSize="20" OnClick="pageControl1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc3:footer ID="footer2" runat="server" />
    </div>
    </form>
</body>
</html>
