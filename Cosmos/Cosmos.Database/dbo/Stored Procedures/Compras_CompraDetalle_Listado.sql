

CREATE PROCEDURE Compras_CompraDetalle_Listado
AS

SELECT  CompraDetalleID,CompraEncabezadoID,RenglonID,ProductoID,Cantidad,UnidadID,Costo
FROM    CompraDetalle