<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aliasInfoList.aspx.cs" Inherits="PU.web.MyOpus.aliasInfoList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>笔名设置</title>

     <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/PUweb.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript">
        /*删除
        aliasInfoID：笔名信息ID
        aliasInfo：笔名信息
        */
        function del(aliasInfoID, aliasInfo) {
            if (!confirm("您真的要删除笔名[" + aliasInfo + "]吗？")) return;
            $("#HidValue").val(aliasInfoID);
            $("#HidCommand").val("del");
            document.getElementById("BtCommand").click();
        }
    
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    
    <asp:HiddenField ID="HidValue" runat="server" />
        <asp:HiddenField ID="HidCommand" runat="server" />
        <asp:Button ID="BtCommand" runat="server" Text="多功能按钮" CssClass="hide" OnClick="BtCommand_Click" />
        
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
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
                                        <asp:Label ID="lbwhatDo" runat="server">笔名设置</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#CCCCCC">
            </td>
        </tr>
    </table>
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td height="28" align="left">
                &nbsp; 笔名：<asp:TextBox ID="txtaliasInfo" runat="server" Width="182px"></asp:TextBox>
&nbsp;
                <asp:Button ID="BtAdd" runat="server" Text="添加"
                    CssClass="btn-btn01" onclick="BtAdd_Click" />
                </td>
        </tr>
        <tr>
            <td height="30" align="center">
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center" id="divCustomerPaper">
                <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" 
                    onitemdatabound="rptRetList_ItemDataBound">
                    <HeaderTemplate>
                        <table cellpadding="0" bgcolor="#E4E4E4" border="0" width="100%" cellspacing="1">
                            <tr class="trTop">
                                <td width="10%">
                                    序号
                                </td>
                                <td width="40%">
                                    笔名
                                </td>
                                <td>
                                    创建时间
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="trData">
                            <td align="center">
                                <%# rptRetList.Items.Count + 1%>
                            </td>
                            <td align="center">
                                <asp:Label ID="LbaliasInfo" runat="server" Text='<%#Eval("aliasInfo") %>' EnableViewState="False"></asp:Label>
                                <asp:HiddenField ID="HidaliasInfoID" runat="server" Value='<%#Eval("aliasInfoID") %>' EnableViewState="False" />
                            </td>
                            <td  align="center">
                                <asp:Label ID="LbcreateTime" runat="server" Text='<%#Eval("createTime") %>' EnableViewState="False"></asp:Label>
                            </td>
                             <td  align="center">
                                 <asp:HyperLink ID="HLinkDel" runat="server" EnableViewState="False">删除</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        </table>
        
            </td>
        </tr>
        <tr>
            <td height="40" align="center">
               <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
