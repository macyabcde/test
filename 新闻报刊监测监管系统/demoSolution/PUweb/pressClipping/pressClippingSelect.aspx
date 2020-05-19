<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pressClippingSelect.aspx.cs" Inherits="PU.web.pressClipping.pressClippingSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>剪报选择</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        //获取列表选择的值
        function GetSelectValue() {
            var pressClippingBasisInfoID = -2;  //保存所选择的剪报基本信息ID,小于0则表示没有选择
            $("#rbl_type").find("input[type=\"radio\"]").each(function(i, j) {
                if (j.checked) {
                    pressClippingBasisInfoID = j.value;
                    //return;
                }
            })
            if (pressClippingBasisInfoID < 0) {
                alert("请选择一个剪报！");
                return false;
            }

            window.returnValue = pressClippingBasisInfoID;
            window.close();
        }

       
    </script>

    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                                            <asp:Label ID="lbwhatDo" runat="server"></asp:Label>
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
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
                <td height="200" align="left" style="padding-left: 15px;" valign="top">
                    <asp:RadioButtonList ID="rbl_type" AutoPostBack="false" RepeatColumns="1" RepeatDirection="Vertical"
                        CellPadding="0" CellSpacing="5" RepeatLayout="Table" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td height="40" colspan="5" align="center">
                    <asp:Button ID="btnFinish" runat="server" Text="确定" OnClientClick="GetSelectValue();return false;"
                        CssClass="btn-btn01" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

