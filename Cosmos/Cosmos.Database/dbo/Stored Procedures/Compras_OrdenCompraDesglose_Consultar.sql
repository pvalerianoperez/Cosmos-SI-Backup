

CREATE PROCEDURE Compras_OrdenCompraDesglose_Consultar
@OrdenCompraDesgloseID int
AS

SELECT  OrdenCompraDesgloseID,OrdenCompraDetalleID,RenglonID,SucursalID,CentroCostoID,AreaID,AlmacenID,ConceptoEgresoID,CuentaContableID,Cantidad,RequisicionDetalleID
FROM    OrdenCompraDesglose
WHERE   OrdenCompraDesgloseID = @OrdenCompraDesgloseID