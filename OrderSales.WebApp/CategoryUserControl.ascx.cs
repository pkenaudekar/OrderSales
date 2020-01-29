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
    public partial class CategoryUserControl : System.Web.UI.UserControl
    {
        private AddProductBusinessAccess _addProductBA = new AddProductBusinessAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCategory();
            }
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = _addProductBA.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public string SelectedText
        {
            get
            {
                return ddlCategory.SelectedItem.Text;
            }
            set
            {
                ddlCategory.SelectedItem.Text = value.ToString();
            }
        }

        public int SelectedValue
        {
            get
            {
                return Convert.ToInt32(ddlCategory.SelectedValue);
            }
            set
            {
                ddlCategory.SelectedValue = value.ToString();
            }
        }
    }
}