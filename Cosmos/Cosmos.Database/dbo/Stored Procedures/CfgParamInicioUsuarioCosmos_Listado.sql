﻿

CREATE PROCEDURE [dbo].[CfgParamInicioUsuarioCosmos_Listado]
@EmpresaID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CfgParamInicioUsuarioCosmos',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT  ParamInicioUsuarioCosmosID,				PpalAreaIDInicio,					PpalCentroCostoIDInicio,		EspCiudadIDInicio ,
            PpalConceptoEgresoIDInicio,				PpalConceptoIngresoIDInicio,		EspEstadoIDInicio,				AuxEstadoCivilIDInicio, 
			CfgEstatusClienteIDInicio,				CfgEstatusContactoPersonalIDInicio, CfgEstatusDocumentoIDInicio,
			CfgEstatusPersonalIDInicio,				CmpEstatusProveedorIDInicio,		CmpEstatusRepresentanteProveedorIDInicio,
			CfgFamiliaProductoIDInicio,				AuxFormaPagoIDInicio,				AuxGiroEmpresaIDInicio,			AuxHorarioPersonalIDInicio, 
			AuxIdiomaIDInicio,						AuxMarcaIDInicio,					AuxMedioContactoIDInicio,		EspMunicipioIDInicio, 
			EspPaisIDInicio,						AuxProfesionIDInicio,				SistemaSexoIDInicio,			CfgTipoClienteIDInicio, 
			CfgTipoContactoPersonalIDInicio, 		CfgTipoDomicilioIDInicio,			CfgTipoFechaIDInicio,			CfgTipoHorarioIDInicio, 
			CfgTipoMailIDInicio,					CfgTipoProductoIDInicio,			CmpTipoProveedorIDInicio,		CfgTipoRepresentanteClienteIDInicio, 
			CmpTipoRepresentanteProveedorIDInicio,	CfgTipoTelefonoIDInicio,			AuxUnidadIDInicio,				AuxVinculoIDInicio, 
			AuxZonaIDInicio,						EmpresaID,							FechaInicio,					CfgUsoTelefonoIDInicio,
			PpalSucursalIDInicio,
			(SELECT RFC FROM EspPersona WHERE EspPersonaID = 
					(SELECT EspPersonaID FROM SistemaEmpresa WHERE EmpresaID = @EmpresaID)) AS EmpresaRFC,
			(SELECT SATRegimenFiscalClave FROM SATRegimenFiscal WHERE SATRegimenFiscalID =
					(SELECT SATRegimenFiscalID FROM EspPersona WHERE EspPersonaID = 
					(SELECT EspPersonaID FROM SistemaEmpresa WHERE EmpresaID = @EmpresaID))) AS EmpresaSATRegimenFiscalClave,
			(SELECT CodigoPostal FROM EspDomicilio WHERE EspDomicilioID =
					(SELECT EspDomicilioIDFacturacion FROM EspPersona WHERE EspPersonaID = 
					(SELECT EspPersonaID FROM SistemaEmpresa WHERE EmpresaID = @EmpresaID))) AS EmpresaCP
	FROM    CfgParamInicioUsuarioCosmos
	WHERE	EmpresaID = @EmpresaID
	

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitacora,
			@TablaNombre		=   @TablaNombreIDBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('EmpresaID::', @EmpresaID, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= @Operacion
												,@UsuarioID			= @UsuarioIDBitacora
												,@Descripcion		= @DescripcionBitacora
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	END
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
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
		COALESCE(ERROR_LINE(), 0) as Linea