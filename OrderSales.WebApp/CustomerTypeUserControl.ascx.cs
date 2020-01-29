using BusinessAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderSales.WebApp
{
    public partial class CustomerTypeUserControl : System.Web.UI.UserControl
    {
        private CustomerBusinessAccess _customerTypeBA = new CustomerBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomerType();
            }
        }

        private void BindCustomerType()
        {
            ddlCustomerType.DataSource = _customerTypeBA.GetAllCustomerTypes();
            ddlCustomerType.DataTextField = "CustomerTypeName";
            ddlCustomerType.DataValueField = "CustomerTypeId";
            ddlCustomerType.DataBind();
        }

        public string SelectedText
        {
            get
            {
                return ddlCustomerType.SelectedItem.Text;
            }
            set
            {
                ddlCustomerType.SelectedItem.Text = value.ToString();
            }
        }

        public int? SelectedValue
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ddlCustomerType.SelectedValue))
                {
                    return Convert.ToInt32(ddlCustomerType.SelectedValue);
                }
                return null;
            }
            set
            {
                ddlCustomerType.SelectedValue = Convert.ToString(value);
            }
        }       
    }
}