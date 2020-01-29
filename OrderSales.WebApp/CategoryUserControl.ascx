<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryUserControl.ascx.cs" Inherits="OrderSales.WebApp.CategoryUserControl" %>
<asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    <asp:ListItem>Select Category</asp:ListItem>
</asp:DropDownList>