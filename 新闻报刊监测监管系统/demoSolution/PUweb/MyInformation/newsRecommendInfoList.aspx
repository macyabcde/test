<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsRecommendInfoList.aspx.cs"
    Inherits="PU.web.MyInformation.newsRecommendInfoList" %>

<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>推荐报道</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">


        //删除报道推荐(多个)
        function deltj() {
            var newscInfoIDs = ""; //要删除的报道推荐信息ID串，多个以“,”隔开
            var sl = 0;
            $("#tabRetList").find("input[type=\"checkbox\"]").each(function(i, j) {
                if (j.checked) {
                    if (newscInfoIDs != "") newscInfoIDs += ",";
                    newscInfoIDs += j.newscInfoID;
                    sl++;
                }
            })

            if (newscInfoIDs == "") {
                alert("请至少选择一篇要删除的报道推荐！");
                return false;
            }

            //alert(newscInfoIDs);
            if (confirm("您确定要删除所选的[" + sl + "]篇报道推荐吗？")) {
                document.getElementById("HidValue").value = newscInfoIDs;
                return true;
            }
            else {
                return false;
            }

        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtRef" runat="server" Text="刷新" CssClass="hide" OnClick="BtRef_Click" />
        <asp:HiddenField ID="HidValue" runat="server" />
        <asp:HiddenField ID="HidCommand" runat="server" />
        <asp:Button ID="BtCommand" runat="server" Text="多功能按钮" CssClass="hide" OnClick="BtCommand_Click" />
        <uc1:head ID="head2" runat="server" />
        <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="212" align="center" valign="top" background="images/leftdi.jpg">
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
                                                        <span class="mo_title_l31">推荐报道</span>
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
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                        <tr>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right" height="40">
                                <asp:Button ID="BtdelSelect" runat="server" Text="删除" CssClass="btn-btn01"
                                    OnClick="BtdelSelect_Click" OnClientClick="return deltj();" />
                                <asp:Button ID="BtFavorites" runat="server" Text="收藏" CssClass="btn-btn01" OnClientClick="FavoritesFormList('tabRetList');return false;" />
                                <asp:Button ID="BtClippingSend" runat="server" Text="剪报推送" CssClass="btn-btn01" OnClientClick="ClippingSendFormList('tabRetList');return false;"/>
                                <asp:Button ID="BtMyOpus" runat="server" Text="放入作品" CssClass="btn-btn01" OnClientClick="addOpusNewsInfoFormList('tabRetList');return false;"/>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="93%" id="tabRetList" border="0" align="center" cellpadding="0" cellspacing="1"
                        bgcolor="#E4E4E4">
                        <tr class="trTop">
                            <td>
                                选择
                            </td>
                            <td>
                                推荐者
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
                        </tr>
                        <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" OnItemDataBound="rptRetList_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input type="checkbox" id="ckbox" runat="server" value='<%#Eval("KID") %>' newscInfoID='<%#Eval("newscInfoID") %>' EnableViewState="False"/>
                                        <asp:HiddenField ID="HidnewscInfoID" runat="server" Value='<%#Eval("newscInfoID") %>'
                                            EnableViewState="False" />
                                        <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidpaperID" runat="server" Value='<%#Eval("paperID") %>' EnableViewState="False" />
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbuserName" runat="server" Text='<%#Eval("userName") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False" Target="_blank"></asp:HyperLink>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbZZ" runat="server" Text='<%#Eval("ZZ") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbMC" runat="server" Text='<%#Eval("MC") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbRQ" runat="server" Text='<%#Eval("RQ") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LbBM" runat="server" Text='<%#Eval("BM") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LBBC" runat="server" Text='<%#Eval("BC") %>' EnableViewState="False"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <table width="93%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" height="40" style="font-size: 12px;">
                                &nbsp;<a href="javascript:QX('tabRetList');">全选</a>&nbsp;<a href="javascript:FX('tabRetList');">反选</a>
                            </td>
                            <td align="right" height="40">
                                <cc1:pageControl ID="pageControl1" runat="server" pageSize="20" OnClick="pageControl1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc3:footer ID="footer2" runat="server" />
    </div>
    </form>
</body>
</html>
