

CREATE PROCEDURE Sistema_Naturaleza_Consultar
@NaturalezaID int
AS

SELECT  NaturalezaID,NaturalezaClave,Nombre,NombreCorto
FROM    SistemaNaturaleza
WHERE   NaturalezaID = @NaturalezaID