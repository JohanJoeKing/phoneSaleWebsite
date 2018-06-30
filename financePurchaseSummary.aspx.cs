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
 * - Filename : financePurchaseSummary.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/29
 * - Description : 本文件为财务科采购汇总界面
 * - Function list :
 * 1.Page_Load
 * 2.bind
 * 3.ButtonRefresh1_Click
 * 4.ButtonRefresh2_Click
 * -Others : 
 * [刘畅]2018/5/29第一次修改，实现基本汇总功能
 ***************************************************/



public partial class financePurchaseSummary : System.Web.UI.Page
{
    // 数据库连接属性
    private MyDatabase MDB;
    private string constr;
    private const string SELECT_GOOD_SUMMARY = "select * from financepurchasegoodsummaryview";
    private const string SELECT_PROVIDER_SUMMARY = "select * from financepurchaseprovidersummaryview";





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

        // 数据库连接
        MDB = new MyDatabase();
        constr = MDB.getConnection();

        // 加载数据库
        bind(SELECT_GOOD_SUMMARY, 1);
        bind(SELECT_PROVIDER_SUMMARY, 2);
    }





    /*****************************************************
     * - Function name : bind
     * - Description : 页面加载
     * - Variables : string sql, int gridViewNumber
     *****************************************************/
    private void bind(string sql, int gridViewNumber)
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(constr);

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = sql;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        if (gridViewNumber == 1)
        {
            //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
            da.Fill(ds, "purchase_summary_table");

            //设置数据源，用于填充控件中的项的值列表  
            GridView1.DataSource = ds;

            //将控件及其所有子控件绑定到指定的数据源  
            GridView1.DataBind();
        }

        else if(gridViewNumber == 2){
            //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
            da.Fill(ds, "purchase_summary_table");

            //设置数据源，用于填充控件中的项的值列表  
            GridView2.DataSource = ds;

            //将控件及其所有子控件绑定到指定的数据源  
            GridView2.DataBind();
        }
        
    }





    /*****************************************************
     * - Function name : ButtonRefresh1_Click
     * - Description : 刷新第一个汇总表
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonRefresh1_Click(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 实例化一个DataManager服务类
        DataManagerService DMS = new DataManagerService();

        // 查询机型个数
        int N = DMS.getPhoneKinds();

        // 建立数组缓存机型编号
        string[] pid = new string[N];

        // 读取机型编号
        int i = 0;
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select p_id from phone_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            pid[i++] = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();

        // 挨个机型汇总
        for (i = 0; i < N; i++)
        {
            int amount = 0;      // 数量
            double summary = 0;  // 总价
            int received = 0;    // 已收货
            int unreceived = 0;  // 未收货
            int purAmount = 0;   // 总单数

            // 统计数量
            amount = DMS.getAmountOf("sum(pur_amount)", "purchase_detail_table", "");

            // 统计总价
            summary = DMS.getAmountOf("sum(p_summary)", "purchase_detail_table", "");

            // 统计已收货数量
            received = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pur_received='是'");

            // 统计未收货数量
            unreceived = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pur_received='否'");

            // 统计总单数
            purAmount = DMS.getAmountOf("count(*)", "purchase_detail_table", "where p_id='" + pid[i] + "'");

            // 查看汇总表是否有机型记录
            int hash = 0;
            hash = DMS.getAmountOf("count(*)", "purchase_summary_good_table", "where p_id='" + pid[i] + "'");

            // 存回数据库
            if (hash == 0)
            {
                // 当之前没有该机型信息汇总，插入操作
                if (!DMS.saveSummary(pid[i], amount, summary, received, unreceived, purAmount, "insert"))
                {
                    Response.Write("<script>alert('汇总过程出错[机型：" + pid + "]');</script>");
                }
            }
            else
            {
                // 存在汇总操作时进行更新
                if (!DMS.saveSummary(pid[i], amount, summary, received, unreceived, purAmount, "update"))
                {
                    Response.Write("<script>alert('汇总过程出错[机型：" + pid + "]');</script>");
                }
            }
        }

        // 提示完成
        Response.Write("<script>alert('汇总完成');</script>");

        // 刷新
        Label1.Text = "上一次汇总：" + System.DateTime.Now.ToString();
        bind(SELECT_GOOD_SUMMARY, 1);
    }





    /*****************************************************
     * - Function name : ButtonRefresh2_Click
     * - Description : 刷新第二个汇总表
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonRefresh2_Click(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 实例化一个DataManager服务类
        DataManagerService DMS = new DataManagerService();

        // 查询供应商个数
        int N = DMS.getProviders();

        // 建立数组缓存供应商编号
        string[] pid = new string[N];

        // 读取机型编号
        int i = 0;
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select pr_number from provider_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            pid[i++] = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();

        // 挨个供应商汇总
        for (i = 0; i < N; i++)
        {
            int amount = 0;      // 数量
            double summary = 0;  // 总价
            int kinds = 0;       // 商品种类
            int finished = 0;    // 已完成订单
            int unfinished = 0;  // 未完成订单

            // 统计数量
            amount = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pr_number='" + pid[i] + "'");

            // 统计总价
            summary = DMS.getAmountOf("sum(p_summary)", "purchase_detail_table", "where pr_number='" + pid[i] + "'");

            // 统计已收货数量
            kinds = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pur_received='是' and pr_number='" + pid[i] + "'");

            // 统计未收货数量
            finished = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pur_received='否' and pr_number='" + pid[i] + "'");

            // 统计总单数
            unfinished = DMS.getAmountOf("count(*)", "purchase_detail_table", "where pr_number='" + pid[i] + "'");

            // 查看汇总表是否有相关供应商记录
            int hash = 0;
            hash = DMS.getAmountOf("count(*)", "purchase_summary_provider_table", "where pr_number='" + pid[i] + "'");

            // 存回数据库
            if (hash == 0)
            {
                // 当之前没有该机型信息汇总，插入操作
                if (!DMS.saveProviderSummary(pid[i], amount, summary, kinds, unfinished, finished, "insert"))
                {
                    Response.Write("<script>alert('汇总过程出错[机型：" + pid + "]');</script>");
                }
            }
            else
            {
                // 存在汇总操作时进行更新
                if (!DMS.saveProviderSummary(pid[i], amount, summary, kinds, unfinished, finished, "update"))
                {
                    Response.Write("<script>alert('汇总过程出错[机型：" + pid + "]');</script>");
                }
            }
        }

        // 提示完成
        Response.Write("<script>alert('汇总完成');</script>");

        // 刷新
        Label2.Text = "上一次汇总：" + System.DateTime.Now.ToString();
        bind(SELECT_PROVIDER_SUMMARY, 2);
    }
}