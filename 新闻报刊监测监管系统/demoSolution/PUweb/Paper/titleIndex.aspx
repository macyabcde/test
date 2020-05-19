<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleIndex.aspx.cs" Inherits="PU.web.Paper.titleIndex" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/calendar.css" rel="stylesheet" type="text/css" />

    <script language="Javascript" src="js/excanvas.compiled.js"></script>

    <script language="Javascript" src="js/jquery-1.3.2.min.js"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script type="text/javascript">
        var JQ = $;
        var dateHtml = "<%=dateHtml %>";
    </script>

    <script language="Javascript" src="js/highlight.js" type="text/javascript"></script>

    <script src="js/paper.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <style type="text/css">
        <!
        -- body
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
        -- ></style>
</head>
<span id="leveldiv" title="点击查看内容" style="border-top-width: 0px; border-left-width: 0px;
    z-index: 100; left: 233px; border-bottom-width: 0px; width: 210px; cursor: hand;
    position: absolute; top: 123px; height: 34px; border-right-width: 0px"></span>
<body text="#000000" vlink="#000000" alink="#ff0000" link="#000000" leftmargin="0"
    topmargin="0" marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="1002" align="center" border="0" background="image/bg.jpg">
        <tr>
            <td align="right" valign="top">
                <table height="115" cellspacing="0" cellpadding="0" width="1001" border="0">
                    <tr>
                        <td height="130" colspan="4" align="right" valign="bottom" class="menu">
                            <table width="609" height="130" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" valign="bottom" background="image/<%=paperID %>.jpg" class="menu">
                                        <span id="goIndexSpan"><a href="BMList.aspx?paperID=<%=paperID %>&RQ=<%=RQ %>">今日头版</a>
                                            |</span> <span id="goTilePageSpan"><span id="bmdhSpan" onmouseover="document.getElementById('bmdh').style.display = 'block';setbmdh();"
                                                onmouseout="document.getElementById('bmdh').style.display = 'none';"><a href="javascript:;">
                                                    版面导航</a></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="left" valign="middle" style="padding-left: 25px;">
                            <asp:Label ID="LbRQ" runat="server" Text="2011年05月24日 星期二 出版" CssClass="default"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td width="35%" align="center" valign="middle">
                            <span id="searchQY" style="display: block">
                                <asp:TextBox ID="txtKeyWord" runat="server" 
                                Style="height: 20px; width: 140" EnableViewState="False"></asp:TextBox>&nbsp;
                                <input id="BtSearch" type="button" value="搜索" onclick="searchWord('<%=paperID %>');" style="height: 20px;" title="全文搜索您输入的关键词" /></span>
                        </td>
                        <td width="25%" align="right" valign="middle" style="padding-right: 25px;">
                            <span id="upqi">
                                <img src="image/image01.jpg"><asp:HyperLink ID="HLinkPreRQ" 
                                title="转到上一个出版日期" runat="server" EnableViewState="False">上一期</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink
                                    ID="HLinkNetRQ" title="转到下一个出版日期" runat="server" 
                                EnableViewState="False">下一期</asp:HyperLink><img src="image/image02.jpg"
                                        width="5" height="9"></span>
                        </td>
                    </tr>
                </table>
                <table width="1001" height="507" border="0" cellpadding="0" cellspacing="0">
                    <tr valign="top">
                        <td rowspan="4" align="center">
                            <table cellspacing="0" cellpadding="5" width="50%" border="0">
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                            <table width="96%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top" style="padding-left: 25px;">
                                        <% foreach (DataRow bmRow in BM_dt.Rows)
                                           {
                                               string bc = bmRow["BC"].ToString();
                                        %>
                                        <table width="710" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;
                                            border: 1px solid #9D9C77;">
                                            <tr>
                                                <td width="678" height="24" background="image/image04.jpg">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td style="padding-left: 3px; font-size: 14px; font-weight: bold;">
                                                                <font color="#333333">&nbsp;第<%=bc%>版 :<%=bmRow["BM"].ToString() %></font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#FFFFFF">
                                                <td>
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="3">
                                                        <tr bgcolor="#D4D3B1">
                                                            <td width="12" align="center" bgcolor="#D4D3B1">
                                                                &nbsp;
                                                            </td>
                                                            <td bgcolor="#D4D3B1">
                                                                标题
                                                            </td>
                                                            <td align="center">
                                                                时间
                                                            </td>
                                                        </tr>
                                                        <%
                                                            DataTable dt = getArticleList(bc);
                                                            foreach (DataRow row in dt.Rows)
                                                            {
                                                                string KID = row["KID"].ToString();
                                                                string date = PubTool.Convert.intToDateStr(int.Parse(row["RQ"].ToString()));
                                                        %>
                                                        <tr bgcolor="#EEEEDF">
                                                            <td align="center" bgcolor="#EEEEDF">
                                                                <span style="font-size: 12px;">·</span>
                                                            </td>
                                                            <td style="display: inline">
                                                                <a href="ArticlePage.aspx?KID=<%=KID%>">
                                                                    <%=row["BT"].ToString() %></a>
                                                            </td>
                                                            <td width="100" align="center" bgcolor="#EEEEDF">
                                                                <%=date %>
                                                            </td>
                                                        </tr>
                                                        <%} %>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%} %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="10" rowspan="4" align="center">
                        </td>
                        <td width="200" height="115" align="center">
                            <table cellspacing="0" cellpadding="0" width="200" border="0" style="margin-top: 10px">
                                <tr>
                                    <td background="image/bg-2.gif" class="default" style="padding-right: 3px; padding-left: 3px;
                                        padding-bottom: 3px; padding-top: 3px; border: #d2d2d2 1px solid;">
                                        <div align="center">
                                            <strong class="whitenav"><font style="font-size: 13px;">按日期查阅</font></strong></div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <table width="200" height="100" border="0" cellpadding="0" cellspacing="0" style="border: #d2d2d2 1px solid;
                                            border-top: none;">
                                            <tr>
                                                <td height="33" colspan="2" align="left" bgcolor="#FFFFFF">
                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1">
                                                                    <tr class="default" align="center">
                                                                        <td height="15" colspan="7" bgcolor="#FFFFFF">
                                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                                <tr align="center">
                                                                                    <td align="right" nowrap>
                                                                                        <img src="image/d1.gif" width="7" height="11" style="cursor: hand;" onclick="turnpage(DpListYear,0)">
                                                                                    </td>
                                                                                    <td width="50">
                                                                                        <asp:DropDownList ID="DpListYear" runat="server" EnableViewState="False">
                                                                                            <asp:ListItem>2012</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <img src="image/d.gif" width="7" height="11" style="cursor: hand;" onclick="turnpage(DpListYear,1)">
                                                                                    </td>
                                                                                    <td align="right" nowrap>
                                                                                        <img src="image/d1.gif" width="7" height="11" style="cursor: hand;" onclick="turnpage(DpListMonth,0)">
                                                                                    </td>
                                                                                    <td width="40">
                                                                                        <asp:DropDownList ID="DpListMonth" runat="server" EnableViewState="False">
                                                                                            <asp:ListItem>11</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <img src="image/d.gif" width="7" height="11" style="cursor: hand;" onclick="turnpage(DpListMonth,1)">
                                                                                    </td>
                                                                                    <td align="right" nowrap>
                                                                                        <font id="GZ" face="Arial, Helvetica, sans-serif"></font>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="middle" bgcolor="#e8e8e8" class="default">
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">日</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">一</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">二</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">三</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">四</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">五</font></b>
                                                                        </td>
                                                                        <td align="center" class="default">
                                                                            <b><font face="Arial, Helvetica, sans-serif">六</font></b>
                                                                        </td>
                                                                    </tr>

                                                                    <script language="JavaScript">
		<!--
                                                                        //                                                                        var gNum;
                                                                        //                                                                        for (i = 0; i < 6; i++) {
                                                                        //                                                                            document.write('<tr align=center>');
                                                                        //                                                                            for (j = 0; j < 7; j++) {
                                                                        //                                                                                gNum = i * 7 + j;
                                                                        //                                                                                document.write('<td bgcolor="#EFF3F7" class="default" align="center" width="14%"><a href="#"  style="font-family:Verdana, Arial;font-size:11px;">' + gNum);
                                                                        //                                                                                document.write('</a><br></td>');
                                                                        //                                                                            }
                                                                        //                                                                            document.write('</tr>');
                                                                        //                                                                        }

                                                                        var gNum = 0;
                                                                        for (i = 0; i < 6; i++) {
                                                                            document.write('<tr align=center>');
                                                                            for (j = 0; j < 7; j++) {

                                                                                document.write('<td bgcolor="#EFF3F7"  align="center" id="date' + gNum + '"><span class=" calendardateNot">&nbsp;</span></td>');
                                                                                gNum++;
                                                                            }
                                                                            document.write('</tr>');
                                                                        }

                                                                        
		//-->
                                                                    </script>

                                                                </table>
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
                        <td width="35" rowspan="4" align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <img src="image/jwb_red_r1_c1.jpg" width="0" height="1" id="logoImg">
            </td>
        </tr>
        <tr>
            <td height="15">
            </td>
        </tr>
        <tr>
            <td align="center" style="line-height: 120%; color: #FFFFFF;">
                <uc1:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
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

    </form>
</body>
</html>

<script type="text/javascript">

    setCalendarForValue(dateHtml);
    
</script>
