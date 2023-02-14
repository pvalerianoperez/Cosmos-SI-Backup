

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedor_Consultar]
@PpalRepresentanteProveedorID int
AS

SELECT  PpalRepresentanteProveedorID,PpalProveedorID,EspPersonaID,ProfesionID,CmpTipoRepresentanteProveedorID,Predeterminado,Puesto
FROM    PpalRepresentanteProveedor
WHERE   PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID