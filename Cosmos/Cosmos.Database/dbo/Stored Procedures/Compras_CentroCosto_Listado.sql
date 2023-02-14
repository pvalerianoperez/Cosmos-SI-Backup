

CREATE PROCEDURE [dbo].[Compras_CentroCosto_Listado]
@EmpresaID int
AS

SELECT  CentroCostoID,EmpresaID, CentroCostoClave,Nombre,NombreCorto,Administracion
FROM    CentroCosto 
WHERE	EmpresaID = @EmpresaID