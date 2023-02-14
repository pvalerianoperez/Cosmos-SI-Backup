

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Proveedor_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Compras.Catalogos.Proveedor_Listado" %>
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

        //validaciones captura
        function ValidaTxt(txt, mensaje) {
            var v = txt.GetValue();
            if (v == null) { v = ''; }
            if (v == '') {
                txt.SetIsValid(false);
                if (mensaje == '') { mensaje = 'El dato es requerido'; }
                txt.SetErrorText(mensaje);
                return false;
            }
            return true;
        }
        function ValidaDdl(ddl, mensaje) {
            var v = ddl.GetValue();
            if (v == null) { v = ''; }
            if (v == '') {
                ddl.SetIsValid(false);
                if (mensaje == '') { mensaje = 'El dato es requerido'; }
                ddl.SetErrorText(mensaje);
                return false;
            }
            return true;
        }
        function ValidaTxtPersonaMoral(s, e) {
            if (ddlTipoPersona.GetValue() == 'M') {
                e.IsValid = ValidaTxt(s);
            }
        }
        function ValidaTxtPersonaFisica(s, e) {
            if (ddlTipoPersona.GetValue() == 'F') {
                e.IsValid = ValidaTxt(s);
            }
        }
        function ValidaDdlPersonaFisica(s, e) {
            if (ddlTipoPersona.GetValue() == 'F') {
                e.IsValid = ValidaDdl(s);
            }
        }
        function cbpEditarEndCallback(errorMessage, refresh, show, grid, editPopup, parentPopup) {
            
            if(errorMessage==null){errorMessage = '';}
            if(errorMessage!=''){
                alert(errorMessage);
            }
            if(refresh=='1'){
                if(grid!=null){
                    grid.PerformCallback('refresh');
                }
            }
            if(show=='1'){
                if (!editPopup.IsVisible()) { editPopup.Show(); }
                //if (parentPopup != null) { if (parentPopup.IsVisible()) { parentPopup.Hide(); } }
            }else{
                if(editPopup.IsVisible()){editPopup.Hide();}
                if (parentPopup != null) { if (!parentPopup.IsVisible()) { parentPopup.Show(); } }
            }
        } 
           

        //edicion de proveedores
        function HabilitaCapturaTipoPersona() {            
            var tipoPersona = ddlTipoPersona.GetValue();
            
            switch (tipoPersona) {
                case "F":
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_1").style.display = "none";
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_2").style.display = "";
                    break;
                case "M":
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_2").style.display = "none";
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_1").style.display = "";
                    break;
                default:
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_1").style.display = "none";
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_2").style.display = "none";
                    break;
            }
        }
        function HabilitaDetalleCasado() {
            var estadoCivil = ddlEstadoCivilID.GetValue();
            switch (estadoCivil) {
                case "1":
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_2_9").style.display = "";
                    break;
                default:
                    document.getElementById("cphContenido_PopupEditar_cbpEditar_flEditar_PC_0_0_0_2_9").style.display = "none";
                    break;
            }
        }
        function Editar(id) {
            txtCURP.SetText('');
            txtRFC.SetText('');
            ddlTipoPersona.SetSelectedIndex(-1);
            ddlTipoProveedorID.SetSelectedIndex(-1);
            ddlGiroEmpresaID.SetSelectedIndex(-1);
            ddlMedioContactoID.SetSelectedIndex(-1);
            ddlVinculoID.SetSelectedIndex(-1);
            txtNombreCorto.SetText('');
            txtNombreComercial.SetText('');
            txtRazonSocial.SetText('');
            txtApellidoPaterno.SetText('');
            txtApellidoMaterno.SetText('');
            txtNombres.SetText('');
            txtSobrenombre.SetText('');
            txtIniciales.SetText('');
            txtFechaNacimiento.SetText('');
            ddlSexoID.SetSelectedIndex(-1);
            ddlEstadoCivilID.SetSelectedIndex(-1);
            chkCasadoCivil.SetChecked(false);
            chkCasadoIglesia.SetChecked(false);
            HabilitaCapturaTipoPersona();
            HabilitaDetalleCasado();
            PopupEditar.Show();
            cbpEditar.PerformCallback("EDITAR|" + id);
        }
        function GuardarProveedor() {
            var tipoPersona = ddlTipoPersona.GetValue();
            var validacionOk = ASPxClientEdit.ValidateGroup('Proveedor');
            if (validacionOk) {
                cbpEditar.PerformCallback("GUARDAR");
            }
        }
        function Eliminar(id) {
            swal({
                title: "¡Eliminar!",
                text: "¿Desea eliminar el proveedor?",
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

        //edicion proveedor (domicilio)
        function EditarProveedorDomicilio(id) {
            txtProveedorDomicilioNombre.SetText('');
            txtProveedorDomicilioCalle.SetText('');
            txtProveedorDomicilioNumeroExterior.SetText('');
            txtProveedorDomicilioNumeroInterior.SetText('');
            txtProveedorDomicilioColonia.SetText('');
            txtProveedorDomicilioEntrecalles1.SetText('');
            txtProveedorDomicilioEntrecalles2.SetText('');
            txtProveedorDomicilioCodigoPostal.SetText('');
            ddlProveedorDomicilioCiudadID.SetSelectedIndex(-1);
            //PopupEditar.Hide();
            PopupDomicilio.Show();
            cbpEditarDomicilio.PerformCallback("EDITAR|" + id);
            
        }
        function GuardarProveedorDomicilio() {
            var validacionOk = ASPxClientEdit.ValidateGroup('ProveedorDomicilio');
            if (validacionOk) {
                cbpEditarDomicilio.PerformCallback("GUARDAR");
            }
        }
        function EliminarProveedorDomicilio(id) {
            if (confirm('¿Desea eliminar el domicilio?')) {
                gridDomicilios.PerformCallback("ELIMINAR|" + id);
            }
        }
        //edicion proveedor (telefono)
        function EditarProveedorTelefono(id) {
            txtProveedorTelefonoNombre.SetText('');
            txtProveedorTelefonoLadaPais.SetText('');
            txtProveedorTelefonoNumeroTelefonico.SetText('');
            ddlProveedorTelefonoTipoTelefonoID.SetSelectedIndex(-1);
            chkProveedorTelefonoPredeterminado.SetChecked(false);
            PopupTelefono.Show();
            cbpEditarTelefono.PerformCallback("EDITAR|" + id);            
        }
        function GuardarProveedorTelefono() {
            var validacionOk = ASPxClientEdit.ValidateGroup('ProveedorTelefono');
            if (validacionOk) {
                cbpEditarTelefono.PerformCallback('GUARDAR');
            }            
        }
        function EliminarProveedorTelefono(id) {
            if (confirm('¿Desea eliminar el teléfono?')) {
                gridTelefonos.PerformCallback("ELIMINAR|" + id);
            }
        }
        //edicion proveedor (email)
        function EditarProveedorMail(id) {
            txtProveedorMailNombre.SetText('');
            txtProveedorMail.SetText('');
            chkProveedorMailPredeterminado.SetChecked(false);            
            PopupMail.Show();
            cbpEditarMail.PerformCallback("EDITAR|" + id);            
        }
        function GuardarProveedorMail() {
            var validacionOk = ASPxClientEdit.ValidateGroup('ProveedorMail');
            if (validacionOk) {
                cbpEditarMail.PerformCallback('GUARDAR');
            }
        }
        function EliminarProveedorMail(id) {
            if (confirm('¿Desea eliminar el mail?')) {
                gridMails.PerformCallback("ELIMINAR|" + id);
            }
        }

        //edicion de REPRESENTANTES
        function RepresentanteProveedorHabilitaDetalleCasado() {
            var estadoCivil = ddlRepresentanteProveedorEstadoCivilID.GetValue();
            var div = document.getElementById("cphContenido_PopupRepresentante_cbpEditarRepresentanteProveedor_flEditarRepresentanteProveedor_PC_0_0_0_0_0_11");
            if (div != null) {
                switch (estadoCivil) {
                    case "1":
                        document.getElementById("cphContenido_PopupRepresentante_cbpEditarRepresentanteProveedor_flEditarRepresentanteProveedor_PC_0_0_0_0_0_11").style.display = "";
                        break;
                    default:
                        document.getElementById("cphContenido_PopupRepresentante_cbpEditarRepresentanteProveedor_flEditarRepresentanteProveedor_PC_0_0_0_0_0_11").style.display = "none";
                        break;
                }
            }
        }
        function EditarRepresentanteProveedor(id) {
            txtRepresentanteProveedorApellidoPaterno.SetText('');
            txtRepresentanteProveedorApellidoMaterno.SetText('');
            txtRepresentanteProveedorNombres.SetText('');
            txtRepresentanteProveedorSobrenombre.SetText('');
            txtRepresentanteProveedorIniciales.SetText('');
            txtRepresentanteProveedorFechaNacimiento.SetText('');
            ddlRepresentanteProveedorSexoID.SetSelectedIndex(-1);
            ddlRepresentanteProveedorLugarNacimientoID.SetSelectedIndex(-1);
            ddlRepresentanteProveedorEstadoCivilID.SetSelectedIndex(-1);
            chkRepresentanteProveedorCasadoCivil.SetChecked(false);
            chkRepresentanteProveedorCasadoIglesia.SetChecked(false);
            RepresentanteProveedorHabilitaDetalleCasado();
            cbpEditarRepresentanteProveedor.PerformCallback("EDITAR|" + id);            
        }
        function GuardarRepresentanteProveedor() {
            var tipoPersona = ddlTipoPersona.GetValue();
            var validacionOk = ASPxClientEdit.ValidateGroup('RepresentanteProveedor');
            if (validacionOk) {
                cbpEditarRepresentanteProveedor.PerformCallback("GUARDAR");
            }
        }
        function EliminarRepresentanteProveedor(id) {
            if (confirm('¿Desea eliminar el representante?')) {
                cbpEditarRepresentanteProveedor.PerformCallback("ELIMINAR|" + id);
            }
        }
      
        //edicion RepresentanteProveedor (domicilio)
        function EditarRepresentanteProveedorDomicilio(id) {
            txtRepresentanteProveedorDomicilioNombre.SetText('');
            txtRepresentanteProveedorDomicilioCalle.SetText('');
            txtRepresentanteProveedorDomicilioNumeroExterior.SetText('');
            txtRepresentanteProveedorDomicilioNumeroInterior.SetText('');
            txtRepresentanteProveedorDomicilioColonia.SetText('');
            txtRepresentanteProveedorDomicilioEntrecalles1.SetText('');
            txtRepresentanteProveedorDomicilioEntrecalles2.SetText('');
            txtRepresentanteProveedorDomicilioCodigoPostal.SetText('');
            ddlRepresentanteProveedorDomicilioCiudadID.SetSelectedIndex(-1);
            PopupRepresentanteProveedorDomicilio.Show();
            cbpEditarRepresentanteProveedorDomicilio.PerformCallback("EDITAR|" + id);            
        }
        function GuardarRepresentanteProveedorDomicilio() {
            var validacionOk = ASPxClientEdit.ValidateGroup('RepresentanteProveedorDomicilio');
            if (validacionOk) {
                cbpEditarRepresentanteProveedorDomicilio.PerformCallback("GUARDAR");
            }
        }
        function EliminarRepresentanteProveedorDomicilio(id) {
            if (confirm('¿Desea eliminar el domicilio?')) {
                gridRepresentanteProveedorDomicilios.PerformCallback("ELIMINAR|" + id);
            }
        }
        //edicion RepresentanteProveedor (telefono)
        function EditarRepresentanteProveedorTelefono(id) {
            txtRepresentanteProveedorTelefonoNombre.SetText('');
            txtRepresentanteProveedorTelefonoLadaPais.SetText('');
            txtRepresentanteProveedorTelefonoNumeroTelefonico.SetText('');
            ddlRepresentanteProveedorTelefonoTipoTelefonoID.SetSelectedIndex(-1);
            chkRepresentanteProveedorTelefonoPredeterminado.SetChecked(false);
            PopupRepresentanteProveedorTelefono.Show();
            cbpEditarRepresentanteProveedorTelefono.PerformCallback("EDITAR|" + id);            
        }
        function GuardarRepresentanteProveedorTelefono() {
            var validacionOk = ASPxClientEdit.ValidateGroup('RepresentanteProveedorTelefono');
            if (validacionOk) {
                cbpEditarRepresentanteProveedorTelefono.PerformCallback('GUARDAR');
            }
        }
        function EliminarRepresentanteProveedorTelefono(id) {
            if (confirm('¿Desea eliminar el teléfono?')) {
                gridRepresentanteProveedorTelefonos.PerformCallback("ELIMINAR|" + id);
            }
        }
        //edicion RepresentanteProveedor (email)
        function EditarRepresentanteProveedorMail(id) {
            txtRepresentanteProveedorMailNombre.SetText('');
            txtRepresentanteProveedorMail.SetText('');
            chkRepresentanteProveedorMailPredeterminado.SetChecked(false);
            PopupRepresentanteProveedorMail.Show();
            cbpEditarRepresentanteProveedorMail.PerformCallback("EDITAR|" + id);           
        }
        function GuardarRepresentanteProveedorMail() {
            var validacionOk = ASPxClientEdit.ValidateGroup('RepresentanteProveedorMail');
            if (validacionOk) {
                cbpEditarRepresentanteProveedorMail.PerformCallback('GUARDAR');
            }
        }
        function EliminarRepresentanteProveedorMail(id) {
            if (confirm('¿Desea eliminar el mail?')) {
                gridRepresentanteProveedorMails.PerformCallback("ELIMINAR|" + id);
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
    
    
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="ProveedorID" Width="100%" Theme="Aqua" OnCustomCallback="Grid_CustomCallback">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}"   />        
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />        
        <SettingsCommandButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>        
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
        <Columns>            
            <dx:GridViewDataTextColumn Caption="ID" FieldName="ProveedorID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Persona" FieldName="PersonaID" VisibleIndex="3" Visible="False">
                <PropertiesComboBox DataSourceID="ObjectDataSource2" TextField="Nombre" ValueField="PersonaID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="4" Width="120px">
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataComboBoxColumn Caption="Tipo Proveedor" FieldName="TipoProveedorID" VisibleIndex="5">
                <PropertiesComboBox DataSourceID="ObjectDataSource4" TextField="Nombre" ValueField="TipoProveedorID" ValueType="System.Int32">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Giro Empresa" FieldName="GiroEmpresaID" VisibleIndex="6">
                <PropertiesComboBox DataSourceID="ObjectDataSource5" TextField="Nombre" ValueField="GiroEmpresaID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Medio Contacto" FieldName="MedioContactoID" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="ObjectDataSource6" TextField="Nombre" ValueField="MedioContactoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Vinculo" FieldName="VinculoID" VisibleIndex="8">
                <PropertiesComboBox DataSourceID="ObjectDataSource7" TextField="Nombre" ValueField="VinculoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
                    
            <dx:GridViewDataTextColumn FieldName="ProveedorID" VisibleIndex="2" Width="150px" Caption=" ">
                <PropertiesTextEdit DisplayFormatString="{0}">
                </PropertiesTextEdit>
                <DataItemTemplate>
                     <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" OnClick='<%# Eval("ProveedorID", "javascript:Eliminar({0});") %>' RenderMode="Link" Text="Eliminar">
                        <Image IconID="actions_cancel_16x16">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorID", "javascript:Editar({0});") %>' Text="Editar">
                        <Image IconID="actions_editname_16x16">
                        </Image>
                    </dx:ASPxButton>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
                    
        </Columns>
    </dx:ASPxGridView>
    
    <dx:ASPxPopupControl ID="PopupMail" runat="server" ClientInstanceName="PopupMail" HeaderText="Mail" Theme="Aqua" Modal="True" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" Width="400px" AllowDragging="true" AllowResize="true">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarMail" runat="server" ClientInstanceName="cbpEditarMail" OnCallback="cbpEditarMail_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridMails, PopupMail, PopupEditar);}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flMail" runat="server" ClientInstanceName="flMail" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>                        
                        <dx:LayoutItem Caption="Tipo" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlProveedorMailTipoMailID" ClientInstanceName="ddlProveedorMailTipoMailID" runat="server" Width="100%"
                                        DataSourceID="odsTipoMail" TextField="Nombre" ValueField="TipoMailID" ValueType="System.Int32">                                                                                
                                        <ValidationSettings ValidationGroup="ProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="chkProveedorMailPredeterminado" ClientInstanceName="chkProveedorMailPredeterminado" runat="server" CheckState="Unchecked" Text="Predeterminado">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Mail" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorMail" ClientInstanceName="txtProveedorMail" runat="server" Width="100%" MaxLength="90">
                                        <ValidationSettings ValidationGroup="ProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                            <RegularExpression ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorText="El correo es inválido" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                        
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorMailNombre" ClientInstanceName="txtProveedorMailNombre" runat="server" Width="100%" MaxLength="30">                                        
                                        <ValidationSettings ValidationGroup="ProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorMailCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {PopupMail.Hide(); PopupEditar.Show();}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorMailGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarProveedorMail();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupTelefono" runat="server" ClientInstanceName="PopupTelefono" HeaderText="Teléfono" Theme="Aqua" Modal="True" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="400px">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarTelefono" runat="server" ClientInstanceName="cbpEditarTelefono" OnCallback="cbpEditarTelefono_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridTelefonos, PopupTelefono, PopupEditar);}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flTelefono" runat="server" ClientInstanceName="flTelefono" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>
                        <dx:LayoutItem Caption="Tipo" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlProveedorTelefonoTipoTelefonoID" ClientInstanceName="ddlProveedorTelefonoTipoTelefonoID" runat="server" 
                                        DataSourceID="odsTipoTelefono" TextField="Nombre" ValueField="TipoTelefonoID" ValueType="System.Int32" Width="100%">
                                        <ClearButton Visibility="Auto">
                                        </ClearButton>
                                        <ValidationSettings ValidationGroup="ProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="chkProveedorTelefonoPredeterminado" ClientInstanceName="chkProveedorTelefonoPredeterminado" runat="server" CheckState="Unchecked" Text="Predeterminado">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                        
                        <dx:LayoutItem Caption="Lada País">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorTelefonoLadaPais" ClientInstanceName="txtProveedorTelefonoLadaPais" runat="server" Width="100%" MaxLength="3">
                                        <ValidationSettings ValidationGroup="ProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Número Telefónico" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorTelefonoNumeroTelefonico" ClientInstanceName="txtProveedorTelefonoNumeroTelefonico" runat="server" Width="100%" MaxLength="10">
                                        <ValidationSettings ValidationGroup="ProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorTelefonoNombre" ClientInstanceName="txtProveedorTelefonoNombre" runat="server" Width="100%" MaxLength="20">                                        
                                        <ValidationSettings ValidationGroup="ProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorTelefonoCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {PopupTelefono.Hide(); PopupEditar.Show();}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorTelefonoGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarProveedorTelefono();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupDomicilio" runat="server" ClientInstanceName="PopupDomicilio" HeaderText="Domicilio" MinHeight="400px" 
        Theme="Aqua" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="400px">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarDomicilio" runat="server" ClientInstanceName="cbpEditarDomicilio" OnCallback="cbpEditarDomicilio_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridDomicilios, PopupDomicilio, PopupEditar);}" />        
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flDomicilio" runat="server" ClientInstanceName="flDomicilio" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>                        
                        <dx:LayoutItem Caption="Calle" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioCalle" ClientInstanceName="txtProveedorDomicilioCalle" runat="server" Width="100%" MaxLength="50">
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="No. Exterior">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioNumeroExterior" ClientInstanceName="txtProveedorDomicilioNumeroExterior" runat="server" Width="100%" MaxLength="20">
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Interior">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioNumeroInterior" ClientInstanceName="txtProveedorDomicilioNumeroInterior" runat="server" Width="100%" MaxLength="20">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Colonia" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioColonia" ClientInstanceName="txtProveedorDomicilioColonia" runat="server" Width="100%">
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Entrecalles 1" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioEntrecalles1" ClientInstanceName="txtProveedorDomicilioEntrecalles1" runat="server" Width="100%" MaxLength="40">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                       
                        <dx:LayoutItem Caption="Entrecalles 2" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioEntrecalles2" ClientInstanceName="txtProveedorDomicilioEntrecalles2" runat="server" Width="100%" MaxLength="40">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Código Postal">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioCodigoPostal" ClientInstanceName="txtProveedorDomicilioCodigoPostal" runat="server" Width="100%" MaxLength="5">
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ciudad" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlProveedorDomicilioCiudadID" ClientInstanceName="ddlProveedorDomicilioCiudadID" runat="server" DataSourceID="odsCiudad" TextField="NombreCompleto" ValueField="CiudadID" ValueType="System.Int32" Width="100%">
                                        <ClearButton Visibility="Auto">
                                        </ClearButton>
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtProveedorDomicilioNombre" ClientInstanceName="txtProveedorDomicilioNombre" runat="server" Width="100%" MaxLength="50">
                                        <ValidationSettings Display="Static" ValidationGroup="ProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorDomicilioCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="35px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {
	PopupDomicilio.Hide(); PopupEditar.Show();
}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnProveedorDomicilioGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="35px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarProveedorDomicilio();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>                                        
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

     <dx:ASPxPopupControl ID="PopupRepresentanteProveedorMail" runat="server" ClientInstanceName="PopupRepresentanteProveedorMail" HeaderText="Mail" Theme="Aqua" Modal="True" 
        PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="400px">
        <ContentCollection>
            
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarRepresentanteProveedorMail" runat="server" ClientInstanceName="cbpEditarRepresentanteProveedorMail" OnCallback="cbpEditarRepresentanteProveedorMail_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridRepresentanteProveedorMails, PopupRepresentanteProveedorMail, PopupRepresentanteProveedorEditar);}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ClientInstanceName="flMail" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>                        
                        <dx:LayoutItem Caption="Tipo" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlRepresentanteProveedorMailTipoMailID" ClientInstanceName="ddlRepresentanteProveedorMailTipoMailID" runat="server" Width="100%"
                                        DataSourceID="odsTipoMail" TextField="Nombre" ValueField="TipoMailID" ValueType="System.Int32">                                                                                
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="chkRepresentanteProveedorMailPredeterminado" ClientInstanceName="chkRepresentanteProveedorMailPredeterminado" runat="server" CheckState="Unchecked" Text="Predeterminado">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Mail" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorMail" ClientInstanceName="txtRepresentanteProveedorMail" runat="server" Width="100%" MaxLength="90">
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                            <RegularExpression ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorText="El correo es inválido" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                        
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorMailNombre" ClientInstanceName="txtRepresentanteProveedorMailNombre" runat="server" Width="100%" MaxLength="20">                                        
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorMail" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorMailCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {
	PopupRepresentanteProveedorMail.Hide(); PopupRepresentanteProveedorEditar.Show();
}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorMailGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarRepresentanteProveedorMail();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupRepresentanteProveedorTelefono" runat="server" ClientInstanceName="PopupRepresentanteProveedorTelefono" HeaderText="Teléfono" Theme="Aqua" Modal="True" 
        PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="400px">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarRepresentanteProveedorTelefono" runat="server" ClientInstanceName="cbpEditarRepresentanteProveedorTelefono" OnCallback="cbpEditarRepresentanteProveedorTelefono_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridRepresentanteProveedorTelefonos, PopupRepresentanteProveedorTelefono, PopupRepresentanteProveedorEditar);}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ClientInstanceName="flTelefono" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>
                        <dx:LayoutItem Caption="Tipo" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlRepresentanteProveedorTelefonoTipoTelefonoID" ClientInstanceName="ddlRepresentanteProveedorTelefonoTipoTelefonoID" runat="server" 
                                        DataSourceID="odsTipoTelefono" TextField="Nombre" ValueField="TipoTelefonoID" ValueType="System.Int32" Width="100%">
                                        <ClearButton Visibility="Auto">
                                        </ClearButton>
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="chkRepresentanteProveedorTelefonoPredeterminado" ClientInstanceName="chkRepresentanteProveedorTelefonoPredeterminado" runat="server" CheckState="Unchecked" Text="Predeterminado">
                                    </dx:ASPxCheckBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                        
                        <dx:LayoutItem Caption="Lada País">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorTelefonoLadaPais" ClientInstanceName="txtRepresentanteProveedorTelefonoLadaPais" runat="server" Width="100%" MaxLength="3">
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Número Telefónico">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorTelefonoNumeroTelefonico" ClientInstanceName="txtRepresentanteProveedorTelefonoNumeroTelefonico" runat="server" Width="100%" MaxLength="10">
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorTelefonoNombre" ClientInstanceName="txtRepresentanteProveedorTelefonoNombre" runat="server" Width="100%" MaxLength="20">                                        
                                        <ValidationSettings ValidationGroup="RepresentanteProveedorTelefono" Display="Static" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorTelefonoCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {
	PopupRepresentanteProveedorTelefono.Hide(); PopupRepresentanteProveedorEditar.Show();
}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorTelefonoGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="30px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarRepresentanteProveedorTelefono();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupRepresentanteProveedorDomicilio" runat="server" ClientInstanceName="PopupRepresentanteProveedorDomicilio" HeaderText="Domicilio" MinHeight="400px" 
        Theme="Aqua" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="400px" >
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarRepresentanteProveedorDomicilio" runat="server" ClientInstanceName="cbpEditarRepresentanteProveedorDomicilio" OnCallback="cbpEditarRepresentanteProveedorDomicilio_Callback">
        <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridRepresentanteProveedorDomicilios, PopupRepresentanteProveedorDomicilio, PopupRepresentanteProveedorEditar);}" />        
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ClientInstanceName="flDomicilio" ColCount="4" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>                        
                        <dx:LayoutItem Caption="Calle" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioCalle" ClientInstanceName="txtRepresentanteProveedorDomicilioCalle" runat="server" Width="100%" MaxLength="50">
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="No. Exterior">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioNumeroExterior" ClientInstanceName="txtRepresentanteProveedorDomicilioNumeroExterior" runat="server" Width="100%" MaxLength="20">
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Interior">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioNumeroInterior" ClientInstanceName="txtRepresentanteProveedorDomicilioNumeroInterior" runat="server" Width="100%" MaxLength="20">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Colonia" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioColonia" ClientInstanceName="txtRepresentanteProveedorDomicilioColonia" runat="server" Width="100%" MaxLength="40">
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Entrecalles 1" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioEntrecalles1" ClientInstanceName="txtRepresentanteProveedorDomicilioEntrecalles1" runat="server" Width="100%" MaxLength="40">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>                       
                        <dx:LayoutItem Caption="Entrecalles 2" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioEntrecalles2" ClientInstanceName="txtRepresentanteProveedorDomicilioEntrecalles2" runat="server" Width="100%" MaxLength="40">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Código Postal">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioCodigoPostal" ClientInstanceName="txtRepresentanteProveedorDomicilioCodigoPostal" runat="server" Width="100%" MaxLength="5">
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ciudad" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="ddlRepresentanteProveedorDomicilioCiudadID" ClientInstanceName="ddlRepresentanteProveedorDomicilioCiudadID" runat="server" DataSourceID="odsCiudad" TextField="NombreCompleto" ValueField="CiudadID" ValueType="System.Int32" Width="100%">
                                        <ClearButton Visibility="Auto">
                                        </ClearButton>
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Comentarios" ColSpan="4">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtRepresentanteProveedorDomicilioNombre" ClientInstanceName="txtRepresentanteProveedorDomicilioNombre" runat="server" Width="100%" MaxLength="50">
                                        <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedorDomicilio" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
<dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorDomicilioCancelar" runat="server" Text="Cancelar" Width="200px" AutoPostBack="False" Height="35px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {
	PopupRepresentanteProveedorDomicilio.Hide(); PopupRepresentanteProveedorEditar.Show();
}" />
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnRepresentanteProveedorDomicilioGuardar" runat="server" Text="Guardar" Width="200px" AutoPostBack="False" Height="35px" ImageSpacing="10px">
                                        <ClientSideEvents Click="function(s, e) {GuardarRepresentanteProveedorDomicilio();}" />
                                        <Image IconID="actions_apply_16x16">
                                        </Image>                                        
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupEditar" runat="server" ClientInstanceName="PopupEditar" Height="600px" Modal="True" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="Aqua" Width="850px" 
        AllowResize="True" MinHeight="600px"  ScrollBars="Auto" HeaderText="Proveedor" CloseAction="CloseButton" AllowDragging="true">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
        <dx:ASPxCallbackPanel ID="cbpEditar" runat="server" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">
            <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, Grid, PopupEditar, null);HabilitaCapturaTipoPersona();HabilitaDetalleCasado();}"/>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditar" runat="server" AlignItemCaptionsInAllGroups="True" ClientInstanceName="flEditar" EnableTheming="True" ShowItemCaptionColon="False" Theme="Aqua">
                    <Items>
                        <dx:TabbedLayoutGroup>
                            <Items>
                                <dx:LayoutGroup Caption="Datos Generales">
                                    <Items>
                                        <dx:LayoutGroup Caption="" ColCount="4" GroupBoxDecoration="None" ShowCaption="False">
                                            <Items>
                                                <dx:LayoutItem Caption="RFC" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtRFC" ClientInstanceName="txtRFC" runat="server" Width="330px" MaxLength="13">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                    <RegularExpression ValidationExpression="^[A-Za-z]{3,4}[ |\-]{0,1}[0-9]{6}[ |\-]{0,1}[0-9A-Za-z]{3}$" ErrorText="RFC Inválido" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Tipo de Persona" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlTipoPersona" runat="server" ClientInstanceName="ddlTipoPersona" Width="330px">
                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {HabilitaCapturaTipoPersona();}" />
                                                                <Items>
                                                                    <dx:ListEditItem Text="FÍSICA" Value="F" />
                                                                    <dx:ListEditItem Text="MORAL" Value="M" />
                                                                </Items>
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
<RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Tipo de Proveedor" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlTipoProveedorID" runat="server" Width="100%" ClientInstanceName="ddlTipoProveedorID" DataSourceID="ObjectDataSource4" TextField="Nombre" ValueField="TipoProveedorID" ValueType="System.Int32">
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
<RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Giro Empresa" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlGiroEmpresaID" ClientInstanceName="ddlGiroEmpresaID" runat="server" DataSourceID="ObjectDataSource5" TextField="Nombre" ValueField="GiroEmpresaID" ValueType="System.Int32" Width="100%">
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Medio de Contacto" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlMedioContactoID" runat="server" ClientInstanceName="ddlMedioContactoID" DataSourceID="ObjectDataSource6" TextField="Nombre" ValueField="MedioContactoID" ValueType="System.Int32" Width="100%">
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>                                                                
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Vínculo" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlVinculoID" runat="server" ClientInstanceName="ddlVinculoID" DataSourceID="ObjectDataSource7" TextField="Nombre" ValueField="VinculoID" ValueType="System.Int32" Width="100%">
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>                                                                
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Persona Moral" ColCount="2" CssClass="hidden" GroupBoxDecoration="None" ShowCaption="False">
                                            <Items>
                                                <dx:LayoutItem Caption="Nombre Corto">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtNombreCorto" ClientInstanceName="txtNombreCorto" runat="server" Width="100%" MaxLength="20">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaMoral" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Nombre Comercial">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtNombreComercial" ClientInstanceName="txtNombreComercial" runat="server" Width="100%" MaxLength="120">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaMoral" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Razon Social" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtRazonSocial" ClientInstanceName="txtRazonSocial" runat="server" Width="100%" MaxLength="120">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaMoral" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Datos Persona Física" ColCount="4" CssClass="hidden" GroupBoxDecoration="None" Name="layoutPersonaFisica" ShowCaption="False">
                                            <Items>
                                                <dx:LayoutItem Caption="Apellido Paterno">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtApellidoPaterno" ClientInstanceName="txtApellidoPaterno" runat="server" Width="100%" MaxLength="30">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaFisica" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Apellido Materno">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtApellidoMaterno" ClientInstanceName="txtApellidoMaterno" runat="server" Width="100%" MaxLength="30">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaFisica" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Nombre(s)" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtNombres" ClientInstanceName="txtNombres" runat="server" Width="100%" MaxLength="35">
                                                                <ValidationSettings Display="Static" ValidationGroup="Proveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                </ValidationSettings>
                                                                <ClientSideEvents Validation="ValidaTxtPersonaFisica" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Sobrenombre">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtSobrenombre" ClientInstanceName="txtSobrenombre" runat="server" Width="100%" MaxLength="25">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Iniciales">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtIniciales" ClientInstanceName="txtIniciales" runat="server" Width="100%" MaxLength="6">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Fecha de Nacimiento">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxDateEdit ID="txtFechaNacimiento" ClientInstanceName="txtFechaNacimiento" runat="server" Width="100%">
                                                                <TimeSectionProperties>
                                                                    <TimeEditProperties>
                                                                        <ClearButton Visibility="Auto">
                                                                        </ClearButton>
                                                                    </TimeEditProperties>
                                                                </TimeSectionProperties>
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                            </dx:ASPxDateEdit>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Sexo">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlSexoID" ValueType="System.Int32" ClientInstanceName="ddlSexoID" runat="server" Width="100%" DataSourceID="odsSexo" ValueField="SexoID" TextField ="Nombre" >
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                                
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="CURP" ColSpan="2">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtCURP" ClientInstanceName="txtCURP" runat="server" Width="100%" MaxLength="18">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Estado Civil">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="ddlEstadoCivilID" ValueType="System.Int32" ClientInstanceName="ddlEstadoCivilID" runat="server" Width="100%" DataSourceID="odsEstadoCivil" ValueField="EstadoCivilID" TextField="Nombre">
                                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {HabilitaDetalleCasado();}" />
                                                                <ClearButton Visibility="Auto">
                                                                </ClearButton>
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutGroup Caption="Casado por" Name="layoutCasadoPor" RowSpan="3" ColCount="2" GroupBoxDecoration="None" ShowCaption="False">
                                                    <Items>
                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkCasadoCivil" runat="server" CheckState="Unchecked" ClientInstanceName="chkCasadoCivil" Text="Civil">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkCasadoIglesia" runat="server" CheckState="Unchecked" ClientInstanceName="chkCasadoIglesia" Text="Iglesia">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="" ColCount="2" GroupBoxDecoration="None" ShowCaption="False">
                                            <Items>
                                                <dx:LayoutItem Caption="">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxButton ID="btnEditarCancelar" runat="server" AutoPostBack="False" Text="Cancelar" Width="100%" ImageSpacing="10px" Height="35px">
                                                                <ClientSideEvents Click="function(s, e) {
	PopupEditar.Hide();
}" />
                                                                <Image IconID="actions_cancel_16x16">
                                                                </Image>
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxButton ID="btnEditarGuardar" runat="server" AutoPostBack="False" Text="Guardar" Width="100%" ImageSpacing="10px" Height="35px">
                                                                <ClientSideEvents Click="function(s, e) {GuardarProveedor();}" />
                                                                <Image IconID="actions_apply_16x16">
                                                                </Image>
                                                            </dx:ASPxButton>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Domicilios" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView runat="server" ID="gridDomicilios" ClientInstanceName="gridDomicilios" AutoGenerateColumns="False"
                                                        KeyFieldName="ProveedorDomicilioID" EnableTheming="True" Theme="Aqua" Width="750px" Styles-Cell-VerticalAlign="Top" 
                                                        OnCustomCallback="gridDomicilios_CustomCallback" OnLoad="gridDomicilios_Load" Settings-VerticalScrollableHeight="430" >                                                        
                                                        <SettingsBehavior ConfirmDelete="False" AllowFocusedRow="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" />
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings HorizontalScrollBarMode="Hidden" ShowFilterRow="True" VerticalScrollBarMode="Visible"  />
                                                        <Columns>

                                                            <dx:GridViewDataTextColumn FieldName="ProveedorDomicilioID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorDomicilioID", "javascript:EliminarProveedorDomicilio({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorDomicilioID", "javascript:EditarProveedorDomicilio({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarProveedorDomicilio(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="1" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Domicilio" FieldName="DomicilioCompleto" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                        </Columns>
                                                    <Styles>
                                                        <Cell VerticalAlign="Top"></Cell>
                                                        
                                                    </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Telefonos" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView ID="gridTelefonos" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridTelefonos" EnableTheming="True" 
                                                        KeyFieldName="ProveedorTelefonoID" OnCustomCallback="gridTelefonos_CustomCallback" OnLoad="gridTelefonos_Load" Theme="Aqua" Width="750px"
                                                         Settings-VerticalScrollableHeight="430">
                                                        
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />                                                        
                                                        <Columns>
                                                             <dx:GridViewDataTextColumn FieldName="ProveedorTelefonoID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorTelefonoID", "javascript:EliminarProveedorTelefono({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorTelefonoID", "javascript:EditarProveedorTelefono({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarProveedorTelefono(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ProveedorTelefonoID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Lada" FieldName="LadaPais" ShowInCustomizationForm="True" VisibleIndex="2" Width="50px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Número Telefónico" FieldName="NumeroTelefonico" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="5" Width="100px">
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoTelefonoID" ShowInCustomizationForm="True" VisibleIndex="4" Width="100px">
                                                                <PropertiesComboBox DataSourceID="odsTipoTelefono" TextField="Nombre" ValueField="TipoTelefonoID">
                                                                    <ClearButton Visibility="Auto">
                                                                    </ClearButton>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="6">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <Styles>
                                                            <Cell VerticalAlign="Top">
                                                            </Cell>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Mails" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView ID="gridMails" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridMails" EnableTheming="True" 
                                                        KeyFieldName="ProveedorMailID" OnCustomCallback="gridMails_CustomCallback" OnLoad="gridMails_Load" Theme="Aqua" Width="750px"
                                                         Settings-VerticalScrollableHeight="430">
                                                        
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />                                                        
                                                        <Columns>

                                                            <dx:GridViewDataTextColumn FieldName="ProveedorMailID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorMailID", "javascript:EliminarProveedorMail({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("ProveedorMailID", "javascript:EditarProveedorMail({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarProveedorMail(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ProveedorMailID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Mail" FieldName="Mail" ShowInCustomizationForm="True" VisibleIndex="2" Width="250px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoMailID" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                                                <PropertiesComboBox DataSourceID="odsTipoMail" ValueField="TipoMailID" TextField="Nombre"></PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="4" Width="100px">
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataTextColumn Caption="Comentarios" FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>

                                                        </Columns>
                                                        <Styles>
                                                            <Cell VerticalAlign="Top">
                                                            </Cell>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Representantes" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                     <dx:ASPxGridView runat="server" ID="gridRepresentantes" ClientInstanceName="gridRepresentantes" AutoGenerateColumns="False"
                                                        KeyFieldName="RepresentanteProveedorID" EnableTheming="True" Theme="Aqua" Width="750px" Styles-Cell-VerticalAlign="Top" 
                                                        OnCustomCallback="gridRepresentantes_CustomCallback" OnLoad="gridRepresentantes_Load" Settings-VerticalScrollableHeight="430">                                                      
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings HorizontalScrollBarMode="Hidden" ShowFilterRow="True" VerticalScrollBarMode="Visible"  />
                                                        <Columns>

                                                            <dx:GridViewDataTextColumn FieldName="RepresentanteProveedorID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorID", "javascript:EliminarRepresentanteProveedor({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorID", "javascript:EditarRepresentanteProveedor({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarRepresentanteProveedor(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" ShowInCustomizationForm="True" VisibleIndex="3">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Teléfono" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Tipo"  ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Mail" ShowInCustomizationForm="True" VisibleIndex="6">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    <Styles>
                                                    <Cell VerticalAlign="Top"></Cell>
                                                    </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Sucursales" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxCheckBoxList ID="flEditar_E1" runat="server" DataSourceID="odsSucursal" TextField="Nombre" ValueField="SucursalID" ValueType="System.Int32">
                                                    </dx:ASPxCheckBoxList>
                                                    <asp:ObjectDataSource ID="odsSucursal" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Sucursal">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="EmpresaID" SessionField="EmpresaID" Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:TabbedLayoutGroup>
                    </Items>
                    <SettingsItemCaptions Location="Top" />
                    <SettingsItems VerticalAlign="Top" />
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupRepresentanteProveedorEditar" runat="server" ClientInstanceName="PopupRepresentanteProveedorEditar" HeaderText="Representante" MinHeight="400px" MinWidth="850px" Theme="Aqua" Modal="True" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" CloseAction="CloseButton" AllowDragging="true" AllowResize="true" Width="850px">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxCallbackPanel ID="cbpEditarRepresentanteProveedor" runat="server" ClientInstanceName="cbpEditarRepresentanteProveedor" OnCallback="cbpEditarRepresentanteProveedor_Callback">
                    <ClientSideEvents EndCallback="function(s, e) {cbpEditarEndCallback(s.cp_errorMessage, s.cp_refresh, s.cp_show, gridRepresentantes, PopupRepresentanteProveedorEditar,PopupEditar);RepresentanteProveedorHabilitaDetalleCasado();}"/>                   
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxFormLayout ID="flEditarRepresentanteProveedor" runat="server" AlignItemCaptionsInAllGroups="True" ClientInstanceName="flEditarRepresentanteProveedor" EnableTheming="True" ShowItemCaptionColon="False" Theme="Aqua" Width="100%">
                        <Items>
                            <dx:TabbedLayoutGroup>
                                <Items>
                                    <dx:LayoutGroup Caption="Datos Generales">
                                        <Items>
                                            <dx:LayoutGroup Caption="Datos Persona Física" CssClass="hidden" GroupBoxDecoration="None" Name="layoutRepresentantePersonaFisica" ShowCaption="False">
                                                <Items>
                                                    <dx:LayoutGroup Caption="" ColCount="4" GroupBoxDecoration="None" ShowCaption="False">
                                                        <Items>                                                            
                                                            <dx:LayoutItem Caption="RFC">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorRFC" runat="server" ClientInstanceName="txtRepresentanteProveedorRFC" Width="100%">
                                                                            <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                                                                <RequiredField IsRequired="True"></RequiredField>
                                                                                <RegularExpression ValidationExpression="^[A-Za-z]{3,4}[ |\-]{0,1}[0-9]{6}[ |\-]{0,1}[0-9A-Za-z]{3}$" ErrorText="RFC Inválido" />
                                                                            </ValidationSettings>
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:EmptyLayoutItem ColSpan="3">
                                                            </dx:EmptyLayoutItem>
                                                            <dx:LayoutItem Caption="Apellido Paterno">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorApellidoPaterno" ClientInstanceName="txtRepresentanteProveedorApellidoPaterno" runat="server" Width="100%">
                                                                            <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                                                                <RequiredField IsRequired="True"></RequiredField>
                                                                            </ValidationSettings>
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Apellido Materno">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorApellidoMaterno" ClientInstanceName="txtRepresentanteProveedorApellidoMaterno" runat="server" Width="100%">
                                                                            <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                                                                <RequiredField IsRequired="True"></RequiredField>
                                                                            </ValidationSettings>
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Nombre(s)" ColSpan="2">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorNombres" ClientInstanceName="txtRepresentanteProveedorNombres" runat="server" Width="100%">
                                                                            <ValidationSettings Display="Static" ValidationGroup="RepresentanteProveedor" RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip">                                                                   
                                                                                <RequiredField IsRequired="True"></RequiredField>
                                                                            </ValidationSettings>
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Sobrenombre">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorSobrenombre" runat="server" ClientInstanceName="txtRepresentanteProveedorSobrenombre" Width="100%">
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Iniciales">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxTextBox ID="txtRepresentanteProveedorIniciales" ClientInstanceName="txtRepresentanteProveedorIniciales" runat="server" Width="100%">
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Fecha de Nacimiento">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxDateEdit ID="txtRepresentanteProveedorFechaNacimiento" ClientInstanceName="txtRepresentanteProveedorFechaNacimiento" runat="server" Width="100%">
                                                                            <TimeSectionProperties>
                                                                                <TimeEditProperties>
                                                                                    <ClearButton Visibility="Auto">
                                                                                    </ClearButton>
                                                                                </TimeEditProperties>
                                                                            </TimeSectionProperties>
                                                                            <ClearButton Visibility="Auto">
                                                                            </ClearButton>
                                                                        </dx:ASPxDateEdit>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Sexo">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxComboBox ID="ddlRepresentanteProveedorSexoID" ValueType="System.Int32" ClientInstanceName="ddlRepresentanteProveedorSexoID" runat="server" Width="100%" DataSourceID="odsSexo" ValueField="SexoID" TextField="Nombre">
                                                                            <ClearButton Visibility="Auto">
                                                                            </ClearButton>
                                                                        </dx:ASPxComboBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
    <dx:LayoutItem Caption="Lugar Nacimiento" ColSpan="4"><LayoutItemNestedControlCollection>
    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxComboBox runat="server" ID="ddlRepresentanteProveedorLugarNacimientoID" ClientInstanceName="ddlRepresentanteProveedorLugarNacimientoID" Width="100%" DataSourceID="odsCiudad" ValueField="CiudadID" TextField="NombreCompleto" ValueType="System.Int32" >
    <ClearButton Visibility="Auto"></ClearButton>
    </dx:ASPxComboBox>

                                                                    </dx:LayoutItemNestedControlContainer>
    </LayoutItemNestedControlCollection>
    </dx:LayoutItem>
                                                            <dx:LayoutItem Caption="Estado Civil">
                                                                <LayoutItemNestedControlCollection>
                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                        <dx:ASPxComboBox ID="ddlRepresentanteProveedorEstadoCivilID" ValueType="System.Int32" ClientInstanceName="ddlRepresentanteProveedorEstadoCivilID" runat="server" Width="100%" DataSourceID="odsEstadoCivil" ValueField="EstadoCivilID" TextField="Nombre">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {RepresentanteProveedorHabilitaDetalleCasado();}" />
                                                                            <ClearButton Visibility="Auto">
                                                                            </ClearButton>
                                                                        </dx:ASPxComboBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                                </LayoutItemNestedControlCollection>
                                                            </dx:LayoutItem>
                                                            <dx:LayoutGroup Caption="Casado por" Name="layoutRepresentanteCasadoPor" RowSpan="3" GroupBoxDecoration="None" ShowCaption="False">                                                            
                                                                <Items>
                                                                    <dx:LayoutGroup Caption="" ColCount="2" GroupBoxDecoration="None" ShowCaption="False">
                                                                        <Items>                                                                        
                                                                            <dx:LayoutItem Caption="">
                                                                                <LayoutItemNestedControlCollection>
                                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                                        <dx:ASPxCheckBox ID="chkRepresentanteProveedorCasadoCivil" ClientInstanceName="chkRepresentanteProveedorCasadoCivil" runat="server" CheckState="Unchecked" Text="Civil">
                                                                                        </dx:ASPxCheckBox>
                                                                                    </dx:LayoutItemNestedControlContainer>
                                                                                </LayoutItemNestedControlCollection>
                                                                            </dx:LayoutItem>
                                                                            <dx:LayoutItem Caption="">
                                                                                <LayoutItemNestedControlCollection>
                                                                                    <dx:LayoutItemNestedControlContainer runat="server">
                                                                                        <dx:ASPxCheckBox ID="chkRepresentanteProveedorCasadoIglesia" ClientInstanceName="chkRepresentanteProveedorCasadoIglesia" runat="server" CheckState="Unchecked" Text="Iglesia">
                                                                                        </dx:ASPxCheckBox>
                                                                                    </dx:LayoutItemNestedControlContainer>
                                                                                </LayoutItemNestedControlCollection>
                                                                                <Paddings Padding="0px" />
                                                                            </dx:LayoutItem>
                                                                        </Items>
                                                                    </dx:LayoutGroup>
                                                                </Items>
                                                                <SettingsItemCaptions Location="Left" />
                                                            </dx:LayoutGroup>
                                                        </Items>
                                                    </dx:LayoutGroup>
                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup ColCount="2" Caption="" ShowCaption="False" GroupBoxDecoration="None">
                                                <Items>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxButton ID="btnEditarRepresentanteProveedorCancelar" runat="server" AutoPostBack="False" Text="Cancelar" Width="100%" ImageSpacing="10px" Height="35px">
                                                                    <ClientSideEvents Click="function(s, e) {PopupRepresentanteProveedorEditar.Hide(); PopupEditar.Show();}" />
                                                                    <Image IconID="actions_cancel_16x16">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                                <dx:ASPxButton ID="btnEditarRepresentanteProveedorGuardar" runat="server" AutoPostBack="False" Text="Guardar" Width="100%" ImageSpacing="10px" Height="35px">
                                                                    <ClientSideEvents Click="function(s, e) {GuardarRepresentanteProveedor();}" />
                                                                    <Image IconID="actions_apply_16x16">
                                                                    </Image>
                                                                </dx:ASPxButton>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                        </Items>
                                    </dx:LayoutGroup>
                                   <dx:LayoutGroup Caption="Domicilios" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView runat="server" ID="gridRepresentanteProveedorDomicilios" ClientInstanceName="gridRepresentanteProveedorDomicilios" AutoGenerateColumns="False"
                                                        KeyFieldName="RepresentanteProveedorDomicilioID" EnableTheming="True" Theme="Aqua" Width="750px" Styles-Cell-VerticalAlign="Top" 
                                                        OnCustomCallback="gridRepresentanteProveedorDomicilios_CustomCallback" OnLoad="gridRepresentanteProveedorDomicilios_Load" Settings-VerticalScrollableHeight="430" >                                                        
                                                        <SettingsBehavior ConfirmDelete="False" AllowFocusedRow="False" AllowSelectByRowClick="False" AllowSelectSingleRowOnly="False" />
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings HorizontalScrollBarMode="Hidden" ShowFilterRow="True" VerticalScrollBarMode="Visible"  />
                                                        <Columns>

                                                            <dx:GridViewDataTextColumn FieldName="RepresentanteProveedorDomicilioID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorDomicilioID", "javascript:EliminarRepresentanteProveedorDomicilio({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorDomicilioID", "javascript:EditarRepresentanteProveedorDomicilio({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoRepresentanteDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoRepresentanteDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarRepresentanteProveedorDomicilio(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="1" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Domicilio" FieldName="DomicilioCompleto" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                        </Columns>
                                                    <Styles>
                                                        <Cell VerticalAlign="Top"></Cell>
                                                        
                                                    </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Teléfonos" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView ID="gridRepresentanteProveedorTelefonos" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridRepresentanteProveedorTelefonos" EnableTheming="True" 
                                                        KeyFieldName="RepresentanteProveedorTelefonoID" OnCustomCallback="gridRepresentanteProveedorTelefonos_CustomCallback" OnLoad="gridRepresentanteProveedorTelefonos_Load" Theme="Aqua" Width="750px"
                                                         Settings-VerticalScrollableHeight="430">
                                                        
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />                                                        
                                                        <Columns>
                                                             <dx:GridViewDataTextColumn FieldName="RepresentanteProveedorTelefonoID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorTelefonoID", "javascript:EliminarRepresentanteProveedorTelefono({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorTelefonoID", "javascript:EditarRepresentanteProveedorTelefono({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoRepresentanteDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoRepresentanteDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarRepresentanteProveedorTelefono(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="RepresentanteProveedorTelefonoID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Lada" FieldName="LadaPais" ShowInCustomizationForm="True" VisibleIndex="2" Width="50px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Número Telefónico" FieldName="NumeroTelefonico" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="5" Width="100px">
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoTelefonoID" ShowInCustomizationForm="True" VisibleIndex="4" Width="100px">
                                                                <PropertiesComboBox DataSourceID="odsTipoTelefono" TextField="Nombre" ValueField="TipoTelefonoID">
                                                                    <ClearButton Visibility="Auto">
                                                                    </ClearButton>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="6">
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <Styles>
                                                            <Cell VerticalAlign="Top">
                                                            </Cell>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Mails" GroupBoxDecoration="None" ShowCaption="False">
                                    <Items>
                                        <dx:LayoutItem Width="100%" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView ID="gridRepresentanteProveedorMails" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridRepresentanteProveedorMails" EnableTheming="True" 
                                                        KeyFieldName="RepresentanteProveedorMailID" OnCustomCallback="gridRepresentanteProveedorMails_CustomCallback" OnLoad="gridRepresentanteProveedorMails_Load" Theme="Aqua" Width="750px"
                                                         Settings-VerticalScrollableHeight="430">
                                                        
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />                                                        
                                                        <Columns>

                                                            <dx:GridViewDataTextColumn FieldName="RepresentanteProveedorMailID" VisibleIndex="0" Width="140px">
                                                                <PropertiesTextEdit DisplayFormatString="{0}">
                                                                </PropertiesTextEdit>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <DataItemTemplate>
                                                                    <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorMailID", "javascript:EliminarRepresentanteProveedorMail({0});") %>' Text="Eliminar">
                                                                        <Image IconID="actions_cancel_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Link" OnClick='<%# Eval("RepresentanteProveedorMailID", "javascript:EditarRepresentanteProveedorMail({0});") %>' Text="Editar">
                                                                        <Image IconID="actions_editname_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </DataItemTemplate>
                                                                <HeaderTemplate>                                                                
                                                                    <dx:ASPxButton ID="btnNuevoRepresentanteDomicilio" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevoRepresentanteDomicilio" RenderMode="Link" Text="Nuevo" VerticalAlign="Middle">
                                                                        <ClientSideEvents Click="function(s, e) {EditarRepresentanteProveedorMail(0);}"  />
                                                                        <Image IconID="reports_addgroupheader_16x16">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </HeaderTemplate>
                                                            </dx:GridViewDataTextColumn>

                                                            
                                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="RepresentanteProveedorMailID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Mail" FieldName="Mail" ShowInCustomizationForm="True" VisibleIndex="2" Width="250px">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="TipoMailID" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                                                <PropertiesComboBox DataSourceID="odsTipoMail" ValueField="TipoMailID" TextField="Nombre"></PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataCheckColumn Caption="Predeterminado" FieldName="Predeterminado" ShowInCustomizationForm="True" VisibleIndex="4" Width="100px">
                                                            </dx:GridViewDataCheckColumn>
                                                            <dx:GridViewDataTextColumn Caption="Comentarios" FieldName="Comentarios" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            </dx:GridViewDataTextColumn>

                                                        </Columns>
                                                        <Styles>
                                                            <Cell VerticalAlign="Top">
                                                            </Cell>
                                                        </Styles>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                </Items>
                            </dx:TabbedLayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                        <SettingsItems VerticalAlign="Top" />
                    </dx:ASPxFormLayout>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Proveedor" DeleteMethod="Eliminar">
        <DeleteParameters>
            <asp:Parameter Name="proveedorID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Persona"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.TipoProveedor">
        <SelectParameters>
            <asp:SessionParameter Name="empresaID" SessionField="EmpresaID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoMail" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.TipoMail"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Ciudad" ID="odsCiudad"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoTelefono" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.TipoTelefono"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.GiroEmpresa"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.MedioContacto"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Vinculo"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSexo" runat="server" SelectMethod="Listado" TypeName="Cosmos.Sistema.Api.Client.Sexo"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEstadoCivil" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.EstadoCivil"></asp:ObjectDataSource>

</asp:Content>

