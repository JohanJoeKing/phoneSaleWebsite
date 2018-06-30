<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financePurchaseDetail.aspx.cs" Inherits="financePurchaseDetail" %>

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
          <td width="1000" height="150"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
        <tr>
          <td>
              <asp:RadioButton ID="RadioButton1" AutoPostBack="true" runat="server" Checked="True" GroupName="gp1" Text="默认" OnCheckedChanged="RadioButton1_CheckedChanged" />
              <asp:RadioButton ID="RadioButton2" AutoPostBack="true" runat="server" GroupName="gp1" Text="已批准" OnCheckedChanged="RadioButton2_CheckedChanged" />
              <asp:RadioButton ID="RadioButton3" AutoPostBack="true" runat="server" GroupName="gp1" Text="未批准" OnCheckedChanged="RadioButton3_CheckedChanged" />
          </td>
        </tr>
        <tr>
          <td>
              <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
              </asp:GridView>
          </td>
        </tr>
        <tr>
          <td><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
    </div>
    </form>


<map name="Map"><area shape="rect" coords="16,34,256,69" href="financeHome.aspx">
</map></body>
</html>
