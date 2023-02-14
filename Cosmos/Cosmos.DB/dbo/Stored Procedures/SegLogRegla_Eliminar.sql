CREATE PROCEDURE [dbo].[SegLogRegla_Eliminar]
@SegLogReglaID	int
/************************************************/
	-- Parámetros para Log
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
	/************************************************/
As

DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDABorrar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegLogRegla',	
		@Operacion	nvarchar(20) = 'Delete', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@SysTablesName_ varchar(50) = '', @SegUsuarioID_ int = 0,
		@TablaNombre_ varchar(50) = 0,    @C_ tinyint = 0,	@U_ tinyint = 0,	
		@R_ tinyint = 0,                  @D_ tinyint = 0;

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

    SET @IDABorrar = @SegLogReglaID
	BEGIN
		DELETE
		FROM    SegLogRegla
		WHERE   SegLogReglaID = @SegLogReglaID

		/****************************************************************************/
		/* Log */
		-- Si no se encontró registro a eliminar -> error
		IF @@RowCount = 0
		BEGIN
			SELECT @Errores = 999998, @Mensaje = CONCAT('No se encontró el ID a Eliminar:', ' ', @IDABorrar)
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
			SET @logMessage = Concat('SegLogReglaID::', @SegLogReglaID, ':', 0, ';')

			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDABorrar
													,@TablaColumna1		= ''
													,@TablaColumna2		= ''
													,@Operacion			= @Operacion
													,@UsuarioID			= @UsuarioIDBitacora
													,@Descripcion		= @DescripcionBitacora
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		END
			-- Fin de proceso sin errores -> COMMIT
			COMMIT TRANSACTION
		END
	END
END TRY
-- Si hubo error los procesa y lo regresa
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