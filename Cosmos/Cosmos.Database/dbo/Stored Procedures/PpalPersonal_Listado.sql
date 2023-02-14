CREATE PROCEDURE [dbo].[PpalPersonal_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalPersonal',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

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
		SET @logMessage =  Concat('EmpresaIDSolicitudBase::', @EmpresaIDSolicitudBase, ':',0, ';')

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

	IF @TipoListado = 'Minimo'
		SELECT  PP.PpalPersonalID AS ID, PP.PpalPersonalClave Clave, EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno as Nombre, 
				PP.PpalPersonalClave NombreCorto, 0 as PadreID
		FROM    PpalPersonal PP
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
		WHERE	PP.EmpresaID = @EmpresaIDSolicitudBase
		ORDER BY 3
	ELSE IF @TipoListado = 'Parcial'
		SELECT  PP.PpalPersonalID,					PP.PpalPersonalClave,		PP.EmpresaID, 
				PP.AuxPuestoID,						PP.ReportaAPpalPersonalID,	PP.PpalAreaID,
				PP.PpalCentroCostoID,				PP.AuxHorarioPersonalID,	PP.CfgEstatusPersonalID,
				PP.EspPersonaID,
				EP.FisicaMoral,						EP.NombreComercial,
				EP.RazonSocial,						EP.Nombre,					EP.ApellidoPaterno,
				EP.ApellidoMaterno,					EP.CURP,					EP.SistemaSexoID,
				EP.FechaNacimiento,					EP.EspCiudadNacimientoID,	EP.AuxEstadoCivilID,
				EP.CasadoCivil,						EP.CasadoIglesia,			EP.Iniciales,
				EP.Sobrenombre,						EP.NombreCorto,				EP.RFC,
				PCC.Nombre as CentroCostoNombre,	AP.Nombre as PuestoNombre,	CEP.Nombre as EstatusNombre,
				EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno as NombreCompleto
		FROM    PpalPersonal PP
		inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
		inner join PpalCentroCosto PCC on PP.PpalCentroCostoID = PCC.PpalCentroCostoID 
		inner join AuxPuesto AP on PP.AuxPuestoID = AP.AuxPuestoID 
		inner join CfgEstatusPersonal CEP on PP.CfgEstatusPersonalID = CEP.CfgEstatusPersonalID 
		WHERE	PP.EmpresaID = @EmpresaIDSolicitudBase
	ELSE
		SELECT  a.PpalPersonalID, a.PpalPersonalClave, a.EmpresaID, a.AuxPuestoID, a.ReportaAPpalPersonalID, a.PpalAreaID, a.PpalCentroCostoID, a.AuxHorarioPersonalID, a.CfgEstatusPersonalID
		FROM    PpalPersonal a 		
		WHERE	a.EmpresaID = @EmpresaIDSolicitudBase

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