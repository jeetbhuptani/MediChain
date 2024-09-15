using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    

namespace MediChain
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Connection string from Web.config
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                string tableName = (btnBuyer.Text == "Buyer") ? "Buyer" : "Dealer";

                string email = txtEmail.Text;
                string password = txtPassword.Text;

                string query = $"SELECT id FROM {tableName} WHERE email = @Email AND password = @Password";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Password", password);  // Assuming passwords are stored in plain text

                            object Id = cmd.ExecuteScalar();

                            if (Id != null)
                            {
                                lblMessage.Text = "Login successful!";
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                
                                Session["Id"] = Id.ToString();
                                
                                if (btnBuyer.Text == "Buyer")
                                {
                                    Response.Redirect("~/Buyer.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Dealer.aspx");
                                }
                            }
                            else
                            {
                                lblMessage.Text = "Invalid email or password.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (btnBuyer.Text == "Buyer")
            {
                btnBuyer.Text = "Dealer";
            }
            else
            {
                if (btnBuyer.Text == "Dealer")
                {
                    btnBuyer.Text = "Buyer";
                }
            }
        }
    }
}