

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorMail_Consultar]
@PpalRepresentanteProveedorMailID int
AS

SELECT  PpalRepresentanteProveedorMailID,PpalRepresentanteProveedorID,Mail,CfgTipoMailID,Predeterminado,Comentarios
FROM    PpalRepresentanteProveedorMail
WHERE   PpalRepresentanteProveedorMailID = @PpalRepresentanteProveedorMailID