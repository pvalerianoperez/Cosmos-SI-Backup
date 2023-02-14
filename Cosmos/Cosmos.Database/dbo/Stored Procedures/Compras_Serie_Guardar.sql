
CREATE PROCEDURE Compras_Serie_Guardar
@ModificacionUsuarioID int = null,
@SerieID int,
@TipoDocumentoID int,
@SerieClave varchar(10),
@FolioInicial int,
@FolioFinal int,
@UltimoFolio int,
@Estatus bit,
@Predeterminado bit,
@SucursalID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT SerieID FROM Serie WHERE SerieID = @SerieID)
    BEGIN
        UPDATE  Serie
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                TipoDocumentoID = @TipoDocumentoID,
				SerieClave = @SerieClave,
				FolioInicial = @FolioInicial,
				FolioFinal = @FolioFinal,
				UltimoFolio = @UltimoFolio,
				Estatus = @Estatus,
				Predeterminado = @Predeterminado,
				SucursalID = @SucursalID
        WHERE   SerieID = @SerieID
    END
    ELSE
    BEGIN        
        INSERT  INTO Serie(
                AltaUsuarioID,
                AltaFecha,
                TipoDocumentoID,
				SerieClave,
				FolioInicial,
				FolioFinal,
				UltimoFolio,
				Estatus,
				Predeterminado,
				SucursalID)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @TipoDocumentoID,
				@SerieClave,
				@FolioInicial,
				@FolioFinal,
				@UltimoFolio,
				@Estatus,
				@Predeterminado,
				@SucursalID)
        
        SET     @SerieID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SerieID as SerieID