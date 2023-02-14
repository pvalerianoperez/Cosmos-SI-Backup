<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionEmpresa.aspx.cs" Inherits="Cosmos.Website.Sistema.SeleccionEmpresa" %>

<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register src="../Recursos/UserControls/ucSeleccionEmpresa.ascx" tagname="ucSeleccionEmpresa" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <uc1:ucSeleccionEmpresa ID="ucSeleccionEmpresa1" runat="server" />
    
    </form>
</body>
</html>
