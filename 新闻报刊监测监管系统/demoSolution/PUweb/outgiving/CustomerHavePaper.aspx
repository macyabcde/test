<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHavePaper.aspx.cs" Inherits="PU.web.outgiving.CustomerHavePaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报纸范围</title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/jquery.js" type="text/javascript"></script>

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
                                    <td>
                                        <asp:Label ID="lbwhatDo" runat="server" Text="已有报纸范围"></asp:Label>
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
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center" id="divCustomerPaper">
                <asp:Repeater ID="rptCustomerPaper" runat="server" 
                    onitemdatabound="rptCustomerPaper_ItemDataBound">
                    <HeaderTemplate>
                        <table cellpadding="0" bgcolor="#E4E4E4" border="0" width="100%" cellspacing="1">
                            <tr class="trTop">
                                <td width="10%">
                                    报纸ID
                                </td>
                                <td width="70%">
                                    报纸名称
                                </td>
                                <td width="15%">
                                    已更新到日期
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="trData">
                            <td align="center">
                                <%# Eval("paperID")%>
                                <asp:HiddenField ID="HFpaperID" Value=' <%# Eval("paperID")%>' runat="server" />
                            </td>
                            <td  align="left">
                                <asp:Label ID="lbPaperName" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lbupdateOverDate" runat="server" Text='<%# Eval("updateOverDate") %>'></asp:Label>
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        </table>
        
  <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="60"  align="center" style=" background-color:White;">
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFcustomerPaperStr" runat="server" />
    </form>
</body>
</html>