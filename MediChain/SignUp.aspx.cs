using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace MediChain
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Add logic for registration process
            if (Page.IsValid)
            {
                //put connectionstrings name from web.config
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                string tableName = (btnBuyer.Text == "Buyer") ? "Buyer" : "Dealer";
                string name = txtName.Text;
                string mobileNumber = txtMobileNumber.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                DateTime joiningDate = DateTime.Now;
                string pharmacyName = "";
                string pharmacyAddress = "";
                string companyName = "";
                string companyAddress = "";
                int warehouseId = 0;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string insertQuery = "";

                    if (tableName == "Buyer")
                    {
                        pharmacyName = txtPharmacyName.Text;
                        pharmacyAddress = txtPharmacyAddress.Text;
                        insertQuery = "INSERT INTO Buyer (buyer_name, pharmacy_name, pharmacy_address, mobile_no, email, password, joiningDate) " +
                                      "VALUES (@Name ,@PharmacyName, @PharmacyAddress, @MobileNumber, @Email, @Password, @JoiningDate)";
                    }
                    else if (tableName == "Dealer")
                    {
                        companyName = txtPharmacyName.Text;
                        companyAddress = txtPharmacyAddress.Text;
                        insertQuery = "INSERT INTO Dealer (owner_name, company_name, company_address, mobile_no, email, password, joiningDate) " +
                                      "VALUES (@Name, @CompanyName, @CompanyAddress, @MobileNumber, @Email, @Password, @JoiningDate)";
                    }

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@JoiningDate", joiningDate);

                        if (tableName == "Dealer")
                        {
                            cmd.Parameters.AddWithValue("@CompanyName", companyName);
                            cmd.Parameters.AddWithValue("@CompanyAddress", companyAddress);
                            dealerId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PharmacyName", pharmacyName);
                            cmd.Parameters.AddWithValue("@PharmacyAddress", pharmacyAddress);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (tableName == "Dealer")
                    {
                        // Insert into Warehouse table
                        warehouseId = GenerateUniqueWarehouseId(connectionString);
                        string warehouseInsertQuery = "INSERT INTO Warehouse (warehouse_id, dealer_id) VALUES (@WarehouseId, @DealerId)";
                        using (SqlCommand cmd = new SqlCommand(warehouseInsertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                            cmd.Parameters.AddWithValue("@DealerId", dealerId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            txtName.Text = string.Empty;
            txtPharmacyName.Text = string.Empty;
            txtPharmacyAddress.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        protected void btnBuyer_Click(object sender, EventArgs e)
        {
            if (btnBuyer.Text == "Buyer")
            {
                btnBuyer.Text = "Dealer";
                lblPharmacyName.Text = "Company";
                lblPharmacyAddress.Text = "Company Address";
            }
            else
            {
                btnBuyer.Text = "Buyer";
                lblPharmacyName.Text = "Pharmacy";
                lblPharmacyAddress.Text = "Pharmacy Address";
            }
        }
    }
}