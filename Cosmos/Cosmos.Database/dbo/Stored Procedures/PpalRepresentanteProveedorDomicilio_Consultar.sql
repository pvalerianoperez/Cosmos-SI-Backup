﻿

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorDomicilio_Consultar]
@PpalRepresentanteProveedorDomicilioID int
AS

SELECT  PpalRepresentanteProveedorDomicilioID,PpalRepresentanteProveedorID,EspDomicilioID,Comentario,Predeterminado,CfgTipoDomicilioID
FROM    PpalRepresentanteProveedorDomicilio
WHERE   PpalRepresentanteProveedorDomicilioID = @PpalRepresentanteProveedorDomicilioID