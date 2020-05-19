<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="PU.web.Search.ArticleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报道修改</title>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
       
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="31" background="../images/middle_di_01.jpg">
                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td align="left" class="mo_title_l41">
                            <table width="200" border="0" cellspacing="1" cellpadding="0">
                                <tr>
                                    <td width="21">
                                        <span class="mo_title_l211">
                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                    </td>
                                    <td width="176">
                                        <asp:Label ID="lbwhatDo" runat="server">报道修改</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#CCCCCC">
            </td>
        </tr>
    </table>
    <table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="900" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center">
                <table width="100%" border="0" cellpadding="0" cellspacing="6">
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="100" align="right">
                            报纸名：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMC" runat="server" Width="166px" Enabled="False"></asp:TextBox>
                            &nbsp;<asp:CheckBox ID="CKBoxPU" runat="server" Text="发布" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtDel" runat="server" CssClass="btn-btn01" 
                                onclick="BtDel_Click" Text="删除" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            引题：</td>
                        <td align="left">
                            <asp:TextBox ID="txtYT" runat="server" Width="526px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            标题：</td>
                        <td align="left">
                            <asp:TextBox ID="txtBT" runat="server" Width="526px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            副标题：</td>
                        <td align="left">
                            <asp:TextBox ID="txtFB" runat="server" Width="526px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            作者：</td>
                        <td align="left">
                            <asp:TextBox ID="txtZZ" runat="server" Width="526px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="100" align="right">
                            版面：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBM" runat="server" Width="166px"></asp:TextBox>
                            &nbsp;版次：<asp:TextBox ID="txtBC" runat="server" Width="55px"></asp:TextBox>
                            &nbsp;版条：<asp:TextBox ID="txtBN" runat="server" Width="48px"></asp:TextBox>
                            &nbsp;责任编辑：<asp:TextBox ID="txtBJ" runat="server" Width="137px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="100" align="right">
                            栏目：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLM" runat="server" Width="166px"></asp:TextBox>
                            &nbsp;分类：<asp:TextBox ID="txtFL" runat="server" Width="166px"></asp:TextBox>
                            &nbsp;地区：<asp:TextBox ID="txtDQ" runat="server" Width="166px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;
                        </td>
                        <td width="100" align="right">
                            体裁：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTC" runat="server" Width="166px"></asp:TextBox>
                            &nbsp;人物：<asp:TextBox ID="txtRW" runat="server" Width="166px"></asp:TextBox>
                        &nbsp;来源：<asp:TextBox ID="txtLY" runat="server" Width="166px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            广告产品：</td>
                        <td align="left">
                            <asp:TextBox ID="txtGGCP" runat="server" Width="166px"></asp:TextBox>
                            广告类型：<asp:TextBox ID="txtGGLX" runat="server" Width="166px"></asp:TextBox>
                            广告分类：<asp:TextBox ID="txtGGFL" runat="server" Width="186px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            广告色彩：</td>
                        <td align="left">
                            <asp:TextBox ID="txtGGSC" runat="server" Width="166px"></asp:TextBox>
                            广告面积：<asp:TextBox ID="txtGGMJ" runat="server" Width="166px"></asp:TextBox>
                            &nbsp;
                            广告主：<asp:TextBox ID="txtGGZ" runat="server" Width="186px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            坐标：</td>
                        <td align="left">
                            <asp:TextBox ID="txtZB" runat="server" Width="686px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            正文：</td>
                        <td align="left">
                            <asp:TextBox ID="txtTX" runat="server" Width="700px" Height="280px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20">
                            &nbsp;</td>
                        <td width="100" align="right">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="40" align="center">
                <asp:Button ID="BtOK" runat="server" Text="保存" CssClass="btn-btn01" 
                    onclick="BtOK_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
