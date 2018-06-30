using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class lack : System.Web.UI.Page
{
    private MyDatabase MDB;
    protected void Page_Load(object sender, EventArgs e)
    {
        MDB = new MyDatabase();
        date.Text = DateTime.Now.ToShortDateString()+"/"+DateTime.Now.Hour+"/"+DateTime.Now.Minute+"/"+DateTime.Now.Second;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "";
        MyDatabase MDB = new MyDatabase();
        string constr = MDB.getConnection();
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        sql = string.Format("insert into lack_table values({0},{1},'否',{2})",p_id.Text.ToString(),amount.Text.ToString(),date.Text.ToString());
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            Response.Write("<script>alert('提交成功！');</script>");
        }
        mycon.Close();
    }
}