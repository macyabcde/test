<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartBpopdom.aspx.cs" Inherits="User.Web.partManage.PartBpopdom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限定义</title>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
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
                                        <asp:Label ID="lbwhatDo" runat="server" Text="权限定义"></asp:Label>
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
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center" id="divPopedom">
                <asp:Repeater ID="rptmodule" runat="server" OnItemDataBound="rptmodule_ItemDataBound1">
                    <ItemTemplate>
                        <table cellspacing="0" width="93%" cellpadding="0">
                            <tr ondblclick='<%# "return ShowOrHide(\"" +Eval("moduleID") +"\");" %>'>
                                <td style="background-color: #ebe8c1; height: 30px; width: 695px; cursor:pointer; line-height: 30px;
                                    border: solid 1px #afafaf;" align="left">
                                    &nbsp;<asp:Label ID="lbModuleName" runat="server" Text='<%# Eval("moduleName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td id='<%# Eval("moduleID") %>'>
                                    <asp:HiddenField ID="HDmoduleID" Value='<%# Eval("moduleID") %>' runat="server" />
                                    <asp:Repeater ID="rptPopedom" runat="server">
                                        <HeaderTemplate>
                                            <table cellpadding="0" bgcolor="#E4E4E4" border="0" width="100%" cellspacing="1">
                                                <tr class="trTop">
                                                    <td width="5%">
                                                        选择
                                                    </td>
                                                    <td width="10%">
                                                        权限代码
                                                    </td>
                                                    <td width="15%">
                                                        权限名称
                                                    </td>
                                                    <td width="70%">
                                                        说明
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trData">
                                                <td align="center" style=" background-color:#ffffe6;">
                                                    <input runat="server" id="cbPopedomCode" runat="server" value='<%# Eval("popedomCode")%>' title='<%# Eval("popedomCode")%>' type="checkbox" />
                                                </td>
                                                <td align="center">
                                                    <%# Eval("popedomCode")%>
                                                </td>
                                                <td runat="server">
                                                    <%# Eval("popedomName")%>
                                                </td>
                                                <td>
                                                    <%# Eval("explain")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr class="trData">
                                        <td colspan="4" style=" text-align:left;">
                                            &nbsp;<asp:LinkButton ID="lbtnSelectAll" OnClientClick='<%# "return SelectAll(\"" +Eval("moduleID")+"\");" %>'
                                                runat="server">全选</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnSelectIntval" OnClientClick='<%# "return SelectInvert(\"" +Eval("moduleID")+"\");" %>'
                                                runat="server">反选</asp:LinkButton>
                                        </td>
                                    </tr>
                        </table>
                        </td> </tr> </table>
                        <div style="height: 10px">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="5" align="center">
                <asp:Button ID="btnFinish" runat="server" Text="保存" 
                    OnClientClick="return setPartPopedomCodeID();" CssClass="btn-btn01" 
                    onclick="btnFinish_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFpopedomCodeStr" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    //设置选择的原子权限代码ID
    function setPartPopedomCodeID() {
        var hasOne = true;
        var strPopedomCode = "";
        $("#divPopedom").find("input[type='checkbox']").each(function(i, j) {
        if (j.checked) {
                
                if (hasOne)
                    strPopedomCode = j.value;
                else
                    strPopedomCode += "," + j.value;
                    
                hasOne = false;
            }
        })
        document.getElementById("HFpopedomCodeStr").value = strPopedomCode;
    }

    //全选,listID为控制全选的范围,即列表ID,需要引用jquery
    function SelectAll(listID) {
        $("#" + listID).find("input[type=\"checkbox\"]").each(function(i, j) {
            j.checked = true;
        })
        return false;
    }

    //反选,listID为控制全选的范围,即列表ID,需要引用jquery
    function SelectInvert(listID) {
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

    //隐藏或者显示
    //ID：要隐藏或显示的控件ID
    function ShowOrHide(ID) {
        var Control = document.getElementById(ID);

        var cDisaplay = Control.style.display;
        if (cDisaplay == "block" || cDisaplay == null || cDisaplay == "") {
            Control.style.display = "none";
            return;
        }
        Control.style.display = "block";
    }
</script>

