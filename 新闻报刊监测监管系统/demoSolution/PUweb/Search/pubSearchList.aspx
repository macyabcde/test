<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pubSearchList.aspx.cs" Inherits="PU.web.Search.pubSearchList" %>

<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tabList
        {
        	word-break:break-all;
        	word-wrap:break-word;
        }
        
        .tabList td
        {
        	line-height:25px;	
        }
        
        .tabList a
        {
        	color:Blue;
        	text-decoration:underline;
        	font-size:16px;
        }
    </style>
</head>
<body style=" background-image:url('../images/skin-x.jpg'); background-repeat:repeat-x;">
    <form id="form1" runat="server">
    <div style=" width:820px; margin:0 auto;">
        <table width="100%">
            <tr align="left">
                <td colspan="2">
                <img src="../images/qflogo.png" />
                </td>
            </tr>
            <tr>
                <td width="300px" align="right">
                    <asp:TextBox ID="tbKeyWord" style=" height:25px; line-height:25px; border:solid 2px #becbd8;" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnSearch" style=" height:30px;" runat="server" Text=" 查询 " 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
         <hr style=" border:solid 1px #ffe6a4;" />
         
         <div style=" width:100%; height:25px; line-height:25px; font-size:12px; background-color:#edf0f7; text-align:left;">
         &nbsp;搜索词：<asp:Label ID="lbKewWord" runat="server" Text="Label"></asp:Label>
         </div>
         <br/>
         <div style=" clear:left;" align="center">
           <table class="tabList" width="800px" cellpadding="0" cellspacing="0">
             <asp:Repeater ID="rptData" runat="server" onitemdatabound="rptData_ItemDataBound">
                <ItemTemplate>
                 <tr>
                    <td align="left">
                        <asp:HyperLink ID="hylinkBT" Target="_blank" runat="server" Text='<%# Eval("BT") %>'></asp:HyperLink>
                        <asp:HiddenField ID="HFKID" Value='<%# Eval("KID") %>' runat="server" />
                    </td>
                </tr>
                <tr height="5px"></tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbTX" runat="server" Text='<%# Eval("TX") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        日期:<asp:Label ID="lbRQ" runat="server" Text='<%# Eval("RQ") %>'></asp:Label>  作者: 
                        <asp:Label ID="lbZZ" runat="server" Text='<%# Eval("ZZ") %>'></asp:Label>
                    </td>
                </tr>
                <tr height="10px"></tr>
                </ItemTemplate>
             </asp:Repeater>
             <tr>
                <td>
                    <cc1:pageControl goPage="1"  ID="PageControl1" runat="server" 
                        onclick="PageControl1_Click" />
                </td>
             </tr>
            </table>
            <br/>
         </div>
    </div>
    </form>
</body>
</html>
