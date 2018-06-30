<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sale.aspx.cs" Inherits="sale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>手机查询</title>
    <style type="text/css">
        .auto-style1 {
            width: 996px;
            height: 17px;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            height: 181px;
        }
        .auto-style4 {
            width: 832px;
        }
        .auto-style5 {
            height: 24px;
            width: 832px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <table width="1000" border="0" cellspacing="1" cellpadding="0" CaptionAlign="align">
  <tr>
    <td><div align="center"><img src="image/sale/head.png" width="1000" height="150" border="0" usemap="#Map"/>
<map name="Map"><area shape="rect" coords="15,35,253,66" href="index.aspx">
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
        <asp:Label ID="Label1" runat="server" Text="手机品牌"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="手机型号"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="颜色"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
        </td>
      </tr>
      <tr>
        <td align="center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"   DataKeyNames="p_id">
        <Columns>
            <asp:BoundField DataField="p_id" HeaderText="手机编号" ReadOnly="True" />
            <asp:BoundField DataField="store_amount" HeaderText="库存量" ReadOnly="True" />
            <asp:BoundField DataField="saled_amount" HeaderText="销售量" ReadOnly="True" />
            <asp:TemplateField HeaderText="操作">
           <ItemTemplate>
              <asp:LinkButton ID="lbtn_redact" runat="server" CommandName="redact" >选购</asp:LinkButton>
            </ItemTemplate>
            <Itemstyle HorizontalAlign="Center" />
           </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </td>
      </tr>
      <tr>
        <td align="center">
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>          </td>
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
</body>
</html>
