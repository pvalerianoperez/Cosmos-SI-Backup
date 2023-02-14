

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Producto_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Compras.Producto_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
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
        function EliminarConfirm(id) {
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
                   alert("eliminar=" + id);
                }                
            });
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
    <script type="text/javascript">

        //familia
        var familiaProductoID;
        function EditarFamiliaProducto(id) {
            familiaProductoID = id;
            cbpEditarFamiliaProducto.PerformCallback('EDITAR|' + id);
            gvProducto.PerformCallback('refresh');
        }
        function GuardarFamiliaProducto() {
            if (ASPxClientEdit.ValidateGroup('GuardarFamiliaProducto')) {
                cbpEditarFamiliaProducto.PerformCallback('GUARDAR');
            }
        }
        function EliminarFamiliaProducto() {
            swal({
                title: "¿Eliminar?",
                text: "Los datos no podrán ser recuperados.",
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
                        cbpEditarFamiliaProducto.PerformCallback('ELIMINAR');
                    }
                });            
        }
        function cbpEditarFamiliaProductoEndCallback(message, refresh, show) {
            if (message != "") {
                swal("¡Error!", message, "error");
            }
            if (refresh == "1") {
                tvFamiliaProducto.PerformCallback('refresh');
                gvProducto.PerformCallback('refresh');
            }
        }

        //subfamilias (popup)
        function AgregarSubFamiliaProducto() {            
            txtSubFamiliaNombre.SetText('');
            txtSubFamiliaNombreCorto.SetText('');
            txtSubFamiliaClave.SetText('');
            if (!PopupSubFamilia.IsVisible()) { PopupSubFamilia.Show(); }
        }
        
        function GuardarSubFamiliaProducto() {
            if (ASPxClientEdit.ValidateGroup('GuardarSubFamiliaProducto')) {
                cbpEditarSubFamiliaProducto.PerformCallback('GUARDAR');
            }
        }
        function cbpEditarSubFamiliaProductoEndCallback(message, refresh, show) {
            if (message != "") {
                swal("¡Error!", message, "error");
            }
            if (refresh == "1") {
                tvFamiliaProducto.PerformCallback('refresh');
                gvProducto.PerformCallback('refresh');
                
            }
            if (show == "1") {
                if (!PopupSubFamilia.IsVisible()) { PopupSubFamilia.Show(); }
            } else {
                if (PopupSubFamilia.IsVisible()) { PopupSubFamilia.Hide(); }
            }
        }

        //productos 
        function EditarProducto(id) {
            //if (familiaProductoID > 0) {
                txtProductoNombre.SetText('');
                txtProductoNombreCorto.SetText('');
                txtProductoClave.SetText('')
                ddlFamiliaProducto.SetSelectedIndex(-1);
                ddlUnidadID.SetSelectedIndex(-1);

                ddlClaseID.SetSelectedIndex(-1);
                ddlTipoProductoID.SetSelectedIndex(-1);
                ddlNivelProductoID.SetSelectedIndex(-1);
                ddlMetodoCosteoID.SetSelectedIndex(-1);
                chkManejaLotes.SetChecked(false);
                chkManejaSeries.SetChecked(false);
                ddlEstatusProductoID.SetSelectedIndex(-1);
                if (id < 0) {
                    if (PopupProducto.IsVisible()) { PopupProducto.Hide(); }
                } else {
                    cbpEditarProducto.PerformCallback('EDITAR|' + id);
                    if (!PopupProducto.IsVisible()) { PopupProducto.Show(); }
                }
            //}
        }
        function GuardarProducto() {
            if (ASPxClientEdit.ValidateGroup('GuardarProducto')) {
                gvProductoAlmacen.UpdateEdit();
                cbpEditarProducto.PerformCallback('GUARDAR');
            }
        }
        function EliminarProducto(id) {
            swal({
                title: "¿Eliminar?",
                text: "Los datos no podrán ser recuperados.",
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
                        cbpEditarProducto.PerformCallback('ELIMINAR|'+id);
                    }
                });
        }
        function cbpEditarProductoEndCallback(message, refresh, refreshAlmacenes, show) {
            if (message != "") {
                swal("¡Error!", message, "error");
            }
            if (refresh == "1") {                
                gvProducto.PerformCallback('refresh');
            }
            if (refreshAlmacenes == "1") {
                gvProductoAlmacen.PerformCallback('refresh');
            }
            if (show == "1") {
                if (!PopupProducto.IsVisible()) { PopupProducto.Show(); }
            } else {
                if (PopupProducto.IsVisible()) { PopupProducto.Hide(); }
            }
        }

        function AgregarDetalleEmpresa() {
            if (ASPxClientEdit.ValidateGroup('DetalleEmpresa')) {
                cbpEditarProducto.PerformCallback('DETALLE_EMPRESA');
            }
        }
        function EditarProductoEmpresa(productoEmpresaID) {
            cbpEditarProducto.PerformCallback("EDITAR_EMPRESA|" + productoEmpresaID);
        }

        function EliminarProductoEmpresa(productoEmpresaID) {
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
                        cbpEditarProducto.PerformCallback("ELIMINAR_EMPRESA|" + productoEmpresaID);
                    }
                });

        }
        
        //splitter
        function OnSplitterPaneResized(s, e) {
            var name = e.pane.name;
            switch (name) {
                case 'tvContainer':
                    ResizeControl(tvFamiliaProducto, e.pane);
                    break;
                case 'gridContainer':
                    ResizeControl(gvProducto, e.pane);
                    break;
                case 'editContainer':
                    ResizeControl(flEditarFamiliaProducto, e.pane);
                    break;
            }                                        
        }

        function ResizeControl(control, splitterPane) {
            control.SetWidth(splitterPane.GetClientWidth());
            control.SetHeight(splitterPane.GetClientHeight());
        }
        
    </script>
    <dx:ASPxGridViewExporter ID="gvExportarProductos" runat="server" GridViewID="Grid"></dx:ASPxGridViewExporter>

    <asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Empresa" ID="odsEmpresa"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsFamilia" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.FamiliaProducto" UpdateMethod="Guardar">
        <UpdateParameters>
            <asp:Parameter Name="familiaProductoID" Type="Int32" />
            <asp:Parameter Name="padreID" Type="Int32" />
            <asp:Parameter Name="familiaClave" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="nombreCorto" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMarca" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Marca"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsUnidad" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Unidad"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsClaseProducto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.ClaseProducto"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoProducto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.TipoProducto">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsNivelProducto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.NivelProducto"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMetodoCosteo" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.MetodoCosteo"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsAlmacen" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Almacen">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <dx:ASPxPopupControl ID="PopupSubFamilia" runat="server" ClientInstanceName="PopupSubFamilia" CloseAction="CloseButton" Width="300px" Modal="true" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Agregar SubFamilia">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarSubFamiliaProducto" ClientInstanceName="cbpEditarSubFamiliaProducto" runat="server" OnCallback="cbpEditarSubFamiliaProducto_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditarSubFamiliaProducto" runat="server" ClientInstanceName="flEditarSubFamiliaProducto" ShowItemCaptionColon="False" Width="100%">
                    <Items>
                        <dx:LayoutItem Caption="Nombre" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtSubFamiliaNombre" runat="server" ClientInstanceName="txtSubFamiliaNombre" MaxLength="50" Width="100%">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="GuardarSubFamiliaProducto">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Nombre Corto" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtSubFamiliaNombreCorto" runat="server" ClientInstanceName="txtSubFamiliaNombreCorto" MaxLength="20" Width="100%">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="GuardarSubFamiliaProducto">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Clave" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtSubFamiliaClave" runat="server" ClientInstanceName="txtSubFamiliaClave" MaxLength="20" Width="100%">
                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidationGroup="GuardarSubFamiliaProducto">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnGuardarSubFamilia" runat="server" AutoPostBack="False" Text="Guardar los cambios" ValidationGroup="GuardarSubFamiliaProducto" Width="100%">
                                        <ClientSideEvents Click="function(s, e) {GuardarSubFamiliaProducto();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>
                                        <Paddings Padding="5px" />
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <Paddings PaddingTop="10px" />
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarSubFamiliaProductoEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show);}" />
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="PopupProducto" runat="server" ClientInstanceName="PopupProducto" CloseAction="CloseButton" HeaderText="Producto" Modal="True" Width="900px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="true" AllowResize="true">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <div style="padding-bottom:15px;">
        <dx:ASPxButton ID="btnEditarProductoCancelar" runat="server" AutoPostBack="False" Text="Cancelar" Width="100px" RenderMode="Secondary">
            <ClientSideEvents Click="function(s, e) {EditarProducto(-1);}" />
            <Image IconID="actions_reset_16x16">
            </Image>
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnEditarProductoGuardar" runat="server" AutoPostBack="False" Text="Guardar" ValidationGroup="GuardarProducto" Width="100px" RenderMode="Secondary">
            <ClientSideEvents Click="function(s, e) {GuardarProducto();}" />
            <Image IconID="actions_apply_16x16">
            </Image>
        </dx:ASPxButton>        
    </div>
    <dx:ASPxCallbackPanel ID="cbpEditarProducto" runat="server" ClientInstanceName="cbpEditarProducto" OnCallback="cbpEditarProducto_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditarProducto" runat="server" ShowItemCaptionColon="False" Width="100%">
                    <Items>
                        <dx:TabbedLayoutGroup ColSpan="1" ActiveTabIndex="1">
                            <Items>
                                <dx:LayoutGroup Caption="Datos Generales" ColCount="4" ColSpan="1" ColumnCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Nombre" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtProductoNombre" runat="server" ClientInstanceName="txtProductoNombre" Width="100%" >
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Nombre Corto" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtProductoNombreCorto" runat="server" ClientInstanceName="txtProductoNombreCorto" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Clave" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtProductoClave" runat="server" ClientInstanceName="txtProductoClave" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Familia" ColSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlFamiliaProducto" runat="server" ClientInstanceName="ddlFamiliaProducto" DataSourceID="odsFamilia" TextField="NombreCompleto" ValueField="FamiliaProductoID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Marca" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlMarcaID" runat="server" ClientInstanceName="ddlMarcaID" DataSourceID="odsMarca" TextField="Nombre" ValueField="MarcaID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Unidad" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlUnidadID" runat="server" ClientInstanceName="ddlUnidadID" DataSourceID="odsUnidad" TextField="Nombre" ValueField="UnidadID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Clase" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlClaseID" runat="server" ClientInstanceName="ddlClaseID" DataSourceID="odsClaseProducto" TextField="Nombre" ValueField="ClaseProductoID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Tipo" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlTipoProductoID" runat="server" ClientInstanceName="ddlTipoProductoID" DataSourceID="odsTipoProducto" TextField="Nombre" ValueField="TipoProductoID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Nivel" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlNivelProductoID" runat="server" ClientInstanceName="ddlNivelProductoID" DataSourceID="odsNivelProducto" TextField="Nombre" ValueField="NivelProductoID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Método Costeo" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlMetodoCosteoID" runat="server" ClientInstanceName="ddlMetodoCosteoID" DataSourceID="odsMetodoCosteo" TextField="Nombre" ValueField="MetodoCosteoID" ValueType="System.Int32" Width="100%">
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Lotes" ColSpan="1" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxCheckBox ID="chkManejaLotes" runat="server" CheckState="Unchecked" ClientInstanceName="chkManejaLotes" Text="Maneja Lotes">
                                                    </dx:ASPxCheckBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Series" ColSpan="1" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxCheckBox ID="chkManejaSeries" runat="server" CheckState="Unchecked" ClientInstanceName="chkManejaSeries" Text="Maneja Series">
                                                    </dx:ASPxCheckBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        
                                        <dx:LayoutItem Caption="Estatus" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="ddlEstatusProductoID" runat="server" ClientInstanceName="ddlEstatusProductoID" SelectedIndex="1" ValueType="System.Int32" Width="100%">
                                                        <Items>
                                                            <dx:ListEditItem Text="Inactivo" Value="2" />
                                                            <dx:ListEditItem Selected="True" Text="Activo" Value="1" />
                                                        </Items>
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="El dato es requerido." ValidationGroup="GuardarProducto">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Almacenes" ColSpan="1">
                                    <Items>
                                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">                                                    
                                                    <dx:ASPxGridView ID="gvProductoAlmacen" 
                                                    ClientInstanceName="gvProductoAlmacen" 
                                                    runat="server" 
                                                    AutoGenerateColumns="False" 
                                                    KeyFieldName="ProductoAlmacenID"
                                                    Width="100%" 
                                                    OnBatchUpdate="gvProductoAlmacen_BatchUpdate"
                                                    OnCustomCallback="gvProductoAlmacen_CustomCallback" >
                                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                                    <SettingsEditing Mode="Batch">
                                                        <BatchEditSettings HighlightDeletedRows="False" />
                                                    </SettingsEditing>
                                                    <Settings ShowFilterRow="True" VerticalScrollBarMode="Auto" ShowStatusBar="Hidden" />                
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
                                                        <dx:GridViewDataComboBoxColumn Caption="Almacén" PropertiesComboBox-DataSourceID="odsAlmacen" FieldName="AlmacenID" ReadOnly="False" ShowInCustomizationForm="True" VisibleIndex="1" MinWidth="200" Width="200px" PropertiesComboBox-ValueField="AlmacenID" 
                                                            PropertiesComboBox-TextField="Nombre" PropertiesComboBox-ValidationSettings-RequiredField-IsRequired="true">
