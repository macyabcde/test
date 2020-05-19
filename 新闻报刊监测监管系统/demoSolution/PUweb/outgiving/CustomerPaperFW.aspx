<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPaperFW.aspx.cs"
    Inherits="PU.web.outgiving.CustomerPaperFW" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报纸范围</title>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <link href="../css/style.css" type="text/css" rel="stylesheet">

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                                        <asp:Label ID="lbwhatDo" runat="server" Text="报纸范围"></asp:Label>
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
            <td>
                录入报纸信息ID(多个用","分割)：
            </td>
            <td align="right">
                <asp:TextBox ID="tbPaperID" runat="server" Width="220px"></asp:TextBox> 
            </td>
            <td>
            已更新到日期：<asp:TextBox ID="tbupdateOverDate" Width="100px" onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'});" runat="server"></asp:TextBox>
            </td>
            <td align="left">
                <asp:Button ID="btnAddMore" CssClass="btn-btn01" runat="server" Text="添加" 
                    onclick="btnAddMore_Click" />
                <asp:Button ID="btnLook" CssClass="btn-btn01" runat="server" Text="查看" />
            </td>
        </tr>
    </table>
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="1">
        <tr>
            <td align="center" id="divCustomerPaper">
                <asp:Repeater ID="rptCustomerPaper" runat="server" 
                    onitemdatabound="rptCustomerPaper_ItemDataBound">
                    <HeaderTemplate>
                        <table cellpadding="0" bgcolor="#E4E4E4" border="0" width="100%" cellspacing="1">
                            <tr class="trTop">
                                <td width="5%">
                                    选择
                                </td>
                                <td width="10%">
                                    报纸ID
                                </td>
                                <td width="85%">
                                    报纸名称
                                </td>
                                <td>
                                已更新到日期
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="trData">
                            <td align="center" style="background-color: #ffffe6;">
                                <input runat="server" id="cbPaperID" value='<%# Eval("paperID")%>' title='<%# Eval("paperID")%>' type="checkbox" />
                                
                            </td>
                            <td align="center">
                                <%# Eval("paperID")%>
                            </td>
                            <td  align="left">
                               &nbsp;<%# Eval("paperName")%>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="tbupdateOverDate"  onclick="WdatePicker({readOnly:true,dateFmt:'yyyy-MM-dd'});"  runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                    <table cellpadding="0"  border="0" width="100%">
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lbMsg" runat="server" ForeColor="Red" Font-Size="12px" Text=""></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        </table>
        
  <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="60"  align="center" style=" background-color:White;">
                <asp:Button ID="btnFinish" runat="server" Text="保存" 
                    OnClientClick="return setCustomerPaperID();"  CssClass="btn-btn01" 
                    onclick="btnFinish_Click"  />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="btn-btn01" OnClientClick="window.close();return false;" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFcustomerPaperStr" runat="server" />
    <asp:HiddenField ID="HFupdateOverDateStr" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">

    //设置选择的报纸信息ID
    function setCustomerPaperID() {
        var strPaperIDstr = "";
        var strUpdateOverDateStr = "";
        var tbTemp;
        var hasOk = true;
        var lbMsg = document.getElementById("lbMsg");
        $("#divCustomerPaper").find("input[type='checkbox']").each(function(i, j) {
            if (j.checked) {

                if (strPaperIDstr == "")
                    strPaperIDstr = j.value;
                else
                    strPaperIDstr += "," + j.value;

                $("#divCustomerPaper").find("input[type='text']").each(function(M, N) {
                    if (N.paperID == j.value) {

                        if (N.value == "") {
                            tbTemp = N;
                            hasOk = false;
                        }

                        if (strUpdateOverDateStr == "")
                            strUpdateOverDateStr = N.value;
                        else
                            strUpdateOverDateStr += "," + N.value;
                    }
                })
            }
        })

        if (!hasOk) {
            lbMsg.innerHTML = "请选择已更新到日期！";
            tbTemp.focus();
        }
        
        document.getElementById("HFcustomerPaperStr").value = strPaperIDstr;
        document.getElementById("HFupdateOverDateStr").value = strUpdateOverDateStr;
        return hasOk;
    }
</script>

