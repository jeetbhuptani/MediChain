<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="MediChain.Warehouse.aspx.cs"
Inherits="MediChain.WarehousePage" %>

<!doctype html>
<html lang="en">
    <head>
        <title>Warehouse</title>
        <meta charset="utf-8" />
        <meta name="viewport"
            content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <!-- Bootstrap CSS -->
        <link
            href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
            rel="stylesheet" crossorigin="anonymous" />
    </head>
    <body>
        <header>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="Dealer.aspx">MediChain</a>
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
                                        href="Dealer.aspx">Dashboard</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link active"
                                        aria-current="page"
                                        href="Warehouse.aspx">Warehouse</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link"
                                        href="LiveOrders.aspx">Live Orders</a>
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
            <form runat="server">
                <div class="p-2 bg-dark">
                    <!-- Regular HTML form elements -->
                    <div class="d-flex" role="search">
                        <asp:textbox runat="server" ID="txtSearch"
                            class="form-control me-2"
                            placeholder="Search Warehouse" />
                        <asp:button ID="btnSearch" runat="server"
                            class="btn btn-outline-warning me-2" type="button"
                            Text="Search"
                            OnClick="btnSearch_Click"></asp:button>
                        <button class="btn btn-outline-success me-1"
                            data-bs-toggle="modal"
                            data-bs-target="#addUpdateModal"
                            type="button">Add</button>
                    </div>
                </div>

                <!-- Table displaying warehouse data -->
                <div class="border border-5 m-1 p-1">
                    <table class="table table-hover table-sm">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Product</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Rate</th>
                                <th scope="col">Custom Price</th>
                                <th scope="col"></th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody class="table-group-divider">
                            <asp:repeater ID="RepeaterWarehouse" runat="server">
                                <itemtemplate>
                                    <tr>
                                        <th scope="row"><%# Container.ItemIndex
                                            + 1 %></th>
                                        <td><%# Eval("name") %></td>
                                        <td><%# Eval("quantity") %></td>
                                        <td><%# Eval("price") %></td>
                                        <td><%# Eval("custom_price") %></td>
                                        <td>
                                            <button
                                                class="btn btn-primary m-0 p-1"
                                                data-bs-toggle="modal"
                                                data-bs-target="#addUpdateModal"
                                                type="button">Update</button>
                                        </td>
                                        <td>
                                            <button
                                                class="btn btn-danger m-0 p-1"
                                                data-bs-toggle="modal"
                                                data-bs-target="#deleteModal"
                                                data-product-name='<%# Eval("product_name") %>'
                                                type="button"
                                                onclick="setDeleteModal(this)">Remove</button>
                                        </td>
                                    </tr>
                                </itemtemplate>
                            </asp:repeater>
                        </tbody>
                    </table>
                </div>

                <!-- Modal for Add/Update -->

                <div class="modal fade" id="addUpdateModal" tabindex="-1"
                    aria-labelledby="addUpdateModalLabel" aria-hidden="true">
                    <div class="modal-dialog">

                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"
                                    id="addUpdateModalLabel">Modify Product</h5>
                                <button type="button" class="btn-close"
                                    data-bs-dismiss="modal"
                                    aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <asp:scriptmanager ID="ScriptManager1"
                                    runat="server"></asp:scriptmanager>
                                <asp:updatepanel ID="UpdatePanel1"
                                    runat="server">
                                    <contenttemplate>
                                        <div class="mb-3">
                                            <asp:label runat="server"
                                                Text="Product ID:"
                                                AssociatedControlID="txtProductID"
                                                CssClass="col-form-label" />
                                            <asp:textbox ID="txtProductID"
                                                runat="server"
                                                CssClass="form-control"></asp:textbox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:label runat="server"
                                                Text="Quantity:"
                                                AssociatedControlID="txtQuantity"
                                                CssClass="col-form-label" />
                                            <asp:textbox ID="txtQuantity"
                                                runat="server"
                                                CssClass="form-control"></asp:textbox>
                                        </div>
                                        <div class="mb-3">
                                            <asp:label runat="server"
                                                Text="Custom Price:"
                                                AssociatedControlID="txtCustomPrice"
                                                CssClass="col-form-label" />
                                            <asp:textbox ID="txtCustomPrice"
                                                runat="server"
                                                CssClass="form-control"></asp:textbox>
                                        </div>
                                        <div class="container">
                                            <asp:label ID="lblMessage"
                                                runat="server"
                                                CssClass="text-danger"></asp:label>
                                        </div>
                                    </contenttemplate>
                                </asp:updatepanel>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary"
                                    data-bs-dismiss="modal">Close</button>
                                <asp:button ID="btnSubmit" runat="server"
                                    CssClass="btn btn-primary" Text="Save"
                                    OnClick="btnSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>

                <!-- Modal for Delete Confirmation -->
                <div class="modal fade" id="deleteModal" tabindex="-1"
                    aria-labelledby="deleteModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title"
                                    id="deleteModalLabel">Remove Product</h5>
                                <button type="button" class="btn-close"
                                    data-bs-dismiss="modal"
                                    aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                Are you sure you want to remove this product?
                                <asp:hiddenfield ID="hiddenProductId"
                                    runat="server" />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary"
                                    data-bs-dismiss="modal">Close</button>
                                <asp:button ID="btnDelete" runat="server"
                                    CssClass="btn btn-danger" Text="Remove"
                                    OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </main>

        <!-- Bootstrap JS -->
        <script
            src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
            crossorigin="anonymous">
            function closeModal() {
                var myModal = new bootstrap.Modal(document.getElementById('addUpdateModal'));
                myModal.hide();
            }
            function showError() {
                var myModal = new bootstrap.Modal(document.getElementById('addUpdateModal'));
                myModal.show();
            }
            function setDeleteModal(button) {
                var productName = button.getAttribute('data-product-name');
                document.getElementById('<%= hiddenProductId.ClientID %>').value = productName;
                document.getElementById('deleteModalLabel').textContent = 'Remove ' + productName;
                var deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
                deleteModal.show();
            }
        </script>
    </body>
</html>
