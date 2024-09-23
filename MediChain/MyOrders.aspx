<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="MediChain.MyOrders" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>My Orders</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="Buyer.aspx">MediChain</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="text-end">
                        <div class="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul class="navbar-nav me-auto mb-2 mb-lg-0 text-end">
                                <li class="nav-item">
                                    <a class="nav-link" href="Buyer.aspx">Dashboard</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Products.aspx">Products</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page" href="MyOrders.aspx">My Orders</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Logout.aspx">Logout</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <!-- Repeater for displaying Past Orders data -->
            <div class="border border-5 m-1 p-1">
                <asp:Repeater ID="rptOrders" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-sm">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Product</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Dealer</th>
                                    <th scope="col">Total Amount</th>
                                    <th scope="col">Ordered Date</th>
                                    <th scope="col">Order Status</th>
                                </tr>
                            </thead>
                            <tbody class="table-group-divider">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                            <td><%# Eval("Product") %></td>
                            <td><%# Eval("Quantity") %></td>
                            <td><%# Eval("Dealer") %></td>
                            <td><%# String.Format("{0:C}", Eval("TotalAmount")) %></td>
                            <td><%# String.Format("{0:dd-MM-yyyy}", Eval("OrderedDate")) %></td>
                            <td><%# Eval("OrderStatus") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </main>
        <footer>
            <!-- place footer here -->
        </footer>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
