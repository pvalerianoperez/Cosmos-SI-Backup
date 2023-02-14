CREATE PROCEDURE [dbo].[SegLogRegla_Guardar]
@SegLogReglaID		int			= null
,@SegUsuarioID		int			= 0
,@TablaNombre		varchar(50)
,@C					Bit			= 0
,@R					Bit			= 0
,@U					Bit			= 0
,@D					Bit			= 0

	/************************************************/
	/* Campos para Log */
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
	/************************************************/
As

SET NOCOUNT ON 
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegLogRegla',	
		@Operacion	nvarchar(20) = 'Create', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SegUsuarioID_	int = 0,
		@SegLogReglaID_ int = 0,
		@TablaNombre_	varchar(50) = '',
		@C_				Bit = 0,
		@R_				Bit = 0,
		@U_				Bit	= 0,
		@D_				Bit = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;

BEGIN TRY
	BEGIN TRANSACTION
	IF @Errores = 0
	BEGIN
		INSERT  INTO SegLogRegla(
				SegLogReglaID,
				SegUsuarioID,
				TablaNombre,
				C,
				R,
				U,
				D)
		VALUES  (
				@SegLogReglaID,
				@SegUsuarioID,
				@TablaNombre,
				@C,
				@R,
				@U,
				@D)
        
		SET     @IDAActualizar = SCOPE_IDENTITY()
	END
	IF @@RowCount > 0
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si el cambio debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- logMessage = Cambios efectuados
			SET @logMessage = Concat(@logMessage, 'SegLogReglaID::', @SegLogReglaID_, ':', @SegLogReglaID, ';')
			SET @logMessage = Concat(@logMessage, 'SegUsuarioID: :', @SegUsuarioID_, ':', @SegUsuarioID, ';')
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDAActualizar
													,@TablaColumna1		= ''
													,@TablaColumna2		= ''
													,@Operacion			= @Operacion
													,@UsuarioID			= @UsuarioIDBitacora
													,@Descripcion		= @DescripcionBitacora
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		END
		
	END
    -- Fin de proceso sin errores -> COMMIT
		COMMIT TRANSACTION
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID