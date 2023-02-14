
CREATE PROCEDURE [dbo].[PpalSerie_Guardar]
@PpalSerieID int,
@TipoDocumentoID int,
@PpalSerieClave varchar(10),
@FolioInicial int,
@FolioFinal int,
@UltimoFolio int,
@Estatus bit,
@Predeterminado bit,
@PpalSucursalID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'PpalSerie',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalSerieClave_ nvarchar(10) = '',
		@PpalSucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@FolioInicial_ int = 0,
		@FolioFinal_ int = 0,
		@UltimoFolio_ int = 0,
		@Estatus_ bit = 0,
		@Predeterminado_ bit = 0,
		@PpalSerieID_ int = @PpalSerieID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalSerieID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@PpalSerieClave_ = IsNull(PpalSerieClave,''),
				@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@PpalSerieID_ = IsNull(PpalSerieID,0),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@FolioInicial_ = IsNull(FolioInicial,0),
				@FolioFinal_ = IsNull(FolioFinal,0),
				@UltimoFolio_ = IsNull(UltimoFolio,0),
				@Estatus_ = IsNull(Estatus,0),
				@Predeterminado_ = IsNull(Predeterminado,0)
		   FROM	PpalSerie WHERE PpalSerieID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @PpalSerieClave_ = @ClaveNoAsignado and @PpalSerieClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalSerie
			SET     TipoDocumentoID = @TipoDocumentoID,
					PpalSerieClave = @PpalSerieClave,
					FolioInicial = @FolioInicial,
					FolioFinal = @FolioFinal,
					UltimoFolio = @UltimoFolio,
					Estatus = @Estatus,
					Predeterminado = @Predeterminado,
					PpalSucursalID = @PpalSucursalID
			WHERE   PpalSerieID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalSerie(
               
					TipoDocumentoID,
					PpalSerieClave,
					FolioInicial,
					FolioFinal,
					UltimoFolio,
					Estatus,
					Predeterminado,
					PpalSucursalID)
			VALUES  (
                
					@TipoDocumentoID,
					@PpalSerieClave,
					@FolioInicial,
					@FolioFinal,
					@UltimoFolio,
					@Estatus,
					@Predeterminado,
					@PpalSucursalID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalSerieID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('PpalSerieClave::', @PpalSerieClave_, ':', @PpalSerieClave, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSerieID::', @PpalSerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'FolioInicial::', @FolioInicial_, ':', @FolioInicial, ';')
				SET @logMessage = Concat(@logMessage, 'FolioFinal::', @FolioFinal_, ':', @FolioFinal, ';')
				SET @logMessage = Concat(@logMessage, 'UltimoFolio::', @UltimoFolio_, ':', @UltimoFolio, ';')
				SET @logMessage = Concat(@logMessage, 'Estatus::', @Estatus_, ':', @Estatus, ';')
				SET @logMessage = Concat(@logMessage, 'Predeterminado::', @Predeterminado_, ':', @Predeterminado, ';')

				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
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