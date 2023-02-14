

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Usuario_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Seguridad.Usuario_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    
    <script type="text/javascript">
        function AccionMenuItemClick(e) {
            switch (e.item.name) {
                case "AGREGAR":
                    Nuevo();
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
        //botones del grid
        function Nuevo() {
            cbpEditar.PerformCallback("NUEVO|0");
        }
        function Editar(id) {
            cbpEditar.PerformCallback("EDITAR|" + id);
        }
        function EditarPerfiles(id) {            
            cbpEditarPerfiles.PerformCallback("EDITAR|" + id);
        }
        function Eliminar(id) {
            if (confirm('¿Desea ELIMINAR el usuario?')) {
                cbpEditar.PerformCallback("ELIMINAR|" + id);
            }
        }
        function GuardarOpcion() {
            cbpEditar.PerformCallback("GUARDAR");
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
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Usuario"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Empresa"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsPerfil" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Perfil"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsModulo" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Modulo"></asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="PopupEditar" runat="server" ClientInstanceName="PopupEditar" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True" AllowResize="True" HeaderText="Edición" Width="400px" Height="400px">
        <HeaderImage IconID="actions_editname_16x16">
        </HeaderImage>
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditar" runat="server" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">        
        <ClientSideEvents EndCallback="function(s, e) {
	if(s.cp_errorMessage!=&quot;&quot;){alert(s.cp_errorMessage);}
	if(s.cp_refresh==&quot;1&quot;){Grid.PerformCallback(&quot;refresh&quot;);}
if(s.cp_show==&quot;1&quot;){PopupEditar.Show();} else{PopupEditar.Hide();}
}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditar" runat="server" ClientInstanceName="flEditar" DataSourceID="odsEditar" ColCount="2" ShowItemCaptionColon="False" Width="400px">
                    <Items>
                        <dx:LayoutGroup ShowCaption="False" VerticalAlign="Top" GroupBoxDecoration="None">
                            <Paddings Padding="0px" />
                            <Items>
                                <dx:LayoutGroup Caption="Datos Generales" GroupBoxDecoration="None" ShowCaption="False">
                                    <Paddings Padding="0px" />
                                    <Items>
                                        <dx:LayoutItem Caption="Nombre" FieldName="Nombre">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtNombre" runat="server" ClientInstanceName="txtNombre" MaxLength="50" Width="100%">
                                                        <ValidationSettings ValidationGroup="Guardar">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Correo electrónico" FieldName="CorreoElectronico">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtCorreoElectronico" runat="server" ClientInstanceName="txtCorreoElectronico" MaxLength="90" Width="100%">
                                                        <ValidationSettings ValidationGroup="Guardar">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Alias">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtAlias" runat="server" Width="100%">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutGroup Caption="" ColCount="4" GroupBoxDecoration="None">
                                            <Paddings Padding="0px" />
                                            <Items>
                                                <dx:LayoutItem FieldName="Activo">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkActivo" runat="server" CheckState="Unchecked" ClientInstanceName="chkActivo">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem FieldName="Bloqueado" Caption="Bloqueado">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkBloqueado" runat="server" CheckState="Unchecked" ClientInstanceName="chkBloqueado">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem FieldName="Administrador" Caption="Administrador">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkAdministrador" runat="server" CheckState="Unchecked" ClientInstanceName="chkAdministrador">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutItem Caption="Contraseña">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtContrasena" runat="server" Password="True" Width="100%" MaxLength="20">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Contraseña Confirmación">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtContrasenaConfirmacion" runat="server" Password="True" Width="100%" MaxLength="20">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" ShowCaption="False">
                                    <Paddings Padding="0px" PaddingBottom="0px" PaddingLeft="0px" PaddingRight="0px" PaddingTop="15px" />
                                    <Items>
                                        <dx:LayoutItem Caption="" HorizontalAlign="Left">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton ID="btnCancelar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Cancelar" Width="200px">
                                                        <ClientSideEvents Click="function(s, e) {PopupEditar.Hide();}" />
                                                        <Image IconID="actions_reset_16x16office2013">
                                                        </Image>
                                                        <Paddings Padding="5px" />
                                                    </dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <Paddings PaddingBottom="0px" PaddingLeft="0px" PaddingRight="5px" PaddingTop="0px" />
                                            <NestedControlCellStyle>
                                                <Paddings Padding="0px" />
                                            </NestedControlCellStyle>
                                            <ParentContainerStyle>
                                                <Paddings Padding="0px" />
                                            </ParentContainerStyle>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton ID="btnGuardar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Guardar" ValidationGroup="Guardar" Width="200px">
                                                        <ClientSideEvents Click="function(s, e) {
	if(ASPxClientEdit.ValidateGroup(null)){GuardarOpcion();}
}" />
                                                        <Image IconID="actions_apply_16x16">
                                                        </Image>
                                                        <Paddings Padding="5px" />
                                                    </dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <Paddings PaddingBottom="0px" PaddingLeft="5px" PaddingRight="0px" PaddingTop="0px" />
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                    <SettingsItems VerticalAlign="Top" />
                </dx:ASPxFormLayout>
                <asp:HiddenField ID="hfID" runat="server" />
                <asp:ObjectDataSource ID="odsEditar" runat="server" SelectMethod="Consultar" TypeName="Cosmos.Seguridad.Api.Client.Usuario">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuarioID" SessionField="Usuario_Listado_UsuarioID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupEditarPerfiles" runat="server" ClientInstanceName="PopupEditarPerfiles" Modal="True" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" AllowDragging="True" AllowResize="True" HeaderText="Perfiles" Width="400px" Height="400px">
        <HeaderImage IconID="actions_editname_16x16">
        </HeaderImage>
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditarPerfiles" runat="server" ClientInstanceName="cbpEditarPerfiles" OnCallback="cbpEditarPerfiles_Callback">        
        <ClientSideEvents EndCallback="function(s, e) {
	if(s.cp_errorMessage!=&quot;&quot;){alert(s.cp_errorMessage);}
	if(s.cp_show==&quot;1&quot;){PopupEditarPerfiles.Show();} else{PopupEditarPerfiles.Hide();}
}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditarPerfiles" runat="server" ClientInstanceName="flEditarPerfiles" DataSourceID="odsEditarPerfiles" ColCount="2" ShowItemCaptionColon="False" Width="400px">
                    <Items>
                        <dx:LayoutGroup ShowCaption="False" VerticalAlign="Top" GroupBoxDecoration="None">
                            <Paddings Padding="0px" />
                            <Items>
                                <dx:LayoutGroup Caption="Datos Generales" GroupBoxDecoration="None" ShowCaption="False">
                                    <Paddings Padding="0px" />
                                    <Items>
                                        <dx:LayoutItem Caption="Perfiles" FieldName="Nombre" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView ID="gvPerfiles" runat="server" AutoGenerateColumns="False" DataSourceID="odsEditarPerfiles" KeyFieldName="UsuarioID;EmpresaID;PerfilID" Width="450px" ClientInstanceName="gvPerfiles" OnBatchUpdate="gvPerfiles_BatchUpdate" OnInitNewRow="gvPerfiles_InitNewRow">
                                                        <SettingsPager Mode="ShowAllRecords">
                                                        </SettingsPager>
                                                        <SettingsEditing Mode="Inline">
                                                        </SettingsEditing>
                                                        <SettingsBehavior ConfirmDelete="True" />
                                                        <SettingsCommandButton>
                                                            <NewButton>
                                                                <Image IconID="actions_add_16x16">
                                                                </Image>
                                                            </NewButton>
                                                            <UpdateButton>
                                                                <Image IconID="actions_apply_16x16">
                                                                </Image>
                                                            </UpdateButton>
                                                            <CancelButton>
                                                                <Image IconID="actions_reset_16x16office2013">
                                                                </Image>
                                                            </CancelButton>
                                                            <EditButton ButtonType="Link">
                                                                <Image IconID="actions_editname_16x16">
                                                                </Image>
                                                            </EditButton>
                                                            <DeleteButton>
                                                                <Image IconID="actions_cancel_16x16">
                                                                </Image>
                                                            </DeleteButton>
                                                        </SettingsCommandButton>
                                                        <SettingsDataSecurity AllowEdit="False" />
                                                        <Columns>
                                                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                                            </dx:GridViewCommandColumn>
                                                            <dx:GridViewDataTextColumn FieldName="UsuarioID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CompositeKey" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Empresa" FieldName="EmpresaID" ShowInCustomizationForm="True" VisibleIndex="3" Width="200px">
                                                                <PropertiesComboBox DataSourceID="odsEmpresa" TextField="Nombre" ValueField="EmpresaID">
                                                                    <ClearButton Visibility="Auto">
                                                                    </ClearButton>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn Caption="Perfil" FieldName="PerfilID" ShowInCustomizationForm="True" VisibleIndex="4" Width="200px">
                                                                <PropertiesComboBox DataSourceID="odsPerfil" TextField="Nombre" ValueField="PerfilID">
                                                                    <ClearButton Visibility="Auto">
                                                                    </ClearButton>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                        </Columns>
                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                    <SettingsItems VerticalAlign="Top" />
                </dx:ASPxFormLayout>
                <asp:HiddenField ID="hfPerfilesID" runat="server" />
                <asp:ObjectDataSource ID="odsEditarPerfiles" runat="server" SelectMethod="ListadoPerfiles" TypeName="Cosmos.Seguridad.Api.Client.Usuario" InsertMethod="GuardarPerfil" DeleteMethod="EliminarPerfil">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuarioID" SessionField="Usuario_Listado_UsuarioID" Type="Int32" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:SessionParameter Name="usuarioID" SessionField="Usuario_Listado_UsuarioID" Type="Int32" />                        
                        <asp:Parameter Name="perfilID" Type="Int32" />
                        <asp:Parameter Name="empresaID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:SessionParameter Name="usuarioID" SessionField="Usuario_Listado_UsuarioID" Type="Int32" />                        
                        <asp:Parameter Name="perfilID" Type="Int32" />
                        <asp:Parameter Name="empresaID" Type="Int32" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="UsuarioID" OnBatchUpdate="Grid_BatchUpdate" OnCustomCallback="Grid_CustomCallback">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" 
            CustomButtonClick="function(s, e) {

               if(e.buttonID=='Nuevo'){Nuevo();}
	if(e.buttonID=='Editar'){s.GetRowValues(e.visibleIndex, 'UsuarioID', Editar);}
