<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="OrderSales.WebApp.Orders" %>
<%@ Register src="CustomerTypeUserControl.ascx" tagname="CustomerTypeUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="container">
    <table class="table table-striped">
        <tr>
            <td>Customer</td>
            <td>
                <asp:TextBox ID="txtCustomerId" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Customer Type</td>
            <td>
               
                <uc1:CustomerTypeUserControl ID="CustomerTypeUserControl1" runat="server" ClientIDMode="Static" />
               
            </td>
        </tr>
        <tr>
            <td>Order Date</td>
            <td>
                <asp:TextBox ID="txtOrderDate" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Search" class="btn btn-primary" runat="server" Text="Search" OnClick="Search_Click" ClientIDMode="Static" />
            </td>
        </tr>
    </table>
        </div>
      <div>
          <div>
        <br /><br />
    <asp:GridView ID="gvwOrder" runat="server" AutoGenerateColumns="False" AllowPaging="True"   OnPageIndexChanging="GridView_PageIndexChanging" PageSize="4" HorizontalAlign="Center" DataKeyNames="OrderId" OnSelectedIndexChanging="gvwOrder_SelectedIndexChanging">
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order ID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
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
            <asp:BoundField DataField="CustomerTypeName" HeaderText="Customer Type Name">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount">
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EmptyDataTemplate>
            No Records Found
        </EmptyDataTemplate>
        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="2" Mode="NumericFirstLast" />
    </asp:GridView>
    <center><asp:Label ID="lblError0" runat="server"></asp:Label></center>
    </div>
        <br /><br />
    <center></center>
          <script type="text/javascript">
              $(document).ready(function () {
                  $('#txtOrderDate').datepicker({
                      dateFormat: 'dd/mm/yy'
                  });
                  $('#Search').click(function(e){
                      var customerId = $("#txtCustomerId").val().trim();
                      var customerTypeId = $("#ddlCustomerType").val().trim();
                      var orderDate = $("#txtOrderDate").val().trim();

                      if (!customerId && !customerTypeId && !orderDate) {
                          alert("Enter atleast one value");
                          e.preventDefault();
                      }
                  });
              })

          </script>
</asp:Content>
