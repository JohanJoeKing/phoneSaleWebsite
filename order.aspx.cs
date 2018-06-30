using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class order : System.Web.UI.Page
{
    private MyDatabase MDB;
    private IncomeExpenseAction IE;
    private orders Ord;
    private string constr;
    private string sql = "";
    private string year = "";
    private string month = "";
    private string day = "";
    private string hour = "";
    private string minute = "";
    private SaleService SS;
    protected void Page_Load(object sender, EventArgs e)
    {
        SS = new SaleService();
        string s = Request["value"].ToString();
        p_id.Text = s;

        year = DateTime.Now.Year.ToString();;
        month = DateTime.Now.Month.ToString();
        day = DateTime.Now.Day.ToString();
        hour = DateTime.Now.Hour.ToString();
        minute = DateTime.Now.Minute.ToString();

        s_date.Text = year+"-" + month+"-" + day ;
        s_id.Text = year + month + day + hour + minute ;
        
       // s_summary.Text = amo * num;
        //创建数据库链接
        MDB = new MyDatabase();
        constr = MDB.getConnection();

        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        sql = string.Format("select p_brand,p_model,p_color,price_sale from phone_table where p_id ={0}",Convert.ToInt32(s));
        //查询   显示结果
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while(reader.Read())
        {
            brand.Text = reader[0].ToString();
            model.Text = reader[1].ToString();
            color.Text = reader[2].ToString();
            s_price.Text = reader[3].ToString();
            
     /*   s_date.Text = reader[1].ToString();
        s_e_id.Text = reader[3].ToString();
        s_amount.Text = reader[4].ToString();
        s_summary.Text = reader[5].ToString();
        
        s_get.Text = reader[7].ToString();
        s_return.Text = reader[8].ToString();
        s_way.Text = reader[9].ToString();
        pr_number.Text = reader[10].ToString();
      */

        }

        reader.Close();
        mycon.Close();
        
        // 默认输入
        double price = double.Parse(s_price.Text.ToString());
        double m = double.Parse(amount.Text.ToString());
        double sum = price * m;
        s_summary.Text = "" + sum;
        s_get.Text = s_summary.Text;
        s_return.Text = "0";
        s_e_id.Text = "34601";
        s_way.Text = "零售";
        pr_number.Text = "4001";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Ord = new orders();
        Ord.setP_id(p_id.Text);
        Ord.setPr_number(pr_number.Text);
        Ord.setS_amount(Convert.ToInt32(amount.SelectedValue));
        Ord.setS_date(s_date.Text);
        Ord.setS_e_id(s_e_id.Text);
        Ord.setS_get(Convert.ToDouble(s_get.Text));
        Ord.setS_id(s_id.Text);
        Ord.setS_price(Convert.ToInt32(s_price.Text));
        Ord.setS_return(Convert.ToDouble(s_return.Text));
        Ord.setS_summary(Convert.ToDouble(s_summary.Text));
        Ord.setS_way(s_way.Text);


        bool flag = SS.salePhone(Ord);
        if(flag)
        {
            Response.Write("<script>alert('购买成功！');</script>");
            // 建立实例
            IncomeExpenseAction IEA = new IncomeExpenseAction();
 
            // 新建收支明细对象
            IEA.addIncomeExpense();
 
            // 设置交易内容
            IEA.setIEDeal(Ord.getS_summary(), "", "", "", "");
 
             // 设置交易人内容
             IEA.setIEDealMan(Ord.getS_date(),"收入","现金交易",Ord.getS_e_id());
 
             // 设置交易备注
            IEA.setIENote("");
 
            // 提交并操作
            IEA.submit();
        }
        else
        {
            Response.Write("<script>alert('购买失败！');</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("sale.aspx");
    }
}