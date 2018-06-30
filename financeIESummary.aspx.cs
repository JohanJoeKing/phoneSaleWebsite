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
 * - Filename : financeIESummary.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/20
 * - Description : 本文件为财务科收支汇总页面的后台程序
 * - Function list :
 * 1.
 * -Others : 
 * [刘畅]2018/5/22第一次修改，完成了UI设计
 ***************************************************/

public partial class financeIncomeSummary : System.Web.UI.Page
{
    // 数据库服务支持项
    private string constr = "Data Source=localhost;database=phonemanager_db;uid=root;password=123456";
    private const string SELECT_DEAL_DATA = "select * from FinanceDealDetailView";
    private const string SELECT_INCOME_DATA = "select * from financesubpageincomedetailview";
    private const string SELECT_EXPENSE_DATA = "select * from financesubpageexpensedetailview";

    DataManagerAction DMA1;
    DataManagerAction DMA2;

    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 检查是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 显示所有收支明细
        bind(SELECT_DEAL_DATA);

        // 显示当前日期
        LabelDate.Text = "当前日期：" + System.DateTime.Now.ToString();

        // 查询汇总结果
        DMA1 = new DataManagerAction();
        DMA2 = new DataManagerAction();
        DMA1.initDataManager();
        DMA2.initDataManager();
        DMA1.setDataManager(DMA1.INCOME);
        DMA2.setDataManager(DMA2.EXPENSE);
        DMA1.searchData();
        DMA2.searchData();

        // 显示到界面
        double income = DMA1.getIESummary();
        double expense = DMA2.getIESummary();
        LabelIncomeSummary.Text = "总收入：" + income + "元";
        LabelExpenseSummary.Text = "总支出：" + expense + "元";
        LabelIncomes.Text = "收入记录：" + DMA1.getIERecords() + "条";
        LabelExpenses.Text = "支出记录：" + DMA2.getIERecords() + "条";
        LabelEarn.Text = "盈利：" + (income - expense) + "元";
    }




    /*****************************************************
     * - Function name : RadioButtonIncome_CheckedChanged
     * - Description : 显示为收入汇总
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButtonIncome_CheckedChanged(object sender, EventArgs e)
    {
        // 检查是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        bind(SELECT_INCOME_DATA);
    }




    /*****************************************************
     * - Function name : RadioButtonExpense_CheckedChanged
     * - Description : 显示为支出汇总
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButtonExpense_CheckedChanged(object sender, EventArgs e)
    {
        // 检查是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        bind(SELECT_EXPENSE_DATA);
    }




    /*****************************************************
     * - Function name : bind
     * - Description : 加载数据
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





    /*****************************************************
     * - Function name : RadioButton1_CheckedChanged
     * - Description : 显示为默认汇总
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        // 检查是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        bind(SELECT_DEAL_DATA);
    }




    /*****************************************************
     * - Function name : buttonPrintSummary_Click
     * - Description : 打印汇总报告
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void buttonPrintSummary_Click(object sender, EventArgs e)
    {
        // 启动提示
        Response.Write("<script>alert('即将开始生成excel报表文件到本地保存');</script>");

        // 新建excel创建对象
        string name = System.DateTime.Now.ToString();
        SummaryExcelCreator SEC = new SummaryExcelCreator(name);

        // 赋值
        SEC.setIncomeExpense(DMA1.getIESummary(), DMA2.getIESummary());
        SEC.setIncomeExpenseScale(DMA1.getIERecords(), DMA2.getIERecords());
        SEC.setEarn(DMA1.getIESummary() - DMA2.getIESummary());

        // 生成
        if (SEC.generateExcel())
        {
            Response.Write("<script>alert('本地报表生成成功，请注意查看');</script>");
        }
        else
        {
            Response.Write("<script>alert('本地报表生成失败！');</script>");
        }
    }
}