

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Perfil_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Seguridad.Perfil_Listado" %>
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
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Perfil"></asp:ObjectDataSource>
    <dx:ASPxCallback ID="cbAcciones" runat="server" ClientInstanceName="cbAcciones" OnCallback="cbAcciones_Callback">
    </dx:ASPxCallback>
    <dx:ASPxPopupControl ID="PopupEditar" runat="server" ClientInstanceName="PopupEditar" HeaderText="Opciones" Height="400px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="800px">
        <HeaderImage IconID="actions_editname_16x16">
        </HeaderImage>
        <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <table border="0">
                <tr valign="top">
                    <td>
                    <dx:ASPxCallbackPanel ID="cbpEditar" runat="server" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">
                        <ClientSideEvents EndCallback="function(s, e) {
                if(s.cp_errorMessage!=&quot;&quot;){alert(s.cp_errorMessage);}
                if(s.cp_show==&quot;1&quot;){PopupEditar.Show();} else{PopupEditar.Hide();}
                }" />
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxTreeList ID="tlOpciones" runat="server" AutoGenerateColumns="False" ClientInstanceName="tlOpciones" DataSourceID="odsOpciones" 
                                    KeyFieldName="OpcionID" ParentFieldName="PadreID" OnFocusedNodeChanged="tlOpciones_FocusedNodeChanged" OnSelectionChanged="tlOpciones_SelectionChanged" Width="400px">
                                    <Columns>
                                        <dx:TreeListTextColumn FieldName="OpcionID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="ModuloID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="PadreID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                        </dx:TreeListTextColumn>
                                        <dx:TreeListTextColumn FieldName="Nombre" ShowInCustomizationForm="True" VisibleIndex="4">
                                        </dx:TreeListTextColumn>
                                    </Columns>
                                    <Settings ScrollableHeight="300" ShowColumnHeaders="False" VerticalScrollBarMode="Visible" />
                                    <SettingsBehavior AutoExpandAllNodes="True" ProcessFocusedNodeChangedOnServer="True" ProcessSelectionChangedOnServer="True" AllowAutoFilter="False" AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False" />
                                    <SettingsSelection Enabled="True" Recursive="True" />
                                    <SettingsEditing AllowNodeDragDrop="True" />

<SettingsPopup>
<HeaderFilter MinHeight="140px"></HeaderFilter>
</SettingsPopup>

                                    <ClientSideEvents CustomButtonClick="function(s, e) {
                                        if(e.buttonID=='Nuevo'){NuevaOpcion(e.nodeKey);}
	                if(e.buttonID=='Editar'){EditarOpcion(e.nodeKey);}
                if(e.buttonID=='Eliminar'){EliminarOpcion(e.nodeKey);}
	
                }" EndCallback="function(s, e) {
	cbpEditarAcciones.PerformCallback();
}" FocusedNodeChanged="function(s, e) {
}" />
                                </dx:ASPxTreeList>                                            
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>                
                    </td>
                    <td>
                    <dx:ASPxCallbackPanel ID="cbpEditarAcciones" runat="server" ClientInstanceName="cbpEditarAcciones" OnCallback="cbpEditarAcciones_Callback">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxListBox ID="lstAcciones" runat="server" ClientInstanceName="lstAcciones" DataSourceID="odsOpcionAcciones" OnSelectedIndexChanged="lstAcciones_SelectedIndexChanged" Rows="20" SelectionMode="CheckColumn" TextField="Nombre" ValueField="AccionID" ValueType="System.Int32" EnableClientSideAPI="False" EnableCallbackMode="True" Width="400px" Height="300px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
e.processOnServer=false;
var sSel= '-1';
var selection = s.GetSelectedItems();
for(var i = 0; i &lt; selection.length; i++) {
          sSel= sSel+ '|' + selection[i].value;
     }
cbAcciones.PerformCallback(sSel);

}" />
                                    <Border BorderStyle="None" />
                                </dx:ASPxListBox>
                                <asp:ObjectDataSource ID="odsOpcionAcciones" runat="server" SelectMethod="ListadoOpcionID" TypeName="Cosmos.Seguridad.Api.Client.Accion">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="opcionID" SessionField="Perfil_Listado_OpcionID" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table class="dxflInternalEditorTable">
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="btnEditarCancelar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Cancelar" Width="400px">
                                        <ClientSideEvents Click="function(s, e) {PopupEditar.Hide();}" />
                                        <Image IconID="actions_reset_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnEditarGuardar" runat="server" AutoPostBack="False" Font-Bold="True" ImagePosition="Top" Text="Guardar" Width="400px">
                                        <ClientSideEvents Click="function(s, e) {cbpEditar.PerformCallback(&quot;GUARDAR&quot;);}" />
                                        <Image IconID="actions_apply_16x16"></Image>
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    
        </dx:PopupControlContentControl>
    </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="PerfilID" Width="100%" OnBatchUpdate="Grid_BatchUpdate">
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" CustomButtonClick="function(s, e) {
	if(e.buttonID=='Opciones'){s.GetRowValues(e.visibleIndex, 'PerfilID', Editar);}}" />
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
                    <dx:GridViewCommandColumnCustomButton ID="Opciones" Text="Opciones">
                        <Image IconID="maps_walking_16x16">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="PerfilID" VisibleIndex="1" Width="50px" ReadOnly="true" Visible="False">
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

