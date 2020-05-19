<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="typePaper.aspx.cs" Inherits="PU.web.PaperLook.typePaper" %>

<%@ Register Src="../UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报刊类别</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    </script>

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
                <td valign="top">
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
                                            <table width="200" border="0" cellspacing="1" cellpadding="0">
                                                <tr>
                                                    <td width="21">
                                                        <span class="mo_title_l21">
                                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                                    </td>
                                                    <td width="176">
                                                        <span class="mo_title_l31">报刊类别</span>
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
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" class="divcss5-6">
                        <tr>
                            <td height="20" align="left" class="divcss5-6">
                                <div style="text-align:left; padding-top:5px;">
                                    <% for (int i = 0; i < dt_type.Rows.Count; i++)
                                       {
                                           string color = "#000000";
                                           if (dt_type.Rows[i]["paperTypeID"].ToString() == paperTypeID.ToString()) color = "#FF6600;";
                                    %>
                                   <div style="height:20px;float: left;text-align:left; padding-right:14px;"><a style="color: <%=color%>" href="typePaper.aspx?paperTypeID=<%=dt_type.Rows[i]["paperTypeID"].ToString()%>">
                                        <%=dt_type.Rows[i]["collectionTypeName"].ToString()%></a>
                                        </div>
                                    <% } %>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="1" background="../images/linedot.jpg">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="4">
                        <% int index = 0;
                           while (index < list.Count)
                           {
                        %>
                        <tr>
                            <td height="310" align="center">
                                <% 
                                    if (index < list.Count) Response.Write(list[index]);
                                    index++;
                                %>
                            </td>
                            <td height="310" align="center">
                                <% 
                                    if (index < list.Count) Response.Write(list[index]);
                                    index++;
                                %>
                            </td>
                            <td height="310" align="center">
                                <% 
                                    if (index < list.Count) Response.Write(list[index]);
                                    index++;
                                %>
                            </td>
                            <td height="310" align="center">
                                <% 
                                    if (index < list.Count) Response.Write(list[index]);
                                    index++;
                                %>
                            </td>
                        </tr>
                        <% } %>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
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
