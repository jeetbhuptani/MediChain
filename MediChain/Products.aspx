<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs"
Inherits="MediChain.Products" %>
<!DOCTYPE html>
<html lang="en">
    <head runat="server">
        <title>Products</title>
        <meta charset="utf-8" />
        <meta name="viewport"
            content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <!-- Bootstrap CSS -->
        <link
            href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
            rel="stylesheet" crossorigin="anonymous" />
    </head>
    <body>
        <form id="form1" runat="server">
            <header>
                <nav class="navbar navbar-expand-lg bg-body-tertiary">
                    <div class="container-fluid">
                        <a class="navbar-brand" href="Buyer.aspx">MediChain</a>
                        <button class="navbar-toggler" type="button"
                            data-bs-toggle="collapse"
                            data-bs-target="#navbarSupportedContent">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="text-end">
                            <div class="collapse navbar-collapse"
                                id="navbarSupportedContent">
                                <ul
                                    class="navbar-nav me-auto mb-2 mb-lg-0 text-end">
                                    <li class="nav-item">
                                        <a class="nav-link"
                                            href="Buyer.aspx">Dashboard</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active"
                                            aria-current="page"
                                            href="Products.aspx">Products</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link"
                                            href="MyOrders.aspx">My Orders</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link"
                                            href="Logout.aspx">Logout</a>
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
                        <asp:textbox ID="txtSearch" CssClass="form-control me-2"
                            runat="server"
                            placeholder="Search Products"></asp:textbox>
                        <asp:button ID="btnSearch"
                            CssClass="btn btn-outline-warning me-2"
                            runat="server" Text="Search"
                            OnClick="btnSearch_Click"
                            CausesValidation="False" />
                    </div>
                </div>

                <!-- Repeater to display warehouse data -->
                <div class="border border-5 m-1 p-1">
                    <asp:repeater ID="rptProducts" runat="server">
                        <headertemplate>
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
                                </headertemplate>

                                <itemtemplate>
                                    <tr>
                                        <th scope="row"><%# Container.ItemIndex
                                            + 1 %></th>
                                        <td><%# Eval("Dealer") %></td>
                                        <td><%# Eval("Product") %></td>
                                        <td><%# String.Format("{0:C}",
                                            Eval("Pricing")) %></td>
                                        <td style="width: 10%;">
                                            <asp:textbox ID="txtQuantity"
                                                runat="server"
                                                CssClass="form-control"
                                                Min="0" Value="0"
                                                Max='<%# Eval("Quantity") %>'
                                                OnInput="this.value = Math.min(this.value, this.max);"></asp:textbox>
                                        </td>
                                        <td style="width: 10%;">
                                            <button type="button"
                                                class="btn btn-primary m-0 p-1 px-5"
                                                data-command-argument='<%# Eval("ProductID") + "," + Eval("DealerID") + "," + Eval("Pricing") %>'
                                                onclick="updateCommandArgument(this)">
                                                Buy
                                            </button>
                                        </td>
                                    </tr>
                                </itemtemplate>

                                <footertemplate>
                                </tbody>
                            </table>
                        </footertemplate>
                    </asp:repeater>
                </div>

                <!-- Modal for Buy Confirmation -->
                <div class="modal fade" id="buyModal" tabindex="-1"
                    aria-labelledby="buyModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="buyModalLabel">Buy
                                    Product</h5>
                                <button type="button" class="btn-close"
                                    data-bs-dismiss="modal"
                                    aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                Are you sure you want to buy this product?
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary"
                                    data-bs-dismiss="modal">Close</button>
                                <!-- ASP.NET Button in Modal for Buy -->
                                <asp:button ID="btnBuyModal"
                                    CssClass="btn btn-danger" runat="server"
                                    Text="Buy" OnCommand="btnBuy_Command"
                                    CausesValidation="False" />

                            </div>
                        </div>
                    </div>
                </div>
            </main>
            <script>
                function updateCommandArgument(button) {
                    function updateCommandArgument(button) {
                        var row = button.closest('tr');
                        var quantityInput = row.querySelector("[id$=txtQuantity]");
                
                        if (quantityInput) {
                            var quantity = quantityInput.value;
                            var commandArgument = button.getAttribute('data-command-argument');
                            button.setAttribute('data-command-argument', commandArgument + ',' + quantity);

                            // Update modal button's CommandArgument
                            var modalButton = document.getElementById('<%= btnBuyModal.ClientID %>');
                            modalButton.setAttribute('data-command-argument', commandArgument + ',' + quantity);

                            // Show the modal
                            var modal = new bootstrap.Modal(document.getElementById('buyModal'));
                            modal.show();
                        }
                    }
                }
            </script>
            <!-- Bootstrap JS -->
            <script
                src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
                crossorigin="anonymous"></script>

        </form>
    </body>
</html>
