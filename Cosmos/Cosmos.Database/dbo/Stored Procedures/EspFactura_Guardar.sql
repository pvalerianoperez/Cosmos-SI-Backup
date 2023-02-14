CREATE PROCEDURE [dbo].[EspFactura_Guardar]
@EspFacturaID int,
@UUID varchar(50) = null,
@RFC varchar(20) = null,
@Serie varchar(10) = null,
@Folio int,
@Importe decimal(18,2),
@Fecha datetime,
@LinkXML varchar(250),
@LinkPDF varchar(250),
@EstatusFactura char(1),
@MetodoPago varchar(4)
/************   COPY 1  ************************************/
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
DECLARE @TablaNombreBitacora   nvarchar(100) = 'EspFactura',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@UUID_ nvarchar(10) = '',
		@RFC_ nvarchar(60) = '',			
		@Serie_ varchar(10) = '',
		@Folio_ int = 0,
		@Importe_ decimal(18,2) = 0,
		@Fecha_ datetime = GetDate(),
		@LinkXML_ varchar(250) = '',
		@LinkPDF_ varchar(250) = '',
		@EstatusFactura_ char(1) = '',
		@EspFacturaID_ int = @EspFacturaID,
		@MetodoPago_ varchar(4) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @EspFacturaID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
	/*	-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;  */
		-- Lee Valores anteriores para Bitácora
		SELECT	@UUID_ = IsNull(UUID,''),
	 			@RFC_ = IsNull(RFC,''),
				@Serie_ = IsNull(Serie,''),
				@Folio_ = IsNull(Folio,0),
				@Importe_ = IsNull(Importe,0),
				@Fecha_ = IsNull(Fecha,GetDate()),
				@LinkXML_ = IsNull(LinkXML,''),
				@LinkPDF_ = IsNull(LinkPDF,''),
				@EstatusFactura_ = IsNull(EstatusFactura,''),
				@EspFacturaID_ = IsNull(EspFacturaID,0),
				@MetodoPago_ = IsNull(MetodoPago,'')
		   FROM	EspFactura WHERE EspFacturaID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
	/*	-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @UUID_ = @ClaveNoAsignado and @UUID <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.'; */
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE  EspFactura
			SET     UUID = @UUID,
					RFC = @RFC,
					Serie = @Serie,
					Folio = @Folio,
					Importe = @Importe,
					Fecha = @Fecha,
					LinkXML = @LinkXML,
					LinkPDF = @LinkPDF,
					EstatusFactura = @EstatusFactura,
					MetodoPago = @MetodoPago
			WHERE   EspFacturaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO EspFactura(
					UUID,
					RFC,
					Serie,
					Folio,
					Importe,
					Fecha,
					LinkXML,
					LinkPDF,
					EstatusFactura,
					MetodoPago)
			VALUES  (
					@UUID,
					@RFC,
					@Serie,
					@Folio,
					@Importe,
					@Fecha,
					@LinkXML,
					@LinkPDF,
					@EstatusFactura,
					@MetodoPago)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @EspFacturaID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('UUID::', @UUID_, ':', @UUID, ';')
				SET @logMessage = Concat(@logMessage, 'RFC::', @RFC_, ':', @RFC, ';')
				SET @logMessage = Concat(@logMessage, 'Serie::', @Serie_, ':', @Serie, ';')
				SET @logMessage = Concat(@logMessage, 'Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat(@logMessage, 'Importe::', @Importe_, ':', @Importe, ';')
				SET @logMessage = Concat(@logMessage, 'LinkXML::', @LinkXML_, ':', @LinkXML, ';')
				SET @logMessage = Concat(@logMessage, 'LinkPDF::', @LinkPDF_, ':', @LinkPDF, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusFactura::', @EstatusFactura_, ':', @EstatusFactura, ';')
				SET @logMessage = Concat(@logMessage, 'MetodoPago::', @MetodoPago_, ':', @MetodoPago, ';')
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
/**************** FIN COPY 3 *********************************************/