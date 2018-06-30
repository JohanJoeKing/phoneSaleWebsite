using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : dataManagerAction.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/22
 * - Description : 该类用于财务科汇总收支使用
 * - Function list :
 * 1.DataManagerAction
 * 2.initDataManager
 * 3.setDataManager
 * 4.searchData
 * 5.getIESummary
 * 6.getIERecords
 * -Others : 
 * [刘畅]2018/5/22第一次修改，完成了基本功能设计
 ***************************************************/

/// <summary>
/// dataManagerAction
/// </summary>
public class DataManagerAction
{
    // 基本属性
    DataManager DM;    // 数据查询器
    public string INCOME = "收入";
    public string EXPENSE = "支出";



    /*****************************************************
    * - Function name : dataManagerAction
    * - Description : 构造函数
    * - Variables : void
    *****************************************************/
	public DataManagerAction()
	{
		
	}




    /*****************************************************
    * - Function name : initDataManager
    * - Description : 新建数据查询器
    * - Variables : void
    *****************************************************/
    public void initDataManager()
    {
        DM = new DataManager();
    }





    /*****************************************************
    * - Function name : setDataManager
    * - Description : 设置数据查询器查询对象
    * - Variables : string deal_kind
    *****************************************************/
    public void setDataManager(string deal_kind)
    {
        DM.setDeal_kind(deal_kind);
    }




    /*****************************************************
    * - Function name : searchData
    * - Description : 查询目标数据
    * - Variables : void
    *****************************************************/
    public void searchData()
    {
        DataManagerService DMS = new DataManagerService();
        DM.setSummary(DMS.set(DM.getDeal_kind()));
        DM.setRecord(DMS.getRecords(DM.getDeal_kind()));
    }





    /*****************************************************
    * - Function name : getIESummary
    * - Description : 获取汇总结果
    * - Variables : void
    *****************************************************/
    public double getIESummary()
    {
        return DM.getSummary();
    }




    /*****************************************************
    * - Function name : getIERecords
    * - Description : 获取记录条数
    * - Variables : void
    *****************************************************/
    public int getIERecords()
    {
        return DM.getRecord();
    }
}