CREATE PROCEDURE [dbo].[SegUsuarioPerfil_Guardar]
@SegUsuarioPerfilID int,
@SegUsuarioID int,
@SegPerfilID int,
@EmpresaID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora			int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress					varchar(40)		= null
	,@HostName					varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegUsuarioPerfil',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SegUsuarioID_ int = 0,
		@SegPerfilID_ int = 0,
		@EmpresaID_ int = 0,
		@SegUsuarioPerfilID_ int = @SegUsuarioPerfilID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SegUsuarioPerfilID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@SegUsuarioID_ =		IsNull(SegUsuarioID,0),
				@SegPerfilID_ =			IsNull(SegPerfilID,0),
				@EmpresaID_ =			IsNull(EmpresaID,0),
				@SegUsuarioPerfilID_ =	IsNull(SegUsuarioPerfilID,0)
		   FROM	SegUsuarioPerfil WHERE SegUsuarioPerfilID = @IDAActualizar
	-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SegUsuarioPerfil
			SET     SegUsuarioID = @SegUsuarioID,
					SegPerfilID = @SegPerfilID,
					EmpresaID = @EmpresaID
			WHERE   SegUsuarioPerfilID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO SegUsuarioPerfil(
					SegUsuarioID,
					SegPerfilID,
					EmpresaID)
			VALUES  (
					@SegUsuarioID,
					@SegPerfilID,
					@EmpresaID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SegUsuarioPerfilID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('SegUsuarioID::', @SegUsuarioID_, ':', @SegUsuarioID, ';')
				SET @logMessage = Concat(@logMessage, 'SegPerfilID::', @SegPerfilID_, ':', @SegPerfilID, ';')
				SET @logMessage = Concat(@logMessage, 'EmpresaID::', @EmpresaID_, ':', @EmpresaID, ';')
				PRINT @logMessage
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
	END
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