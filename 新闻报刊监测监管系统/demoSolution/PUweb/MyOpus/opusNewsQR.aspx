<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opusNewsQR.aspx.cs" Inherits="PU.web.MyOpus.opusNewsQR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>作品确认</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">


        //获取选择的KID
        function getSelectKID() {
            var selectKIDStr = "";
            var NotselectKIDStr = "";

            $("#tabRetList").find("input[type=\"checkbox\"]").each(function(i, j) {
                if (j.checked) {
                    if (selectKIDStr != "") selectKIDStr += ",";
                    selectKIDStr += j.value;
                } else {
                    if (NotselectKIDStr != "") NotselectKIDStr += ",";
                    NotselectKIDStr += j.value;
                }
            })


            document.getElementById("HidValue").value = selectKIDStr;
            document.getElementById("HidValueNot").value = NotselectKIDStr;
            
            return true;

        }
    
    </script>
    <style type="text/css">
        .style1
        {
            width: 71px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="HidValue" runat="server" />
    <asp:HiddenField ID="HidValueNot" runat="server" />
    <asp:HiddenField ID="HidCommand" runat="server" />
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
                                                        <span class="mo_title_l31">作品确认</span>
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
                            <td height="40" align="center">以下为新更新的您的作品，请确认。
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="5">
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
                        </tr>
                        <asp:Repeater ID="rptRetList" runat="server" EnableViewState="False" OnItemDataBound="rptRetList_ItemDataBound">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="trData">
                                    <td align="center">
                                        <input type="checkbox" id="ckbox" runat="server" value='<%#Eval("KID") %>' EnableViewState="False"/>                                        
                                        <asp:HiddenField ID="HidKID" runat="server" Value='<%#Eval("KID") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidPD" runat="server" Value='<%#Eval("PD") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidJP" runat="server" Value='<%#Eval("JP") %>' EnableViewState="False" />
                                        <asp:HiddenField ID="HidpaperID" runat="server" Value='<%#Eval("paperID") %>' EnableViewState="False" />
                                    </td>
                                   <td align="center">
                                         <%# rptRetList.Items.Count + 1%>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <asp:HyperLink ID="HLinkBT" runat="server" Text='<%#Eval("BT") %>' EnableViewState="False"></asp:HyperLink>
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
                    <table width="93%" border="0" align="center" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" height="40" style="font-size: 12px;" class="style1">
                                &nbsp;<a href="javascript:QX('tabRetList');">全选</a>&nbsp;<a href="javascript:FX('tabRetList');">反选</a>
                            </td>
                            <td align="center" height="40">
                                <asp:Button ID="BtQR0" runat="server" Text="确认所选" CssClass="btn-btn01" 
                                    OnClientClick="return getSelectKID();" onclick="BtQR0_Click"/>
                                &nbsp;<asp:Button ID="BtFavorites0" runat="server" Text="以后再说" CssClass="btn-btn01" 
                                    OnClientClick="window.close();return false;" />
                                </td>
                        </tr>
                    </table>
    </div>
    </form>
</body>
</html>
