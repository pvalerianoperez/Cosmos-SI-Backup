<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Requisiciones.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Capturas.Requisiciones" %>
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
    </script>
    <script type="text/javascript">   
        function Editar(id) {
            cbpEditar.PerformCallback("EDITAR|" + id);
        }
        function Eliminar(id) {
            swal({
                title: "¡Eliminar!",
                text: "¿Desea eliminar la requisición?",
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
        function AbreCatalogo(titulo, url) {           
            if (!PopupCatalogo.IsVisible()) { PopupCatalogo.Show(); }
            PopupCatalogo.SetHeaderText(titulo);
            //PopupCatalogo.SetContentUrl('_blank');
            PopupCatalogo.SetSize(830, 590);
            PopupCatalogo.UpdatePosition();
            //PopupCatalogo.SetContentUrl(url)
        }
        function cbpEditarEndCallback(message, refresh, refreshDetalle, show) {
            if (message != "") {
                swal("¡Error!", message, "error");
            }
            if (refreshDetalle == "1") {                
                gvRequisicionDetalle.PerformCallback('refresh');
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
        function EditarRequisicionDetalle(renglon) {
            cbpEditar.PerformCallback("EDITAR_DETALLE|" + renglon);
        }
        function EliminarRequisicionDetalle(renglon) {
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
        function GuardarRequisicion() {
            if (ASPxClientEdit.ValidateGroup('RequisicionEncabezado')) {
                cbpEditar.PerformCallback("GUARDAR");
            }
        }
        function Consultar() {
            Grid.PerformCallback("refresh");
        }
        function CancelarEdicionRequisicion() {
            if (PopupEditar.IsVisible()) { PopupEditar.Hide(); }
        }
        function AgregarRequisicionDetalle() {
            if (ASPxClientEdit.ValidateGroup('RequisicionDetalle')) {
                cbpEditar.PerformCallback('DETALLE');
            }
        }
        //$(function () {
        //    resize_grid_pane();
        //    $(window).resize(resize_grid_pane);
        //});
        //function resize_grid_pane() {
        //    var div = $(".dxgvCSD");
        //    var hEncabezado = $("#divEncabezado").height();
        //    alert(div);
        //    if (div != null) {
        //        var offset = div.offset;
        //        remaining_height = parseInt($(window).height() - hEncabezado - 130);
        //        div.height(remaining_height);
        //    }                        
        //}
    </script>
    <dx:ASPxPopupControl ID="PopupEditar"  runat="server" ClientInstanceName="PopupEditar" Modal="True" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Height="800px" HeaderText="Requisición" Width="900px" CCloseAction="CloseButton" AllowDragging="true" AllowResize="true">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel runat="server" ID="cbpEditar" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_refreshDetalle, s.cp_show);}" />
        <PanelCollection>
            <dx:PanelContent>        
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ShowItemCaptionColon="False">
        <Items>
<dx:LayoutGroup Caption="" ColCount="6" GroupBoxDecoration="None" ColumnCount="6"><Items>
<dx:LayoutItem Caption="Sucursal" ColSpan="2"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" Width="100%" ID="ddlSucursal" ClientInstanceName="ddlSucursal" DataSourceID="odsSucursal" TextField="Nombre" ValueField="SucursalID" ValueType="System.Int32">
<ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlSerie.PerformCallback('refresh');}" />
</dx:ASPxComboBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Serie"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="ddlSerie" runat="server" DataSourceID="odsSerie" TextField="SerieClave" ValueField="SerieID" ValueType="System.Int32" Width="100%" ClientInstanceName="ddlSerie" OnCallback="ddlSerie_Callback">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource runat="server" SelectMethod="ListadoSerieTipoDocumento" TypeName="Cosmos.Compras.Api.Client.Serie" ID="odsSerie">
                                    <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="tipoDocumentoID" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlSucursal" DefaultValue="" Name="sucursalID" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Folio"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox runat="server" Width="100%" ID="txtMovimiento" ReadOnly="true" MaxLength="5"></dx:ASPxTextBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Fecha"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxDateEdit runat="server" Width="100%" ID="txtFecha" ClientInstanceName="txtFecha">
                                    <TimeSectionProperties>
                                    <TimeEditProperties>
                                    <ClearButton Visibility="Auto"></ClearButton>
                                    </TimeEditProperties>
                                    </TimeSectionProperties>
                                    <ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Referencia"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox runat="server" Width="100%" ID="txtReferencia" MaxLength="20">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Centro de Costo"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" Width="100%" ID="ddlCentroCosto" ClientInstanceName="ddlCentroCosto" DataSourceID="odsCentroCosto" TextField="Nombre" ValueField="CentroCostoID" ValueType="System.Int32">
<ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
</dx:ASPxComboBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="&#193;rea"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" Width="100%" ID="ddlArea" DataSourceID="odsArea" TextField="Nombre" ValueField="AreaId" ValueType="System.Int32">
<ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
</dx:ASPxComboBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Solicitante" ColSpan="2"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" Width="100%" ID="ddlSolicitante" DataSourceID="odsSolicitante" TextField="NombreCompleto" ValueField="PersonalID" ValueType="System.Int32">
<ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
</dx:ASPxComboBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Concepto" ColSpan="2"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox runat="server" Width="100%" ID="txtConcepto" MaxLength="50">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
    <dx:LayoutItem Caption="Pre Autorizada" ColSpan="1" Visible="false">
        <LayoutItemNestedControlCollection>
            <dx:LayoutItemNestedControlContainer runat="server">
                <dx:ASPxCheckBox ID="chkPreAutorizada" runat="server" CheckState="Unchecked">
                </dx:ASPxCheckBox>
            </dx:LayoutItemNestedControlContainer>
        </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
    <dx:LayoutItem Caption="Usuario Pre Autoriza" ColSpan="1" Visible="false">
        <LayoutItemNestedControlCollection>
            <dx:LayoutItemNestedControlContainer runat="server">
                <dx:ASPxLabel ID="lblUsuarioPreAutorizo" runat="server">
                </dx:ASPxLabel>
            </dx:LayoutItemNestedControlContainer>
        </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
    <dx:LayoutItem Caption="Fecha Pre Autorización" ColSpan="1" Visible="false">
        <LayoutItemNestedControlCollection>
            <dx:LayoutItemNestedControlContainer runat="server">
                <dx:ASPxLabel ID="lblFechaPreAutorizacion" runat="server">
                </dx:ASPxLabel>
            </dx:LayoutItemNestedControlContainer>
        </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
    <dx:LayoutItem Caption="Autorizada" ColSpan="1" Visible="false">
        <LayoutItemNestedControlCollection>
            <dx:LayoutItemNestedControlContainer runat="server">
                <dx:ASPxCheckBox ID="chkAutorizada" runat="server" CheckState="Unchecked">
                </dx:ASPxCheckBox>
            </dx:LayoutItemNestedControlContainer>
        </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
    <dx:LayoutItem Caption="Autorizó" ColSpan="1" Visible="false">
        <LayoutItemNestedControlCollection>
            <dx:LayoutItemNestedControlContainer runat="server">
                <dx:ASPxLabel ID="lblUsuarioAutorizo" runat="server">
                </dx:ASPxLabel>
            </dx:LayoutItemNestedControlContainer>
        </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
<dx:LayoutItem Caption="Fecha Autorización" ColSpan="1" Visible="false"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxLabel runat="server" ID="lblFechaAutorizacion"></dx:ASPxLabel>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
<dx:LayoutItem Caption="Estatus" ColSpan="2" ColumnSpan="2"><LayoutItemNestedControlCollection>
<dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox runat="server" Width="100%" ID="ddlEstatus" DataSourceID="odEstatusDocumento" TextField="Nombre" ValueField="EstatusDocumentoID" ValueType="System.Int32">
<ClearButton Visibility="Auto"></ClearButton>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionEncabezado">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
</dx:ASPxComboBox>

                            </dx:LayoutItemNestedControlContainer>
</LayoutItemNestedControlCollection>
</dx:LayoutItem>
</Items>
</dx:LayoutGroup>
            <dx:LayoutGroup ColCount="5" ColumnCount="5" Caption="Edición del detalle">
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
                                        <dx:GridViewDataComboBoxColumn FieldName="MarcaID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Marca">
                                            <PropertiesComboBox DataSourceID="odsMarca" ValueField="MarcaID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NombreCorto" ShowInCustomizationForm="True" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="UnidadID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Unidad">
                                            <PropertiesComboBox DataSourceID="odsUnidad" ValueField="UnidadID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="ClaseProductoID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Clase">
                                            <PropertiesComboBox DataSourceID="odsClaseProducto" ValueField="ClaseProductoID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="TipoProductoID" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Tipo">
                                            <PropertiesComboBox DataSourceID="odsTipoProducto" ValueField="TipoProductoID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="NivelProductoID" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Nivel">
                                            <PropertiesComboBox DataSourceID="odsNivelProducto" ValueField="NivelProductoID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="MetodoCosteoID" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Método Costeo">
                                            <PropertiesComboBox DataSourceID="odsMetodoCosteo" ValueField="MetodoCosteoID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="FamiliaProductoID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Familia">
                                            <PropertiesComboBox DataSourceID="odsFamiliaProducto" ValueField="FamiliaProductoID" TextField="Nombre">
                                            </PropertiesComboBox>                                            
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
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
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
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
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Almacén" ColSpan="1">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="ddlDetalleAlmacen" runat="server" ClientInstanceName="ddlDetalleAlmacen" ValueField="AlmacenID" TextField="Nombre" ValueType="System.Int32" Width="100%" DataSourceID="odsAlmacen">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Concepto Egreso" ColSpan="1">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="ddlDetalleConceptoEgreso" ClientInstanceName="ddlDetalleConceptoEgreso" ValueField="ConceptoEgresoID" TextField="Nombre" ValueType="System.Int32" runat="server" Width="100%" DataSourceID="odsConceptoEgreso">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Cuenta Contable" ColSpan="1">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="ddlDetalleCuentaContable" ClientInstanceName="ddlDetalleCuentaContable" ValueField="CuentaContableID" TextField="Nombre" ValueType="System.Int32" runat="server" Width="100%" DataSourceID="odsCuentaContable">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Descripción" ColSpan="2" ColumnSpan="2">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtDetalleDescripcion" ClientInstanceName="txtDetalleDescripcion" runat="server" Width="100%" MaxLength="50">
                                    <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="RequisicionDetalle">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem ColSpan="1" ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnAgregarDetalle" runat="server" AutoPostBack="False" Width="100%" Text="Agregar" ClientInstanceName="btnAgregarDetalle">
                                    <ClientSideEvents Click="function(s, e) {AgregarRequisicionDetalle();}" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxGridView ID="gvRequisicionDetalle" runat="server" AutoGenerateColumns="False"  ClientInstanceName="gvRequisicionDetalle" OnCustomCallback="gvRequisicionDetalle_CustomCallback">
                           
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
                                <dx:GridViewDataTextColumn Caption=" " FieldName="Renglon" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Width="130px">
                                    <Settings AllowAutoFilter="False" />
                                    <DataItemTemplate>
                                        <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("Renglon", "javascript:EliminarRequisicionDetalle({0});") %>' RenderMode="Link" Text="Eliminar">
                                            <Image IconID="actions_cancel_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("Renglon", "javascript:EditarRequisicionDetalle({0});") %>' RenderMode="Link" Text="Editar">
                                            <Image IconID="actions_editname_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                    </DataItemTemplate>
                                    <FilterTemplate>                                        
                                    </FilterTemplate>
                                    <FilterCellStyle HorizontalAlign="Center"></FilterCellStyle>
                                </dx:GridViewDataTextColumn>                               
                                <dx:GridViewDataTextColumn FieldName="Renglon" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Cantidad" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn ShowInCustomizationForm="True" VisibleIndex="10" FieldName="DescripcioAdicional">
                                </dx:GridViewDataTextColumn>
                                
                                <dx:GridViewDataComboBoxColumn FieldName="ProductoID" ShowInCustomizationForm="True" VisibleIndex="2">
                                    <PropertiesComboBox DataSourceID="odsProducto" TextField="Nombre" ValueField="ProductoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="UnidadID" ShowInCustomizationForm="True" VisibleIndex="4">
                                    <PropertiesComboBox DataSourceID="odsUnidad" TextField="Nombre" ValueField="UnidadID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="AlmacenID" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="odsAlmacen" TextField="Nombre" ValueField="AlmacenID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ConceptoEgresoID" ShowInCustomizationForm="True" VisibleIndex="7">
                                    <PropertiesComboBox DataSourceID="odsConceptoEgreso" TextField="Nombre" ValueField="ConceptoEgresoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="CuentaContableID" ShowInCustomizationForm="True" VisibleIndex="9">
                                    <PropertiesComboBox DataSourceID="odsCuentaContable" TextField="Nombre" ValueField="CuentaContableID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                
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
                                    <ClientSideEvents Click="function(s, e) {CancelarEdicionRequisicion();}" />
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
                                    <ClientSideEvents Click="function(s, e) {GuardarRequisicion();}" />
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
    <dx:ASPxPopupControl ID="PopupCatalogo" runat="server" ClientInstanceName="PopupCatalogo" ContentUrl="~/Sistema/Compras/Catalogos/Producto_Listado.aspx?hidenavigation=1" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="true" AllowResize="true" CloseAction="CloseButton">
        <%--<ClientSideEvents Closing="function(s) {s.SetContentHtml(null); }" />--%>
    </dx:ASPxPopupControl>



<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Personal" ID="odsSolicitante">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Sucursal" ID="odsSucursal">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.CentroCosto" ID="odsCentroCosto">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Area" ID="odsArea">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odEstatusDocumento" runat="server" SelectMethod="ListadoTipoDocumentoID" TypeName="Cosmos.Compras.Api.Client.EstatusDocumento">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="tipoDocumentoID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" ID="odsExplosion"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Producto" ID="odsProducto">    
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Unidad" ID="odsUnidad"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Marca" ID="odsMarca"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.FamiliaProducto" ID="odsFamiliaProducto"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.TipoProducto" ID="odsTipoProducto">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.MetodoCosteo" ID="odsMetodoCosteo"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.ClaseProducto" ID="odsClaseProducto"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.NivelProducto" ID="odsNivelProducto"></asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Almacen" ID="odsAlmacen">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.ConceptoEgreso" ID="odsConceptoEgreso">
    <SelectParameters>
        <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.CuentaContable" ID="odsCuentaContable"></asp:ObjectDataSource>

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
                                                <dx:ASPxComboBox ID="ddlFiltroSolicitante" ClientInstanceName="ddlFiltroSolicitante" runat="server" DataSourceID="odsSolicitante" TextField="NombreCompleto" ValueField="PersonalID" ValueType="System.Int32">
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
        AutoGenerateColumns="False" KeyFieldName="RequisicionEncabezadoID" Width="100%" OnCustomCallback="Grid_CustomCallback" >
        
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
            <dx:GridViewDataTextColumn Caption=" " FieldName="RequisicionEncabezadoID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Width="130px">
                <Settings AllowAutoFilter="False" />
                <DataItemTemplate>
                     <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("RequisicionEncabezadoID", "javascript:Eliminar({0});") %>' RenderMode="Link" Text="Eliminar">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("RequisicionEncabezadoID", "javascript:Editar({0});") %>' RenderMode="Link" Text="Editar">
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
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Movimientos" FieldName="Movimientos" VisibleIndex="2" Width="120px">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Fecha" FieldName="Fecha" VisibleIndex="3" Width="300px" PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Area" FieldName="Area" VisibleIndex="4" Width="120px">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Estatus" FieldName="EstatusDocumento" VisibleIndex="5">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
