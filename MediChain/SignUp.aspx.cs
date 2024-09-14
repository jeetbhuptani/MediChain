using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MediChain
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Add logic for registration process
            if (Page.IsValid)
            {
                // Example: Save user details to database
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            txtName.Text = string.Empty;
            txtPharmacyName.Text = string.Empty;
            txtPharmacyAddress.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (btnBuyer.Text == "Buyer")
            {
                btnBuyer.Text = "Dealer";
                lblPharmacyName.Text = "Company";
                lblPharmacyAddress.Text = "Company Address";
            }
            else
            {
                if (btnBuyer.Text == "Dealer")
                {
                    btnBuyer.Text = "Buyer";
                    lblPharmacyName.Text = "Pharmacy";
                    lblPharmacyAddress.Text = "Pharmacy Address";
                }
            }
        }
    }
}