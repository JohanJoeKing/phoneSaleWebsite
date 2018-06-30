<%@ Page Language="C#" AutoEventWireup="true" CodeFile="puechaseapproval.aspx.cs" Inherits="puechaseapproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 76px;
        }
        .auto-style2 {
            width: 82px;
        }
        .auto-style3 {
            width: 82px;
            height: 38px;
        }
        .auto-style4 {
            width: 76px;
            height: 38px;
        }
        .auto-style5 {
            height: 38px;
        }
        .auto-style6 {
            width: 103px;
            height: 38px;
        }
        .auto-style7 {
            width: 103px;
        }
        .auto-style8 {
            height: 38px;
            width: 117px;
        }
        .auto-style9 {
            width: 117px;
        }
        .auto-style10 {
            width: 112px;
        }
        .auto-style13 {
            width: 92px;
            height: 38px;
        }
        .auto-style14 {
            width: 92px;
        }
        .auto-style15 {
            width: 88px;
            height: 38px;
        }
        .auto-style16 {
            width: 88px;
        }
    </style>
</head>
<body>
   
   <form id="form1" runat="server">
       <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
         <tr>
           <td height="150"><img src="image/repository/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
         </tr>
         <tr>
           <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Height="145px" OnRowCommand="GridView1_RowCommand"  >
             <footerstyle BackColor="#990000" Font-Bold="True" ForeColor="White" />           
             <columns>
               <asp:BoundField DataField="p_id" HeaderText="商品编号" ReadOnly="True" />
               <asp:BoundField DataField="pr_number" HeaderText="运营商编号" />
               <asp:BoundField DataField="pur_way" HeaderText="采购方式" />
               <asp:BoundField DataField="pur_amount" HeaderText="采购数量(台)" />
               <asp:BoundField DataField="p_summary" HeaderText="采购总价(元)" />
               <asp:BoundField DataField="pur_card" HeaderText="采购银行卡号" />
               <asp:BoundField DataField="receive_id" HeaderText="收货人工号" />
               <asp:BoundField DataField="buy_id" HeaderText="下单人工号" />
               <asp:BoundField DataField="pur_id" HeaderText="采购单号" />
               <asp:BoundField DataField="pur_id_2" HeaderText="采购二级单号" />
               <asp:ButtonField CommandName="agree" HeaderText="评审结果" Text="确认验收"  />
               <asp:ButtonField CommandName="refuse" HeaderText="评审结果" Text="拒绝验收" />
             </columns>
             <pagerstyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />           
             <headerstyle BackColor="#006699" Font-Bold="True" ForeColor="White" />           
</asp:GridView></td>
         </tr>
         <tr>
           <td height="150"><img src="image/purchase/tail.png" width="1000" height="150"></td>
         </tr>
       </table>
</form>
       


<map name="Map"><area shape="rect" coords="18,34,254,66" href="storequery.aspx">
</map></body>
</html>
