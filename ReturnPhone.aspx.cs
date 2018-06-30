using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class ReturnPhone : System.Web.UI.Page
{

    private MyDatabase MDB;
    private orders Ord;
    private SaleService SS;
    private string constr;
    private string sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        MDB = new MyDatabase();
        constr = MDB.getConnection();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Cid = chaxundingdan.Text;
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();

        sql = string.Format("select * from sale_detail_table where s_id ={0}",Cid);
        //查询   显示结果
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while(reader.Read())
        {
        p_id.Text = reader[0].ToString();
        s_date.Text = reader[1].ToString();
        s_price.Text = reader[2].ToString();
        s_e_id.Text = reader[3].ToString();
        s_amount.Text = reader[4].ToString();
        s_summary.Text = reader[5].ToString();
        s_id.Text = reader[6].ToString();
        s_get.Text = reader[7].ToString();
        s_return.Text = reader[8].ToString();
        s_way.Text = reader[9].ToString();
        pr_number.Text = reader[10].ToString();
        }
        reader.Close();
        mycon.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Ord = new orders();
        Ord.setP_id(p_id.Text);
        Ord.setPr_number(pr_number.Text);
        Ord.setS_amount(int.Parse(s_amount.Text));
        Ord.setS_date(s_date.Text);
        Ord.setS_e_id(s_e_id.Text);
        Ord.setS_get(Convert.ToDouble(s_get.Text));
        Ord.setS_id(s_id.Text);
        Ord.setS_price(Convert.ToInt32(s_price.Text));
        Ord.setS_return(Convert.ToDouble(s_return.Text));
        Ord.setS_summary(Convert.ToDouble(s_summary.Text));
        Ord.setS_way(s_way.Text);

        bool flag = SS.returnPhone(Ord);
        if (flag)
        {
            Response.Write("<script>alert('退货成功');</script>");
            // 建立实例
            IncomeExpenseAction IEA = new IncomeExpenseAction();

            // 新建收支明细对象
            IEA.addIncomeExpense();

            // 设置交易内容
            IEA.setIEDeal(Ord.getS_amount(), "", "", "", "");

            // 设置交易人内容
            IEA.setIEDealMan(DateTime.Now.ToShortDateString(), "支出", "现金交易", Ord.getS_e_id());

            // 设置交易备注
            IEA.setIENote("");

            // 提交并操作
            IEA.submit();
        }
        else
        {
            Response.Write("<script>alert('退货失败');</script>");
        }        


    }
}