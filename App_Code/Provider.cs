using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : Provider.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 供应商实体类
 * - Function list :
 * 1.Provider
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/



/// <summary>
/// Provider
/// </summary>
public class Provider
{
    private string name;     // 公司名称
    private string number;   // 运营商编号
    private string address;  // 地址
    private string phone;    // 联系方式
    private string mail;     // 邮箱
    private string service;  // 主营业务
    private string charge;   // 负责人
    private string note;     // 备注



    // set
    public void setName(string name) { this.name = name; }
    public void setNumber(string number) { this.number = number; }
    public void setAddress(string address) { this.address = address; }
    public void setPhone(string phone) { this.phone = phone; }
    public void setMail(string mail) { this.mail = mail; }
    public void setService(string service) { this.service = service; }
    public void setCharge(string charge) { this.charge = charge; }
    public void setNote(string note) { this.note = note; }



    // get
    public string getName() { return name; }
    public string getNumber() { return number; }
    public string getAddress() { return address; }
    public string getPhone() { return phone; }
    public string getMail() { return mail; }
    public string getService() { return service; }
    public string getCharge() { return charge; }
    public string getNote() { return note; }




    /*****************************************************
    * - Function name : Provider
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public Provider()
	{
		
	}
}