<PropertiesComboBox TextField="Nombre" ValueField="AlmacenID">
<ValidationSettings>
<RequiredField IsRequired="True"></RequiredField>
</ValidationSettings>
</PropertiesComboBox>

                                                            <Settings AutoFilterCondition="Contains" />
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Máximo" FieldName="Maximo" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="2" Width="100px">
                                                            <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="n2" MaxLength="4" NumberFormat="Custom">
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="El dato es requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                            <Settings AutoFilterCondition="Contains" />
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Mínimo" FieldName="Minimo" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="3" Width="100px">
                                                            <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="n2" MaxLength="4" NumberFormat="Custom">
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="El dato es requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                            <Settings AutoFilterCondition="Contains" />
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Reorden" FieldName="Reorden" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="n2" MaxLength="4" NumberFormat="Custom">
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="El dato es requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesSpinEdit>
                                                            <Settings AutoFilterCondition="Contains" />
                                                            <CellStyle HorizontalAlign="Left">
                                                            </CellStyle>
                                                        </dx:GridViewDataSpinEditColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:TabbedLayoutGroup>
                        <dx:LayoutGroup ColCount="2" ColSpan="1" ColumnCount="2" GroupBoxDecoration="None" ShowCaption="False">
                            <Items>
                                <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarProductoEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_refreshAlmacenes, s.cp_show);}" />
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxSplitter ID="ASPxSplitter2" runat="server" FullscreenMode="True" Height="100%" Width="100%">
        <Panes>
            <dx:SplitterPane>
                <Panes>
                    <dx:SplitterPane Name="tvContainer" AutoWidth="True" Size="300px">
                        <ContentCollection>
                            <dx:SplitterContentControl runat="server">
                                <dx:ASPxTreeList ID="tvFamiliaProducto" runat="server" AutoGenerateColumns="False" ClientInstanceName="tvFamiliaProducto" 
                                    KeyFieldName="FamiliaProductoID" ParentFieldName="PadreID" Settings-ShowRoot="true" OnCustomCallback="tvFamiliaProducto_CustomCallback">
                                    <Columns>
                                        <dx:TreeListTextColumn AutoFilterCondition="Default" FieldName="Nombre" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0">
                                            <DataCellTemplate>
                                                <dx:ASPxButton runat="server" ID="lblFamilia" Text='<%#Eval("Nombre")%>' AutoPostBack="false" RenderMode="Link" OnClick='<%# Eval("FamiliaProductoID", "javascript:EditarFamiliaProducto({0});") %>' ForeColor="Black" Font-Underline="false"></dx:ASPxButton>                                                                                                
                                            </DataCellTemplate>
                                        </dx:TreeListTextColumn>
                                    </Columns>
                                    <Settings ShowColumnHeaders="False" />
                                    <SettingsBehavior AllowFocusedNode="True" AutoExpandAllNodes="True" />
                                    <SettingsEditing AllowNodeDragDrop="True">
                                    </SettingsEditing>                                   
                                    <SettingsPopup>
                                    <HeaderFilter MinHeight="140px"></HeaderFilter>
                                    </SettingsPopup>
                                </dx:ASPxTreeList>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                    </dx:SplitterPane>
                    <dx:SplitterPane Name="editContainer" Size="300px">
                        <ContentCollection>
                            <dx:SplitterContentControl runat="server">
                                <dx:ASPxCallbackPanel ID="cbpEditarFamiliaProducto" ClientInstanceName="cbpEditarFamiliaProducto" runat="server" Width="100%" OnCallback="cbpEditarFamiliaProducto_Callback">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <dx:ASPxFormLayout ID="flEditarFamilia" ClientInstanceName="flEditarFamiliaProducto" runat="server" ShowItemCaptionColon="False" Width="100%">
                                                <Items>
                                                    <dx:LayoutItem Caption="Nombre" ColSpan="1">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtNombre" ClientInstanceName="txtNombre" MaxLength="50" runat="server" Width="100%">
                                                                    <ValidationSettings ValidationGroup="GuardarFamiliaProducto" ErrorDisplayMode="ImageWithTooltip">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Nombre Corto" ColSpan="1">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtNombreCorto" ClientInstanceName="txtNombreCorto" MaxLength="20" runat="server" Width="100%">
                                                                    <ValidationSettings ValidationGroup="GuardarFamiliaProducto" ErrorDisplayMode="ImageWithTooltip">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="Clave" ColSpan="1">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxTextBox ID="txtClave" ClientInstanceName="txtClave" MaxLength="20" runat="server" Width="100%">
                                                                    <ValidationSettings ValidationGroup="GuardarFamiliaProducto" ErrorDisplayMode="ImageWithTooltip">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxButton ID="btnAgregarSubFamilia" runat="server" AutoPostBack="False" Text="Agregar Subfamilia" Width="100%" Enabled="False">
                                                                    <Image IconID="actions_converttorange_16x16">
                                                                    </Image>
                                                                    <ClientSideEvents Click="function(s, e) {AgregarSubFamiliaProducto();}" />
                                                                    <Paddings Padding="5px" />
                                                                </dx:ASPxButton>
                                                                
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <Paddings PaddingTop="10px" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxButton ID="btnGuardarFamilia" runat="server" AutoPostBack="False" Text="Guardar los cambios" Width="100%" ValidationGroup="GuardarFamilia" Enabled="False">
                                                                    <ClientSideEvents Click="function(s, e) {GuardarFamiliaProducto();}" />
                                                                    <Image IconID="actions_apply_16x16">
                                                                    </Image>
                                                                    <Paddings Padding="5px" />
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <Paddings PaddingTop="10px" />
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxButton ID="btnEliminarFamilia" runat="server" AutoPostBack="False" Text="Eliminar" Width="100%" Enabled="False">
                                                                    <ClientSideEvents Click="function(s, e) {EliminarFamiliaProducto();}" />
                                                                    <Image IconID="actions_trash_16x16">
                                                                    </Image>
                                                                    <Paddings Padding="5px" />
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                        <Paddings PaddingTop="10px" />
                                                    </dx:LayoutItem>
                                                </Items>
                                                <SettingsItemCaptions Location="Top" />
                                            </dx:ASPxFormLayout>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                    <ClientSideEvents EndCallback="function(s, e) {cbpEditarFamiliaProductoEndCallback(s.cp_errorMessage, s.cp_refresh);}" />
                                </dx:ASPxCallbackPanel>
                            </dx:SplitterContentControl>
                        </ContentCollection>
                    </dx:SplitterPane>
                </Panes>
                <ContentCollection>
<dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
</ContentCollection>
            </dx:SplitterPane>
            <dx:SplitterPane Name="gridContainer">
                <ContentCollection>
                    <dx:SplitterContentControl runat="server">
                        <asp:ObjectDataSource ID="odsProducto" runat="server" SelectMethod="ListadoFamiliaProducto" TypeName="Cosmos.Compras.Api.Client.Producto">
                            <SelectParameters>
                                <asp:SessionParameter Name="familiaProductoID" SessionField="Producto_Listado_FamiliaProductoID" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <dx:ASPxGridView ID="gvProducto" runat="server" AutoGenerateColumns="False" ClientInstanceName="gvProducto" DataSourceID="odsProducto" 
                            KeyFieldName="ProductoID" OnBatchUpdate="Grid_BatchUpdate" Width="100%" OnCustomCallback="gvProducto_CustomCallback">
                            <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
                            <SettingsPager Mode="ShowAllRecords">
                            </SettingsPager>
                            <Settings HorizontalScrollBarMode="Auto" ShowFilterRow="True" VerticalScrollBarMode="Visible" />
                            <SettingsPopup>
                                <HeaderFilter MinHeight="140px">
                                </HeaderFilter>
                            </SettingsPopup>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption=" " FieldName="ProductoID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" CellStyle-Wrap="False" MinWidth="200" Width="200px">
                                    <Settings AllowAutoFilter="False" />
                                    <DataItemTemplate>
                                        <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("ProductoID", "javascript:EliminarProducto({0});") %>' RenderMode="Secondary" Text="Eliminar" Width="90px">
                                            <Image IconID="actions_trash_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("ProductoID", "javascript:EditarProducto({0});") %>' RenderMode="Secondary" Text="Editar" Width="90px">
                                            <Image IconID="edit_edit_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                    </DataItemTemplate>
                                    <HeaderTemplate>
                                        <dx:ASPxButton ID="btnProductoNuevo" ClientInstanceName="btnProductoNuevo" runat="server" AutoPostBack="False" RenderMode="Secondary" Text="Nuevo" VerticalAlign="Middle" Width="100%">
                                            <ClientSideEvents Click="function(s, e) {EditarProducto(0);}" />
                                            <Image IconID="actions_addfile_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                    </HeaderTemplate>
                                    <FilterCellStyle HorizontalAlign="Center"></FilterCellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Marca" FieldName="MarcaID" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesComboBox DataSourceID="odsMarca" TextField="Nombre" ValueField="MarcaID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="Familia" FieldName="FamiliaProductoNombreCompleto" MinWidth="300" ShowInCustomizationForm="True" VisibleIndex="4" Width="300px">
                                    <PropertiesTextEdit MaxLength="80">
                                    </PropertiesTextEdit>
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" MinWidth="300" ShowInCustomizationForm="True" VisibleIndex="4" Width="300px">
                                    <PropertiesTextEdit MaxLength="80">
                                    </PropertiesTextEdit>
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Unidad" FieldName="UnidadID" ShowInCustomizationForm="True" VisibleIndex="6" MinWidth="100" Width="100px">
                                    <PropertiesComboBox DataSourceID="odsUnidad" TextField="Nombre" ValueField="UnidadID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Clase Producto" FieldName="ClaseProductoID" ShowInCustomizationForm="True" VisibleIndex="7" MinWidth="100" Width="100px">
                                    <PropertiesComboBox DataSourceID="odsClaseProducto" TextField="Nombre" ValueField="ClaseProductoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Tipo Producto" FieldName="TipoProductoID" ShowInCustomizationForm="True" VisibleIndex="8" MinWidth="100" Width="100px">
                                    <PropertiesComboBox DataSourceID="odsTipoProducto" TextField="Nombre" ValueField="TipoProductoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Nivel Producto" FieldName="NivelProductoID" ShowInCustomizationForm="True" VisibleIndex="9" MinWidth="100" Width="100px">
                                    <PropertiesComboBox DataSourceID="odsNivelProducto" TextField="Nombre" ValueField="NivelProductoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Metodo Costeo" FieldName="MetodoCosteoID" ShowInCustomizationForm="True" VisibleIndex="10" MinWidth="100">
                                    <PropertiesComboBox DataSourceID="odsMetodoCosteo" TextField="Nombre" ValueField="MetodoCosteoID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </dx:SplitterContentControl>
                </ContentCollection>                
            </dx:SplitterPane>
        </Panes>
        <ClientSideEvents PaneResized="OnSplitterPaneResized" />
    </dx:ASPxSplitter>
    <%--<asp:ObjectDataSource ID="odsFamiliaProducto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.FamiliaProducto"></asp:ObjectDataSource>--%>


</asp:Content>

