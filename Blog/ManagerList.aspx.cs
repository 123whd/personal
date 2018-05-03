using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

public partial class ManagerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            BindTheme();
        }
  
        if (Session["CurrentUser"] != null)
        {
            Userinfo user = new Userinfo();

            user = (Userinfo)Session["CurrentUser"];
            Session["userid"] = user.Id;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="View")
        {
            Response.Redirect("manageDetail.aspx?Id=" + e.CommandArgument.ToString());
        }
    }


    //获取所有文章信息

    ThemeManager bll = new ThemeManager();
    private void BindTheme()
    {
        GridView1.DataSource = bll.GetTheme();
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int ThemeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
        if (bll.DeleteTheme(ThemeId))
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!')</script>");
            BindTheme();
        }
        else
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败!')</script>");
    }
    //编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindTheme();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //查找需要更新的控件
        TextBox tName = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
        TextBox tTime = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
        TextBox tContent = GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
        //查找对应的的键值
        string ThemeId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        //给实体赋值
        Themeinfo info = new Themeinfo();
        info.ThemeId = Convert.ToInt32(ThemeId);
        info.Title = Convert.ToString(tName.Text);
        info.T_PublishTime = Convert.ToDateTime(tTime.Text);
        info.Spot = Convert.ToInt32(tContent.Text);

        //更新数据
        if (bll.UpdateTheme(info))
        {
            GridView1.EditIndex = -1;
            BindTheme();
        }
        else
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败!')</script>");
    }
    //取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindTheme();
    }
}