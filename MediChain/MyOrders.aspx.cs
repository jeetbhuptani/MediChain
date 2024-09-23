using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Id"] != null)
                {
                    LoadOrdersData();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void LoadOrdersData()
        {
            string buyerId = Session["Id"].ToString();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = @"
                    SELECT 
                        p.name AS Product,
                        po.quantity AS Quantity,
                        d.company_name AS Dealer,
                        po.amount AS TotalAmount,
                        po.date AS OrderedDate,
                        po.status AS OrderStatus
                    FROM 
                        PurchaseOrder po
                    JOIN 
                        Dealer d ON po.dealer_id = d.id
                    JOIN 
                        Product p ON po.product_id = p.product_id
                    WHERE
                        po.buyer_id = @BuyerId;
                    ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BuyerId", buyerId);

                con.Open();
                rptOrders.DataSource = cmd.ExecuteReader();
                rptOrders.DataBind();
                con.Close();
            }
        }
    }
}