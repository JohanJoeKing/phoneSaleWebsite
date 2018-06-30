using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : financePurchasePermitAction.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/6/3
 * - Description : 本文件为财务科批复采购申请确认的界面
 * - Function list :
 * 1.Page_Load
 * -Others : 
 * [刘畅]2018/6/5第一次修改，实现了批复确认的功能
 * [刘畅]2018/6/24第二次修改，实现了批准功能
 ***************************************************/

public partial class financePurchasePermitAction : System.Web.UI.Page
{
    private string id;   // 票号

    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["FinanceDepartmentUsername"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 接收传递过来的单号
        id = Request.QueryString["id"];

        // 初始化信息
        init();
    }



    /*****************************************************
     * - Function name : ButtonPermit_Click
     * - Description : 批准操作
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonPermit_Click(object sender, EventArgs e)
    {
        // 获取确认人工号
        string purid = Session["FinanceDepartmentUsername"].ToString();

        // 修改采购单状态
        FinanceDatabaseHelper FDH = new FinanceDatabaseHelper();
        if (FDH.purchasePermitAction(id))
        {
            Response.Write("<script>alert('已批准申请');</script>");
        }
        else
        {
            Response.Write("<script>alert('申请批准操作异常！');</script>");
        }
    }




    /*****************************************************
     * - Function name : init
     * - Description : 根据单号查询信息
     * - Variables : void
     *****************************************************/
    private void init()
    {
        // 创建一个服务类
        FinanceDatabaseHelper FDH = new FinanceDatabaseHelper();

        // 读取订单信息
        Purchase p = FDH.getPurchaseApplicationDetail(id);

        // 显示到界面
        LabelBrand.Text = "品牌：" + FDH.getBrand(id);
        LabelModel.Text = "型号：" + FDH.getModel(id);
        LabelPrice.Text = "单价：" + p.getP_price() + "元";
        LabelAmount.Text = "采购数量：" + p.getPur_amount() + "部";
        LabelSummary.Text = "总价：" + p.getP_summary() + "元";
        LabelDate.Text = "申请日期：" + p.getPur_date();
        LabelBuyway.Text = "采购方式：" + p.getPur_way() + "（" + id + "）";
        LabelBuy.Text = "申请人：" + FDH.getBuyEmployeeName(id);
        LabelCard.Text = "采购卡号：" + p.getPur_card();
    }
}