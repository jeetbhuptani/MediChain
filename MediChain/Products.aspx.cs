using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadWarehouseData();
            }
        }

        protected void LoadWarehouseData(string searchTerm = "")
        {
            // Replace with your actual database connection string
            //string connectionString = "YourConnectionStringHere";
            //string query = "SELECT Dealer, Product, Pricing FROM Warehouse";

            //if (!string.IsNullOrEmpty(searchTerm))
            //{
                //query += " WHERE Product LIKE @SearchTerm OR Dealer LIKE @SearchTerm";
            //}

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
                //SqlCommand cmd = new SqlCommand(query, con);

                //if (!string.IsNullOrEmpty(searchTerm))
                //{
                    //cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                //}

                //con.Open();
                //rptProducts.DataSource = cmd.ExecuteReader();
                //rptProducts.DataBind();
                //con.Close();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string searchTerm = txtSearch.Text.Trim();
            //LoadWarehouseData(searchTerm);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            // Implement the logic to handle the Buy operation here.
            // You can use ViewState or Session to get the selected product information.
            // For example, you could store the product ID in a hidden field in the repeater,
            // and then access it here to complete the purchase.
        }
    }
}