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
 * - Filename : dataManagerService.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 该类用于财务科汇总收支使用
 * - Function list :
 * 1.DataManagerService
 * 2.set
 * 3.getRecords
 * 4.getPhoneKinds
 * 5.getAmountOf
 * 6.saveSummary
 * 7.getProviders
 * 8.saveProviderSummary
 * -Others : 
 * [刘畅]2018/5/22第一次修改，完成查询汇总功能实现
 * [刘畅]2018/5/22第二次修改，添加查询记录条数功能
 * [刘畅]2018/5/26第三次修改，改动数据库属性获取方式
 * [刘畅]2018/5/30第四次修改，增加了几个有关采购汇总的查询功能
 * [刘畅]2018/5/30第五次修改，增加了几个有关销售汇总的查询功能
 ***************************************************/

/// <summary>
/// dataManagerService
/// 需要调用数据库支持项
/// </summary>
public class DataManagerService
{
    // 数据库服务支持项
    private MyDatabase MDB;

    /*****************************************************
     * - Function name : dataManagerService
     * - Description : 构造函数
     * - Variables : void
     *****************************************************/
	public DataManagerService()
	{
        MDB = new MyDatabase();
	}




    /*****************************************************
     * - Function name : set
     * - Description : 查询相关业务的汇总
     * - Variables : string deal_kind
     *****************************************************/
    public double set(string deal_kind)
    {
        double summary = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select sum(money) from deal_detail_table where deal_kind='{0}'", deal_kind);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            summary = double.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return summary;
    }





    /*****************************************************
     * - Function name : getRecords
     * - Description : 查询相关业务的数量
     * - Variables : string deal_kind
     *****************************************************/
    public int getRecords(string deal_kind)
    {
        int n = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select count(*) from deal_detail_table where deal_kind='{0}'", deal_kind);
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
     * - Function name : getPhoneKinds
     * - Description : 查询数据库中保存的机型个数
     * - Variables : void
     *****************************************************/
    public int getPhoneKinds()
    {
        // 返回数
        int x = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select count(*) from phone_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            x = int.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return x;
    }





    /*****************************************************
     * - Function name : getAmountOf
     * - Description : 查询某些特征的数据的个数
     * - Variables : string SELECTED, string WHERE
     *****************************************************/
    public int getAmountOf(string SELECTED, string TABLE, string WHERE)
    {
        int x = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select {0} from {1} {2}", SELECTED, TABLE, WHERE);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                x = int.Parse(reader[0].ToString());
            }
        }
        catch(Exception e){

        }        
        reader.Close();
        mycon.Close();

        return x;
    }





    /*****************************************************
     * - Function name : saveSummary
     * - Description : 保存汇总数据
     * - Variables : string pid, int amount, int summary, int received, int unreceived, int purAmount， string command
     *****************************************************/
    public bool saveSummary(string pid, int amount, double summary, int received, int unreceived, int purAmount, string command)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = "";

        // 执行更新操作
        if (command == "update")
        {
            sql = string.Format("update purchase_summary_good_table set p_amount={0}, p_summary={1}, psg_received={2}, psg_no_receive={3}, pur_amount={4} where p_id='{5}'"
            , amount
            , summary
            , received
            , unreceived
            , purAmount
            , pid);
        }

        // 执行插入操作
        else if(command == "insert"){
            sql = string.Format("insert into purchase_summary_good_table values('{0}',{1},{2},{3},{4},{5})"
            , pid
            , amount
            , summary
            , received
            , unreceived
            , purAmount);
        }

        // 命令错误
        else
        {
            return false;
        }

        // 开始执行
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





    /*****************************************************
     * - Function name : getProviders
     * - Description : 查询供应商个数
     * - Variables : void
     *****************************************************/
    public int getProviders()
    {
        // 返回数
        int x = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select count(*) from provider_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            x = int.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return x;
    }




    /*****************************************************
     * - Function name : saveProviderSummary
     * - Description : 保存供应商汇总数据
     * - Variables : string pid, int amount, double summary, int kinds, int finished, int unfinished, string command
     *****************************************************/
    public bool saveProviderSummary(string pid, int amount, double summary, int kinds, int finished, int unfinished, string command)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = "";

        // 执行更新操作
        if (command == "update")
        {
            sql = string.Format("update purchase_summary_provider_table set pur_amount={0}, pur_summary={1}, p_kinds={2}, pur_unfinish={3}, pur_finished={4} where pr_number='{5}'"
            , amount
            , summary
            , kinds
            , unfinished
            , finished
            , pid);
        }

        // 执行插入操作
        else if (command == "insert")
        {
            sql = string.Format("insert into purchase_summary_provider_table values('{0}',{1},{2},{3},{4},{5})"
            , pid
            , amount
            , summary
            , kinds
            , unfinished
            , finished);
        }

        // 命令错误
        else
        {
            return false;
        }

        // 开始执行
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






    /*****************************************************
     * - Function name : getSaledPhones
     * - Description : 查询售出过的机型个数
     * - Variables : void
     *****************************************************/
    public int getSaledPhones()
    {
        int x = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select distinct count(*) from sale_detail_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            x = int.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return x;
    }





    /*****************************************************
     * - Function name : getSaledSummary
     * - Description : 查询售出某机型总收入
     * - Variables : string pid
     *****************************************************/
    public double getSaledSummary(string pid)
    {
        double x = 0;

        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select sum(s_summary) from sale_detail_table");
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        while (reader.Read())
        {
            x = double.Parse(reader[0].ToString());
        }
        reader.Close();
        mycon.Close();

        return x;
    }






    /*****************************************************
     * - Function name : saveSaledSummary
     * - Description : 保存销售汇总数据
     * - Variables : string pid, int store, int saled, double summary, string command
     *****************************************************/
    public bool saveSaledSummary(string pid, int store, int saled, double summary, string command)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = "";

        // 执行更新操作
        if (command == "update")
        {
            sql = string.Format("update sale_summary_provider_table set store_amount={0}, saled_amount={1}, earned={2} where p_id='{3}'"
            , store
            , saled
            , summary
            , pid);
        }

        // 执行插入操作
        else if (command == "insert")
        {
            sql = string.Format("insert into sale_summary_provider_table values('{0}',{1},{2},{3})"
            , pid
            , store
            , saled
            , summary);
        }

        // 命令错误
        else
        {
            return false;
        }

        // 开始执行
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