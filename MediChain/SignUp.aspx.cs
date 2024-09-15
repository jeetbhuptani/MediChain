using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

                string tableName = (btnBuyer.Text == "Buyer") ? "Buyers" : "Dealer";
                string name = txtName.Text;
                string mobileNumber = txtMobileNumber.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                DateTime joiningDate = DateTime.Now;
                string pharmacyName = "";
                string pharmacyAddress = "";
                string companyName = "";
                string companyAddress = "";


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string insertQuery = "";

                    if (tableName == "Buyers")
                    {
                        pharmacyName = txtPharmacyName.Text;
                        pharmacyAddress = txtPharmacyAddress.Text;
                        insertQuery = "INSERT INTO Buyers (buyer_name, pharmacy_name, pharmacy_address, mobile_no, email, password, joiningDate) " +
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
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PharmacyName", pharmacyName);
                            cmd.Parameters.AddWithValue("@PharmacyAddress", pharmacyAddress);
                        }

                        cmd.ExecuteNonQuery();
                    }
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