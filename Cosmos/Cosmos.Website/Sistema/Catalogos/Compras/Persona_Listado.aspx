

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Persona_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Compras.Persona_Listado" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
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
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Persona"></asp:ObjectDataSource>
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="PersonaID" Width="100%" OnBatchUpdate="Grid_BatchUpdate">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <SettingsEditing Mode="Batch">
        </SettingsEditing>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" />
        <SettingsBehavior ConfirmDelete="False" />
        <SettingsCommandButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>        
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" Caption=" " ShowDeleteButton="True" VisibleIndex="0" Width="40px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="PersonaID" VisibleIndex="1" Width="50px" ReadOnly="true">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Persona Clave" FieldName="PersonaClave" VisibleIndex="2" Width="60px">
                <PropertiesTextEdit MaxLength="10">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Fisica Moral" FieldName="FisicaMoral" VisibleIndex="3" Width="40px">
                <PropertiesTextEdit MaxLength="1">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Comercial" FieldName="NombreComercial" VisibleIndex="4" Width="500px">
                <PropertiesTextEdit MaxLength="120">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Razon Social" FieldName="RazonSocial" VisibleIndex="5" Width="500px">
                <PropertiesTextEdit MaxLength="120">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="6" Width="210px">
                <PropertiesTextEdit MaxLength="35">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="7" Width="180px">
                <PropertiesTextEdit MaxLength="30">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="8" Width="180px">
                <PropertiesTextEdit MaxLength="30">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="RFC" FieldName="RFC" VisibleIndex="9" Width="78px">
                <PropertiesTextEdit MaxLength="13">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="CURP" FieldName="CURP" VisibleIndex="10" Width="108px">
                <PropertiesTextEdit MaxLength="18">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataComboBoxColumn Caption="Sexo" FieldName="SexoID" VisibleIndex="11">
                <PropertiesComboBox DataSourceID="ObjectDataSource11" TextField="Nombre" ValueField="SexoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataDateColumn VisibleIndex="12" Caption="Fecha Nacimiento" FieldName="FechaNacimiento">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" EnableFocusedStyle="False">
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
            <dx:GridViewDataComboBoxColumn Caption="Ciudad Nacimiento" FieldName="CiudadNacimientoID" VisibleIndex="13">
                <PropertiesComboBox DataSourceID="ObjectDataSource13" TextField="Nombre" ValueField="CiudadNacimientoID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Estado Civil" FieldName="EstadoCivilID" VisibleIndex="14">
                <PropertiesComboBox DataSourceID="ObjectDataSource14" TextField="Nombre" ValueField="EstadoCivilID">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn VisibleIndex="15" Caption="Casado Civil" FieldName="CasadoCivil">
                <PropertiesCheckEdit DisplayFormatString="g">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn VisibleIndex="16" Caption="Casado Iglesia" FieldName="CasadoIglesia">
                <PropertiesCheckEdit DisplayFormatString="g">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataTextColumn Caption="Iniciales" FieldName="Iniciales" VisibleIndex="17" Width="40px">
                <PropertiesTextEdit MaxLength="6">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Sobre Nombre" FieldName="SobreNombre" VisibleIndex="18" Width="150px">
                <PropertiesTextEdit MaxLength="25">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataSpinEditColumn VisibleIndex="19" Caption="Alta Usuario ID" FieldName="AltaUsuarioID">
                <PropertiesSpinEdit DisplayFormatString="n0" MaxLength="5" NumberFormat="Number" DecimalPlaces="0">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataDateColumn VisibleIndex="20" Caption="Alta Fecha" FieldName="AltaFecha">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" EnableFocusedStyle="False">
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
            <dx:GridViewDataSpinEditColumn VisibleIndex="21" Caption="Modificacion Usuario ID" FieldName="ModificacionUsuarioID">
                <PropertiesSpinEdit DisplayFormatString="n0" MaxLength="5" NumberFormat="Number" DecimalPlaces="0">
                    <ClearButton Visibility="Auto">
                    </ClearButton>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataDateColumn VisibleIndex="22" Caption="Modificacion Fecha" FieldName="ModificacionFecha">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" EnableFocusedStyle="False">
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
                    
        </Columns>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" SelectMethod="Listado" TypeName=""></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource13" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.Ciudad"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource14" runat="server" SelectMethod="Listado" TypeName="Cosmos.Compras.Api.Client.EstadoCivil"></asp:ObjectDataSource>

</asp:Content>

