<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financeHome.aspx.cs" Inherits="financeHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>财务科界面</title>
</head>
<style>
    .a td{font-family:微软雅黑;font-size:16px;color:#666666}
    .auto-style1 {
        height: 20px;
    }
	a:link{font-family:微软雅黑;color:#666666;text-decoration:none}
	a:hover{font-family:微软雅黑;color:#333333;text-decoration:none}
	
</style>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="1000" border="0" align="center" cellpadding="0">
        <tr>
          <td width="1000" height="150"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
      </table>
      <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" class="a">
        <tr>
          <td width="200" bgcolor="#ACDAE0" class="auto-style1" style="font-family: 微软雅黑"><div align="left">工号：<asp:TextBox ID="TextBoxEid" MaxLength="100" runat="server" Width="90px"></asp:TextBox></div>            </td>
          <td width="800" class="auto-style1">
              <asp:Button ID="ButtonRefresh1" runat="server" Text="刷新" OnClick="Refresh1_Click"/>
              <asp:Label ID="label1" runat="server" Text="新的采购申请：0条"></asp:Label></td>
        </tr>
        <tr>
          <td width="200" height="20" bgcolor="#ACDAE0" style="font-family: 微软雅黑"><div align="left">密码：<asp:TextBox ID="TextBoxPW" MaxLength="100" TextMode="Password" runat="server" Width="90px"></asp:TextBox></div>          </td><td width="800" rowspan="15" style="overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
                <SelectedRowStyle BackColor="#CCFFFF" />
            </asp:GridView>
          </td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20" style="font-family: 微软雅黑"><div align="left">姓名：<asp:TextBox ID="TextBoxName" MaxLength="100" runat="server" ReadOnly="True" Width="90px"></asp:TextBox></div>            </td></tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20" style="font-family: 微软雅黑"><div align="left">职位：<asp:TextBox ID="TextBoxPosition" MaxLength="100" runat="server" ReadOnly="True" Width="90px"></asp:TextBox></div>            </td></tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20" style="font-family: 微软雅黑">
              <asp:Button ID="ButtonLogin" OnClick="login_Click" runat="server" Text="登录" />
              <asp:Button ID="ButtonLogout" OnClick="logout_Click" runat="server" Text="注销" />          </td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><div align="left"></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><div align="left"><a href="financeDealDetail.aspx">查看收支明细</a></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><div align="left"><a href="financePurchasePermit.aspx">采购申请处理</a></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><div align="left"><a href="financeAddDeal.aspx">添加收支记录</a></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><div align="left"><a href="financePurchaseDetail.aspx">采购明细</a></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" class="auto-style1"><div align="left"><a href="financePurchaseSummary.aspx">采购汇总</a></div></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><a href="financeIESummary.aspx">财务汇总</a></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20"><a href="financeSaleSummary.aspx">销售汇总</a></td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr>
          <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
          <td width="800" height="20">
              <asp:Button ID="ButtonRefresh2" runat="server" Text="刷新" OnClick="Refresh2_Click"/>
              <asp:Label ID="labelTime" runat="server" Text="当前时间："></asp:Label>          </td>
        </tr>
        <tr>
          <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
          <td width="800" rowspan="15" style="overflow: scroll">
              <asp:GridView ID="GridView2" runat="server" BackColor="#CCFF99">
                  <SelectedRowStyle BackColor="#CCFFCC" />
              </asp:GridView>          </td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
        <tr bgcolor="#ACDAE0">
          <td width="200" height="20">&nbsp;</td>
        </tr>
      </table>
      <table width="1000" border="0" align="center" cellpadding="0">
        <tr>
          <td width="1000"><img src="image/homepage/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
      <div align="center"></div>
    </div>
    </form>


<map name="Map"><area shape="rect" coords="16,34,259,69" href="index.aspx">
</map></body>
</html>
