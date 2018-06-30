<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemEmployee.aspx.cs" Inherits="systemEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="150"><img src="image/system/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td>
            <asp:Button ID="ButtonRefresh" runat="server" Text="刷新" OnClick="ButtonRefresh_Click" />
          </td>
      </tr>
      <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
            </asp:GridView>
          </td>
      </tr>
      <tr>
        <td height="150"><img src="image/system/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    <div>
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="17,35,256,67" href="systemHome.aspx">
</map></body>
</html>
