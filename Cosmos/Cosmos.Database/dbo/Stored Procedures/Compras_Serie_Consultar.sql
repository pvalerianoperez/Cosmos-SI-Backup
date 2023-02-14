
CREATE PROCEDURE Compras_Serie_Consultar
@SerieID int
AS

SELECT  SerieID,TipoDocumentoID,SerieClave,FolioInicial,FolioFinal,UltimoFolio,Estatus,Predeterminado,SucursalID
FROM    Serie
WHERE   SerieID = @SerieID