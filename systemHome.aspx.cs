using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : systemHome.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 本文件为系统管理主页面
 * - Function list :
 * 1.Page_Load
 * -Others : 
 * [刘畅]2018/5/27第一次修改，基本实现了该页面功能
 ***************************************************/


public partial class systemHome : System.Web.UI.Page
{
    // 数据库连接
    private MyDatabase MDB;
    private const string SELECT_EMPLOYEE_DATA = "select * from systemEmployeeView";
    private const string SELECT_NULL = "select * from user_table where u_id='1' and u_id='2'";

    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 连接数据库
        MDB = new MyDatabase();

        // 第一次打开界面时加载
        if (!IsPostBack && Session["SystemAccount"] == null)
        {
            bind(SELECT_NULL);
        }
        else
        {
            if (Session["SystemAccount"] != null)
            {
                bind(SELECT_EMPLOYEE_DATA);

                // 显示登录状态
                LabelLogState.Text = "登录状态：已登录";
                TextBoxAccount.Enabled = false;
                TextBoxPassword.Enabled = false;
            }
            else
            {
                //Response.Write("<script>alert('请先登录！');</script>");
            }
        }
    }





    /*****************************************************
     * - Function name : ButtonLoggin_Click
     * - Description : 登录验证
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonLoggin_Click(object sender, EventArgs e)
    {
        // 当已经登录则退出本次操作
        if (Session["SystemAccount"] != null)
        {
            Response.Write("<script>alert('已登录！');</script>");
            return;
        }

        // 读取输入的登录验证信息
        string id = TextBoxAccount.Text.ToString();
        string pw = TextBoxPassword.Text.ToString();
        LogHelper LOG = new LogHelper();

        // 验证输入缺省
        if (id == "" || pw == "")
        {
            Response.Write("<script>alert('请输入完整信息！');</script>");
            return;
        }

        // 验证
        LOG.setId(id);
        LOG.setPassword(pw);
        LOG.matchingIntoSystem();

        // 当验证通过
        if (LOG.passed())
        {
            // 获取当前登录账号的用户名和职位
            string username = LOG.getName();
            string position = LOG.getPosition();

            // 保存到session，方便其他页面查看
            Session["SystemAccount"] = id;

            // 弹出提示框
            string welcome = "<script>alert('欢迎" + username + "');</script>";
            Response.Write(welcome);

            // 加载采购数据和交易数据
            bind(SELECT_EMPLOYEE_DATA);

            // 关闭登录控件
            ButtonLoggin.Enabled = false;
            TextBoxAccount.Enabled = false;
            TextBoxPassword.Enabled = false;

            // 加载当前时间
            LabelCurrentTime.Text = System.DateTime.Now.ToString();

            // 显示登录状态
            LabelLogState.Text = "登录状态：已登录";
        }

        // 当验证未通过
        else
        {
            Response.Write("<script>alert('登录失败！');</script>");
        }
    }




    /*****************************************************
     * - Function name : bind
     * - Description : 加载交易明细数据
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
        da.Fill(ds, "employee_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
}