CREATE PROCEDURE [dbo].[PpalContactoPersonalFecha_Guardar]
@PpalContactoPersonalFechaID int,
@PpalContactoPersonalID int,
@Fecha date,
@TipoFechaID int,
@Comentarios varchar(100) = null,
@Predeterminado bit
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalContactoPersonalFecha',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@Predeterminado_ bit = 0,
		@PpalContactoPersonalID_ int = 0,			
		@Fecha_ date,
		@TipoFechaID_ int = 0,
		@Comentarios_ varchar(100) = '',
		@PpalContactoPersonalFechaID_ int = @PpalContactoPersonalFechaID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalContactoPersonalFechaID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@Predeterminado_ = IsNull(Predeterminado,0),
	 			@PpalContactoPersonalID_ = IsNull(PpalContactoPersonalID,''),
				--@Fecha_ = IsNull(Fecha,2007-05-08),
				@TipoFechaID_ = IsNull(CfgTipoFechaID,0),
				@Comentarios_ = IsNull(Comentarios,0),
				@PpalContactoPersonalFechaID_ = IsNull(PpalContactoPersonalFechaID,0)
		   FROM	PpalContactoPersonalFecha WHERE PpalContactoPersonalFechaID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @AreaClave_ = @ClaveNoAsignado and @AreaClave <> @ClaveNoAsignado
			--SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalContactoPersonalFecha
			SET     Predeterminado = @Predeterminado,
					PpalContactoPersonalID = @PpalContactoPersonalID,
					Fecha = @Fecha,
					CfgTipoFechaID = @TipoFechaID,
					Comentarios = @Comentarios
			WHERE   PpalContactoPersonalFechaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalContactoPersonalFecha(
					Predeterminado,
					PpalContactoPersonalID,
					Fecha,
					CfgTipoFechaID,
					Comentarios)
			VALUES  (
					@Predeterminado,
					@PpalContactoPersonalID,
					@Fecha,
					@TipoFechaID,
					@Comentarios)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalContactoPersonalFechaID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('Predeterminado::', @Predeterminado_, ':', @Predeterminado, ';')
				SET @logMessage = Concat(@logMessage, 'PpalContactoPersonalID::', @PpalContactoPersonalID_, ':', @PpalContactoPersonalID, ';')
				--SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat(@logMessage, 'TipoFechaID::', @TipoFechaID_, ':', @TipoFechaID, ';')
				SET @logMessage = Concat(@logMessage, 'Comentarios::', @Comentarios_, ':', @Comentarios, ';')
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