CREATE PROCEDURE [dbo].[CoCmpOrdenCompraEncabezado_Guardar]
@CmpOrdenCompraEncabezadoID int,
@CoPartidaID int
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
		@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombreBitacora   nvarchar(100) = 'CoCmpOrdenCompraEncabezado',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE @CoPartidaID_ int = 0,
		@CmpOrdenCompraEncabezadoID_ int = @CmpOrdenCompraEncabezadoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpOrdenCompraEncabezadoID
	-- Si recibe ID del Encabezado, lo procesa y si no -> error
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	 @CoPartidaID_  = IsNull(CoPartidaID,'')
		   FROM	CoCmpOrdenCompraEncabezado WHERE CmpOrdenCompraEncabezadoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> Lo agrega y Si lo encontró, lo actualiza
		IF @@RowCount = 0
			BEGIN
				INSERT  INTO CoCmpOrdenCompraEncabezado(
						CmpOrdenCompraEncabezadoID,
						CoPartidaID)
				VALUES  (
						@CmpOrdenCompraEncabezadoID,
						@CoPartidaID);
				-- PARA QUE DETECTE QUE FUE INSERT
				SET @CmpOrdenCompraEncabezadoID = 0;
			END
		ELSE
			UPDATE	CoCmpOrdenCompraEncabezado
			SET		CoPartidaID =  @CoPartidaID
			WHERE	CmpOrdenCompraEncabezadoID = @CmpOrdenCompraEncabezadoID;
	END
	ELSE
		SELECT @Errores = 999996, @Mensaje = CONCAT('No se recibió CmpOrdenEncabezadoID al agregar CoCmpOrdenCompraEncabezado ', '.'),
				@TituloMensaje = 'Error de Protección de Integridad.';

	IF @Errores = 0
	BEGIN
		/* Procesa Bitácora */
		-- Determina si fue UPDATE o INSERT
		IF @CmpOrdenCompraEncabezadoID > 0  SET @Operacion = 'Update' 	
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
			SET @logMessage = Concat('CmpOrdenCompraEncabezadoID::', @CmpOrdenCompraEncabezadoID, ':', @CmpOrdenCompraEncabezadoID_, ';')
			SET @logMessage = Concat(@logMessage, 'CoPartidaID::', @CoPartidaID_, ':', @CoPartidaID, ';')
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