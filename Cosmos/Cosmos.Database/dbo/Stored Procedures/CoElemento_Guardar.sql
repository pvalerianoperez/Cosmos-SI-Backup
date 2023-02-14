CREATE PROCEDURE [dbo].[CoElemento_Guardar]
@CoElementoID int,
@CoElementoClave varchar(10) = null,
@Nombre varchar(80) = null,
@NombreCorto varchar(12) = null,
@CoLoteID int,
@CoTipoPresupuestoID int,
@CoModeloID int,
@CoFachadaID int,
@CoContratoIDActual int
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
DECLARE @TablaNombreIDBItacora   nvarchar(100) = 'CoElemento',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	
		@CoElementoID_ int = @CoElementoID,
		@CoElementoClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(60) = '',			
		@NombreCorto_ varchar(10) = '',
		@CoLoteID_ int = 0,
		@CoTipoPresupuestoID_ int = 0,
		@CoModeloID_ int = 0,
		@CoFachadaID_ int = 0,
		@CoContratoIDActual_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CoElementoID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@CoElementoClave_ = IsNull(CoElementoClave,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@CoLoteID_ = IsNull(CoLoteID,0),
				@CoTipoPresupuestoID_ = IsNull(CoTipoPresupuestoID,0),
				@CoModeloID_ = IsNull(CoModeloID,0),
				@CoFachadaID_ = IsNull(CoFachadaID,0),
				@CoContratoIDActual_ = IsNull(CoContratoIDActual,0)

		   FROM	CoElemento WHERE CoElementoID = @IDAActualizar

		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @CoElementoClave_ = @ClaveNoAsignado and @CoElementoClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado),
					@TituloMensaje = 'Error de Protección de Integridad.';
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE  CoElemento
			SET     CoElementoClave = @CoElementoClave,		Nombre = @Nombre,		NombreCorto = @NombreCorto,
					CoLoteID = @CoLoteID,		CoTipoPresupuestoID = @CoTipoPresupuestoID,		CoModeloID = @CoModeloID,
					CoFachadaID = @CoFachadaID,		CoContratoIDActual = @CoContratoIDActual

			WHERE   CoElementoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CoElemento(
					CoElementoClave,			
					Nombre,					
					NombreCorto,
					CoLoteID,
					CoTipoPresupuestoID,
					CoModeloID,
					CoFachadaID,
					CoContratoIDActual)
			VALUES  (
					@CoElementoClave,
					@Nombre,
					@NombreCorto,
					@CoLoteID,
					@CoTipoPresupuestoID,
					@CoModeloID,
					@CoFachadaID,
					@CoContratoIDActual)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CoElementoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBItacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CoElementoClave::', @CoElementoClave_, ':', @CoElementoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'CoLoteID::', @CoLoteID_, ':', @CoLoteID, ';')
				SET @logMessage = Concat(@logMessage, 'CoTipoPresupuestoID::', @CoTipoPresupuestoID_, ':', @CoTipoPresupuestoID, ';')
				SET @logMessage = Concat(@logMessage, 'CoModeloID::', @CoModeloID_, ':', @CoModeloID, ';')
				SET @logMessage = Concat(@logMessage, 'CoFachadaID::', @CoFachadaID_, ':', @CoFachadaID, ';')
				SET @logMessage = Concat(@logMessage, 'CoContratoIDActual::', @CoContratoIDActual_, ':', @CoContratoIDActual, ';')


				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBItacora
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