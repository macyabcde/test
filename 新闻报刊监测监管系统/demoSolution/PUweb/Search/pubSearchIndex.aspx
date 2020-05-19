<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pubSearchIndex.aspx.cs" Inherits="PU.web.Search.pubSearchIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:730px; margin:0 auto; text-align:center; margin-top:50px;">
        int<img src="../images/qianfang.gif" />
        <hr style=" border:solid 1px #ffe6a4;" />
        <div style=" padding-top:40px; padding-bottom:30px; font-size:12px;">
        全文搜索<asp:TextBox ID="tbKeyWard" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text=" 搜索 " 
                onclick="btnSearch_Click" />
        </div>
        <div style=" border-top:solid 1px #555555; background-color:#e5e5e5; height:30px; line-height:30px; font-size:12px;">
            <asp:Label ID="lbFooter" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
