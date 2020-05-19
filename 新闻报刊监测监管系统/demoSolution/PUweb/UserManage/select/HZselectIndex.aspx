<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HZselectIndex.aspx.cs"
    Inherits="User.Web.select.HZselectIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员选择</title>
    <link href="../css/SelectUserStyel.css" rel="stylesheet" type="text/css" />

    <script src="../MzTreeView10/MzTreeView10.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/jquery.js" type="text/javascript"></script>
    
 
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <div id="PageStyle" class="PageStyle">
        <div id="ContentOne" class="Content">
            <div id="left" class="left">
                <div id="Ltop" class="Ltop fontStyle1">
                    集团员工列表
                </div>
                <div id="Ltree" class="Ltree scorllStyle">
                    <!--展现树的地方-->
                    <script language="javascript" type="text/javascript"> 
                        var t = new MzTreeView("t");    
                        t.setIconPath("../MzTreeView10/"); //可用相对路径    
                        t.setTarget("iframeShow");
                       <%=nodeStr%>   
                   </script>
                </div>
            </div>
            <div id="right" class="right">
                <div id="Rtop" class="Rtop fontStyle1">
                    选择列表
                </div>
                <div id="Rseach" class="Rseach">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <input type="text" id="txtKey" onblur="TextBlur(this)" value="请输入关键字..." class="ipt-t" style="width: 145px; height: 20px;" onfocus="TextFocus(this)" onchange="TextChange(this)" />
                            </td>
                            <td width="80px" align="center">
                                <input type="button" value="搜索" onclick="btnSearch('txtKey',this)" class="btn-btn01" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="RList" class="RList">
                    <div id="RLleft" class="RLleft">
                        <div id="RLLtop" class="RLLtop fontStyle2">
                            部门员工列表
                        </div>
                        <div id="RLLContent" class="RLLContent">
                            <iframe id="iframeShow" name="iframeShow" src="HZselectShow.aspx?DepartID=<%=focusID%>"
                                frameborder="0" class="mainFrame"></iframe>
                        </div>
                    </div>
                    <div id="RLright" class="RLright">
                        <div id="RLRtop" class="RLLtop fontStyle2">
                            已选人员
                        </div>
                        <div id="RLRContent" class="RLLContent">
                            <asp:ListBox ID="ListBoxSelect" runat="server" CssClass="mainFrame scorllStyle">
                            </asp:ListBox>
                        </div>
                    </div>
                    <div id="RLcenter" class="RLcenter">
                        <input type="image" id="Image1" src="../images/show_right2.jpg" onclick="toSelectALL();return false;" /><br />
                        <br />
                        <input type="image" id="Image2" src="../images/show_left2.jpg" onclick="toNotSelectAll();return false;" />
                    </div>
                    <div class="clearFloat">
                    </div>
                </div>
                <div id="botton" class="botton">
                    <input type="button" id="BtOK" class="btn-btn01" value="确 定" onclick="OKreturn();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="BtClose" class="btn-btn01" value="取 消" onclick="Close();" />
                </div>
            </div>
            <div id="center" class="center">
            </div>
            <div id="clearFloat" class="clearFloat">
            </div>
        </div>
        <div id="ContentTwo" class="ContentTwo">
            <div id="divHead" class="divHead fontStyle1">
                人员搜索
            </div>
            <div id="divSearch" class="divSearch">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <input type="text" id="txtKeyTwo" onblur="TextBlur(this)" value="请输入关键字..." class="ipt-t"
                                style="width: 145px; height: 20px;" onfocus="TextFocus(this)" onchange="TextChange(this)" />
                        </td>
                        <td width="80px" align="center">
                            <input type="button" value="搜索" onclick="btnSearch2('txtKeyTwo',this)" class="btn-btn01" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="userList" class="userList scorllStyle2">
                <table id="tabUser" cellpadding="0" border="1" cellspacing="0" class="tab" width="590px">
                    <tr>
                        <th width="6%">
                            选择
                        </th>
                        <th width="30%">
                            用户ID
                        </th>
                        <th width="32%">
                            姓名
                        </th>
                        <th width="32%">
                            部门
                        </th>
                    </tr>
                </table>
                <table cellpadding="0" border="1" cellspacing="0" class="tab2" width="590px">
                    <tr>
                        <td>
                            <a href="javascript:;" onclick="QX('tabUser')">全选</a> <a href="javascript:;" onclick="FX('tabUser')">
                                反选</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divButton" class="divButton">
                <input type="button" class="btn-btn01" value="确 定" onclick="GetSearchValue()" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="btn-btn01" onclick="closeSearch()" value="取 消" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
