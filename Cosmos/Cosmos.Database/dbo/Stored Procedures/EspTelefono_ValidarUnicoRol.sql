CREATE PROCEDURE [dbo].[EspTelefono_ValidarUnicoRol]
@TelefonoID int 
AS


Select 'Representante Proveedor' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol
	from PpalRepresentanteProveedorTelefono PRPT
	inner join PpalRepresentanteProveedor PRP ON PRPT.PpalRepresentanteProveedorID = PRP.PpalRepresentanteProveedorID 
	inner join PpalProveedor PP ON PRP.PpalProveedorID = PP.PpalProveedorID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PRP.EspPersonaID = P_2.EspPersonaID
	where PRPT.EspTelefonoID = @TelefonoID
UNION ALL
Select 'Proveedor' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol
	from PpalProveedorTelefono PPT
	inner join PpalProveedor PP ON PPT.PpalProveedorID = PP.PpalProveedorID
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	where PPT.EspTelefonoID = @TelefonoID

UNION All
Select 'Contacto Personal' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol
	from PpalContactoPersonalTelefono PCPT
	inner join PpalContactoPersonal PCP ON PCPT.PpalContactoPersonalID = PCP.PpalContactoPersonalID 
	inner join PpalPersonal PP ON PCP.PpalPersonalID = PP.PpalPersonalID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PCP.EspPersonaID = P_2.EspPersonaID
	where PCPT.EspTelefonoID = @TelefonoID
UNION ALL
Select 'Personal' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol
	from PpalPersonalTelefono PPT
	inner join PpalPersonal PP ON PPT.PpalPersonalID = PP.PpalPersonalID
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	where PPT.EspTelefonoID = @TelefonoID