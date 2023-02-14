

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedor_ListadoProveedorID]
@PpalProveedorID INT
AS

SELECT  PpalRepresentanteProveedorID,PpalProveedorID,P.EspPersonaID,ProfesionID,CmpTipoRepresentanteProveedorID,Predeterminado,Puesto,P.*
FROM    PpalRepresentanteProveedor PRP
inner join EspPersona P on PRP.EspPersonaID = p.EspPersonaID
WHERE  PpalProveedorID = @PpalProveedorID