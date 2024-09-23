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
            // Get the button that was clicked
            Button btnBuy = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnBuy.NamingContainer;

            // Retrieve product information from the repeater
            string dealer = ((Label)item.FindControl("lblDealer")).Text;
            string product = ((Label)item.FindControl("lblProduct")).Text;
            decimal pricing = Convert.ToDecimal(((Label)item.FindControl("lblPricing")).Text);
            int quantity = Convert.ToInt32(((TextBox)item.FindControl("txtQuantity")).Text);

            string buyerId = Session["Id"].ToString();

            SavePurchase(buyerId, dealer, product, pricing, quantity);

        }

        private void SavePurchase(string buyerId, string dealer, string product, decimal pricing, int quantity)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Get the dealer ID and product ID based on the dealer and product names
                int dealerId = GetDealerId(dealer, con);
                int productId = GetProductId(product, con);


                // Calculate the amount
                decimal amount = pricing * quantity;
                DateTime orderDate = DateTime.Now;


                string query = @"
           INSERT INTO PurchaseOrder (dealer_id, buyer_id, amount, product_id, quantity, date, status)
           VALUES (@DealerId, @BuyerId, @Amount, @ProductId, @Quantity, @OrderDate, @Status)";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DealerId", dealerId);
                    cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@Status", "pending");


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private int GetDealerId(string dealerName, SqlConnection con)
        {
            string query = "SELECT id FROM Dealer WHERE owner_name = @DealerName";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@DealerName", dealerName);
                return (int)cmd.ExecuteScalar();
            }
        }


        private int GetProductId(string productName, SqlConnection con)
        {
            string query = "SELECT product_id FROM Product WHERE name = @ProductName";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);
                return (int)cmd.ExecuteScalar();
            }
        }

    }
}