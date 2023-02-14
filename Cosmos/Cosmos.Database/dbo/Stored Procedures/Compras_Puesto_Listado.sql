

CREATE PROCEDURE [dbo].[Compras_Puesto_Listado]
@EmpresaID int
AS

SELECT  PuestoID,EmpresaID, PuestoClave,Nombre,NombreCorto,Sueldo,BaseNeto,Tipo,Objetivo,ReqAcademicos,TiempoDesempeno
FROM    Puesto
WHERE	EmpresaID = @EmpresaID