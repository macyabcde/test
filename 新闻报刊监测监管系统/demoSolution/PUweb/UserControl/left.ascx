<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="PU.web.UserControl.left" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript" language="javascript">
<!--

    var argumentArr = new Array();
    function menuInit() {
        argumentArr = arguments;
        var menuID = "";
        var picDivID = "";
        var listDivID = "";
        for (var i = 0; i < argumentArr.length; i++) {
            menuID = argumentArr[i];
            picDivID = menuID + "_pic";
            listDivID = menuID + "_list";
            document.getElementById(picDivID).className = "mo_title_r2 btn_all_tiny_img";
            document.getElementById(listDivID).style.display = "none";
        }
    }

    function menuDivClick(ClickmenuID) {
        var menuID = "";
        var picDivID = "";
        var listDivID = "";
        console.log(ClickmenuID);
        for (var i = 0; i < argumentArr.length; i++) {
            menuID = argumentArr[i];
            if (ClickmenuID == menuID) continue;
            picDivID = menuID + "_pic";
            listDivID = menuID + "_list";
            document.getElementById(picDivID).className = "mo_title_r2 btn_all_tiny_img";
            document.getElementById(listDivID).style.display = "none";
        }
        picDivID = ClickmenuID + "_pic";
        listDivID = ClickmenuID + "_list";
        if (document.getElementById(picDivID).className == "mo_title_r1 btn_all_tiny_img") {
            console.log(11);
            document.getElementById(picDivID).className = "mo_title_r2 btn_all_tiny_img";
            document.getElementById(listDivID).style.display = "none";
        } else {
            console.log(22);
            document.getElementById(picDivID).className = "mo_title_r1 btn_all_tiny_img";
            document.getElementById(listDivID).style.display = "";
        }
    }

    var backcolor = "";
    function ListMouseOver(obj) {
        backcolor = obj.style.background;
        obj.style.background = "#E6E8EC"; //#E6E8EC
    }
    function ListMouseOut(obj) {
        obj.style.background = backcolor;
    }

    
