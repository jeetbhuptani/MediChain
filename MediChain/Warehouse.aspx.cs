using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
namespace MediChain
{
    public partial class WarehousePage : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null)
                {
                    string dealerId = Session["Id"].ToString();
                    BindWarehouseData(dealerId);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private void BindWarehouseData(string dealerId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT p.product_id,p.name, mw.quantity, p.price, mw.custom_price
            FROM MedicineWarehouse mw
            INNER JOIN Product p ON mw.product_id = p.product_id
            INNER JOIN Warehouse w ON mw.warehouse_id = w.warehouse_id
            WHERE w.dealer_id = @DealerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DealerID", dealerId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        RepeaterWarehouse.DataSource = dt;
                        RepeaterWarehouse.DataBind();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Id"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                string dealerId = Session["Id"].ToString();
                lblMessage.Text = string.Empty;

                string productIdStr = txtProductID.Text.Trim();
                int productId;
                int quantity;
                decimal customPrice;

                if (string.IsNullOrEmpty(productIdStr))
                {
                    System.Diagnostics.Debug.WriteLine("Product ID cannot be empty.");
                    lblMessage.Text = "Product ID cannot be empty.";
                    return;
                }

                // Check if quantity and custom price are valid
                if (!int.TryParse(txtQuantity.Text.Trim(), out quantity) || quantity <= 0)
                {
                    System.Diagnostics.Debug.WriteLine("Quantity must be a positive integer.");
                    lblMessage.Text = "Quantity must be a positive integer.";
                    return;
                }

                if (!decimal.TryParse(txtCustomPrice.Text.Trim(), out customPrice) || customPrice <= 0)
                {
                    System.Diagnostics.Debug.WriteLine("Custom price must be a positive decimal.");
                    lblMessage.Text = "Custom price must be a positive decimal.";
                    return;
                }
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine("Connection opened.");

                    // Step 1: Find warehouse_id based on dealer_id
                    string warehouseQuery = "SELECT warehouse_id FROM Warehouse WHERE dealer_id = @DealerId";
                    int warehouseId;

                    using (SqlCommand warehouseCmd = new SqlCommand(warehouseQuery, conn))
                    {
                        warehouseCmd.Parameters.AddWithValue("@DealerId", dealerId);
                        object result = warehouseCmd.ExecuteScalar();

                        if (result == null)
                        {
                            System.Diagnostics.Debug.WriteLine("No warehouse found for the given dealer.");
                            lblMessage.Text = "No warehouse found for the given dealer.";
                            return;
                        }

                        warehouseId = Convert.ToInt32(result);
                        System.Diagnostics.Debug.WriteLine($"Found warehouse_id: {warehouseId}");
                    }

                    // Step 2: Check if the product exists in Product table
                    if (!int.TryParse(productIdStr, out productId))
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid Product ID.");
                        lblMessage.Text = "Invalid Product ID.";
                        return;
                    }

                    string productCheckQuery = "SELECT COUNT(*) FROM Product WHERE product_id = @ProductId";
                    int productExists;

                    using (SqlCommand productCheckCmd = new SqlCommand(productCheckQuery, conn))
                    {
                        productCheckCmd.Parameters.AddWithValue("@ProductId", productId);
                        productExists = (int)productCheckCmd.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine($"Product exists: {productExists > 0}");
                    }

                    if (productExists == 0) // If product does not exist
                    {
                        System.Diagnostics.Debug.WriteLine("Product does not exist in the Product table.");
                        lblMessage.Text = "Product does not exist in the Product table.";
                        return;
                    }

                    // Step 3: Check if the product exists in MedicineWarehouse
                    string productCountQuery = "SELECT COUNT(*) FROM MedicineWarehouse WHERE warehouse_id = @WarehouseId AND product_id = @ProductId";
                    int productCount;

                    using (SqlCommand productCountCmd = new SqlCommand(productCountQuery, conn))
                    {
                        productCountCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                        productCountCmd.Parameters.AddWithValue("@ProductId", productId);
                        productCount = (int)productCountCmd.ExecuteScalar();
                    }

                    // Step 4: Update or insert the product
                    if (productCount > 0) // If product exists, perform update
                    {
                        string updateQuery = "UPDATE MedicineWarehouse SET quantity = @Quantity, custom_price = @CustomPrice WHERE warehouse_id = @WarehouseId AND product_id = @ProductId";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                            updateCmd.Parameters.AddWithValue("@ProductId", productId);
                            updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@CustomPrice", customPrice);

                            int rowsAffected = updateCmd.ExecuteNonQuery();
                            lblMessage.Text = rowsAffected > 0 ? "Product updated successfully." : "No changes were made to the product.";
                            System.Diagnostics.Debug.WriteLine($"Rows affected in update: {rowsAffected}");
                        }
                        txtProductID.Text = string.Empty;
                        txtQuantity.Text = string.Empty;
                        txtCustomPrice.Text = string.Empty;
                        lblMessage.Text = string.Empty;
                    }
                    else // If product does not exist, perform insert
                    {
                        string insertQuery = "INSERT INTO MedicineWarehouse (warehouse_id, product_id, quantity, custom_price) VALUES (@WarehouseId, @ProductId, @Quantity, @CustomPrice)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                            insertCmd.Parameters.AddWithValue("@ProductId", productId);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@CustomPrice", customPrice);

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            lblMessage.Text = rowsAffected > 0 ? "Product added successfully." : "Failed to add product.";
                            System.Diagnostics.Debug.WriteLine($"Rows affected in insert: {rowsAffected}");
                        }
                        txtProductID.Text = string.Empty;
                        txtQuantity.Text = string.Empty;
                        txtCustomPrice.Text = string.Empty;
                        lblMessage.Text = string.Empty;
                    }

                    // Refresh the data
                    BindWarehouseData(dealerId);
                    System.Diagnostics.Debug.WriteLine("Warehouse data refreshed.");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", "showError();", true);
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                System.Diagnostics.Debug.WriteLine("Session ID is null, redirecting to LoginPage.");
                Response.Redirect("LoginPage.aspx");
                return;
            }

            string dealerId = Session["Id"].ToString();
            string productName = hiddenProductId.Value;
            System.Diagnostics.Debug.WriteLine("Product Name: " + productName);

            if (string.IsNullOrEmpty(productName))
            {
                System.Diagnostics.Debug.WriteLine("No product selected for deletion.");
                return;
            }

            int warehouseId;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Connection opened.");

                // Step 1: Get warehouse_id
                string queryWarehouse = "SELECT warehouse_id FROM Warehouse WHERE dealer_id = @dealerId";
                using (SqlCommand cmd = new SqlCommand(queryWarehouse, conn))
                {
                    cmd.Parameters.AddWithValue("@dealerId", dealerId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        warehouseId = Convert.ToInt32(result);
                        System.Diagnostics.Debug.WriteLine("Warehouse ID: " + warehouseId);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No warehouse found for dealer: " + dealerId);
                        return;
                    }
                }

                // Step 2: Get product_id from Product table using productName
                int productId;
                string queryProduct = "SELECT product_id FROM Product WHERE name = @productName";
                using (SqlCommand cmd = new SqlCommand(queryProduct, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        productId = Convert.ToInt32(result);
                        System.Diagnostics.Debug.WriteLine("Product ID: " + productId);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Product not found: " + productName);
                        return;
                    }
                }

                string queryDelete = "DELETE FROM MedicineWarehouse WHERE warehouse_id = @warehouseId AND product_id = @productId";
                using (SqlCommand cmd = new SqlCommand(queryDelete, conn))
                {
                    cmd.Parameters.AddWithValue("@warehouseId", warehouseId);
                    cmd.Parameters.AddWithValue("@productId", productId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Product removed successfully. Rows affected: " + rowsAffected);
                        BindWarehouseData(dealerId);
                        ScriptManager.RegisterStartupScript(this, GetType(), "CloseModal", "closeModal();", true);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No product found to remove. Rows affected: " + rowsAffected);
                    }
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Code to handle Search 
        }
    }
}
