using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class purchaseadd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 31; i++)
        {
            DropDownList1.Items.Add(i+"");
        }
        for (int i = 1; i <= 12; i++)
        {
            DropDownList2.Items.Add(i + "");
        } 
        for (int i = 2018; i < 2030; i++)
        {
            DropDownList3.Items.Add(i + "");
        }
        bind();
        bind1();
        string y = System.DateTime.Now.Year.ToString();
        string mon = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        string h = System.DateTime.Now.Hour.ToString();
        string min = System.DateTime.Now.Minute.ToString();
        string s = System.DateTime.Now.Second.ToString();
        TextBox9.Text = y + mon + day + h + min + s;
        TextBox10.Text = "1";
    }
    int zongshuliang;
    double zongjia;
    int psg_no_receive;
    int zongdanshu;

    int zongdanshu1;
    double zongzhichu;
    int p_kinds;
    int pur_unfinished;
    int kucun;

    
    private void bind()
    {
        string constr = "Data Source=localhost;database=phonemanager_db;uid=root;password=123456";

        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = "select * from purchasephoneview";

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "phone_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
    private void bind1()
    {
        string constr = "Data Source=localhost;database=phonemanager_db;uid=root;password=123456";

        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = "select * from purchaselackview where 是否处理缺件 = '否'";

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "phone_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView2.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView2.DataBind();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int rowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView2.Rows[rowIndex];

        string a = row.Cells[5].Text.ToString();
        string constr0 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon0 = new MySqlConnection(constr0);
        mycon0.Open();
        string sql0 = "update lack_table set dealed = '是' where date = '" + a + "'";
        MySqlCommand mycmd0 = new MySqlCommand(sql0, mycon0);
        if (mycmd0.ExecuteNonQuery() > 0)
        {
            Response.Write("<script>alert('操作成功');</script>");
        }
        else
        {
            Response.Write("<script>alert('操作失败');</script>");
        }
        mycon0.Close();
        // 数据库连接
        bind1();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string p_id = TextBox1.Text;
        string pr_number = TextBox2.Text;
        string pur_date = DropDownList3.SelectedItem.Text.ToString() + "-" + DropDownList2.SelectedItem.Text.ToString() + "-" + DropDownList1.SelectedItem.Text.ToString();
        string pur_way = DropDownList4.SelectedItem.Text;
        int pur_amount =  int.Parse(TextBox3.Text.ToString());
        double p_price =  double.Parse(TextBox4.Text.ToString());
        double p_summary = double.Parse(TextBox5.Text.ToString());
        string pur_card =   TextBox8.Text;
        string recrive_id = TextBox6.Text;
        string buy_id =    TextBox7.Text;
        string pur_id = TextBox9.Text;
        int pur_id_2 = int.Parse(TextBox10.Text.ToString());
       
        
        //向采购明细表中插入采购信息
        string constr = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        string sql = "insert into purchase_detail_table(p_id,pr_number,pur_date,pur_way,pur_amount,p_price,p_summary,pur_card,receive_id,buy_id,pur_id,pur_id_2,pur_received,pur_permit) values('"+p_id+"','"+pr_number+"','"+pur_date+"','"+pur_way+"','"+pur_amount+"','"+p_price+"','"+p_summary+"','"+pur_card+"','"+recrive_id+"','"+buy_id+"','"+pur_id+"','"+pur_id_2+"','否','否' )";
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            Response.Write( "<script>alert('已保存采购记录');</script>");
        }
        else
        {
            Response.Write("<script>alert('数据修改失败');</script>");
        }
        mycon.Close();


        //对采购汇总表1进行更新
        //先查询是否有相关信息
        int a = 0;
        string constr1 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon1 = new MySqlConnection(constr1);
        mycon1.Open();
        string sql1 = "select * from purchase_summary_good_table where p_id = '" + p_id + "'";
        MySqlCommand mycmd1 = new MySqlCommand(sql1, mycon1);
        MySqlDataReader reader1 = mycmd1.ExecuteReader();
       
        
       
        while (reader1.Read())
        {
            a++;
            zongshuliang = int.Parse(reader1[1].ToString()) + pur_amount;
            zongjia = p_summary + double.Parse(reader1[2].ToString());
            psg_no_receive = int.Parse(reader1[4].ToString()) + 1;
            zongdanshu = int.Parse(reader1[5].ToString()) + 1;
        }
        reader1.Close();
        mycon1.Close();

        //对于查询结果进行不同的方法调用
        string constr2 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon2 = new MySqlConnection(constr2);
        mycon2.Open();
        if (a == 1)//说明此时采购汇总表1中有此商品
        {
            string sql2_1 = "update purchase_summary_good_table set p_amount='"+zongshuliang+"',p_summary='"+zongjia+"',psg_no_receive='"+psg_no_receive+"',pur_amount='"+zongdanshu+"' where p_id='"+p_id+"' ";
            MySqlCommand mycmd2 = new MySqlCommand(sql2_1, mycon2);
            if (mycmd2.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已汇总到采购统计');</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');</script>");
            }
        }
        else//说明此时采购汇总表1中无此商品
        {
            string sql2_2 = "insert into purchase_summary_good_table(p_id,p_amount,p_summary,psg_received,psg_no_receive,pur_amount)  values('" + p_id + "','" + pur_amount + "','" + p_summary + "','0','1','1')";
            MySqlCommand mycmd2 = new MySqlCommand(sql2_2, mycon2);
            if (mycmd2.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已汇总到采购统计');</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');</script>");
            }
        }
        mycon2.Close();









        //对采购汇总表2进行更新
        //先查询是否有相关信息
        int a1 = 0;
        string constr3 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon3 = new MySqlConnection(constr3);
        mycon3.Open();
        string sql3 = "select * from purchase_summary_provider_table where pr_number = '" + pr_number + "'";
        MySqlCommand mycmd3 = new MySqlCommand(sql3, mycon3);
        MySqlDataReader reader3 = mycmd3.ExecuteReader();



        while (reader3.Read())
        {
            a1++;
            zongdanshu1 = int.Parse(reader3[1].ToString()) + 1;
            zongzhichu = p_summary + double.Parse(reader3[2].ToString());
            p_kinds = int.Parse(reader3[3].ToString()) + 1;
            pur_unfinished = int.Parse(reader3[4].ToString()) + 1;
        }
        reader3.Close();
        mycon3.Close();

        //对于查询结果进行不同的方法调用
        string constr4 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon4 = new MySqlConnection(constr4);
        mycon4.Open();
        if (a1 == 1)//说明此时采购汇总表2中有此商品
        {
            string sql4_1 = "update purchase_summary_provider_table set pur_amount='" + zongdanshu1 + "',pur_summary = '" + zongzhichu + "',p_kinds='" + p_kinds + "',pur_unfinish='" + pur_unfinished + "' where pr_number='" + pr_number + "' ";
            MySqlCommand mycmd4 = new MySqlCommand(sql4_1, mycon4);
            if (mycmd4.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已汇总到供应商采购记录');</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');</script>");
            }
        }
        else//说明此时采购汇总表2中无此商品
        {

            string sql4_2 = "insert into purchase_summary_provider_table(pr_number,pur_amount,pur_summary,p_kinds,pur_unfinish,pur_finished)  values('" + pr_number + "','1','" + p_summary + "','0','1','0')";
            MySqlCommand mycmd4 = new MySqlCommand(sql4_2, mycon4);
            if (mycmd4.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已汇总到供应商采购记录');</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');</script>");
            }
        }
        mycon4.Close();

        //对库存量进行更新
        //向设备详情表中插入数据
        //先查询是否有相关信息
        string constr7 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon7 = new MySqlConnection(constr7);
        mycon7.Open();
        string sql7 = "select   MAX(ph_id) from phone_detail_table where p_id = '" + p_id + "'";
        MySqlCommand mycmd7 = new MySqlCommand(sql7, mycon7);
        MySqlDataReader reader7 = mycmd7.ExecuteReader();
        int max = 0;
        while (reader7.Read())
        {
            max = int.Parse(reader7[0].ToString());

        }
        reader7.Close();
        mycon7.Close();
        //对于查询结果进行方法调用
        max++;
        string constr8 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon8 = new MySqlConnection(constr8);
        mycon8.Open();
        for (int i = 0; i < pur_amount; i++)
        {
            string sql8_1 = "insert  into  phone_detail_table(p_id,ph_id,saled,broken) values('" + p_id + "','" + max + "','否','否') ";
            MySqlCommand mycmd8 = new MySqlCommand(sql8_1, mycon8);
            mycmd8.ExecuteNonQuery();
            max++;
        }
        mycon8.Close();



        int a2 = 0;
        string constr5 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon5 = new MySqlConnection(constr5);
        mycon5.Open();
        string sql5 = "select * from sale_summary_table where p_id = '" + p_id + "'";
        MySqlCommand mycmd5 = new MySqlCommand(sql5, mycon5);
        MySqlDataReader reader5 = mycmd5.ExecuteReader();

        while (reader5.Read())
        {
            a2++;
            kucun = pur_amount + int.Parse(reader5[1].ToString());
        }
        reader5.Close();
        mycon5.Close();


        //对于查询结果进行不同的方法调用
        string constr6 = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon6 = new MySqlConnection(constr6);
        mycon6.Open();
        if (a2 == 1)//说明此时库存中有此商品
        {
            string sql6_1 = "update sale_summary_table set store_amount='" + kucun + "' where p_id='" + p_id + "' ";
            MySqlCommand mycmd6 = new MySqlCommand(sql6_1, mycon6);
            if (mycmd6.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已保存到库存数据');window.location='purchaseadd.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');window.location='purchaseadd.aspx'</script>");
            }
        }
        else//说明此时库存中无此商品
        {

            string sql6_2 = "insert into sale_summary_table(p_id,store_amount,saled_amount,earned)  values('" + p_id + "','" + pur_amount + "','0','0')";
            MySqlCommand mycmd6 = new MySqlCommand(sql6_2, mycon6);
            if (mycmd6.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('已保存到库存数据');window.location='purchaseadd.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('数据修改失败');window.location='purchaseadd.aspx'</script>");
            }
        }
        mycon6.Close();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string pid = TextBox1.Text.ToString();
        string constr = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        string sql = string.Format("select price_buy from phone_table where p_id='{0}'", pid);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = mycmd.ExecuteReader();
        string price = "";
        while (reader.Read())
        {
            price = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();
        TextBox4.Text = price;
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (TextBox4.Text.ToString() == "")
        {
            return;
        }
        double price = double.Parse(TextBox4.Text.ToString());
        double amount = double.Parse(TextBox3.Text.ToString());
        double summary = price * amount;
        TextBox5.Text = "" + summary;
    }
}