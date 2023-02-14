

CREATE PROCEDURE Compras_CompraEncabezado_Guardar
@ModificacionUsuarioID int = null,
@CompraEncabezadoID int,
@SucursalID int,
@TipoDocumentoID int,
@SerieID int,
@Folio int,
@ProveedorID int,
@TipoMovimientoProveedorID int,
@PersonalID int,
@Fecha datetime,
@Referencia varchar(50),
@Concepto varchar(100),
@EstatusDocumentoID int,
@PreAutorizada bit,
@UsuarioIDPreAutoriza int,
@FechaPreAutoriza datetime,
@Autorizada bit,
@UsuarioIDAutoriza int,
@FechaAutoriza datetime
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT CompraEncabezadoID FROM CompraEncabezado WHERE CompraEncabezadoID = @CompraEncabezadoID)
    BEGIN
        UPDATE  CompraEncabezado
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                SucursalID = @SucursalID,
				TipoDocumentoID = @TipoDocumentoID,
				SerieID = @SerieID,
				Folio = @Folio,
				ProveedorID = @ProveedorID,
				TipoMovimientoProveedorID = @TipoMovimientoProveedorID,
				PersonalID = @PersonalID,
				Fecha = @Fecha,
				Referencia = @Referencia,
				Concepto = @Concepto,
				EstatusDocumentoID = @EstatusDocumentoID,
				PreAutorizada = @PreAutorizada,
				UsuarioIDPreAutoriza = @UsuarioIDPreAutoriza,
				FechaPreAutoriza = @FechaPreAutoriza,
				Autorizada = @Autorizada,
				UsuarioIDAutoriza = @UsuarioIDAutoriza,
				FechaAutoriza = @FechaAutoriza
        WHERE   CompraEncabezadoID = @CompraEncabezadoID
    END
    ELSE
    BEGIN        
        INSERT  INTO CompraEncabezado(
                AltaUsuarioID,
                AltaFecha,
                SucursalID,
				TipoDocumentoID,
				SerieID,
				Folio,
				ProveedorID,
				TipoMovimientoProveedorID,
				PersonalID,
				Fecha,
				Referencia,
				Concepto,
				EstatusDocumentoID,
				PreAutorizada,
				UsuarioIDPreAutoriza,
				FechaPreAutoriza,
				Autorizada,
				UsuarioIDAutoriza,
				FechaAutoriza)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @SucursalID,
				@TipoDocumentoID,
				@SerieID,
				@Folio,
				@ProveedorID,
				@TipoMovimientoProveedorID,
				@PersonalID,
				@Fecha,
				@Referencia,
				@Concepto,
				@EstatusDocumentoID,
				@PreAutorizada,
				@UsuarioIDPreAutoriza,
				@FechaPreAutoriza,
				@Autorizada,
				@UsuarioIDAutoriza,
				@FechaAutoriza)
        
        SET     @CompraEncabezadoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @CompraEncabezadoID as CompraEncabezadoID