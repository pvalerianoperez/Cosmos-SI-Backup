
CREATE Procedure [dbo].[SegLogRegla_Consultar]
@SegLogReglaID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

As
	-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegLogRegla',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@SysTablesName_ varchar(50) = '',	@SegUsuarioID_ int = 0,	@TablaNombre_ varchar(50) = 0,    
		@C_ tinyint = 0,					@U_ tinyint = 0,		@R_ tinyint = 0,                  
		@D_ tinyint = 0;

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
		SET @IDAConsultar = @SegLogReglaID
		SELECT	@SegUsuarioID_ = SegUsuarioID,	@TablaNombre_ = TablaNombre,	@C_ = C,
				@R_ = R,						@U_ = U,						@D_ = D 
		FROM	SegLogRegla
		WHERE	SegLogReglaID = @IDAConsultar

		-- Si no se encontró registro a Consultar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
		ELSE
			BEGIN
					/* Procesa Bitácora */
				-- Revisa si la consulta debe ser guardado en Bitácora
				EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
						@UsuarioID			=	@UsuarioIDBitacora,
						@TablaNombre		=   @TablaNombreIDBitacora,
						@Operacion			=	@Operacion
				IF @isChangeBeLogged = 1 
				BEGIN
					-- LogMessage = Parámetros de Consulta
					SET @logMessage = Concat('SegCriteriosBitacoraID::', @IDAConsultar, ':', 0, ';')
	
					-- Guarda en Bitácora
					EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
															,@TablaID			= @IDAConsultar
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
			-- Si no hubo errores -> COMMIT
			COMMIT TRANSACTION
END TRY
-- Si hubo error lo procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT	@Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

IF @Errores = 0
	SELECT	@SegUsuarioID_ as SegUsuarioID,	@TablaNombre_ as TablaNombre, @C_ as C,
			@R_ as R, @U_ as U, @D_ as D
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID