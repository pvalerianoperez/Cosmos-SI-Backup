

CREATE PROCEDURE [dbo].[PpalProducto_Consultar]
@PpalProductoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProducto',	
		@Operacion				 nvarchar(20) = 'Read', 
		@logMessage				 varchar(Max) = '',
		@isChangeBeLogged		 bit

-- Variables para valores de columnas
DECLARE @PpalProductoID_		nvarchar(10) = @PpalProductoID,
		@MarcaID_	            int = 0,
		@Nombre_				nvarchar(100) = '',
		@NombreCorto_			nvarchar(20) = '',
		@AuxUnidadID_			int = 0,
		@ClaseProductoID_		int = 0,
		@CfgTipoProductoID_		int = 0,
		@NivelProductoID_		int = 0,
		@MetodoCosteoID_		int = 0,
		@ManejaLotes_			char(1) = '0',
		@ManejaSeries_			char(1) = '0',
		@Reorden_				decimal(18,6) = 0.0,
		@CfgFamiliaProductoID_	int = 0,
		@EstatusProductoID_		int = 0,
		@Maximo_				decimal(18,6) = 0.0,
		@Minimo_				decimal(18,6) = 0.0,
		@CostoPromedio_			decimal(18,6) = 0.0,
		@UltimoCosto_			decimal(18,6) = 0.0,
		@PpalProductoClave_			varchar(20) = '',
		@EmpresaID_				int = 0,
		@CfgTasaIVAID_			int = 0,
		@ExentoIVA_				char(1) = ''

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY	
	BEGIN TRANSACTION

	SET @IDAConsultar = @PpalProductoID
	SELECT  @PpalProductoID_		= PpalProductoID,
			@MarcaID_	            = MarcaID,
			@Nombre_				= Nombre,
			@NombreCorto_			= NombreCorto,
			@AuxUnidadID_			= AuxUnidadID,
			@ClaseProductoID_		= ClaseProductoID,
			@CfgTipoProductoID_		= CfgTipoProductoID,
			@NivelProductoID_		= NivelProductoID,
			@MetodoCosteoID_		= MetodoCosteoID,
			@ManejaLotes_			= ManejaLotes,
			@ManejaSeries_			= ManejaSeries,
			@Reorden_				= Reorden,
			@CfgFamiliaProductoID_	= CfgFamiliaProductoID,
			@EstatusProductoID_		= EstatusProductoID,
			@Maximo_				= Maximo,
			@Minimo_				= Minimo,
			@CostoPromedio_			= CostoPromedio,
			@UltimoCosto_			= UltimoCosto,
			@PpalProductoClave_			= PpalProductoClave,
			@EmpresaID_				= EmpresaID,
			@CfgTasaIVAID_			= CfgTasaIVAID,
			@ExentoIVA_				= ExentoIVA
	FROM PpalProducto
	WHERE PpalProductoID = @IDAConsultar

	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
	BEGIN
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @PpalProductoID)
		ROLLBACK TRANSACTION
	END
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
			SET @logMessage = Concat('PpalAlmacenID::', @PpalProductoID, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @PpalProductoID
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
	END
END TRY
-- Si hubo error lo procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

IF @Errores = 0
	SELECT  @IDAConsultar		as PpalProductoID,				@PpalProductoID_		as PpalProductoID,
			@MarcaID_	            as MarcaID,					@Nombre_				as Nombre,
			@NombreCorto_			as NombreCorto,				@AuxUnidadID_			as AuxUnidadID,
			@ClaseProductoID_		as ClaseProductoID,			@CfgTipoProductoID_		as CfgTipoProductoID,
			@NivelProductoID_		as NivelProductoID,			@MetodoCosteoID_		as MetodoCosteoID,
			@ManejaLotes_			as ManejaLotes,				@ManejaSeries_			as ManejaSeries,
			@Reorden_				as Reorden,					@CfgFamiliaProductoID_	as CfgFamiliaProductoID,
			@EstatusProductoID_		as EstatusProductoID,		@Maximo_				as Maximo,
			@Minimo_				as Minimo,					@CostoPromedio_			as CostoPromedio,
			@UltimoCosto_			as UltimoCosto,				@PpalProductoClave_		as PpalProductoClave,
			@EmpresaID_				as EmpresaID,				@CfgTasaIVAID_			as CfgTasaIVAID,
			@ExentoIVA_				as ExentoIVA

ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID