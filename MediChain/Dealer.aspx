<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dealer.aspx.cs" Inherits="MediChain.Dealer" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Dealer DashBoard</title>
        <!-- Required meta tags -->
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

        <!-- Bootstrap CSS v5.2.1 -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    </head>

    <body>
        <header>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="Dealer.aspx">MediChain</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="text-end">
                    <div class="collapse navbar-collapse text-end" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="Dealer.aspx">Dashboard</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Warehouse.aspx">Warehouse</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="LiveOrders.aspx">Live Orders</a>
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
            <!-- User Details Section -->
            <div class="border border-5 border-success-subtle m-2 p-3">
                <h4 class="text-center">User Details</h4>
                <p class="p-2">Name: <asp:Label ID="lblName" runat="server" Text="Jeet Bhuptani"></asp:Label></p>
                <p class="p-2">Company Name: <asp:Label ID="lblCompanyName" runat="server" Text="Apollo Pharmacy"></asp:Label></p>
                <p class="p-2">Address: <asp:Label ID="lblAddress" runat="server" Text="A 123, Park Avenue, Sesame Street, India"></asp:Label></p>
                <p class="p-2">Mobile No: <asp:Label ID="lblMobileNo" runat="server" Text="9876543210"></asp:Label></p>
                <p class="p-2">Email: <asp:Label ID="lblEmail" runat="server" Text="jeet@gmail.com"></asp:Label></p>
            </div>

            <!-- Quick Links Section -->
            <div class="border border-5 border-info-subtle m-2 p-3 text-center">
                <h4>Quick Links</h4>
                <div class="row">
                    <!-- WareHouse Link -->
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">WareHouse</h5>
                                <p class="card-text">WareHouse Items Count: <asp:Label ID="lblWarehouseCount" runat="server" Text="1000"></asp:Label></p>
                                <a href="Warehouse.aspx" class="btn btn-primary">Go</a>
                            </div>
                        </div>
                    </div>
                    
                    <!-- Live Orders Link -->
                    <div class="col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Live Orders</h5>
                                <p class="card-text">Live Orders Count: <asp:Label ID="lblLiveOrdersCount" runat="server" Text="20"></asp:Label></p>
                                <a href="LiveOrders.aspx" class="btn btn-primary">Go</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <footer>
            <!-- Footer content can go here -->
        </footer>

        <!-- Bootstrap JavaScript Libraries -->
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js"></script>
    </body>
</html>
