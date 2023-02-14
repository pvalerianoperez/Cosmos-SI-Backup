

CREATE PROCEDURE [dbo].[PpalPersonalFecha_Listado]
AS

SELECT	PpalPersonalFechaID,PpalPersonalID,Fecha,CfgTipoFechaID,Comentarios,Predeterminado
FROM    PpalPersonalFecha