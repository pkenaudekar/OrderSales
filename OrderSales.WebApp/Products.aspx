<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="OrderSales.WebApp.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <br /><br />
    <asp:GridView ID="gvwProduct" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="Page_Load" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="4" HorizontalAlign="Center" DataKeyNames="ProductId" OnRowEditing="gvwProduct_RowEditing" Width="1007px">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CategoryId" HeaderText="Category ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UnitsInStock" HeaderText="Unit In Stock">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="Units On Order">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Discontinued" HeaderText="Discontinued">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="2" Mode="NumericFirstLast" />
    </asp:GridView>
    
    <center><asp:Label ID="lblError" runat="server" Text="" ></asp:Label>
        <br />
    <a href="AddProduct.aspx" class="btn btn-primary">Add New Product</a></center>
    </div>
</asp:Content>
