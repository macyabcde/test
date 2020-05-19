<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsCollectionInex.aspx.cs"
    Inherits="PU.web.MyInformation.newsCollectionInex" %>

<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报道收藏</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        /*删除类别
        typeName：类别名称
        */
        function delType(typeName) {
            if (confirm("您真的要删除[" + typeName + "]" + "类别吗？")) {
                return true;
            } else {
                return false;
            }
        }

        //删除报道收藏(多个)
        function delSc() {
            var newsCollectionInfoIDs = ""; //要删除的报道收藏信息ID串，多个以“,”隔开
            var sl = 0;
            $("#tabRetList").find("input[type=\"checkbox\"]").each(function(i, j) {
                if (j.checked) {
                    if (newsCollectionInfoIDs != "") newsCollectionInfoIDs += ",";
                    newsCollectionInfoIDs += j.newsCollectionInfoID;
                    sl++;
                }
            })

            if (newsCollectionInfoIDs == "") {
                alert("请至少选择一个要删除的文章收藏！");
                return false;
            }

            if (confirm("您确定要删除所选的[" + sl + "]篇报道收藏吗？")) {
                document.getElementById("HidValue").value = newsCollectionInfoIDs;
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
                                                        <span class="mo_title_l31">报道收藏<asp:Label ID="LbTypeName" runat="server" Text="--财经"></asp:Label></span>
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
                                <asp:Button ID="BtAddType" runat="server" Text="添加类别" CssClass="btn-btn01" OnClientClick="windOpen('newsCollectionTypeAdd.aspx?whatDo=add','750px','200px'); return false;" />
                                <asp:Button ID="BtEditType" runat="server" Text="修改类别" CssClass="btn-btn01" />
                                <asp:Button ID="BtDelType" runat="server" Text="删除类别" CssClass="btn-btn01" 
                                    onclick="BtDelType_Click" />
                            </td>
                            <td align="right" height="40">
                                <asp:Button ID="BtdelSelect" runat="server" Text="删除" CssClass="btn-btn01" onclick="BtdelSelect_Click" OnClientClick="return delSc();" />
                                <asp:Button ID="BtRecommend" runat="server" Text="推荐" CssClass="btn-btn01" OnClientClick="RecommendFormList('tabRetList');return false;" />
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
                        <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" 
                            onitemdatabound="rptRetList_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input type="checkbox" id="ckbox" runat="server" value='<%#Eval("KID") %>' newsCollectionInfoID='<%#Eval("newsCollectionInfoID") %>' EnableViewState="False"/>
                                        <asp:HiddenField ID="HidnewsCollectionInfoID" runat="server" Value='<%#Eval("newsCollectionInfoID") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidpaperID" runat="server" Value='<%#Eval("paperID") %>' EnableViewState="False" />
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
