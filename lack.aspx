<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lack.aspx.cs" Inherits="lack" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>确认订单</title>
    </head>
<body>
    <center>
    <form id="form1" runat="server">
   <table width="1000" border="0" cellspacing="1" cellpadding="0" CaptionAlign="align">
  <tr>
    <td><img src="image/sale/head.png" width="1000" height="150"/></td>
  </tr>
  <tr>
    <td><table width="1000" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="243" valign="top" style="width: 997px"><table width="754" border="0" cellspacing="1" cellpadding="0">
      <tr>
        <td align="center">&nbsp;
            <asp:Label ID="Label1" runat="server" Text="提交缺货申请"></asp:Label>
            </td>
      </tr>
      <tr>
        <td align="center"><p>&nbsp;</p>
          <table width="367" border="1" cellspacing="1">
            <tr>
            <td width="97">
                <asp:Label ID="Label2" runat="server" Text="商品编号"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="p_id" runat="server"></asp:TextBox>
                </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="提交日期"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="date" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="销售数量"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="amount" runat="server"></asp:TextBox>
              </td>
          </tr>
          </table>
          <p>
              <asp:Button ID="Button1" runat="server" Text="提交缺货单" OnClick="Button1_Click" style="height: 21px" />
&nbsp;
              </p>
            </td>
      </tr>
      <tr>
        <td align="center">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
</td>
  </tr>
  <tr>
    <td><img src="image/sale/tail.png" width="1000" height="150"></td>
  </tr>
</>
   </form>
</center>
</body>
</html>
