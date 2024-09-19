using System;
using System.Data.SqlClient;
using System.Data;
namespace MediChain
{
    public partial class WarehousePage : System.Web.UI.Page
    {
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
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT p.name, mw.quantity, p.price, mw.custom_price
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

                string productId = txtProductID.Text.Trim();
                int quantity;
                decimal customPrice;

                if (string.IsNullOrEmpty(productId))
                {
                    lblMessage.Text = "Product ID cannot be empty.";
                    return;
                }

                if (!int.TryParse(txtQuantity.Text.Trim(), out quantity) || quantity <= 0)
                {
                    lblMessage.Text = "Quantity must be a positive integer.";
                    return;
                }

                if (!decimal.TryParse(txtCustomPrice.Text.Trim(), out customPrice) || customPrice <= 0)
                {
                    lblMessage.Text = "Custom price must be a positive decimal.";
                    return;
                }

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Step 1: Find warehouse_id from dealer_id
                    string warehouseQuery = "SELECT warehouse_id FROM Warehouse WHERE dealer_id = @DealerId";

                    int warehouseId;
                    using (SqlCommand warehouseCmd = new SqlCommand(warehouseQuery, conn))
                    {
                        warehouseCmd.Parameters.AddWithValue("@DealerId", dealerId);
                        object result = warehouseCmd.ExecuteScalar();

                        if (result == null)
                        {
                            lblMessage.Text = "No warehouse found for the given dealer.";
                            return;
                        }

                        warehouseId = Convert.ToInt32(result);
                    }

                    // Step 2: Update or insert the product in the MedicineWarehouse table
                    string mergeQuery = @"
                MERGE INTO MedicineWarehouse AS target
                USING (VALUES (@WarehouseId, @ProductID, @Quantity, @CustomPrice)) AS source (warehouse_id, product_id, quantity, custom_price)
                ON target.warehouse_id = source.warehouse_id AND target.product_id = source.product_id
                WHEN MATCHED THEN
                    UPDATE SET quantity = source.quantity, custom_price = source.custom_price
                WHEN NOT MATCHED THEN
                    INSERT (warehouse_id, product_id, quantity, custom_price)
                    VALUES (source.warehouse_id, source.product_id, source.quantity, source.custom_price);";

                    using (SqlCommand mergeCmd = new SqlCommand(mergeQuery, conn))
                    {
                        mergeCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                        mergeCmd.Parameters.AddWithValue("@ProductID", productId);
                        mergeCmd.Parameters.AddWithValue("@Quantity", quantity);
                        mergeCmd.Parameters.AddWithValue("@CustomPrice", customPrice);

                        int rowsAffected = mergeCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "CloseModal", "closeModal();", true);

                            BindWarehouseData(dealerId);
                        }
                        else
                        {
                            lblMessage.Text = "No changes were made to the database.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", "showError();", true);
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Code to handle Delete 
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Code to handle Search 
        }
    }
}
