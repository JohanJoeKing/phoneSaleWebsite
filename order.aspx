<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>确认订单</title>
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 21px;
            width: 113px;
        }
    </style>
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
    <td width="243" valign="top"><table width="243" border="0" cellspacing="1" cellpadding="0">
      <tr>
        <td width="241" bgcolor="#00CCFF">&nbsp;</td>
      </tr>
      <tr>
        <td align="center" bgcolor="#00CCFF"><a href="sale.aspx">手机查询</a></td>
      </tr>
     
      <tr>
        <td align="center" bgcolor="#00CCFF"><a href="ReturnPhone.aspx">手机退货</a></td>
      </tr>
      <tr>
        <td align="center" bgcolor="#00CCFF"><a href="lack.aspx">缺货上报</a></td>
      </tr>
      <tr>
        <td bgcolor="#00CCFF">&nbsp;</td>
      </tr>
    </table></td>
    <td width="754" valign="top"><table width="754" border="0" cellspacing="1" cellpadding="0">
      <tr>
        <td align="center">&nbsp;
            <asp:Label ID="Label1" runat="server" Text="确认购买订单"></asp:Label>
            </td>
      </tr>
      <tr>
        <td align="center"><p>&nbsp;</p>
          <table width="367" border="1" cellspacing="1">
            <tr>
              <td colspan="2" class="auto-style1">
                  <asp:Label ID="Label13" runat="server" Text="品牌"></asp:Label>
                  <asp:TextBox ID="brand" runat="server" Width="66px"></asp:TextBox>
                </td>
              <td class="auto-style2">
                  <asp:Label ID="Label14" runat="server" Text="型号"></asp:Label>
                  <asp:TextBox ID="model" runat="server" Width="72px"></asp:TextBox>
                </td>
              <td width="76" class="auto-style1">
                  <asp:Label ID="Label15" runat="server" Text="颜色"></asp:Label>
                  <asp:TextBox ID="color" runat="server" Width="35px"></asp:TextBox>
                </td>
              </tr>
            <tr>
            <td width="97">
                <asp:Label ID="Label2" runat="server" Text="商品编号"></asp:Label>
                </td>
            <td colspan="3">
                <asp:TextBox ID="p_id" runat="server"></asp:TextBox>
                </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="销售日期"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_date" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="销售单号"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_id" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="售价"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_price" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="销售数量"></asp:Label>
              </td>
            <td colspan="3">
                <asp:DropDownList ID="amount" runat="server">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="总价"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_summary" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="收银"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_get" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="销售工号"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_e_id" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="退补"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_return" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="销售方式"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="s_way" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="运营商编号"></asp:Label>
              </td>
            <td colspan="3">
                <asp:TextBox ID="pr_number" runat="server"></asp:TextBox>
              </td>
          </tr>
        </table>
          <p>
              <asp:Button ID="Button1" runat="server" Text="提交订单" OnClick="Button1_Click" />
&nbsp;
              <asp:Button ID="Button3" runat="server" Text="取消订单" OnClick="Button3_Click" />
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
