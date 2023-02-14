<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUsuario.ascx.cs" Inherits="Cosmos.Website.Recursos.UserControls.ucUsuario" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <dx:ASPxHyperLink ID="hlUsuario" runat="server" Text="Usuario" ClientInstanceName="hlUsuario" />
            &nbsp;-
            <dx:ASPxHyperLink ID="hlCerrarSesión" runat="server" Text="Cerrar Sesión" NavigateUrl="~/Cuenta/Logout.aspx" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left">
            <dx:ASPxHyperLink ID="hlEmpresa" runat="server" Text="Empresa" ClientInstanceName="hlEmpresa" CssClass="linkEmpresaModulo" />&nbsp;
            <dx:ASPxLabel runat="server" ID="lblSeparador" Text=" > "></dx:ASPxLabel>
            <dx:ASPxHyperLink ID="hlModulo" runat="server" Text="Modulo" ClientInstanceName="hlModulo" CssClass="linkEmpresaModulo" />
        </td>
    </tr>
</table>


