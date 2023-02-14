

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="TipoOpcion_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Seguridad.TipoOpcion_Listado" %>
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
        function Editar(id) {
            cbpEditar.PerformCallback("EDITAR|" + id);
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
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.TipoOpcion"></asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="PopupEditar" runat="server" ClientInstanceName="PopupEditar" HeaderText="Acciones" Height="400px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="400px">
        <HeaderImage IconID="actions_editname_16x16">
        </HeaderImage>
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditar" runat="server" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">
        <ClientSideEvents EndCallback="function(s, e) {
if(s.cp_errorMessage!=&quot;&quot;){alert(s.cp_errorMessage);}
if(s.cp_show==&quot;1&quot;){PopupEditar.Show();} else{PopupEditar.Hide();}
}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxCheckBoxList ID="chkAcciones" runat="server" ClientInstanceName="chkAcciones" DataSourceID="odsAcciones" RepeatColumns="3" TextField="Nombre" ValueField="AccionID" ValueType="System.Int32" ItemSpacing="10px">
                    <Paddings Padding="10px" />
                    <Border BorderStyle="None" />
                </dx:ASPxCheckBoxList>
                <asp:ObjectDataSource ID="odsAcciones" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Accion"></asp:ObjectDataSource>
                <br />
                <table class="dxflInternalEditorTable">
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnEditarCancelar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Cancelar" Width="200px">
                                <ClientSideEvents Click="function(s, e) {
	PopupEditar.Hide();
}" />
                                <Image IconID="actions_reset_16x16office2013">
                                </Image>
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnEditarGuardar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Guardar" Width="200px">
                                <ClientSideEvents Click="function(s, e) {
	cbpEditar.PerformCallback(&quot;GUARDAR&quot;);
}" />
                                <Image IconID="actions_apply_16x16">
                                </Image>
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="TipoOpcionID" Width="100%" OnBatchUpdate="Grid_BatchUpdate" OnCustomCallback="Grid_CustomCallback">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" CustomButtonClick="function(s, e) {
	if(e.buttonID=='Acciones'){s.GetRowValues(e.visibleIndex, 'TipoOpcionID', Editar);}}" />
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <SettingsEditing Mode="Batch">
        </SettingsEditing>
        <Settings ShowFilterRow="True" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Auto" />
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
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Link" Caption=" " ShowDeleteButton="True" VisibleIndex="0" Width="150px" ShowNewButtonInHeader="True">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Acciones" Text="Acciones">
                        <Image IconID="maps_walking_16x16">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="TipoOpcionID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="2" MinWidth="300" Width="300px">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="3" MinWidth="100">
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
                    
        </Columns>
    </dx:ASPxGridView>
    
</asp:Content>

