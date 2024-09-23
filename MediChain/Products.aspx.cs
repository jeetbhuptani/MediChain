using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MediChain
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null)
                {
                    LoadWarehouseData();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
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
            string buyerId = Session["Id"].ToString();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        d.company_name AS Dealer,
                        p.name AS Product,
                        mw.quantity AS Quantity,
                        mw.custom_price AS Pricing
                    FROM 
                        Dealer d
                    JOIN 
                        Warehouse w ON d.id = w.dealer_id
                    JOIN 
                        MedicineWarehouse mw ON w.warehouse_id = mw.warehouse_id
                    JOIN 
                        Product p ON mw.product_id = p.product_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
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