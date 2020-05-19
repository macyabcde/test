<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pressClippingNews.aspx.cs"
    Inherits="PU.web.pressClipping.pressClippingNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报道信息</title>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

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
                                        <asp:Label ID="lbwhatDo" runat="server" Text="报道信息"></asp:Label>
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
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr height="35px">
            <td align="right">
                <asp:Button ID="btnRemove" runat="server" Text="移除" OnClientClick="return removePressClippingBasisInfo();"
                    CssClass="btn-btn01" OnClick="btnRemove_Click" />&nbsp;
            </td>
        </tr>
    </table>
    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center" id="divPressClippingNewsInfo">
                <table cellpadding="0" bgcolor="#E4E4E4" border="0" width="100%" cellspacing="1">
                    <tr class="trTop">
                        <td>
                            选择
                        </td>
                         <td>
                            序号
                        </td>
                        <td>
                            标题
                        </td>
                        <td>
                            作者
                        </td>
                        <td>
                            报纸名
                        </td>
                        <td>
                            日期
                        </td>
                        <td>
                            版面
                        </td>
                        <td>
                            版次
                        </td>
                        <td>
                            版面文件
                        </td>
                    </tr>
                    <asp:Repeater ID="rptPressClippingNewsInfo" runat="server" OnItemDataBound="rptPressClippingNewsInfo_ItemDataBound">
                        <ItemTemplate>
                            <tr class="trData">
                                <td style="background-color: #ffffe6" align="center">
                                    <input type="checkbox" value='<%# Eval("pressClippingNewsInfoID") %>' />
                                    <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                </td>
                                <td>
                                    <%# rptPressClippingNewsInfo.Items.Count + 1%>
                                </td>
                                <td align="left" style="padding-left: 8px;">
                                    <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False"></asp:HyperLink>
                                </td>
                                <td>
                                    <asp:Label ID="lbZZ" runat="server" Text='<%# Eval("ZZ") %>' EnableViewState="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbMC" runat="server" Text='<%# Eval("MC") %>' EnableViewState="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbRQ" runat="server" Text='<%# Eval("RQ") %>' EnableViewState="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbBM" runat="server" Text='<%# Eval("BM") %>' EnableViewState="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbBC" runat="server" Text='<%# Eval("BC") %>' EnableViewState="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                    <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                                    <asp:HiddenField ID="HidpaperID" runat="server" Value='<%#Eval("paperID") %>' EnableViewState="False" />
                                    <asp:HiddenField ID="HidBC" runat="server" Value='<%#Eval("BC") %>' EnableViewState="False" />
                                    <asp:HyperLink ID="HLinkPD" runat="server" EnableViewState="False"><img src="../images/pdf01.gif"  title="下载版面PDF"/></asp:HyperLink>&nbsp;
                                    <asp:HyperLink ID="HLinkJP" runat="server" EnableViewState="False"><img src="../images/jpg02.gif" title="下载版面JPG"/></asp:HyperLink>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <table width="100%">
                    <tr height="30px">
                        <td align="left" style="font-size: 12px">
                            <asp:LinkButton ID="lbtnQX" OnClientClick="QX('divPressClippingNewsInfo'); return false; "
                                runat="server">全选</asp:LinkButton>
                            <asp:LinkButton ID="lbtnFX" OnClientClick=" FX('divPressClippingNewsInfo');  return false; "
                                runat="server">反选</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFpressClippingNewsInfoIDStr" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    //移除剪报报道信息
    function removePressClippingBasisInfo() {
        var HFpressClippingNewsInfoIDStr = document.getElementById("HFpressClippingNewsInfoIDStr");
        var pressClippingNewsInfoIDStr = "";
        var removeCount = 0;
        $("#divPressClippingNewsInfo").find("input[type='checkbox']").each(function(i, j) {
            if (j.checked) {
                if (pressClippingNewsInfoIDStr == "")
                    pressClippingNewsInfoIDStr = j.value;
                else
                    pressClippingNewsInfoIDStr += "," + j.value;

                removeCount++;
            }
        })

        if (pressClippingNewsInfoIDStr == "") {
            alert("请至少选择一篇您要删除的剪报报道！");
            return false;
        }

        HFpressClippingNewsInfoIDStr.value = pressClippingNewsInfoIDStr;

        return confirm("您确定要删除所选的[" + removeCount + "]篇剪报报道信息吗？");
    }
    
</script>

