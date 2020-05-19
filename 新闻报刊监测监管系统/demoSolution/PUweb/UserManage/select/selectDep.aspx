<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectDep.aspx.cs" Inherits="User.Web.select.selectDep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>部门选择</title>
    
    <link href="../css/SelectUserStyel.css" rel="stylesheet" type="text/css" />
    <script src="../MzTreeView10/MzTreeView10.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        //组织结构ID
        var selDepartID = "<%=selDepartID %>";
        //组织名称
        var selDepartName = "<%=selDepartName %>";

        //选择
        function select(DepartID, DepartName) {
            selDepartID = DepartID;
            selDepartName = DepartName;
        }
        
        //点击确定
        function OKreturn() {
            var ret = "";
            if (selDepartID != 0) ret = selDepartID + ";" + selDepartName
            window.returnValue = ret;
            window.close();
        }

        //点击取消
        function Close() {
            window.returnValue = "";
            window.close();
        }
    </script>    
 
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
       
    <div id="PageStyle" class="PageStyleDep"
    <div id="ContentOne" class="Content-tree">
    	<div id="left" class="tree-tree">
        	<div id="Ltop" class="Ltop-tree fontStyle1">
            	集团部门列表
            </div>
            <div id="Ltree" class="Ltree-tree scorllStyle">
           		<!--展现树的地方-->
                <script  language="javascript" type="text/javascript"> 
                     var t = new MzTreeView("t");    
                     t.setIconPath("../MzTreeView10/"); //可用相对路径    
                     <%=nodeStr%>   
	            </script>
            </div>
            <div id="botton" class="botton-tree">
            	<div class="btn-treeCenter">
            	<input id="BtOK" type="button" class="btn-btn01" value="确 定" onclick="OKreturn();" />&nbsp;&nbsp;
            	<input id="BtClose" type="button" class="btn-btn01" value="取 消" onclick="Close();"/>
                </div>
            </div>
        </div>
    </div>
    
    </form>
</body>
</html>
