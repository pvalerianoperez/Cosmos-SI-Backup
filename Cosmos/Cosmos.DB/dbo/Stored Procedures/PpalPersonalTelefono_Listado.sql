

CREATE PROCEDURE [dbo].[PpalPersonalTelefono_Listado]
AS

SELECT  a.PpalPersonalTelefonoID, a.PpalPersonalID, a.EspTelefonoID, a.Extension, a.Predeterminado, a.Comentarios,a.CfgUsoTelefonoID,
		b.ClaveTelefonicaPais, b.NumeroTelefonico, b.CfgTipoTelefonoID, b.CfgTipoTelefonoID
FROM    PpalPersonalTelefono a 
		INNER JOIN EspTelefono b ON a.EspTelefonoID = b.EspTelefonoID