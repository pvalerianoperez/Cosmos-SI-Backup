﻿

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="ClaseProducto_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Sistema.ClaseProducto_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    
    <script type="text/javascript">
        function AccionMenuItemClick(e) {
            switch (e.item.name) {
                case "AGREGAR":
                    Grid.AddNewRow();
                    break;
                case "IMPRIMIR":
                case "EXPORTAR_PDF":
                case "EXPORTAR_EXCEL":
                    __doPostBack(e.item.name, "")
                    break;
                default:
                    break;
            }            
        }
    </script>
    <script type="text/javascript">        
        $(function () {
            resize_grid_pane();
            $(window).resize(resize_grid_pane);
        });
        function resize_grid_pane() {
            var div = $(".dxgvCSD");
            var hEncabezado = $("#divEncabezado").height();          
            if (div != null) {
                var offset = div.offset;
                remaining_height = parseInt($(window).height() - hEncabezado - 130);
                div.height(remaining_height);
            }                        
        }
    </script>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="Grid"></dx:ASPxGridViewExporter>
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.ClaseProducto"></asp:ObjectDataSource>
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="ClaseProductoID" Width="100%" OnBatchUpdate="Grid_BatchUpdate">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <SettingsEditing Mode="Batch">
        </SettingsEditing>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
        <SettingsBehavior ConfirmDelete="False" />
        <SettingsCommandButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>        
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" Caption=" " ShowDeleteButton="True" VisibleIndex="0" Width="40px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="ClaseProductoID" VisibleIndex="1" Width="50px" ReadOnly="true">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Clase Producto Clave" FieldName="ClaseProductoClave" VisibleIndex="2" Width="40px">
                <PropertiesTextEdit MaxLength="4">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="3" Width="150px">
                <PropertiesTextEdit MaxLength="25">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="4" >
                <PropertiesTextEdit MaxLength="8">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
                    
        </Columns>
    </dx:ASPxGridView>
    
</asp:Content>

