using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;


public partial class article : System.Web.UI.Page
{
//    ThemeManager tm = new ThemeManager();
//    Themeinfo info = new Themeinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Add_Visitor();
            Bindlist();
        }
    }
    protected void btnPut_Click(object sender, EventArgs e)
    {
        //int Id = Convert.ToInt32(Request.QueryString["ThemeId"]);
        Models.Questions qs1 = new Models.Questions();
        qs1.ThemeId = Convert.ToInt32(Request.QueryString["ThemeId"]);
        qs1.Author = txtCommentName.Text;
        qs1.R_Content = txtComment.Text;
        qs1.R_PublishTime = DateTime.Now;
        CommentManager.AddComment(qs1);
        ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('添加成功')</script>");//向页面注册脚本
    }
    public void Add_Visitor()
    {
        string Visitor = "游客";
        Visitor = Visitor + Guid.NewGuid().ToString().Substring(0, 4);
        this.txtCommentName.Text = Visitor;
    }

    private void Bindlist()
    {
         ThemeManager tm = new ThemeManager();
         int ThemeId = Convert.ToInt32(Request.QueryString["ThemeId"]);
         this.dlAllComment.DataSource = tm.GetModelById(ThemeId);
         dlAllComment.DataBind();

    }

}
