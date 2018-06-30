using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : dataManager.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 该类用于财务科汇总收支使用
 * - Function list :
 * 1.DataManager
 * -Others : 
 * [刘畅]2018/5/22第一次修改，实现了基本功能
 * [刘畅]2018/5/22第二次修改，添加记录条数属性
 ***************************************************/

/// <summary>
/// dataManager
/// 关联控制类dataManagerAction
/// 关联服务类dataManagerService
/// </summary>
public class DataManager
{
    // 基本属性
    private double summary;     // 总计
    private string deal_kind;   // 业务类型
    private int record;         // 记录条数

    // set
    public void setSummary(double summary) { this.summary = summary; }
    public void setDeal_kind(string deal_kind) { this.deal_kind = deal_kind;}
    public void setRecord(int record) { this.record = record; }

    // get
    public double getSummary() { return summary; }
    public string getDeal_kind() { return deal_kind; }
    public int getRecord() { return record; }




    /*****************************************************
    * - Function name : dataManager
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public DataManager()
	{
        summary = 0;
        deal_kind = "";
        record = 0;
	}
}