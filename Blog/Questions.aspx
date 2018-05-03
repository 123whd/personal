<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="Questions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 81%;
            height: 47px;
        }
        .style3
        {
            height: 45px;
            width: 554px;
        }
        .style4
        {
            height: 125px;
            width: 554px;
        }
        .style6
        {
            height: 125px;
            width: 97px;
        }
        .style7
        {
            height: 45px;
            width: 97px;
        }
        .style10
        {
            width: 65px;
        }
        .style16
        {
            width: 554px;
        }
        .style17
        {
            width: 97px;
        }
        .style18
        {
            width: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" Width="824px" 
            style="margin-right: 299px">
            <EditItemTemplate>
                <asp:Panel ID="Panel1" runat="server" BackColor="#CCFFFF">
                
                <table class="style1">
                    <tr>
                        <td class="style16" colspan="5">
                            主题<%# Eval("Theme")%><br />作者：<%# Eval("UserName")%>发表时间：<%# Eval("T_PublishTime")%></td>
                        <td class="style17">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            内容<%# Eval("T_Content")%></td>
                        <td class="style6" valign="bottom">
                            点击数：<%# Eval("spot")%><br /> 
                            <asp:Button ID="Button2" runat="server" Text="返回" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            用户名：<%# Eval("UserName")%>发表时间：<%# Eval("T_PublishTime")%><br />发表内容：<%# Eval("T_Content")%></td>
                        <td class="style7">
                        </td>
                    </tr>
                    <tr>
                        <td class="style16">
                            <table class="style1">
                                <tr>
                                    <td class="style18">
                                        用户名：</td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("UserName")%>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style18">
                                        发表时间：</td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("T_PublishTime")%>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="style17">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style16"> 
                            内容：<asp:TextBox ID="TextBox3" runat="server" Height="68px" Width="266px" ></asp:TextBox>
                        </td>
                        <td class="style17">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style16">
                            <asp:Button ID="Button1" runat="server" Text="发表" />
                        </td>
                        <td class="style17">
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
            </EditItemTemplate>
        </asp:FormView>
    
    </form>
</body>
</html>
