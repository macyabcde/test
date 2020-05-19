<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookArticle.aspx.cs" Inherits="PU.web.Search.LookArticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet">

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../UserManage/js/client.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
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
                                            <asp:Label ID="lbwhatDo" runat="server" Text="文章信息"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="1" bgcolor="#CCCCCC">
                </td>
            </tr>
        </table>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    <asp:Button ID="BtFavorites" runat="server" Text="收藏" CssClass="btn-btn01" />
                    <asp:Button ID="BtRecommend" runat="server" Text="推荐" CssClass="btn-btn01" />
                    <asp:Button ID="BtClippingSend" runat="server" Text="剪报推送" CssClass="btn-btn01" />
                    <asp:Button ID="BtMyOpus" runat="server" Text="放入作品" CssClass="btn-btn01" />
                    <asp:Button ID="BtEPaper" runat="server" Text="数字报" CssClass="btn-btn01" />
                    <asp:Button ID="BtFDFDown" runat="server" Text="PDF下载" CssClass="btn-btn01" />
                    <asp:Button ID="BtEdit" runat="server" Text="修改" CssClass="btn-btn01" />
                </td>
            </tr>
        </table>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="280" valign="top">
                    <span style="float: left; margin: 0px 15px 15px">
                        <img alt="" src="<%=jpgUrl %>" width="280" /></span>
                </td>
                <td valign="top">
                    <div style="margin-top: 20px;">
                    </div>
                    <% if (ArticleJG.YT != "")
                       { %>
                    <div style="margin-top: 10px; font-weight: 100; font-size: 14px; margin-bottom: 5px;
                        font-family: Verdana; height: 20px">
                        <%=MarkKey(ArticleJG.YT)%></div>
                    <% } %>
                    <div style="font-weight: bold; font-size: 20px; font-family: '微软雅黑'">
                        <%=MarkKey(ArticleJG.BT)%></div>
                    <% if (ArticleJG.FB != "")
                       { %>
                    <div style="margin-top: 5px; font-weight: 100; font-size: 14px; margin-bottom: 5px;
                        font-family: Verdana; height: 20px">
                        <%=MarkKey(ArticleJG.FB)%></div>
                    <% } %>
                    <% if (ArticleJG.ZZ != "")
                       { %>
                    <div style="margin-top: 5px; font-weight: 100; font-size: 12px; margin-bottom: 5px;
                        font-family: Verdana; height: 20px">
                        <%=MarkKey(ArticleJG.ZZ)%></div>
                    <% } %>
                    <ul id="arttitle">
                        <li>
                            <%=bmOtherInfo%>
                        </li>
                    </ul>
                    <div style="padding-right: 15px; padding-left: 15px; font-size: 14px; line-height: 24px;
                        text-align: justify">
                        <%
                            string tx = ArticleJG.TX;
                            tx = tx.Replace("\r\n", "<br>");
                            tx = tx.Replace(" ", "&nbsp;");
                            tx = MarkKey(tx);
                            Response.Write(tx);
                        %>
                    </div>
                    <div id="ct">
                        <%
                            foreach (PM.Model.MDL_CTInfo CTmodel in ArticleJG.CTList)
                            {
                                string ctUrl = "../Resource/getResource.aspx?KID=" + ArticleJG.KID + "&paperID=" + ArticleJG.paperID + "&RQ=" + ArticleJG.RQ + "&BC=" + ArticleJG.BC + "&type=3" + "&fileName=" + CTmodel.fileName;													
                        %>
                        <div>
                            <img class="img" style="background-color: #cccccc" src="<%=ctUrl %>" /></div>
                        <div style="margin-top: 5px; font-weight: 100; font-size: 12px; margin-bottom: 5px;
                            font-family: Verdana; height: 20px">
                            <%=MarkKey(CTmodel.TS)%></div>
                        <div style="margin-top: 5px; font-weight: 100; font-size: 12px; margin-bottom: 5px;
                            font-family: Verdana; height: 20px">
                            <%=MarkKey(CTmodel.TZ)%></div>
                        <%} %>
                    </div>
                </td>
            </tr>
        </table>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="60">
                    <asp:Button ID="BtClose" runat="server" Text="关 闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
