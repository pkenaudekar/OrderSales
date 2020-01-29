using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccess;
using BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace OrderSales.WebApp
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductBusinessAccess _productBA = new ProductBusinessAccess();
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
       
        private void BindGrid()
        {
            try
            {
                gvwProduct.DataSource = _productBA.GetAllProducts();
                gvwProduct.DataBind();
            }
            catch (Exception)
            {
                lblError.Text = "Error in loading Customers";
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvwProduct.PageIndex = e.NewPageIndex;
            gvwProduct.DataBind();
        }

        protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvwProduct.PageIndex = e.NewPageIndex;            // GRIDVIEW PAGING.
            BindGrid();       // CALL YOU METHOD TO LOAD DATA TO THE GRIDVIEW OR DO OTHER STUFF.
        }

        protected void gvwProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int productId = Convert.ToInt32(gvwProduct.DataKeys[e.NewEditIndex].Value);
            Session["editProductId"] = productId;
            Response.Redirect("EditProduct.aspx");
        }
    }
}