
CREATE PROCEDURE [dbo].[PpalProveedor_ListadoProveedorID]
@PpalProveedorID int
AS


SELECT	*
FROM	PpalProveedorDomicilio
WHERE	PpalProveedorID = @PpalProveedorID