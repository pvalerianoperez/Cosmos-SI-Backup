<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="OrdenesCompra.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Capturas.OrdenesCompra" %>
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
                  
                case "IMPRIMIR":
                case "EXPORTAR_PDF":
                case "EXPORTAR_EXCEL":
                    __doPostBack(e.item.name, "")
                    break;
                default:
                    break;
            }            
         }
         function Editar(id) {
             cbpEditar.PerformCallback("EDITAR|" + id);
         }
         function Eliminar(id) {
             swal({
                 title: "¡Eliminar!",
                 text: "¿Desea eliminar la orden de compra?",
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
                         cbpEditar.PerformCallback("ELIMINAR|" + id);
                     }
                 });

         }
         function cbpEditarEndCallback(message, refresh, refreshDetalle, show) {
             if (message != "") {
                 swal("¡Error!", message, "error");
             }
             if (refreshDetalle == "1") {
                 gvOCDetalle.PerformCallback('refresh');
             }
             if (refresh == "1") {
                 Grid.PerformCallback('refresh');
             }

             if (show == "1") {
                 if (!PopupEditar.IsVisible()) { PopupEditar.Show(); }
             } else {
                 if (PopupEditar.IsVisible()) { PopupEditar.Hide(); }
             }
         }
         function EditarOCDetalle(renglon) {
             cbpEditar.PerformCallback("EDITAR_DETALLE|" + renglon);
         }
         function EliminarOCDetalle(renglon) {
             swal({
                 title: "¡Eliminar!",
                 text: "¿Desea eliminar el detalle?",
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
                         cbpEditar.PerformCallback("ELIMINAR_DETALLE|" + renglon);
                     }
                 });

         }
         function GuardarOC() {
             if (ASPxClientEdit.ValidateGroup('OCEncabezado')) {
                 cbpEditar.PerformCallback("GUARDAR");
             }
         }
         function Consultar() {
             Grid.PerformCallback("refresh");
         }
         function CancelarEdicionOC() {
             if (PopupEditar.IsVisible()) { PopupEditar.Hide(); }
         }
         function AgregarOCDetalle() {
             if (ASPxClientEdit.ValidateGroup('OCDetalle')) {
                 cbpEditar.PerformCallback('DETALLE');
             }
         }
    </script>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Producto" ID="odsProducto"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Unidad" ID="odsUnidad"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Almacen" ID="odsAlmacen"></asp:ObjectDataSource>

<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Personal" ID="odsSolicitante"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Sucursal" ID="odsSucursal"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Proveedor" ID="odsProveedor"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odEstatusDocumento" runat="server" SelectMethod="ListadoTipoDocumentoID" TypeName="Cosmos.Compras.Api.Client.EstatusDocumento">
    <SelectParameters>
        <asp:Parameter DefaultValue="3" Name="tipoDocumentoID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


