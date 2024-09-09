using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        // ProductDetails.aspx.cs
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productId = Request.QueryString["product_id"];
                if (!string.IsNullOrEmpty(productId))
                {
                    // Fetch and display product details using productId
                    DisplayProductDetails(productId);
                }
            }
        }

        private void DisplayProductDetails(string productId)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MediChainConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "SELECT category_id, name, price, description FROM Product where product_id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(productId));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        ddlCategory.SelectedIndex = Int32.Parse(rdr.GetString(0)) - 1;
                        tbName.Text = rdr.GetString(1);
                        tbPrice.Text = rdr.GetString(2);
                        tbDescription.Text = rdr.GetString(3);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Errors: ", ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}