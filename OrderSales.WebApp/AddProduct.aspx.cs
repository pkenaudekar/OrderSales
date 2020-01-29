using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BusinessAccess;
using System.Data;
using System.Data.SqlClient;

namespace OrderSales.WebApp
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private AddProductBusinessAccess _addProductBA = new AddProductBusinessAccess();
        
        private SqlConnection _connection;
        //private SqlCommand _command;
        private string _connectionString;
        public AddProduct()
        {
            _connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //    BindCategoryID();
        }

        //private void BindCategoryID()
        //{
        //    //try
        //    //{
        //    //    _connection.Open();
        //    //    //ddlCategoryID
        //    //    //ddlCategoryID.DataSource = _addProductBA.GetAllCategories();
        //    //    ddlCategoryID.DataSource = _addProductBA.GetAllCategories();
        //    //    ddlCategoryID.DataTextField = "CategoryName";//Its shows the text
        //    //    ddlCategoryID.DataValueField = "CategoryId";//Hides from the user
        //    //    ddlCategoryID.DataBind();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    lblText.Text = "Error in loading Customers";
        //    //}
        //    //finally
        //    //{
        //    //    _connection.Close();
        //    //}

        //    using (_connection = new SqlConnection(_connectionString))
        //    {
        //        _connection.Open();
        //        //var query = "SELECT CategoryId, CategoryName FROM Category";
        //        //_command = new SqlCommand(query, _connection);//command object
        //        try
        //        {
        //            //ddlCategoryID.DataSource = _command.ExecuteReader(); //Binding data to the Grid and reding
        //            ddlCategoryID.DataSource = _addProductBA.GetAllCategories();
        //            ddlCategoryID.DataTextField = "CategoryName";//Its shows the text
        //            ddlCategoryID.DataValueField = "CategoryId";//Hides from the user
        //            ddlCategoryID.DataBind();
        //        }
        //        catch (Exception)
        //        {
        //            lblText.Text = "Error in Retriving Category";
        //        }
        //        finally
        //        {
        //            _connection.Close();
        //        }
        //    }

        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AddProductBE obj = new AddProductBE();
                obj.ProductName = Convert.ToString(txtProductName.Text);
                //obj.CategoryId = Convert.ToInt32(ddlCategoryID.Text);
                obj.CategoryId = CategoryUserControl.SelectedValue;
                obj.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                obj.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);
                obj.UnitsOnOrder = Convert.ToInt32(txtUnitsOnOrder.Text);
                obj.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                obj.Discontinued = Convert.ToBoolean(rbDiscontinue.SelectedValue);
                _addProductBA.InsertProduct(obj);
                lblText.Text = "Record added successfully";
                Response.Redirect("Products.aspx");
            }
            catch(Exception ex)
            {
                lblText.Text = ex.ToString();                
            }
        }

        protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_connection = new SqlConnection("Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True");//Connection object
            //_command = new SqlCommand("SELECT * FROM Employee WHERE DepartmentId = @dno", _connection);//command object
            //_command.Parameters.AddWithValue("@dno", ddlDepartment.SelectedValue);

            //try
            //{
            //    _connection.Open();
            //    gvwDepartment.DataSource = _command.ExecuteReader(); //Binding data to the Grid and reding
            //    gvwDepartment.DataBind();
            //}
            //catch (Exception)
            //{
            //    lblError.Text = "Error in Retriving Department";
            //}
            //finally
            //{
            //    _connection.Close();

            //}
        }
    }
}