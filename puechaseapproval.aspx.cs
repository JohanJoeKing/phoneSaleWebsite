using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class puechaseapproval : System.Web.UI.Page
{
    private MyDatabase MDB;
    private string constr;
    private const string SELECT_SALE_SUMMARY = "select * from purchase_detail_table where pur_received='否' and pur_permit='是'";

    protected void Page_Load(object sender, EventArgs e)
    {
        // 数据库连接
        MDB = new MyDatabase();
        constr = MDB.getConnection();
        // 加载数据库
        bind(SELECT_SALE_SUMMARY);
    }
    private void bind(string sql)
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句  
        string cmdSQL = sql;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "sale_summary_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }



    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "agree")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowIndex]; 

            string a = row.Cells[8].Text.ToString();
            string b = row.Cells[9].Text.ToString();
            string constr = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = "update purchase_detail_table set pur_received = '是' where pur_id = '" + a + "' and pur_id_2 = '" + b + "'";
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('操作成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('操作失败');</script>");
            }
            mycon.Close();
            // 数据库连接
            MDB = new MyDatabase();
            constr = MDB.getConnection();
            // 加载数据库
            bind(SELECT_SALE_SUMMARY);
        }
        if (e.CommandName == "refuse")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowIndex];

            int a = int.Parse(row.Cells[8].Text.ToString());
            int b = int.Parse(row.Cells[9].Text.ToString());

            string constr = "server=localhost;User Id=root;password=123456;Database=phonemanager_db";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            string sql = "delete from purchase_detail_table where pur_id = '" + a + "' and pur_id_2 = '" + b + "'";
            MySqlCommand mycmd = new MySqlCommand(sql, mycon);
            if (mycmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('操作成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('操作失败');</script>");
            }
            mycon.Close();
            // 数据库连接
        MDB = new MyDatabase();
        constr = MDB.getConnection();
        // 加载数据库
        bind(SELECT_SALE_SUMMARY);
        }
    }
  
}