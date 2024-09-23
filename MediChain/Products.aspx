<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MediChain.Products" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Products</title>
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
                                    <a class="nav-link active" aria-current="page" href="Products.aspx">Products</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="MyOrders.aspx">My Orders</a>
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
            <div class="p-2 bg-dark">
                <!-- Search bar using ASP.NET TextBox and Button -->
                <div class="d-flex" role="search">
                    <asp:TextBox ID="txtSearch" CssClass="form-control me-2" runat="server" placeholder="Search Products"></asp:TextBox>
                    <asp:Button ID="btnSearch" CssClass="btn btn-outline-warning me-2" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
                </div>
            </div>

            <!-- Repeater to display warehouse data -->
            <div class="border border-5 m-1 p-1">
                <asp:Repeater ID="rptProducts" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-sm">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Dealer</th>
                                    <th scope="col">Product</th>
                                    <th scope="col">Pricing</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody class="table-group-divider">
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                            <td><%# Eval("Dealer") %></td>
                            <td><%# Eval("Product") %></td>
                            <td><%# String.Format("{0:C}", Eval("Pricing")) %></td>
                            <td style="width: 10%;">
                                <input type="number" class="form-control" min="0" value="0" />
                            </td>
                            <td style="width: 10%;">
                                <button class="btn btn-primary m-0 p-1 px-5" data-bs-toggle="modal" data-bs-target="#buyModal" type="button">Buy</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <!-- Modal for Buy Confirmation -->
            <div class="modal fade" id="buyModal" tabindex="-1" aria-labelledby="buyModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="buyModalLabel">Buy Product</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Are you sure you want to buy this product?
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <!-- ASP.NET Button in Modal for Buy -->
                            <asp:Button ID="btnBuy" CssClass="btn btn-danger" runat="server" Text="Buy" OnClick="btnBuy_Click" CausesValidation="False" />
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    </form>
</body>
</html>
