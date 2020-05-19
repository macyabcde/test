<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="User.Web.select.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/client.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       UserGUID： <asp:TextBox ID="tbUserGUID" runat="server"></asp:TextBox><br/>
       UserName： <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox><br/>
        <asp:Button ID="btnSelMoreUser" runat="server" OnClientClick="return selectUserMore('tbUserGUID','tbUserName');" Text="多用户选择" />
        <br/>
       DepartID：<asp:TextBox ID="tbDepartID" runat="server"></asp:TextBox><br/>
       DepartName：<asp:TextBox ID="tbDepartName" runat="server"></asp:TextBox><br/>
        <asp:Button ID="btnSelDepart" runat="server" Text="选择部门" OnClientClick="return selectOneDepart('tbDepartID','tbDepartName');" />
        <br />
        UserGUID：<asp:TextBox ID="tbUserOneGUID" runat="server"></asp:TextBox><br/>
        UserName：<asp:TextBox ID="tbUserOneName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSelOneUser" runat="server" Text="单用户选择" OnClientClick="return selectOneUser('tbUserOneGUID','tbUserOneName');" />
    </div>
    </form>
</body>
</html>
