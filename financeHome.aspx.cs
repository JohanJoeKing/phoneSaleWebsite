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
 * - Filename : financeHome.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/20
 * - Description : 本文件为财务科主页的后台程序
 * - Function list :
 * 1.Page_Load
 * 2.login_Click
 * 3.logout_Click
 * 4.bindDeal
 * 5.bindNullDealDetail
 * 6.bindPurchase
 * 7.bindNullPurchaseDetail
 * 8.changeTimePrint
 * 9.Refresh1_Click
 * 10.Refresh2_Click
 * -Others : 
 * [刘畅]2018/5/20第一次修改，基本完成登录功能
 * [刘畅]2018/5/21第二次修改，添加session实现登录保存，
 *       去掉logged属性，添加读取数据库功能
 * [刘畅]2018/5/21第三次修改，编写刷新函数，优化了部分
 *       UI设计,修改了登录漏洞
 * [刘畅]2018/5/23第四次修改，增加登录后登录控件关闭功
 *       能，点击注销后再开启
 ***************************************************/

public partial class financeHome : System.Web.UI.Page
{
    // 数据库服务支持项
    private string constr = "Data Source=localhost;database=phonemanager_db;uid=root;password=123456";
    private const string SELECT_DEAL_DATA = "select * from FinanceDealDetailView";
    private const string SELECT_PURCHASE_DATA = "select * from FinancePurchaseDetailView";

    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 第一次打开界面时加载
        if (!IsPostBack && Session["FinanceDepartmentUsername"] == null)
        {
            bindNullPurchaseDetail();
        }
        else
        {
            if (Session["FinanceDepartmentUsername"] != null)
            {
                bindPurchase();
                bindDeal();
                TextBoxName.Text = Session["FinanceDepartmentUsername"].ToString();
                TextBoxPosition.Text = Session["FinanceDepartmentPosition"].ToString();
            }
            else
            {
                //Response.Write("<script>alert('请先登录！');</script>");
            }
        }
    }



    /*****************************************************
     * - Function name : bindPurchase
     * - Description : 加载采购明细数据
     * - Variables : void
     *****************************************************/
    private void bindPurchase()
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = SELECT_PURCHASE_DATA;

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




    /*****************************************************
     * - Function name : bindDeal
     * - Description : 加载交易明细数据
     * - Variables : void
     *****************************************************/
    private void bindDeal()
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = SELECT_DEAL_DATA;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "deal_detail_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView2.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView2.DataBind();
    }




    /*****************************************************
     * - Function name : bindNullPurchaseDetail
     * - Description : 加载空采购数据，使用在登录前
     * - Variables : void
     *****************************************************/
    private void bindNullPurchaseDetail()
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = "select * from purchase_detail_table where p_id='1' and p_id='2'";

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




    /*****************************************************
     * - Function name : bindNullDealDetail
     * - Description : 加载空交易数据，使用在登录前
     * - Variables : void
     *****************************************************/
    private void bindNullDealDetail()
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = "select * from deal_detail_table where money=1 and money=2";

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "deal_detail_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView2.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView2.DataBind();
    }





    /*****************************************************
     * - Function name : login_Click
     * - Description : 登录验证
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void login_Click(object sender, EventArgs e)
    {
        // 当已经登录则退出本次操作
        if (Session["FinanceDepartmentUsername"] != null)
        {
            Response.Write("<script>alert('已登录！');</script>");
            return;
        }
        
        // 读取输入的登录验证信息
        string id = TextBoxEid.Text.ToString();
        string pw = TextBoxPW.Text.ToString();
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
        LOG.setDepartment("财务科职员");
        LOG.matchingByDepartment();

        // 当验证通过
        if (LOG.passed())
        {
            // 获取当前登录账号的用户名和职位
            string username = LOG.getName();
            string position = LOG.getPosition();

            // 显示到控件
            TextBoxName.Text = username;
            TextBoxPosition.Text = position;
            TextBoxPW.Text = "123456";

            // 保存到session，方便其他页面查看
            Session["FinanceDepartmentUsername"] = username;
            Session["FinanceDepartmentPosition"] = position;

            // 弹出提示框
            string welcome = "<script>alert('欢迎" + username + "');</script>";
            Response.Write(welcome);

            // 加载采购数据和交易数据
            bindPurchase();
            bindDeal();

            // 关闭登录控件
            ButtonLogin.Enabled = false;
            TextBoxName.Enabled = false;
            TextBoxPW.Enabled = false;
            TextBoxEid.Enabled = false;
            TextBoxPosition.Enabled = false;
        }

        // 当验证未通过
        else
        {
            Response.Write("<script>alert('登录失败！');</script>");
        }
    }




    /*****************************************************
     * - Function name : logout_Click
     * - Description : 注销
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void logout_Click(object sender, EventArgs e)
    {
        // 清空UI
        TextBoxEid.Text = "";
        TextBoxPW.Text = "";
        TextBoxName.Text = "";
        TextBoxPosition.Text = "";

        // 消除登录信息
        Session["FinanceDepartmentUsername"] = null;
        Session["FinanceDepartmentPosition"] = null;
        bindNullDealDetail();
        bindNullPurchaseDetail();

        // 开启登录控件
        ButtonLogin.Enabled = true;
        TextBoxName.Enabled = true;
        TextBoxPW.Enabled = true;
        TextBoxEid.Enabled = true;
        TextBoxPosition.Enabled = true;
    }




    /*****************************************************
     * - Function name : changeTimePrint
     * - Description : 刷新时间显示
     * - Variables : void
     *****************************************************/
    private void changeTimePrint()
    {
        string time = System.DateTime.Now.ToString();
        labelTime.Text = "当前时间：" + time;
    }





    /*****************************************************
     * - Function name : Refresh1_Click
     * - Description : 刷新采购记录显示
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Refresh1_Click(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }

        // 记录数据刷新
        bindPurchase();

        // 统计显示未处理的采购申请
        FinanceDatabaseHelper FDH = new FinanceDatabaseHelper();
        int n = FDH.getUnsolvedApplies();
        label1.Text = "新的采购申请" + n + "条";
    }




    /*****************************************************
     * - Function name : Refresh2_Click
     * - Description : 刷新交易记录显示
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Refresh2_Click(object sender, EventArgs e)
    {
        if (Session["FinanceDepartmentUsername"] == null)
        {
            return;
        }
        bindDeal();
        changeTimePrint();
    }
}