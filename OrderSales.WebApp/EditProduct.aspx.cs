using BusinessAccess;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OrderSales.WebApp
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private EditProductBusinessAccess _editProductBA = new EditProductBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["editProductId"] != null && !Page.IsPostBack)
            {
                //lblMessage.Text = "Hello" + Convert.ToString(Session["editProductId"]);                
                BindProduct(Convert.ToInt32(Session["editProductId"]));
            }
        }

        private void BindProduct(int session)
        {
            AddProductBE product = _editProductBA.GetProductById(session);
            //this.txtProductName.DataSource = _editProductBA.GetProductById(session).;
            this.txtProductName.Text = product.ProductName;
            this.txtReorderLevel.Text = Convert.ToString(product.ReorderLevel);
            this.CategoryUserControl.SelectedValue  = product.CategoryId;
            this.txtUnitPrice.Text = Convert.ToString(product.UnitPrice);
            this.txtUnitsInStock.Text = Convert.ToString(product.UnitsInStock);
            this.txtUnitsOnOrder.Text = Convert.ToString(product.UnitsOnOrder);
            this.txtReorderLevel.Text = Convert.ToString(product.ReorderLevel);

            if (Convert.ToBoolean(_editProductBA.GetProductById(session).Discontinued))
            {
                this.rbDiscontinue.Items.FindByValue("True").Selected = true;
            }
            else
            {
                this.rbDiscontinue.Items.FindByValue("False").Selected = true;                
            }          
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AddProductBE obj = new AddProductBE();
                obj.ProductName = Convert.ToString(txtProductName.Text);
                //obj.CategoryId = Convert.ToInt32(ddlCategoryID.Text);
                obj.CategoryId = Convert.ToInt32( CategoryUserControl.SelectedValue);
                obj.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                obj.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);
                obj.UnitsOnOrder = Convert.ToInt32(txtUnitsOnOrder.Text);
                obj.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                obj.Discontinued = Convert.ToBoolean(rbDiscontinue.SelectedValue);
                obj.ProductId = Convert.ToInt32(Session["editProductId"]);
                _editProductBA.UpdateProducts(obj);
                lblText.Text = "Record updated successfully";
                Response.Redirect("Products.aspx");
            }
            catch (Exception ex)
            {
                lblText.Text = ex.ToString();
            }
        }
    }
}    


