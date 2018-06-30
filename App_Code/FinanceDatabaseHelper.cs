using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : FinanceDatabaseHelper.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/21
 * - Description : 该类用于响应财务科的一些数据库操作，提供接口
 * - Function list :
 * 1.
 * -Others : 
 * [刘畅]2018/5/20第一次修改，实现统计未处理的采购申请
 * [刘畅]2018/5/26第二次修改，改动数据库属性获取方式
 * [刘畅]2018/6/5第三次修改，增加采购批准的相关方法
 * [刘畅]2018/6/23第四次修改，增加采购批准的查看方法
 * [刘畅]2018/6/24第五次修改，增加采购批准实现方法
 ***************************************************/

/// <summary>
/// FinanceDatabaseHelper
/// 需要访问数据库
/// 故该文件内需要引用MySQL的DLL
/// </summary>
public class FinanceDatabaseHelper
{
    // 数据库连接属性
    private MyDatabase MDB;



    /*****************************************************
    * - Function name : FinanceDatabaseHelper
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public FinanceDatabaseHelper()
	{
        MDB = new MyDatabase();
	}





    /*****************************************************
    * - Function name : getUnsolvedApplies
    * - Description : 统计未处理的采购申请数量
    * - Variables : void
    *****************************************************/
    public int getUnsolvedApplies()
    {
        int n = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = "select count(*) from purchase_detail_table where pur_permit='否'";
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            n = int.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return n;
    }




    /*****************************************************
    * - Function name : getUserEmployeeID
    * - Description : 反向查询员工工号
    * - Variables : string name
    *****************************************************/
    public string getEmployeeID(string name)
    {
        string eid = "";

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select e_id from employee_table where e_name='{0}'", name);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            eid = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();

        return eid;
    }




    /*****************************************************
    * - Function name : getPurchaseApplications
    * - Description : 查询采购申请数量
    * - Variables : void
    *****************************************************/
    public int getPurchaseApplications()
    {
        int n = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select count(*) from purchase_detail_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            n = int.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return n;
    }





    /*****************************************************
    * - Function name : getPurchaseApplicationDetail
    * - Description : 查询采购单详细
    * - Variables : string id
    *****************************************************/
    public Purchase getPurchaseApplicationDetail(string id)
    {
        Purchase p = new Purchase();

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select * from purchase_detail_table where pur_id='{0}'", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();

        // 订单信息
        string p_id = "";
        string pr_number = "";
        string pur_date = "";
        string pur_way = "";
        string pur_amount = "";
        string p_price = "";
        string p_summary = "";
        string pur_card = "";
        string receive_id = "";
        string buy_id = "";
        string pur_id = "";
        string pur_received = "";
        string pur_permit = "";

        // 读取信息
        while (reader.Read())
        {
            p_id = reader[0].ToString();
            pr_number = reader[1].ToString();
            pur_date = reader[2].ToString();
            pur_way = reader[3].ToString();
            pur_amount = reader[4].ToString();
            p_price = reader[5].ToString();
            p_summary = reader[6].ToString();
            pur_card = reader[7].ToString();
            receive_id = reader[8].ToString();
            buy_id = reader[9].ToString();
            pur_id = reader[10].ToString();
            pur_received = reader[11].ToString();
            pur_permit = reader[12].ToString();
        }

        // 关闭连接
        reader.Close();
        mycon.Close();

        // 设置变量
        p.setP_id(p_id);
        p.setPr_number(pr_number);
        p.setPur_date(pur_date);
        p.setPur_way(pur_way);
        p.setPur_amount(int.Parse(pur_amount));
        p.setP_price(double.Parse(p_price));
        p.setP_summary(double.Parse(p_summary));
        p.setPur_card(pur_card);
        p.setReceive_id(receive_id);
        p.setBuy_id(buy_id);
        p.setPur_id(pur_id);
        
        return p;
    }




    /*****************************************************
    * - Function name : getBrand
    * - Description : 查询采购的商品品牌
    * - Variables : string id
    *****************************************************/
    public string getBrand(string id)
    {
        string brand = "";

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select p_brand from purchase_detail_table pdt join phone_table pt on pdt.p_id=pt.p_id where pdt.pr_number={0}", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            brand = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();


        return brand;
    }




    /*****************************************************
    * - Function name : getModel
    * - Description : 查询采购的商品型号
    * - Variables : string id
    *****************************************************/
    public string getModel(string id)
    {
        string model = "";

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select p_model from purchase_detail_table pdt join phone_table pt on pdt.p_id=pt.p_id where pdt.pr_number={0}", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            model = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();


        return model;
    }




    /*****************************************************
    * - Function name : getBuyEmployeeName
    * - Description : 查询采购人
    * - Variables : string id
    *****************************************************/
    public string getBuyEmployeeName(string id)
    {
        string name = "";

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select e_name from purchase_detail_table pdt join employee_table et on pdt.buy_id=et.e_id where pdt.pr_number={0}", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            name = reader[0].ToString();
        }
        reader.Close();
        mycon.Close();


        return name;
    }





    /*****************************************************
    * - Function name : purchasePermitAction
    * - Description : 批准单号的申请单
    * - Variables : string id
    *****************************************************/
    public bool purchasePermitAction(string id)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("update purchase_detail_table set pur_permit='是' where pur_id='{0}'", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            mycon.Close();
            return true;
        }
        else
        {
            mycon.Close();
            return false;
        }
    }
}