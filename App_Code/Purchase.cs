using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Purchase 的摘要说明
/// </summary>
public class Purchase
{
    // 基本属性
    private string p_id;         // 商品编号
    private string pr_number;    // 单号
    private string pur_date;     // 申请日期
    private string pur_way;      // 采购方式
    private int pur_amount;      // 采购数量
    private double p_price;      // 单价
    private double p_summary;    // 总价
    private string pur_card;     // 采购使用的卡号
    private string receive_id;   // 收款卡号
    private string buy_id;       // 采购人
    private string pur_id;          // 审核人
    private string pur_id_2;        // 二级单号
    private char pur_received;   // 是否收货
    private char pur_permit;     // 是否通过审核



    // set
    public void setP_id(string p_id) { this.p_id = p_id; }
    public void setPr_number(string pr_number) { this.pr_number = pr_number; }
    public void setPur_date(string pur_date) { this.pur_date = pur_date; }
    public void setPur_way(string pur_way) { this.pur_way = pur_way; }
    public void setPur_amount(int pur_amount) { this.pur_amount = pur_amount; }
    public void setP_price(double p_price) { this.p_price = p_price; }
    public void setP_summary(double p_summary) { this.p_summary = p_summary; }
    public void setPur_card(string pur_card) { this.pur_card = pur_card; }
    public void setReceive_id(string receive_id) { this.receive_id = receive_id; }
    public void setBuy_id(string buy_id) { this.buy_id = buy_id; }
    public void setPur_id(string pur_id) { this.pur_id = pur_id; }
    public void setPur_id_2(string pur_id_2) { this.pur_id_2 = pur_id_2; }
    public void setPur_received(char pur_received) { this.pur_received = pur_received; }
    public void setPur_permit(char pur_permit) { this.pur_permit = pur_permit; }



    // get
    public string getP_id() { return p_id; }
    public string getPr_number() { return pr_number; }
    public string getPur_date() { return pur_date; }
    public string getPur_way() { return pur_way; }
    public int getPur_amount() { return pur_amount; }
    public double getP_price() { return p_price; }
    public double getP_summary() { return p_summary; }
    public string getPur_card() { return pur_card; }
    public string getReceive_id() { return receive_id; }
    public string getBuy_id() { return buy_id; }
    public string getPur_id() { return pur_id; }
    public string getPur_id_2() { return pur_id_2; }
    public char getPur_received() { return pur_received; }
    public char getPur_permit() { return pur_permit; }
}