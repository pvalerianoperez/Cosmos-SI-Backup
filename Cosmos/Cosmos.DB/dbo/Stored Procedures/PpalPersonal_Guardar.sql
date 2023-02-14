

CREATE PROCEDURE [dbo].[PpalPersonal_Guardar]
@PpalPersonalID int,
@PpalPersonalClave varchar(10),
@EmpresaIDSolicitudBase int,
@AuxPuestoID int,
@ReportaAPpalPersonalID int,
@PpalAreaID int,
@PpalCentroCostoID int,
@AuxHorarioPersonalID int,
@CfgEstatusPersonalID int,
--Variables Persona ->
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
@FechaNacimiento datetime = null,
@EspCiudadNacimientoID int = 0,
@AuxEstadoCivilID int = 0,
@CasadoCivil bit,
@CasadoIglesia bit,
@Iniciales varchar(6),
@SobreNombre varchar(25),
@NombreCorto varchar(25)
--@Estatus bit
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalPersonal',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalPersonalClave_ varchar(10) = '',
		@EmpresaID_ int = 0,
		@EspPersonaID_ int,
		@AuxPuestoID_ int = 0,
		@ReportaAPpalPersonalID_ int = 0,
		@PpalAreaID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@AuxHorarioPersonalID_ int = 0,
		@CfgEstatusPersonalID_ int = 0,
		@PpalPersonalID_ int = @PpalPersonalID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalPersonalID

	-- actualiza en Persona
	EXEC @EspPersonaID = [dbo].[EspPersona_Guardar]
			@EspPersonaID = @EspPersonaID,
			@FisicaMoral = @FisicaMoral,
			@NombreComercial= @NombreComercial,
			@RazonSocial = @RazonSocial,
			@Nombre = @Nombre,
			@ApellidoPaterno = @ApellidoPaterno,
			@ApellidoMaterno = @ApellidoMaterno,
			@RFC = @RFC,
			@CURP = @CURP,
			@SexoID = @SexoID,
			@FechaNacimiento = @FechaNacimiento,
			@CiudadNacimientoID = @EspCiudadNacimientoID,
			@EstadoCivilID = @AuxEstadoCivilID,
			@CasadoCivil = @CasadoCivil,
			@CasadoIglesia = @CasadoIglesia,
			@Iniciales = @Iniciales,
			@SobreNombre = @SobreNombre,
			@NombreCorto = @NombreCorto,
			@EspDomicilioIDFacturacion = 2
			,@UsuarioIDBitacora		= @UsuarioIDBitacora
			,@DescripcionBitacora	= @DescripcionBitacora
			,@IpAddress			= @IpAddress	
			,@HostName			= @HostName

	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@PpalPersonalClave_ = IsNull(PpalPersonalClave,''),
	 			@EmpresaID_ = IsNull(EmpresaID,''),
				@EspPersonaID_ = IsNull(EspPersonaID,0), --Variable agregada
				@AuxPuestoID_ = IsNull(AuxPuestoID,''),
				@ReportaAPpalPersonalID_ = IsNull(ReportaAPpalPersonalID,0),
				@PpalAreaID_ = IsNull(PpalAreaID,0),
				@PpalCentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@AuxHorarioPersonalID_ = IsNull(AuxHorarioPersonalID,0),
				@CfgEstatusPersonalID_ = IsNull(CfgEstatusPersonalID,0),
				@PpalPersonalID_ = IsNull(PpalPersonalID,0)
		   FROM	PpalPersonal WHERE PpalPersonalID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @PpalPersonalClave_ = @ClaveNoAsignado and @PpalPersonalClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalPersonal
			SET     PpalPersonalClave = @PpalPersonalClave,
					EspPersonaID = @EspPersonaID,
					EmpresaID = @EmpresaIDSolicitudBase,
					AuxPuestoID = @AuxPuestoID,
					ReportaAPpalPersonalID = @ReportaAPpalPersonalID,
					PpalAreaID = @PpalAreaID,
					PpalCentroCostoID = @PpalCentroCostoID,
					AuxHorarioPersonalID = @AuxHorarioPersonalID,
					CfgEstatusPersonalID = @CfgEstatusPersonalID
			WHERE   PpalPersonalID = @PpalPersonalID
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalPersonal(
					PpalPersonalClave,
					EmpresaID,
					EspPersonaID,
					AuxPuestoID,
					ReportaAPpalPersonalID,
					PpalAreaID,
					PpalCentroCostoID,
					AuxHorarioPersonalID,
					CfgEstatusPersonalID)
			VALUES  (
					@PpalPersonalClave,
					@EmpresaIDSolicitudBase,
					@EspPersonaID,
					@AuxPuestoID,
					@ReportaAPpalPersonalID,
					@PpalAreaID,
					@PpalCentroCostoID,
					@AuxHorarioPersonalID,
					@CfgEstatusPersonalID)
        
        SET     @IDAActualizar = SCOPE_IDENTITY()
    END
    IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalPersonalID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('PpalPersonalClave::', @PpalPersonalClave_, ':', @PpalPersonalClave, ';')
				SET @logMessage = Concat(@logMessage, 'EmpresaID::', @EmpresaID_, ':', @EmpresaIDSolicitudBase, ';')
				SET @logMessage = Concat(@logMessage, 'PuestoID::', @AuxPuestoID_, ':', @AuxPuestoID, ';')
				SET @logMessage = Concat(@logMessage, 'ReportaAPpalPersonalID::', @ReportaAPpalPersonalID_, ':', @ReportaAPpalPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoID::', @PpalCentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'HorarioPersonalID::', @AuxHorarioPersonalID_, ':', @AuxHorarioPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'CfgEstatusPersonalID::', @CfgEstatusPersonalID_, ':', @CfgEstatusPersonalID, ';')
				
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