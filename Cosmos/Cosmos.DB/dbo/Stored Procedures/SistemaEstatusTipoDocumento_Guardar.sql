

CREATE PROCEDURE [dbo].[SistemaEstatusTipoDocumento_Guardar]
@SistemaEstatusTipoDocumentoID int,
@SistemaEstatusDocumentoID int,
@TipoDocumentoID int,
@EmpresaID int,
@Predeterminado bit,
@Restringido bit,
@Monto bit,
@Propietario bit,
@Sistema bit

-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SistemaEstatusTipoDocumento',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@TipoDocumentoID_ int = 0,
		@SistemaEstatusDocumentoID_ int = 0,
		@SistemaEstatusTipoDocumentoID_ int = @SistemaEstatusTipoDocumentoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SistemaEstatusTipoDocumentoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@SistemaEstatusDocumentoID_ = IsNull(SistemaEstatusDocumentoID,0),
				@SistemaEstatusTipoDocumentoID_ = IsNull(SistemaEstatusTipoDocumentoID,0)
		   FROM	SistemaEstatusTipoDocumento WHERE SistemaEstatusTipoDocumentoID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SistemaEstatusTipoDocumento
			SET     SistemaEstatusDocumentoID = @SistemaEstatusDocumentoID,
					TipoDocumentoID = @TipoDocumentoID
			WHERE   SistemaEstatusTipoDocumentoID = @SistemaEstatusTipoDocumentoID
		END
		ELSE
		BEGIN        
			INSERT  INTO SistemaEstatusTipoDocumento(
					SistemaEstatusDocumentoID,
					TipoDocumentoID,
					EmpresaID,
					Predeterminado,
					Restringido,
					Monto,
					Sistema)
			VALUES  (
					@SistemaEstatusDocumentoID,
					@TipoDocumentoID,
					@EmpresaID,
					@Predeterminado,
					@Restringido,
					@Monto,
					@Sistema)
        
        SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SistemaEstatusTipoDocumentoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'SistemaEstatusDocumentoID::', @SistemaEstatusDocumentoID_, ':', @SistemaEstatusDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
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