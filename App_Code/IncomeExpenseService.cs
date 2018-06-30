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
 * - Filename : IncomeExpenseService.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 收支明细类服务类
 * - Function list :
 * 1.IncomeExpenseService
 * 2.saveIncomeExpenseRecord
 * -Others : 
 * [刘畅]2018/5/22第一次修改，实现了新的记录的插入
 * [刘畅]2018/5/26第二次修改，改动数据库属性获取方式
 ***************************************************/

/// <summary>
/// IncomeExpenseService
/// IncomeExpense的服务类
/// 需要连接数据库
/// </summary>
public class IncomeExpenseService
{
    // 数据库服务支持项
    private MyDatabase MDB;


    /*****************************************************
     * - Function name : IncomeExpenseService
     * - Description : 构造函数
     * - Variables : void
     *****************************************************/
	public IncomeExpenseService()
	{
        MDB = new MyDatabase();
	}



    /*****************************************************
     * - Function name : saveIncomeExpenseRecord
     * - Description : 保存收支记录
     * - Variables : IncomeExpense IE
     *****************************************************/
    public bool saveIncomeExpenseRecord(IncomeExpense IE)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("insert into deal_detail_table values({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')"
            ,IE.getMoney()
            ,IE.getDate()
            ,IE.getReceive_name()
            ,IE.getReceive_card()
            ,IE.getAllocate_name()
            ,IE.getAllocate_card()
            ,IE.getDeal_way()
            ,IE.getAssure_id()
            ,IE.getDdt_note()
            ,IE.getDeal_kind());
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