using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccess;
using BusinessEntities;


namespace OrderSales.WebApp
{
    public partial class Customers : System.Web.UI.Page
    {
        private CustomerBusinessAccess _customerBA = new CustomerBusinessAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }            
        }

        private void BindGrid()
        {
            try
            {
                gvwCustomer.DataSource = _customerBA.GetAllCustomers();
                gvwCustomer.DataBind();
            }
            catch(Exception)
            {
                lblError.Text = "Error in loading Customers";
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvwCustomer.PageIndex = e.NewPageIndex;
            gvwCustomer.DataBind();
        }

        protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvwCustomer.PageIndex = e.NewPageIndex;            // GRIDVIEW PAGING.
            BindGrid();       // CALL YOU METHOD TO LOAD DATA TO THE GRIDVIEW OR DO OTHER STUFF.
        }

    }
}