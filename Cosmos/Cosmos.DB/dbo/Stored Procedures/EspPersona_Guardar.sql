CREATE PROCEDURE [dbo].[EspPersona_Guardar]
@EspPersonaID int,
@FisicaMoral char(1),
@NombreComercial nvarchar(120),
@RazonSocial nvarchar(120),
@Nombre nvarchar(35),
@ApellidoPaterno nvarchar(30),
@ApellidoMaterno nvarchar(30),
@RFC nvarchar(13),
@CURP nvarchar(18),
@SexoID int = 0,
@FechaNacimiento date = null,
@CiudadNacimientoID int = 0,
@EstadoCivilID int = 0,
@CasadoCivil bit,
@CasadoIglesia bit,
@Iniciales varchar(6),
@SobreNombre varchar(25),
@NombreCorto varchar(25),
@EspDomicilioIDFacturacion int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora			int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress					varchar(40)		= null
	,@HostName					varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspPersona',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@EspPersonaID_ int = @EspPersonaID,
		@FisicaMoral_ char(1),
		@NombreComercial_ nvarchar(120),
		@RazonSocial_ nvarchar(120),
		@Nombre_ nvarchar(35),
		@ApellidoPaterno_ nvarchar(30),
		@ApellidoMaterno_ nvarchar(30),
		@RFC_ nvarchar(13),
		@CURP_ nvarchar(18),
		@SistemaSexoID_ int = 0,
		@FechaNacimiento_ date = null,
		@CiudadNacimientoID_ int = 0,
		@EstadoCivilID_ int = 0,
		@CasadoCivil_ bit,
		@CasadoIglesia_ bit,
		@Iniciales_ varchar(6),
		@SobreNombre_ varchar(25),
		@NombreCorto_ varchar(25),
		@EspDomicilioIDFacturacion_ int = 0,
-- Variables para validación de duplicados
		@Duplicado varchar(100)
--BEGIN TRY
--	BEGIN TRANSACTION

SET @IDAActualizar = @EspPersonaID
-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
/*IF @IDAActualizar > 0
BEGIN
	-- Lee Valores anteriores para Bitácora
	SELECT	@EspPersonaID_ = EspPersonaID,				@FisicaMoral_ = FisicaMoral,			@NombreComercial_ = NombreComercial,
			@RazonSocial_ = RazonSocial,			@Nombre_ = Nombre,						@ApellidoPaterno_ = ApellidoPaterno,
			@ApellidoMaterno_ = ApellidoMaterno,	@RFC_ = RFC,							@CURP_ = CURP,
			@SistemaSexoID_ = SistemaSexoID,		@FechaNacimiento_ = FechaNacimiento,	@CiudadNacimientoID_ = EspCiudadNacimientoID,
			@EstadoCivilID_ = AuxEstadoCivilID,		@CasadoCivil_ = CasadoCivil,			@CasadoIglesia_ = CasadoIglesia,
			@Iniciales_ = Iniciales,				@SobreNombre_ = SobreNombre,			@NombreCorto_ = NombreCorto,
			@EspDomicilioIDFacturacion_ = EspDomicilioIDFacturacion
		FROM	EspPersona WHERE EspPersonaID = @IDAActualizar
	-- Si no se encontró registro a actualizar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar)
	ELSE
	BEGIN
		-- Si existe ID -> Valida RFC, CURP y Razón Social no duplicados
		IF @RFC > ''
		BEGIN
			SELECT @Duplicado = MAX( CASE WHEN FisicaMoral = 'F' THEN 
					Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno ELSE RazonSocial END )
			  FROM EspPersona
			 WHERE RFC = @RFC AND EspPersonaID <> @EspPersonaID;
			IF @Duplicado > ''
				SELECT @Errores = 999990, @Mensaje = CONCAT('RFC DUPLICADO EN : ', @Duplicado);
		END
		IF @Errores = 0
		BEGIN
			IF @CURP > ''
			BEGIN
				SELECT @Duplicado = MAX( CASE WHEN FisicaMoral = 'F' THEN 
						Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno ELSE RazonSocial END )
					FROM EspPersona
					WHERE CURP = @CURP AND EspPersonaID <> @EspPersonaID;
				IF @Duplicado > ''
					SELECT @Errores = 999990, @Mensaje = CONCAT('CURP DUPLICADO EN : ', @Duplicado);
			END
		END
		IF @Errores = 0
		BEGIN
			IF @RazonSocial > ''
			BEGIN
				SELECT @Duplicado = MAX( RFC )
					FROM EspPersona
					WHERE RazonSocial = @RazonSocial AND EspPersonaID <> @EspPersonaID;
				IF @Duplicado > ''
					SELECT @Errores = 999990, @Mensaje = CONCAT('RAZÓN SOCIAL DUPLICADO EN : ', @Duplicado);
			END
		END
	END
END */
-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
IF @Errores = 0
BEGIN
	-- Si la llave existe hace UPDATE y si no, hace INSERT
	IF @IDAActualizar > 0
	BEGIN
		UPDATE  EspPersona
		SET    
				FisicaMoral = @FisicaMoral,
				NombreComercial = @NombreComercial,
				RazonSocial = @RazonSocial,
				Nombre = @Nombre,
				ApellidoPaterno = @ApellidoPaterno,
				ApellidoMaterno = @ApellidoMaterno,
				RFC = @RFC,
				CURP = @CURP,
				SistemaSexoID = @SexoID,
				FechaNacimiento = @FechaNacimiento,
				EspCiudadNacimientoID = @CiudadNacimientoID,
				AuxEstadoCivilID = @EstadoCivilID,
				CasadoCivil = @CasadoCivil,
				CasadoIglesia = @CasadoIglesia,
				Iniciales = @Iniciales,
				SobreNombre = @SobreNombre,
				NombreCorto = @NombreCorto,
				EspDomicilioIDFacturacion = @EspDomicilioIDFacturacion
		WHERE   EspPersonaID = @EspPersonaID
	END
	ELSE
	BEGIN        
		INSERT  INTO EspPersona(          
				FisicaMoral,
				NombreComercial,
				RazonSocial,
				Nombre,
				ApellidoPaterno,
				ApellidoMaterno,
				RFC,
				CURP,
				SistemaSexoID,
				FechaNacimiento,
				EspCiudadNacimientoID,
				AuxEstadoCivilID,
				CasadoCivil,
				CasadoIglesia,
				Iniciales,
				SobreNombre,
				NombreCorto,
				EspDomicilioIDFacturacion)
		VALUES  (        
				@FisicaMoral,
				@NombreComercial,
				@RazonSocial,
				@Nombre,
				@ApellidoPaterno,
				@ApellidoMaterno,
				@RFC,
				@CURP,
				@SexoID,
				@FechaNacimiento,
				@CiudadNacimientoID,
				@EstadoCivilID,
				@CasadoCivil,
				@CasadoIglesia,
				@Iniciales,
				@SobreNombre,
				@NombreCorto,
				@EspDomicilioIDFacturacion)
        
		SET     @EspPersonaID = SCOPE_IDENTITY()
	END
