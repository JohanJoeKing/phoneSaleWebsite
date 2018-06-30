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
 * - Filename : financeSaleSummary.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/30
 * - Description : 本文件为财务科销售汇总界面
 * - Function list :
 * 1.Page_Load
 * 2.ButtonRefresh_Click
 * 3.bind
 * -Others : 
 * [刘畅]2018/5/30第一次修改，实现基本汇总功能
 ***************************************************/



public partial class financeSaleSummary : System.Web.UI.Page
{
    // 数据库连接属性
    private MyDatabase MDB;
    private string constr;
    private const string SELECT_SALE_SUMMARY = "select * from financesalesummaryview";





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
        bind(SELECT_SALE_SUMMARY);
    }





    /*****************************************************
     * - Function name : ButtonRefresh_Click
     * - Description : 刷新汇总数据
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonRefresh_Click(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 实例化一个DataManager服务类
        DataManagerService DMS = new DataManagerService();

        // 查询售出过的机型个数
        int N = DMS.getSaledPhones();

        // 建立缓存数组
        string[] pid = new string[N];

        // 挨个汇总
        int i = 0;
        double sum = 0;
        for (i = 0; i < N; i++)
        {
            int store = 0;      // 库存量
            int saled = 0;      // 售出量
            double earned = 0;  // 总收入

            try
            {
                // 统计库存量
                store = DMS.getAmountOf("count(*)", "phone_detail_table", "where p_id='" + pid[i] + "' and saled='否'");

                // 统计售出量
                saled = DMS.getAmountOf("count(*)", "sale_detail_table", "where p_id='" + pid[i] + "'");

                // 总收入
                earned = DMS.getSaledSummary(pid[i]);
                sum += earned;

                // 查看汇总表是否有机型记录
                int hash = 0;
                hash = DMS.getAmountOf("count(*)", "sale_summary_table", "where p_id='" + pid[i] + "'");

                // 存回数据库
                if (hash == 0)
                {
                    // 当之前没有该机型信息汇总，插入操作
                    if (!DMS.saveSaledSummary(pid[i], store, saled, earned, "insert"))
                    {
                        Response.Write("<script>alert('汇总过程出错[机型：" + pid[i] + "]');</script>");
                    }
                }
                else
                {
                    // 存在汇总操作时进行更新
                    if (!DMS.saveSaledSummary(pid[i], store, saled, earned, "update"))
                    {
                        Response.Write("<script>alert('汇总过程出错[机型：" + pid[i] + "]');</script>");
                    }
                }
            }
            catch(Exception ex){

            }
            
        }


        // 提示完成
        Response.Write("<script>alert('汇总完成');</script>");
        
        // 修改总收入显示
        LabelSummary.Text = "总收入：" + sum + "元";
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

        //sql查询语句 查询对应ID的贷款申请情况  
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
}