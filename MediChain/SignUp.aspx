<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="MediChain.SignUp" %>

<!DOCTYPE html>
<html lang="en">
    <head runat="server">
        <title>MediChain - SignUp</title>
        <!-- Required meta tags -->
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

        <!-- Bootstrap CSS v5.2.1 -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    </head>

    <body>
        <form id="form1" runat="server" class="container">
            <header>
                <!-- place navbar here -->
                <p class="h1 text-center bg-primary-subtle text-primary">MediChain</p>
            </header>

            <main class="container">
                <asp:Panel ID="Panel1" runat="server" CssClass="border border-5 border-secondary rounded">
                    <div class="text-end bg-secondary mb-3 pb-3">
                        <p class="h3 text-center pt-1"><b>SignUp</b></p>
                        <div class="text-end">
                            <asp:Button ID="btnBuyer" runat="server" Text="Buyer" CssClass="btn btn-light me-3" OnClick="btnBuyer_Click" CausesValidation="False" />
                        </div>
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" CssClass="form-label">Name: </asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="John"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblPharmacyName" AssociatedControlID="txtPharmacyName" runat="server" CssClass="form-label">Pharmacy</asp:Label>
                        <asp:TextBox ID="txtPharmacyName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPharmacyName" runat="server" ControlToValidate="txtPharmacyName" ErrorMessage="Name is required." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <div class="m-3 form-floating">
                        <asp:TextBox ID="txtPharmacyAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblPharmacyAddress" AssociatedControlID="txtPharmacyAddress" runat="server" CssClass="form-label">Pharmacy Address</asp:Label>
                        <asp:RequiredFieldValidator ID="rfvPharmacyAddress" runat="server" ControlToValidate="txtPharmacyAddress" ErrorMessage="Address is required." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblMobileNumber" AssociatedControlID="txtMobileNumber" runat="server" CssClass="form-label">Mobile Number: </asp:Label>
                        <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="10" placeholder="9876543210"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile number is required." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Invalid mobile number." ForeColor="Red" ValidationExpression="^\d{10}$" Display="Dynamic" />
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" CssClass="form-label">Email: </asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="example@mail.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" Display="Dynamic" />
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblPassword" AssociatedControlID="txtPassword" runat="server" CssClass="form-label">Password: </asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <div class="m-3">
                        <asp:Label ID="lblConfirmPassword" AssociatedControlID="txtConfirmPassword" runat="server" CssClass="form-label">Confirm Password: </asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm your password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirming your password is required." ForeColor="Red" Display="Dynamic" />
                        <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic" />
                    </div>

                    <div class="text-center mb-3">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnRegister_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="btnReset_Click" CausesValidation="False" />
                    </div>
                </asp:Panel>
            </main>

            <footer>
                <!-- place footer here -->
            </footer>
        </form>

        <!-- Bootstrap JavaScript Libraries -->
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js"></script>
    </body>
</html>
