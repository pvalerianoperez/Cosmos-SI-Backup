

CREATE PROCEDURE [dbo].[PpalPersonalTelefono_Guardar]
@ModificacionUsuarioID int = null,
@PpalPersonalTelefonoID int,
@PpalPersonalID int,
@TelefonoID int,
@Extension varchar(10),
@Predeterminado bit,
@Comentarios varchar(100),
@CfgUsoTelefonoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null


AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalPersonalTelefono',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalPersonalID_ int = 0,
		@TelefonoID_ int = 0,			
		@TipoTelefonoID_ int = 0,
		@Comentarios_ varchar(100) = '',
		@Predeterminado_ bit = 0,
		@PpalPersonalTelefonoID_ int = @PpalPersonalTelefonoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION


	SET @IDAActualizar = @PpalPersonalTelefonoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@PpalPersonalID_ = IsNull(PpalPersonalID,0),
	 			@TelefonoID_ = IsNull(EspTelefonoID,0),
				@Comentarios_ = IsNull(Comentarios,0),
				@Predeterminado_ = IsNull(@Predeterminado_,0)
		   FROM	PpalPersonalTelefono WHERE PpalPersonalTelefonoID = @IDAActualizar
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
			UPDATE  PpalPersonalTelefono
			SET     PpalPersonalID = @PpalPersonalID,
					EspTelefonoID = @TelefonoID,
					Extension = @Extension,
					Predeterminado = @Predeterminado,
					Comentarios = @Comentarios,
					CfgUsoTelefonoID = @CfgUsoTelefonoID
			WHERE   PpalPersonalTelefonoID = @PpalPersonalTelefonoID
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalPersonalTelefono(
					PpalPersonalID,
					EspTelefonoID,
					Extension,
					Predeterminado,
					Comentarios,
					CfgUsoTelefonoID)
			VALUES  (
					@PpalPersonalID,
					@TelefonoID,
					@Extension,
					@Predeterminado,
					@Comentarios,
					@CfgUsoTelefonoID)
        
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalPersonalTelefonoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('PpalPersonalID::', @PpalPersonalID_, ':', @PpalPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'TelefonoID::', @TelefonoID_, ':', @TelefonoID, ';')
				SET @logMessage = Concat(@logMessage, 'Comentarios::', @Comentarios_, ':', @Comentarios, ';')
				SET @logMessage = Concat(@logMessage, 'Predeterminado::', @Predeterminado_, ':', @Predeterminado, ';')

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