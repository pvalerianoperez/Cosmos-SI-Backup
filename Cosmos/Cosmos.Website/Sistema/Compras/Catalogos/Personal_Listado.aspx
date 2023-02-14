<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Personal_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Catalogos.Personal_Listado" %>
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
        $(function () {
            resize_grid_pane();
            $(window).resize(resize_grid_pane);
        });
        function resize_grid_pane() {
            var divGrid = $(".dxgv");
            var divRows = $(".dxgvCSD");
            var divHeader = $(".dxgvHSDC");
            var hEncabezado = $("#divEncabezado").height();
            if (divRows != null) {
                var offset = divRows.offset;
                remaining_height = parseInt($(window).height() - hEncabezado - 110);
                divRows.height(remaining_height);
                //divGrid.width($(window).width() - 200);
                //divRows.width(divGrid.width());
                //divHeader.width(divGrid.width());
            }
        }

        function HabilitaDetalleCasado() {
            chkCasadoCivil.SetVisible(false);
            chkCasadoIglesia.SetVisible(false);
            if (ddlEstadoCivil.GetValue() == "1") {
                chkCasadoCivil.SetVisible(true);
                chkCasadoIglesia.SetVisible(true);
            }
        }

        function Editar(id) {
            //primero limpia todo el show
            hfPersonal.Clear();
            txtRFC.SetText('');
            txtCURP.SetText('');
            txtNombres.SetText('');
            txtApellidoPaterno.SetText('');
            txtApellidoMaterno.SetText('');
            txtSobrenombre.SetText('');
            txtIniciales.SetText('');
            ddlSexo.SetSelectedIndex(-1);
            dtFechaNacimiento.SetText('');
            ddlCiudadNacimiento.SetValue(null);
            ddlEstadoCivil.SetSelectedIndex(-1);
            chkCasadoCivil.SetChecked(false);
            chkCasadoIglesia.SetChecked(false); 
            HabilitaDetalleCasado()            
            ddlEstatus.SetSelectedIndex(-1);
            //ddlEmpresa.SetSelectedIndex(-1);
            ddlArea.SetSelectedIndex(-1);
            ddlPuesto.SetSelectedIndex(-1);
            ddlHorarioPersonal.SetSelectedIndex(-1);
            ddlJefeInmediato.SetSelectedIndex(-1);
            ddlCentroCosto.SetSelectedIndex(-1);
            popupPersonal.Show();
            if (id > 0) {                
                cbpPersonal.PerformCallback("EDITAR|" + id);            
            }
        }
        function Eliminar(id) {
            swal({
                title: "¡Eliminar!",
                text: "¿Desea eliminar el empleado?",
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
                        cbpPersonal.PerformCallback("ELIMINAR|" + id);
                    }
                }); 
        }
        function Cancelar() {
            popupPersonal.Hide();
        }

        var guardarFlag; 

        function Guardar() {            
            var validacionOk = ASPxClientEdit.ValidateGroup('Personal');
            if (validacionOk) {
                guardarFlag = 1;
                gvEndCallback('');

                //if (gvPersonalMail.batchEditApi.HasChanges()) {
                //    gvPersonalMail.UpdateEdit();
                //} else {
                //    if (gvPersonalTelefonos.batchEditApi.HasChanges()) {
                //        gvPersonalTelefonos.UpdateEdit();
                //    } else {
                //        cbpPersonal.PerformCallback("GUARDAR");
                //    }
                //}
                
                //gvPersonalTelefonos.UpdateEdit();
                //cbpPersonal.PerformCallback("GUARDAR");
            }            
        }

        function gvEndCallback(id) {
            if (guardarFlag == 1) {
                switch (id) {
                    case '':
                        if (gvPersonalMail.batchEditApi.HasChanges()) {
                            gvPersonalMail.UpdateEdit();
                        } else {
                            gvEndCallback('gvPersonalMail');
                        }
                        break;
                    case 'gvPersonalMail':
                        if (gvPersonalTelefonos.batchEditApi.HasChanges()) {
                            gvPersonalTelefonos.UpdateEdit();
                        } else {
                            gvEndCallback('gvPersonalTelefonos');
                        }  
                        break;
                    case 'gvPersonalTelefonos':                        
                        cbpPersonal.PerformCallback("GUARDAR");
                        guardarFlag = 0;                        
                        break;
                }
            }
            
        }


        function cbpPersonalEndCallback(errorMessage, refresh, show, grid, popup, habilitaDetalleCasado) {
            if (errorMessage == null) { errorMessage = ''; }
            if (errorMessage != '') {
                swal("¡Error!", errorMessage, "error");
            }
            if (grid != null) {
                if (refresh == '1') {                    
                    grid.PerformCallback('refresh');                    
                }
            }
            if (popup != null) {
                if (show == '1') {
                    if (!popup.IsVisible()) { popup.Show(); }
                } else {
                    if (popup.IsVisible()) { popup.Hide(); }
                }
            }
            if (habilitaDetalleCasado) {
                HabilitaDetalleCasado();
            }
        }

    </script>
    <dx:ASPxGridView ID="gvPersonal" ClientInstanceName="gvPersonal" runat="server" 
        AutoGenerateColumns="False" KeyFieldName="PersonalID"  
        DataSourceID="odsPersonal" Width="100%" OnCustomCallback="gvPersonal_CustomCallback"  >
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
        <SettingsBehavior ConfirmDelete="False" />
        <Columns>
            <dx:GridViewDataTextColumn Caption=" " FieldName="RequisicionEncabezadoID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="130px">
                <Settings AllowAutoFilter="False" />
                <DataItemTemplate>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("PersonalID", "javascript:Eliminar({0});") %>' RenderMode="Link" Text="Eliminar" Visible='<%# ((Cosmos.Website.Recursos.MasterPages.SitioProtegido)Page.Master).PermisoAccion("ELIMINAR")%>'>
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnEditar" runat="server" AutoPostBack="False" OnClick='<%# Eval("PersonalID", "javascript:Editar({0});") %>' RenderMode="Link" Text="Editar" Visible='<%# ((Cosmos.Website.Recursos.MasterPages.SitioProtegido)Page.Master).PermisoAccion("MODIFICAR")%>'>
                        <Image IconID="actions_editname_16x16">
                        </Image>
                    </dx:ASPxButton>
                </DataItemTemplate>
                <FilterTemplate>
                </FilterTemplate>
                <FilterCellStyle HorizontalAlign="Center">
                </FilterCellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="NombreCompleto" VisibleIndex="4">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Empresa" FieldName="EmpresaID" ReadOnly="True" VisibleIndex="1" Width="150px">
                <PropertiesComboBox DataSourceID="odsEmpresa" TextField="Nombre" ValueField="EmpresaID">
                </PropertiesComboBox>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Puesto" FieldName="PuestoID" VisibleIndex="3" Width="150px">
                <PropertiesComboBox DataSourceID="odsPuesto" TextField="Nombre" ValueField="PuestoID">
                </PropertiesComboBox>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    
    <asp:ObjectDataSource ID="odsTipoMail" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.TipoMail"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoTelefono" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.TipoTelefono"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSexo" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.Sexo"></asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="Consultar" TypeName="Cosmos.Seguridad.Api.Client.Empresa">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>   

    <asp:ObjectDataSource ID="odsPersonal" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Personal">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>    

    <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Area">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>   
    <asp:ObjectDataSource ID="odsPuesto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Puesto">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsHorarioPersonal" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.HorarioPersonal">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>   
    <asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Ciudad" ID="odsCiudad"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEstadoCivil" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.EstadoCivil"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEstatusPersonal" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.EstatusPersonal"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCentroCosto" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.CentroCosto">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>   


    <asp:ObjectDataSource ID="odsEstatusTelefono" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.EstatusTelefono"></asp:ObjectDataSource>


    <dx:ASPxPopupControl ID="popupPersonal" ClientInstanceName="popupPersonal" Modal="true" runat="server" CloseAction="CloseButton"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" MinWidth="800" 
        MinHeight="550" Width="900" Height="550" AllowDragging="true" AllowResize="true">        
        <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <div style="height:100%;">
                <div style="margin:auto;">
                    <dx:ASPxButton runat="server" ID="btnEditarOK" ClientInstanceName="btnEditarOK" Text="Guardar los cambios" AutoPostBack="false">
                        <Image IconID="actions_apply_16x16"></Image>
                        <ClientSideEvents Click="function(s, e) {Guardar();}" />
                    </dx:ASPxButton>                
                </div>
                <div style="margin:auto;">
                    <dx:ASPxCallbackPanel ID="cbpPersonal" ClientInstanceName="cbpPersonal" runat="server" OnCallback="cbpPersonal_Callback">
                        <ClientSideEvents EndCallback="function(s, e) {cbpPersonalEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gvPersonal, popupPersonal, s.cp_HabilitaDetalleCasado );}" />
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxHiddenField runat="server" ID="hfPersonal" ClientInstanceName="hfPersonal"></dx:ASPxHiddenField>
                                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ShowItemCaptionColon="False">
                                    <Items>
                                        <dx:TabbedLayoutGroup ColSpan="1">
                                            <Items>
                                                <dx:LayoutGroup Caption="Datos Generales" ColCount="4" ColSpan="1" ColumnCount="4">
                                                    <Items>
                                                        <dx:LayoutItem Caption="RFC" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtRFC" runat="server" ClientInstanceName="txtRFC" Width="100%" MaxLength="13">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="CURP" ColSpan="3" ColumnSpan="3">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtCURP" runat="server" ClientInstanceName="txtCURP" Width="100%" MaxLength="18">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Nombre(s)" ColSpan="2" ColumnSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtNombres" runat="server" ClientInstanceName="txtNombres" Width="100%" MaxLength="50">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="ApellidoPaterno" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtApellidoPaterno" runat="server" ClientInstanceName="txtApellidoPaterno" Width="100%" MaxLength="50">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Apellido Materno" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtApellidoMaterno" runat="server" ClientInstanceName="txtApellidoMaterno" Width="100%" MaxLength="50">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Sobrenombre" ColSpan="2" ColumnSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtSobrenombre" runat="server" ClientInstanceName="txtSobrenombre" Width="100%" MaxLength="50">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Iniciales" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtIniciales" runat="server" ClientInstanceName="txtIniciales" Width="100%" MaxLength="6">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Sexo" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlSexo" runat="server" ClientInstanceName="ddlSexo" Width="100%" DataSourceID="odsSexo" ValueType="System.Int32" ValueField="SexoID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Fecha de Nacimiento" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxDateEdit ID="dtFechaNacimiento" runat="server" ClientInstanceName="dtFechaNacimiento" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100%">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxDateEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Ciudad de Nacimiento" ColSpan="3" ColumnSpan="3">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlCiudadNacimiento" runat="server" ClientInstanceName="ddlCiudadNacimiento" Width="100%" DataSourceID="odsCiudad" ValueType="System.Int32" ValueField="CiudadID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Estado Civil" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlEstadoCivil" runat="server" ClientInstanceName="ddlEstadoCivil" Width="100%" DataSourceID="odsEstadoCivil" ValueType="System.Int32" ValueField="EstadoCivilID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkCasadoCivil" runat="server" CheckState="Unchecked" ClientInstanceName="chkCasadoCivil" Text="Civil">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkCasadoIglesia" runat="server" CheckState="Unchecked" ClientInstanceName="chkCasadoIglesia" Text="Iglesia">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Estatus" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlEstatus" runat="server" ClientInstanceName="ddlEstatus" Width="100%" DataSourceID="odsEstatusPersonal" ValueType="System.Int32" ValueField="EstatusPersonalID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <%--<dx:LayoutItem Caption="Empresa" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlEmpresa" runat="server" ClientInstanceName="ddlEmpresa" Width="100%" DataSourceID="odsEmpresa" ValueType="System.Int32" ValueField="EmpresaID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>
                                                         <dx:LayoutItem Caption="Área" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlArea" runat="server" ClientInstanceName="ddlArea" Width="100%" DataSourceID="odsArea" ValueType="System.Int32" ValueField="AreaID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         <dx:LayoutItem Caption="Puesto" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlPuesto" runat="server" ClientInstanceName="ddlPuesto" Width="100%" DataSourceID="odsPuesto" ValueType="System.Int32" ValueField="PuestoID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         <dx:LayoutItem Caption="Horario" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlHorarioPersonal" runat="server" ClientInstanceName="ddlHorarioPersonal" Width="100%" DataSourceID="odsHorarioPersonal" ValueType="System.Int32" ValueField="HorarioPersonalID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Clave" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtClaveEmpleado" runat="server" ClientInstanceName="txtClaveEmpleado" Width="100%" MaxLength="10">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         <dx:LayoutItem Caption="Jefe Inmediato" ColSpan="2">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlJefeInmediato" runat="server" ClientInstanceName="ddlJefeInmediato" Width="100%" DataSourceID="odsPersonal" ValueType="System.Int32" ValueField="PersonalID" TextField="NombreCompleto">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Centro de Costos" ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ddlCentroCosto" runat="server" ClientInstanceName="ddlCentroCosto" Width="100%" DataSourceID="odsCentroCosto" ValueType="System.Int32" ValueField="CentroCostoID" TextField="Nombre">
                                                                        <ValidationSettings ValidationGroup="Personal" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>                                                                    
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Correo Electrónico" ColSpan="1">
                                                    <Items>
                                                        <dx:LayoutItem ColSpan="1" ShowCaption="False">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxGridView ID="gvPersonalMail" runat="server" AutoGenerateColumns="False" ClientInstanceName="gvPersonalMail"  KeyFieldName="PersonalMailID" 
                                                                        OnBatchUpdate="gvPersonalMail_BatchUpdate" 
                                                                        Width="100%">                                                                        
                                                                        <ClientSideEvents EndCallback="function(s, e) {gvEndCallback('gvPersonalMail');}" />                                                                        
                                                                        <SettingsPager Mode="ShowAllRecords">
                                                                        </SettingsPager>
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
                                                                            <HeaderFilter MinHeight="140px">
                                                                            </HeaderFilter>
                                                                        </SettingsPopup>
                                                                        <SettingsText BatchEditChangesPreviewDeletedValues="Eliminados" BatchEditChangesPreviewInsertedValues="Nuevos" BatchEditChangesPreviewUpdatedValues="Modificados" />
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" ShowDeleteButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="PersonalMailID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="50px">
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" MinWidth="300" ShowInCustomizationForm="True" VisibleIndex="2" Width="200px">
                                                                                <PropertiesTextEdit MaxLength="90">
                                                                                    <ValidationSettings>
                                                                                        <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="4" Width="120px">
                                                                            </dx:GridViewDataCheckColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoMailID" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                                                                <PropertiesComboBox MaxLength="20" DataSourceID="odsTipoMail" TextField="Nombre" ValueField="TipoMailID">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesComboBox>
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Comentarios" FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="5" Width="200px">
                                                                                <PropertiesTextEdit MaxLength="30">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Teléfonos" ColSpan="1">
                                                    <Items>
                                                        <dx:LayoutItem ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxGridView ID="gvPersonalTelefonos" runat="server" AutoGenerateColumns="False" ClientInstanceName="gvPersonalTelefonos"  
                                                                        KeyFieldName="PersonalTelefonoID" OnBatchUpdate="gvPersonalTelefonos_BatchUpdate" Width="100%">
                                                                        <ClientSideEvents EndCallback="function(s, e) {gvEndCallback('gvPersonalTelefonos');}" />
                                                                        <SettingsPager Mode="ShowAllRecords">
                                                                        </SettingsPager>
                                                                        <SettingsEditing Mode="Batch">
                                                                            <BatchEditSettings HighlightDeletedRows="False" />
                                                                        </SettingsEditing>
                                                                        <Settings ShowFilterRow="True" ShowStatusBar="Hidden" VerticalScrollBarMode="Auto" />
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
                                                                            <HeaderFilter MinHeight="140px">
                                                                            </HeaderFilter>
                                                                        </SettingsPopup>
                                                                        <SettingsText BatchEditChangesPreviewDeletedValues="Eliminados" BatchEditChangesPreviewInsertedValues="Nuevos" BatchEditChangesPreviewUpdatedValues="Modificados" />
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" ShowDeleteButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="100px">
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="PersonalTelefonoID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="50px">
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="No. Telefónico" FieldName="NumeroTelefonico" MinWidth="150" ShowInCustomizationForm="True" VisibleIndex="4" Width="150px">
                                                                                <PropertiesTextEdit MaxLength="10">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="7" Width="120px">
                                                                            </dx:GridViewDataCheckColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoTelefonoID" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="6" Width="120px">
                                                                                <PropertiesComboBox DataSourceID="odsTipoTelefono" MaxLength="20" TextField="Nombre" ValueField="TipoTelefonoID">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesComboBox>
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Comentarios" FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="8" Width="150px">
                                                                                <PropertiesTextEdit MaxLength="20">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="TelefonoID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="LADA" FieldName="LadaPais" ShowInCustomizationForm="True" VisibleIndex="3" Width="100px">
                                                                                <PropertiesTextEdit MaxLength="3">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Ext" FieldName="Extension" ShowInCustomizationForm="True" VisibleIndex="5" Width="100px">
                                                                                <PropertiesTextEdit MaxLength="6">
                                                                                </PropertiesTextEdit>
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Estatus" FieldName="EstatusTelefonoID" ShowInCustomizationForm="True" VisibleIndex="9" Width="80px">
                                                                                <PropertiesComboBox DataSourceID="odsEstatusTelefono" TextField="Nombre" ValueField="EstatusTelefonoID">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesComboBox>
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Domicilios" ColSpan="1">
                                                    <Items>
                                                        <dx:LayoutItem ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxGridView ID="gvPersonalDomicilios" runat="server" AutoGenerateColumns="False" ClientInstanceName="gvPersonalDomicilios" KeyFieldName="PersonalDomicilioID" OnBatchUpdate="gvPersonalDomicilios_BatchUpdate" Width="100%" OnRowDeleting="gvPersonalDomicilios_RowDeleting" OnRowInserting="gvPersonalDomicilios_RowInserting" OnRowUpdating="gvPersonalDomicilios_RowUpdating">
                                                                        <SettingsPager Mode="ShowAllRecords">
                                                                        </SettingsPager>
                                                                        <SettingsEditing Mode="PopupEditForm">
                                                                            <BatchEditSettings HighlightDeletedRows="False" />
                                                                        </SettingsEditing>
                                                                        <Settings ShowFilterRow="True" ShowStatusBar="Hidden" VerticalScrollBarMode="Auto" />
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
                                                                            <UpdateButton ButtonType="Secondary" RenderMode="Secondary" Text="Guardar los cambios">
                                                                                <Image IconID="actions_apply_16x16">
                                                                                </Image>
                                                                            </UpdateButton>
                                                                            <CancelButton ButtonType="Secondary" RenderMode="Secondary" Text="Cancelar los cambios">
                                                                                <Image IconID="actions_reset_16x16">
                                                                                </Image>
                                                                            </CancelButton>
                                                                            <EditButton  ButtonType="Secondary" RenderMode="Secondary" Text="Editar">
                                                                                <Image IconID="edit_edit_16x16">
                                                                                </Image>
                                                                                <Styles>
                                                                                    <Style Width="90px">
                                                                                    </Style>
                                                                                </Styles>
                                                                            </EditButton>
                                                                            <DeleteButton ButtonType="Secondary" RenderMode="Secondary" Text="Eliminar">
                                                                                <Image IconID="actions_trash_16x16">
                                                                                </Image>
                                                                                <Styles>
                                                                                    <Style Width="90px">
                                                                                    </Style>
                                                                                </Styles>
                                                                            </DeleteButton>
                                                                        </SettingsCommandButton>
                                                                        <SettingsPopup>
                                                                            <HeaderFilter MinHeight="140px">
                                                                            </HeaderFilter>
                                                                        </SettingsPopup>
                                                                        <SettingsText BatchEditChangesPreviewDeletedValues="Eliminados" BatchEditChangesPreviewInsertedValues="Nuevos" BatchEditChangesPreviewUpdatedValues="Modificados" />
                                                                        <Columns>
                                                                            <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="200px">
                                                                            </dx:GridViewCommandColumn>
                                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="PersonalDomicilioID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="50px">
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="No. Exterior" FieldName="NumeroExterior" MinWidth="300" ShowInCustomizationForm="True" VisibleIndex="5" Width="200px" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="20">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                                <Settings AutoFilterCondition="Contains" />
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="DomicilioID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="Calle" FieldName="Calle" ShowInCustomizationForm="True" VisibleIndex="4" Width="50px" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="50">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn Caption="No. Interior" FieldName="NumeroInterior" ShowInCustomizationForm="True" VisibleIndex="6" Width="50px" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="20">
                                                                                </PropertiesTextEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="PersonalID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="EntreCalle1" ShowInCustomizationForm="True" VisibleIndex="7" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="40">
                                                                                </PropertiesTextEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="EntreCalle2" ShowInCustomizationForm="True" VisibleIndex="8" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="40">
                                                                                </PropertiesTextEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="Colonia" ShowInCustomizationForm="True" VisibleIndex="10" Visible="False">
                                                                                <PropertiesTextEdit MaxLength="40">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesTextEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataComboBoxColumn Caption="Ciudad" FieldName="CiudadID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                <PropertiesComboBox DataSourceID="odsCiudad" TextField="NombreCompleto" ValueField="CiudadID">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesComboBox>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataComboBoxColumn>
                                                                            <dx:GridViewDataTextColumn FieldName="DomicilioCompleto" ShowInCustomizationForm="True" VisibleIndex="12" Caption="Domicilio">
                                                                                <EditFormSettings Visible="False" />
                                                                            </dx:GridViewDataTextColumn>
                                                                            <dx:GridViewDataSpinEditColumn FieldName="CodigoPostal" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="6" NumberType="Integer">
                                                                                    <ValidationSettings>
                                                                                        <RequiredField IsRequired="True" />
                                                                                    </ValidationSettings>
                                                                                </PropertiesSpinEdit>
                                                                                <EditFormSettings Visible="True" />
                                                                            </dx:GridViewDataSpinEditColumn>
                                                                        </Columns>
                                                                    </dx:ASPxGridView>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Contactos" ColSpan="1" Visible="false">
                                                    <Items>
                                                        <dx:LayoutItem ColSpan="1">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="ASPxFormLayout1_E4" runat="server">
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:TabbedLayoutGroup>
                                    </Items>
                                    <SettingsItemCaptions Location="Top" />
                                </dx:ASPxFormLayout>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </div>                
            </div>            
        </dx:PopupControlContentControl>
    </ContentCollection>        
    </dx:ASPxPopupControl>
</asp:Content>
