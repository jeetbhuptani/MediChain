using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediChain
{
    public partial class Warehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
           ShowProducts();
        }

        protected void ShowProducts()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MediChainConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "SELECT m.product_id, p.name, m.quantity, p.price, m.custom_price, p.description\r\nFROM MedicineWarehouse m\r\nINNER JOIN product p ON m.product_id = p.product_id;\r\n";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GVWarehouse.DataSource = rdr;
                    GVWarehouse.DataBind();
                    rdr.Close();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MediChainConnection"].ConnectionString;
            string query = "INSERT INTO MedicineWarehouse (product_id, quantity, custom_price) values (@productId, @quantity, @customPrice)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@productId", "4");
                        cmd.Parameters.AddWithValue("@quantity", 6);
                        cmd.Parameters.AddWithValue("@customPrice", 100);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
            ShowProducts();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MediChainConnection"].ConnectionString;
            string query = "DELETE from MedicineWarehouse where product_id = @id";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@id", 4);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errors: " + ex.Message);
            }
            ShowProducts();
        }
    }

        
}