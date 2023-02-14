

CREATE PROCEDURE Compras_CompraDesglose_Listado
AS

SELECT  CompraDesgloseID,CompraDetalleID,RenglonID,SucursalID,CentroCostoID,AreaID,AlmacenID,ConceptoEgresoID,CuentaContableID,Cantidad,OrdenCompraDetalleID
FROM    CompraDesglose