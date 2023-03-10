

CREATE PROCEDURE [dbo].[EspPersona_Listado]
@TipoListado varchar(10) = ''
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase	int
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspPersona',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	IF @TipoListado = 'Minimo'
		SELECT  EspPersonaID AS ID,						'' AS Clave,
				CASE WHEN FisicaMoral = 'F' THEN Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno 
											ELSE NombreComercial END AS Nombre,
				CASE WHEN FisicaMoral = 'F' THEN SobreNombre ELSE NombreCorto END AS NombreCorto,
				0 AS PadreID
		FROM    EspPersona
		ORDER BY 3
	ELSE
		SELECT  EspPersonaID,FisicaMoral,NombreComercial,RazonSocial,Nombre,ApellidoPaterno,ApellidoMaterno,RFC,CURP,SistemaSexoID,FechaNacimiento,EspCiudadNacimientoID,
				AuxEstadoCivilID,CasadoCivil,CasadoIglesia,Iniciales,SobreNombre, EspDomicilioIDFacturacion
		FROM    EspPersona
		ORDER BY Nombre

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
		--SET @logMessage =  Concat('BancoID::', @BancoID, ':',0, ';')
		SET @logMessage = ''
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