//-->
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top" class="divcss5-1">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="32" align="left" background="../images/left_di_01.jpg">
                        &nbsp;&nbsp;&nbsp;<strong>系统菜单</strong> &nbsp;&nbsp;<img src="../images/tubiao01.gif"
                            width="16" height="16" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="wp_sidebar">
                            <div class="mo_wp" id="win1">
                                <div class="mo_title" onclick="menuDivClick('win1')">
                                    <div id="win1_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao02.gif" />
                                        &nbsp;&nbsp;报刊阅览</div>
                                </div>
                                <div id="win1_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper.aspx">党报系列</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao04.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper1.aspx">都市报系列</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao05.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper2.aspx">专业报系列</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao06.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper3.aspx">县市报系列</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper4.aspx">今日系列</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper5.aspx">中央及省外报刊</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper6.aspx">企业报刊</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../PaperLook/groupPaper7.aspx">其他报刊</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win2">
                                <div class="mo_title" onclick="menuDivClick('win2')">
                                    <div id="win2_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao07.gif" width="16" height="16" />
                                        &nbsp;&nbsp;舆情检索</div>
                                </div>
                                <div id="win2_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao50.gif" width="16" height="16" />&nbsp;<a
                                                    href="../Search/scriptureInput.aspx">经典检索</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao10.gif" width="16" height="16" />&nbsp;<a
                                                    href="../Search/andInput.aspx">而且检索</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao16.gif" width="16" height="16" />&nbsp;<a
                                                    href="../Search/orInput.aspx">或者检索</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao08.gif" width="16" height="16" />&nbsp;<a
                                                    href="../Search/fxInput.aspx">分项检索</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win4">
                                <div class="mo_title" onclick="menuDivClick('win4')">
                                    <div id="win4_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao12.gif" width="16" height="16" />
                                        &nbsp;&nbsp;我的资料</div>
                                </div>
                                <div id="win4_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao03.gif" width="16" height="16" />&nbsp;<a
                                                    href="../MyInformation/paperCollectionList.aspx">报纸收藏</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao13.gif" width="16" height="16" />&nbsp;<a
                                                    href="../MyInformation/BMCollectionList.aspx">版面收藏</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao51.gif" width="16" height="16" />&nbsp;<a
                                                    href="../MyInformation/newsCollectionInex.aspx">报道收藏</a>
                                            </td>
                                        </tr>
                                        <% foreach (DataRow row in scType_dt.Rows)
                                           {
                                               string newsCollectionTypeID = row["newsCollectionTypeID"].ToString();
                                               string collectionTypeName = row["collectionTypeName"].ToString();
                                        %>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)"
                                                style="font-style: italic;">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../MyInformation/newsCollectionInex.aspx?newsCollectionTypeID=<%=newsCollectionTypeID %>"><%=collectionTypeName%></a>
                                            </td>
                                        </tr>
                                        <%} %>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao16.gif" width="16" height="16" />&nbsp;<a
                                                    href="../MyInformation/newsRecommendInfoList.aspx">推荐报道</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win5">
                                <div class="mo_title" onclick="menuDivClick('win5')">
                                    <div id="win5_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao07.gif" width="16" height="16" />
                                        &nbsp;&nbsp;文章评分评论</div>
                                </div>
                                <div id="win5_list" class="mo_con" style="display: none;">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao50.gif" width="16" height="16" />&nbsp;<a
                                                    href="/articlepingfen.aspx">文章评分</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao10.gif" width="16" height="16" />&nbsp;<a
                                                    href="/articlepinglun.aspx">文章评论</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win8">
                                <div class="mo_title" onclick="menuDivClick('win8')">
                                    <div id="win8_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao08.gif" width="16" height="16" />
                                        &nbsp;&nbsp;数字剪报扩展</div>
                                </div>
                                <div id="win8_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao33.gif" width="16" height="16" />&nbsp;<a
                                                    href="../pressClipping/pressClippingList.aspx">剪报制作</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao19.gif" width="16" height="16" />&nbsp;<a
                                                    href="../pressClipping/pressClippingSPList.aspx">剪报审批</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao50.gif" width="16" height="16" />&nbsp;<a
                                                    href="../pressClipping/pressClippingSearchList.aspx">剪报查询</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win9">
                                <div class="mo_title" onclick="menuDivClick('win9')">
                                    <div id="win9_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao08.gif" width="16" height="16" />
                                        &nbsp;&nbsp;报刊版面交流</div>
                                </div>
                                <div id="win9_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao33.gif" width="16" height="16" />&nbsp;<a
                                                    href="/pagestudy.aspx">版式比对</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="mo_wp" id="win10">
                                <div class="mo_title" onclick="menuDivClick('win9')">
                                    <div id="win10_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao18.gif" width="16" height="16" />
                                        &nbsp;&nbsp;<a href="../UserManage/other/index.aspx" target="_blank">系统管理</a></div>
                                </div>
                                <div id="win10_list" class="mo_con">
                                </div>
                            </div>
                        </div>
                        <%--<div class="mo_wp" id="win6">
                                <div class="mo_title" >
                                    <div id="win6_pic" class="mo_title_r1 btn_all_tiny_img">
                                    </div>
                                    <div class="mo_title_l">
                                        &nbsp;<img src="../images/tubiao09.gif" width="16" height="16" />
                                        &nbsp;&nbsp;报刊最新动态</div>
                                </div>
                                <div id="win6_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        
                                    </table>
                                </div>
                            </div>--%>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script language="javascript" type="text/javascript">
<!--


    menuInit('win1', 'win2', 'win4','win9');
    
    var win1 = "groupPaper.aspx,groupPaper1.aspx,groupPaper2.aspx,groupPaper3.aspx,groupPaper4.aspx,groupPaper5.aspx,groupPaper6.aspx,groupPaper7.aspx";
    var win2 = "scriptureInput.aspx,andInput.aspx,orInput.aspx,fxInput.aspx,searchRetList.aspx";
//    var win3 = "opusNewsList.aspx";
    var win4 = "paperCollectionList.aspx,BMCollectionList.aspx,newsCollectionInex.aspx,newsRecommendInfoList.aspx";
//    var win5 = "pressClippingList.aspx,pressClippingSPList.aspx,pressClippingSearchList.aspx";
    //var win6 = "CustomerBasisInfoList.aspx";
    var fileName = <%=fileName %>;
    var openObjID="win1";
    if(win1.indexOf(fileName)>-1) openObjID="win1";
    if(win2.indexOf(fileName)>-1) openObjID="win2";
//    if(win3.indexOf(fileName)>-1) openObjID="win3";
    if(win4.indexOf(fileName)>-1) openObjID="win4";
//    if(win5.indexOf(fileName)>-1) openObjID="win5";
    //if(win9.indexOf(fileName)>-1) openObjID="win9";
    menuDivClick(openObjID);
    
    var fileNameAndQuery=<%=fileNameAndQuery%>;
    
    var str="";
    var tempName = "";
    var ifbreak = false;
    $("div[class='mo_con'] table tr td").each(function(i, j) {
        if (!ifbreak) {
            str = $(this).html();
            if (str.indexOf("newsCollectionInex.aspx") > 0)
                tempName = fileNameAndQuery;
            else
                tempName = fileName;
            if (str.indexOf(tempName) > 0) {
                $(this).css({ background: "#E6E8EC" });
                ifbreak = true;
            }
        }
    })
    
   
   
 //-->   
</script>
