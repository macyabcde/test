<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBasisInfoList.aspx.cs"
    Inherits="PU.web.outgiving.CustomerBasisInfoList" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>客户管理</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:head ID="head2" runat="server" />
        <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="212" align="center" valign="top" background="../images/leftdi.jpg">
                    <uc2:left ID="left2" runat="server" />
                </td>
                <td width="1" align="center" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="5" bgcolor="#5F87BC">
                </td>
                <td valign="top" align="center">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="1" bgcolor="#FFFFFF">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="31" background="../images/middle_di_01.jpg">
                                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <td align="left" class="mo_title_l4">
                                            <table width="500" border="0" cellspacing="1" cellpadding="0">
                                                <tr>
                                                    <td width="21">
                                                        <span class="mo_title_l21">
                                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                                    </td>
                                                    <td width="176">
                                                        <span class="mo_title_l31">客户管理</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="1" bgcolor="#CCCCCC">
                            </td>
                        </tr>
                    </table>
                    
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                        <tr>
                            <td align="left">
                            </td>
                            <td align="right" height="40">
                                <asp:Button ID="BtnAdd" OnClientClick="windOpen('CustomerBasisInfoAdd.aspx?whatDo=add','730','355'); return false;" runat="server" Text="添加" CssClass="btn-btn01"/>
                                <asp:Button ID="BtnDel" OnClientClick="return delCustomer();" runat="server" 
                                    Text="删除" CssClass="btn-btn01" onclick="BtnDel_Click" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="93%" id="tabCustomerList" border="0" align="center" cellpadding="0" cellspacing="1"
                        bgcolor="#E4E4E4">
                        <tr class="trTop">
                            <td>
                                选择
                            </td>
                            <td>
                                客户ID
                            </td>
                            <td>
                                客户名称
                            </td>
                            <td>
                                客户联系人
                            </td>
                            <td>
                                联系人电话
                            </td>
                            <td>
                                联系人Email
                            </td>
                            <td>
                                联系人QQ
                            </td>
                            <td>
                                服务截止日期
                            </td>
                            <td>
                                频度限制
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <asp:Repeater ID="rptCustomerList" runat="server" EnableViewState="False" 
                            onitemdatabound="rptCustomerList_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="trData">
                                    <td align="center" style=" background-color: #ffffe6;">
                                        <input type="checkbox" id="ckbox" runat="server" value='<%#Eval("customerID") %>' />
                                        <asp:HiddenField ID="HidCustomerID" runat="server" Value='<%#Eval("customerID") %>'
                                            EnableViewState="False" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCustomerID" runat="server" Text='<%# Eval("customerID") %>'></asp:Label>
                                    
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbCustomerName" runat="server" Text='<%# Eval("customerName") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbLinkman" runat="server" Text='<%#Eval("linkman") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbTel" runat="server" Text='<%#Eval("tel") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbEmail" runat="server" Text='<%#Eval("email") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbqq" runat="server" Text='<%#Eval("qq") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbServiceEndTime" runat="server" Text='<%# Eval("serviceEndTime") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbRequestLimit" runat="server" Text='<%# Eval("requestLimit") %>'></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtnUpdate" runat="server">修改</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnActive" CommandArgument='<%# Eval("active") %>'  runat="server">启用</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnPaperFW" runat="server">报纸范围</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <!--结果列表end -->
                    <table width="93%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" height="40" style="font-size: 12px;">
                                &nbsp;<a href="javascript:QX('tabCustomerList');">全选</a>&nbsp;<a href="javascript:FX('tabCustomerList');">反选</a>
                            </td>
                            <td align="right" height="40">
                                <cc1:pageControl ID="pageControl1" goPage="1" runat="server" pageSize="20" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td> </tr> </table>
        <uc3:footer ID="footer2" runat="server" />
    </div>
    <asp:Button ID="btnRefresh" runat="server" Text="刷新" Style="display: none;" OnClick="btnRefresh_Click" />
    <asp:HiddenField ID="HFcomand" runat="server" />
    <asp:HiddenField ID="HFvalue" runat="server" />
    <asp:HiddenField ID="HFactive" runat="server" />
    <asp:Button ID="btncomand" runat="server" Text="Button"  onclick="btncomand_Click" style=" display:none;" />
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">

    var HFvalue = document.getElementById("HFvalue");
    var HFcomand = document.getElementById("HFcomand");
    var btncomand = document.getElementById("btncomand");
   

    //启用(禁用)客户
    //active：客户当前启用状态
    //customerID：客户ID
    //customerName：客户名称
    function isactive(active, customerName) {
        var HasActive = false;
        if (active == 0)
            HasActive = confirm("您确定要启用\"" + customerName + "\"吗？");
        else
            HasActive = confirm("您确定要禁用\"" + customerName + "\"吗？");

        if (active == 0)
            active = 1;
        else
            active = 0;

        if (!HasActive) return false;

        var HFactive = document.getElementById("HFactive");
        HFvalue.value = customerName;
        HFactive.value = active;
        HFcomand.value = "active";
        btncomand.click();
        return false;
    }

    //删除客户信息
    function delCustomer() {
        var customerIDstr = "";
        var delCout = 0;
        $("#tabCustomerList").find("input[type='checkbox']").each(function(i, j) {
            if (j.checked) {
            
                if (customerIDstr == "")
                    customerIDstr = j.value;
                else
                    customerIDstr += "," + j.value;

                delCout++;
            }
        })

        if (customerIDstr == "") {
            alert("请至少选择一个您要删除的客户信息！");
            return false;
        }

        HFvalue.value = customerIDstr;

        var hasDel = confirm("您确定要删除所选的[" + delCout + "]个客户信息吗？");

        if (!hasDel) HFvalue.value = "";

        return hasDel;
    }
</script>