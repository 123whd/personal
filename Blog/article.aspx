<%@ Page Language="C#" AutoEventWireup="true" CodeFile="article.aspx.cs" Inherits="article" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

       

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
        <asp:DataList ID="DataList1" runat="server" DataSourceID="objGetTheme">
            <ItemTemplate>
                <%# Eval("Title")%>
                <br />
                作者：
                <%# Eval("UserId")%>发表时间：
                <%# Eval("T_PublishTime", "{0:yyyy-MM-dd}")%>
                <%# Eval("T_Content")%>
                <br />
                <br />
                <br />
                <br />
                <br />
                点击率:
                <%# Eval("Spot")%>|
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="objGetTheme" runat="server" SelectMethod="GetListById"
            TypeName="BLL.ThemeManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="ThemeId" QueryStringField="ThemeId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <h2 class="title">
        <span style="float: right; padding-bottom: 2px; font-size: 12px;"></span>访客评论</h2>
    <asp:DataList ID="dlAllComment" runat="server" Width="610px">
        <ItemTemplate>
            作者：
            <asp:Label ID="ComUsersLabel" runat="server" Text='<%# Eval("Author")%>' />
            &nbsp; 发表时间:
            <asp:Label ID="ComTimeLabel" runat="server" Text='<%# Eval("R_PublishTime", "{0:R}")%>' />
            <br />
            <br />
            评论内容:
            <asp:Label ID="ComTextLabel" runat="server" Text=' <%# Eval("R_Content")%>' />
        </ItemTemplate>
    </asp:DataList>
   <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetModelById"
        TypeName="BLL.ThemeManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="ThemeId" QueryStringField="ThemeId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <h2 class="title">
        发表评论(请不要超过200字)</h2>
    <div class="formbox">
        <table style="position: relative; width: 571px;">
            <tr>
                <td style="width: 70px">
                    昵称：
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCommentName" runat="server" Style="position: relative"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                    评论内容：
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" Columns="95" Rows="8"
                        TabIndex="4" Text="" Width="471px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnPut" runat="server" Text="评论" OnClick="btnPut_Click" />
        <asp:Label ID="lblErrorComment" runat="server" Visible="False" Width="148px"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtComment"
            ErrorMessage="*"></asp:RequiredFieldValidator></div>
    </form>
</body>
</html>
