CREATE PROCEDURE [dbo].[Academico_Institucion_Educativa_Guardar]
@InstitucionEducativaID    INT,
    @InstitucionEducativaClave VARCHAR (6),
    @Nombre           VARCHAR (80),
    @NombreCorto      VARCHAR (15),
    @ExtraTexto1      VARCHAR (500),
    @ExtraTexto2      VARCHAR (500),
    @ExtraTexto3      VARCHAR (500),
    @ExtraFecha1      DATETIME,
    @ExtraFecha2      DATETIME,
    @ExtraDecimal1    DECIMAL (18, 6),
    @ExtraDecimal2    DECIMAL (18, 6),
    @ExtraDecimal3    DECIMAL (18, 6)	
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UserIDBitacora	int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',				@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = ''
-- Variables para Bitácora
DECLARE @TablaNombre   nvarchar(100) = 'AcInstitucionEducativa',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@InstitucionEducativaClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(60) = '',			
		@NombreCorto_ varchar(10) = '',
		@EmpresaID_ int = 0,
		@InstitucionEducativaID_ int = @InstitucionEducativaID,
		@ExtraTexto1_      VARCHAR (500),
		@ExtraTexto2_      VARCHAR (500),
		@ExtraTexto3_      VARCHAR (500),
		@ExtraFecha1_      DATETIME,
		@ExtraFecha2_      DATETIME,
		@ExtraDecimal1_    DECIMAL (18, 6),
		@ExtraDecimal2_    DECIMAL (18, 6),
		@ExtraDecimal3_    DECIMAL (18, 6)	

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @InstitucionEducativaID
	-- Lee ClaveNoAsignado y Títulos de mensajes de Parámetros Cosmos
	SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,''),	@TituloMensaje = IsNull(TituloMensajeRespuesta,'')
		FROM	SistemaParamCosmos;
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@InstitucionEducativaClave_ = IsNull(InstitucionEducativaClave,''),
	 			@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@InstitucionEducativaID_ = IsNull(InstitucionEducativaID,0),
				@ExtraTexto1      = IsNull(ExtraTexto1,''),
				@ExtraTexto2      = IsNull(ExtraTexto2,''),
				@ExtraTexto3      = IsNull(ExtraTexto3,''),
				@ExtraFecha1      = IsNull(ExtraFecha1, GetDate()),
				@ExtraFecha2      = IsNull(ExtraFecha2, GetDate()),
				@ExtraDecimal1    = IsNull(ExtraDecimal1,0),
				@ExtraDecimal2    = IsNull(ExtraDecimal2,0),
				@ExtraDecimal3    = IsNull(ExtraDecimal3,0)	
		   FROM	AcInstitucionEducativa WHERE InstitucionEducativaID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar),
					@TituloMensaje = 'Error de Inconsistencia de Información.';
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @InstitucionEducativaClave_ = @ClaveNoAsignado and @InstitucionEducativaClave <> @ClaveNoAsignado
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
			UPDATE  AcInstitucionEducativa
			SET     InstitucionEducativaClave = @InstitucionEducativaClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					ExtraTexto1 = @ExtraTexto1,
					ExtraTexto2 = @ExtraTexto2,
					ExtraTexto3 = @ExtraTexto3,
					ExtraFecha1 = @ExtraFecha1,
					ExtraFecha2 = @ExtraFecha2,
					ExtraDecimal1 = @ExtraDecimal1,
					ExtraDecimal2 = @ExtraDecimal2,
					ExtraDecimal3 = @ExtraDecimal3
			WHERE   InstitucionEducativaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO AcInstitucionEducativa(
					InstitucionEducativaClave,				Nombre,						NombreCorto,
					ExtraTexto1,							ExtraTexto2,				ExtraTexto3,
					ExtraFecha1,							ExtraFecha2,				ExtraDecimal1,
					ExtraDecimal2,							ExtraDecimal3)
			VALUES  (@InstitucionEducativaClave,			@Nombre,					@NombreCorto,
					@ExtraTexto1,							@ExtraTexto2,				@ExtraTexto3,
					@ExtraFecha1,							@ExtraFecha2,				@ExtraDecimal1,
					@ExtraDecimal2,							@ExtraDecimal3)        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		/****************** COPY 3 ************************************************/
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @InstitucionEducativaID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UserIDBitacora,
					@TablaNombre		=   @TablaNombre,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('InstitucionEducativaClave::', @InstitucionEducativaClave_, ':', @InstitucionEducativaClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraTexto1::', @ExtraTexto1_, ':', @ExtraTexto1, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraTexto2::', @ExtraTexto2_, ':', @ExtraTexto2, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraTexto3::', @ExtraTexto3_, ':', @ExtraTexto3, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraFecha1::', @ExtraFecha1_, ':', @ExtraFecha1, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraFecha2::', @ExtraFecha2_, ':', @ExtraFecha2, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraDecimal1::', @ExtraDecimal1_, ':', @ExtraDecimal1, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraDecimal2::', @ExtraDecimal2_, ':', @ExtraDecimal2, ';')
				SET @logMessage = Concat(@logMessage, 'ExtraDecimal3::', @ExtraDecimal3_, ':', @ExtraDecimal3, ';')

				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombre
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UserIDBitacora
														,@Descripcion		= @Descripcion
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