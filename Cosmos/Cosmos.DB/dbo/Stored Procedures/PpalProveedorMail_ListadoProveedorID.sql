
CREATE PROCEDURE [dbo].[PpalProveedorMail_ListadoProveedorID]
@PpalProveedorID int
AS


SELECT	pm.*, tm.Nombre as TipoMailNombre
FROM	PpalProveedorMail pm
	inner join CfgTipoMail tm on pm.CfgTipoMailID = tm.CfgTipoMailID
WHERE	PpalProveedorID = @PpalProveedorID