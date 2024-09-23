<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buyer.aspx.cs" Inherits="MediChain.Buyer" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Buyer Dashboard</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS v5.2.1 -->
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
                                    <a class="nav-link active" aria-current="page" href="Buyer.aspx">Dashboard</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Products.aspx">Products</a>
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
        <main class="m-5" style="
            background: rgba(255, 255, 255, 0.9); /* Semi-transparent background color */
            background-image: url('logo.jpg'); 
            background-repeat: no-repeat; 
            background-position: center; 
            background-size: 100px; /* Adjust the size of the logo as needed */
            height: 80vh; /* Adjust as per requirement */
            display: flex; 
            align-items: center; 
            justify-content: center;
        ">
            <div class="container border border-5 py-3 position-relative top-0 left-50" style="width: 80%;">                
                <!-- Purchase History -->
                <div class="d-flex flex-column border border-2 border-dark p-1 m-1">
                    <p class="h5 text-center"><u>Purchase History</u></p>
                    <asp:Repeater ID="rptPurchaseHistory" runat="server">
                        <HeaderTemplate>
                            <ul class="list-group">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li class="list-group-item bg-transparent border border-1 mb-1 p-3">
                                <%# Eval("PurchaseDescription") %> <!-- Adjust according to your data field -->
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </main>
        
        <!-- Footer -->
        <footer>
            <!-- Place footer here -->
        </footer>
    </form>

    <!-- Bootstrap JavaScript Libraries -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" crossorigin="anonymous"></script>
</body>
</html>
