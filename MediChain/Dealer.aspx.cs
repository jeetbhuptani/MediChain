using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MediChain
{
    public partial class Dealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                string dealerId = Session["Id"].ToString();
                FetchDealerDetails(dealerId);
                lblWarehouseCount.Text = GetWarehouseCount(dealerId).ToString();
                lblLiveOrdersCount.Text = GetLiveOrdersCount(dealerId).ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void FetchDealerDetails(string dealerId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "SELECT owner_name, company_name, company_address, mobile_no, email, joiningDate FROM Dealer WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", dealerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblName.Text = reader["owner_name"].ToString();
                                lblCompanyName.Text = reader["company_name"].ToString();
                                lblAddress.Text = reader["company_address"].ToString();
                                lblMobileNo.Text = reader["mobile_no"].ToString();
                                lblEmail.Text = reader["email"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An error occurred while fetching dealer details ')", true);
                    Console.Write(ex);
                }
            }
        }


        private int GetWarehouseCount(string dealerId)
        {
            int productCount = 0;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Get warehouse_id from dealer_id
                string warehouseQuery = "SELECT warehouse_id FROM Warehouse WHERE dealer_id = @DealerId";
                int warehouseId;
                using (SqlCommand warehouseCmd = new SqlCommand(warehouseQuery, con))
                {
                    warehouseCmd.Parameters.AddWithValue("@DealerId", dealerId);
                    object result = warehouseCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out warehouseId))
                    {
                        // Get count of product_id from MedicineWarehouse using warehouse_id
                        string countQuery = "SELECT COUNT(product_id) AS ProductCount FROM MedicineWarehouse WHERE warehouse_id = @WarehouseId";
                        using (SqlCommand countCmd = new SqlCommand(countQuery, con))
                        {
                            countCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                            object countResult = countCmd.ExecuteScalar();
                            if (countResult != null)
                            {
                                int.TryParse(countResult.ToString(), out productCount);
                            }
                        }
                    }
                }
            }

            return productCount;
        }

        private int GetLiveOrdersCount(string dealerId)
        {
            int purchaseCount = 0;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT COUNT(purchase_id) AS PurchaseCount FROM PurchaseOrder WHERE dealer_id = @DealerId and status='pending'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DealerId", dealerId);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out purchaseCount);
                    }
                }
            }

            return purchaseCount;
        }
    }
}