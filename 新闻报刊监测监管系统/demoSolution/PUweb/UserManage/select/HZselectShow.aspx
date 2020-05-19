<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HZselectShow.aspx.cs" Inherits="User.Web.select.HZselectShow" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>待选人员</title>
    <style type="text/css">
	body
	{
		margin:0px 0px;
		padding:0px 0px;
	}
	.mainFrame
	{
		width:151px;
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
    <script language="javascript" type="text/javascript">

        //选择到已选列表
        function toSelect() {
            var fromList = document.getElementById("ListBoxShow"); //待选列表
            var toList = parent.document.getElementById("ListBoxSelect"); //已选列表            
            moveSelectOneData(fromList, toList);
        }
        
        //将列表选种的一项移到另一个列表 fromList：源列表对象，toList：目地列表对象
        function moveSelectOneData(fromList, toList) {

            var ifhave = false;
            for (var i = fromList.length - 1; i >= 0; i--) {
                if (fromList.options[i].selected) {
                    ifhave = false;
                    for (var w = 0; w < toList.options.length; w++) {
                        if (fromList.options[i].value == toList.options[w].value) {
                            ifhave = true;
                            break;
                        }
                    }
                    if (!ifhave) {
                        toList.options.length++;
                        toList.options[toList.options.length - 1].value = fromList.options[i].value;
                        toList.options[toList.options.length - 1].text = fromList.options[i].text;
                    }

                    for (var j = i; j < fromList.options.length - 1; j++) {
                        fromList.options[j].value = fromList.options[j + 1].value;
                        fromList.options[j].text = fromList.options[j + 1].text;
                        //fromList.options[j].selected = false;
                    }
                    fromList.length--;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:ListBox ID="ListBoxShow" runat="server" CssClass="mainFrame scorllStyle"></asp:ListBox>
    </div>
    </form>
</body>
</html>
