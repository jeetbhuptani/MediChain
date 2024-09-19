using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Buyer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPurchaseHistory();
            }
        }

        protected void LoadPurchaseHistory()
        {
            // Replace with your actual database connection string
            //string connectionString = "YourConnectionStringHere";

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
                //SqlCommand cmd = new SqlCommand("SELECT PurchaseDescription FROM PurchaseHistory WHERE BuyerID = @BuyerID", con);
                // Replace with actual BuyerID
                //cmd.Parameters.AddWithValue("@BuyerID", "SomeBuyerID");

                //con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                //rptPurchaseHistory.DataSource = reader;
                //rptPurchaseHistory.DataBind();
                //con.Close();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Redirect to Products.aspx with search query string
                //Response.Redirect($"Products.aspx?search={searchTerm}");
            }
        }
    }
}