<dx:ASPxPopupControl ID="PopupEditar"  runat="server" ClientInstanceName="PopupEditar" Modal="True" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Height="800px" HeaderText="Orden de Compra" Width="900px" CloseAction="CloseButton" AllowDragging="true" AllowResize="true">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel runat="server" ID="cbpEditar" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_refreshDetalle, s.cp_show);}" />
        <PanelCollection>
            <dx:PanelContent>        
                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ShowItemCaptionColon="False">
                    <Items>
                        <dx:LayoutGroup Caption="" ColCount="6" GroupBoxDecoration="None" ColumnCount="6">
                            <Items>
                                <dx:LayoutItem Caption="Sucursal" ColSpan="3" ColumnSpan="3">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox runat="server" Width="100%" ID="ddlSucursal" ClientInstanceName="ddlSucursal" DataSourceID="odsSucursal" TextField="Nombre" ValueField="SucursalID" ValueType="System.Int32">
                                            <ClearButton Visibility="Auto"></ClearButton>
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlSerie.PerformCallback('refresh');}" />
                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Serie">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="ddlSerie" ClientInstanceName="ddlSerie" runat="server" DataSourceID="odsSerie" TextField="SerieClave" ValueField="SerieID" ValueType="System.Int32" Width="100%" OnCallback="ddlSerie_Callback">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                            <asp:ObjectDataSource runat="server" SelectMethod="ListadoSerieTipoDocumento" TypeName="Cosmos.Compras.Api.Client.Serie" ID="odsSerie">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="3" Name="tipoDocumentoID" Type="Int32" />
                                                <asp:ControlParameter ControlID="ddlSucursal" DefaultValue="" Name="sucursalID" PropertyName="Value" Type="Int32" />
                                            </SelectParameters>
                                             </asp:ObjectDataSource>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Folio">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox runat="server" Width="100%" ID="txtFolio" ClientInstanceName="txtFolio" MaxLength="5" ReadOnly="true"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Fecha">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit runat="server" Width="100%" ID="txtFecha" ClientInstanceName="txtFecha" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                <TimeSectionProperties>
                                                <TimeEditProperties>
                                                <ClearButton Visibility="Auto"></ClearButton>
                                                </TimeEditProperties>
                                                </TimeSectionProperties>
                                                <ClearButton Visibility="Auto"></ClearButton>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip"  ValidationGroup="OCEncabezado">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>                                 
                                <dx:LayoutItem Caption="Referencia" ColumnSpan="2" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtReferencia" ClientInstanceName="txtReferencia" MaxLength="50" runat="server" Width="100%">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Concepto" ColumnSpan="2" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtConcepto" ClientInstanceName="txtConcepto" MaxLength="50" runat="server" Width="100%">
                                                 <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Estatus" ColumnSpan="2" ColSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="ddlEstatus" ClientInstanceName="ddlEstatus" runat="server" Width="100%" DataSourceID="odEstatusDocumento" TextField="Nombre" ValueField="EstatusDocumentoID" ValueType="System.Int32">
                                                <ClearButton Visibility="Auto">
                                                </ClearButton>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Solicitante" ColSpan="3" ColumnSpan="3">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox runat="server" Width="100%" ID="ddlSolicitante" DataSourceID="odsSolicitante" TextField="Nombre" ValueField="PersonalID" ValueType="System.Int32">
                                            <ClearButton Visibility="Auto"></ClearButton>
                                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Proveedor" ColSpan="3" ColumnSpan="3">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="ddlProveedor" ClientInstanceName="ddlProveedor" runat="server" Width="100%" DataSourceID="odsProveedor" TextField="Nombre" ValueField="ProveedorID" ValueType="System.Int32">
                                                <ClearButton Visibility="Auto">
                                                </ClearButton>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCEncabezado">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                
                                <dx:LayoutItem Caption="Pre Autorizada">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chkPreAutorizada" ClientInstanceName="chkPreAutorizada" runat="server" CheckState="Unchecked" Text="Pre-Autorizada">
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Usuario Pre Autoriza">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxLabel runat="server" ID="lblUsuarioPreAutorizo" ClientInstanceName="lblUsuarioPreAutorizo"></dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Fecha Pre Autorización">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxLabel runat="server" ID="lblFechaPreAutorizacion" ClientInstanceName="lblFechaPreAutorizacion"></dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Autorizada">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chkAutorizada" ClientInstanceName="chkAutorizada" runat="server" CheckState="Unchecked" Text="Autorizada">
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Autorizó">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxLabel runat="server" ID="lblUsuarioAutorizo" ClientInstanceName="lblUsuarioAutorizo"></dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Fecha Autorización">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxLabel runat="server" ID="lblFechaAutorizacion" ClientInstanceName="lblFechaAutorizacion"></dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="7" ColumnCount="7" Caption="Edición del detalle">
                            <Items>
                                <dx:LayoutItem Caption="Producto" ColSpan="2" ColumnSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridLookup ID="ddlDetalleProducto" runat="server" ClientInstanceName="ddlDetalleProducto" AutoGenerateColumns="False" DataSourceID="odsProducto" KeyFieldName="ProductoID" Width="100%" TextFormatString="{2}">
                                                <GridViewProperties>
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    <SettingsPopup>
                                                        <HeaderFilter MinHeight="140px">
                                                        </HeaderFilter>
                                                    </SettingsPopup>
                                                </GridViewProperties>
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="ProductoID" ShowInCustomizationForm="True" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="MarcaID" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NombreCorto" ShowInCustomizationForm="True" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UnidadID" ShowInCustomizationForm="True" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ClaseProductoID" ShowInCustomizationForm="True" VisibleIndex="5">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TipoProductoID" ShowInCustomizationForm="True" VisibleIndex="6">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NivelProductoID" ShowInCustomizationForm="True" VisibleIndex="7">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="MetodoCosteoID" ShowInCustomizationForm="True" VisibleIndex="8">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="ManejaLotes" ShowInCustomizationForm="True" VisibleIndex="9">
                                                    </dx:GridViewDataCheckColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="ManejaSeries" ShowInCustomizationForm="True" VisibleIndex="10">
                                                    </dx:GridViewDataCheckColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Reorden" ShowInCustomizationForm="True" VisibleIndex="11">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="FamiliaProductoID" ShowInCustomizationForm="True" VisibleIndex="12">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EstatusProductoID" ShowInCustomizationForm="True" VisibleIndex="13">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AltaUsuarioID" ShowInCustomizationForm="True" VisibleIndex="14">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="AltaFecha" ShowInCustomizationForm="True" VisibleIndex="15">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ModificacionUsuarioID" ShowInCustomizationForm="True" VisibleIndex="16">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="ModificacionFecha" ShowInCustomizationForm="True" VisibleIndex="17">
                                                    </dx:GridViewDataDateColumn>
                                                </Columns>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCDetalle">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxGridLookup>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Cantidad" ColSpan="1">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtDetalleCantidad" ClientInstanceName="txtDetalleCantidad" runat="server" Width="100%">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCDetalle">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Unidad" ColSpan="1">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="ddlDetalleUnidad" runat="server" ClientInstanceName="ddlDetalleUnidad" Width="100%" DataSourceID="odsUnidad" ValueField="UnidadID" TextField="Nombre" ValueType="System.Int32">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCDetalle">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Costo" ColSpan="1">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtCosto" ClientInstanceName="txtCosto" runat="server">
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="OCDetalle">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Fecha Compromiso" ColSpan="1">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit runat="server" Width="100%" ID="txtFechaCompromiso" ClientInstanceName="txtFechaCompromiso" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                <TimeSectionProperties>
                                                <TimeEditProperties>
                                                <ClearButton Visibility="Auto"></ClearButton>
                                                </TimeEditProperties>
                                                </TimeSectionProperties>
                                                <ClearButton Visibility="Auto"></ClearButton>
                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip"  ValidationGroup="OCDetalle">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxButton ID="btnAgregarDetalle" runat="server" AutoPostBack="False" Width="100%" Text="Agregar" ClientInstanceName="btnAgregarDetalle">
                                                <ClientSideEvents Click="function(s, e) {AgregarOCDetalle();}" />
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="gvOCDetalle" runat="server" AutoGenerateColumns="False"  ClientInstanceName="gvOCDetalle" OnCustomCallback="gvOCDetalle_CustomCallback">                          
                                    <SettingsPager Mode="ShowAllRecords">
                                    </SettingsPager>
                                    <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
                                    <SettingsCommandButton>
                                        <DeleteButton>
                                            <Image IconID="actions_cancel_16x16">
                                            </Image>
                                        </DeleteButton>
                                    </SettingsCommandButton>
                                    <SettingsPopup>
                                    <HeaderFilter MinHeight="140px"></HeaderFilter>
                                    </SettingsPopup>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption=" " FieldName="RenglonID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Width="130px">
                                            <Settings AllowAutoFilter="False" />
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("RenglonID", "javascript:EliminarOCDetalle({0});") %>' RenderMode="Link" Text="Eliminar">
                                                    <Image IconID="actions_cancel_16x16">
                                                    </Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("RenglonID", "javascript:EditarOCDetalle({0});") %>' RenderMode="Link" Text="Editar">
                                                    <Image IconID="actions_editname_16x16">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </DataItemTemplate>
                                            <FilterTemplate>                                        
                                            </FilterTemplate>
                                            <FilterCellStyle HorizontalAlign="Center"></FilterCellStyle>
                                        </dx:GridViewDataTextColumn>                               
                                        <dx:GridViewDataTextColumn FieldName="RenglonID" ShowInCustomizationForm="True" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="ProductoID" ShowInCustomizationForm="True" VisibleIndex="2">
                                            <PropertiesComboBox DataSourceID="odsProducto" TextField="Nombre" ValueField="ProductoID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Cantidad" ShowInCustomizationForm="True" VisibleIndex="3" PropertiesSpinEdit-DisplayFormatString="n2">
