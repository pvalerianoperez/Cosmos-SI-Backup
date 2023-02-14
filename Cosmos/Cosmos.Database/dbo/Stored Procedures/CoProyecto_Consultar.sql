CREATE PROCEDURE [dbo].[CoProyecto_Consultar]
@CoProyectoID int
/************   COPY 1  ************************************/
-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
/************************************************/
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora  nvarchar(100) = 'CoProyecto',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores de columnas
DECLARE	@PpalSucursalID_ int = 0,
		@CoProyectoClave_ varchar(12) = '',
		@Nombre_ varchar(150) = '',
		@NombreCorto_ varchar(40) = '',
		@NivelPartidaInicio_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@ManejaElementoInicio_ bit = 0,
		@NivelCalendarioInicio_ int = 0,
		@FechaAlta_ date = GetDate(),
		@CP_ int = 0,
		@Inscipcion_ varchar(30) = '',
		@Libro_ varchar(30) = '',
		@Seccion_ varchar(30) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAConsultar = @CoProyectoID
	/************* FIN COPY 1  *********************/
	SELECT  @PpalSucursalID_ = PpalSucursalID,		@CoProyectoClave_ = CoProyectoClave,			@Nombre_ = Nombre,
			@NombreCorto_ = NombreCorto,			@NivelPartidaInicio_ = NivelPartidaInicio,		@PpalCentroCostoID_ = PpalCentroCostoID,
			@ManejaElementoInicio_ = ManejaElementoInicio,	@NivelCalendarioInicio_ = NivelCalendarioInicio,
			@FechaAlta_ = FechaAlta,				@CP_ = EspCP,										@Inscipcion_ = Inscripcion,
			@Libro_ = Libro,						@Seccion_  = Seccion		
	FROM    CoProyecto
	WHERE   CoProyectoID = @IDAConsultar

	/****************** COPY 2 ************************************************/
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
			SET @logMessage = Concat('CoProyectoID::', @IDAConsultar, ':', 0, ';')
	
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
	SELECT  @IDAConsultar as CoProyectoID,					@PpalSucursalID_ as PpalSucursalID,		
			@CoProyectoClave_ as CoProyectoClave,			@Nombre_ as Nombre,	
			@NombreCorto_ as NombreCorto,					@NivelPartidaInicio_ as NivelPartidaInicio,
			@PpalCentroCostoID_ as PpalCentroCostoID,
			@ManejaElementoInicio_ as ManejaElementoInicio,	@NivelCalendarioInicio_ as NivelCalendarioInicio,
			@FechaAlta_ as FechaAlta,						@CP_ as CP,
			@Inscipcion_ as Inscripcion,					@Libro_ as Libro,
			@Seccion_  as Seccion
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID
/**************** FIN COPY 2 *********************************************/