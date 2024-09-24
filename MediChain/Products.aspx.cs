using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Products : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
            string buyerId = Session["Id"].ToString();

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

        

        protected void btnBuy_Command(object sender, CommandEventArgs e)
        {
            string comm = hiddenProductId.Value;
            string[] commandArgs = comm.Split(',');
            string product = commandArgs[0];  // ProductID
            string dealer = commandArgs[1];   // DealerID
            decimal pricing = Convert.ToDecimal(commandArgs[2]); // Pricing
            int quantity = Convert.ToInt32(commandArgs[3]); // Inputted Quantity
            string buyerId = Session["Id"].ToString();

            // Save the purchase details
            SavePurchase(buyerId, dealer, product, pricing, quantity);
        }

        private void SavePurchase(string buyerId, string dealer, string product, decimal pricing, int quantity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Retrieve dealer ID
                    int dealerId;
                    object temp;
                    string q1 = "SELECT id FROM Dealer WHERE company_name = @DealerName";
                    using (SqlCommand cmd = new SqlCommand(q1, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DealerName", dealer);
                        temp = cmd.ExecuteScalar();

                        if (temp == null || temp == DBNull.Value)
                        {
                            throw new Exception("Dealer not found");
                        }
                        dealerId = Convert.ToInt32(temp);
                    }

                    // Retrieve product ID
                    int productId;
                    string q2 = "SELECT product_id FROM Product WHERE name = @ProductName";
                    using (SqlCommand cmd = new SqlCommand(q2, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", product);
                        temp = cmd.ExecuteScalar();

                        if (temp == null || temp == DBNull.Value)
                        {
                            throw new Exception("Product not found");
                        }
                        productId = Convert.ToInt32(temp);
                    }

                    // Calculate the amount
                    decimal amount = pricing * quantity;
                    DateTime orderDate = DateTime.Now;

                    // Insert purchase order
                    string query = @"
                        INSERT INTO PurchaseOrder (dealer_id, buyer_id, amount, product_id, quantity, date, status)
                        VALUES (@DealerId, @BuyerId, @Amount, @ProductId, @Quantity, @OrderDate, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DealerId", dealerId);
                        cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                        cmd.Parameters.AddWithValue("@Status", "pending");

                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Purchase Placed";
                        
                    }

                    transaction.Commit(); // Commit the transaction if all commands succeed
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback if any error occurs
                    // Log or re-throw the exception as necessary
                    throw ex;
                }
            }
        }

        private int GetDealerId(string dealerName)
        {
            string query = "SELECT id FROM Dealer WHERE owner_name = @DealerName";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DealerName", dealerName);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Dealer not found");
                    }

                    return Convert.ToInt32(result);
                }
            }
        }

        private int GetProductId(string productName)
        {
            string query = "SELECT product_id FROM Product WHERE name = @ProductName";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Product not found");
                    }

                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
