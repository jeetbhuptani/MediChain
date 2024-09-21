<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiveOrders.aspx.cs" Inherits="MediChain.LiveOrders" %>

<!doctype html>
<html lang="en">
    <head>
        <title>Live Orders</title>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <!-- Bootstrap CSS -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous" />
    </head>
    <body>
        <header>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="Dealer.aspx">MediChain</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="text-end">
                        <div class="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul class="navbar-nav me-auto mb-2 mb-lg-0 text-end">
                                <li class="nav-item">
                                    <a class="nav-link" href="Dealer.aspx">Dashboard</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Warehouse.aspx">Warehouse</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page" href="LiveOrders.aspx">Live Orders</a>
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
            <form runat="server">
                <!-- Table displaying live orders data -->
                <div class="border border-5 m-1 p-1">
                    <table class="table table-hover table-sm">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Pharmacy</th>
                                <th scope="col">Buyer ID</th>
                                <th scope="col">Product</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Total Cost</th>
                                <th scope="col"></th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody class="table-group-divider">
                            <asp:Repeater ID="RepeaterLiveOrders" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                        <td><%# Eval("pharmacy_name") %></td>
                                        <td><%# Eval("buyer_id") %></td>
                                        <td><%# Eval("product_name") %></td>
                                        <td><%# Eval("quantity") %></td>
                                        <td><%# Eval("amount") %></td>
                                        <td>
                                            <asp:Button ID="btnUnfit" runat="server" CssClass="btn btn-danger m-0 p-1" Text="Unfit" OnClick="btnUnfit_Click" CommandArgument='<%# Eval("purchase_id") %>' />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDone" runat="server" CssClass="btn btn-success m-0 p-1" Text="Done" OnClick="btnDone_Click" CommandArgument='<%# Eval("purchase_id") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </form>
        </main>

        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    </body>
</html>
