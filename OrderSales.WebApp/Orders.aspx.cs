using BusinessAccess;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderSales.WebApp
{
    public partial class Orders : System.Web.UI.Page
    {
        private OrderBusinessAccess _orderBA = new OrderBusinessAccess();

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
                //gvwOrder.DataSource = _orderBA.GetAllOrder(obj);
                gvwOrder.DataBind();
            }
            catch (Exception)
            {
                lblError0.Text = "Error in loading Customers";
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            try
            {
                OrderRequestBE obj = new OrderRequestBE();
                if (!string.IsNullOrWhiteSpace(txtCustomerId.Text))
                {
                    obj.CustomerId = Convert.ToInt32(txtCustomerId.Text.Trim());
                }

                obj.CustomerTypeId = CustomerTypeUserControl1.SelectedValue;

                if (!string.IsNullOrWhiteSpace(txtOrderDate.Text))
                {
                    obj.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                }

                gvwOrder.DataSource = _orderBA.GetAllOrder(obj);
                gvwOrder.DataBind();
            }
            catch (Exception ex)
            {
                lblError0.Text = ex.ToString();
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvwOrder.PageIndex = e.NewPageIndex;
            gvwOrder.DataBind();
        }

        protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvwOrder.PageIndex = e.NewPageIndex;            // GRIDVIEW PAGING.
                                                            //BindGrid();       // CALL YOU METHOD TO LOAD DATA TO THE GRIDVIEW OR DO OTHER STUFF.
        }

        
        protected void gvwOrder_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string orderId = Convert.ToString(gvwOrder.DataKeys[e.NewSelectedIndex].Value);
            Session["orderProductId"] = orderId;
            Response.Redirect("OrderDetails.aspx");
        }
       
    }
}