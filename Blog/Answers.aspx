<%@ Page Language="C#" ValidateRequest="false" Debug="true" AutoEventWireup="true"  CodeFile="Answers.aspx.cs" Inherits="Answers" %>
   

<httpruntime requestvalidationmode="2.0" />
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="fckeditor/fckconfig.js" type="text/javascript"></script>
<script src="fckeditor/fckconfig.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            color: #003300;
            font-weight: 700;
        }
        #Text1
        {
            width: 468px;
        }
        #Text4
        {
            height: 222px;
            width: 475px;
            margin-right: 0px;
        }
        .style2
        {
            height: 27px;
        }
        .style3
        {
            width: 95px;
        }
        .style4
        {
            height: 27px;
            width: 95px;
        }
    </style>
</head>
<body style="color: #003300">
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:Panel ID="Panel1" runat="server" BackColor="#CCFFCC" Height="100%" Style="color: #CCCCFF;
        margin-top: 0px; margin-bottom: 54px" Width="100%">
        <table class="style1">
            <tr>
                <td class="style3">
                    文章标题：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="476px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    发表时间：
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="168px" Text='<%# Eval("T_PublishTime")%>'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    文章作者：
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="168px" Text='<%# Eval("UserName")%>'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    文章内容：
                </td>
                <td>
                    <FTB:FreeTextBox ID="FreeTextBox1" runat="server">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="发表" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="重置" OnClick="Button4_Click" />
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
