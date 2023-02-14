<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="FormaPago_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.FormaPago_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <script type="text/javascript">
        function AccionMenuItemClick(e) {
            switch (e.item.name) {
                case "AGREGAR":
                    grid.AddNewRow();
                    break;
                case "ELIMINAR":
                    grid.DeleteRow();
                    break;
                default:
                    break;
            }
            
        }
    </script>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="grid" runat="server" 
        AutoGenerateColumns="False" KeyFieldName="FormaPagoID" Width="100%" OnBatchUpdate="ASPxGridView1_BatchUpdate">
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <SettingsEditing Mode="Batch">
        </SettingsEditing>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
        <Columns>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="FormaPagoID" VisibleIndex="0" Width="50px" ReadOnly="true">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="1" Width="100px">
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="2" >
                <PropertiesTextEdit MaxLength="50">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
