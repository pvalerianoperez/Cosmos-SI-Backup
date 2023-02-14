

<%@ Page Title="" Language="C#" MasterPageFile="~/Recursos/MasterPages/SitioProtegido.Master" AutoEventWireup="true" CodeBehind="Modulo_Listado.aspx.cs" Inherits="Cosmos.Website.Sistema.Catalogos.Seguridad.Modulo_Listado" %>
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

        
        //botones del grid
        function NuevaOpcion(id) {
            cbpEditar.PerformCallback("NUEVO|" + id);
        }
        function EditarOpcion(id) {
            cbpEditar.PerformCallback("EDITAR|" + id);
        }
        function EliminarOpcion(id) {
            if (confirm('¿Desea ELIMINAR la opción?')) {
                cbpEditar.PerformCallback("ELIMINAR|" + id);
            }
            
        }

        //seleccion del recurso
        var recursoSeleccionado;
        var funcCancelaSeleccionado;
        function SeleccionaNodoRecurso(n) {
            var o = document.getElementById(n.contentElementID);
            if (o != null) {
                if (o.title != null) {
                    console.log("nodo click: " + o.title.trim().toLowerCase());
                    if (recursoSeleccionado == o.title.trim().toLowerCase().replace("//", "/")) {                        
                        recursoSeleccionado = recursoSeleccionado.trim().toLowerCase();
                        if (!recursoSeleccionado.endsWith(".aspx")) { recursoSeleccionado = ""; }
                        if (recursoSeleccionado != "") {                            
                            console.log("recursoSeleccionado OK, cierra ventana");
                            txtRecursoWebsite.SetText(recursoSeleccionado);
                            PopupRecursos.Hide();
                        }                        
                    } else {
                        recursoSeleccionado = o.title.trim().toLowerCase().replace("//", "/");
                    }
                } else {
                    recursoSeleccionado = "";
                }
            } else {
                recursoSeleccionado = "";
            }
            console.log("recursoSeleccionado: " + recursoSeleccionado);
            funcCancelaSeleccionado = setTimeout(CancelaSeleccionado, 1000);
        }
        function CancelaSeleccionado() {
            recursoSeleccionado = "";
            console.log("recursoSeleccionado timeout");
        }
        
        //guardar opcion
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
    <asp:ObjectDataSource ID="ods0" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.Modulo"></asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="PopupUpload" runat="server" ClientInstanceName="PopupUpload" HeaderText="Seleccione una imágen" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxUploadControl ID="uploadIcono" runat="server" ClientInstanceName="uploadIcono" OnFileUploadComplete="uploadIcono_FileUploadComplete" ShowUploadButton="True" UploadMode="Auto" Width="280px">
        <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png">
        </ValidationSettings>
        <ClientSideEvents FileUploadComplete="function(s, e) {
