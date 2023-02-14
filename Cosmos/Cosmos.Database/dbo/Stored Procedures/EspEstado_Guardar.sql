

CREATE PROCEDURE [dbo].[EspEstado_Guardar]
@EspEstadoID int,
@EspEstadoClave varchar(6),
@ClaveCURP varchar(3),
@Clave2 varchar(2),
@Clave3 varchar(3),
@Nombre varchar(50),
@NombreCorto varchar(15),
@NombreCompleto varchar(50),
@EspPaisID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspEstado',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@EspEstadoID_ int = @EspEstadoID,
		@EspEstadoClave_ varchar(6) = '',
		@ClaveCURP_ varchar(3) = '',
		@Clave2_ varchar(2) = '',
		@Clave3_ varchar(3) = '',
		@Nombre_ varchar(50) = '',
		@NombreCorto_ varchar(15) = '',
		@NombreCompleto_ varchar(50) = '',
		@EspPaisID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @EspEstadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@EspEstadoID_  =		IsNull(EspEstadoID,''),
				@EspEstadoClave_ =		IsNull(EspEstadoClave,''),
				@ClaveCURP_ =		IsNull(ClaveCURP,''),
				@Clave2_ =			IsNull(Clave2,''),
				@Clave3_ =			IsNull(Clave3,''),
				@Nombre_ =			IsNull(Nombre,''),
				@NombreCorto_ =		IsNull(NombreCorto,''),
				@NombreCompleto_ =	IsNull(NombreCompleto,''),
				@EspPaisID_ = IsNull(EspPaisID,0)
		   FROM	EspEstado WHERE EspEstadoID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0

		BEGIN
			UPDATE  EspEstado
			SET     EspEstadoClave = @EspEstadoClave,
					ClaveCURP = @ClaveCURP,
					Clave2 = @Clave2,
					Clave3 = @Clave3,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					NombreCompleto = @NombreCompleto,
					EspPaisID = @EspPaisID
			WHERE   EspEstadoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO EspEstado(
					EspEstadoID,
					EspEstadoClave,
					ClaveCURP,
					Clave2,
					Clave3,
					Nombre,
					NombreCorto,
					NombreCompleto,
					EspPaisID
					)
			VALUES  (
					@EspEstadoID,
					@EspEstadoClave,
					@ClaveCURP,
					@Clave2,
					@Clave3,
					@Nombre,
					@NombreCorto,
					@NombreCompleto,
					@EspPaisID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @EspEstadoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('EstadoClave::', @EspEstadoClave_, ':', @EspEstadoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				PRINT @logMessage
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