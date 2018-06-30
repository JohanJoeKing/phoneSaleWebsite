using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : financeAddDeal.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/21
 * - Description : 本文件为财务科添加收支记录页面
 * - Function list :
 * 1.Page_Load
 * 2.submit_Click
 * 3.DropDownListYear_SelectedIndexChanged
 * 4.DropDownListMonth_SelectedIndexChanged
 * 5.DropDownListDay_SelectedIndexChanged
 * 6.setBoxesAvailable
 * 7.datetimeAvailable
 * -Others : 
 * [刘畅]2018/5/21第一次修改，完成UI实现
 * [刘畅]2018/5/22第二次修改，实现登录验证，添加
 *       控件关闭和打开方法，添加数据功能
 ***************************************************/

public partial class financeAddDeal : System.Web.UI.Page
{
    // 系统支持项
    private const bool OPEN = true;
    private const bool CLOSE = false;



    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 验证是否登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            setBoxesAvailable(CLOSE);
        }
        else
        {
            // UI设置
            for (int y = 2018; y < 2030; y++)
            {
                DropDownListYear.Items.Add(y + "");
            }
            for (int m = 1; m <= 12; m++)
            {
                DropDownListMonth.Items.Add(m + "");
            }
            for (int d = 1; d <= 31; d++)
            {
                DropDownListDay.Items.Add(d + "");
            }
            DropDownListDealway.Items.Add("在线交易");
            DropDownListDealway.Items.Add("现金交易");
            DropDownListDealway.Items.Add("银行卡交易");
            setBoxesAvailable(OPEN);

            // 默认参数
            string year = System.DateTime.Now.Year.ToString();
            string month = System.DateTime.Now.Month.ToString();
            string day = System.DateTime.Now.Day.ToString();
            DropDownListYear.Text = year;
            DropDownListMonth.Text = month;
            DropDownListDay.Text = day;
            TextBoxDealMan.Text = Session["FinanceDepartmentUsername"].ToString();
        }
        
    }




    /*****************************************************
     * - Function name : submit_Click
     * - Description : 提交响应
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void submit_Click(object sender, EventArgs e)
    {
        // 获取输入值
        double money = double.Parse(TextBoxMoney.Text.ToString());
        string y = DropDownListYear.Text.ToString();
        string m = DropDownListMonth.Text.ToString();
        string d = DropDownListDay.Text.ToString();
        string h = System.DateTime.Now.Hour.ToString();
        string min = System.DateTime.Now.Minute.ToString();
        string sec = System.DateTime.Now.Second.ToString();
        string date = y + "/" + m + "/" + d + " " + h + ":" + min + ":" + sec;
        string deal_kind = "";
        if (RadioButton1.Checked == true)
        {
            deal_kind = "收入";
        }
        else if (RadioButton2.Checked == true)
        {
            deal_kind = "支出";
        }
        string receive_name = TextBoxReceiveMan.Text.ToString();
        string receive_card = TextBoxReceiveCard.Text.ToString();
        string allocate_name = TextBoxAllocateMan.Text.ToString();
        string allocate_card = TextBoxAllocateCard.Text.ToString();
        string deal_way = DropDownListDealway.Text.ToString();
        FinanceDatabaseHelper FDH = new FinanceDatabaseHelper();
        string deal_man = TextBoxDealMan.Text.ToString();
        string assure_id = FDH.getEmployeeID(deal_man);
        string note = TextBoxNote.Text.ToString();

        // 检验办理人是否合理
        if (deal_man != "匿名")
        {
            if (deal_man == "")
            {
                Response.Write("<script>alert('办理人不合法！');</script>");
                return;
            }
        }

        // 创建控制类
        IncomeExpenseAction IEA = new IncomeExpenseAction();

        // 新建收支对象
        IEA.addIncomeExpense();

        // 设置属性值
        IEA.setIEDeal(money, receive_name, receive_card, allocate_name, allocate_card);
        IEA.setIEDealMan(date, deal_kind, deal_way, assure_id);
        IEA.setIENote(note);

        // 保存
        IncomeExpenseService IES = new IncomeExpenseService();
        if (IES.saveIncomeExpenseRecord(IEA.getIncomeExpense()))
        {
            Response.Write("<script type='text/javascript'>alert('添加成功！');window.location='financeHome.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
    }




    /*****************************************************
     * - Function name : DropDownListYear_SelectedIndexChanged
     * - Description : 加载年份
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void DropDownListYear_SelectedIndexChanged(object sender, EventArgs e)
    {
    }




    /*****************************************************
     * - Function name : DropDownListMonth_SelectedIndexChanged
     * - Description : 加载月份
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 读取选取的月份和年份
        string year = DropDownListYear.Text.ToString();
        string month = DropDownListMonth.Text.ToString();

        // 确认缺省
        if (year == "" || month == "")
        {
            return;
        }

        // 计算应有的天数
        int y = int.Parse(year);
        if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
        {
            // 闰年
            int m = int.Parse(month);
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
            {
                for (int d = 1; d <= 31; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
            else if (m == 4 || m == 6 || m == 9 || m == 11)
            {
                for (int d = 1; d <= 30; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
            else
            {
                for (int d = 1; d <= 29; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
        }
        else
        {
            // 平年
            int m = int.Parse(month);
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
            {
                for (int d = 1; d <= 31; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
            else if (m == 4 || m == 6 || m == 9 || m == 11)
            {
                for (int d = 1; d <= 30; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
            else
            {
                for (int d = 1; d <= 28; d++)
                {
                    DropDownListDay.Items.Add(d + "");
                }
            }
        }
    }




    /*****************************************************
     * - Function name : DropDownListDay_SelectedIndexChanged
     * - Description : 加载日期
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void DropDownListDay_SelectedIndexChanged(object sender, EventArgs e)
    {
    }





    /*****************************************************
     * - Function name : setBoxesAvailable
     * - Description : 关闭或开启控件使用
     * - Variables : bool available
     *****************************************************/
    private void setBoxesAvailable(bool available)
    {
        DropDownListYear.Enabled = available;
        DropDownListMonth.Enabled = available;
        DropDownListDay.Enabled = available;
        ButtonSubmit.Enabled = available;
        TextBoxAllocateMan.Enabled = available;
        TextBoxAllocateCard.Enabled = available;
        TextBoxReceiveMan.Enabled = available;
        TextBoxReceiveCard.Enabled = available;
        TextBoxMoney.Enabled = available;
        DropDownListDealway.Enabled = available;
        RadioButton1.Enabled = available;
        RadioButton2.Enabled = available;
        TextBoxNote.Enabled = available;
        TextBoxDealMan.Enabled = available;
    }




    /*****************************************************
     * - Function name : datetimeAvailable
     * - Description : 检验日期是否正确
     * - Variables : int year, int month, int day
     *****************************************************/
    private bool datetimeAvailable(int year, int month, int day)
    {
        // 计算应有的天数
        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            // 闰年
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day <= 31)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (day <= 29)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            // 平年
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day <= 31)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (day <= 28)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}