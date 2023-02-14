

CREATE PROCEDURE [dbo].[EspEstado_Eliminar]
@EstadoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDABorrar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspEstado',	
		@Operacion	nvarchar(20) = 'Delete', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variable para validar no Eliminar ClaveNoAsignado
DECLARE @TablaClave nvarchar(100) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDABorrar = @EstadoID
	-- Lee ClaveNoAsignado de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
	  FROM	SistemaParamCosmos;
	-- Lee TablaClave para validar que no sea ClaveNoAsignado
	SELECT	@TablaClave = IsNull(EspEstadoClave,'')
	  FROM	EspEstado WHERE EspEstadoID = @IDABorrar
	-- Si es ClaveNoAsignado -> No se permite borrar
	-- Si es ClaveNoAsignado -> No se permite borrar
	IF @TablaClave = @ClaveNoAsignado
	BEGIN
		SELECT @Errores = 999995, @Mensaje = CONCAT('No se permite eliminar Clave ', @ClaveNoAsignado)
		ROLLBACK TRANSACTION
	END
	ELSE
		DELETE
		FROM    EspEstado
		WHERE   EspEstadoID = @IDABorrar

		-- Si no se encontró registro a eliminar -> error
		IF @@RowCount = 0
		BEGIN
		SELECT @Errores = 999998, @Mensaje = CONCAT('No se encontró el ID a Eliminar:', ' ', @IDABorrar)
		ROLLBACK TRANSACTION
		END
		ELSE
		BEGIN
    		/* Procesa Bitácora */
			-- Revisa si el borrado debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el borrado debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1
			BEGIN
				-- LogMessage = Parámetro para borrado
				SET @logMessage = Concat('EspEstadoID::', @EstadoID, ':', 0, ';')

				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDABorrar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitacora
														,@Descripcion		= @DescripcionBitacora
														,@Cambios			= @logMessage
														,@IpAddress			= @IpAddress
														,@HostName			= @HostName
			END
			COMMIT TRANSACTION
	END
	-- Fin de proceso sin errores -> COMMIT

END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDABorrar as EliminarID
SET NOCOUNT OFF