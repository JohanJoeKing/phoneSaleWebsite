using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : systemProvider.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/30
 * - Description : 本文件为系统管理职工界面
 * - Function list :
 * 1.Page_Load
 * 2.ButtonRefresh_Click
 * 3.bind
 * -Others : 
 * [刘畅]2018/5/30第一次修改，实现基本显示功能
 ***************************************************/

public partial class systemProvider : System.Web.UI.Page
{
    // 数据库连接
    private MyDatabase MDB;
    private const string SELECT_PROVIDER_DATA = "select * from systemproviderView";





    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 实例化一个数据框操作对象
        MDB = new MyDatabase();

        // 加载数据
        bind(SELECT_PROVIDER_DATA);
    }





    /*****************************************************
     * - Function name : ButtonRefresh_Click
     * - Description : 刷新数据
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonRefresh_Click(object sender, EventArgs e)
    {
        // 加载数据
        bind(SELECT_PROVIDER_DATA);
    }




    /*****************************************************
     * - Function name : bind
     * - Description : 加载数据
     * - Variables : string sql
     *****************************************************/
    private void bind(string sql)
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(MDB.getConnection());

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = sql;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "provider_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
}