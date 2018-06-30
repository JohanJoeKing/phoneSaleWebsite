using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class storequery : System.Web.UI.Page
{
    private MyDatabase MDB;
    private string constr;
    private const string SELECT_SALE_SUMMARY = "select * from repositoryphonedetailview";

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
        da.Fill(ds, "phone_detail_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }
}