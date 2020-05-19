<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tree.aspx.cs" Inherits="User.Web.UserDepartManage.Tree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../MzTreeView10/MzTreeView10.js"></script>

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
            font-size: 12px;
        }
        .hide
        {
            display: none;
        }
        .message
        {
            color: Red;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="left" style=" padding-top: 5px;">
        <!--展现树的地方-->

        <script language="javascript" type="text/javascript"> 
        var t = new MzTreeView("t");    
        t.setIconPath("../MzTreeView10/"); //可用相对路径    
        t.setURL("UserList.aspx");
        t.setTarget("ifUserShow");
        <%=nodeStr%>   
        </script>

    </div>
    </form>
</body>
</html>
<script  language="javascript" type="text/javascript">
    function SetParentIframSize() {
        window.parent.document.getElementById("iftreeShow").style.height = document.body.scrollHeight + 50;
    }
    setTimeout("SetParentIframSize()", 1);
</script>
