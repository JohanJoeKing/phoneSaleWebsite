using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/***************************************************
 * - Project name : phoneSaleWebsite
 * - Filename : systemUser.aspx.cs
 * - Author : 刘畅    Version : 1.0   Date : 2018/5/27
 * - Description : 本文件为系统管理账户管理界面
 * - Function list :
 * 1.Page_Load
 * 2.ButtonAdd_Click
 * 3.ButtonSave_Click
 * 4.bind
 * 5.TextBoxCeid_TextChanged
 * 6.DropDownListCstatus_SelectedIndexChanged
 * 7.ButtonDelete_Click
 * -Others : 
 * [刘畅]2018/5/27第一次修改，基本实现了该页面功能
 * [刘畅]2018/5/27第二次修改，修改了添加失败漏洞
 ***************************************************/


public partial class systemUser : System.Web.UI.Page
{
    // 数据库连接属性
    private MyDatabase MDB;
    private const string SELECT_USER = "select * from systemuserview";




    /*****************************************************
     * - Function name : Page_Load
     * - Description : 页面加载
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["SystemAccount"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 数据加载
        MDB = new MyDatabase();
        bind(SELECT_USER);
        
        // 加载部件
        if (DropDownListStatus.Items.Count < 2)
        {
            DropDownListStatus.Items.Clear();
            DropDownListStatus.Items.Add("admin");
            DropDownListStatus.Items.Add("user");
            DropDownListCstatus.Items.Clear();
            DropDownListCstatus.Items.Add("admin");
            DropDownListCstatus.Items.Add("user");
        }
    }






    /*****************************************************
     * - Function name : ButtonAdd_Click
     * - Description : 添加用户响应
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["SystemAccount"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 获取信息并查看信息缺省
        string account = TextBoxAccount.Text.ToString();    // 账号
        string password = TextBoxPassword.Text.ToString();  // 密码
        string name = TextBoxName.Text.ToString();          // 姓名
        string status = DropDownListStatus.Text.ToString(); // 角色
        string id = TextBoxEid.Text.ToString();             // 工号
        if(account == "" || password == ""
            || name == "" || status == ""
            || id == "")
        {
            Response.Write("<script>alert('请输入完整信息');</script>");
            return;
        }

        // 实例化一个控制类对象
        UserAction UA = new UserAction();
        UA.initUser();

        // 传递参数
        UA.setUser(account, password, name, status, id);

        // 保存到数据库
        if (UA.saveUser())
        {
            // 浏览器提示
            Response.Write("<script>alert('添加成功');</script>");

            // 清空输入控件
            TextBoxAccount.Text = "";
            TextBoxPassword.Text = "";
            TextBoxName.Text = "";
            TextBoxEid.Text = "";
            DropDownListStatus.Text = "user";

            // 刷新用户数据库信息
            bind(SELECT_USER);
        }
        else
        {
            Response.Write("<script>alert('添加失败');</script>");
        }

    }





    /*****************************************************
     * - Function name : ButtonSave_Click
     * - Description : 保存修改信息
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["SystemAccount"] == null)
        {
            Response.Write("<script>alert('请先登录！');</script>");
            return;
        }

        // 获取信息并查看信息缺省
        string account = TextBoxCaccount.Text.ToString();    // 账号
        string password = TextBoxCpassword.Text.ToString();  // 密码
        string name = TextBoxCname.Text.ToString();          // 姓名
        string status = DropDownListCstatus.Text.ToString(); // 角色
        string id = TextBoxCeid.Text.ToString();             // 工号
        if (account == "" || password == ""
            || name == "" || status == ""
            || id == "")
        {
            Response.Write("<script>alert('请输入完整信息');</script>");
            return;
        }

        // 实例化一个控制类对象
        UserAction UA = new UserAction();
        UA.initUser();

        // 传递参数
        UA.setUser(account, password, name, status, id);

        // 保存到数据库
        if (UA.alterUser())
        {
            // 浏览器提示
            Response.Write("<script>alert('修改成功');</script>");

            // 清空输入控件
            TextBoxCaccount.Text = "";
            TextBoxCpassword.Text = "";
            TextBoxCname.Text = "";
            TextBoxCeid.Text = "";

            // 刷新数据库数据显示
            bind(SELECT_USER);
        }
        else
        {
            Response.Write("<script>alert('修改失败');</script>");
        }
    }




    /*****************************************************
     * - Function name : bind
     * - Description : 加载交易明细数据
     * - Variables : string sql
     *****************************************************/
    private void bind(string sql)
    {
        //创建sql连接对象  
        MySqlConnection conn = new MySqlConnection(MDB.getConnection());

        //sql查询语句 查询对应ID的贷款申请情况  
        string cmdSQL = sql;

        //实例化SqlDataAdapter对象  
        MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

        //实例化数据集DataSet  
        DataSet ds = new DataSet();

        //将返回的数据存放到DataSet中名为LoanMaterial的DataTable中  
        da.Fill(ds, "user_table");

        //设置数据源，用于填充控件中的项的值列表  
        GridView1.DataSource = ds;

        //将控件及其所有子控件绑定到指定的数据源  
        GridView1.DataBind();
    }




    /*****************************************************
     * - Function name : TextBoxCeid_TextChanged
     * - Description : 工号框变化时的响应
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void TextBoxCeid_TextChanged(object sender, EventArgs e)
    {
        // 查看是否已登录
        if (Session["SystemAccount"] == null)
        {
            return;
        }

        // 实时查询对应的用户信息
        UserService US = new UserService();    // 实例化一个服务类对象
        User user = US.getInfoByEid(TextBoxCeid.Text.ToString());

        // 将查询到的信息实时显示到页面
        if (user.getAccount() == "")
        {
            // 当查询为空则说明没有对应信息，直接退出
            return;
        }
        else
        {
            // 实时显示
            TextBoxCaccount.Text = user.getAccount();
            TextBoxCpassword.Text = user.getPassword();
            TextBoxCname.Text = user.getName();
            DropDownListCstatus.Text = user.getStatus();
        }
    }





    /*****************************************************
     * - Function name : DropDownListCstatus_SelectedIndexChanged
     * - Description : 系统角色框内容改变时的覆盖函数
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void DropDownListCstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }







    /*****************************************************
     * - Function name : ButtonDelete_Click
     * - Description : 删除某用户
     * - Variables : object sender, EventArgs e
     *****************************************************/
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        // 实例化一个控制类对象
        UserAction UA = new UserAction();

        // 设置工号
        string eid = TextBoxCeid.Text.ToString();
        UA.initUser();
        UA.setEid(eid);

        // 删除操作
        if (UA.deleteUser())
        {
            // 浏览器提示
            Response.Write("<script>alert('删除成功');</script>");

            // 清空输入控件
            TextBoxCaccount.Text = "";
            TextBoxCpassword.Text = "";
            TextBoxCname.Text = "";
            TextBoxCeid.Text = "";

            // 刷新数据库数据显示
            bind(SELECT_USER);
        }
        else
        {
            // 浏览器提示
            Response.Write("<script>alert('删除失败');</script>");
        }
    }
}