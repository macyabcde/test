<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ex.aspx.cs" Inherits="PU.web.PaperLook.ex" %>

<%@ Register src="../UserControl/head.ascx" tagname="head" tagprefix="uc1" %>
<%@ Register src="../UserControl/left.ascx" tagname="left" tagprefix="uc2" %>
<%@ Register src="../UserControl/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>模板</title>
     <link href="../css/style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:head ID="head2" runat="server" />
    
    <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="212" align="center" valign="top" background="images/leftdi.jpg">
        <uc2:left ID="left2" runat="server" />
      </td>
	<td width="1" align="center" valign="top" bgcolor="#FFFFFF"></td>
    <td width="5" bgcolor="#5F87BC"></td>
    <td valign="top">&nbsp;</td>
  </tr>
</table>

        <uc3:footer ID="footer2" runat="server" />
        
    </div>
    </form>
</body>
</html>
