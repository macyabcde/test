<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticlePage.aspx.cs" Inherits="PU.web.Paper.ArticlePage" %>

<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/calendar.css" rel="stylesheet" type="text/css" />

    <script language="Javascript" src="js/excanvas.compiled.js"></script>

    <script language="Javascript" src="js/jquery-1.3.2.min.js"></script>

    <script src="../UserManage/js/client.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script type="text/javascript">
        var JQ = $;
       
    </script>

    <script language="Javascript" src="js/highlight.js" type="text/javascript"></script>

    <script src="js/paper.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <style type="text/css">
        body
        {
            background-image: url();
            background-color: #F7FAFF;
        }
        body, td, th, prelink
        {
            font-size: 12px;
        }
        .STYLE30
        {
            color: #B52008;
            font-weight: bold;
        }
        .commonlight2
        {
            background-color: #a2dbff;
        }
        .commoncolor3
        {
            background-color: #FFFFFF;
        }
    </style>
</head>
<span id="leveldiv" title="点击查看内容" style="border-top-width: 0px; border-left-width: 0px;
    z-index: 100; left: 233px; border-bottom-width: 0px; width: 210px; cursor: hand;
    position: absolute; top: 123px; height: 34px; border-right-width: 0px"></span>
<body onload="makeCanvas();" text="#000000" vlink="#000000" alink="#ff0000" link="#000000"
    leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="1002" align="center" border="0" background="image/bg.jpg">
        <tr>
            <td valign="top" width="354">
                <table width="380" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="380" align="middle">
                            <table width="381" height="146" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="23" rowspan="3" valign="top">
                                        <img src="image/jwb_red_r1_c1.jpg" width="25" height="130" id="logoImg">
                                    </td>
                                    <td width="322" valign="top" bgcolor="#ffffff" style="background: url(image/jwb_red_r1_c2.jpg) repeat-x;">
                                        <img src="image/jwb_red_r1_c2.jpg" width="355" height="42">
                                    </td>
                                    <td width="10" rowspan="2" valign="top" background="image/jwb_red_r6_c3.jpg" style="background-repeat: repeat-y">
                                        <img src="image/jwb_red_r1_c3.jpg" width="13" height="160">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="310" bgcolor="#ffffff" style="border: #111111 1px solid; padding: 10px;"
                                        align="center">
                                        <div id="main-ed-map" align="center">
                                            <map name="PagePicMap">
                                                <% foreach (string str in zblist)
                                                   {
                                                       string[] arr = str.Split(';');
                                               
                                                %>
                                                <area coords="<%=arr[0] %>" btid="BT<%=arr[1] %>" shape="polygon" href="ArticlePage.aspx?KID=<%=arr[1] %>">
                                                <%} %>
                                            </map>
                                            <img src="<%=jpgUrl %>" border="0" usemap="#PagePicMap">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="23" align="right" valign="top">
                                        <img src="image/jwb_red_r8_c2.jpg" width="355" height="9">
                                    </td>
                                    <td valign="top">
                                        <img src="image/jwb_red_r8_c3.jpg" width="9" height="9">
                                    </td>
                                </tr>
                            </table>
                            <table width="373" border="0" cellpadding="5" cellspacing="0" style="margin-bottom: 3px">
                                <tr>
                                    <td width="13" align="left">
                                        &nbsp;
                                    </td>
                                    <td width="175" align="left">
                                        <asp:Label ID="LbBC" runat="server" Text="02"></asp:Label>
                                        <asp:Label ID="LbBM" runat="server" Text="：综合新闻" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td width="125" align="right" nowrap style="padding-right: 0px; padding-left: 0px;
                                        padding-bottom: 0px; padding-top: 0px">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td nowrap width="33%" class="px12">
                                                    <span style='font-size: 12px; font-family: webdings'>3</span><asp:HyperLink ID="HLinkPreBC"
                                                        title="转到上一版" runat="server">上一版</asp:HyperLink>&nbsp;
                                                </td>
                                                <td nowrap width="33%" class="px12">
                                                    <asp:HyperLink ID="HLinkNetBC" title="转到下一版" runat="server">下一版<span style='font-size: 12px;
                                                        font-family: webdings'>4</span></asp:HyperLink>&nbsp;
                                                </td>
                                                <td nowrap class="px12">
                                                    <asp:HyperLink ID="HLinkSC" title="收藏本版面" runat="server">收藏</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="16" align="right" valign="center" nowrap style="padding-right: 5px">
                                        <asp:HyperLink ID="HLinkPDFDown" runat="server" title="下载本版面PDF" Target="_blank"><img height="16" src="image/pdf01.gif" width="16" border="0"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="4" width="376" border="0">
                                <tr>
                                    <td width="12" align="left" valign="top">
                                        &nbsp;
                                    </td>
                                    <td width="348" align="left" valign="top">
                                        <table width="348" border="0" cellspacing="0" cellpadding="0" style="border: #C0C0C0 1px solid">
                                            <tr>
                                                <td bgcolor="#FFFFFF" height="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" height="20" style="padding-left: 10px;">
                                                    <span class="STYLE30">标题导航</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF">
                                                    <img src="image/image06.jpg">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#FFFFFF" style="padding-left: 10px;">
                                                    <div id="main-ed-articlenav-list" style="height: 170px; overflow-y: scroll; width: 100%;">
                                                        <table cellspacing="0" cellpadding="1" border="0">
                                                            <tbody>
                                                                <asp:Repeater ID="rptTitleList" runat="server" EnableViewState="False" OnItemDataBound="rptTitleList_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td class="default" valign="top">
                                                                                <img src="image/checkbox.gif" width="10" height="10">
                                                                            </td>
                                                                            <td class="default" valign="top">
                                                                                <div style="display: inline" id='BT<%#Eval("KID") %>'>
                                                                                    <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False"></asp:HyperLink>
                                                                                </div>
                                                                                <span style="display: none">#article-pretitle#~~~#article-subtitle#</span>
                                                                                <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table height="115" cellspacing="0" cellpadding="0" width="609" border="0">
                    <tr>
                        <td height="130" colspan="4" align="right" valign="bottom" background="image/<%=ArticleModel.paperID %>.jpg"
                            class="menu">
                            <span id="goIndexSpan"><a href="BMList.aspx?paperID=<%=ArticleModel.paperID %>&RQ=<%=ArticleModel.RQ %>">
                                今日头版</a> |</span> <span id="goTilePageSpan"><a href="titleIndex.aspx?paperID=<%=ArticleModel.paperID %>&RQ=<%=ArticleModel.RQ %>">
                                    版面标题导航</a> |</span> <span id="bmdhSpan" onmouseover="document.getElementById('bmdh').style.display = 'block';setbmdh();"
                                        onmouseout="document.getElementById('bmdh').style.display = 'none';"><a href="javascript:;">
                                            版面导航</a> |</span> <span id="btdhSpan" onmouseover="document.getElementById('btdh').style.display = 'block';setbtdh();"
                                                onmouseout="document.getElementById('btdh').style.display = 'none';"><a href="javascript:;">
                                                    标题导航</a></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="5">
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="center" valign="top">
                            <asp:Label ID="LbRQ" runat="server" Text="2011年05月24日 星期二 出版" CssClass="default"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td width="35%" align="center" valign="top">
                            <span id="searchQY" style="display: block">
                                <asp:TextBox ID="txtKeyWord" runat="server" Style="height: 20px; width: 140"></asp:TextBox>&nbsp;
                                    <input id="BtSearch" type="button" value="搜索" onclick="searchWord('<%=ArticleModel.paperID %>');" style="height: 20px;" title="全文搜索您输入的关键词" /></span>
                        </td>
                        <td width="25%" align="center" valign="top">
                            <span id="upqi" style="display: block">
                                <img src="image/image01.jpg" /><asp:HyperLink ID="HLinkPreRQ" title="转到上一个出版日期" runat="server">上一期</asp:HyperLink>&nbsp;&nbsp;
                                <asp:HyperLink ID="HLinkNetRQ" runat="server" title="转到下一个出版日期">下一期</asp:HyperLink><img
                                    src="image/image02.jpg" /></span>
                        </td>
                    </tr>
                </table>
                <table width="588" height="507" border="0" cellpadding="0" cellspacing="0">
                    <tr valign="top">
                        <td rowspan="4">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="border-bottom: #787878 1px solid;" height="24">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td colspan="2" height="15">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="26%">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td nowrap width="50%" class="px12">
                                                                <asp:HyperLink ID="HLinkPreArticle" title="转到本版的上一篇报道" runat="server">
                                                                <span style="font-size: 12px;font-family: webdings;">3</span>上一篇</asp:HyperLink>
                                                            </td>
                                                            <td nowrap width="50%" class="px12">
                                                                <asp:HyperLink ID="HLinkNextArticle" title="转到本版的下一篇报道" runat="server">下一篇 <span style='font-size: 12px; font-family: webdings'>
                                                                    4</span></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="74%" align="right">
                                                    <asp:HyperLink ID="HLinkArticleSC" title="收藏本篇报道" runat="server" EnableViewState="False">收藏</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkTJ" title="将本篇报道推荐给他人" runat="server" EnableViewState="False">推荐</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkTJB" title="将本篇报道加入剪报中" runat="server" EnableViewState="False">剪报</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkMyOpus" title="将本篇报道放入我的作品中" runat="server" EnableViewState="False">作品</asp:HyperLink>&nbsp;&nbsp;
                                                    <a onclick="zoomIn();" href="javascript:;">放大<img height="16" src="image/zoomin.gif"
                                                        width="16" align="middle" border="0" /></a> <a onclick="zoomOut();" href="javascript:;">
                                                            缩小<img height="16" src="image/zoomout.gif" width="16" align="middle" border="0"></a>
                                                    <a onclick="ozoom.style.zoom='100%';" href="javascript:;">默认<img height="16" src="image/zoomact.gif"
                                                        width="16" align="middle" border="0" /></a> &nbsp;<span id="readTxtQY" style="display: inline"><a
                                                            onclick="readTxt();" href="javascript:;">朗读<img height="16" src="image/soundon.gif"
                                                                width="16" align="middle" border="0" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <!----------文章部分开始---------->
                                        <div style="height: 800px; overflow-y: scroll; width: 100%;">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin: 10px 0;"
                                                class="wz">
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                                            <tbody>
                                                                <tr valign="top">
                                                                    <td class="font02" align="center" style="color: #827E7B;">
                                                                        <!--<npm:article-pretitle>-->
                                                                        <asp:Label ID="LbYT" runat="server" EnableViewState="False"></asp:Label>
                                                                        <!--</npm:article-pretitle>-->
                                                                    </td>
                                                                </tr>
                                                                <tr valign="top">
                                                                    <td class="font01" align="center" style="color: #000000;">
                                                                        <founder-title>
                                                                        <!--<npm:article-title>--><asp:Label ID="LbBT" runat="server" EnableViewState="False"></asp:Label><!--</npm:article-title>-->
                                                                        </founder-title>
                                                                    </td>
                                                                </tr>
                                                                <% if (ArticleModel.FB != "")
                                                                   { %>
                                                                <tr valign="top">
                                                                    <td class="font02" align="center" style="color: #827E7B;">
                                                                        <!--<npm:article-subtitle>-->
                                                                        <asp:Label ID="LbFB" runat="server" EnableViewState="False"></asp:Label>
                                                                        <!--</npm:article-subtitle>-->
                                                                    </td>
                                                                </tr>
                                                                <%} %>
                                                                <% if (ArticleModel.ZZ != "")
                                                                   { %>
                                                                <tr valign="top">
                                                                    <td class="font02" align="center">
                                                                        <founder-author>
                                                                        <!--<npm:article-author>--><asp:Label ID="LbZZ" runat="server" EnableViewState="False"></asp:Label><!--</npm:article-author>-->
                                                                    </founder-author>
                                                                    </td>
                                                                </tr>
                                                                <%} %>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="padding: 10px 20px;">
                                                        <% if (ArticleModel.CTList.Count > 0)
                                                           { %>
                                                        <table id="newspic" bgcolor="#efefef">
                                                            <tr>
                                                                <td>
                                                                    <table>
                                                                        <tbody>
                                                                            <% foreach (PM.Model.MDL_CTInfo CTmodel in ArticleModel.CTList)
                                                                               {
                                                                                   string ctUrl = "../Resource/getResource.aspx?paperID=" + ArticleModel.paperID + "&RQ=" + ArticleModel.RQ + "&BC=" + ArticleModel.BC + "&type=3" + "&fileName=" + CTmodel.fileName + "&w=500&h=500";
                                                                                   string ts = "";
                                                                                   if (CTmodel.TZ != "") ts = "作者：(" + CTmodel.TZ + ")&nbsp;&nbsp;&nbsp;";
                                                                                   ts += CTmodel.TS;
                                                                            %>
                                                                            <tr>
                                                                                <td>
                                                                                    <!--<npm:article-pic>-->
                                                                                    <img alt="" src="<%=ctUrl %>" />
                                                                                    <!--</npm:article-pic>-->
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <!--<npm:article-pic-text>-->
                                                                                    <%=ts%>
                                                                                    <!--</npm:article-pic-text>-->
                                                                                </td>
                                                                            </tr>
                                                                            <%} %>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%} %>
                                                        <div id="ozoom" style="zoom: 100%; float: left;" class="content">
                                                            <founder-content>
                                                            <!--<npm:article-content>-->
                                                            <asp:Label ID="LbTX" runat="server" EnableViewState="False"></asp:Label>
                                                            　　<!--</npm:article-content>-->
                                                            </founder-content>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!----------文章部分结束---------->
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top: #787878 1px solid;" height="30">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="26%">
                                                    <table width="100%" border="0">
                                                        <tr>
                                                            <td nowrap width="50%" class="px12">
                                                                <asp:HyperLink ID="HLinkPreArticle2" title="转到本版的上一篇报道" runat="server">
                                                                <span style="font-size: 12px;font-family: webdings;">3</span>上一篇</asp:HyperLink>
                                                            </td>
                                                            <td nowrap width="50%" class="px12">
                                                                <asp:HyperLink ID="HLinkNextArticle2" title="转到本版的下一篇报道" runat="server">下一篇 <span style='font-size: 12px; font-family: webdings'>
                                                                    4</span></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="74%" align="right" style="padding-top: 5px">
                                                    <asp:HyperLink ID="HLinkArticleSC2" title="收藏本篇报道" runat="server" EnableViewState="False">收藏</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkTJ2" title="将本篇报道推荐给他人" runat="server" EnableViewState="False">推荐</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkTJB2" title="将本篇报道加入剪报中" runat="server" EnableViewState="False">剪报</asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkMyOpus2" title="将本篇报道放入我的作品中" runat="server" EnableViewState="False">作品</asp:HyperLink>&nbsp;&nbsp;
                                                    <a onclick="zoomIn();" href="javascript:;">放大<img height="16" src="image/zoomin.gif"
                                                        width="16" align="middle" border="0" /></a> <a onclick="zoomOut();" href="javascript:;">
                                                            缩小<img height="16" src="image/zoomout.gif" width="16" align="middle" border="0" /></a>
                                                    <a onclick="ozoom.style.zoom='100%';" href="javascript:;">默认<img height="16" src="image/zoomact.gif"
                                                        width="16" align="middle" border="0"></a> &nbsp;<span id="Span1" style="display: inline"><a
                                                            onclick="readTxt();" href="javascript:;">朗读<img height="16" src="image/soundon.gif"
                                                                width="16" align="middle" border="0" border="0" /></a></span>
                                                </td>
                                            </tr>
                                        </table>
                                        <iframe name="TTSPlayeriframe" id="TTSPlayeriframe" height="0" width="0" border="0"
                                            frameborder="0" src="framepage/TTSPost.htm"></iframe>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" height="15">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="line-height: 120%">
                <uc1:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
    <div id="float">
    </div>
    <!-------bmdh版面导航------>
    <div id="bmdh" onmouseover="document.getElementById('bmdh').style.display = 'block';"
        onmouseout="document.getElementById('bmdh').style.display = 'none';">
        <table width="200px" border="0" cellpadding="2" cellspacing="0" bgcolor="#FFFFFF">
            <tbody>
                <asp:Repeater ID="rptBMShowList" runat="server" EnableViewState="False" OnItemDataBound="rptBMShowList_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="this.className = 'commonlight2'" onmouseout="this.className = 'commonlight3'">
                            <td align="left" height="24" style="padding-left: 15px">
                                <asp:HyperLink ID="HLinkBT" runat="server" Text="第01版：一版要闻" EnableViewState="False"></asp:HyperLink>
                                <asp:HiddenField ID="HidBC" runat="server" Value='<%#Eval("BC") %>' EnableViewState="False" />
                                <asp:HiddenField ID="HidBM" runat="server" Value='<%#Eval("BM") %>' EnableViewState="False" />
                                <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                            </td>
                            <td width="20" align="middle" nowrap>
                                <asp:HyperLink ID="HLinkPDFDown" runat="server" Target="_blank" EnableViewState="False"><img height="16" src="image/pdf.gif" width="16" border="0"></asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <!-------bmdh版面导航END------>
    <!---------------------------标题导航-------------->
    <div id="btdh" onmouseover="document.getElementById('btdh').style.display = 'block';"
        onmouseout="document.getElementById('btdh').style.display = 'none';">
        <table border="0" cellpadding="2" cellspacing="0" bgcolor="#FFFFFF" width="277">
            <tbody>
                <asp:Repeater ID="rptTitleShowList" runat="server" EnableViewState="False" OnItemDataBound="rptTitleShowList_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmouseover="this.className = 'commonlight2'" onmouseout="this.className = 'commonlight3'">
                            <td height="27" style="padding-left: 15px">
                                <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False"></asp:HyperLink>
                                <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <!---------------------------标题导航 END -------------->
    </div>
    </form>
</body>
</html>
