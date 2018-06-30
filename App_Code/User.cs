using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : User.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 用户实体类
 * - Function list :
 * 1.User
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/


/// <summary>
/// User 的摘要说明
/// </summary>
public class User
{
    private string account;    // 账户
    private string password;   // 密码
    private string name;       // 昵称
    private string status;     // 权限
    private string id;         // 身份证号



    // set
    public void setAccount(string account) { this.account = account; }
    public void setPassword(string password) { this.password = password; }
    public void setName(string name) { this.name = name; }
    public void setStatus(string status) { this.status = status; }
    public void setId(string id) { this.id = id; }



    // get
    public string getAccount() { return account; }
    public string getPassword() { return password; }
    public string getName() { return name; }
    public string getStatus() { return status; }
    public string getId() { return id; }




    /*****************************************************
    * - Function name : User
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public User()
	{
		
	}
}