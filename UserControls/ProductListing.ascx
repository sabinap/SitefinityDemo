<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListing.ascx.cs" Inherits="SitefinityWebApp.UserControls.ProductListing" %>
        <asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="rptProducts_ItemDataBound">
            <ItemTemplate>
                Product:<asp:Literal ID="productTitle" runat="server"></asp:Literal><br />
                Category: <asp:Literal ID="productCategory" runat="server"></asp:Literal><br /><br />
            </ItemTemplate>
        </asp:Repeater>