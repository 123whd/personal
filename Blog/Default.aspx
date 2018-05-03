<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 784px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:DataList ID="dtlist" runat="server" DataKeyField="Id" Width="639px" 
                        onitemcommand="dtlist_ItemCommand">
                        <ItemTemplate>
                            <h2 class="posttitle">
                                <%--<asp:HyperLink ID="HyperLink2" runat="server" Text=' <%# Eval("Title")%>' NavigateUrl='<%# Eval("ThemeId","~/article.aspx?ThemeId={0}") %>'></asp:HyperLink>--%>
                               
                                  
                                <asp:LinkButton ID="LinkButton3" runat="server"  CommandName="Reader" CommandArgument='<%# Eval("ThemeId") %>'><%# Eval("Title")%></asp:LinkButton>
                            </h2>
                          
                            <p >
                            作者： <%# Eval("UserId")%>   发表时间： <%# Eval("T_PublishTime", "{0:yyyy-MM-dd}")%>
                            </p>
                            <div class="content">
                                <p>
                                    <%# GetCut(Eval("T_Content").ToString(), 30)%>
                                </p>
                                <p>
                                    »<asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Reader" CommandArgument='<%# Eval("ThemeId") %>'>阅读全文</asp:LinkButton>
                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" CommandName="Reader"    NavigateUrl ='<%# Eval("ThemeId","~/article.aspx?ThemeId={0}") %>' CommandArgument='<%# Eval("ThemeId","~/article.aspx?ThemeId={0}") %>'>阅读全文</asp:HyperLink>--%>
                                </p>
                                <%--<a href='article.aspx?aid=<%# Eval("ThemeId") %>'>阅读全文</a>--%>
                            </div>
                            <p class="postmetadata">
                                &nbsp; 点击率:
                                <%# Eval("Spot")%>|
                                | 
                                <%--<asp:HyperLink ID="HyperLink3" runat="server" Text="评论" NavigateUrl='<%# Eval("ThemeId","article.aspx?ThemeId=<%#CommonHandler.GetCommentNumber(int.Parse(Eval("ThemeId").ToString()"))) )%>'></asp:HyperLink>--%>


                                <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="Reader" CommandArgument='<%# Eval("ThemeId") %>'>评论</asp:LinkButton>
                                             <asp:Label ID="Label3" runat="server" Style="position: relative" Text='<%# CommonHandler.GetCommentNumber( int.Parse(Eval("ThemeId").ToString())) %>'> </asp:Label>
                                </p>
                         
                                <%--<asp:Label ID="lblMessage" runat="server" Style="position: relative" Text='<%# CommonHandler.GetCommentNumber( int.Parse(Eval("ThemeId").ToString())) %>'>
                        --%></ItemTemplate>
                    </asp:DataList>
                 
                </td>
                <td valign="top">
                    友情链接<br />
                    &nbsp;&nbsp; --&gt;新浪网<br />
                    &nbsp;&nbsp; --&gt;百度<br />
                    <br />
                    我的地盘<br />
                    &nbsp;&nbsp;&nbsp;<br />
                    <table class="style9">
                        <tr>
                            <td colspan="2">
                                用户登录|login
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                用户名：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" valign="baseline">
                                <asp:Button ID="Button3" runat="server" Text="登录" OnClick="Button3_Click" />
                                <asp:Button ID="Button2" runat="server" Text="注册" PostBackUrl="~/Register.aspx" />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnLongin" runat="server" Visible="False">
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                        <br />
                        &nbsp;&nbsp; --&gt;<a href="Answers.aspx">发表文章</a><br />
                        &nbsp;&nbsp; --&gt;<a href="ManagerList.aspx">文章管理</a><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="退出" />
                    </asp:Panel>
                    &nbsp;<br />
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="likup" runat="server" OnClick="likup_Click" Text="上一页" />
                    <asp:Button ID="liknext" runat="server" OnClick="liknext_Click" Text="下一页" />
                </td>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
