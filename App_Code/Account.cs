using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : Account.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 账户实体类
 * - Function list :
 * 1.Account
 * -Others : 
 * [刘畅]2018/5/27第一次修改，搭建好类
 ***************************************************/


/// <summary>
/// Account 的摘要说明
/// </summary>
public class Account
{
    private string id;     // 身份证号
    private string card;   // 银行卡号
    private string eid;    // 工号
    private string note;   // 备注
    private double money;  // 余额



    // set
    public void setId(string id) { this.id = id; }
    public void setCard(string card) { this.card = card; }
    public void setEid(string eid) { this.eid = eid; }
    public void setNote(string note) { this.note = note; }
    public void setMoney(double money) { this.money = money; }



    // get
    public string getId() { return id; }
    public string getCard() { return card; }
    public string getEid() { return eid; }
    public string getNote() { return note; }
    public double getMoney() { return money; }




    /*****************************************************
    * - Function name : Account
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public Account()
	{
		
	}
}