<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Cosmos.Website.Cuenta.Logout" %>

<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:600px;margin:auto;text-align:center;padding-top:150px;">
    
        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Bold="True" Font-Size="Medium" Text="ASPxLabel">
        </dx:ASPxLabel>
        <br />
        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Font-Size="Small" Text="Continuar" NavigateUrl="Login.aspx" />
    
    </div>
    </form>
</body>
</html>
