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
 * - Filename : UserService.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 用户服务类
 * - Function list :
 * 1.UserService
 * 2.saveUserService
 * 3.alterUserService
 * 4.getInfoByEid
 * 5.deleteUserService
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/

/// <summary>
/// UserService
/// 需要连接数据库
/// 需引用相关DLL
/// </summary>
public class UserService
{
    // 数据库服务
    private MyDatabase MDB;


    /*****************************************************
    * - Function name : UserService
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public UserService()
	{
        MDB = new MyDatabase();
	}




    /*****************************************************
    * - Function name : saveUserService
    * - Description : 保存用户数据到数据库
    * - Variables : User user
    *****************************************************/
    public bool saveUserService(User user)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("insert into user_table values({0}, '{1}', '{2}', '{3}', '{4}')"
            , user.getAccount()
            , user.getPassword()
            , user.getName()
            , user.getStatus()
            , user.getId());
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
    * - Function name : alterUserService
    * - Description : 修改数据库中的用户数据
    * - Variables : User user
    *****************************************************/
    public bool alterUserService(User user)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("update user_table set u_account='{0}', u_password='{1}', u_name='{2}', u_status='{3}' where u_id='{4}'"
            , user.getAccount()
            , user.getPassword()
            , user.getName()
            , user.getStatus()
            , user.getId());
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
    * - Function name : alterUserService
    * - Description : 修改数据库中的用户数据
    * - Variables : string eid
    *****************************************************/
    public User getInfoByEid(string eid)
    {
        // 实例化一个用户对象
        User user = new User();

        // 数据库查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select * from user_table where u_id='{0}'", eid);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        string account = "";
        string password = "";
        string name = "";
        string status = "";
        while (reader.Read())
        {
            account = reader[0].ToString();
            password = reader[1].ToString();
            name = reader[2].ToString();
            status = reader[3].ToString();
        }
        reader.Close();
        mycon.Close();

        // 赋值
        user.setAccount(account);
        user.setPassword(password);
        user.setName(name);
        user.setStatus(status);

        // 返回值
        return user;
    }




    /*****************************************************
    * - Function name : deleteUserService
    * - Description : 修改数据库中的用户数据
    * - Variables : User user
    *****************************************************/
    public bool deleteUserService(User user)
    {
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("delete from user_table where u_id='{0}'", user.getId());
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