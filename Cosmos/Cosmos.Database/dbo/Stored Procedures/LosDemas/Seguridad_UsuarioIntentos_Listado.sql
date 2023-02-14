

CREATE PROCEDURE Seguridad_UsuarioIntentos_Listado
AS

SELECT  UsuarioID,Fecha,IP,Contrasena
FROM    SistemaUsuarioIntentos