using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;


public partial class Theme : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTheme();
        }
    }

    public void GetTheme()
    {
        ThemeManager tm = new ThemeManager();
        //string UserId=DataList1.DataKeys[]
        //da
        //FormView1.DataBind();
        DataList1.DataSource = tm.GetTheme();
        DataList1.DataBind();
        
    }


    //protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    //{
    //    ThemeManager tm = new ThemeManager();
    //    //string UserId = DataList1.DataKeys[e.Item.ItemIndex].ToString();

    //    DataList1.DataSource = tm.GetTheme();
    //    DataList1.DataBind();
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        Userinfo user;
        Usermanager um = new Usermanager();
        if (um.Login(this.TextBox1.Text, this.TextBox2.Text, out user))
        {
            
            //Session["CurrentUser"] = user;
            //this.Label1.Text = user.NickName.ToString() + "  欢迎您！";
            //this.pnLongin.Visible = true;
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码不正确，请重新填写')</script>");
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Reader")
        {
            int ThemeId = Convert.ToInt32(e.CommandArgument);
            ThemeManager bll = new ThemeManager();
            bll.AddClick(ThemeId);
            Response.Redirect("~/article.aspx?ThemeId=" + e.CommandArgument.ToString());
        }
    }
}