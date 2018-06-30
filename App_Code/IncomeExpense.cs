using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : IncomeExpense.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 收支明细类
 * - Function list :
 * 1.IncomeExpense
 * -Others : 
 * [刘畅]2018/5/22第一次修改，代码通过自动生成器产生，
 *       自行添加了默认值设定。
 ***************************************************/

/// <summary>
/// IncomeExpense
/// 实体类
/// 关联控制类IncomeExpenseAction
/// 关联服务类IncomeExpenseService
/// </summary>
public class IncomeExpense
{
    private double money;          //交易金额：money>=0
    private string date;           //交易日期：年/月/日 时:分:秒
    private string deal_kind;      //业务类型：收入|支出
    private string receive_name;   //收款人：允许为空
    private string receive_card;   //收款卡号：允许为空
    private string allocate_name;  //发款人：允许为空
    private string allocate_card;  //发款卡号：允许为空
    private string deal_way;       //交易方式：在线交易|现金交易|银行卡交易
    private string assure_id;      //办理人工号：e_id
    private string ddt_note;       //备注：允许为空




    public void setMoney(double money) { this.money = money; }
    public void setDate(string date) { this.date = date; }
    public void setDeal_kind(string deal_kind) { this.deal_kind = deal_kind; }
    public void setReceive_name(string receive_name) { this.receive_name = receive_name; }
    public void setReceive_card(string receive_card) { this.receive_card = receive_card; }
    public void setAllocate_name(string allocate_name) { this.allocate_name = allocate_name; }
    public void setAllocate_card(string allocate_card) { this.allocate_card = allocate_card; }
    public void setDeal_way(string deal_way) { this.deal_way = deal_way; }
    public void setAssure_id(string assure_id) { this.assure_id = assure_id; }
    public void setDdt_note(string ddt_note) { this.ddt_note = ddt_note; }




    public double getMoney() { return money; }
    public string getDate() { return date; }
    public string getDeal_kind() { return deal_kind; }
    public string getReceive_name() { return receive_name; }
    public string getReceive_card() { return receive_card; }
    public string getAllocate_name() { return allocate_name; }
    public string getAllocate_card() { return allocate_card; }
    public string getDeal_way() { return deal_way; }
    public string getAssure_id() { return assure_id; }
    public string getDdt_note() { return ddt_note; }




    /*****************************************************
     * - Function name : IncomeExpense
     * - Description : 构造函数
     * - Variables : void
     *****************************************************/
	public IncomeExpense()
	{
        money = 0;
        date = "";
        deal_kind = "";
        receive_name = "";
        receive_card = "";
        allocate_card = "";
        allocate_name = "";
        deal_way = "";
        assure_id = "";
        ddt_note = "";
	}
}