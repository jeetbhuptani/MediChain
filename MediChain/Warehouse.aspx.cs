using System;

namespace MediChain
{
    public partial class WarehousePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your code here
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Code to handle Add/Update product
            txtSearch.Text = "submit";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Code to handle Delete product
            txtSearch.Text = "delete";
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Code to handle Search product
            txtSearch.Text = "search";
        }
    }
}
