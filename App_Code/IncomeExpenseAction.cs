using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : IncomeExpenseAction.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 收支明细类控制类
 * - Function list :
 * 1.IncomeExpenseAction
 * 2.addIncomeExpense
 * 3.setIEDeal
 * 4.setIEDealMan
 * 5.setIENote
 * -Others : 
 * [刘畅]2018/5/22第一次修改，完成设定接口设计
 ***************************************************/

/*
 该类的使用方法：
 // 建立实例
 IncomeExpenseAction IEA = new IncomeExpenseAction();
 
 // 新建收支明细对象
 IEA.addIncomeExpense();
 
 // 设置交易内容
 IEA.setIEDeal(...);
 
 // 设置交易人内容
 IEA.setIEDealMan(...);
 
 // 设置交易备注
 IEA.setIENote(...);
 
 // 提交并操作
 IEA.submit();
 */



/// <summary>
/// IncomeExpenseAction
/// IncomeExpense的控制类
/// </summary>
public class IncomeExpenseAction
{
    // 系统支持项
    private IncomeExpense IE;

    public IncomeExpense getIncomeExpense() { return IE; }


    /*****************************************************
     * - Function name : IncomeExpenseAction
     * - Description : 构造函数
     * - Variables : void
     *****************************************************/
	public IncomeExpenseAction()
	{
		
	}




    /*****************************************************
     * - Function name : addIncomeExpense
     * - Description : 新建收支明细对象
     * - Variables : void
     *****************************************************/
    public void addIncomeExpense()
    {
        IE = new IncomeExpense();
    }





    /*****************************************************
     * - Function name : setIEDeal
     * - Description : 设置交易内容
     * - Variables : double money, string receive_name, string receive_card, string allocate_name, string allocate_card
     *****************************************************/
    public void setIEDeal(double money, string receive_name, string receive_card, string allocate_name, string allocate_card)
    {
        // 交易金额
        IE.setMoney(money);

        // 收款人姓名（可为空）
        IE.setReceive_name(receive_name);

        // 收款卡号（可为空）
        IE.setReceive_card(receive_card);

        // 付款人姓名（可为空）
        IE.setAllocate_name(allocate_name);

        // 付款卡号（可为空）
        IE.setAllocate_card(allocate_card);
    }




    /*****************************************************
     * - Function name : setIEDealMan
     * - Description : 设置交易人内容
     * - Variables : string date, string deal_kind, string deal_way, string assure_id
     *****************************************************/
    public void setIEDealMan(string date, string deal_kind, string deal_way, string assure_id)
    {
        // 交易日期
        IE.setDate(date);

        // 交易类型（收入/支出）
        IE.setDeal_kind(deal_kind);

        // 交易途径
        IE.setDeal_way(deal_way);

        // 办理人工号
        IE.setAssure_id(assure_id);
    }




    /*****************************************************
     * - Function name : setIENote
     * - Description : 设置交易备注
     * - Variables : string note
     *****************************************************/
    public void setIENote(string note)
    {
        IE.setDdt_note(note);
    }




    /*****************************************************
     * - Function name : submit
     * - Description : 提交并操作
     * - Variables : void
     *****************************************************/
    public void submit()
    {
        IncomeExpenseService IES = new IncomeExpenseService();
        IES.saveIncomeExpenseRecord(this.IE);
    }
}