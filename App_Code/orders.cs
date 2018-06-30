using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// order 订单   销售明细表
/// </summary>
public class orders
{
    private string p_id;  //商品编号
    private string s_date; //日期
    private double s_price;
    private string s_e_id;
    private int s_amount;
    private double s_summary;
    private string s_id;  //销售单号
    private double s_get;
    private double s_return;
    private string s_way;
    private string pr_number;

    public void setP_id(string p_id) { this.p_id = p_id; }
    public void setS_date(string s_date) { this.s_date = s_date; }
    public void setS_price(double s_price) { this.s_price = s_price; }
    public void setS_e_id(string s_e_id) { this.s_e_id = s_e_id; }
    public void setS_amount(int s_amount) { this.s_amount = s_amount; }
    public void setS_summary(double s_summary) { this.s_summary = s_summary; }
    public void setS_id(string s_id) { this.s_id = s_id; }
    public void setS_get(double s_get) { this.s_get = s_get; }
    public void setS_return(double s_return) { this.s_return = s_return; }
    public void setS_way(string s_way) { this.s_way = s_way; }
    public void setPr_number(string pr_number) { this.pr_number = pr_number; }




    public string getP_id() { return p_id; }
    public string getS_date() { return s_date; }
    public double getS_price() { return s_price; }
    public string getS_e_id() { return s_e_id; }
    public int getS_amount() { return s_amount; }
    public double getS_summary() { return s_summary; }
    public string getS_id() { return s_id; }
    public double getS_get() { return s_get; }
    public double getS_return() { return s_return; }
    public string getS_way() { return s_way; }
    public string getPr_number() { return pr_number; }



	public orders()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
}