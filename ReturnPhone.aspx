<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnPhone.aspx.cs" Inherits="ReturnPhone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body><center>
    <form id="form1" runat="server">
   <table width="1000" border="0" cellspacing="1" cellpadding="0" CaptionAlign="align">
  <tr>
    <td><div align="center"><img src="image/sale/head.png" width="1000" height="150" border="0" usemap="#Map"/>
<map name="Map"><area shape="rect" coords="18,36,254,65" href="sale.aspx">
</map></div></td>
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
        <td align="center">
            <asp:Label ID="Label1" runat="server" Text="请输入销售单号"></asp:Label>
            <asp:TextBox ID="chaxundingdan" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button2_Click" />
            </td>
      </tr>
      <tr>
        <td align="center"><table width="367" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td width="176">
                <asp:Label ID="Label2" runat="server" Text="商品编号"></asp:Label>
                </td>
            <td width="178">
                <asp:TextBox ID="p_id" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="销售日期"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_date" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="销售单号"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_id" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="售价"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="s_price" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="销售数量"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_amount" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="总价"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_summary" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="收银"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_get" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="销售工号"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_e_id" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="退补"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_return" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="销售方式"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="s_way" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
          <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="运营商编号"></asp:Label>
              </td>
            <td>
                <asp:TextBox ID="pr_number" runat="server" ReadOnly="True"></asp:TextBox>
              </td>
          </tr>
        </table>
          <p>
              <asp:Button ID="Button1" runat="server" Text="确认退货" OnClick="Button1_Click" />
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
    <td><div align="center"><img src="image/sale/tail.png" width="1000" height="150"></div></td>
  </tr>
</>

    </form>
    </center>
</body>
</html>