// <!CDATA[

    //将已选移到待选列表
    function toNotSelect() {
        var toList = iframeShow.document.getElementById("ListBoxShow"); //待选列表
        var fromList = document.getElementById("ListBoxSelect"); //已选列表
        moveSelectOneData(fromList, toList);
    }

    //选择到已选列表全部
    function toSelectALL() {
        var fromList = iframeShow.document.getElementById("ListBoxShow"); //待选列表
        var toList = document.getElementById("ListBoxSelect"); //已选列表
        moveSelectListData(fromList, toList);
    }

    //将已选移到待选列表全部
    function toNotSelectAll() {
        var toList = iframeShow.document.getElementById("ListBoxShow"); //待选列表
        var fromList = document.getElementById("ListBoxSelect"); //已选列表
        moveSelectListData(fromList, toList);
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

    //将列表选种的所有项移到另一个列表 fromList：源列表对象，toList：目地列表对象
    function moveSelectListData(fromList, toList) {
        var ifhave = false;

        for (var i = 0; i < fromList.length; i++) {
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

        }
        fromList.length = 0;

    }

    //向目地列表添加数据，toList：目地列表对象，txt：显示的数据，value：值
    function addToAim(toList, txt, value) {
        
        var ifhave = false;
        for (var w = 0; w < toList.options.length; w++) {
            if (value == toList.options[w].value) {
                ifhave = true;
                break;
            }
        }
        if (!ifhave) {
            toList.options.length++;
            toList.options[toList.options.length - 1].value = value;
            toList.options[toList.options.length - 1].text = txt;
        }
    }

    function OKreturn() {
        var idStr = "";
        var nameStr = "";
        var ret = "";

        var selList = document.getElementById("ListBoxSelect");

        for (var i = 0; i < selList.length; i++) {
            if (idStr == "")
                idStr = selList.options[i].value;
            else
                idStr = idStr + "," + selList.options[i].value;

            if (nameStr == "")
                nameStr = selList.options[i].text;
            else
                nameStr = nameStr + "," + selList.options[i].text;

        }
        if (idStr != "") ret = idStr + ";" + nameStr
        var DataKey = "<%=tempDataKey %>"; //将后台的数据写到页面代码中
        SetExchangeDataWithKey(ret, DataKey);
        window.returnValue = ret;
        window.close();

    }

    function Close() {
        var ret = "";
        var DataKey = "<%=tempDataKey %>"; //将后台的数据写到页面代码中
        SetExchangeDataWithKey(ret, DataKey);
        window.returnValue = ret;
        window.close();
    }




    /************************************************************
    *	文件聚焦事件										        *
    ************************************************************/
    function TextFocus(obj) {
        if (obj.value == "请输入关键字...") {
            obj.value = "";
        }
        obj.className = 'ipt-t ipt-t-dft-active'
        obj.style.color = "black";
    }

    /************************************************************
    *	文本失去焦点事件										    *
    ************************************************************/
    function TextBlur(obj) {
        if (obj.value.replace(/[ ]/g, "") == "" || obj.value == "请输入关键字...") {
            obj.value = "请输入关键字...";
            //IsUserKey=false;
            obj.style.color = "#828282";
        }
        obj.className = 'ipt-t';
    }

    /************************************************************
    *	文本内容改变事件										    *
    ************************************************************/
    function TextChange(obj) {
        //IsUserKey=true;
    }

    /************************************************************
    *	全选,listID为控制全选的范围,即列表ID,需要引用jquery		    *
    ************************************************************/
    function QX(listID) {
        $("#" + listID).find("input[type=\"checkbox\"]").each(function(i, j) {
            j.checked = true;
        })
        return false;
    }

    /************************************************************
    *	反选,listID为控制全选的范围,即列表ID,需要引用jquery		    *
    ************************************************************/
    function FX(listID) {
        $("#" + listID).find("input[type=\"checkbox\"]").each(function(i, j) {
            if (j.checked) {
                j.checked = false;
            }
            else {
                j.checked = true;
            }
        })
        return false;
    }

    /************************************************************
    *	传递参数	,把搜索的关键字传入到搜索页面中					    *
    *	keyID为输入关键字的text ID			 				    *
    *	obj当前按钮							 				    *
    ************************************************************/
    function btnSearch(keyID, obj) {
        var textKey = document.getElementById(keyID);
        //输入的关键字为“”,不执行传递操作
        if (textKey.value == "" || textKey.value == "请输入关键字...") {
            textKey.focus();
            obj.title = "请输入关键字！";
            return false;
        }
        obj.title = "";
        //传递参数到搜索页面，隐藏人员选择页面。
        //隐藏人员选择页面。
        document.getElementById("ContentOne").style.display = "none";
        //显示人员搜索页面
        document.getElementById("ContentTwo").style.display = "block";
        //传递参数值
        document.getElementById("txtKeyTwo").value = textKey.value;

        //搜索人员信息
        SearchUser(textKey.value);
    }

    /************************************************************
    *	搜索页面的搜索按钮调用事件。								*
    *	tbID:搜索关键字所在的文本(text)的ID							*
    *	obj:搜索按钮对象。										*
    ************************************************************/
    function btnSearch2(tbID, obj) {
        //获取搜索关键字
        var tbkeyWord = document.getElementById(tbID);
        //输入的关键字为“”,不执行传递操作操作
        if (tbkeyWord.value == "") {
            tbkeyWord.focus();
            obj.title = "请输入关键字！";
            return false;
        }

        obj.title = "";
        //搜索人员
        SearchUser(tbkeyWord.value);
    }

    /************************************************************
    *	清空搜索页面人员信息列表								    *
    *   tabUser:人员信息列表对象								 	*
    ************************************************************/
    function clearUserInfo(tabUser) {
        var rowCount = tabUser.rows.length;
        for (i = rowCount - 1; i > 0; i--) {
            tabUser.deleteRow(i);
        }
    }

    /************************************************************
    *	显示新搜索出来的用户信息。          					    *
    *	arryUser为josn数组,格式为：								*
    *	[{UserGUID:'',UserName:'',UserID:'',DepartName:''},...] *
    ************************************************************/
    function ShowUserInfo(arryUser) {
        //获取展现用户信息的表对象
        var tabUser = document.getElementById("tabUser");
        clearUserInfo(tabUser);
        if (arryUser == null) return;

        //添加新的用户信息
        var row; 		//新的数据行
        var cellSelect; 	//选择列
        var cellUserID; 	//用户ID列
        var cellUserName;   //姓名列
        var cellDepartName; //部门列
        var cb; 			//选择控件

        for (i = 0; i < arryUser.length; i++) {
            //创建一个新行
            row = tabUser.insertRow();

            //第一列
            cellSelect = row.insertCell();
            cellSelect.align = "center";
            cellSelect.bgColor = "#ffffe6";
            //给checkbox赋value值
            cb = document.createElement("input");
            cb.type = "checkbox";
            cb.value = arryUser[i].UserGUID + "," + arryUser[i].UserName;
            cellSelect.appendChild(cb);

            //第二列
            cellUserID = row.insertCell();
            cellUserID.align = "center";
            cellUserID.innerText = arryUser[i].UserLoginName;

            //第三列
            cellUserName = row.insertCell();
            cellUserName.align = "center";
            cellUserName.innerText = arryUser[i].UserName;

            //第四列
            cellDepartName = row.insertCell();
            cellDepartName.align = "center";
            cellDepartName.innerText = arryUser[i].DepartName;
        }
    }

    /************************************************************
    *	点击“取消”按钮调用，隐藏搜索页面，显示人员选择页面。并清空	    *
    *	搜索页面的人员列表信息和搜索关键字					        *
    ************************************************************/
    function closeSearch() {
        //获取展现用户信息的表对象
        var tabUser = document.getElementById("tabUser");
        //清空用户数据
        clearUserInfo(tabUser);
        //清空搜索关键字
        document.getElementById("txtKeyTwo").value = "";
        document.getElementById("ContentOne").style.display = "block";
        document.getElementById("ContentTwo").style.display = "none";
    }

    /************************************************************
    *	关闭页面													*
    ************************************************************/
    function closeWindow() {
        window.close();
    }

    /************************************************************
    *	点击“确定”按钮调用，隐藏搜索页面，显示人员选择页面。并清空	    *
    *	搜索页面的人员列表信息和搜索关键字。把选择的信息返回到人员		*
    *	选择页面。												*
    ************************************************************/
    function GetSearchValue() {
        //显示人员选择页面。
        document.getElementById("ContentOne").style.display = "block";
        //隐藏人员搜索页面
        document.getElementById("ContentTwo").style.display = "none";


        //获取已选列表对象
        var selList = document.getElementById("ListBoxSelect");

        var selectValue = "";
        var arr;
        $("#tabUser").find("input[type=\"checkbox\"]").each(function(i, j) {
            if (j.checked) {
                selectValue = j.value;
                arr = selectValue.split(",");
                addToAim(selList, arr[1], arr[0]);
            }
        })
        return false;
    }

    /************************************************************
    *	搜索用户信息,并将搜索出的信息显示在人员搜索页面的人员列表中	    *
    *	keyWord:搜索关键  				 						*
    ************************************************************/
    function SearchUser(keyWord) {
        //alert("您输入的搜索关键字为:"+keyWord);
        /*
        进行数据库查询操作，返回人员信息格式字符串。格式：
        [{UserGUID:'',UserName:'',UserID:'',DepartName:''},...]	
        */
        var strJosn = findUser(keyWord);
        var arryUser = null;
        //把格式字符串转化为josn对象
        if (strJosn != "#null#") arryUser = eval(strJosn);
        //显示人员信息
        ShowUserInfo(arryUser);
    }


    /************************************************************
    查找用户,返回用户信息josn字符串：
    数据的格式: [{UserGUID:'',UserName:'',UserID:'',DepartName:''},...]
    没有找到数据返回“#null#”
    ************************************************************/
    function findUser(key) {
        var senddate = "";
        senddate = "keyWord=" + escape(key) + "&whatDo=" + escape("findUser");
        var result = PostData(senddate, "../Command/ExchangeData.aspx");
        return result;
    }
// ]]>
</script>

