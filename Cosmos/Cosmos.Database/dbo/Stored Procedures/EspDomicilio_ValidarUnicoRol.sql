

CREATE PROCEDURE [dbo].[EspDomicilio_ValidarUnicoRol]
@DomicilioID int
AS


Select 'Representante Proveedor' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol
	from PpalRepresentanteProveedorDomicilio PRPD
	inner join PpalRepresentanteProveedor PRP ON PRPD.PpalRepresentanteProveedorID = PRP.PpalRepresentanteProveedorID 
	inner join PpalProveedor PP ON PRP.PpalProveedorID = PP.PpalProveedorID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PRP.EspPersonaID = P_2.EspPersonaID
	where PRPD.EspDomicilioID = @DomicilioID
UNION ALL
Select 'Proveedor' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol
	from PpalProveedorDomicilio PPD
	inner join PpalProveedor PP ON PPD.PpalProveedorID = PP.PpalProveedorID
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	where PPD.EspDomicilioID = @DomicilioID

UNION All
Select 'Contacto Personal' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol
	from PpalContactoPersonalDomicilio PCPT
	inner join PpalContactoPersonal PCP ON PCPT.PpalContactoPersonalID = PCP.PpalContactoPersonalID 
	inner join PpalPersonal PP ON PCP.PpalPersonalID = PP.PpalPersonalID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PCP.EspPersonaID = P_2.EspPersonaID
	where PCPT.EspDomicilioID = @DomicilioID
UNION ALL
Select 'Personal' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol
	from PpalPersonalDomicilio PPT
	inner join PpalPersonal PP ON PPT.PpalPersonalID = PP.PpalPersonalID
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	where PPT.EspDomicilioID = @DomicilioID