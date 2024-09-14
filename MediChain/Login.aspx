<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MediChain.Login" %>

<!DOCTYPE html>
<html lang="en">
    <head runat="server">
        <title>MediChain - Login</title>
        <!-- Required meta tags -->
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

        <!-- Bootstrap CSS v5.2.1 -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    </head>

    <body>
        <form id="form1" runat="server" class="container">
            <header>
                <!-- Navbar or any other header content -->
                <p class="h1 text-center bg-primary-subtle text-primary">MediChain</p>
            </header>

            <main class="container">
                <asp:Panel ID="Panel1" runat="server" CssClass="border border-5 border-secondary rounded">
                    <div class="text-end bg-secondary mb-3 pb-3">
                        <p class="h3 text-center pt-1"><b>Login</b></p>
                        <div class="text-end">
                            <asp:Button ID="btnBuyer" runat="server" Text="Buyer" CssClass="btn btn-light me-3" OnClick="btnBuyer_Click" CausesValidation="False" />
                        </div>
                    </div>

                    <!-- Email Field -->
                    <div class="m-3">
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" CssClass="form-label">Email: </asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="example@mail.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" Display="Dynamic" />
                    </div>

                    <!-- Password Field -->
                    <div class="m-3">
                        <asp:Label ID="lblPassword" AssociatedControlID="txtPassword" runat="server" CssClass="form-label">Password: </asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <!-- Login and Reset Buttons -->
                    <div class="text-center mb-3">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btnReset_Click" CausesValidation="False" />
                    </div>
                </asp:Panel>
            </main>

            <footer>
                <!-- Footer content -->
            </footer>
        </form>

        <!-- Bootstrap JavaScript Libraries -->
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js"></script>
    </body>
</html>
