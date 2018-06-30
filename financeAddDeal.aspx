<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeAddDeal.aspx.cs" Inherits="financeAddDeal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>财务科-添加收支记录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td colspan="4"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
        <tr>
          <td width="250" height="50">
              <asp:DropDownList ID="DropDownListYear" runat="server" Height="16px" Width="200px" OnSelectedIndexChanged="DropDownListYear_SelectedIndexChanged">
              </asp:DropDownList>
              年</td>
          <td width="250" height="50">
              <asp:TextBox ID="TextBoxAllocateMan" runat="server"></asp:TextBox>
              发款人</td>
          <td width="250" height="50">
              <asp:TextBox ID="TextBoxMoney" TextMode="Number" runat="server" Width="160px" Height="16px"></asp:TextBox>
              金额</td>
          <td width="250" height="50">
              <asp:RadioButton ID="RadioButton1" GroupName="gp1" runat="server" Text="收入" Checked="True" />
          </td>
        </tr>
        <tr>
          <td width="250" height="50">
              <asp:DropDownList ID="DropDownListMonth" runat="server" Height="16px" Width="200px" OnSelectedIndexChanged="DropDownListMonth_SelectedIndexChanged">
              </asp:DropDownList>
              月</td>
          <td width="250" height="50">
              <asp:TextBox ID="TextBoxAllocateCard" runat="server"></asp:TextBox>
              发款卡号</td>
          <td width="250" height="50">
              <asp:DropDownList ID="DropDownListDealway" runat="server" Height="16px" Width="170px">
              </asp:DropDownList>
              交易方式</td>
          <td width="250" height="50">
              <asp:RadioButton ID="RadioButton2" GroupName="gp1" runat="server" Text="支出" />
          </td>
        </tr>
        <tr>
          <td width="250" height="50">
              <asp:DropDownList ID="DropDownListDay" runat="server" Height="16px" Width="200px" OnSelectedIndexChanged="DropDownListDay_SelectedIndexChanged">
              </asp:DropDownList>
              日</td>
          <td width="250" height="50"><asp:TextBox ID="TextBoxReceiveMan" runat="server"></asp:TextBox>
              收款人</td>
          <td height="50" colspan="2"><asp:TextBox ID="TextBoxNote" runat="server" Width="399px"></asp:TextBox>
              备注</td>
        </tr>
        <tr>
          <td width="250" height="50">
              <asp:Button ID="ButtonSubmit" runat="server" Text="提交" Width="200px" OnClick="submit_Click"/>
          </td>
          <td width="250" height="50"><asp:TextBox ID="TextBoxReceiveCard" runat="server"></asp:TextBox>
              收款卡号</td>
          <td height="50" colspan="2">
              <asp:TextBox ID="TextBoxDealMan" runat="server" Width="160px"></asp:TextBox>
              办理人</td>
        </tr>
        <tr>
          <td colspan="4"><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
    </div>
    </form>

<map name="Map"><area shape="rect" coords="19,35,253,69" href="financeHome.aspx">
</map></body>
</html>
