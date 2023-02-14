

CREATE PROCEDURE Compras_CompraDetalle_Consultar
@CompraDetalleID int
AS

SELECT  CompraDetalleID,CompraEncabezadoID,RenglonID,ProductoID,Cantidad,UnidadID,Costo
FROM    CompraDetalle
WHERE   CompraDetalleID = @CompraDetalleID