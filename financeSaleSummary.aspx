﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeSaleSummary.aspx.cs" Inherits="financeSaleSummary" %>

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
            <asp:Button ID="ButtonRefresh" runat="server" OnClick="ButtonRefresh_Click" Text="刷新" />
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
            <asp:Label ID="LabelSummary" runat="server" Text="总收入："></asp:Label>
          </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td height="150"><img src="image/system/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    <div>
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="18,35,254,66" href="financeHome.aspx">
</map></body>
</html>
