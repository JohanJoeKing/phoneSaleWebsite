<%@ Page Language="C#" AutoEventWireup="true" CodeFile="systemUser.aspx.cs" Inherits="systemUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    .a td{font-family:微软雅黑;font-size:16px;color:#666666}
    a:link{font-family:微软雅黑;color:#666666;text-decoration:none}
	a:hover{font-family:微软雅黑;color:#333333;text-decoration:none}
	
    .auto-style1 {
        height: 20px;
    }
	
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table class="a" width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="150" colspan="4"><img src="image/system/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
        </tr>
        <tr>
          <td width="250">账户<asp:TextBox ID="TextBoxAccount" runat="server"></asp:TextBox>            </td>
          <td width="250">密码<asp:TextBox ID="TextBoxPassword" runat="server" Width="148px"></asp:TextBox>            </td>
          <td width="250">系统角色<asp:DropDownList ID="DropDownListStatus" AutoPostBack="true" runat="server" Width="130px">
              </asp:DropDownList>            </td>
          <td width="250">&nbsp;</td>
        </tr>
        <tr>
          <td width="250">工号<asp:TextBox ID="TextBoxEid" runat="server"></asp:TextBox>            </td>
          <td width="250">姓名<asp:TextBox ID="TextBoxName" runat="server" Width="148px"></asp:TextBox>            </td>
          <td width="250">
              <asp:Button ID="ButtonAdd" runat="server" Text="添加" Width="192px" OnClick="ButtonAdd_Click" />            </td>
          <td width="250">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="4" style="overflow: scroll">
              <asp:GridView ID="GridView1" runat="server" BackColor="#CCFF99">              </asp:GridView>            </td>
        </tr>
        <tr>
          <td colspan="4" class="auto-style1">账户修改</td>
        </tr>
        <tr>
          <td width="250">工号<asp:TextBox ID="TextBoxCeid" AutoPostBack="true" runat="server" OnTextChanged="TextBoxCeid_TextChanged"></asp:TextBox>
            </td>
          <td width="250">密码<asp:TextBox ID="TextBoxCpassword" runat="server"></asp:TextBox>
            </td>
          <td width="250">系统角色<asp:DropDownList ID="DropDownListCstatus" runat="server" Height="16px" Width="130px" OnSelectedIndexChanged="DropDownListCstatus_SelectedIndexChanged">
              </asp:DropDownList>
            </td>
          <td width="250">&nbsp;</td>
        </tr>
        <tr>
          <td width="250">账号<asp:TextBox ID="TextBoxCaccount" runat="server"></asp:TextBox>
            </td>
          <td width="250">姓名<asp:TextBox ID="TextBoxCname" runat="server"></asp:TextBox>
            </td>
          <td width="250">
              <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="保存" Width="100px" />
              <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="删除" Width="100px" />
            </td>
          <td width="250">&nbsp;</td>
        </tr>
        <tr>
          <td height="150" colspan="4"><img src="image/system/tail.png" width="1000" height="150"></td>
        </tr>
      </table>
    </div>
    </form>

<map name="Map"><area shape="rect" coords="17,33,254,67" href="systemHome.aspx">
</map></body>
</html>
