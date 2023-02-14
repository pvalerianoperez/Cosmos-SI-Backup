

CREATE PROCEDURE Compras_Profesion_Consultar
@ProfesionID int
AS

SELECT  ProfesionID,ProfesionClave,Nombre,NombreCorto
FROM    Profesion
WHERE   ProfesionID = @ProfesionID