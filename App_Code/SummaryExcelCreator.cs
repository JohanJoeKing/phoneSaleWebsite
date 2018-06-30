using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;

/*******************************************************
 * - Class name : SummaryExcelCreator
 * - Author : 刘畅   Version : 1.0   Date : 2018/5/22
 * - Description : 汇总表生成器
 * - Function List :
 *  1.SummaryPdfCreator
 *  2.setIncomeExpense
 *  3.setIncomeExpenseScale
 *  4.setEarn
 *  5.generateExcel
 * - Others : 
 *******************************************************/

/// <summary>
/// SummaryPdfCreator
/// 需要EXCEL文件生成外部支持项
/// </summary>
public class SummaryExcelCreator
{
    // 基本属性
    private string filename;  // excel文件名
    private double income;    // 总收入
    private double expense;   // 总支出
    private int incomes;      // 收入项
    private int expenses;     // 支出项
    private double earn;      // 盈利


    /*****************************************************
     * - Function name : SummaryPdfCreator
     * - Description : 构造函数
     * - Variables : string filename
     *****************************************************/
    public SummaryExcelCreator(string filename)
	{
        this.filename = filename;
	}




    /*****************************************************
     * - Function name : setIncomeExpense
     * - Description : 设定收支
     * - Variables : double income, double expense
     *****************************************************/
    public void setIncomeExpense(double income, double expense)
    {
        this.income = income;
        this.expense = expense;
    }






    /*****************************************************
     * - Function name : SummaryPdfCreatorScale
     * - Description : 设定收支规模
     * - Variables : string filename
     *****************************************************/
    public void setIncomeExpenseScale(int incomes, int expenses)
    {
        this.incomes = incomes;
        this.expenses = expenses;
    }




    /*****************************************************
     * - Function name : setEarn
     * - Description : 设定盈利
     * - Variables : double earn
     *****************************************************/
    public void setEarn(double earn)
    {
        this.earn = earn;
    }





    /*****************************************************
     * - Function name : generateExcel
     * - Description : 生成报表
     * - Variables : void
     *****************************************************/
    public bool generateExcel()
    {
        try
        {
            // 实例化Application对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            // 设置为后台操作不可见
            excel.Visible = false;

            // 新建工作簿
            excel.Application.Workbooks.Add(true);

            // 插入数据
            excel.Cells[1, 1] = "总收入";
            excel.Cells[1, 2] = "总支出";
            excel.Cells[1, 3] = "收入记录";
            excel.Cells[1, 4] = "支出记录";
            excel.Cells[1, 5] = "盈利";

            excel.Cells[2, 1] = income + "元";
            excel.Cells[2, 2] = expense + "元";
            excel.Cells[2, 3] = incomes + "条";
            excel.Cells[2, 4] = expenses + "条";
            excel.Cells[2, 5] = earn + "元";

            // 设置禁止弹出保存和覆盖提示
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;

            // 保存
            excel.Application.Workbooks.Add(true).Save();

            // 保存excel文件
            excel.Save("D:\\" + filename + ".xls");

            // 确认excel进程关闭
            excel.Quit();
            excel = null;

            return true;
        }
        catch(Exception e){
            return false;
        }
    }
}