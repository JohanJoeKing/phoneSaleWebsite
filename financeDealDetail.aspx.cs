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
 * - Filename : financeDealDetail.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/21
 * - Description : 本文件为财务科查看收支明细的页面
 * - Function list :
 * 1.Page_Load
 * 2.RadioButton1_CheckedChanged
 * 3.RadioButton2_CheckedChanged
 * 4.RadioButton3_CheckedChanged
 * 5.bind
 * -Others : 
 * [刘畅]2018/5/21第一次修改，基本实现了该页面功能
 ***************************************************/


public partial class financeDealDetail : System.Web.UI.Page
{
    // 数据库服务支持项
    private string constr = "Data Source=localhost;database=phonemanager_db;uid=root;password=123456";
    private const string SELECT_DEAL_DATA = "select * from financesubpagedealdetailview";
    private const string SELECT_INCOME_DATA = "select * from financesubpageincomedetailview";
    private const string SELECT_EXPENSE_DATA = "select * from financesubpageexpensedetailview";



    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }
        bind(SELECT_DEAL_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton1_CheckedChanged
     * - Description : 默认查询
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_DEAL_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton2_CheckedChanged
     * - Description : 查询收入明细
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_INCOME_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton3_CheckedChanged
     * - Description : 查询支出明细
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_EXPENSE_DATA);
    }




    /*****************************************************
     * - Function name : bind
     * - Description : 加载交易明细数据
     * - Variables : string sql
     *****************************************************/
    private void bind(string sql)
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = sql;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "deal_detail_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
}