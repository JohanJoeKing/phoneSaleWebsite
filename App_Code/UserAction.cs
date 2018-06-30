using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : UserAction.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 用户控制类
 * - Function list :
 * 1.UserAction
 * 2.UserAction
 * 3.initUser
 * 4.setUser
 * 5.saveUser
 * 6.alterUser
 * 7.setEid
 * 8.deleteUser
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/


/// <summary>
/// UserAction
/// </summary>
public class UserAction
{
    // 基本属性
    private User user;   // 用户实体类




    /*****************************************************
    * - Function name : UserAction
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public UserAction()
	{
		
	}





    /*****************************************************
    * - Function name : UserAction
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
    public UserAction(User user)
    {
        this.user = user;
    }




    /*****************************************************
    * - Function name : initUser
    * - Description : 新建用户对象
    * - Variables : void
    *****************************************************/
    public void initUser()
    {
        user = new User();
    }




    /*****************************************************
    * - Function name : setUser
    * - Description : 设置用户对象
    * - Variables : string account, string password, string name, string status, string id
    *****************************************************/
    public void setUser(string account, string password, string name, string status, string id)
    {
        user.setAccount(account);   // 设置账号
        user.setPassword(password); // 设置密码
        user.setName(name);         // 设置姓名
        user.setStatus(status);     // 设置系统角色
        user.setId(id);             // 设置身份证号
    }





    /*****************************************************
    * - Function name : saveUser
    * - Description : 保存用户对象
    * - Variables : void
    *****************************************************/
    public bool saveUser()
    {
        // 实例化一个服务类对象
        UserService US = new UserService();

        // 调用保存到数据库接口
        if (US.saveUserService(user))
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    /*****************************************************
    * - Function name : alterUser
    * - Description : 更改用户对象
    * - Variables : void
    *****************************************************/
    public bool alterUser()
    {
        // 实例化一个服务类对象
        UserService US = new UserService();

        // 调用保存到数据库接口
        if (US.alterUserService(user))
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    /*****************************************************
    * - Function name : setEid
    * - Description : 设置用户工号
    * - Variables : string eid
    *****************************************************/
    public void setEid(string eid)
    {
        user.setId(eid);
    }




    /*****************************************************
    * - Function name : deleteUser
    * - Description : 删除工号用户
    * - Variables : void
    *****************************************************/
    public bool deleteUser()
    {
        // 实例化一个服务类对象
        UserService US = new UserService();

        // 调用保存到数据库接口
        if (US.deleteUserService(user))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}