﻿

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorFecha_Consultar]
@PpalRepresentanteProveedorFechaID int
AS

SELECT  PpalRepresentanteProveedorFechaID,PpalRepresentanteProveedorID,Fecha,CfgTipoFechaID,Comentarios,Predeterminado
FROM    PpalRepresentanteProveedorFecha
WHERE   PpalRepresentanteProveedorFechaID = @PpalRepresentanteProveedorFechaID