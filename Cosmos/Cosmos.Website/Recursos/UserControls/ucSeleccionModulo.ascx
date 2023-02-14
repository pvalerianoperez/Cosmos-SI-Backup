<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeleccionModulo.ascx.cs" Inherits="Cosmos.Website.Recursos.UserControls.ucSeleccionaModulo" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div style="text-align:center;margin:auto;">
    <div style="padding-bottom:20px">  
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" CssClass="Titulo1" Text="Módulos">
    </dx:ASPxLabel>
    </div>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" HorizontalAlign="Center">
        <ItemTemplate>
            <div style="text-align:center;width:130px;">
                <asp:ImageButton runat="server" ID="imgLogo" ImageUrl='<%# ImagenLogo(Cosmos.Framework.CastHelper.CInt2(Eval("ModuloID")))%>' 
                    CommandArgument='<%# Cosmos.Framework.CastHelper.CInt2(Eval("ModuloID")) %>' OnClick="imgLogo_Click" /><br />
                <dx:ASPxLabel runat="server" ID="lblNombre" Text='<%# Eval("Nombre") %>'></dx:ASPxLabel>
            </div>                
        </ItemTemplate>

    </asp:DataList>    
</div>