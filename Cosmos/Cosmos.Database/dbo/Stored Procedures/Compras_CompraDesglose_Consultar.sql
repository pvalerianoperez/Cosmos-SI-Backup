

CREATE PROCEDURE Compras_CompraDesglose_Consultar
@CompraDesgloseID int
AS

SELECT  CompraDesgloseID,CompraDetalleID,RenglonID,SucursalID,CentroCostoID,AreaID,AlmacenID,ConceptoEgresoID,CuentaContableID,Cantidad,OrdenCompraDetalleID
FROM    CompraDesglose
WHERE   CompraDesgloseID = @CompraDesgloseID