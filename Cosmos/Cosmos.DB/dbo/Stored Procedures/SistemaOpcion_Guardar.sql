
CREATE PROCEDURE [dbo].[SistemaOpcion_Guardar]
@OpcionID int,
@ModuloID int,
@PadreID int = null,
@Nombre nvarchar(50),
@NombreCorto nvarchar(20),
@RecursoWebsite nvarchar(150),
@Activo bit,
@Protegido bit,
@Popup bit,
@VisibleMenu bit,
@Icono nvarchar(50),
@Orden smallint
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
SET @PadreID = NULLIF(@PadreID, 0)
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SistemaOpcion',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@ModuloID_ int = 0,
		@PadreID_ int = 0,
		@Nombre_ nvarchar(50) = '',
		@NombreCorto_ nvarchar(20) = '',			
		@RecursoWebsite_ varchar(150) = '',
		@Activo_ bit = 0,
		@Protegido_ bit = 0,
		@Popup_ bit = 0,
		@VisibleMenu_ bit = 0,
		@Icono_ nvarchar(50) = '',
		@Orden_ smallint = 0,
		@OpcionID_ int = @OpcionID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @OpcionID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT
	 			@ModuloID_ = IsNull(ModuloID,0),
				@PadreID_ = IsNull(PadreID,0),
				@Nombre_= IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),			
				@RecursoWebsite_ = IsNull(RecursoWebsite,''),
				@Activo_ = IsNull(Activo,0),
				@Protegido_ = IsNull(Protegido,0),
				@Popup_ = IsNull(Popup,0),
				@VisibleMenu_ = IsNull(VisibleMenu,0),
				@Icono_ = IsNull(Icono,''),
				@Orden_ = IsNull(Orden,0),
				@OpcionID_=IsNull(OpcionID,0)
		   FROM SistemaOpcion WHERE OpcionID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0

		BEGIN
			UPDATE  SistemaOpcion
			SET                     ModuloID = @ModuloID,
					PadreID = @PadreID,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					RecursoWebsite = @RecursoWebsite,
					Activo = @Activo,
					Protegido = @Protegido,
					Popup = @Popup,
					VisibleMenu = @VisibleMenu,
					Icono = @Icono,
					Orden = @Orden
			WHERE   OpcionID = @OpcionID
		END
		ELSE
		BEGIN        
			INSERT  INTO SistemaOpcion(
					ModuloID,
					PadreID,
					Nombre,
					NombreCorto,
					RecursoWebsite,
					Activo,
					Protegido,
					Popup,
					VisibleMenu,
					Icono,
					Orden)
			VALUES  (
					@ModuloID,
					@PadreID,
					@Nombre,
					@NombreCorto,
					@RecursoWebsite,
					@Activo,
					@Protegido,
					@Popup,
					@VisibleMenu,
					@Icono,
					@Orden)
        
        SET     @IDAActualizar = SCOPE_IDENTITY()
		END
		
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @OpcionID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('ModuloID::', @ModuloID_, ':', @ModuloID, ';')
				SET @logMessage = Concat(@logMessage,'PadreID::', @PadreID_, ':', @PadreID, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'RecursoWebSite::', @RecursoWebSite_, ':', @RecursoWebSite, ';')
				SET @logMessage = Concat(@logMessage, 'Activo::', @Activo_, ':', @Activo, ';')
				SET @logMessage = Concat(@logMessage, 'Protegido::', @Protegido_, ':', @Protegido, ';')
				SET @logMessage = Concat(@logMessage, 'Popup::', @Popup_, ':', @Popup, ';')
				SET @logMessage = Concat(@logMessage, 'VisibleMenu::', @VisibleMenu_, ':', @VisibleMenu, ';')
				SET @logMessage = Concat(@logMessage, 'Icono::', @Icono_, ':', @Icono, ';')
				SET @logMessage = Concat(@logMessage, 'Orden::', @Orden_, ':', @Orden, ';')
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