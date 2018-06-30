<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeIESummary.aspx.cs" Inherits="financeIncomeSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td colspan="5"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
        <tr>
          <td width="200">
              <asp:RadioButton ID="RadioButton1" AutoPostBack="true" GroupName="gp1" runat="server" Checked="True" Text="默认" OnCheckedChanged="RadioButton1_CheckedChanged" />
              <asp:RadioButton ID="RadioButtonIncome" AutoPostBack="true" GroupName="gp1" runat="server" Text="收入" OnCheckedChanged="RadioButtonIncome_CheckedChanged" />
              <asp:RadioButton ID="RadioButtonExpense" AutoPostBack="true" GroupName="gp1" runat="server" Text="支出" OnCheckedChanged="RadioButtonExpense_CheckedChanged" />            </td>
          <td width="200">
              <asp:Button ID="ButtonPrintSummary" runat="server" Text="打印汇总报告" OnClick="buttonPrintSummary_Click"/>
          </td>
          <td width="200">&nbsp;</td>
          <td width="200">&nbsp;</td>
          <td width="200">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="5">
              <asp:Label ID="LabelDate" runat="server" Text="当前日期"></asp:Label>            </td>
        </tr>
        <tr>
          <td colspan="5">
              <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">              </asp:GridView>            </td>
        </tr>
        <tr>
          <td width="200">
              <asp:Label ID="LabelIncomeSummary" runat="server" Text="总收入：0元"></asp:Label>            </td>
          <td width="200">
              <asp:Label ID="LabelExpenseSummary" runat="server" Text="总支出：0元"></asp:Label>            </td>
          <td width="200">
              <asp:Label ID="LabelIncomes" runat="server" Text="收入记录：0条"></asp:Label>            </td>
          <td width="200">
              <asp:Label ID="LabelExpenses" runat="server" Text="支出记录：0条"></asp:Label>            </td>
          <td width="200">
              <asp:Label ID="LabelEarn" runat="server" Text="盈利：0元"></asp:Label>            </td>
        </tr>
        <tr>
          <td colspan="5"><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
    </div>
    </form>


<map name="Map"><area shape="rect" coords="16,34,255,70" href="financeHome.aspx">
</map></body>
</html>
