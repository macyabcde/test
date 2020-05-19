<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaperSelect.ascx.cs"
    Inherits="PU.web.Search.PaperSelect" %>
<link href="../css/tabStyle.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    //Set the id names of your tablink (without a number at the end)
    var tablink_idname = new Array("tablink")
    //Set the id name of your tabcontentarea (without a number at the end)
    var tabcontent_idname = new Array("tabcontent")
    //Set the number of your tabs
    var tabcount = new Array("4")
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


    /*
    报纸复选框发生变化时，同进其它tab页的选择
    obj：当前发生变化的复选框对象
    */
    function checkChange(obj) {
        var ck = obj.checked;
        //alert(ck);
        var paperID = obj.value;
        $("#PaperList").find("input[CKpaperID=\"" + paperID + "\"]").each(function (i, j) {
            j.checked = ck;
        })
    }

    /*
    全选
    ID：范围ID
    */
    function selectAll(ID) {
        var paperID;
        var arr = new Array();
        for (var i = 0; i < 10000; i++) {
            arr[i] = -1;
        }
        $("#" + ID).find("input[type=\"checkbox\"]").each(function (i, j) {
            //j.checked = true;
            arr[j.value] = 1;
            //checkChange(j);
        })
        selectPaperWithArr(arr);
    }

    /*
    返选
    ID：范围ID
    */
    function selectFan(ID) {
        var arr = new Array();
        for (var i = 0; i < 10000; i++) {
            arr[i] = -1;
        }
        $("#" + ID).find("input[type=\"checkbox\"]").each(function (i, j) {
            if (j.checked)
                arr[j.value] = 0;
            else
                arr[j.value] = 1;
            //checkChange(j);
        })
        selectPaperWithArr(arr);
    }
    /*
    根据被选种的报纸ID数组将报纸打勾
    */
    function selectPaperWithArr(paperArr) {
        $("#PaperList").find("input[type=\"checkbox\"]").each(function (i, j) {
            if (paperArr[j.value] == 1) j.checked = true;
            if (paperArr[j.value] == 0) j.checked = false;
            //checkChange(j);
        })
    }

    /*
    获取所有选定的报纸ID串（ID可能会重复，程序中要再次处理过）
    obj：当前发生变化的复选框对象
    */
    function getSelectPaperIDStr() {
        var idStr = "";
        $("#PaperList").find("input[bj=\"CKpaperSelect\"]").each(function (i, j) {
            if (j.checked) idStr += j.value + ",";
        })
        if (idStr != "") idStr = idStr.substr(0, idStr.length - 1);
        return idStr;
    }

</script>
<table width="93%" id="PaperList" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div class="tabmenus">
                <ul>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="tablink2">报刊地域</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A1">党报系列</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A2">都市报系列</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A3">专业报系列</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A4">县市报系列</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A5">今日系列</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A6">中央及省外报刊</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"
                        title="" id="A7">企业报刊</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '3');" onfocus="easytabs('1', '3');" onclick="return false;"
                        title="" id="tablink3">其他报刊</a></li>
                    <li><a href="#" onmousedown="easytabs('1', '4');" onfocus="easytabs('1', '4');" onclick="return false;"
                        title="" id="tablink4">我的收藏</a></li>
                </ul>
            </div>
            <div id="tabcontent1" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <% for (int x = 0; x < dt_group.Rows.Count; x++)
                               {
                                   Response.Write(getCKboxHtml(dt_group.Rows[x], "CKBoxGroup"));
                               } %>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                            <a href="javascript:selectAll('tabcontent1');">全选</a>&nbsp;<a href="javascript:selectFan('tabcontent1');">反选</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tabcontent2" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <% 
                        PU.Model.MDL_PaperObj obj;
                        for (int i = 0; i < list_prv.Count; i++)
                        {
                            obj = list_prv[i];
                 
                    %>
                    <tr>
                        <td align="left" height="30">
                            <span style="color: #FF6600; cursor: pointer" onclick="selectFan('prv<%=obj.aID %>');">
                                <b>
                                    <%=obj.name %></b></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" id="prv<%=obj.aID %>">
                            <% for (int x = 0; x < obj.dt.Rows.Count; x++)
                               {
                                   Response.Write(getCKboxHtml(obj.dt.Rows[x], "CKBoxPrv"));
                               } %>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td align="left" height="30">
                            <a href="javascript:selectAll('tabcontent2');">全选</a>&nbsp;<a href="javascript:selectFan('tabcontent2');">反选</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tabcontent3" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <% 
                        for (int i = 0; i < list_type.Count; i++)
                        {
                            obj = list_type[i];
                 
                    %>
                    <tr>
                        <td align="left" height="30">
                            <span style="color: #FF6600; cursor: pointer" onclick="selectFan('type<%=obj.aID %>');">
                                <b>
                                    <%=obj.name %></b></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" id="type<%=obj.aID %>">
                            <% for (int x = 0; x < obj.dt.Rows.Count; x++)
                               {
                                   Response.Write(getCKboxHtml(obj.dt.Rows[x], "CKBoxType"));
                               } %>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td align="left" height="30">
                            <a href="javascript:selectAll('tabcontent3');">全选</a>&nbsp;<a href="javascript:selectFan('tabcontent3');">反选</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tabcontent4" class="tabcontent">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <% for (int x = 0; x < dt_SC.Rows.Count; x++)
                               {
                                   Response.Write(getCKboxHtml(dt_SC.Rows[x], "CKBoxSC"));
                               } %>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" height="30">
                            <a href="javascript:selectAll('tabcontent4');">全选</a>&nbsp;<a href="javascript:selectFan('tabcontent4');">反选</a>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
<br>
<br>
<script language="javascript" type="text/javascript">
    loadTab();

</script>
