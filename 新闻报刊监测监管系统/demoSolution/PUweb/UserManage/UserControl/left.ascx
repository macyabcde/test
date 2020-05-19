<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="User.Web.UserControl.left" %>


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
            document.getElementById(picDivID).className = "mo_title_r2 btn_all_tiny_img";
            document.getElementById(listDivID).style.display = "none";
        } else {
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
                                        &nbsp;<img src="../images/tubiao18.gif" width="16" height="16" />
                                        &nbsp;&nbsp;系统管理</div>
                                </div>
                                <div id="win1_list" class="mo_con">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao19.gif" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                    href="../partManage/partList.aspx">角色管理</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao20.gif" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                    href="../UserDepartManage/UserManage.aspx">用户管理</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao21.gif" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                    href="#" onclick="UserPwdEdit();">密码修改</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" onmouseover="ListMouseOver(this)" onmouseout="ListMouseOut(this)">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<img src="../images/tubiao22.gif" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                    href="#" onclick="UserInfoEdit();">个人信息</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<script language="javascript" type="text/javascript">

    menuInit('win1');
    
    var win1 = "partList.aspx,UserManage.aspx";
    
    var fileName = <%=fileName %>;
    var openObjID="win1";
   if(win1.indexOf(fileName)>-1) openObjID="win1";
   
    menuDivClick(openObjID);
    
    var fileNameAndQuery=<%=fileNameAndQuery%>;
    
    var str = "";
    var tempName = "";
    var ifbreak = false;
    $("div[class='mo_con'] table tr td").each(function(i, j) {
        if (!ifbreak) {
            str = $(this).html();
            tempName = fileName;
            if (str.indexOf(tempName) > 0) {
                $(this).css({ background: "#E6E8EC" });
                ifbreak = true;
            }
        }
    })
    
    
</script>