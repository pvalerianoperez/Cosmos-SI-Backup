<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionModulo.aspx.cs" Inherits="Cosmos.Website.Sistema.SeleccionModulo" %>

<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<%@ Register src="../Recursos/UserControls/ucSeleccionModulo.ascx" tagname="ucSeleccionModulo" tagprefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <uc1:ucSeleccionModulo ID="ucSeleccionModulo1" runat="server" />
    
    </form>
</body>
</html>
