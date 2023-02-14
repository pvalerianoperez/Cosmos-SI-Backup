

CREATE PROCEDURE [dbo].[PpalProducto_Guardar]
@PpalProductoID		nvarchar(10) = null,
@MarcaID	        int ,
@Nombre				nvarchar(100) = null,
@NombreCorto		nvarchar(20) = null,
@AuxUnidadID		int,
@ClaseProductoID	int,
@CfgTipoProductoID	int,
@NivelProductoID	int,
@MetodoCosteoID		int,
@ManejaLotes		char(1),
@ManejaSeries		char(1),
@Reorden			decimal(18,6),
@CfgFamiliaProductoID	int,
@EstatusProductoID		int,
@Maximo					decimal(18,6),
@Minimo					decimal(18,6),
@CostoPromedio			decimal(18,2),
@UltimoCosto			decimal(18,2),
@PpalProductoClave		varchar(20),
@EmpresaID				int,
@CfgTasaIVAID			int,
@ExentoIVA				char(1)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProducto',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalProductoID_		nvarchar(10) = @PpalProductoID,
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
		@CostoPromedio_			decimal(18,2) = 0.0,
		@UltimoCosto_			decimal(18,2) = 0.0,
		@PpalProductoClave_		varchar(20) = '',
		@EmpresaID_				int = 0,
		@CfgTasaIVAID_			int = 0,
		@ExentoIVA_			char(1) = '0'

DECLARE	@ProductoUltimaClave	varchar(20) = '',
		@PpalProductoDigitos	tinyint

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalProductoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@PpalProductoID_	=	ISNULL(PpalProductoID, 0),
				@MarcaID_	        =    ISNULL(MarcaID, 0),
				@Nombre_			=	ISNULL(Nombre, ''),
				@NombreCorto_		=	ISNULL(NombreCorto, ''),
				@AuxUnidadID_		=	ISNULL(AuxUnidadID, 0),
				@ClaseProductoID_	=	ISNULL(ClaseProductoID, 0),
				@CfgTipoProductoID_	=	ISNULL(CfgTipoProductoID, 0),
				@NivelProductoID_	=	ISNULL(NivelProductoID, 0),
				@MetodoCosteoID_	=	ISNULL(MetodoCosteoID, 0),
				@ManejaLotes_		=	ISNULL(ManejaLotes, '0'),
				@ManejaSeries_		=	ISNULL(ManejaSeries, '0'),
				@Reorden_			=	ISNULL(Reorden, 0.0),
				@CfgFamiliaProductoID_	 = ISNULL(CfgFamiliaProductoID, 0),
				@EstatusProductoID_	=	ISNULL(EstatusProductoID, 0),
				@Maximo_			=	ISNULL(Maximo, 0.0),
				@Minimo_			=	ISNULL(Minimo, 0.0),
				@CostoPromedio_		=	ISNULL(CostoPromedio, 0.0),
				@UltimoCosto_		=	ISNULL(UltimoCosto, 0.0),
				@PpalProductoClave_	=	ISNULL(PpalProductoClave, ''),
				@EmpresaID_			=	ISNULL(EmpresaID, 0),
				@CfgTasaIVAID_		=	ISNULL(CfgTasaIVAID, 0),
				@ExentoIVA_		=	ISNULL(ExentoIVA, '')
		   FROM	PpalProducto WHERE PpalProductoID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalProducto
			SET     
					MarcaID = @MarcaID ,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					AuxUnidadID = @AuxUnidadID,
					ClaseProductoID = @ClaseProductoID,
					CfgTipoProductoID = @CfgTipoProductoID,
					NivelProductoID = @NivelProductoID,
					MetodoCosteoID = @MetodoCosteoID,
					ManejaLotes = @ManejaLotes,
					ManejaSeries = @ManejaSeries,
					Reorden = @Reorden,
					CfgFamiliaProductoID = @CfgFamiliaProductoID,
					EstatusProductoID = @EstatusProductoID,
					Maximo = @Maximo,
					Minimo = @Minimo,
					CostoPromedio = @CostoPromedio,
					UltimoCosto = @UltimoCosto,
					PpalProductoClave = @PpalProductoClave,
					EmpresaID = @EmpresaID,
					CfgTasaIVAID = @CfgTasaIVAID,
					ExentoIVA = @ExentoIVA
			WHERE   PpalProductoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			IF (SELECT ProductoClaveAutomatico  FROM CfgParamConfigUsuarioCosmos) = 'S'
			BEGIN
				-- Lo actualiza en parámetros
				UPDATE	CfgParamConfigUsuarioCosmos
				   SET	ProductoUltimaClave = ProductoUltimaClave + 1
				-- Lee último folio de la serie
				SELECT	@ProductoUltimaClave = ProductoUltimaClave
				  FROM	CfgParamConfigUsuarioCosmos

				SELECT @PpalProductoDigitos = (SELECT ProductoClaveDigitos FROM CfgParamConfigUsuarioCosmos)
				SET @PpalProductoClave = right('00000000000000000000' + cast(cast(@ProductoUltimaClave as decimal) as varchar), @PpalProductoDigitos)
			END
			INSERT  INTO PpalProducto(
					MarcaID,
					Nombre,
					NombreCorto,
					AuxUnidadID,
					ClaseProductoID,
					CfgTipoProductoID,
					NivelProductoID,
					MetodoCosteoID,
					ManejaLotes,
					ManejaSeries,
					Reorden,
					CfgFamiliaProductoID,
					EstatusProductoID,
					Maximo,
					Minimo,
					CostoPromedio,
					UltimoCosto,
					PpalProductoClave,
					EmpresaID,
					CfgTasaIVAID,
					ExentoIVA)
			VALUES  (
					@MarcaID ,
					@Nombre,
					@NombreCorto,
					@AuxUnidadID,
					@ClaseProductoID,
					@CfgTipoProductoID,
					@NivelProductoID,
					@MetodoCosteoID,
					@ManejaLotes,
					@ManejaSeries,
					@Reorden,
					@CfgFamiliaProductoID,
					@EstatusProductoID,
					@Maximo,
					@Minimo,
					@CostoPromedio,
					@UltimoCosto,
					@PpalProductoClave,
					@EmpresaID,
					@CfgTasaIVAID,
					@ExentoIVA)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalProductoID > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
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