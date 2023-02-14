

CREATE PROCEDURE [dbo].[PpalPersonal_Consultar]
@PpalPersonalID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalPersonal',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@PpalPersonalClave_ nvarchar(10) = '',
		@EmpresaID_ int = 0	,		
		@PuestoID_ int = 0,
		@ReportaAPpalPersonalID_ int = 0,
		@PpalAreaID_ int = 0,
		@PpalPersonalID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@AuxHorarioPersonalID_ int = 0,
		@CfgEstatusPersonalID_ int = 0,
		@EspPersonalID_ int = 0,
		--Variebles Persona
		@FisicaMoral_ char = '',
		@NombreComercial_ varchar(120) = '',
		@RazonSocial_ varchar(120) = '',
		@Nombre_ varchar(35) = '',
		@ApellidoPaterno_ varchar(30) = '',
		@ApellidoMaterno_ varchar(30) = '',
		@RFC_ varchar(13) = '',
		@CURP_ varchar(18) = '',
		@SexoID_ int = 0,
		@FechaNacimiento_ DateTime = GetDate(),
		@EspCiudadNacimientoID_ int = 0,
		@AuxEstadoCivilID_ int = 0,
		@CasadoCivil_ bit = 0,
		@CasadoIglesia_ bit = 0,
		@Iniciales_ varchar(6) = '',
		@SobreNombre_ varchar(25) = '',
		@NombreCorto_ varchar(25) = '',
		@PpalProveedorClave_ varchar(10) = '',
		@NombreCompleto_ varchar(97) = ''


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SET @IDAConsultar = @PpalPersonalID
	SELECT  @PpalPersonalID_ = PP.PpalPersonalID,
			@PpalPersonalClave_ = PP.PpalPersonalClave,
			@EmpresaID_ = PP.EmpresaID,
			@PuestoID_ = PP.AuxPuestoID,
			@ReportaAPpalPersonalID_ = PP.ReportaAPpalPersonalID,
			@PpalAreaID_ = PP.PpalAreaID,
			@PpalCentroCostoID_ = PP.PpalCentroCostoID,
			@AuxHorarioPersonalID_ = PP.AuxHorarioPersonalID,
			@CfgEstatusPersonalID_ = PP.CfgEstatusPersonalID,
			@EspPersonalID_ = EP.EspPersonaID,
			@FisicaMoral_ = EP.FisicaMoral,
			@NombreComercial_ = EP.NombreComercial,
			@RazonSocial_ = EP.RazonSocial,
			@Nombre_ = EP.Nombre,
			@ApellidoPaterno_ = EP.ApellidoPaterno,
			@ApellidoMaterno_ = EP.ApellidoMaterno,
			@RFC_ = EP.RFC,
			@CURP_ = EP.CURP,
			@SexoID_ = EP.SistemaSexoID,
			@FechaNacimiento_ = EP.FechaNacimiento,
			@EspCiudadNacimientoID_ = EP.EspCiudadNacimientoID,
			@AuxEstadoCivilID_ = EP.AuxEstadoCivilID,
			@CasadoCivil_ = EP.CasadoCivil,
			@CasadoIglesia_ = EP.CasadoIglesia,
			@Iniciales_ = EP.Iniciales,
			@SobreNombre_ = EP.SobreNombre,
			@NombreCorto_ = EP.NombreCorto,
			@NombreCompleto_ = EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
	FROM    PpalPersonal PP
	inner join EspPersona EP on  PP.EspPersonaID = EP.EspPersonaID
	WHERE   PpalPersonalID = @PpalPersonalID

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
			SET @logMessage = Concat('PpalPersonalID::', @IDAConsultar, ':', 0, ';')
	
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
	SELECT  @IDAConsultar as PpalPersonalID,					@PpalPersonalClave_ as PpalPersonalClave,	
			@EmpresaID_ as EmpresaID,							@PuestoID_ as PuestoID,			
			@ReportaAPpalPersonalID_ as ReportaAPpalPersonalID,			@PpalAreaID_ as PpalAreaID,
			@PpalCentroCostoID_ as PpalCentroCostoID,			@AuxHorarioPersonalID_ as AuxHorarioPersonalID,
			@CfgEstatusPersonalID_ as CfgEstatusPersonalID,		@EspPersonalID_ as EspPersonalID,
			@IDAConsultar as PpalProveedorID,					@UsuarioIDBitacora as SegUsuarioID,
			@FisicaMoral_ as FisicaMoral,					@NombreComercial_ as NombreComercial,
			@RazonSocial_ as RazonSocial,					@Nombre_ as Nombre,
			@ApellidoPaterno_ as ApellidoPaterno,			@ApellidoMaterno_ as ApellidoMaterno,
			@RFC_ as RFC,									@CURP_ as CURP,
			@SexoID_ as SexoID,								@FechaNacimiento_ as FechaNacimiento,
			@EspCiudadNacimientoID_ as EspCiudadNacimientoID,	@AuxEstadoCivilID_ as AuxEstadoCivilID,
			@CasadoCivil_ as CasadoCivil,					@CasadoIglesia_ as CasadoIglesia,
			@PpalProveedorClave_ as PpalProveedorClave,		@Iniciales_ as Iniciales,
			@NombreCorto_ as NombreCorto,					@SobreNombre_ as SobreNombre,
			@EmpresaID_ as EmpresaID,						@NombreCompleto_ as NombreCompleto
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID