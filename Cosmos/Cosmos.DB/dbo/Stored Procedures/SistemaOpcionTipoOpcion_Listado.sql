

CREATE PROCEDURE [SistemaOpcionTipoOpcion_Listado]
@OpcionID int
AS

SELECT  b.OpcionTipoOpcionID, b.OpcionID, a.TipoOpcionID, a.Nombre, a.NombreCorto
FROM    dbo.SistemaTipoOpcion a
        INNER JOIN SistemaOpcionTipoOpcion b 
            ON  b.TipoOpcionID = a.TipoOpcionID
WHERE   b.OpcionID = @OpcionID