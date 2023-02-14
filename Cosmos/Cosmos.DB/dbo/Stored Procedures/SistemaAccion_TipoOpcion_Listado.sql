

CREATE PROCEDURE [SistemaAccion_TipoOpcion_Listado]
@AccionID int
AS

SELECT  a.*
FROM    dbo.SistemaTipoOpcion a
        INNER JOIN SistemaTipoOpcionAccion b 
            ON  b.TipoOpcionID = a.TipoOpcionID
WHERE   b.AccionID = @AccionID