CREATE PROCEDURE [dbo].[CoContratoRetencion_Consultar]
@CoContratoRetencionID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoContratoRetencion',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@CoContratoRetencionID_ int = 0,
		@CoContratoRetencionClave_ nvarchar(10) = '',
		@Nombre_ nvarchar(50) = '',			
		@NombreCorto_ varchar(10) = '',
		@CoContratoID_ int = 0,
		@TipoRetencion_ char(1) = '',
		@Porcentaje_ decimal(5,2) = 0,
		@EstimacionInicialAmortizacion_ smallint = 0,
		@EstimacionFinalAmortizacion_ smallint = 0,
		@TipoAmortizacion_ char(1) = '',
		@PorcentajeInicialAmortizacion_ decimal(5,2) = 0,
		@PorcentajeFinalAmortizacion_ decimal(5,2) = 0


SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SET @IDAConsultar = @CoContratoRetencionID
	/************* FIN COPY 1  *********************/
	SELECT	@CoContratoRetencionID_  = CoContratoRetencionID,		@CoContratoRetencionClave_ = CoContratoRetencionClave,	@Nombre_ = Nombre,			
			@NombreCorto_ = NombreCorto,	@CoContratoID_ = CoContratoID,		@TipoRetencion_ = TipoRetencion,	@Porcentaje_ = Porcentaje,
			@EstimacionInicialAmortizacion_ = EstimacionInicialAmortizacion,	@EstimacionFinalAmortizacion_ = EstimacionFinalAmortizacion,
			@TipoAmortizacion_ = TipoAmortizacion,	@PorcentajeInicialAmortizacion_ = PorcentajeInicialAmortizacion, 
			@PorcentajeFinalAmortizacion_ = PorcentajeFinalAmortizacion
	FROM    CoContratoRetencion
	WHERE   CoContratoRetencionID = @IDAConsultar

	/****************** COPY 2 ************************************************/
	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitcora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('CoContratoRetencionID::', @IDAConsultar, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDAConsultar
													,@TablaColumna1		= ''
													,@TablaColumna2		= ''
													,@Operacion			= @Operacion
													,@UsuarioID			= @UsuarioIDBitcora
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
	SELECT  @CoContratoRetencionID_  as CoContratoRetencionID,		@CoContratoRetencionClave_ as CoContratoRetencionClave,	@Nombre_ as Nombre,			
			@NombreCorto_ as NombreCorto,	@CoContratoID_ as CoContratoID,		@TipoRetencion_ as TipoRetencion,	@Porcentaje_ as Porcentaje,
			@EstimacionInicialAmortizacion_ as EstimacionInicialAmortizacion,	@EstimacionFinalAmortizacion_ as EstimacionFinalAmortizacion,
			@TipoAmortizacion_ as TipoAmortizacion,	@PorcentajeInicialAmortizacion_ as PorcentajeInicialAmortizacion, 
			@PorcentajeFinalAmortizacion_ as PorcentajeFinalAmortizacion
	

ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID
/**************** FIN COPY 2 *********************************************/