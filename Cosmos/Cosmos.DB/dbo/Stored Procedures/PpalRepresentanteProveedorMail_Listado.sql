

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorMail_Listado]
AS

SELECT  PpalRepresentanteProveedorMailID,PpalRepresentanteProveedorID,Mail,CfgTipoMailID,Predeterminado,Comentarios
FROM    PpalRepresentanteProveedorMail