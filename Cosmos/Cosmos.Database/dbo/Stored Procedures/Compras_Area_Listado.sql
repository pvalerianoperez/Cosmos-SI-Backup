

CREATE PROCEDURE [dbo].[Compras_Area_Listado]
@EmpresaID int
AS

SELECT  AreaId,EmpresaID,AreaClave,Nombre,NombreCorto
FROM    Area 
WHERE	EmpresaID = @EmpresaID