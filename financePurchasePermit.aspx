<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financePurchasePermit.aspx.cs" Inherits="financePurchasePermit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="150"><img src="image/finance/head.png" width="1000" height="150" border="0" usemap="#Map"></td>
      </tr>
      <tr>



        <%
            // 静态连接数据库
            string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            "localhost","root","123456","phonemanager_db");
            MySqlConnection mycon = new MySqlConnection(link);
            
            // 打开连接
            mycon.Open();
            
            // 定义语句
            string sql = string.Format("select * from financesubpagepurchasepermitview");
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            MySqlDataReader reader = null;
            
            // 执行查询
            reader = mycmd.ExecuteReader();
            
            // 收集数据
            string brand = "";    // 商品
            string price = "";    // 单价
            string amount = "";   // 数量
            string summary = "";  // 总价
            string buy = "";      // 申请人
            string date = "";     // 申请日期
            string buyWay = "";   // 采购途径
            string purid = "";    // 单号
            string permit = "";   // 批准状态
        %>
        <td><table width="1000" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="100" bgcolor="#CCFF99"><div align="center">商品</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">单价</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">数量</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">总价</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">申请人</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">日期</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">采购方式</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center">单号</div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center"></div></td>
            <td width="100" bgcolor="#CCFF99"><div align="center"></div></td>
          </tr>

          <%
            while(reader.Read())
            {
                brand = reader[0].ToString() + reader[1].ToString();
                price = reader[2].ToString();
                amount = reader[3].ToString();
                summary = reader[4].ToString();
                date = reader[5].ToString();
                buyWay = reader[6].ToString();
                purid = reader[7].ToString();
                buy = reader[8].ToString();
                permit = reader[9].ToString();

                string permited = "";  // 批准提示
                string solve = "";     // 处理提示

                if (permit == "是")
                {
                    permited = "已批准";
                }
                else
                {
                    solve = "去处理";
                }
          %>

          <tr>
            <td><div align="center"><%= brand %></div></td>
            <td><div align="center"><%= price %></div></td>
            <td><div align="center"><%= amount %></div></td>
            <td><div align="center"><%= summary %></div></td>
            <td><div align="center"><%= buy %></div></td>
            <td><div align="center"><%= date %></div></td>
            <td><div align="center"><%= buyWay %></div></td>
            <td><div align="center"><%= purid %></div></td>
            <td><div align="center"><%= permited %></div></td>
            <td><div align="center"><a href="financePurchasePermitAction.aspx?id=<%= purid %>"><%= solve %></a></div></td>
          </tr>
            <%
                } // while
            %>
        </table>
        <%
            // 关闭连接
            reader.Close();
            mycon.Close();
        %>





        </td>
      </tr>
      <tr>
        <td height="150"><img src="image/finance/tail.png" width="1000" height="150"></td>
      </tr>
    </table>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>

<map name="Map"><area shape="rect" coords="18,36,252,65" href="financeHome.aspx">
</map></body>
</html>
