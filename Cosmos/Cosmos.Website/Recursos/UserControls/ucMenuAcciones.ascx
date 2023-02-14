<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuAcciones.ascx.cs" Inherits="Cosmos.Website.Recursos.UserControls.ucMenuAcciones" %>
<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<div>
    <div class="migajaDiv">
        <table border="0">
            <tr>
                <td><dx:ASPxLabel runat="server" ID="lblMigaja" CssClass="migaja" Font-Bold="true" Font-Size="15px" Font-Names="Oswald-Bold" ForeColor="#666666"></dx:ASPxLabel></td>
                <td><dx:ASPxLabel runat="server" ID="lblMigajaUbicacionActual" CssClass="migaja" Font-Bold="true" Font-Size="18px" Font-Names="Oswald-Bold"></dx:ASPxLabel></td>
            </tr>
        </table>
    </div>
    <div style="padding-top:5px">
    <dx:ASPxMenu ID="ASPxMenu3" runat="server" ClientInstanceName="ASPxMenu1" ItemStyle-VerticalAlign="Middle" Theme="Aqua" >
        <ClientSideEvents ItemClick="function(s, e) {AccionMenuItemClick(e);}" />
        <Items>
            <dx:MenuItem Text="Agregar" Name="AGREGAR">
                <Image IconID="actions_addfile_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Modificar" Name="MODIFICAR" Visible="false">
                <Image IconID="actions_editname_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Eliminar" Name="ELIMINAR" Visible="false">
                <Image IconID="actions_deletelist2_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Imprimir" Name="IMPRIMIR">
                <Image IconID="print_print_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Exportar PDF" Name="EXPORTAR_PDF">
                <Image IconID="export_exporttopdf_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Exportar EXCEL" Name="EXPORTAR_EXCEL">
                <Image IconID="export_exporttoxlsx_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Autorizar" Name="AUTORIZAR">
                <Image IconID="actions_apply_16x16">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Text="Cancelar" Name="CANCELAR">
                <Image IconID="reports_deleteheader_16x16">
                </Image>
            </dx:MenuItem>
        </Items>
        <ItemStyle CssClass="alignText" Height="20px"   />
        <Border BorderStyle="None" />
    </dx:ASPxMenu>
    </div>
</div>
