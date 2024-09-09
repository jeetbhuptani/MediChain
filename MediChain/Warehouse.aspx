<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="MediChain.Warehouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GVWarehouse" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Product ID">
                        <ItemTemplate>
                <asp:HyperLink ID="hlProductID" runat="server" 
                    NavigateUrl='<%# "ProductDetails.aspx?product_id=" + Eval("product_id") %>'>
                    <%# Eval("product_id") %>
                </asp:HyperLink>
            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Product Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Rate" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="custom_price" HeaderText="Custom Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                </Columns>
                <AlternatingRowStyle BackColor="White" />
                
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
        <p>
            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="List Products" />
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Add Product" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Product" />
        </p>
    </form>
</body>
</html>
