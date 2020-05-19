<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchRetList.aspx.cs"
    Inherits="PU.web.Search.searchRetList" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>检索结果</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="../css/tabStyle.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script type="text/javascript">
        //Set the id names of your tablink (without a number at the end)
        var tablink_idname = new Array("tablink")
        //Set the id name of your tabcontentarea (without a number at the end)
        var tabcontent_idname = new Array("tabcontent")
        //Set the number of your tabs
        var tabcount = new Array("2")
        //Set the Tab wich should load at start (In this Example:Tab 1 visible on load)
        var loadtabs = new Array("1")
        //Set the Number of the Menu which should autochange (if you dont't want to have a change menu set it to 0)
        var autochangemenu = 0;
        //the speed in seconds when the tabs should change
        var changespeed = 3;
        //should the autochange stop if the user hover over a tab from the autochangemenu? 0=no 1=yes
        var stoponhover = 1;
        //END MENU SETTINGS

        /*Swich EasyTabs Functions - no need to edit something here*/
        function easytabs(menunr, active) { if (menunr == autochangemenu) { currenttab = active; } if ((menunr == autochangemenu) && (stoponhover == 1)) { stop_autochange() } else if ((menunr == autochangemenu) && (stoponhover == 0)) { counter = 0; } menunr = menunr - 1; for (i = 1; i <= tabcount[menunr]; i++) { document.getElementById(tablink_idname[menunr] + i).className = 'tab' + i; document.getElementById(tabcontent_idname[menunr] + i).style.display = 'none'; } document.getElementById(tablink_idname[menunr] + active).className = 'tab' + active + ' tabactive'; document.getElementById(tabcontent_idname[menunr] + active).style.display = 'block'; } var timer; counter = 0; var totaltabs = tabcount[autochangemenu - 1]; var currenttab = loadtabs[autochangemenu - 1]; function start_autochange() { counter = counter + 1; timer = setTimeout("start_autochange()", 1000); if (counter == changespeed + 1) { currenttab++; if (currenttab > totaltabs) { currenttab = 1 } easytabs(autochangemenu, currenttab); restart_autochange(); } } function restart_autochange() { clearTimeout(timer); counter = 0; start_autochange(); } function stop_autochange() { clearTimeout(timer); counter = 0; }

        //window.onload=function(){
        //var menucount=loadtabs.length; var a = 0; var b = 1; do {easytabs(b, loadtabs[a]);  a++; b++;}while (b<=menucount);
        //if (autochangemenu!=0){start_autochange();}
        //}

        function loadTab() {
            var menucount = loadtabs.length; var a = 0; var b = 1; do { easytabs(b, loadtabs[a]); a++; b++; } while (b <= menucount);
            if (autochangemenu != 0) { start_autochange(); }
        }

        /*显示全部*/
        function showAll() {
            $("#HidGroupType").val("PT");
            //$("#BtRef").click();
            document.getElementById("BtRefGoFirst").click();
        }

        /*显示年份分组
        year：要显示的年份
        */
        function showYear(year) {
            $("#HidGroupType").val("year");
            $("#HidGroupValue").val(year);
            //$("#BtRef").click();
            document.getElementById("BtRefGoFirst").click();
        }

        /*显示报纸分组
        paperID：要显示的报纸ID
        */
        function showPaper(paperID) {
            //alert(paperID);
            $("#HidGroupType").val("paper");
            $("#HidGroupValue").val(paperID);
            //$("#BtRef").click();
            document.getElementById("BtRefGoFirst").click();
        }

        


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtRef" runat="server" Text="刷新" CssClass="hide" OnClick="BtRef_Click" />
        <asp:Button ID="BtRefGoFirst" runat="server" Text="刷新到第一页" CssClass="hide" OnClick="BtRefGoFirst_Click" />
        <asp:HiddenField ID="HidTJ" runat="server" />
        <asp:HiddenField ID="HidGroupType" runat="server" Value="PT" />
        <asp:HiddenField ID="HidGroupValue" runat="server" />
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
                <td valign="top">
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
                                                        <span class="mo_title_l31">检索结果</span>
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
                    <table width="99%" border="0" align="center" cellpadding="5" cellspacing="0">
                        <tr>
                            <td valign="top" width="200">
                                <!-- 时光隧道 -->
                                <div class="tabmenus">
                                    <ul>
                                        <li><a href="#" onmousedown="easytabs('1', '1');" onfocus="easytabs('1', '1');" onclick="return false;"
                                            title="" id="tablink1">报纸分类</a></li>
                                        <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                                            title="" id="tablink2">时光隧道</a></li>
                                    </ul>
                                </div>
                                <div id="tabcontent1" class="tabcontent">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left" height="20">
                                                <div style="height: 18px; width: 100%; margin-top: 12px;">
                                                    <a href="javascript:showAll();">全部(<%=totalRowSL%>)</a></div>
                                                <% string title = "";
                                                    foreach (DataRow row in paper_dt.Rows)
                                                    {
                                                        int paperID = int.Parse(row["paperID"].ToString());
                                                        string paperName = getPaperName(paperID);
                                                        int sl = int.Parse(row["rowSL"].ToString());
                                                        string showName = paperName + "(" + sl.ToString() + ")";
                                                        title = paperName + "(" + PercenShow(sl).ToString("0.00") + "%)";
                                                        
                                                %>
                                                <div style="height: 18px; width: 100%; margin-top: 12px;">
                                                    <a href="javascript:showPaper(<%=paperID %>);" title="<%=title %>">
                                                        <%=showName%></a></div>
                                                <div style="background-color: #00CCFF; height: 5px; margin-top: -2px; width: <%=Percen(sl)%>%;">
                                                </div>
                                                <%  } %>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="tabcontent2" class="tabcontent">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left" height="20">
                                                <div style="height: 18px; width: 100%; margin-top: 12px;">
                                                    <a href="javascript:showAll();">全部(<%=totalRowSL%>)</a></div>
                                                <% 
                                                    foreach (DataRow row in year_dt.Rows)
                                                    {
                                                        int year = int.Parse(row["year"].ToString());
                                                        int sl = int.Parse(row["rowSL"].ToString());
                                                        string showName = year + "年" + "(" + sl.ToString() + ")";
                                                        title = year.ToString() + "年(" + PercenShow(sl).ToString("0.00") + "%)";
                                                %>
                                                <div style="height: 18px; width: 100%; margin-top: 12px;">
                                                    <a href="javascript:showYear(<%=year %>);" title="<%=title %>">
                                                        <%=showName%></a>
                                                </div>
                                                <div style="background-color: #00CCFF; height: 5px; margin-top: -2px; width: <%=Percen(sl)%>%;">
                                                </div>
                                                <%
                                                    DataTable yearMonthTemp_dt = getYearMonthInfoList(year);
                                                    foreach (DataRow rowMonth in yearMonthTemp_dt.Rows)
                                                    {
                                                        int yearMonth = int.Parse(rowMonth["yearMonth"].ToString());
                                                        sl = int.Parse(rowMonth["rowSL"].ToString());
                                                        title = year.ToString() + "年" + yearMonth.ToString().Substring(4, 2) + "月(" + PercenShow(sl).ToString("0.00") + "%)";
                                                        showName = yearMonth.ToString().Substring(4, 2) + "月" + "(" + sl.ToString() + ")";
                                                %>
                                                <div style="height: 18px; width: 100%; margin-top: 12px;">
                                                    &nbsp;<a href="javascript:showYear(<%=yearMonth %>);" title="<%=title %>">
                                                        <%=showName%></a>
                                                </div>
                                                <div style="background-color: #00CCFF; height: 3px; margin-top: -2px; width: <%=Percen(sl)%>%;"></div>
                                                <% }
                                                    } %>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!-- 时光隧道end -->
                            </td>
                            <td valign="top">
                                <!-- 结果列表 -->
                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                                    <tr>
                                        <td align="left">
                                            &nbsp;结果数（<asp:Label ID="LbRetTotalSL" runat="server" ForeColor="Red"></asp:Label>
                                            ） 搜索内容：<asp:Label ID="LbKeyWord" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" height="40">
                                            排序方式：<asp:DropDownList ID="DPListsearchRetOrder" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="DPListsearchRetOrder_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:Button ID="BtFavorites" runat="server" Text="收藏" CssClass="btn-btn01" OnClientClick="FavoritesFormList('tabRetList');return false;" />
                                            <asp:Button ID="BtRecommend" runat="server" Text="推荐" CssClass="btn-btn01" OnClientClick="RecommendFormList('tabRetList');return false;" />
                                            <asp:Button ID="BtClippingSend" runat="server" Text="剪报推送" CssClass="btn-btn01" OnClientClick="ClippingSendFormList('tabRetList');return false;" />
                                            <asp:Button ID="BtMyOpus" runat="server" Text="放入作品" CssClass="btn-btn01" OnClientClick="addOpusNewsInfoFormList('tabRetList');return false;" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="99%" id="tabRetList" border="0" align="center" cellpadding="0" cellspacing="1"
                                    bgcolor="#E4E4E4">
                                    <tr class="trTop">
                                        <td>
                                            选择
                                        </td>
                                        <td>
                                            标题
                                        </td>
                                        <td>
                                            作者
                                        </td>
                                        <td>
                                            报纸名
                                        </td>
                                        <td>
                                            日期
                                        </td>
                                        <td>
                                            版面
                                        </td>
                                        <td>
                                            版次
                                        </td>
                                        <td>
                                            版面文件
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" OnItemDataBound="rptRetList_ItemDataBound">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trData">
                                                <td style="background-color: #ffffe6;" align="center">
                                                    <input type="checkbox" id="ckbox" runat="server" value='<%#Eval("KID") %>' enableviewstate="False" />
                                                    <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                                </td>
                                                <td align="left" style="padding-left: 8px;">
                                                    <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False"></asp:HyperLink>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="LbZZ" runat="server" Text='<%#Eval("ZZ") %>' EnableViewState="False"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="LbMC" runat="server" Text='<%#Eval("MC") %>' EnableViewState="False"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="LbRQ" runat="server" Text='<%#Eval("RQ") %>' EnableViewState="False"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="LbBM" runat="server" Text='<%#Eval("BM") %>' EnableViewState="False"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="LbBC" runat="server" Text='<%#Eval("BC") %>' EnableViewState="False"></asp:Label>
                                                </td>
                                                <td valign="middle">
                                                    <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                                    <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                                                    <asp:HiddenField ID="HidpaperID" runat="server" Value='<%#Eval("paperID") %>' EnableViewState="False" />
                                                    <asp:HiddenField ID="HidBC" runat="server" Value='<%#Eval("BC") %>' EnableViewState="False" />
                                                    <asp:HyperLink ID="HLinkPD" runat="server" EnableViewState="False"><img src="../images/pdf01.gif"  title="下载版面PDF"/></asp:HyperLink>&nbsp;
                                                    <asp:HyperLink ID="HLinkJP" runat="server" EnableViewState="False"><img src="../images/jpg02.gif" title="下载版面JPG"/></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                                <!--结果列表end -->
                                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" height="40" style="font-size: 12px;">
                                            &nbsp;<a href="javascript:QX('tabRetList');">全选</a>&nbsp;<a href="javascript:FX('tabRetList');">反选</a>
                                        </td>
                                        <td align="right" height="40">
                                            <cc1:pageControl ID="pageControl1" runat="server" pageSize="20" OnClick="pageControl1_Click" />
                                        </td>
                                    </tr>
                                </table>
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

<script language="javascript" type="text/javascript">
    loadTab();
    var groupType = $("#HidGroupType").val();
    if (groupType == "PT") easytabs('1', '1');
    if (groupType == "paper") easytabs('1', '1');
    if (groupType == "year") easytabs('1', '2');
    
   

</script>

