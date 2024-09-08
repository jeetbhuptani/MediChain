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
    public partial class Dealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MediChainConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "Select * from MedicineWarehouse";
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

        protected void GVWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}