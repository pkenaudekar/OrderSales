<%@ Page Title="Add Product Data" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OrderSales.WebApp.AddProduct" %>

<%@ Register Src="~/CategoryUserControl.ascx" TagPrefix="uc1" TagName="CategoryUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h3>Please Enter Search Details</h3>
  <div class="container">
  <div class="table-responsive">
      <table class="table table-striped">
        <tbody>
          <tr>
            <td>Product Name</td>
            <td><asp:TextBox class="form-control" ID="txtProductName" runat="server"></asp:TextBox></td>        
          </tr>
          <tr>
            <td>Category</td>
            <td>
                <uc1:CategoryUserControl runat="server" id="CategoryUserControl" />
                <%--<asp:DropDownList class="btn btn-primary dropdown-toggle" ID="ddlCategoryID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryID_SelectedIndexChanged"></asp:DropDownList></td>--%>  
                
          </tr>
          <tr>
            <td>Unit Price</td>
            <td><asp:TextBox class="form-control" ID="txtUnitPrice" runat="server"></asp:TextBox></td>        
          </tr>
          <tr>
            <td>Units In Stock</td>
            <td><asp:TextBox class="form-control" ID="txtUnitsInStock" runat="server"></asp:TextBox></td>        
          </tr>
          <tr>
            <td>Units On Order</td>
            <td><asp:TextBox class="form-control" ID="txtUnitsOnOrder" runat="server"></asp:TextBox></td>        
          </tr>
          <tr>
            <td>Reorder Level</td>
            <td><asp:TextBox class="form-control" ID="txtReorderLevel" runat="server"></asp:TextBox></td>        
          </tr>
          <tr>
            <td>Discontinued</td>
            <td>
                <asp:RadioButtonList ID="rbDiscontinue" runat="server" >
                    <asp:ListItem>True</asp:ListItem><asp:ListItem>False</asp:ListItem>
                </asp:RadioButtonList>
            </td>        
          </tr>
          <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click"/>
            </td>        
          </tr>
        </tbody>
      </table>
  </div>
</div>
    <asp:Label ID="lblText" runat="server"></asp:Label>
</asp:Content>
