
CREATE PROCEDURE [dbo].[PpalProveedorFecha_ListadoProveedorID]
@PpalProveedorID int
AS


SELECT	PF.*,TF.Nombre as TipoFechaNombre
FROM	PpalProveedorFecha PF
inner join CfgTipoFecha TF on PF.CfgTipoFechaID = TF.CfgTipoFechaID
WHERE	PpalProveedorID = @PpalProveedorID