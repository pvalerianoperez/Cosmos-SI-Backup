

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="UsuarioEstatusDocumentoPermiso_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Catalogos.UsuarioEstatusDocumentoPermiso_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">    
    <script type="text/javascript">
        function AccionMenuItemClick(e) {
            switch (e.item.name) {
                case "AGREGAR":
                    Editar(0);
                    break;
                case "MODIFICAR":
                case "ELIMINAR":
                case "IMPRIMIR":
                case "EXPORTAR_PDF":
                case "EXPORTAR_EXCEL":
                case "AUTORIZAR":
                case "CANCELAR":
                case "BLOQUEAR":
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
                remaining_height = parseInt($(window).height() - hEncabezado - 140);
                div.height(remaining_height);
            }                        
        }
        function Editar(id) {
            if (id > 0) {

            } else {
                Grid.AddNewRow();
            }
        }
        function Eliminar(id) {
            Grid.DeleteRow(id);
            /*
            swal({
                title: "¡Eliminar!",
                text: "¿Desea eliminar el registro?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "SI",
                cancelButtonText: "NO",
                closeOnConfirm: true,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {                            
                        var index = id;
                        Grid.DeleteRow(index);
                    }
                });
            */
        }
    </script>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="Grid"></dx:ASPxGridViewExporter>
    <asp:ObjectDataSource ID="odsGrid" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.UsuarioEstatusDocumentoPermiso">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxGridView ID="Grid" 
        ClientInstanceName="Grid" 
        runat="server" 
        DataSourceID="odsGrid" 
        AutoGenerateColumns="False" 
        KeyFieldName="UsuarioEstatusDocumentoPermisoID"
        Width="100%" 
        OnBatchUpdate="Grid_BatchUpdate" 
        OnCommandButtonInitialize="Grid_CommandButtonInitialize" >
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
        <SettingsPager Mode="ShowAllRecords"></SettingsPager>
        <SettingsEditing Mode="Batch">
            <BatchEditSettings HighlightDeletedRows="False" />
        </SettingsEditing>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" />                
        <SettingsCommandButton>
            <PreviewChangesButton Text="Revisión de cambios">
                <Image IconID="zoom_zoom_16x16">
                </Image>
            </PreviewChangesButton>
            <HidePreviewButton Text="Vista normal">
                <Image IconID="richedit_inserttable_16x16">
                </Image>
            </HidePreviewButton>
            <NewButton ButtonType="Secondary" RenderMode="Secondary" Text="Nuevo">
                <Image IconID="actions_addfile_16x16">
                </Image>
                <Styles>
                    <Style Width="100%">
                    </Style>
                </Styles>
            </NewButton>
            <UpdateButton ButtonType="Outline" RenderMode="Outline" Text="Guardar los cambios">
                <Image IconID="actions_apply_16x16">
                </Image>
            </UpdateButton>
            <CancelButton Text="Cancelar los cambios">
                <Image IconID="actions_reset_16x16">
                </Image>
            </CancelButton>
            <EditButton>
                <Image IconID="edit_edit_16x16">
                </Image>
            </EditButton>
            <DeleteButton ButtonType="Secondary" RenderMode="Secondary" Text="Eliminar">
                <Image IconID="actions_trash_16x16">
                </Image>
                <Styles>
                    <Style Width="100%">
                    </Style>
                </Styles>
            </DeleteButton>
        </SettingsCommandButton>
        <SettingsPopup>
        <HeaderFilter MinHeight="140px"></HeaderFilter>
        </SettingsPopup>
        <SettingsText BatchEditChangesPreviewDeletedValues="Eliminados" BatchEditChangesPreviewInsertedValues="Nuevos" BatchEditChangesPreviewUpdatedValues="Modificados" />
        <Columns>
            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" ShowDeleteButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="UsuarioEstatusDocumentoPermisoID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Usuario" FieldName="UsuarioID" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="ObjectDataSource2" TextField="Nombre" ValueField="UsuarioID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Estatus Documento" FieldName="EstatusDocumentoID" VisibleIndex="3">
                <PropertiesComboBox DataSourceID="ObjectDataSource3" TextField="Nombre" ValueField="EstatusDocumentoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Centro Costo" FieldName="CentroCostoID" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="ObjectDataSource4" TextField="Nombre" ValueField="CentroCostoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Area" FieldName="AreaID" VisibleIndex="5">
                <PropertiesComboBox DataSourceID="ObjectDataSource5" TextField="Nombre" ValueField="AreaID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            
            <dx:GridViewDataComboBoxColumn Caption="Almacen" FieldName="AlmacenID" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="ObjectDataSource7" TextField="Nombre" ValueField="AlmacenID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Sucursal" FieldName="SucursalID" VisibleIndex="8">
                <PropertiesComboBox DataSourceID="ObjectDataSource8" TextField="Nombre" ValueField="SucursalID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn VisibleIndex="9" Caption="Monto" FieldName="Monto" MinWidth="100">
                <PropertiesSpinEdit DisplayFormatString="c2" MaxLength="10" NumberFormat="Number" DecimalPlaces="2">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesSpinEdit>
                <CellStyle HorizontalAlign="Right" />                
                <HeaderStyle HorizontalAlign="Right" />
            </dx:GridViewDataSpinEditColumn>
        </Columns>
    </dx:ASPxGridView>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Usuario"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.EstatusDocumento"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.CentroCosto">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Area">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Empresa"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Almacen">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Sucursal">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

</asp:Content>

