using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

public partial class Answers : System.Web.UI.Page
{
    Userinfo user;
    //private int UsersId
    //{
    //    get { return Convert.ToInt32(Session["UsersID"]); }
    //    set { Session["UsersID"] = value; }
    //}
    //private string UserName
    //{
    //    get { return Session["UserName"].ToString(); }
    //    set { Session["UserName"] = value; }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        
 
            //UsersId = Convert.ToInt32(Request.QueryString["UsersID"]);
            //UserName = Request.QueryString["UserName"];
            //this.TextBox3 .Text = UserName;
        
      

        if (Session["CurrentUser"] != null)
        {
            user = (Userinfo)Session["CurrentUser"];
        }
        else
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能登陆发表文章!");
            return;
        }
        this.TextBox2.Text =DateTime.Now.ToString();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Themeinfo info = new Themeinfo();
        ThemeManager tm = new ThemeManager();
        info.Title = this.TextBox1.Text.ToString();
        info.T_Content = this.FreeTextBox1.Text.ToString();
        info.Anthor = user;
        info.Spot = 0;
        info.T_PublishTime = DateTime.Now;

        if (tm.Insert_Article(info) != null)
        {
            Response.Redirect("~/refresh.aspx?msg=" + "恭喜你,发表成功!");
        }
        else
        {
            this.lblMsg.Text = "很遗憾,发表失败,请重新尝试!";
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        this.FreeTextBox1 .Text = "";
    }
}