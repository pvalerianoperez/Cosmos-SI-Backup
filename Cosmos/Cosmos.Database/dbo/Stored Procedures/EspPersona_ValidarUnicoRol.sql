CREATE PROCEDURE [dbo].[EspPersona_ValidarUnicoRol]
@EspPersonaID int 
AS


Select 'Representante Proveedor' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol,
	PRP.Puesto as Otro
	from PpalRepresentanteProveedor PRP
	inner join PpalProveedor PP ON PRP.PpalProveedorID = PP.PpalProveedorID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PRP.EspPersonaID = P_2.EspPersonaID
	where PRP.EspPersonaID = @EspPersonaID
UNION ALL
Select 'Proveedor' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol,
	GE.Nombre as Otro
	from PpalProveedor PP
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	inner join AuxGiroEmpresa GE on PP.AuxGiroEmpresaID = GE.AuxGiroEmpresaID
	where PP.EspPersonaID = @EspPersonaID

UNION All
Select 'Contacto Personal' as Rol, 
	CASE WHEN P_1.FisicaMoral = 'F' THEN P_1.Nombre + ' ' + P_1.ApellidoPaterno + ' ' + P_1.ApellidoMaterno  ELSE P_1.RazonSocial END + ' / ' +
	CASE WHEN P_2.FisicaMoral = 'F' THEN P_2.Nombre + ' ' + P_2.ApellidoPaterno + ' ' + P_2.ApellidoMaterno  ELSE P_2.RazonSocial END AS NombreRol,
	CP.Nombre as Otro
	from PpalContactoPersonal PCP
	inner join PpalPersonal PP ON PCP.PpalPersonalID = PP.PpalPersonalID
	inner join EspPersona P_1 ON PP.EspPersonaID = P_1.EspPersonaID
	inner join EspPersona P_2 ON PCP.EspPersonaID = P_2.EspPersonaID
	inner join SistemaTipoContactoPersonal CP on PCP.TipoContactoPersonalID = CP.TipoContactoPersonalID
	where PCP.EspPersonaID = @EspPersonaID
UNION ALL
Select 'Personal' as Rol, 
	CASE WHEN P.FisicaMoral = 'F' THEN P.Nombre + ' ' + P.ApellidoPaterno + ' ' + P.ApellidoMaterno  ELSE P.RazonSocial END AS NombreRol,
	pu.Nombre as Otro
	from PpalPersonal PP
	inner join EspPersona P ON PP.EspPersonaID = P.EspPersonaID
	inner join AuxPuesto pu on PP.AuxPuestoID = pu.AuxPuestoID
	where PP.EspPersonaID = @EspPersonaID