<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financePurchaseSummary.aspx.cs" Inherits="financePurchaseSummary" %>

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
        <td height="150"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td>
            <asp:Button ID="ButtonRefresh1" runat="server" Text="刷新" OnClick="ButtonRefresh1_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
            </asp:GridView>
          </td>
      </tr>
      <tr>
        <td>
            <asp:Button ID="ButtonRefresh2" runat="server" Text="刷新" OnClick="ButtonRefresh2_Click" />
            <asp:Label ID="Label2" runat="server"></asp:Label>
          </td>
      </tr>
      <tr>
        <td>
            <asp:GridView ID="GridView2" runat="server" BackColor="#CCFF99">
            </asp:GridView>
          </td>
      </tr>
      <tr>
        <td height="150"><img src="image/finance/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    <div>
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="16,35,254,67" href="financeHome.aspx">
</map></body>
</html>
