using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
/// <summary>
/// SaleService 的摘要说明
/// </summary>
public class SaleService
{
	public SaleService()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}



    public string searchPhone(string brand,string model,string color)
    {
        string p_id="";
        string sql="";
        //创建数据库链接
        MyDatabase  MDB = new MyDatabase();
        string constr = MDB.getConnection();

        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        sql = "select p_id from phone_table where p_brand ='"+brand+"' and p_model = '"+model+"' and p_color ='"+color+"'";
 
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
       if(reader.Read())
       {
           p_id = reader[0].ToString();
       }
       reader.Close();
       mycon.Close();
       

        
        return p_id;
    }

    public bool salePhone(orders Ord)
    {
        bool flag = false;
        string sql = "";
        MyDatabase MDB = new MyDatabase();
        string constr = MDB.getConnection();
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
        sql = string.Format("insert into sale_detail_table values({0},{1},{2},{3},{4},{5},{6},{7},{8},'{9}',{10})", Ord.getP_id(), Ord.getS_date(), Ord.getS_price(), Ord.getS_e_id(), Ord.getS_amount(), Ord.getS_summary(), Ord.getS_id(), Ord.getS_get(), Ord.getS_return(), Ord.getS_way(), Ord.getPr_number());
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            sql = string.Format("update sale_summary_table set store_amount=store_amount-{0},saled_amount = saled_amount + {1} where p_id={2}", Ord.getS_amount(), Ord.getS_amount(), Ord.getP_id());
            MySqlCommand mycnd = new MySqlCommand(sql, mycon);
            if (mycnd.ExecuteNonQuery() > 0)
            {
                // 修改手机明细记录
                sql = string.Format("select MIN(ph_id) from phone_detail_table where p_id='{0}' and saled='否'", Ord.getP_id());
                string pid2 = Ord.getP_id(), ph_id = "";
                MySqlCommand mycmd2 = new MySqlCommand(sql, mycon);
                MySqlDataReader reader = null;
                reader = mycmd2.ExecuteReader();
                if (reader.Read())
                {
                    ph_id = reader[0].ToString();
                }
                reader.Close();
                sql = string.Format("update phone_detail_table set saled='是' where p_id='{0}' and ph_id='{1}'", pid2, ph_id);
                MySqlCommand mycnd2 = new MySqlCommand(sql, mycon);
                if (mycnd2.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
                
        }
        else
        {
            flag = false;
        }

        

        mycon.Close();


        return flag; 
    }

    public bool returnPhone(orders Ord)
    {
        bool flag = false;
        int n =Ord.getS_amount();
        string sql = "";
        MyDatabase MDB = new MyDatabase();
        string constr = MDB.getConnection();
        MySqlConnection mycon = new MySqlConnection(constr);
        mycon.Open();
            sql = string.Format("update sale_summary_table set store_amount=store_amount + {0},saled_amount = saled_amount - {1} where p_id={2}", Ord.getS_amount(), Ord.getS_amount(), Ord.getP_id());
            MySqlCommand mycnd = new MySqlCommand(sql, mycon);
            if (mycnd.ExecuteNonQuery() > 0)
            {
                for (int i = 0; i < n;i++ )
                {
                    // 修改手机明细记录
                    sql = string.Format("select MIN(ph_id) from phone_detail_table where p_id='{0}' and saled='是'", Ord.getP_id());
                string pid2 = Ord.getP_id(), ph_id = "";
                MySqlCommand mycmd2 = new MySqlCommand(sql, mycon);
                MySqlDataReader reader = null;
                reader = mycmd2.ExecuteReader();
                if (reader.Read())
                {
                    ph_id = reader[0].ToString();
                }
                reader.Close();
                sql = string.Format("update phone_detail_table set saled='否' where p_id='{0}' and ph_id='{1}'", pid2, ph_id);
                MySqlCommand mycnd2 = new MySqlCommand(sql, mycon);
                if (mycnd2.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                }

        }
        else
        {
            flag = false;
        }



        mycon.Close();




        return flag;
    }
}