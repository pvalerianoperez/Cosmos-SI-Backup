

CREATE PROCEDURE [dbo].[SistemaAccion_Eliminar]
@AccionID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS

DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDABorrar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora  nvarchar(100) = 'SistemaAccion',	
		@Operacion				nvarchar(20) = 'Delete', 
		@logMessage				varchar(Max) = '',
		@isChangeBeLogged		bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION 

	SET @IDABorrar = @AccionID
    DELETE
    FROM    SistemaAccion
    WHERE   AccionID = @IDABorrar

	IF @@RowCount = 0
	BEGIN
		SELECT @Errores = 999998, @Mensaje = CONCAT('No se encontró el ID a Eliminar:', ' ', @AccionID)
		ROLLBACK TRANSACTION
	END
	ELSE
	BEGIN
    	/* Procesa Bitácora */
		-- Revisa si el borrado debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si el borrado debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1
		BEGIN
			-- LogMessage = Parámetro para borrado
			SET @logMessage = Concat('AccionID::', @AccionID, ':', 0, ';')

			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @AccionID
													,@TablaColumna1		= ''
													,@TablaColumna2		= ''
													,@Operacion			= @Operacion
													,@UsuarioID			= @UsuarioIDBitacora
													,@Descripcion		= @DescripcionBitacora
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		END
		COMMIT TRANSACTION
	END
 
END TRY
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDABorrar as EliminarID
SET NOCOUNT OFF