using BusinessAccess;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderSales.WebApp
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        private OrderBusinessAccess _orderBA = new OrderBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["orderProductId"] != null && !IsPostBack)
            {
                BindOrderDetails();
            }
        }


        private void BindOrderDetails()
        {
           
            int orderProductId = Convert.ToInt32(Session["orderProductId"]);
            try
            {
                OrderResponseBE order = new OrderResponseBE();
                order = _orderBA.GetOrderById(orderProductId);
                //lblOrderDate.Text = Convert.ToString(order.OrderDate);
                //DateTime dat = Convert.ToDateTime("1986-03-24T00:00:00");
                lblOrderDate.Text = order.OrderDate.ToString("dd-MM-yyyy");
                lblCustomerName.Text = order.FirstName+" "+ order.LastName;
                lblCustomerType.Text = order.CustomerTypeName;
                gvwOrderDetails.DataSource = order.OrderDetails;
                gvwOrderDetails.DataBind();


            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvwOrderDetails.PageIndex = e.NewPageIndex;
            gvwOrderDetails.DataBind();
        }

        protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvwOrderDetails.PageIndex = e.NewPageIndex;            // GRIDVIEW PAGING.
                                                            //BindGrid();       // CALL YOU METHOD TO LOAD DATA TO THE GRIDVIEW OR DO OTHER STUFF.
        }
    }

}