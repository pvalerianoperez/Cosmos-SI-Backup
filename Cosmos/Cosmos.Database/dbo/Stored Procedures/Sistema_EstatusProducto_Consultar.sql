

CREATE PROCEDURE Sistema_EstatusProducto_Consultar
@EstatusProductoID int
AS

SELECT  EstatusProductoID,EstatusProductoClave,Nombre,NombreCorto
FROM    SistemaEstatusProducto
WHERE   EstatusProductoID = @EstatusProductoID