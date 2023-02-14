<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cosmos.Website.Cuenta.Login" %>


<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Recursos/Css/Sitio.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="divCenter">
    
        <asp:Image ID="imgSplash" runat="server" ImageUrl="~/Recursos/Imagenes/Splash.png" />
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="350px" HeaderText="Iniciar Sesión">
            <PanelCollection>
<dx:PanelContent runat="server">
    <table class="dxic-fileManager">
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Correo Electrónico">
                </dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTextBox ID="txtCorreoElectronico" runat="server" Width="100%" MaxLength="150">
                    <validationsettings errordisplaymode="Text" errortext="El correo electrónico es requerido" setfocusonerror="True">
                        <requiredfield isrequired="True" />
                    </validationsettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Contraseña">
                </dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTextBox ID="txtContrasena" runat="server" Width="100%" MaxLength="20" Password="True">
                    <validationsettings errordisplaymode="Text" errortext="La contraseña es requerida" setfocusonerror="True">
                        <requiredfield isrequired="True" />
                    </validationsettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="btnContinuar" runat="server" OnClick="btnContinuar_Click" Text="Continuar">
                </dx:ASPxButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
                </dx:PanelContent>
</PanelCollection>
        </dx:ASPxRoundPanel>
        <br />
                <dx:ASPxValidationSummary runat="server" ID="ASPxValidationSummary1"></dx:ASPxValidationSummary>

            <dx:ASPxLabel ID="lblError" runat="server" ForeColor="#FF3300">
        </dx:ASPxLabel>
        </div>
    </form>
</body>
</html>