if(e.callbackData)&nbsp;{var&nbsp;fileData&nbsp;=&nbsp;e.callbackData.split('|');var&nbsp;fileName&nbsp;=&nbsp;fileData[0], fileUrl&nbsp;=&nbsp;fileData[1], fileSize&nbsp;=&nbsp;fileData[2];
imgIcono.SetImageUrl('');	
imgIcono.SetImageUrl(fileUrl);	
} 
	PopupUpload.Hide();
}" />
    </dx:ASPxUploadControl>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <asp:ObjectDataSource ID="odsOpciones" runat="server" SelectMethod="ListadoModuloID" TypeName="Cosmos.Seguridad.Api.Client.Opcion" DeleteMethod="Eliminar" InsertMethod="Guardar" UpdateMethod="Guardar">
        <DeleteParameters>
            <asp:Parameter Name="opcionID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="opcionID" Type="Int32" />
            <asp:Parameter Name="moduloID" Type="Int32" />
            <asp:Parameter Name="padreID" Type="Int32" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="nombreCorto" Type="String" />
            <asp:Parameter Name="recursoWebsite" Type="String" />
            <asp:Parameter Name="activo" Type="Boolean" />
            <asp:Parameter Name="protegido" Type="Boolean" />
            <asp:Parameter Name="popup" Type="Boolean" />
            <asp:Parameter Name="visibleMenu" Type="Boolean" />
            <asp:Parameter Name="icono" Type="String" />
            <asp:Parameter Name="orden" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="moduloID" SessionField="Modulo_Listado_ModuloID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="opcionID" Type="Int32" />
            <asp:Parameter Name="moduloID" Type="Int32" />
            <asp:Parameter Name="padreID" Type="Int32" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="nombreCorto" Type="String" />
            <asp:Parameter Name="recursoWebsite" Type="String" />
            <asp:Parameter Name="activo" Type="Boolean" />
            <asp:Parameter Name="protegido" Type="Boolean" />
            <asp:Parameter Name="popup" Type="Boolean" />
            <asp:Parameter Name="visibleMenu" Type="Boolean" />
            <asp:Parameter Name="icono" Type="String" />
            <asp:Parameter Name="orden" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="PopupRecursos" runat="server" ClientInstanceName="PopupRecursos" Height="400px" PopupElementID="ASPxFormLayout1_E8" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ScrollBars="Auto" Width="500px" AllowResize="True" HeaderText="Seleccione un recurso">
        <HeaderImage IconID="zoom_zoom_16x16">
        </HeaderImage>
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxTreeView ID="tvRecursos" runat="server" ClientInstanceName="tvRecursos" DataSourceID="SiteMapDataSource1" 
        NavigateUrlField="" NameField="Description"  OnDataBound="tvRecursos_DataBound" AllowSelectNode="True">
        <ClientSideEvents NodeClick="function(s, e) {
            SeleccionaNodoRecurso(e.node);

}" />
    </dx:ASPxTreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="PopupEditar" runat="server" ClientInstanceName="PopupEditar" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True" AllowResize="True" HeaderText="Edición" Width="700px">
        <HeaderImage IconID="actions_editname_16x16">
        </HeaderImage>
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <dx:ASPxCallbackPanel ID="cbpEditar" runat="server" ClientInstanceName="cbpEditar" OnCallback="cbpEditar_Callback">        
        <ClientSideEvents CallbackError="function(s, e) {
	PopupEditar.Hide();
}" EndCallback="function(s, e) {
	if(s.cp_errorMessage!=&quot;&quot;){alert(s.cp_errorMessage);}
	if(s.cp_refresh==&quot;1&quot;){tlOpciones.PerformCallback(&quot;refresh&quot;);}
if(s.cp_show==&quot;1&quot;){PopupEditar.Show();} else{PopupEditar.Hide();}
}" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="flEditar" runat="server" ClientInstanceName="flEditar" DataSourceID="odsEditar" ColCount="2" Height="500px" ShowItemCaptionColon="False">
                    <Items>
                        <dx:LayoutGroup ShowCaption="False" VerticalAlign="Top" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutGroup Caption="Datos Generales">
                                    <Items>
                                        <dx:LayoutItem Caption="Nombre" FieldName="Nombre">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtNombre" runat="server" ClientInstanceName="txtNombre" MaxLength="50" Width="100%">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Nombre Corto" FieldName="NombreCorto">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtNombreCorto" runat="server" ClientInstanceName="txtNombreCorto" MaxLength="20" Width="100%">
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
                                                <dx:LayoutItem FieldName="Protegido">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkProtegido" runat="server" CheckState="Unchecked" ClientInstanceName="chkProtegido">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem FieldName="VisibleMenu">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkVisibleMenu" runat="server" CheckState="Unchecked" ClientInstanceName="chkVisibleMenu">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem FieldName="Popup">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxCheckBox ID="chkPopup" runat="server" CheckState="Unchecked" ClientInstanceName="chkPopup">
                                                            </dx:ASPxCheckBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Icono" GroupBoxDecoration="HeadingLine" HorizontalAlign="Left">
                                            <Items>
                                                <dx:LayoutItem Caption="">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxImage ID="imgIcono" runat="server" ClientInstanceName="imgIcono" ShowLoadingImage="True">
                                                                <ClientSideEvents Click="function(s, e) {
	PopupUpload.Show();
}" />
                                                            </dx:ASPxImage>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <NestedControlCellStyle>
                                                        <Paddings Padding="0px" />
                                                    </NestedControlCellStyle>
                                                    <ParentContainerStyle>
                                                        <Paddings Padding="0px" />
                                                    </ParentContainerStyle>
                                                </dx:LayoutItem>
                                            </Items>
                                            <ParentContainerStyle>
                                                <Paddings PaddingTop="15px" />
                                            </ParentContainerStyle>
                                        </dx:LayoutGroup>
                                        <dx:LayoutItem FieldName="PadreID" Visible="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtPadreID" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Recurso a proteger:" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="" FieldName="RecursoWebsite">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtRecursoWebsite" runat="server" ClientInstanceName="txtRecursoWebsite" MaxLength="150" Width="280px">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <CaptionSettings Location="Top" />
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton ID="ASPxFormLayout1_E8" runat="server" AutoPostBack="False" Text="Seleccionar">
                                                        <ClientSideEvents Click="function(s, e) {
	PopupRecursos.Show();
}" />
                                                        <Image IconID="zoom_zoom_16x16">
                                                        </Image>
                                                    </dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                            <ParentContainerStyle>
                                                <Paddings Padding="3px" />
                                            </ParentContainerStyle>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutItem Caption="" HorizontalAlign="Left">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxButton ID="flEditar_E1" runat="server" AutoPostBack="False" Text="Guardar">
                                                <ClientSideEvents Click="function(s, e) {
	GuardarOpcion();
}" />
                                                <Image IconID="actions_apply_16x16">
                                                </Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <NestedControlCellStyle>
                                        <Paddings Padding="0px" />
                                    </NestedControlCellStyle>
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutItem Caption="" VerticalAlign="Top">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBoxList ID="lstTipoOpcion" runat="server" ClientInstanceName="lstTipoOpcion" DataSourceID="odsTipoOpcion" OnDataBound="lstTipoOpcion_DataBound" TextField="Nombre" ValueField="TipoOpcionID" ValueType="System.Int32">
                                    </dx:ASPxCheckBoxList>
                                    <asp:ObjectDataSource ID="odsTipoOpcion" runat="server" SelectMethod="Listado" TypeName="Cosmos.Seguridad.Api.Client.TipoOpcion"></asp:ObjectDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <ParentContainerStyle>
                                <Paddings Padding="15px" />
                            </ParentContainerStyle>
                        </dx:LayoutItem>
                    </Items>
                    <SettingsItems VerticalAlign="Top" />
                </dx:ASPxFormLayout>
                <asp:HiddenField ID="hfOpcionID" runat="server" />
                <asp:ObjectDataSource ID="odsEditar" runat="server" SelectMethod="Consultar" TypeName="Cosmos.Seguridad.Api.Client.Opcion">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfOpcionID" DefaultValue="0" Name="opcionID" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxGridView ID="Grid" ClientInstanceName="Grid" runat="server" DataSourceID="ods0"
        AutoGenerateColumns="False" KeyFieldName="ModuloID" Width="100%" OnBatchUpdate="Grid_BatchUpdate" >
        <ClientSideEvents EndCallback="function(s, e) {resize_grid_pane();}" />
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
        <Templates>
            <DetailRow>
                <dx:ASPxTreeList ID="tlOpciones" ClientInstanceName="tlOpciones" runat="server" AutoGenerateColumns="False" DataSourceID="odsOpciones" 
                    OnInit="ASPxTreeList1_Init" KeyFieldName="OpcionID" ParentFieldName="PadreID" OnCustomCallback="tlOpciones_CustomCallback">
                    <Columns>
                        <dx:TreeListTextColumn FieldName="OpcionID" VisibleIndex="1" Visible="false">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="ModuloID" VisibleIndex="2" Visible="false">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="PadreID" VisibleIndex="3" Visible="false">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="Nombre" VisibleIndex="4">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="NombreCorto" VisibleIndex="5">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="RecursoWebsite" VisibleIndex="6">
                        </dx:TreeListTextColumn>
                        <dx:TreeListCheckColumn FieldName="Activo" VisibleIndex="7">
                        </dx:TreeListCheckColumn>
                        <dx:TreeListCheckColumn FieldName="Protegido" VisibleIndex="8">
                        </dx:TreeListCheckColumn>
                        <dx:TreeListCheckColumn FieldName="Popup" VisibleIndex="9">
                        </dx:TreeListCheckColumn>
                        <dx:TreeListCheckColumn FieldName="VisibleMenu" VisibleIndex="10">
                        </dx:TreeListCheckColumn>
                        <dx:TreeListTextColumn FieldName="Icono" VisibleIndex="11" Visible="false">
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn FieldName="Orden" VisibleIndex="12" Visible="false">
                        </dx:TreeListTextColumn>
                        <dx:TreeListCommandColumn ButtonType="Image" Caption=" " VisibleIndex="0">
                            <EditButton>
                                <Image IconID="actions_editname_16x16">
                                </Image>
                            </EditButton>
                            <DeleteButton>
                                <Image IconID="actions_cancel_16x16">
                                </Image>
                            </DeleteButton>
                            <CustomButtons>
                                 <dx:TreeListCommandColumnCustomButton ID="Nuevo">
                                    <Image IconID="actions_add_16x16">
                                    </Image>
                                </dx:TreeListCommandColumnCustomButton>
                                <dx:TreeListCommandColumnCustomButton ID="Editar">
                                    <Image IconID="actions_editname_16x16">
                                    </Image>
                                </dx:TreeListCommandColumnCustomButton>
                                <dx:TreeListCommandColumnCustomButton ID="Eliminar">
                                    <Image IconID="actions_cancel_16x16">
                                    </Image>
                                </dx:TreeListCommandColumnCustomButton>
                            </CustomButtons>                            
                        </dx:TreeListCommandColumn>
                    </Columns>
                    <SettingsEditing AllowNodeDragDrop="True" />
                    <ClientSideEvents CustomButtonClick="function(s, e) {
                        if(e.buttonID=='Nuevo'){NuevaOpcion(e.nodeKey);}
	if(e.buttonID=='Editar'){EditarOpcion(e.nodeKey);}
if(e.buttonID=='Eliminar'){EliminarOpcion(e.nodeKey);}
	
}" />
                </dx:ASPxTreeList>
            </DetailRow>
        </Templates>
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
            <dx:GridViewDataTextColumn Caption="ID" FieldName="ModuloID" VisibleIndex="1" Width="50px" ReadOnly="true">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="2" Width="300px">
                <PropertiesTextEdit MaxLength="50">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
            <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="3" >
                <PropertiesTextEdit MaxLength="20">
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>                
                    
        </Columns>
    </dx:ASPxGridView>
    
</asp:Content>

