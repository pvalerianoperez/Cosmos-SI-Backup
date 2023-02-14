

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Perfil_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Seguridad.Catalogos.Perfil_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
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
        function EditarOpciones(id) {            
            tlOpciones.PerformCallback(id);
            popupOpciones.Show();
        }
        function EditarAcciones(id) {
            cbpAcciones.PerformCallback('REFRESCAR|' + id);
            popupAcciones.Show();
        }
        function GuardarAcciones() {
            cbpAcciones.PerformCallback('GUARDAR');
        }
        function cbpAccionesEndCallback(message, refresh, show) {           
            if (message != "") {
                swal("¡Error!", message, "error");
            }
            if (show == "1") {
                if (!popupAcciones.IsVisible()) { popupAcciones.Show(); }
            } else {
                if (popupAcciones.IsVisible()) { popupAcciones.Hide(); }
            }
        }
    </script>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="Grid"></dx:ASPxGridViewExporter>
    <asp:ObjectDataSource ID="odsGrid" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Perfil"></asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="popupAcciones" ClientInstanceName="popupAcciones" runat="server" AllowDragging="True" CloseAction="CloseButton" Height="300px" Modal="True" Width="400px" ScrollBars="None" HeaderText="Acciones"
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">        
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxButton ID="btnGuardarAcciones" runat="server" Text="Guardar" AutoPostBack="False" ClientInstanceName="btnGuardarAcciones">
                    <ClientSideEvents Click="function(s, e) {GuardarAcciones();}" />
                </dx:ASPxButton>
                <dx:ASPxCallbackPanel ID="cbpAcciones" runat="server" ClientInstanceName="cbpAcciones" OnCallback="cbpAcciones_Callback">
                    <ClientSideEvents EndCallback="function(s, e) {cbpAccionesEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show);}" />
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <asp:ObjectDataSource ID="odsAcciones" runat="server" SelectMethod="ConsultarAcciones" TypeName="Cosmos.Seguridad.Api.Client.Perfil">
                                <SelectParameters>
                                    <asp:SessionParameter Name="perfilID" SessionField="Perfil_Listado_PerfilID" Type="Int32" />
                                    <asp:SessionParameter DefaultValue="" Name="opcionID" SessionField="Perfil_Listado_OpcionID" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <dx:ASPxCheckBoxList ID="chkAcciones" runat="server" DataSourceID="odsAcciones" TextField="Accion" ValueField="AccionID" ClientInstanceName="chkAcciones" OnDataBound="chkAcciones_DataBound" EnableViewState="false">
                            </dx:ASPxCheckBoxList>
                            
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popupOpciones" ClientInstanceName="popupOpciones" runat="server" AllowDragging="True" CloseAction="CloseButton" Height="500px" Modal="True" Width="400px" ScrollBars="None" HeaderText="Opciones del Perfil"
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">            
            <asp:ObjectDataSource ID="odsOpciones" runat="server" SelectMethod="ConsultarOpciones" TypeName="Cosmos.Seguridad.Api.Client.Perfil">
                <SelectParameters>
                    <asp:SessionParameter Name="perfilID" SessionField="Perfil_Listado_PerfilID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <dx:ASPxTreeList ID="tlOpciones" runat="server" AutoGenerateColumns="False" ClientInstanceName="tlOpciones" DataSourceID="odsOpciones" 
                KeyFieldName="OpcionID" ParentFieldName="PadreID" Width="400px" 
                OnCustomCallback="tlOpciones_CustomCallback" 
                OnDataBound="tlOpciones_DataBound" OnSelectionChanged="tlOpciones_SelectionChanged"  >
                <Columns>
                    <dx:TreeListTextColumn AutoFilterCondition="Default" FieldName="Nombre" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0">
                    </dx:TreeListTextColumn>

                    <dx:TreeListHyperLinkColumn AutoFilterCondition="Default" FieldName="OpcionID" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="1">
                        <PropertiesHyperLink NavigateUrlFormatString="javascript:EditarAcciones({0});" Text="Acciones">
                        </PropertiesHyperLink>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:TreeListHyperLinkColumn>

                </Columns>
                <Settings ScrollableHeight="490" ShowColumnHeaders="False" VerticalScrollBarMode="Auto" />
                <SettingsBehavior AllowAutoFilter="False" AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False" AutoExpandAllNodes="True" 
                    ProcessFocusedNodeChangedOnServer="false" 
                    ProcessSelectionChangedOnServer="false" />
                <SettingsSelection Enabled="True" Recursive="True" AllowSelectAll="True" />
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                <settingspopup>
                    <headerfilter minheight="140px">
                    </headerfilter>
                </settingspopup>        
            </dx:ASPxTreeList>        
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxGridView ID="Grid" 
        ClientInstanceName="Grid" 
        runat="server" 
        DataSourceID="odsGrid" 
        AutoGenerateColumns="False" 
        KeyFieldName="PerfilID"
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
            <dx:GridViewDataTextColumn Caption="ID" FieldName="PerfilID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="2" MinWidth="300" Width="300px">
                <PropertiesTextEdit MaxLength="50">
                    <ValidationSettings>
                        <RequiredField IsRequired="true" ErrorText="El dato es requerido" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="3" MinWidth="100" Width="100px">
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataHyperLinkColumn Caption=" " FieldName="PerfilID" VisibleIndex="4" MinWidth="100">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:EditarOpciones({0});" Text="Opciones">
                </PropertiesHyperLinkEdit>
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </dx:GridViewDataHyperLinkColumn>
        </Columns>
    </dx:ASPxGridView>

</asp:Content>

