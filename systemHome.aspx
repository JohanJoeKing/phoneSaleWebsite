<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemHome.aspx.cs" Inherits="systemHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<style>
    .a td{font-family:微软雅黑;font-size:16px;color:#666666}
    a:link{font-family:微软雅黑;color:#666666;text-decoration:none}
	a:hover{font-family:微软雅黑;color:#333333;text-decoration:none}
	
    .auto-style1 {
        height: 20px;
    }
	
</style>
<body>
<form id="form1" runat="server">
    <div>
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" class="a">
      <tr>
        <td height="150" colspan="2"><img src="image/system/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">账号<asp:TextBox ID="TextBoxAccount" runat="server" Width="130px"></asp:TextBox>
          </td>
        <td width="800" height="20">
            <asp:Label ID="LabelCurrentTime" runat="server" Text="当前时间："></asp:Label>
          </td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">密码<asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" Width="130px"></asp:TextBox>
          </td>
        <td width="800" rowspan="8" style="overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">
            </asp:GridView>
          </td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">
            <asp:Button ID="ButtonLoggin" runat="server" OnClick="ButtonLoggin_Click" Text="登录" />
          </td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">
            <asp:Label ID="LabelLogState" runat="server" Text="登录状态："></asp:Label>
          </td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0"><div align="left"><a href="systemGoods.aspx">我的商品</a></div></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0"><div align="left"><a href="systemEmployee.aspx">职工信息</a></div></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0"><div align="left"><a href="systemProvider.aspx">供货商管理</a></div></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0"><div align="left"><a href="systemUser.aspx">系统账户</a></div></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" bgcolor="#ACDAE0" class="auto-style1"></td>
        <td width="800" class="auto-style1"></td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td width="200" height="20" bgcolor="#ACDAE0">&nbsp;</td>
        <td width="800" height="20">&nbsp;</td>
      </tr>
      <tr>
        <td height="150" colspan="2"><img src="image/system/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="17,36,255,67" href="index.aspx">
</map></body>
</html>
