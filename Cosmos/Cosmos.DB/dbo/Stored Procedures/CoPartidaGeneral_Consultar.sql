CREATE PROCEDURE [dbo].[CoPartidaGeneral_Consultar]
@CoPartidaGeneralID int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora			int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoPartidaGeneral',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@PadreID_ int = 0,
		@CoPartidaGeneralClave_ nvarchar(5) = '',
		@Nombre_ nvarchar(40) = '',			
		@NombreCorto_ varchar(10) = '',
		@PpalAreaIDInicio_ int = 0,
		@PpalConceptoEgresoIDInicio_ int = 0,
		@AplicaIVA_ char(1) = '',
		@CoTipoConstruccionID_ int = 0
SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	SET @IDAConsultar = @CoPartidaGeneralID
	/************* FIN COPY 1  *********************/
	SELECT	@PadreID_	= PadreID,					@CoPartidaGeneralClave_ = CoPartidaGeneralClave,		@Nombre_ = Nombre,		
			@NombreCorto_ = NombreCorto,			@PpalAreaIDInicio_ = PpalAreaIDInicio,
			@PpalConceptoEgresoIDInicio_ = PpalConceptoEgresoIDInicio,										@AplicaIVA_ = AplicaIVA,
			@CoTipoConstruccionID_ = CoTipoConstruccionID
	FROM    CoPartidaGeneral
	WHERE   CoPartidaGeneralID = @IDAConsultar

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
			SET @logMessage = Concat('CoPartidaGeneralID::', @IDAConsultar, ':', 0, ';')
	
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
	SELECT  @PadreID_	as PadreID,					@CoPartidaGeneralClave_ as CoPartidaGeneralClave,				@Nombre_ as Nombre,		
			@NombreCorto_ as NombreCorto,			@PpalAreaIDInicio_ as PpalAreaIDInicio,
			@PpalConceptoEgresoIDInicio_ as PpalConceptoEgresoIDInicio,								@AplicaIVA_ as AplicaIVA,
			@CoTipoConstruccionID_ as CoTipoConstruccionID
	

ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID