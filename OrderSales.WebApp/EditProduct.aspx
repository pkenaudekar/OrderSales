<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="OrderSales.WebApp.EditProduct" %>
<%@ Register src="CategoryUserControl.ascx" tagname="CategoryUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="table-responsive">
        <table class="table table-striped">
            <tbody>
                <tr>
                    <td>Product Name</td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtProductName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Category</td>
                    <td>
                        <uc1:CategoryUserControl runat="server" id="CategoryUserControl" />
                <%--<asp:DropDownList class="btn btn-primary dropdown-toggle" ID="ddlCategoryID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryID_SelectedIndexChanged"></asp:DropDownList></td>--%>  
                
                    </tr>
                <tr>
                    <td>Unit Price</td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtUnitPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Units In Stock</td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtUnitsInStock" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Units On Order</td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtUnitsOnOrder" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Reorder Level</td>
                    <td>
                        <asp:TextBox class="form-control" ID="txtReorderLevel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Discontinued</td>
                    <td>
                        <asp:RadioButtonList ID="rbDiscontinue" runat="server" >
                            <asp:ListItem value="True">True</asp:ListItem>
                            <asp:ListItem value="False">False</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:Label ID="lblText" runat="server"></asp:Label>
</asp:Content>