<PropertiesSpinEdit DisplayFormatString="n2" NumberFormat="Custom"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>                                                                        
                                        <dx:GridViewDataComboBoxColumn FieldName="UnidadID" ShowInCustomizationForm="True" VisibleIndex="4">
                                            <PropertiesComboBox DataSourceID="odsUnidad" TextField="Nombre" ValueField="UnidadID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataSpinEditColumn FieldName="Costo" ShowInCustomizationForm="True" VisibleIndex="5" PropertiesSpinEdit-DisplayFormatString="n2">
<PropertiesSpinEdit DisplayFormatString="n2" NumberFormat="Custom"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>                                
                                        <dx:GridViewDataDateColumn FieldName="FechaCompromiso" ShowInCustomizationForm="True" VisibleIndex="6" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>                                
                                        
                                        
                                        
                                    </Columns>
                                </dx:ASPxGridView>
                                    
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup Caption="" ColCount="2" GroupBoxDecoration="None" ShowCaption="False">
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                            <Items>
                                <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="ASPxFormLayout1_E14" runat="server" ImagePosition="Top" Text="        Cancelar" Width="100%" AutoPostBack="False">
                                    <ClientSideEvents Click="function(s, e) {CancelarEdicionOC();}" />
                                    <Image IconID="actions_cancel_16x16">
                                    </Image>
                                    <Paddings Padding="10px" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <Paddings PaddingBottom="0px" PaddingLeft="0px" PaddingRight="5px" PaddingTop="0px" />
                    </dx:LayoutItem>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="ASPxFormLayout1_E15" runat="server" ImagePosition="Top" Text="        Guardar" Width="100%" AutoPostBack="False">
                                    <ClientSideEvents Click="function(s, e) {GuardarOC();}" />
                                    <Image IconID="actions_apply_16x16">
                                    </Image>
                                    <Paddings Padding="10px" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <Paddings Padding="0px" PaddingBottom="0px" PaddingLeft="5px" PaddingRight="0px" PaddingTop="0px" />
                    </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
                </dx:PanelContent>
            </PanelCollection>
                </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
       <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="7" ColumnCount="7" ShowItemCaptionColon="False">
                                <Items>
                                    <dx:LayoutItem Caption="Fecha Inicial" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="dtFechaInicial" ClientInstanceName="dtFechaInicial" runat="server">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Fecha Final" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="dtFechaFinal" ClientInstanceName ="dtFechaFinal" runat="server">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Mostrar Pendientes" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBox ID="chkMostrarPendientes" ClientInstanceName="chkMostrarPendientes" runat="server" CheckState="Unchecked">
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Mostrar Activos" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBox ID="chkMostrarActivos" ClientInstanceName="chkMostrarActivos" runat="server" CheckState="Unchecked">
                                                </dx:ASPxCheckBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Usuario" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="ddlFiltroSolicitante" ClientInstanceName="ddlFiltroSolicitante" runat="server" DataSourceID="odsSolicitante" TextField="Nombre" ValueField="PersonalID" ValueType="System.Int32">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Proceso" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxCheckBoxList ID="chkEstatusDocumento" ClientInstanceName="chkEstatusDocumento" runat="server" DataSourceID="odEstatusDocumento" TextField="Nombre" ValueField="EstatusDocumentoID" ValueType="System.Int32" RepeatColumns="4">
                                                </dx:ASPxCheckBoxList>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxButton ID="btnConsultar" ClientInstanceName="btnConsultar" runat="server" AutoPostBack="False" Text="Consultar">
                                                    <ClientSideEvents Click="function(s, e) {Consultar();}" />
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <SettingsItemCaptions Location="Top" />
                                <SettingsItems VerticalAlign="Top" />
    </dx:ASPxFormLayout>
    <br />
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" 
        AutoGenerateColumns="False" KeyFieldName="OrdenCompraEncabezadoID" Width="100%" OnCustomCallback="Grid_CustomCallback" EnableRowsCache="False" EnableViewState="False" >
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
        <SettingsBehavior ConfirmDelete="False" />
        <SettingsCommandButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>
        <Columns>
            <dx:GridViewDataTextColumn Caption=" " FieldName="OrdenCompraEncabezadoID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Width="130px">
                <Settings AllowAutoFilter="False" />
                <DataItemTemplate>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("OrdenCompraEncabezadoID", "javascript:Eliminar({0});") %>' RenderMode="Link" Text="Eliminar">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("OrdenCompraEncabezadoID", "javascript:Editar({0});") %>' RenderMode="Link" Text="Editar">
                        <Image IconID="actions_editname_16x16">
                        </Image>
                    </dx:ASPxButton>
                </DataItemTemplate>
                <FilterTemplate>                                        
                </FilterTemplate>
                <FilterCellStyle HorizontalAlign="Center"></FilterCellStyle>
            </dx:GridViewDataTextColumn>        
            <dx:GridViewDataTextColumn Caption="Serie" FieldName="Serie" VisibleIndex="1" Width="50px" ReadOnly="true">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Folio" FieldName="Folio" VisibleIndex="2" Width="120px">
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Movimientos" FieldName="Movimientos" VisibleIndex="2" Width="120px">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Fecha" FieldName="Fecha" VisibleIndex="3" Width="300px" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Estatus" FieldName="EstatusDocumento" VisibleIndex="5">
                <PropertiesComboBox TextField="Nombre" ValueField="SucursalID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
