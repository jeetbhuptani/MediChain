using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Dealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Example: Fetch user details and set to controls
                lblName.Text = "Jeet Bhuptani"; // Fetch from database
                lblCompanyName.Text = "Apollo Pharmacy"; // Fetch from database
                lblAddress.Text = "A 123, Park Avenue, Sesame Street, India"; // Fetch from database
                lblMobileNo.Text = "9876543210"; // Fetch from database
                lblEmail.Text = "jeet@gmail.com"; // Fetch from database

                // Example: Fetch warehouse and order counts
                lblWarehouseCount.Text = GetWarehouseCount().ToString();
                lblLiveOrdersCount.Text = GetLiveOrdersCount().ToString();
            }
        }

        private int GetWarehouseCount()
        {
            // Example function: Fetch the actual warehouse count from DB
            return 1000; // Replace with DB call
        }

        private int GetLiveOrdersCount()
        {
            // Example function: Fetch the actual live orders count from DB
            return 20; // Replace with DB call
        }
    }
}