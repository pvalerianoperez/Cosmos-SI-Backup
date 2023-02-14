CREATE PROCEDURE [dbo].[CfgParamInicioUsuarioCosmos_Guardar]
		@ParamInicioUsuarioCosmosID int,
        @PpalAreaIDInicio int,
        @PpalCentroCostoIDInicio int,
        @CiudadIDInicio int,
        @ConceptoEgresoIDInicio int,
        @ConceptoIngresoIDInicio int,
        @EstadoIDInicio int,
        @EstadoCivilIDInicio int,
        @EstatusClienteIDInicio int,
        @EstatusContactoPersonalIDInicio int,
        @CfgEstatusDocumentoIDInicio int,
        @EstatusPersonalIDInicio int,
        @CmpEstatusProveedorIDInicio int,
        @CmpEstatusRepresentanteProveedorIDInicio int,
        @FamiliaProductoIDInicio int,
        @FormaPagoIDInicio int,
        @GiroEmpresaIDInicio int,
        @HorarioPersonalIDInicio int,
        @IdiomaIDInicio int,
        @MarcaIDInicio int,
        @MedioContactoIDInicio int,
        @MunicipioIDInicio int,
        @PaisIDInicio int,
        @ProfesionIDInicio int,
        @SexoIDInicio int,
        @TipoClienteIDInicio int,
        @TipoContactoPersonalIDInicio int,
        @TipoDomicilioIDInicio int,
        @TipoFechaIDInicio int,
        @TipoHorarioIDInicio int,
        @TipoMailIDInicio int,
        @TipoProductoIDInicio int,
        @CmpTipoProveedorIDInicio int,
        @TipoRepresentanteClienteIDInicio int,
        @CmpTipoRepresentanteProveedorIDInicio int,
        @CfgTipoTelefonoIDInicio int,
        @AuxUnidadIDInicio int,
        @VinculoIDInicio int,
        @ZonaIDInicio int,
        @EmpresaID int,
        @FechaInicio int,
		@CfgUsoTelefonoIDInicio int,
		@PpalSucursalIDInicio int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CfgParamInicioUsuarioCosmos',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalAreaIDInicio_ int,
        @PpalCentroCostoIDInicio_ int,
        @CiudadIDInicio_ int,
        @ConceptoEgresoIDInicio_ int,
        @ConceptoIngresoIDInicio_ int,
        @EstadoIDInicio_ int,
        @EstadoCivilIDInicio_ int,
        @EstatusClienteIDInicio_ int,
        @EstatusContactoPersonalIDInicio_ int,
        @CfgEstatusDocumentoIDInicio_ int,
        @EstatusPersonalIDInicio_ int,
        @CmpEstatusProveedorIDInicio_ int,
        @CmpEstatusRepresentanteProveedorIDInicio_ int,
        @FamiliaProductoIDInicio_ int,
        @FormaPagoIDInicio_ int,
        @GiroEmpresaIDInicio_ int,
        @HorarioPersonalIDInicio_ int,
        @IdiomaIDInicio_ int,
        @MarcaIDInicio_ int,
        @MedioContactoIDInicio_ int,
        @MunicipioIDInicio_ int,
        @PaisIDInicio_ int,
        @ProfesionIDInicio_ int,
        @SexoIDInicio_ int,
        @TipoClienteIDInicio_ int,
        @TipoContactoPersonalIDInicio_ int,
        @TipoDomicilioIDInicio_ int,
        @TipoFechaIDInicio_ int,
        @TipoHorarioIDInicio_ int,
        @TipoMailIDInicio_ int,
        @TipoProductoIDInicio_ int,
        @CmpTipoProveedorIDInicio_ int,
        @TipoRepresentanteClienteIDInicio_ int,
        @CmpTipoRepresentanteProveedorIDInicio_ int,
        @CfgTipoTelefonoIDInicio_ int,
        @AuxUnidadIDInicio_ int,
        @VinculoIDInicio_ int,
        @ZonaIDInicio_ int,
        @EmpresaID_ int,
        @FechaInicio_ int,
		@CfgUsoTelefonoIDInicio_ int,
		@PpalSucursalIDInicio_ int,
		@ParamInicioUsuarioCosmosID_ int = @ParamInicioUsuarioCosmosID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @EmpresaID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	BEGIN
		SELECT	@PpalAreaIDInicio_ = IsNull(PpalAreaIDInicio ,0),
				@PpalCentroCostoIDInicio_ = IsNull( PpalCentroCostoIDInicio,0),
				@CiudadIDInicio_ = IsNull(EspCiudadIDInicio ,0),
				@ConceptoEgresoIDInicio_ = IsNull( PpalConceptoEgresoIDInicio,0),
				@ConceptoIngresoIDInicio_ = IsNull(PpalConceptoIngresoIDInicio ,0),
				@EstadoIDInicio_ = IsNull( EspEstadoIDInicio,0),
				@EstadoCivilIDInicio_ = IsNull(AuxEstadoCivilIDInicio,0),
				@EstatusClienteIDInicio_ = IsNull(CfgEstatusClienteIDInicio ,0),
				@EstatusContactoPersonalIDInicio_ = IsNull(CfgEstatusContactoPersonalIDInicio ,0),
				@CfgEstatusDocumentoIDInicio_ = IsNull(CfgEstatusDocumentoIDInicio ,0),
				@EstatusPersonalIDInicio_ = IsNull(CfgEstatusPersonalIDInicio ,0),
				@CmpEstatusProveedorIDInicio_ = IsNull(CmpEstatusProveedorIDInicio ,0),
				@CmpEstatusRepresentanteProveedorIDInicio_ = IsNull(CmpEstatusRepresentanteProveedorIDInicio ,0),
				@FamiliaProductoIDInicio_ = IsNull(CfgFamiliaProductoIDInicio ,0),
				@FormaPagoIDInicio_ = IsNull(AuxFormaPagoIDInicio ,0),
				@GiroEmpresaIDInicio_ = IsNull( AuxGiroEmpresaIDInicio,0),
				@HorarioPersonalIDInicio_ = IsNull(AuxHorarioPersonalIDInicio ,0),
				@IdiomaIDInicio_ = IsNull(AuxIdiomaIDInicio ,0),
				@MarcaIDInicio_ = IsNull(AuxMarcaIDInicio ,0),
				@MedioContactoIDInicio_ = IsNull(AuxMedioContactoIDInicio ,0),
				@MunicipioIDInicio_ = IsNull(EspMunicipioIDInicio ,0),
				@PaisIDInicio_ = IsNull(EspPaisIDInicio ,0),
				@ProfesionIDInicio_ = IsNull(AuxProfesionIDInicio ,0),
				@SexoIDInicio_ = IsNull(SistemaSexoIDInicio ,0),
				@TipoClienteIDInicio_ = IsNull(CfgTipoClienteIDInicio ,0),
				@TipoContactoPersonalIDInicio_ = IsNull(CfgTipoContactoPersonalIDInicio ,0),
				@TipoDomicilioIDInicio_ = IsNull(CfgTipoDomicilioIDInicio ,0),
				@TipoFechaIDInicio_ = IsNull(CfgTipoFechaIDInicio ,0),
				@TipoHorarioIDInicio_ = IsNull(CfgTipoHorarioIDInicio ,0),
				@TipoMailIDInicio_ = IsNull(CfgTipoMailIDInicio ,0),
				@TipoProductoIDInicio_ = IsNull(CfgTipoProductoIDInicio ,0),
				@CmpTipoProveedorIDInicio_ = IsNull(CmpTipoProveedorIDInicio ,0),
				@TipoRepresentanteClienteIDInicio_ = IsNull(CfgTipoRepresentanteClienteIDInicio ,0),
				@CmpTipoRepresentanteProveedorIDInicio_ = IsNull( CmpTipoRepresentanteProveedorIDInicio,0),
				@CfgTipoTelefonoIDInicio_ = IsNull(CfgTipoTelefonoIDInicio ,0),
				@AuxUnidadIDInicio = IsNull(AuxUnidadIDInicio ,0),
				@VinculoIDInicio_ = IsNull(AuxVinculoIDInicio ,0),
				@ZonaIDInicio_ = IsNull(AuxZonaIDInicio ,0),
				@EmpresaID_ = IsNull(EmpresaID ,0),
				@FechaInicio_ = IsNull(FechaInicio,''),
				@CfgUsoTelefonoIDInicio_ = IsNull(CfgUsoTelefonoIDInicio,0),
				@ParamInicioUsuarioCosmosID_ = IsNull(ParamInicioUsuarioCosmosID,0),
				@PpalSucursalIDInicio_ = ISNULL(PpalSucursalIDInicio, 0)
			FROM CfgParamInicioUsuarioCosmos WHERE EmpresaID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN		
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CfgParamInicioUsuarioCosmos
			SET      PpalAreaIDInicio = @PpalAreaIDInicio,
					 PpalCentroCostoIDInicio = @PpalCentroCostoIDInicio,
					 EspCiudadIDInicio = @CiudadIDInicio,
					 PpalConceptoEgresoIDInicio = @ConceptoEgresoIDInicio,
					 PpalConceptoIngresoIDInicio = @ConceptoIngresoIDInicio,
					 EspEstadoIDInicio = @EstadoIDInicio,
					 AuxEstadoCivilIDInicio = @EstadoCivilIDInicio,
					 CfgEstatusClienteIDInicio = @EstatusClienteIDInicio,
					 CfgEstatusContactoPersonalIDInicio = @EstatusContactoPersonalIDInicio,
					 CfgEstatusDocumentoIDInicio = @CfgEstatusDocumentoIDInicio,
					 CfgEstatusPersonalIDInicio = @EstatusPersonalIDInicio,
					 CmpEstatusProveedorIDInicio = @CmpEstatusProveedorIDInicio,
					 CmpEstatusRepresentanteProveedorIDInicio = @CmpEstatusRepresentanteProveedorIDInicio,
					 CfgFamiliaProductoIDInicio = @FamiliaProductoIDInicio,
					 AuxFormaPagoIDInicio = @FormaPagoIDInicio,
					 AuxGiroEmpresaIDInicio = @GiroEmpresaIDInicio,
					 AuxHorarioPersonalIDInicio = @HorarioPersonalIDInicio,
					 AuxIdiomaIDInicio = @IdiomaIDInicio,
					 AuxMarcaIDInicio = @MarcaIDInicio,
					 AuxMedioContactoIDInicio = @MedioContactoIDInicio,
					 EspMunicipioIDInicio = @MunicipioIDInicio,
					 EspPaisIDInicio = @PaisIDInicio,
					 AuxProfesionIDInicio = @ProfesionIDInicio,
					 SistemaSexoIDInicio = @SexoIDInicio,
					 CfgTipoClienteIDInicio = @TipoClienteIDInicio,
					 CfgTipoContactoPersonalIDInicio = @TipoContactoPersonalIDInicio,
					 CfgTipoDomicilioIDInicio = @TipoDomicilioIDInicio,
					 CfgTipoFechaIDInicio = @TipoFechaIDInicio,
					 CfgTipoHorarioIDInicio = @TipoHorarioIDInicio,
					 CfgTipoMailIDInicio = @TipoMailIDInicio,
					 CfgTipoProductoIDInicio = @TipoProductoIDInicio,
					 CmpTipoProveedorIDInicio = @CmpTipoProveedorIDInicio,
					 CfgTipoRepresentanteClienteIDInicio = @TipoRepresentanteClienteIDInicio,
					 CmpTipoRepresentanteProveedorIDInicio = @CmpTipoRepresentanteProveedorIDInicio,
					 CfgTipoTelefonoIDInicio = @CfgTipoTelefonoIDInicio,
					 AuxUnidadIDInicio = @AuxUnidadIDInicio,
					 AuxVinculoIDInicio = @VinculoIDInicio,
					 AuxZonaIDInicio = @ZonaIDInicio,
					 CfgUsoTelefonoIDInicio = @CfgUsoTelefonoIDInicio,
					 EmpresaID = @EmpresaID,
					 PpalSucursalIDInicio = @PpalSucursalIDInicio
			WHERE   EmpresaID = @IDAActualizar
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			SET @Operacion = 'Update' 	
						 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('PpalAreaIDInicio ::', @PpalAreaIDInicio_ , ':', @PpalAreaIDInicio , ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoIDInicio::', @PpalCentroCostoIDInicio_, ':', @PpalCentroCostoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CiudadIDInicio::', @CiudadIDInicio_, ':', @CiudadIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoEgresoIDInicio::', @ConceptoEgresoIDInicio_, ':', @ConceptoEgresoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'ConceptoIngresoIDInicio::', @ConceptoIngresoIDInicio_, ':', @ConceptoIngresoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EstadoIDInicio::', @EstadoIDInicio_, ':', @EstadoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EstadoCivilIDInicio::', @EstadoCivilIDInicio_, ':', @EstadoCivilIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusClienteIDInicio::', @EstatusClienteIDInicio_, ':', @EstatusClienteIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusContactoPersonalIDInicio::', @EstatusContactoPersonalIDInicio_, ':', @EstatusContactoPersonalIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CfgEstatusDocumentoIDInicio::', @CfgEstatusDocumentoIDInicio_, ':', @CfgEstatusDocumentoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EstatusPersonalIDInicio::', @EstatusPersonalIDInicio_, ':', @EstatusPersonalIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CmpEstatusProveedorIDInicio::', @CmpEstatusProveedorIDInicio_, ':', @CmpEstatusProveedorIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CmpEstatusRepresentanteProveedorIDInicio::', @CmpEstatusRepresentanteProveedorIDInicio_, ':', @CmpEstatusRepresentanteProveedorIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'FamiliaProductoIDInicio::', @FormaPagoIDInicio_, ':', @FormaPagoIDInicio , ';')
				SET @logMessage = Concat(@logMessage, 'GiroEmpresaIDInicio::', @GiroEmpresaIDInicio_, ':', @GiroEmpresaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'HorarioPersonalIDInicio ::', @HorarioPersonalIDInicio_, ':', @HorarioPersonalIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'IdiomaIDInicio::', @IdiomaIDInicio_, ':', @IdiomaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'MarcaIDInicio::', @MarcaIDInicio_, ':', @MarcaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'MedioContactoIDInicio::', @MedioContactoIDInicio_, ':', @MedioContactoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'MunicipioIDInicio::', @MunicipioIDInicio_, ':', @GiroEmpresaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'PaisIDInicio::', @PaisIDInicio_, ':', @PaisIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'ProfesionIDInicio::', @ProfesionIDInicio_, ':', @ProfesionIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'SexoIDInicio::', @SexoIDInicio_, ':', @SexoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoClienteIDInicio::', @GiroEmpresaIDInicio_, ':', @GiroEmpresaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoContactoPersonalIDInicio::', @TipoContactoPersonalIDInicio_, ':', @TipoContactoPersonalIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDomicilioIDInicio::', @TipoFechaIDInicio_, ':', @TipoFechaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoHorarioIDInicio::', @TipoHorarioIDInicio_, ':', @TipoHorarioIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoMailIDInicio::', @TipoMailIDInicio_, ':', @TipoMailIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoProductoIDInicio::', @TipoProductoIDInicio_, ':', @TipoProductoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CmpTipoProveedorIDInicio::', @CmpTipoProveedorIDInicio_, ':', @CmpTipoProveedorIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'TipoRepresentanteClienteIDInicio::', @TipoRepresentanteClienteIDInicio_, ':', @TipoRepresentanteClienteIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CmpTipoRepresentanteProveedorIDInicio::', @CmpTipoRepresentanteProveedorIDInicio_, ':', @CmpTipoRepresentanteProveedorIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CfgTipoTelefonoIDInicio::', @CfgTipoTelefonoIDInicio_, ':', @CfgTipoTelefonoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'AuxUnidadIDInicio::', @AuxUnidadIDInicio_, ':', @AuxUnidadIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'VinculoIDInicio::', @VinculoIDInicio_, ':', @VinculoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'ZonaIDInicio::', @ZonaIDInicio_, ':', @ZonaIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'CfgUsoTelefonoIDInicio::', @CfgUsoTelefonoIDInicio_, ':', @CfgUsoTelefonoIDInicio, ';')
				SET @logMessage = Concat(@logMessage, 'EmpresaID::', @EmpresaID_, ':', @EmpresaID, ';')
				SET @logMessage = Concat(@logMessage, 'FechaInicio::', @FechaInicio_, ':', @FechaInicio, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalIDInicio_, ':', @PpalSucursalIDInicio, ';')

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
		@EmpresaID as GuardarID