<%@ Page Language="C#" Debug="true"  AutoEventWireup="true" CodeFile="Theme.aspx.cs" Inherits="Theme" %>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 

  
 
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 544px;
        }
        .style2
        {
            width: 75%;
            height: 152px;
        }
        .style3
        {
            width: 20%;
            height: 152px;
        }
        .style4
        {
            height: 200px;
        }
        .style5
        {
            height: 65px;
        }
        .style6
        {
            height: 124px;
        }
        .style7
        {
            width: 100%;
            height: 70px;
        }
        .style8
        {
            height: 17px;
        }
        .style9
        {
            width: 100%;
            height: 98px;
        }
        .style10
        {
            width: 97px;
        }
    </style>
 

  
 
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:DataList ID="DataList1" runat="server" Width="817px" Height="546px" 
                        DataKeyField="ThemeId" onitemcommand="DataList1_ItemCommand" 
                        >
                        <ItemTemplate>
                           <%# Eval("Title")%><br />
                            作者：<%# Eval("UserName")%>发表时间：<%# Eval("T_PublishTime")%><br /><br /><%# Eval("T_Content")%><br /><asp:LinkButton ID="LinkButton3" runat="server"  CommandName="Reader" CommandArgument='<%# Eval("ThemeId") %>'>阅读全文。。</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            &nbsp;&nbsp;&nbsp; 点击次数：<%# Eval("spot")%>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td class="style3" valign="top">
                  
                    <table class="style1">
                        <tr>
                            <td class="style4" valign="top">
                    <asp:DataList ID="DataList2" runat="server" Width="240px" 
                        DataSourceID="ObjectDataSource1" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="151px">
                     <ItemTemplate>      
                     <%# Eval("Title")%>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     <%# Eval("spot")%>
                         
                     </ItemTemplate>
                        <AlternatingItemStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <HeaderTemplate>
                            热门文章
                        </HeaderTemplate>
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    </asp:DataList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                    SelectMethod="GetModelById" TypeName="BLL.ThemeManager">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" valign="top">
                    <asp:DataList ID="DataList3" runat="server" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="145px" 
                                    style="margin-top: 0px" Width="237px" DataSourceID="objUser">
                        <AlternatingItemStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <HeaderTemplate>
                            用户列表
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("UserName")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("Counts")%>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    </asp:DataList>
                                <asp:ObjectDataSource ID="objUser" runat="server" SelectMethod="GetUsers" 
                                    TypeName="BLL.ThemeManager"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" valign="top">
                                <table class="style7">
                                    <tr>
                                        <td class="style8">
                                            友情链接</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;&nbsp; --&gt;新浪网&nbsp;<br />
&nbsp;&nbsp; --&gt;百度</td>
                                    </tr>
                                   
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style9">
                                    <tr>
                                        <td colspan="2">
                                            用户登录|login</td>
                                    </tr>
                                    <tr>
                                        <td class="style10">
                                            用户名：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style10">
                                            密码：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" valign="baseline">
                                            <asp:Button ID="Button1" runat="server" Text="登录" onclick="Button1_Click" />
                                            <asp:Button ID="Button2" runat="server" Text="注册" 
                                                PostBackUrl="~/Register.aspx" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    
    </div>
   
    </form>
</body>
</html>