if(e.buttonID=='Eliminar'){s.GetRowValues(e.visibleIndex, 'UsuarioID', Eliminar);}
	if(e.buttonID=='Perfiles'){s.GetRowValues(e.visibleIndex, 'UsuarioID', EditarPerfiles);}
}" />
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <Settings ShowFilterRow="True" />
        <SettingsBehavior ConfirmDelete="False" />
        <SettingsCommandButton>
            <NewButton>
                <Image IconID="actions_add_16x16">
                </Image>
            </NewButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>

        </SettingsCommandButton>        
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Link" Caption=" " VisibleIndex="0" Width="40px" CellStyle-Paddings-Padding="5px">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Eliminar" Text="Eliminar">
                        <Image IconID="actions_cancel_16x16"></Image>
                    </dx:GridViewCommandColumnCustomButton>
                    <dx:GridViewCommandColumnCustomButton ID="Editar" Text="Editar">
                        <Image IconID="actions_editname_16x16">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                    <dx:GridViewCommandColumnCustomButton ID="Perfiles" Text="Perfiles">
                        <Image IconID="businessobjects_bodepartment_16x16">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
<HeaderStyle HorizontalAlign="Center" />
<CellStyle>
<Paddings Padding="5px"></Paddings>
</CellStyle>
                <HeaderTemplate>
                    <dx:ASPxButton ID="btnNuevo" runat="server" AutoPostBack="False" ClientInstanceName="btnNuevo" RenderMode="Link" Text="Nuevo">
                        <ClientSideEvents Click="function(s, e) {
	Nuevo();
}" />
                        <Image IconID="actions_add_16x16">
                        </Image>
                    </dx:ASPxButton>
                </HeaderTemplate>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="UsuarioID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Correo Electronico" FieldName="CorreoElectronico" VisibleIndex="2" Width="200px">
                <PropertiesTextEdit MaxLength="150">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Contrasena" FieldName="Contrasena" VisibleIndex="3" Width="300px" Visible="False">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="4" Width="200px">
                <PropertiesTextEdit MaxLength="150">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Alias" FieldName="Alias" VisibleIndex="5" Width="300px" Visible="False">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataCheckColumn VisibleIndex="6" Caption="Activo" FieldName="Activo" Width="80px">
                <PropertiesCheckEdit DisplayFormatString="g">
                </PropertiesCheckEdit>
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataSpinEditColumn VisibleIndex="7" Caption="Intentos" FieldName="Intentos" Visible="False">
                <PropertiesSpinEdit DisplayFormatString="n0" MaxLength="5" NumberFormat="Number" DecimalPlaces="0">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataCheckColumn VisibleIndex="8" Caption="Bloqueado" FieldName="Bloqueado" Width="80px">
                <PropertiesCheckEdit DisplayFormatString="g">
                </PropertiesCheckEdit>
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataTextColumn Caption="Usuario AD" FieldName="UsuarioAD" VisibleIndex="9" Width="300px" Visible="False">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataCheckColumn VisibleIndex="10" Caption="Administrador" FieldName="Administrador" Width="80px">
                <PropertiesCheckEdit DisplayFormatString="g">
                </PropertiesCheckEdit>
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataDateColumn VisibleIndex="11" Caption="Ultimo Acceso" FieldName="UltimoAcceso" Width="150px">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss" EditFormat="Custom" EditFormatString="dd/MM/yyyy" EnableFocusedStyle="False">
                    <TimeSectionProperties>
                        <TimeEditProperties>
                            <ClearButton Visibility="Auto">
                            </ClearButton>
                        </TimeEditProperties>
                    </TimeSectionProperties>
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataSpinEditColumn VisibleIndex="14" Caption="Ultima Opcion ID" FieldName="UltimaOpcionID" Visible="False">
                <PropertiesSpinEdit DisplayFormatString="n0" MaxLength="5" NumberFormat="Number" DecimalPlaces="0">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn Caption="Ultima IP" FieldName="UltimaIP" VisibleIndex="15" >
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
                    
            <dx:GridViewDataComboBoxColumn Caption="Ultima Empresa" FieldName="UltimaEmpresaID" VisibleIndex="12">
                <PropertiesComboBox DataSourceID="odsEmpresa" DisplayFormatString="g" MaxLength="5" TextField="Nombre" ValueField="EmpresaID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Ultimo Modulo" FieldName="UltimoModuloID" VisibleIndex="13">
                <PropertiesComboBox DataSourceID="odsModulo" DisplayFormatString="g" MaxLength="5" TextField="Nombre" ValueField="ModuloID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
                    
        </Columns>

    </dx:ASPxGridView>
    
</asp:Content>

