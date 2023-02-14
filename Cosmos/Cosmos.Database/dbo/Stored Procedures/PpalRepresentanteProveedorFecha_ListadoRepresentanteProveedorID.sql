
CREATE PROCEDURE [dbo].[PpalRepresentanteProveedorFecha_ListadoRepresentanteProveedorID]
@PpalRepresentanteProveedorID int
AS


SELECT	*
FROM	PpalRepresentanteProveedorFecha
WHERE	PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID