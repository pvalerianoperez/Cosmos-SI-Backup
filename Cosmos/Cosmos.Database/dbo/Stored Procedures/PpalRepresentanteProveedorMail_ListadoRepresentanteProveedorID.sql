﻿

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorMail_ListadoRepresentanteProveedorID]
@PpalRepresentanteProveedorID INT
AS

SELECT  PpalRepresentanteProveedorMailID,PpalRepresentanteProveedorID,Mail,CfgTipoMailID,Predeterminado,Comentarios
FROM    PpalRepresentanteProveedorMail
WHERE   PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID