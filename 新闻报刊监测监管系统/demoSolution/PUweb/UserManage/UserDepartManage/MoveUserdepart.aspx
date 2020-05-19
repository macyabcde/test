<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoveUserdepart.aspx.cs"
    Inherits="User.Web.UserDepartManage.MoveUserdepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户调动</title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../MzTreeView10/MzTreeView10.js" type="text/javascript"></script>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <style type="text/css">
        
        A:link
        {
            color: #333333;
            text-decoration: none;
            font-family: Tahoma;
            font-size: 12px;
        }
        A:visited
        {
            color: #333333;
            text-decoration: none;
            font-family: Tahoma;
            font-size: 12px;
        }
        A:hover
        {
            color: #BD0013;
            text-decoration: underline;
            font-family: Tahoma;
        }
    </style>
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
                                    <td width="176">
                                        <asp:Label ID="lbwhatDo" runat="server" Text="用户调动"></asp:Label>
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
    <table width="400" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr height="5px">
        </tr>
        <tr>
            <td class="style1" height="500px" align="left" valign="top">
                <script type="text/javascript" language="JavaScript" > 
			        var t = new MzTreeView("t");    
			        t.setIconPath("../MzTreeView10/"); //可用相对路径    
			        t.colors={
                        "highLight" : "red",
                        "highLightText" : "black",
                        "mouseOverBgColor" : "#D4D0C8"
                     };
		            <%=nodeStr%>
                </script>

            </td>
        </tr>
        <tr>
            <td height="30" align="center">
                <asp:Button ID="btnFinish" runat="server" Text="保存" OnClick="btnFinish_Click" CssClass="btn-btn01" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFfatherID" runat="server" />
    <asp:HiddenField ID="HFdepartID" runat="server" />
    <asp:HiddenField ID="HFmoveToDeaprtID" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    var fatherID = document.getElementById("HFfatherID").value; //当前要移动的组织的上级组织ID
    var departID = document.getElementById("HFdepartID").value; //当前要调动用户所在的组织ID
    var moveToDeaprtIDObj = document.getElementById("HFmoveToDeaprtID"); //保存移动到的组织ID对象
    var node = null; //存储用户选择的要移动到的目标组织节点对象
    var oldNodeName = ""; //存储用户选择的要移动到的目标组织节点对象的名称
    var ifSelectOver = true; //判断选择要移动到的组织操作是否完成
    t.focus(departID);

    //初始化树，使当前要调动用户所在的组织的名称样式变为蓝色并加上“(用户所在原来的组织)”的文字信息
    //DepartID：当前要移动的组织ID
    function intItTree(departID) {
        var x = 0;
        $("body").find("a").each(function(i, j) {
            x++;
            //因为不知为何会找到两个满足条件的，所以加上 j.innerText != "" 就可以避免两次都满足
            if (j.href.getQuery("departID") == departID && j.innerText != "") {
                j.style.color = "blue";
                j.innerText = j.innerText + "(用户所在原来的组织)";
                //alert("bbff=" + j.innerText + " DepartID=" + j.href.getQuery("DepartID") + " x=" + x);
            }
        })
    }
    //树节点点击调用事件
    function SetTreeNodeURL(moveToDeaprtID) {
        //清空之前选择的组织ID
        moveToDeaprtIDObj.value = "";

        //还原之前选择"移动到此的节点"的样式
        if (ifSelectOver) {
            ifSelectOver = false; //避免联系选择，导致显示出错
            if (node != null) {
                node.innerText = oldNodeName;
            }
            //遍历树,修改"移动到此的节点"样式
            $("body").find("a").each(function(i, j) {


                if (j.href.getQuery("departID") == departID && j.innerText != "") {
                    j.style.color = "blue";
                }
                //因为不知为何会找到两个满足条件的，所以加上 j.innerText != "" 就可以避免两次都满足
                if (j.href.getQuery("departID") == moveToDeaprtID && j.innerText != "") {
                    if (moveToDeaprtID != departID) {
                        oldNodeName = j.innerText;
                        //nodeHref=j.href;
                        j.style.color = "red";
                        j.innerText = j.innerText + "(调动到此组织)";
                        node = j;
                        //记录目标组织ID
                        moveToDeaprtIDObj.value = moveToDeaprtID;
                    }
                    else if (moveToDeaprtID == departID) {
                        j.style.color = "blue";
                        alert("用户已在此组织！");
                    }
                }
            })
            ifSelectOver = true;
        }
    }

    setTimeout("intItTree(" + departID + ")", 200);  //初始化要移动的节点,加载树需要时间。控制好在树加载完后，初始化要移动的节点
    //setTimeout("SetTreeNodeURL('123','')",101);  //初始化要移动的节点,加载树需要时间。控制好在树加载完后，初始化要移动的节点

    //检测是否选择了目标部门
    function CheckIsSelect() {
        if (moveToDeaprtIDObj.value == "") {
            alert("请选择要调动到的组织！");
            return false;
        }
        return true;
    }
</script>

