<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="MediChain.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 254px;
        }
        .auto-style2 {
            width: 205px;
        }
        .auto-style3 {
            width: 490px;
        }
    </style>
</head>
<body style="width: 1461px; height: 259px">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Category</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSourceCategory" DataTextField="name" DataValueField="name" Height="39px" Width="275px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [ProductCategory]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbName" runat="server" Width="472px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Price</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbPrice" runat="server" ReadOnly="True" TextMode="Number" Width="469px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Description</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="tbDescription" runat="server" Width="466px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
    </form>
</body>
</html>
