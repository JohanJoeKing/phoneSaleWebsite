<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchaseadd.aspx.cs" Inherits="purchaseadd" Codepage="65001" %>
<!DOCTYPE html>
	
	

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Select2 {
            width: 42px;
        }
        #Select3 {
            width: 39px;
        }
    </style>
</head>
<body style="height: 270px">
    <form id="form1" runat="server">
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="150" colspan="11" align="center" valign="middle"><img src="image/purchase/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td height="150" colspan="11" align="center" valign="middle" style="overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
            </asp:GridView>
          </td>
      </tr>
              <tr>
        <td height="150" colspan="11" align="center" valign="middle" style="overflow: scroll">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  Height="145px" OnRowCommand="GridView2_RowCommand"  >

                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

                        <Columns>

                            <asp:BoundField DataField="品牌" HeaderText="品牌" ReadOnly="True" />

                            <asp:BoundField DataField="型号" HeaderText="型号" />

                            <asp:BoundField DataField="颜色" HeaderText="颜色" />
                 

                            <asp:BoundField DataField="进价" HeaderText="进价(元)" />


                            <asp:BoundField DataField="缺件数量" HeaderText="缺件数量(台)" />

                            <asp:BoundField DataField="缺件申请日期" HeaderText="缺件申请日期" />
                            <asp:ButtonField CommandName="agree" HeaderText="缺货申请状态" Text="处理"  />

                        </Columns>

                        <RowStyle ForeColor="#000066" />

                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />

                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />

                    </asp:GridView>


          </td>
      </tr>
      <tr>
        <td width="100"><label>手机编号：</label></td>
        <td width="100">
            <asp:TextBox ID="TextBox1" AutoPostBack="true" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>        </td>
        <td width="100">运营商编号：</td>
        <td width="100">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>        </td>
        <td width="100" align="right">采购日期：</td>
        <td width="45">
            <asp:DropDownList ID="DropDownList3" runat="server">            </asp:DropDownList>        </td>
        <td width="45">年</td>
        <td width="45">
            <asp:DropDownList ID="DropDownList2" runat="server">            </asp:DropDownList>        </td>
        <td width="45">月</td>
        <td width="45">
            <asp:DropDownList ID="DropDownList1" runat="server" >            </asp:DropDownList>        </td>
        <td width="45">日</td>
      </tr>
      <tr>
        <td>采购方式：</td>
        <td>
            <asp:DropDownList ID="DropDownList4" runat="server" style="margin-left: 0px">
                <asp:ListItem>询价采购</asp:ListItem>
                <%--<asp:ListItem>订单采购</asp:ListItem>--%>
                <asp:ListItem>合同采购</asp:ListItem>
                <asp:ListItem>订单采购</asp:ListItem>
            </asp:DropDownList>        </td>
        <td>采购数量：</td>
        <td>
            <asp:TextBox ID="TextBox3" AutoPostBack="true" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>        </td>
        <td align="right"> 单价：</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Width="60px"></asp:TextBox>        </td>
        <td>元</td>
        <td>&nbsp;</td>
        <td align="right">总价：</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Width="60px"></asp:TextBox>        </td>
        <td>元</td>
      </tr>
      <tr>
        <td>采购银行卡号：</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>        </td>
        <td align="right">收货人工号：</td>
        <td colspan="6">
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>        </td>
      </tr>
      <tr>
        <td>采购单号：</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>        </td>
        <td align="right">下单人工号：</td>
        <td colspan="6">
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>        </td>
      </tr>
      <tr>
        <td>采购二级单号：</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td align="center"colspan="11">
            <asp:Button ID="Button1" runat="server" Text="提交订单" OnClick="Button1_Click" />        </td>
      </tr>
      <tr>
        <td height="150" colspan="11"><div align="center"><img src="image/purchase/tail.png" width="1000" height="150"></div></td>
      </tr>
    </table>
    <div style="height: 20px">
    
    </div>
</form>

<map name="Map"><area shape="rect" coords="16,35,258,69" href="index.aspx">
</map></body>
</html>
