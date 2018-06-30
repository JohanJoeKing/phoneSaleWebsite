<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeDealDetail.aspx.cs" Inherits="financeDealDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>财务科-门店收支明细</title>
<style type="text/css">
<!--
body,td,th {
	color: #666666;
}
-->
</style></head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
        <tr>
          <td>
              <asp:RadioButton ID="RadioButton1" GroupName="gp1" AutoPostBack="true" runat="server" Text="默认" Checked="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
              <asp:RadioButton ID="RadioButton2" GroupName="gp1" AutoPostBack="true" runat="server" Text="收入" OnCheckedChanged="RadioButton2_CheckedChanged" />
              <asp:RadioButton ID="RadioButton3" GroupName="gp1" AutoPostBack="true" runat="server" Text="支出" OnCheckedChanged="RadioButton3_CheckedChanged" />
          </td>
        </tr>
        <tr>
          <td>
              <asp:GridView ID="GridView1" runat="server" BackColor="#CCFFCC"></asp:GridView>
          </td>
        </tr>
        <tr>
          <td><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
    </div>
    </form>


<map name="Map"><area shape="rect" coords="17,33,257,70" href="financeHome.aspx">
</map></body>
</html>
