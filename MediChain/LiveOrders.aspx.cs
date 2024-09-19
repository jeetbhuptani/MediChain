using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class LiveOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLiveOrders();
            }
        }

        private void BindLiveOrders()
        {
            // Replace with your data source
            //string query = "SELECT OrderID, PharmacyName, BuyerID, ProductName, Quantity, TotalCost FROM Orders";
           //DataTable dt = GetData(query); // Assume GetData is a method that fetches data from the database.
            //RepeaterLiveOrders.DataSource = dt;
            //RepeaterLiveOrders.DataBind();
        }

        protected void btnUnfit_Click(object sender, EventArgs e)
        {
            // Get the OrderID from CommandArgument and mark as Unfit in the database.
            string orderId = (sender as Button).CommandArgument;
            // Perform database operation here.
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            // Get the OrderID from CommandArgument and mark as Done in the database.
            string orderId = (sender as Button).CommandArgument;
            // Perform database operation here.
        }

    }
}