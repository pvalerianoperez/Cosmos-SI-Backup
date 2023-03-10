
CREATE PROCEDURE [dbo].[CoPartidaGeneral_Guardar]
@CoPartidaGeneralID int,
@PadreID int,
@CoPartidaGeneralClave varchar(5) = null,
@Nombre varchar(40) = null,
@NombreCorto varchar(10) = null,
@PpalAreaIDInicio int,
@PpalConceptoEgresoIDInicio int,
@AplicaIVA char(1),
@CoTipoConstruccionID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CoPartidaGeneral',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CoPartidaGeneralID_ int = @CoPartidaGeneralID,
		@PadreID_ int  = 0,
		@CoPartidaGeneralClave_ varchar(5) = '',
		@Nombre_ varchar(40) = '',
		@NombreCorto_ varchar(10) = '',
		@PpalAreaIDInicio_ int  =0,
		@PpalConceptoEgresoIDInicio_ int = 0,
		@AplicaIVA_ char(1) = '',
		@CoTipoConstruccionID_ int = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoPartidaGeneralID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoPartidaGeneralID_ = IsNULL(CoPartidaGeneralID,0),
				@PadreID_ = IsNULL(PadreID,0),
				@CoPartidaGeneralClave_ = IsNULL(CoPartidaGeneralClave,''),
				@Nombre_ = IsNULL(Nombre,''),
				@NombreCorto_ = IsNULL(NombreCorto,''),
				@PpalAreaIDInicio_ = IsNULL(PpalAreaIDInicio,0),
				@PpalConceptoEgresoIDInicio_ = IsNULL(PpalConceptoEgresoIDInicio,0),
				@AplicaIVA_ = ISNULL(AplicaIVA,''),
				@CoTipoConstruccionID_ = ISNULL(CoTipoConstruccionID,0)
		   FROM	CoPartidaGeneral WHERE CoPartidaGeneralID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoPartidaGeneralClave_ = @ClaveNoAsignado and @CoPartidaGeneralClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CoPartidaGeneral
			SET    	PadreID  = CASE WHEN @PadreID = 0 THEN NULL ELSE @PadreID END,
					CoPartidaGeneralClave = @CoPartidaGeneralClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					PpalAreaIDInicio =  @PpalAreaIDInicio,
					PpalConceptoEgresoIDInicio = @PpalConceptoEgresoIDInicio,
					AplicaIVA = @AplicaIVA,
					CoTipoConstruccionID = @CoTipoConstruccionID
			WHERE   CoPartidaGeneralID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoPartidaGeneral(
					PadreID,
					CoPartidaGeneralClave,
					Nombre,
					NombreCorto,
					PpalAreaIDInicio,
					PpalConceptoEgresoIDInicio,
					AplicaIVA,
					CoTipoConstruccionID)
			VALUES  (
					CASE WHEN @PadreID = 0 THEN NULL ELSE @PadreID END,
					@CoPartidaGeneralClave,
					@Nombre,
					@NombreCorto,
					@PpalAreaIDInicio,
					@PpalConceptoEgresoIDInicio,
					@AplicaIVA,
					@CoTipoConstruccionID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoPartidaGeneralID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('PadreID::', @PadreID_, ':', @PadreID, ';')
				SET @logMessage = Concat(@logMessage, 'CoPartidaGeneralClave::', @CoPartidaGeneralClave_, ':', @CoPartidaGeneralClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaIDInicio::', @PpalAreaIDInicio_, ':', @PpalAreaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'PPalConceptoEgresoIDinicio::', @PPalConceptoEgresoIDinicio_, ':', @PPalConceptoEgresoIDinicio, ';')
				SET @logMessage = Concat(@logMessage, 'AplicaIVA::', @AplicaIVA_, ':', @AplicaIVA, ';')
				SET @logMessage = Concat(@logMessage, 'CoTipoConstruccionID::', @CoTipoConstruccionID_, ':', @CoTipoConstruccionID, ';')

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