/*	IF @@RowCount > 0
	BEGIN
		/* Procesa Bitácora */
		-- Determina si fue UPDATE o INSERT
		IF @EspPersonaID_ > 0  SET @Operacion = 'Update' 	
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
			SET @logMessage = Concat('FisicaMoral::', @FisicaMoral_, ':', @FisicaMoral, ';')
			SET @logMessage = Concat(@logMessage, 'NombreComercial::', @NombreComercial_, ':', @NombreComercial, ';')
			SET @logMessage = Concat(@logMessage, 'RazonSocial::', @RazonSocial_, ':', @RazonSocial, ';')
			SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
			SET @logMessage = Concat(@logMessage, 'ApellidoPaterno::', @ApellidoPaterno_, ':', @ApellidoPaterno, ';')
			SET @logMessage = Concat(@logMessage, 'ApellidoMaterno::', @ApellidoMaterno_, ':', @ApellidoMaterno, ';')
			SET @logMessage = Concat(@logMessage, 'RFC::', @RFC_, ':', @RFC, ';')
			SET @logMessage = Concat(@logMessage, 'CURP::', @CURP_, ':', @CURP, ';')
			SET @logMessage = Concat(@logMessage, 'SexoID::', @SistemaSexoID_, ':', @SexoID, ';')
			SET @logMessage = Concat(@logMessage, 'FechaNacimiento::', @FechaNacimiento_, ':', @FechaNacimiento, ';')
			SET @logMessage = Concat(@logMessage, 'CiudadNacimientoID::', @CiudadNacimientoID_, ':', @CiudadNacimientoID, ';')
			SET @logMessage = Concat(@logMessage, 'EstadoCivilID::', @EstadoCivilID_, ':', @EstadoCivilID, ';')
			SET @logMessage = Concat(@logMessage, 'CasadoCivil::', @CasadoCivil_, ':', @CasadoCivil, ';')
			SET @logMessage = Concat(@logMessage, 'CasadoIglesia::', @CasadoIglesia_, ':', @CasadoIglesia, ';')
			SET @logMessage = Concat(@logMessage, 'Iniciales::', @Iniciales_, ':', @Iniciales, ';')
			SET @logMessage = Concat(@logMessage, 'SobreNombre::', @SobreNombre_, ':', @SobreNombre, ';')
			SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
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
	END */
END
--END TRY
-- Si hubo error los procesa y lo regresa
--BEGIN CATCH
--    SELECT @Errores = ERROR_NUMBER(), 
--			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
--END CATCH 
--IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
--IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

/*SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID */

RETURN  @EspPersonaID