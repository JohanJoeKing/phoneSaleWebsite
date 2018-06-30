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
 * - Filename : LogHelper.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/20
 * - Description : 该类用于响应各种用户登录和注销
 *                 提供登录验证接口
 * - Function list :
 * 1.LogHelper
 * 2.LogHelper
 * 3.matching
 * 4.passed
 * 5.matchingByDepartment
 * -Others : 
 * [刘畅]2018/5/20第一次修改，大体能完成基本登录验证功能
 * [刘畅]2018/5/21第二次修改，设计为提供不同部门登录的不
 *       同接口,添加department属性验证
 * [刘畅]2018/5/26第三次修改，改动数据库属性获取方式
 ***************************************************/

/// <summary>
/// LogHelper
/// 需要访问数据库
/// 故该文件内需要引用MySQL的DLL
/// </summary>
public class LogHelper
{
    // 基本属性
    private string id;         // 工号
    private string password;   // 密码
    private string name;       // 姓名
    private string position;   // 职位
    private bool flag;         // 是否可登录
    private string department; // 操作部门
                               /*
                                * department属性的取值范围有：
                                * 采购科职员
                                * 财务科职员
                                * 仓库职员
                                * 销售科职员
                                * 管理员
                                */

    // 数据库连接属性
    private MyDatabase MDB;

    // set方法
    public void setId(string id) { this.id = id; }
    public void setPassword(string password) { this.password = password; }
    public void setName(string name) { this.name = name; }
    public void setPosition(string position) { this.position = position; }
    public void setFlag(bool flag) { this.flag = flag; }
    public void setDepartment(string department) { this.department = department; }

    // get方法
    public string getId() { return id; }
    public string getPassword() { return password; }
    public string getName() { return name; }
    public string getPosition() { return position; }
    public bool getFlag() { return flag; }
    public string getDepartment() { return department; }


   /*****************************************************
    * - Function name : LogHelper
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
    public LogHelper()
	{
        id = "";
        password = "";
        name = "";
        position = "";
        flag = false;
        MDB = new MyDatabase();
	}




    /*****************************************************
    * - Function name : LogHelper
    * - Description : 构造函数（不区分部门式，更快捷）
    * - Variables : string id, string password
    *****************************************************/
    public LogHelper(string id, string password)
    {
        this.id = id;
        this.password = password;
        name = "";
        position = "";
        flag = false;
        matching();
        MDB = new MyDatabase();
    }




    /*****************************************************
    * - Function name : matching
    * - Description : 验证（不区分部门式）
    * - Variables : void
    *****************************************************/
    public void matching()
    {
        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}", 
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select * from user_table where u_id='{0}'", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        string pwTemp = "";
        while (reader.Read())
        {
            pwTemp = reader[1].ToString();
            name = reader[2].ToString();
            position = reader[3].ToString();
        }
        reader.Close();
        mycon.Close();

        // 密码匹配
        if (pwTemp == password)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }




    /*****************************************************
    * - Function name : passed
    * - Description : 查看是否登录验证通过
    * - Variables : void
    *****************************************************/
    public bool passed()
    {
        return flag;
    }




    /*****************************************************
    * - Function name : matchingByDepartment
    * - Description : 分科室验证登录，需要先设置科室
    * - Variables : void
    *****************************************************/
    public void matchingByDepartment()
    {
        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select * from user_table ut join employee_table et on ut.u_id=et.e_id where ut.u_id='{0}' and e_position='{1}'", id, department);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        string pwTemp = "";
        while (reader.Read())
        {
            pwTemp = reader[1].ToString();
            name = reader[2].ToString();
        }
        reader.Close();
        mycon.Close();
        position = department;

        // 密码匹配
        if (pwTemp == password)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }




    /*****************************************************
    * - Function name : matchingIntoSystem
    * - Description : 登录到系统管理员
    * - Variables : void
    *****************************************************/
    public void matchingIntoSystem()
    {
        // 连接数据库并查询
        string link = string.Format("server={0};User Id={1};password={2};Database={3}",
            MDB.getServer(), MDB.getUser(), MDB.getPassword(), MDB.getDatabase());
        MySqlConnection mycon = new MySqlConnection(link);
        mycon.Open();
        string sql = string.Format("select * from user_table where u_id='{0}' and u_status='admin'", id);
        MySqlCommand mycmd = new MySqlCommand(sql, mycon);
        MySqlDataReader reader = null;
        reader = mycmd.ExecuteReader();
        string pwTemp = "";
        while (reader.Read())
        {
            pwTemp = reader[1].ToString();
            name = reader[2].ToString();
        }
        reader.Close();
        mycon.Close();
        position = department;

        // 密码匹配
        if (pwTemp == password)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }
}