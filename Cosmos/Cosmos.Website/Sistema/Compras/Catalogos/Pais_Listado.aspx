

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Pais_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Catalogos.Pais_Listado" %>
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
        function EditarDetalles(id) {
            popupDetalles.SetContentUrl('Estado_Listado.aspx?hidenavigation=1&PaisID=' + id)
            popupDetalles.Show();
        }
        function EditarDetallesMunicipios(id) {
            popupDetallesMunicipios.SetContentUrl('Municipio_Listado.aspx?hidenavigation=1&EstadoID=' + id)
            popupDetallesMunicipios.Show();
        }
        function EditarDetallesCiudades(id) {
            popupDetallesCiudades.SetContentUrl('Ciudad_Listado.aspx?hidenavigation=1&MunicipioID=' + id)
            popupDetallesCiudades.Show();
        }

    </script>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="Grid"></dx:ASPxGridViewExporter>
    <asp:ObjectDataSource ID="odsGrid" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Pais"></asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="popupDetalles" runat="server" AllowDragging="True" AllowResize="True" ClientInstanceName="popupDetalles" CloseAction="CloseButton" HeaderText="Estados" Height="400px" 
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="800px">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popupDetallesMunicipios" runat="server" AllowDragging="True" AllowResize="True" ClientInstanceName="popupDetallesMunicipios" CloseAction="CloseButton" HeaderText="Municipios" Height="400px" 
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="800px">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl><dx:ASPxPopupControl ID="popupDetallesCiudades" runat="server" AllowDragging="True" AllowResize="True" ClientInstanceName="popupDetallesCiudades" CloseAction="CloseButton" HeaderText="Ciudades" Height="400px" 
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="800px">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxGridView ID="Grid" 
        ClientInstanceName="Grid" 
        runat="server" 
        DataSourceID="odsGrid" 
        AutoGenerateColumns="False" 
        KeyFieldName="PaisID"
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
            <dx:GridViewDataTextColumn Caption="ID" FieldName="PaisID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Clave" FieldName="PaisClave" VisibleIndex="2" MinWidth="92" Width="92px">
                <PropertiesTextEdit MaxLength="6">
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="3" MinWidth="300" Width="300px">
                <PropertiesTextEdit MaxLength="50">
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="4" MinWidth="100" Width="100px">
                <PropertiesTextEdit MaxLength="15">
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataHyperLinkColumn Caption=" " FieldName="PaisID" VisibleIndex="5">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:EditarDetalles({0});" Text="Estados">
                </PropertiesHyperLinkEdit>
                <HeaderStyle HorizontalAlign="Left" />
                <CellStyle HorizontalAlign="Left">
                </CellStyle>
            </dx:GridViewDataHyperLinkColumn>
        </Columns>
    </dx:ASPxGridView>

</asp:Content>

