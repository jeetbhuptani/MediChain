using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
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
                if (Session["Id"] != null)
                {
                    string buyerId = Session["Id"].ToString();
                    LoadPurchaseHistory(buyerId);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void LoadPurchaseHistory(string buyerId)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                        SELECT 
                            p.product_id,
                            p.amount,
                            p.quantity,
                            p.date,
                            pr.name AS ProductName
                        FROM PurchaseOrder p
                        INNER JOIN Product pr ON p.product_id = pr.product_id
                        WHERE p.buyer_id = @BuyerID
                        ORDER BY p.date DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", buyerId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dt.Columns.Add("PurchaseDescription", typeof(string));

                        // case of no purchase history
                        if (dt.Rows.Count == 0) {
                            return;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string description = $"Product: {row["ProductName"]}, " +
                                                 $"Quantity: {row["quantity"]}, " +
                                                 $"Amount: {row["amount"]}, " +
                                                 $"Date: {Convert.ToDateTime(row["date"]).ToString("yyyy-MM-dd")}";
                            row["PurchaseDescription"] = description;
                        }

                        // Bind the DataTable to the Repeater
                        rptPurchaseHistory.DataSource = dt;
                        rptPurchaseHistory.DataBind();
                    }
                }
            }
        }
    }
}