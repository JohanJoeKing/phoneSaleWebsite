<%@ Page Language="C#" AutoEventWireup="true" CodeFile="storequery.aspx.cs" Inherits="storequery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="1000" height="150"><img src="image/repository/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td><a href="puechaseapproval.aspx">验收入库</a></td>
      </tr>
      <tr>
        <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Height="145px" Width="511px"   >
          <footerstyle BackColor="#990000" Font-Bold="True" ForeColor="White" />        
          <columns>
          <asp:BoundField DataField="p_id" HeaderText="商品编号" ReadOnly="True" />
              <asp:BoundField DataField="p_brand" HeaderText="品牌" ReadOnly="True" />
              <asp:BoundField DataField="p_model" HeaderText="型号" ReadOnly="True" />
          <asp:BoundField DataField="ph_id" HeaderText="产品序号" />
          <asp:BoundField DataField="saled" HeaderText="是否损坏" />
          <asp:BoundField DataField="broken" HeaderText="是否售出" />
          </columns>
          <RowStyle ForeColor="#000066" />
          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
          <pagerstyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />        
          <headerstyle BackColor="#006699" Font-Bold="True" ForeColor="White" />        
</asp:GridView></td>
      </tr>
      <tr>
        <td width="1000" height="150"><img src="image/repository/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    
</form>

<map name="Map"><area shape="rect" coords="18,35,254,67" href="index.aspx">
</map></body>
</html>
