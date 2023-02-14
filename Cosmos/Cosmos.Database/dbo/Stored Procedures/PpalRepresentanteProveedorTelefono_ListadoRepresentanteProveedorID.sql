

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorTelefono_ListadoRepresentanteProveedorID]
@PpalRepresentanteProveedorID INT
AS

SELECT  PpalRepresentanteProveedorTelefonoID,PpalRepresentanteProveedorID,PRPT.EspTelefonoID,Extension,Predeterminado,Comentarios,CfgUsoTelefonoID,
		T.*
FROM    PpalRepresentanteProveedorTelefono PRPT
inner join EspTelefono T on PRPT.EspTelefonoID = T.EspTelefonoID
WHERE   PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID