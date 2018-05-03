using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

public partial class _Default : System.Web.UI.Page
{
       Userinfo user = new Userinfo(); 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            PageIndex = 0;
          
            BindDataList();
        }
        if (Session["CurrentUser"] != null)
        {
           
            user = (Userinfo)Session["CurrentUser"];
            Session["userid"] = user.Id;
        }
        else
        {
            Session["userid"] = Convert.ToInt32(Request.QueryString["ThemeId"]);
        }
     
        //if (Session["CurrentUser"] != null)
        //{
        //    //User user = new User();
        //    user = (Userinfo)Session["CurrentUser"];
        //    Session["userid"] = user.Id;
        //}
        //else
        //{
        //    Session["userid"] = Convert.ToInt32(Request.QueryString["id"]);
        //}

        if (Session["CurrentUser"] != null)
        {
            this.pnLongin.Visible = false;
            this.Label1.Visible = true;
            user = (Userinfo)Session["CurrentUser"];
            this.Label1.Text = user.NickName.ToString() + "欢迎您！";
            this.pnLongin.Visible = true;
        }
    }
    private void BindDataList()
    {
        ThemeManager pManager = new ThemeManager();
        string con = GetCond();
        //实例化分页控件
        PagedDataSource pd = new PagedDataSource();
        pd.AllowPaging = true;//充许分页
        pd.PageSize = 4;//页面的数据项数
      
        pd.DataSource = pManager.GetListByCon(con);//加载数据
        
         dtlist .DataSource = pd;//加载分页数据源
         dtlist.DataBind();
         Page.DataBind();
        SetButtonState(pd);
        
    }

    private void SetButtonState(PagedDataSource pd)
    {
        likup.Enabled = false;
        liknext.Enabled = true;
        //if (pd.IsFirstPage)
        //    likup.Enabled = false;
        //if (pd.IsLastPage)
        //    liknext.Enabled = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Userinfo user;
        Usermanager um = new Usermanager();
        if (um.Login(this.TextBox1.Text, this.TextBox2.Text, out user))
        {
            this.pnLongin.Visible = false;
            Session["CurrentUser"] = user;
            this.Label1 .Text = user.NickName.ToString() + "  欢迎您！";
            this.pnLongin.Visible = true;
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码不正确，请重新填写')</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["CurrentUser"] = null;
        this.pnLongin.Visible = false;

        this.Label1.Visible = false;
        this.pnLongin.Visible = true;
    }

    public string GetCut(string contents, int num)
    {
        return CommonHandler.CutString(contents, num);
    }
    private string GetCond()
    {
        string str = "";

        str += " order by T_PublishTime desc";
        return str;
    }
    protected void likup_Click(object sender, EventArgs e)
    {
        PageIndex--;
        BindDataList();
    }
    protected void liknext_Click(object sender, EventArgs e)
    {
        PageIndex++;
        BindDataList();
    }
    private int PageIndex
    {
        get { return Convert.ToInt32(ViewState["pageindex"]); }
        set { ViewState["pageindex"] = value; }
    }
    protected void dtlist_ItemCommand(object source, DataListCommandEventArgs e)
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