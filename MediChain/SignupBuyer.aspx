<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupBuyer.aspx.cs" Inherits="MediChain.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 289px;
        }
        .auto-style2 {
            width: 282px;
        }
        .auto-style3 {
            width: 388px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1 runat="server" style="font-family: Georgia, 'Times New Roman', Times, serif; font-size: large; font-weight: bolder; text-decoration: underline; background-color: #000000; clip: rect(auto, auto, auto, auto); float: none; text-align: center; color: #FFFFFF;">MediChain</h1>
        <div style="text-align:center;background: gray;">
            <asp:Label runat="server">SignUp</asp:Label>
        </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
            <asp:Label runat="server" ID="lblName">Name: </asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox runat="server" ID="tbName"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserName Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblPharmacy" runat="server" Text="Pharmacy Name: "></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbPharmacy" runat="server"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Your Pharmacy Name Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblPrarmacyAddress" runat="server" Text="Pharmacy Address: "></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbPhramcyAddress" runat="server" TextMode="MultiLine" MaxLength="300" Rows="3"></asp:TextBox></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblNumber" runat="server" Text="Label">Mobile Number: </asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbNumber" runat="server" TextMode="Number"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please add your mobile number"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter a valid Mobile Number" MaximumValue="10" MinimumValue="10" SetFocusOnError="True"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblEmail" runat="server" Text="Label">Email: </asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbEmail" runat="server" TextMode="Email"></asp:TextBox></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">   
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="lblConfirmP" runat="server" Text="Confirm Paassword: "></asp:Label>
                    </td>
                    <td class="auto-style3">
            <asp:TextBox ID="tbConfirmP" runat="server"></asp:TextBox></td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
           <asp:Button ID="btnSubmit" runat="server" Text="SignUp" />&nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" PostBackUrl="~/SignupBuyer.aspx" />
    </form>
</body>
</html>
