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
 * - Filename : financePurchaseDetail.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 本文件为财务科查看采购申请明细的页面
 * - Function list :
 * 1.Page_Load
 * 2.RadioButton1_CheckedChanged
 * 3.RadioButton2_CheckedChanged
 * 4.RadioButton3_CheckedChanged
 * 5.bind
 * -Others : 
 * [刘畅]2018/5/22第一次修改，基本实现了该页面功能
 * [刘畅]2018/5/29第二次修改，修改了数据库连接方式
 ***************************************************/


public partial class financePurchaseDetail : System.Web.UI.Page
{
    // 数据库服务支持项
    private MyDatabase MDB;
    private string constr;
    private const string SELECT_PURCHASE_DATA = "select * from financesubpagepurchasedetailview";
    private const string SELECT_PERMITTED_DATA = "select * from financesubpagesolvedpurchaseview";
    private const string SELECT_UNPERMITTED_DATA = "select * from financesubpageunsolvedpurchaseview";



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

        // 数据库服务
        MDB = new MyDatabase();
        constr = MDB.getConnection();

        // 加载数据
        bind(SELECT_PURCHASE_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton1_CheckedChanged
     * - Description : 查询所有采购申请
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_PURCHASE_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton2_CheckedChanged
     * - Description : 查询已批准的采购申请
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_PERMITTED_DATA);
    }




    /*****************************************************
     * - Function name : RadioButton3_CheckedChanged
     * - Description : 查询未批准的采购申请
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bind(SELECT_UNPERMITTED_DATA);
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
        da.Fill(ds, "purchase_detail_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
}