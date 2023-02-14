

CREATE PROCEDURE [dbo].[EspPersona_Consultar]
@EspPersonaID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspPersona',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

-- Variables para valores de columnas
DECLARE	@EspPersonaID_ int = @EspPersonaID,
		@FisicaMoral_ char(1) = '',
		@NombreComercial_ nvarchar(120) = '',
		@RazonSocial_ nvarchar(120) = '',
		@Nombre_ nvarchar(35) = '',
		@ApellidoPaterno_ nvarchar(30) = '',
		@ApellidoMaterno_ nvarchar(30) = '',
		@RFC_ nvarchar(13) = '',
		@CURP_ nvarchar(18) = '',
		@SistemaSexoID_ int = 0,
		@FechaNacimiento_ date = null,
		@EspCiudadNacimientoID_ int = 0,
		@AuxEstadoCivilID_ int = 0,
		@CasadoCivil_ bit,
		@CasadoIglesia_ bit,
		@Iniciales_ varchar(6) = '',
		@SobreNombre_ varchar(25) = '',
		@NombreCorto_ varchar(25) ='',
		@EspDomicilioIDFacturacion_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAConsultar = @EspPersonaID
	
	SELECT  @EspPersonaID_ = EspPersonaID,			@FisicaMoral_ = FisicaMoral,			@NombreComercial_ = NombreComercial,	@RazonSocial_ = RazonSocial,
			@Nombre_ = Nombre,						@ApellidoPaterno_ = ApellidoPaterno,	@ApellidoMaterno_ = ApellidoMaterno,	@RFC_ = RFC,
			@CURP_ = CURP,							@SistemaSexoID_ = SistemaSexoID,		@FechaNacimiento_ = FechaNacimiento,	@EspCiudadNacimientoID_ = EspCiudadNacimientoID,
			@AuxEstadoCivilID_ = AuxEstadoCivilID,	@CasadoCivil_ = CasadoCivil,			@CasadoIglesia_ = CasadoIglesia,		@Iniciales_ = Iniciales,
			@SobreNombre_ = SobreNombre,			@NombreCorto_ = NombreCorto,            @EspDomicilioIDFacturacion_ = EspDomicilioIDFacturacion
	FROM    EspPersona
	WHERE   EspPersonaID = @EspPersonaID

	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('EspPersonaID::', @EspPersonaID, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDAConsultar
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
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
END TRY
-- Si hubo error lo procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

IF @Errores = 0
	SELECT  @IDAConsultar		as PaisID,				@FisicaMoral_	  as FisicaMoral,			@NombreComercial_		as NombreComercial,
			@RazonSocial_		as RazonSocial,			@Nombre_		  as nombre,				@ApellidoPaterno_		as ApellidoPaterno,
			@ApellidoMaterno_	as ApellidoMaterno,		@RFC_			  as RFC,					@CURP_				    as CURP,
			@SistemaSexoID_		as SexoID,				@FechaNacimiento_ as FechaNacimiento,		@EspCiudadNacimientoID_ as CiudadNacimientoID,
			@AuxEstadoCivilID_	as EstadoCivilID,		@CasadoCivil_     as CasaCivil,				@CasadoIglesia_			as CasadoIglesia,
			@Iniciales_			as Iniciales,			@SobreNombre_     as SobreNombre,			@NombreCorto_			as NombreCorto,
			@EspDomicilioIDFacturacion_ as EspDomicilioIDFacturacion
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID