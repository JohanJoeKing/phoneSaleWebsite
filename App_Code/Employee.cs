using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : Employee.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 职工实体类
 * - Function list :
 * 1.Employee
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/


/// <summary>
/// Employee
/// </summary>
public class Employee
{
    private string id;            //身份证号码
    private string name;          //姓名
    private string phone;         //联系方式
    private string joinDate;      //上岗日期
    private string dismissDate;   //离职日期
    private string birth;         //出生日期
    private string sex;           //性别
    private string wages;         //基本工资
    private string position;      //岗位
    private string eid;           //工号
    private string address;       //住址
    private string note;          //备注



    // set
    public void setId(string id) { this.id = id; }
    public void setName(string name) { this.name = name; }
    public void setPhone(string phone) { this.phone = phone; }
    public void setJoinDate(string joinDate) { this.joinDate = joinDate; }
    public void setDismissDate(string dismissDate) { this.dismissDate = dismissDate; }
    public void setBirth(string birth) { this.birth = birth; }
    public void setSex(string sex) { this.sex = sex; }
    public void setWages(string wages) { this.wages = wages; }
    public void setPosition(string position) { this.position = position; }
    public void setEid(string eid) { this.eid = eid; }
    public void setAddress(string address) { this.address = address; }
    public void setNote(string note) { this.note = note; }



    // get
    public string getId() { return id; }
    public string getName() { return name; }
    public string getPhone() { return phone; }
    public string getJoinDate() { return joinDate; }
    public string getDismissDate() { return dismissDate; }
    public string getBirth() { return birth; }
    public string getSex() { return sex; }
    public string getWages() { return wages; }
    public string getPosition() { return position; }
    public string getEid() { return eid; }
    public string getAddress() { return address; }
    public string getNote() { return note; }




    /*****************************************************
    * - Function name : Employee
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public Employee()
	{
		
	}
}