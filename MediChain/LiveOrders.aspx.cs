using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class LiveOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null)
                {
                    string dealerId = Session["Id"].ToString();
                    BindLiveOrders(dealerId);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private void BindLiveOrders(string dealerId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = @"
                SELECT 
                    po.purchase_id, 
                    b.email, 
                    b.pharmacy_name, 
                    p.name AS product_name, 
                    po.quantity, 
                    po.amount 
                FROM 
                    PurchaseOrder po
                JOIN 
                    Buyer b ON po.buyer_id = b.id
                JOIN 
                    Product p ON po.product_id = p.product_id
                WHERE 
                    po.dealer_id = @dealerId 
                    AND po.status = 'pending';";  // Fetch only pending orders
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dealerId", dealerId);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        

                        RepeaterLiveOrders.DataSource = dt;
                        RepeaterLiveOrders.DataBind();
                    }
                }
            }
        }

        private void UpdateOrderStatus(string purchaseId, string query)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@purchaseId", purchaseId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        protected void btnUnfit_Click(object sender, EventArgs e)
        {
            string purchaseId = (sender as Button).CommandArgument;
            
            string query = "UPDATE PurchaseOrder SET status = 'unfit' WHERE purchase_id = @purchaseId";

            UpdateOrderStatus(purchaseId, query);

            BindLiveOrders(Session["Id"].ToString());
        }


        protected void btnDone_Click(object sender, EventArgs e)
        {
            string purchaseId = (sender as Button).CommandArgument;
            string query = "UPDATE PurchaseOrder SET status = 'done' WHERE purchase_id = @purchaseId";
            /*string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query1 = "Select quantity from PurchaseOrder where purchase_id = @purchaseId";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                object temp = cmd.ExecuteScalar();

            }*/
            UpdateOrderStatus(purchaseId, query);

            BindLiveOrders(Session["Id"].ToString());
        }


    }
}