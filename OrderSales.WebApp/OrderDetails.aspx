<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="OrderSales.WebApp.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  <div class="container">
      <table class="table table-striped">
        <tr>
            <td>Order Date</td>
            <td>
                <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label>

            </td>
            
        </tr>
        <tr>
            <td>Customer Name</td>
            <td>
                <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>

            </td>
            
        </tr>
        <tr>
            <td>Customer Type</td>
            <td>
                <asp:Label ID="lblCustomerType" runat="server" Text=""></asp:Label>

            </td>
            
        </tr>
    </table>
  </div>
    <asp:GridView ID="gvwOrderDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"  PageSize="4" HorizontalAlign="Center" DataKeyNames="OrderId" >
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Total" HeaderText="Total">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <center><asp:Label ID="lblError" runat="server"></asp:Label></center>
</asp:Content>
