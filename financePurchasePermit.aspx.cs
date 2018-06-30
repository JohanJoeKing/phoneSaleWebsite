using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : financePurchasePermit.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/6/3
 * - Description : 本文件为财务科批复采购申请的界面
 * - Function list :
 * 1.Page_Load
 * -Others : 
 * [刘畅]2018/6/5第一次修改，实现了将数据显示到表格
 ***************************************************/

public partial class financePurchasePermit : System.Web.UI.Page
{
    


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
    }
}