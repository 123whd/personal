using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using BLL;

public partial class Login : System.Web.UI.Page
{ Userinfo info=new Userinfo() ;
    Usermanager um = new Usermanager();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        info.UserId= TextBox1.Text;
        info.NickName = TextBox4.Text;
        info.Pwd=TextBox3.Text;
      
        info.Email=TextBox5.Text;
        info.QQ=TextBox6.Text;
       
        if (!um.Register(info))
        {
            this.Label1.Text = "<script>alert('用户名已使用！请重新选择！')</script>";
        }else
        
            this.Label1.Text = "<script>alert('注册成功！小凡博客欢迎您！');window.location='Default.aspx'</script>";
        


    }
}