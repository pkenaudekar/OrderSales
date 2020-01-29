<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="OrderSales.WebApp.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <br /><br />
    <asp:GridView ID="gvwCustomer" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="Page_Load" OnPageIndexChanging="GridView_PageIndexChanging" PageSize="4" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" Visible="False">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FirstName" HeaderText="First Name">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="LastName" HeaderText="Last Name">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CustomerTypeId" HeaderText="Customer Type ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="State" HeaderText="State">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Country" HeaderText="Country">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Pincode" HeaderText="Pincode">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email">
            <FooterStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Phone" HeaderText="Phone">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="2" Mode="NumericFirstLast" />
    </asp:GridView>
    <center><asp:Label ID="lblError" runat="server"></asp:Label></center>
    </div>
</asp:Content>
