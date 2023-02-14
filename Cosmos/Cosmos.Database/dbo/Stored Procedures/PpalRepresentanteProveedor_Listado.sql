

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedor_Listado]
AS

SELECT  
PRP.PpalRepresentanteProveedorID,PRP.PpalProveedorID,PRP.EspPersonaID,PRP.ProfesionID,PRP.CmpTipoRepresentanteProveedorID,PRP.Predeterminado,PRP.Puesto,P.ApellidoPaterno,
		P.ApellidoMaterno,P.NombreCorto,P.*
FROM    PpalRepresentanteProveedor PRP
inner join EspPersona P on PRP.EspPersonaID = p.EspPersonaID