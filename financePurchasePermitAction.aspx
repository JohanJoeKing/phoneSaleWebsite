<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financePurchasePermitAction.aspx.cs" Inherits="financePurchasePermitAction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="150"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td><table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="400">
                <asp:Label ID="LabelBrand" runat="server" Text="品牌："></asp:Label>            </td>
            <td width="400">
                <asp:Label ID="LabelDate" runat="server" Text="申请日期："></asp:Label>              </td>
          </tr>
          <tr>
            <td width="400">
                <asp:Label ID="LabelModel" runat="server" Text="型号："></asp:Label>            </td>
            <td width="400">
                <asp:Label ID="LabelBuyway" runat="server" Text="采购方式:"></asp:Label>              </td>
          </tr>
          <tr>
            <td width="400">
                <asp:Label ID="LabelPrice" runat="server" Text="采购单价："></asp:Label>            </td>
            <td width="400">
                <asp:Label ID="LabelBuy" runat="server" Text="下单人:"></asp:Label>              </td>
          </tr>
          <tr>
            <td width="400" class="auto-style1">
                <asp:Label ID="LabelAmount" runat="server" Text="采购数量："></asp:Label>            </td>
            <td width="400" class="auto-style1">
                <asp:Label ID="LabelCard" runat="server" Text="使用卡号:"></asp:Label>              </td>
          </tr>
          <tr>
            <td width="400">
                <asp:Label ID="LabelSummary" runat="server" Text="采购总价："></asp:Label>            </td>
            <td width="400">
                <asp:Label ID="LabelProvider" runat="server" Text="供应商："></asp:Label>              </td>
          </tr>
          <tr>
            <td colspan="2"><div align="center">
                <asp:Button ID="ButtonPermit" runat="server" Text="批准" Width="241px" OnClick="ButtonPermit_Click" />
                </div></td>
          </tr>
          
        </table></td>
      </tr>
      <tr>
        <td height="150"><img src="image/finance/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    <div>
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="17,37,253,66" href="financePurchasePermit.aspx">
</map></body>
</html>
