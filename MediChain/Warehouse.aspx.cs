using System;

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
            // Code to handle Add/Update product
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
