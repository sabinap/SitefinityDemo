<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="SitefinityWebApp.UserControls.Navigation" %>


<ul class="nav navbar-nav">
    <!-- navigation -->
    <asp:Repeater ID="rptNavigation" runat="server">
        <ItemTemplate>
            <li class="dropdown">
                <a class="dropdown-toggle" data-hover="dropdown" href='<%#Eval("Url") %>' runat="server"><%#Eval("Title") %></a>

                <asp:Repeater ID="rptNavigation2ndLevel" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem,"secondLevelPages") %>'>
                    <HeaderTemplate>
                        <ul class="dropdown-menu">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%#Eval("Url") %>' runat="server"><%#Eval("Title") %></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
