using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class sale : System.Web.UI.Page
{
    // 数据库连接属性
    private MyDatabase MDB;
    private SaleService SS;
    private string constr;
    private const string SELECT_SALE_SUMMARY = "select * from sale_summary_table";
    protected void Page_Load(object sender, EventArgs e)
    {
        SS = new SaleService();
        // 数据库连接
        MDB = new MyDatabase();
        constr = MDB.getConnection();
        // 加载数据库
        bind(SELECT_SALE_SUMMARY);
        bind2();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string brand = TextBox1.Text.ToString();
        string model = TextBox2.Text.ToString();
        string color = TextBox3.Text.ToString();
       
        if(TextBox1.Text=="" || TextBox2.Text == ""  || TextBox3.Text =="")
            Response.Write("<script>alert('请输入要查询手机信息！');</script>");
        else
        {
            string phone_id = SS.searchPhone(brand,model,color);
            //Response.Write("<script>alert('"+phone_id+"');</script>");
            string s_sql = "select * from sale_summary_table where p_id=" + phone_id;
            bind(s_sql);
        }
        
        
    }

     /*****************************************************
     * - Function name : bind
     * - Description : 页面加载
     * - Variables : string sql
     *****************************************************/
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




    /*****************************************************
     * - Function name : bind2
     * - Description : 页面加载
     * - Variables : string sql
     *****************************************************/
    private void bind2()
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句  
        string cmdSQL = "select * from purchasephoneview";

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



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        int index = gvrow.RowIndex;
        string id = ((GridView)sender).DataKeys[index].Values["p_id"].ToString();
        Response.Redirect("order.aspx?value="+id);
    }
}