
CREATE PROCEDURE [dbo].[SistemaGrupoEstatus_Guardar]
@SistemaGrupoEstatusID int,
@SistemaGrupoID int,
@Nombre varchar(50),
@TipoDocumentoID int,
@Color varchar(30),
@Activo bit
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SistemaGrupoEstatus',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SistemaGrupoID_ int = 0,
		@Nombre_ nvarchar(60) = '',			
		@TipoDocumentoID_ int = 0,
		@Color_ varchar(50) = '',
		@Activo_ bit = 0,
		@SistemaGrupoEstatusID_ int = @SistemaGrupoEstatusID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SistemaGrupoEstatusID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@SistemaGrupoID_ = IsNull(SistemaGrupoID,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@Color_ = IsNull(Color,''),
				@Activo_ = IsNull(Activo,0),
				@SistemaGrupoEstatusID_ = IsNull(SistemaGrupoEstatusID,0)
		   FROM	SistemaGrupoEstatus WHERE SistemaGrupoEstatusID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SistemaGrupoEstatus
			SET                     SistemaGrupoID = @SistemaGrupoID,
					Nombre = @Nombre,
					TipoDocumentoID = @TipoDocumentoID,
					Color = @Color,
					Activo = @Activo
			WHERE   SistemaGrupoEstatusID = @SistemaGrupoEstatusID
		END
		ELSE
		BEGIN        
			INSERT  INTO SistemaGrupoEstatus(
					SistemaGrupoID,
					Nombre,
					TipoDocumentoID,
					Color,
					Activo)
			VALUES  (
					@SistemaGrupoID,
					@Nombre,
					@TipoDocumentoID,
					@Color,
					@Activo)
        
        SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SistemaGrupoEstatusID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('SistemaGrupoID::', @SistemaGrupoID_, ':', @SistemaGrupoID, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'Color::', @Color_, ':', @Color, ';')
				SET @logMessage = Concat(@logMessage, 'Activo::', @Activo_, ':', @Activo, ';')
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