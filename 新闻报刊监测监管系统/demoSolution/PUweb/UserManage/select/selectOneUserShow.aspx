<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectOneUserShow.aspx.cs" Inherits="User.Web.select.selectOneUserShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
	body
	{
		margin:0px 0px;
		padding:0px 0px;
	}
	.mainFrame
	{
		width:201px;
		height:450px;
	}
	.scorllStyle
	{
		scrollbar-3dlight-color: #616161; 
		scrollbar-arrow-color: #ffffff; 
		scrollbar-base-color: #CFCFCF; 
		scrollbar-face-color: #CFCFCF; 
		scrollbar-highlight-color: #FFFFF; 
		scrollbar-shadow-color: #595959; 
		scrollbar-darkshadow-color: #FFFFFF;
	
		_scrollbar-3dlight-color: none; 
		_scrollbar-arrow-color: none; 
		_scrollbar-base-color: none; 
		_scrollbar-face-color: none; 
		_scrollbar-highlight-color: none; 
		_scrollbar-shadow-color: none; 
		_scrollbar-darkshadow-color: none;
	
	}
</style>


     <script language="javascript" type="text/javascript" src="../js/PubJSLibrary.js"></script>
     <script language="javascript" type="text/javascript" src="../js/tempData.js"></script>
     <script language="javascript" type="text/javascript">
// <!CDATA[

        //返回选择的数据
        function OKreturn() {
            var idStr = "";
            var nameStr = "";
            var ret = "";

            var selList = document.getElementById("ListBoxShow"); //待选列表

            for (var i = 0; i < selList.length; i++) {
                if (selList.options[i].selected) {
                    idStr = selList.options[i].value;
                    nameStr = selList.options[i].text;
                }
            }
            if (idStr != "") ret = idStr + ";" + nameStr
            var DataKey = parent.document.getElementById("HidFieldDataKey").value;
           
            SetExchangeData(ret, DataKey);
            parent.window.returnValue = ret;
            //alert("ret=" + ret);
            parent.window.close();
        }
        
        

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:ListBox ID="ListBoxShow" runat="server" class="mainFrame scorllStyle"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
