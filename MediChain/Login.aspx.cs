using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (btnBuyer.Text == "Buyer")
            {
                btnBuyer.Text = "Dealer";
            }
            else
            {
                if (btnBuyer.Text == "Dealer")
                {
                   btnBuyer.Text = "Buyer";               
                }
            }
        }
    }
}